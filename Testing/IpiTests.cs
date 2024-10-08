using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class IpiTests
    {
       public class DumpFileInfo
        {
            public int Id { get;set; }
            public string Name { get;set; }
        }
        public static void LoadDumpFiles(string ipiFtpUrl, 
            string ipiFtpLogin, 
            string ipiFtpPwd, 
            string inputDir,
            string outputDir,
            string connString)
        {
            var ftpClient = new FtpClient(ipiFtpUrl, ipiFtpLogin, ipiFtpPwd, true);
            var dir = ftpClient.ReadDirectory(inputDir);
            var fileNames = new List<string>();
            dir.ForEach(x => fileNames.Add(x.Split(' ').Last()));

            RegisterFilesInDb(fileNames, connString);

            var fileInfoList = LoadFileInfo(connString);

            fileInfoList.ForEach(x =>
            {
                var outputFileFullName = Path.Combine(outputDir, x.Name);
                var targetFileFullName = (Path.Combine(outputDir, x.Name.Substring(0, x.Name.Length - 4)));
                
                File.Delete(outputFileFullName);
                ftpClient.DownloadFile(inputDir, x.Name, outputDir);

                File.Delete(targetFileFullName);
                ZipFile.ExtractToDirectory(outputFileFullName, outputDir);
                File.Delete(outputFileFullName);
                
                LoadDumpFile(targetFileFullName, connString, x.Id);
                File.Delete(targetFileFullName);
            });
        }

        public static void RegisterFilesInDb(List<string> fileNames, string connString)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        truncate table FullDumpFileRecords
                        truncate table FullDumpFiles
                    ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"
                        insert SocIpiTesting..FullDumpFiles (Name) values (@Name)
                    ";

                    fileNames.Where(x => x.EndsWith(".zip")).OrderBy(x => x).ToList().ForEach(x =>
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", x);
                        cmd.ExecuteNonQuery();
                    });

                    var fileInfo = new List<DumpFileInfo> ();
                    cmd.CommandText = "select * from SocIpiTesting..FullDumpFiles order by Id";
                    cmd.Parameters.Clear();
                    using(var r = cmd.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            fileInfo.Add(new DumpFileInfo { Id = r.GetInt32(0), Name = r.GetString(1) });
                        }
                    }
                }
            }
        }

        public static List<DumpFileInfo> LoadFileInfo(string connString)
        {
            var fileInfo = new List<DumpFileInfo> ();
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using(var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from FullDumpFiles order by Id";
                    cmd.Parameters.Clear();
                    using(var r = cmd.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            fileInfo.Add(new DumpFileInfo { Id = r.GetInt32(0), Name = r.GetString(1) });
                        }
                    }
                }
            }
            return fileInfo;
        }

        public static void LoadDumpFile(string fileFullName, string connString, int fileId)
        {
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                var bcp = new BulkUploadToSql();
                bcp.conn = conn;
                bcp.TableName = "FullDumpFileRecords";
                using (StreamReader read = new StreamReader(fileFullName)) {
                    string line;
                    while ((line = read.ReadLine()) != null) {
                        var data = new List<object>();
                        data.Add(DBNull.Value);
                        data.Add(fileId);
                        data.Add(line);
                        bcp.AddData(data);
                    }
                }
                bcp.Flush();
            }
        }

    }
}
