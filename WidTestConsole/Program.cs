using IpiUpdatesLib;
using Microsoft.Data.SqlClient;
using SharedLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using WidAdminLib;
using WidAdminLib.Entities;
using WidServiceLib;
using WidUpdatesLib;
using static WidTestConsole.MwSearchBase;

namespace WidTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Started");
            //IpiAnalyserOld.AddGrId();
            //IpiUpdateService.LoadUpdFile(@"D:\UACRR\WID\IPI\FtpMirror\IPI\download", "20220824.IPI", x => { });
            IpiUpdateService.LoadUpdFile(@"D:\UACRR\WID\FtpMirror\IPI\IPI_PUB\Complete_IPI\DOMAINS\DOMAINS.EDI", x => { });
            //IpiUpdateService.LoadDumpFile(@"D:\UACRR\WID\IPI\FtpMirror\IPI\IPI_Pub\Complete_IPI\20220529\IPI01080.EDI", x => { });
            //IpiUpdateService.LoadDumpFiles();
            //IpiUpdateService.ApplySingleFileUpdates(@"D:\UACRR\WID\ReplicationWorkFiles\Ipi\20220909.IPI", x => { });
            //(new WidTaskPlanner()).PlanTasks();

            /*
            var socWidAdminImporter = new SocWidAdminImporter(@"D:\UACRR\WID\Sources\WidService\DataFromProd");
            socWidAdminImporter.ImportFromFiles();
            */

            return;

           //WidReplicationTests.RunFileDownload();

            /*
                        using (var conn = new SqlConnection(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidUpdates; Server=89.184.65.168\IPSDATA,60675"))
                        {
                            conn.Open();
                            using (var cmd = conn.CreateCommand())
                            {
                                var fileName = "WID20220531104247399300.021";
                                var fileTime = new DateTime(
                                    int.Parse(fileName.Substring(3, 4)),
                                    int.Parse(fileName.Substring(7, 2)),
                                    int.Parse(fileName.Substring(9, 2)),
                                    int.Parse(fileName.Substring(11, 2)),
                                    int.Parse(fileName.Substring(13, 2)),
                                    int.Parse(fileName.Substring(15, 2)),
                                    int.Parse(fileName.Substring(17, 3))
                                ); 
                                HistoryBuilder.BuildHistory(cmd, fileTime);
                            }
                        }
            */
            //RestoreFromInitial(true);
            //CreateInitialHistRecords(true);
            //return;

            //GenUpdRecFiles();

            /*
        try
        {
        using (var conn = new SqlConnection(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWidUpdates; Server=89.184.65.168\IPSDATA,60675"))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    WidUpdatesService.ApplyUpdates(@"D:\UACRR\WID\WidServiceFiles", "WID20220603085853399300.021", cmd, x => { });
                }
            }
        }
        catch (Exception ex)
        {
           //Logger.WriteLine($"ERROR: {ex.Message}");
        }
            */


            //LoadIntoDb("AltTtl");
            //LoadIntoDb("IpiBase");
            //LoadIntoDb("MbrAgreeTerr");
            //LoadIntoDb("IpiName");
            //LoadIntoDb("IpiStatus");
            //LoadIntoDb("Artist");
            //LoadIntoDb("Component");
            //LoadIntoDb("Conflict");
            //LoadIntoDb("Instn");
            //LoadIntoDb("InstnDtl");
            //LoadIntoDb("IntrPty");
            //LoadIntoDb("Iswc");
            //LoadIntoDb("OrgTtlVrExrp");
            //LoadIntoDb("Shares");
            //LoadIntoDb("Submission");
            //LoadIntoDb("Title");
            //LoadIntoDb("WrkOrg");
            //LoadIntoDb("WtrPubRel");
            //WidUpdatesService.LoadAllUpdFiles(@"D:\UACRR\WID\WidSoc-2022-May", new DateTime(2022, 02, 27), true);
            //WidUpdatesService.GenRecEntityFragments();
            //WidUpdatesService.GenRecEntities(@"D:\UACRR\WID\TestingArea\Entities");
            //WidUpdatesService.LoadDscRecFields(@"D:\UACRR\WID\Sources\WidService\WidUpdatesLib\Definitions.txt");
            //LoadUpdate(@"D:\UACRR\WID\FtpMirror\outbox\SOC\WID20210210165513399300.021");
            //var size = ReadFtpFileSize("tblArtist.zip");
            //ReadFtpDirectory("wid-dump");
            //DownloadFtpFile(@"D:\UACRR\WID\FtpDownloadTest", "tblOrgTtlVrExrp.zip");
            //var widAdmin = new WidAdminLib.WidAdminService();
            //var wcfg = widAdmin.GetConfiguration();

            //widAdmin.Run();

        }

        /*
         static void DecompressGs()
         {
            using FileStream compressedFileStream = File.Open(Path.Combine(@"D:\UACRR\WID\WidServiceFiles", "WID20220524085609399300.021.gz"), FileMode.Open);
            using FileStream outputFileStream = File.Create(Path.Combine(@"D:\UACRR\WID\WidServiceFiles", "WID20220524085609399300.021"));
            using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
            decompressor.CopyTo(outputFileStream);

            ZipFile.ExtractToDirectory(Path.Combine(@"D:\UACRR\WID\WidServiceFiles", "WID20220524085609399300.021.gz"), @"D:\UACRR\WID\WidServiceFiles", true);

            
         }

       static void AddConfiguration()
        {
            var widAdmin = new WidAdminLib.WidAdminService();
            widAdmin.AddConfiguration(new WidConfigurationEntity
            {
                Name = "Development environment",
                FtpUrl = "ftp://ftp-aws.fasttrackdcn.net",
                FtpLogin = "wid_140",
                FtpPassword = "ad1WropKoPhlyb",
                FtpWidDumpPath = "wid-dump",
                FtpWidUpdatesPath = "outbox/SOC",
                LocalFilesRootPath = @"D:\UACRR\WID\WidServiceFiles",
                LocalWidDbConnectionString = @"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWid; Server=89.184.65.168\IPSDATA,60675",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            });
        }
        */

        static void GetHistEntityFiles()
        {
            Directory.GetFiles(@"D:\UACRR\WID\Sources\WidService\WidService\Entities").ToList().ForEach(x =>
            {
                var outLines = new List<string>();
                var fileName = (Path.GetFileName(x));
                var inLines = File.ReadAllLines(x);
                inLines.ToList().ForEach(line =>
                {
                    if(line.Contains("[Table"))
                    {
                        outLines.Add(line.Replace("\")]", "Hist\")]"));
                    }
                    else if (line.Contains("public class"))
                    {
                        outLines.Add(line.Replace("Entity", "HistEntity"));
                    }
                    else if (line.Contains(" Wic "))
                    {
                        outLines.Add("        [Column(TypeName = \"datetime\")] public DateTime ValidFrom { get; set; }");
                        outLines.Add("        [Column(TypeName = \"datetime\")] public DateTime ValidTo { get; set; }");
                        outLines.Add(line);
                    }
                    else
                    {
                        outLines.Add(line);
                    }
                });
                
                var outFileName = fileName.Replace("Entity.cs", "HistEntity.cs");
                File.WriteAllLines(Path.Combine(@"D:\UACRR\WID\TestingArea\HistEntityFiles", outFileName), outLines);
            });
        }

        static void GenUpdRecFiles()
        {
            var info = WidUpdatesLib.EntityInfo.GetEntityInfoList();
            info.ForEach(x =>
            {
                if(x.isTran)
                {
                    var fileText = 
$@"
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace WidUpdatesLib.UpdRecs.DerivedUpdRecs
{{
    public class Upd{x.name}: UpdRecTran
    {{
        public Upd{x.name}(SqlCommand cmd, List<string> tranLines) : base(cmd, tranLines)
        {{
        }}

        public override void Apply()
        {{
        }}
    }}
}}
";
                    File.WriteAllText($@"D:\UACRR\WID\TestingArea\UpdRecFiles\Upd{x.name}.cs", fileText);
                }
            });
        }

        static void LoadUpdate(string fileFullName)
        {
            using (StreamReader r = new StreamReader(fileFullName))
            {
                string line;
                Dictionary<string, string> recordTypes = new Dictionary<string, string>();
                while ((line = r.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                        continue;
                    string recordType = line.Substring(0, 3);
                    if(!recordTypes.ContainsKey(recordType))
                    {
                        recordTypes.Add(recordType, "");
                    }
                }
            }
        }


        /*
        static void LoadIntoDb()
        {
            using (SqlConnection conn = new SqlConnection(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWid; Server=89.184.65.168\IPSDATA,60675"))
            {
                conn.Open();
                var entityBulkLoader = new EntityBulkLoader
                {
                    FilePath = @"D:\UACRR\WID\WID-Dump\",
                    conn = conn,
                };
                entityBulkLoader.LoadAll();
            }
        }
        */

        static void LoadIntoDb(string entityName)
        {
            using (SqlConnection conn = new SqlConnection(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWid; Server=89.184.65.168\IPSDATA,60675"))
            {
                conn.Open();
                var entityBulkLoader = new EntityBulkLoader
                {
                    FilePath = @"D:\UACRR\WID\WID-Dump\",
                    Conn = conn,
                };
                entityBulkLoader.LoadSingle(entityName, null);
            }
        }

        static long ReadFtpFileSize(string fileName)
        {
            var ftpClient = new FtpClient("ftp://ftp-aws.fasttrackdcn.net", "wid_140", "ad1WropKoPhlyb");
            return ftpClient.ReadFileSize("wid-dump", fileName);
        }

        static void ReadFtpDirectory(string targetPath)
        {
            var ftpClient = new FtpClient("ftp://ftp-aws.fasttrackdcn.net", "wid_140", "ad1WropKoPhlyb");
            var lines = ftpClient.ReadDirectory(targetPath);

            var fileNames = lines.ConvertAll(x => x.Split(' ').Last());
            var fileSizeSum = lines
                .Where(x => x.Split(' ').Last().EndsWith(".zip"))
                .ToList()
                .ConvertAll(x => long.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[4]))
                .Sum(x => x);
                //.
                //.ConvertAll(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[4]))
                //.

        }
        static void DownloadFtpFile(string localPath, string fileName)
        {
            var ftpClient = new FtpClient("ftp://ftp-aws.fasttrackdcn.net", "wid_140", "ad1WropKoPhlyb");
            ftpClient.DownloadFile("wid-dump", localPath, fileName);
            ZipFile.ExtractToDirectory(Path.Combine(localPath, fileName), localPath, true); ;
        }

        static void CreateInitialHistRecords(bool reCreate)
        {
             try
            {
                using (var conn = new SqlConnection(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWid; Server=89.184.65.168\IPSDATA,60675"))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandTimeout = 0;
                        var infoList = WidServiceLib.EntityInfo.GetEntityInfoList();
                        foreach(var info in infoList)
                        {
                            Console.WriteLine($"Processing {info.name}");
                            cmd.CommandText = $"select top 1 * from {info.tableNameHist}";
                            var r = cmd.ExecuteReader();
                            var hasData = r.HasRows;
                            r.Close();
                            if(!reCreate && hasData)
                            {
                                continue;
                            }

                            var cols = info.entityPropInfoList[0].propertyInfo.Name;
                            for(var i = 1; i < info.entityPropInfoList.Count; i++) // Skip Id and Wic
                            {
                                var propInfo = info.entityPropInfoList[i];
                                cols += $", {propInfo.propertyInfo.Name}";
                            }
                            cmd.CommandText = $"truncate table {info.tableNameHist}; insert {info.tableNameHist}({cols}, ValidFrom, ValidTo) select {cols}, @minDate, @maxDate from {info.tableName}";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@minDate", WidServiceLib.Helpers.msSqlMinDate);
                            cmd.Parameters.AddWithValue("@maxDate", WidServiceLib.Helpers.msSqlMaxDate);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.WriteLine($"ERROR: {ex.Message}");
            }
        }

        static void RestoreFromInitial(bool reCreate)
        {
            try
            {
                using (var conn = new SqlConnection(@"Persist Security Info=False;User=OlegM;Password=111111;Initial Catalog = SocWid; Server=89.184.65.168\IPSDATA,60675"))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandTimeout = 0;
                        var infoList = WidServiceLib.EntityInfo.GetEntityInfoList();
                        foreach (var info in infoList)
                        {
                            Console.WriteLine($"{info.name}");
                            cmd.CommandText = $"select top 1 * from SocWid..{info.tableName}";
                            var r = cmd.ExecuteReader();
                            var hasData = r.HasRows;
                            r.Close();
                            if (!reCreate && hasData)
                            {
                                continue;
                            }

                            var cols = info.entityPropInfoList[1].propertyInfo.Name;
                            for (var i = 2; i < info.entityPropInfoList.Count; i++) // Skip Id and Wic
                            {
                                var propInfo = info.entityPropInfoList[i];
                                cols += $", {propInfo.propertyInfo.Name}";
                            }
                            cmd.CommandText = $"truncate table SocWid..{info.tableName}; insert SocWid..{info.tableName}({cols}) select {cols} from SocWidInitial..{info.tableName}";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
