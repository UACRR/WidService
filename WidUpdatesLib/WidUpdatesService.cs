using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WidUpdatesLib.Entities;
using WidUpdatesLib.UpdRecs;

namespace WidUpdatesLib
{
    public class WidUpdatesService
    {
        public delegate void ProgressChanged(double percentDone);
        public delegate void TransStarted(int lineIdx);


        public class ProgressNotifier
        {
            public long fileSize;
            public double accBytesRead;
            public double totalBytesRead;
            public double bytesInOnePercent;

            public ProgressNotifier(string path, string fileName)
            {
                var fileFullName = Path.Combine(path, fileName);
                FileInfo fi = new FileInfo(fileFullName);
                fileSize = fi.Length;
                accBytesRead = 0;
                totalBytesRead = 0.0;
                bytesInOnePercent = fileSize / 100.00;
            }
            public void NotifyProgress(string line, ProgressChanged progressChanged)
            {
                if(string.IsNullOrEmpty(line))
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

        private static Dictionary<string, string> _dscFieldColNames;
        private static Dictionary<string, BulkUploadToSql>  _bulkLoaders = new Dictionary<string, BulkUploadToSql>();
        
        public static void LoadDscRecFields(string fileFullName)
        {
            using (StreamReader file = new StreamReader(fileFullName))
            {
                string line;
                string[] recTypeCodes = null;
                int seqNr = 1;

                var dbConext = new WidUpdatesDbContext();
                dbConext.RemoveRange(dbConext.DscRecFields);
                dbConext.SaveChanges();

                while ((line = file.ReadLine()) != null)
                {
                    if(string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    var fields = line.Split("\t");
                    if(fields[0].Equals("#"))
                    {
                        recTypeCodes = fields;
                        seqNr = 1;
                        continue;
                    }

                    for(int i = 1; i < recTypeCodes.Length; i++)
                    {
                        dbConext.Add(new DscRecField
                        {
                            RecTypeCode = recTypeCodes[i],
                            SeqNr = seqNr,
                            Field = fields[0],
                            Start = int.Parse(fields[1]),
                            Size = int.Parse(fields[2]),
                            Fmt = fields[3][0],
                            Req = fields[4][0],
                            Dsc = fields[5],
                            Rules = fields[6],
                        });
                        dbConext.SaveChanges();
                    }
                    seqNr++;
                }
                file.Close();
            }
        }

        public static void GenRecEntities(string path)
        {
            var dbConext = new WidUpdatesDbContext();

            _dscFieldColNames = new Dictionary<string, string>();
            dbConext.DscFieldColNames.ToList().ForEach(x =>
            {
                _dscFieldColNames.Add(x.FieldName, x.ColName);
            });

            dbConext.DscRecTypes.ToList().ForEach(x =>
            {
                GenRecEntity(dbConext, path, x);
            });
        }

        private static string Capitalize(string source)
        {
            if (source.Length == 0)
                return "";
            else if (source.Length == 1)
                return source.ToUpper();
            else
                return source.Substring(0, 1).ToUpper() + source.Substring(1).ToLower();
        }

        private static void GenRecEntity(WidUpdatesDbContext dbConext, string path, DscRecType recType)
        {
            var sw = new StringWriter();
            sw.WriteLine( "using System.ComponentModel.DataAnnotations.Schema;");
            sw.WriteLine( "");
            sw.WriteLine( "");
            sw.WriteLine( "namespace WidUpdatesLib.Entities");
            sw.WriteLine( "{");
            sw.WriteLine($"    [Table(\"Rec{Capitalize(recType.Code)}\")]");
            sw.WriteLine($"    public class Rec{Capitalize(recType.Code)}");
            sw.WriteLine( "    {");
            sw.WriteLine("        [Column(TypeName = \"int\")] public int Id { get; set; }");
            sw.WriteLine("        [Column(TypeName = \"int\")] public int UpdFileId { get; set; }");
            dbConext.DscRecFields
                .Where(x => x.RecTypeCode == recType.Code)
                .OrderBy(x => x.SeqNr)
                .ToList()
                .ForEach(x =>
                {
                    sw.WriteLine($"        [CustomPosInFile({x.Start}, {x.Size})] [Column(TypeName = \"varchar({x.Size})\")] public string {_dscFieldColNames[x.Field]} {{ get; set; }}");
                });
            sw.WriteLine("");
            sw.WriteLine("        public UpdFile UpdFile { get; set; }");
            sw.WriteLine("    }");
            sw.WriteLine("}");
            sw.WriteLine("");
            File.WriteAllText(Path.Combine(path, $"Rec{Capitalize(recType.Code)}.cs"), sw.ToString());
        }
    
        public static void GenRecEntityFragments()
        {
            var sw = new StringWriter();
            var dbContext = new WidUpdatesDbContext();
            dbContext.DscRecTypes.ToList().ForEach(x =>
            {
                sw.WriteLine($"modelBuilder.Entity<Rec{Capitalize(x.Code)}>().HasNoKey();");
            });
            dbContext.DscRecTypes.ToList().ForEach(x =>
            {
                sw.WriteLine($"public DbSet<Rec{Capitalize(x.Code)}> Rec{Capitalize(x.Code)} {{ get; set; }}");
            });
            dbContext.DscRecTypes.ToList().ForEach(x =>
            {
                sw.WriteLine($"modelBuilder.Entity<Rec{Capitalize(x.Code)}>().HasOne(x => x.UpdFile).WithMany(x => x.Rec{Capitalize(x.Code)}Lst).OnDelete(DeleteBehavior.Cascade);");
            });
            var str = sw.ToString();
        }

        public static void LoadUpdFile(string path, string fileName, ProgressChanged progressChanged)
        {
            var dbContext = new WidUpdatesDbContext();
            var updFile = dbContext.UpdFiles.SingleOrDefault(x => x.Name.ToLower() == fileName.ToLower());
            if (updFile == null)
            {
                updFile = new UpdFile
                {
                    Name = fileName,
                    Year = int.Parse(fileName.Substring(3, 4)),
                    Month = int.Parse(fileName.Substring(7, 2)),
                    Day = int.Parse(fileName.Substring(9, 2)),
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

                var fileFullName = Path.Combine(path, fileName);
                FileInfo fi = new FileInfo(fileFullName);
                var fileSize = fi.Length;
                var accBytesRead = 0;
                var totalBytesRead = 0.0;
                var bytesInOnePercent = fileSize / 100.00;

                using (StreamReader sr = new StreamReader(fileFullName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if(string.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        var byteCnt = line.Length;
                        accBytesRead += byteCnt;
                        totalBytesRead += byteCnt;
                        if (accBytesRead > bytesInOnePercent)
                        {
                            progressChanged(100* Convert.ToDouble(totalBytesRead) / fileSize);
                            accBytesRead = 0;
                        }

                       var recCode = line.Substring(0, 3);
                        var info = EntityInfo.GetEntityInfoEntry(recCode);

                        if(info == null) // Skip header records
                        {
                            continue;
                        }

                        BulkUploadToSql bulkLoader;
                        if(_bulkLoaders.ContainsKey(recCode))
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

        /*
        public static void LoadAllUpdFiles(string path, DateTime startDate, bool purgeAllBeforeLoad = false)
        {
            if (purgeAllBeforeLoad)
            {
                var dbContext = new WidUpdatesDbContext();
                dbContext.Database.GetDbConnection().Open();
                using (SqlCommand cmd = (SqlCommand)dbContext.Database.GetDbConnection().CreateCommand())
                {
                    var eil = EntityInfo.GetEntityInfoList();
                    eil.ForEach(x =>
                    {
                        cmd.CommandText = $"truncate table {x.tableName}";
                        cmd.ExecuteNonQuery();
                    });
                    cmd.CommandText = $"delete from UpdFiles";
                    cmd.ExecuteNonQuery();
                }
            }

            Directory.GetFiles(path)
                .ToList()
                .ForEach(x =>
                {
                    var fileName = Path.GetFileName(x);
                    var fileDate = new DateTime(int.Parse(fileName.Substring(3, 4)), int.Parse(fileName.Substring(7, 2)), int.Parse(fileName.Substring(9, 2)));
                    if (fileDate >= startDate)
                    {
                        LoadUpdFile(path, fileName, null);
                    }
                });
            _bulkLoaders.Values.ToList().ForEach(x =>
            {
                x.Flush();
            });
        }
        */
    
        public static void ApplyUpdates (string path, string fileName, SqlCommand cmd, int? startLineIdx, 
            ProgressChanged progressChanged, TransStarted transStarted)
        {
            Logger.SetRootPath(Path.Combine(path, "Log"));
            Logger.SetSubFolder(fileName);
            Logger.WriteLine($"PROCESSING FILE {Path.Combine(path, fileName)}");

            var fileTime = new DateTime(
                int.Parse(fileName.Substring(3, 4)),
                int.Parse(fileName.Substring(7, 2)),
                int.Parse(fileName.Substring(9, 2)),
                int.Parse(fileName.Substring(11, 2)),
                int.Parse(fileName.Substring(13, 2)),
                int.Parse(fileName.Substring(15, 2)),
                int.Parse(fileName.Substring(17, 3))
            );

            var progressNotifier = new ProgressNotifier(path, fileName);
            var lineIdx = -1;
            using (StreamReader sr = new StreamReader(Path.Combine(path, fileName)))
            {
                string line = sr.ReadLine();
                lineIdx++;
                progressNotifier.NotifyProgress(line, progressChanged);

                // Skip already processed lines
                if (startLineIdx != null)
                {
                    while (lineIdx < startLineIdx)
                    {
                        line = sr.ReadLine();
                        lineIdx++;
                        progressNotifier.NotifyProgress(line, progressChanged);
                    }
                }


                while (true)
                {
                    if(line == null)
                    {
                        break;
                    }

                    if (string.IsNullOrEmpty(line))
                    {
                        line = sr.ReadLine();
                        lineIdx++;
                        progressNotifier.NotifyProgress(line, progressChanged);
                        continue;
                    }

                    var recCode = line.Substring(0, 3);
                    var info = EntityInfo.GetEntityInfoEntry(recCode);

                    if (info == null || !info.isTran) // Skip header records and not transaction lines
                    {
                        Logger.WriteLine($"{recCode}: not transaction, skipped");
                        line = sr.ReadLine();
                        lineIdx++;
                        progressNotifier.NotifyProgress(line, progressChanged);
                        continue;
                    }

                    var tranSeqNr = int.Parse(line.Substring(3, 8));
                    var tranLines = new List<string>();
                    tranLines.Add(line);
                    transStarted(lineIdx);
                    while ((line = sr.ReadLine()) != null)
                    {
                        lineIdx++;
                        progressNotifier.NotifyProgress(line, progressChanged);

                        var detailRecCode = line.Substring(0, 3);
                        var detailInfo = EntityInfo.GetEntityInfoEntry(detailRecCode);
                        if(detailInfo == null || detailInfo.isTran)
                        {
                            break;
                        }
                        tranLines.Add(line);
                    }

                    var updRecTran = (UpdRecTran)Activator.CreateInstance(info.updClassType, cmd, tranLines, fileTime);
                    if(!updRecTran.HasUpdWic() && !updRecTran.HasRecLnk())
                    {
                        Logger.WriteLine($"{recCode}-{tranSeqNr}: No WicCode provided, skipped");
                        //updRecTran.ToHtmlFile(Logger.GetCurrentFolder());
                        continue;
                    }

                    using(var sqlTran = cmd.Connection.BeginTransaction())
                    {
                        try
                        {
                            Logger.WriteLine($"{recCode}-{tranSeqNr}: processing, {updRecTran.GetUpdWicString()}");
                            cmd.Transaction = sqlTran;
                            updRecTran.Apply();
                            sqlTran.Commit();
                        }
                        catch(Exception ex)
                        {
                            sqlTran.Rollback();
                            updRecTran.ToHtmlFile(Logger.GetCurrentFolder());
                            for(int i = 0; i < cmd.Parameters.Count; i++)
                            {
                                var par = cmd.Parameters[i];
                                Console.WriteLine($"{par.ParameterName} = [{par.Value}]");
                            }
                            throw;
                        }
                    }
                    //updRecTran.ToHtmlFile(Logger.GetCurrentFolder());
                }
            }

            //HistoryBuilder.BuildHistory(cmd, fileTime);

            Logger.WriteLine($"FINISHED PROCESSING FILE {Path.Combine(path, fileName)}");
        }
    }
}
