using IpiUpdatesLib.Entities;
using IpiUpdatesLib.StructuredEntities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SharedLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace IpiUpdatesLib
{
    public class IpiUpdateService
    {
        public delegate void ProgressChanged(double percentDone);

        private static readonly List<string> _mainTableNames = new List<string>
        {
            "IpiAgreement",
            "IpiBase",
            "IpiName",
            "IpiNameUsage",
            "IpiNationality",
            "IpiRemark",
            "IpiStatus",
            "IpiTerritory",
        };

        public class ProgressNotifier
        {
            public long fileSize;
            public double accBytesRead;
            public double totalBytesRead;
            public double bytesInOnePercent;
            ProgressChanged progressChanged;

            public ProgressNotifier(string fileFullName, ProgressChanged progressChanged)
            {
                this.progressChanged = progressChanged;
                FileInfo fi = new FileInfo(fileFullName);
                fileSize = fi.Length;
                accBytesRead = 0;
                totalBytesRead = 0.0;
                bytesInOnePercent = fileSize / 100.00;
            }
            public ProgressNotifier(string path, string fileName, ProgressChanged progressChanged)
            {
                this.progressChanged = progressChanged;
                var fileFullName = Path.Combine(path, fileName);
                FileInfo fi = new FileInfo(fileFullName);
                fileSize = fi.Length;
                accBytesRead = 0;
                totalBytesRead = 0.0;
                bytesInOnePercent = fileSize / 100.00;
            }
            public void NotifyProgress(string line)
            {
                if (string.IsNullOrEmpty(line))
                {
                    return;
                };
                var byteCnt = line.Length;
                accBytesRead += byteCnt;
                totalBytesRead += byteCnt;
                if (accBytesRead > bytesInOnePercent)
                {
                    progressChanged(100 * Convert.ToDouble(totalBytesRead) / fileSize);
                    accBytesRead = 0;
                }
            }
        }

        private static Dictionary<string, BulkUploadToSql> _bulkLoaders = new Dictionary<string, BulkUploadToSql>();

        public static void LoadDumpFiles()
        {
            SqlQueries.SocIpiDbName = "SocIpi_2024_08_31";
            var ftpClient = new FtpClient("ftp://ftp.suisa.ch", "UACRR", "S0c-74084lXY-?", true);
            var inputDir = "IPI/IPI_Pub/Complete_IPI/20240831";
            var dir = ftpClient.ReadDirectory(inputDir);
            var fileNames = new List<string>();
            dir.ForEach(x => fileNames.Add(x.Split(' ').Last()));
            var outputDir = @"d:\Tmp";
            fileNames.Where(x => x.EndsWith(".zip")).OrderBy(x => x).ToList().ForEach(fileName =>
            {
                ftpClient.DownloadFile("IPI/IPI_Pub/Complete_IPI/20240831", fileName, outputDir);
                ZipFile.ExtractToDirectory(Path.Combine(outputDir, fileName), outputDir, true);
                File.Delete(Path.Combine(outputDir, fileName));
                var targetFileFullName = (Path.Combine(outputDir, fileName.Substring(0, fileName.Length - 4)));
                LoadDumpFile(targetFileFullName, x => { });
                File.Delete(targetFileFullName);
            });
        }

        public static void LoadDumpFile(string fileFullName, ProgressChanged progressChanged)
        {
            SqlTransaction tran = null;
            try
            {
                var dbContext = new IpiUpdatesDbContext();
                var conn = dbContext.Database.GetDbConnection();
                conn.Open();
                using(tran = (SqlTransaction)conn.BeginTransaction())
                using (var cmd = (SqlCommand)conn.CreateCommand())
                {
                    cmd.Transaction = tran;
                    var eil = EntityInfo.GetEntityInfoList();
                    FileInfo fi = new FileInfo(fileFullName);
                    var fileSize = fi.Length;
                    var accBytesRead = 0;
                    var totalBytesRead = 0.0;
                    var bytesInOnePercent = fileSize / 100.00;

                    _bulkLoaders.Clear();
                    _mainTableNames.ForEach(x =>
                    {
                        _bulkLoaders.Add(x, new BulkUploadToSql
                        {
                            conn = (SqlConnection)dbContext.Database.GetDbConnection(),
                            TableName = x,
                            tran = tran,
                        });
                    });

                    List<string> transLines = null;
                    using (StreamReader sr = new StreamReader(fileFullName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (string.IsNullOrEmpty(line))
                            {
                                continue;
                            }

                            var byteCnt = line.Length;
                            accBytesRead += byteCnt;
                            totalBytesRead += byteCnt;
                            if (accBytesRead > bytesInOnePercent)
                            {
                                progressChanged(100 * Convert.ToDouble(totalBytesRead) / fileSize);
                                accBytesRead = 0;
                            }

                            var recCode = line.Substring(0, 3);

                            if (recCode == "TRL" || recCode == "HDR" || recCode == "GRH" || recCode == "GRT" || recCode == "TRS" || recCode == "DRS")
                            {
                                continue;
                            }

                            var info = EntityInfo.GetEntityInfoEntry(recCode);

                            if (info.isTrans)
                            {
                                if (transLines != null)
                                {
                                    AddBulkLoadData(transLines, _bulkLoaders);
                                }
                                transLines = new List<string>();
                                transLines.Add(line);
                            }
                            else if (info.isDetail || info.isDomain)
                            {
                                transLines.Add(line);
                            }
                            else
                            {
                                if (transLines != null)
                                {
                                    AddBulkLoadData(transLines, _bulkLoaders);
                                    transLines = null;
                                }
                            }
                        }
                    }

                    // Add lines of the last transaction
                    if (transLines != null)
                    {
                        AddBulkLoadData(transLines, _bulkLoaders);
                    }

                    _bulkLoaders.Values.ToList().ForEach(x =>
                    {
                        x.Flush();
                    });
                    tran.Commit();
                }
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw;
            }
        }
        public static void LoadUpdFile(string fileFullName, ProgressChanged progressChanged)
        {
            var fileName = Path.GetFileNameWithoutExtension(Path.GetFileName(fileFullName));
            var dbContext = new IpiUpdatesDbContext();
            var updFile = dbContext.UpdFiles.SingleOrDefault(x => x.Name.ToLower() == fileName.ToLower());
            if (updFile == null)
            {
                updFile = new UpdFile
                {
                    Name = fileName,
                    Year = 0,
                    Month = 0,
                    Day = 0,
                };
                dbContext.Add(updFile);
                dbContext.SaveChanges();
            }

            dbContext.Database.GetDbConnection().Open();
            using (SqlCommand cmd = (SqlCommand)dbContext.Database.GetDbConnection().CreateCommand())
            {
                var eil = EntityInfo.GetEntityInfoList();
                cmd.Parameters.AddWithValue("@updFileId", updFile.Id);
                eil.ForEach(x =>
                {
                    cmd.CommandText = $"delete from {x.tableName} where UpdFileId = @updFileId";
                    cmd.ExecuteNonQuery();
                });

                FileInfo fi = new FileInfo(fileFullName);
                var fileSize = fi.Length;
                var accBytesRead = 0;
                var totalBytesRead = 0.0;
                var bytesInOnePercent = fileSize / 100.00;

                var grId = "";

                using (StreamReader sr = new StreamReader(fileFullName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        var byteCnt = line.Length;
                        accBytesRead += byteCnt;
                        totalBytesRead += byteCnt;
                        if (accBytesRead > bytesInOnePercent)
                        {
                            progressChanged(100 * Convert.ToDouble(totalBytesRead) / fileSize);
                            accBytesRead = 0;
                        }

                        var recCode = line.Substring(0, 3);

                        if(recCode == "TRL" || recCode == "TRS" || recCode == "DRS")
                        {
                            continue;
                        }

                        var info = EntityInfo.GetEntityInfoEntry(recCode);

                        var isHeadRec = recCode == "HDR" || recCode == "GRH" || recCode == "GRT";
                        if(recCode == "GRH")
                        {
                            grId = line.Substring(6, 5);
                        }

                        BulkUploadToSql bulkLoader;
                        if (_bulkLoaders.ContainsKey(recCode))
                        {
                            bulkLoader = _bulkLoaders[recCode];
                        }
                        else
                        {
                            bulkLoader = new BulkUploadToSql();
                            bulkLoader.conn = (SqlConnection)dbContext.Database.GetDbConnection();
                            bulkLoader.TableName = info.tableName;
                            _bulkLoaders.Add(recCode, bulkLoader);
                        }

                        var data = new List<object>();
                        data.Add(DBNull.Value);
                        data.Add(updFile.Id);
                        if(!isHeadRec)
                        {
                            data.Add(grId);
                        }
                        info.entityPropInfoList.ForEach(x =>
                        {
                            string value = "";
                            if (x.start < line.Length)
                            {
                                value = line.Substring(x.start - 1, x.size);
                            }
                            data.Add(value);
                        });

                        bulkLoader.AddData(data);
                    }
                }

                _bulkLoaders.Values.ToList().ForEach(x =>
                {
                    x.Flush();
                });
            }
        }

        public static void ApplySingleFileUpdates(string fileFullName, ProgressChanged progressChanged)
        {
            var progressNotifier = new ProgressNotifier(fileFullName, progressChanged);
            using (StreamReader sr = new StreamReader(fileFullName))
            {
                string line;
                List<string> transLines = null;
                while ((line = sr.ReadLine()) != null)
                {
                    progressNotifier.NotifyProgress(line);

                    var recCode = line.Substring(0, 3);
                    var info = EntityInfo.GetEntityInfoEntry(recCode);

                    if (info == null) // Skip header records
                    {
                        continue;
                    }

                    if(info.isTrans)
                    {
                        if(transLines != null)
                        {
                            ProcessTrans(transLines);
                        }
                        transLines = new List<string>();
                        transLines.Add(line);
                    }
                    else if (info.isDetail || info.isDomain)
                    {
                        transLines.Add(line);
                    }
                    else
                    {
                        if (transLines != null)
                        {
                            ProcessTrans(transLines);
                            transLines = null;
                        }
                    }

                }
            }

        }

        private static void ProcessTrans(List<string> transLines)
        {
            var recType = transLines[0].Substring(0, 3);
            var className = char.ToUpper(recType[0]) + recType.Substring(1).ToLower();
            var classType = Type.GetType("IpiUpdatesLib.StructuredEntities." + className);
            var transObj = (TransBase)Activator.CreateInstance(classType);
            transObj.Apply(transLines);
            Console.WriteLine($"Processed {transLines[0]}");
        }

        private static void AddBulkLoadData(List<string> transLines, Dictionary<string, BulkUploadToSql> bulkLoaders)
        {
            var recType = transLines[0].Substring(0, 3);
            var className = char.ToUpper(recType[0]) + recType.Substring(1).ToLower();
            var classType = Type.GetType("IpiUpdatesLib.StructuredEntities." + className);
            var transObj = (TransBase)Activator.CreateInstance(classType);
            transObj.AddBulkLoadData(transLines, bulkLoaders);
        }
    }
}
