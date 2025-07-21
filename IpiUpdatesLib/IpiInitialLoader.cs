using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SharedLib;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;

namespace IpiUpdatesLib
{
    // Provides for initial IPI databse fill-in from CompeteIpi for some date and allying conseqiest updates

    public class IpiInitialLoader
    {
        public string IpiFtpUrl         { get; set; }
        public int IpiFtpPort       { get; set; }
        public string IpiFtpLogin       { get; set; }
        public string IpiFtpPassword    { get; set; }
        public bool IpiFtpUseSftp    { get; set; }
        public bool IpiFtpUseSsl    { get; set; }
        public string CompleteIpiDir    { get; set; }
        public DateTime CompleteIpiDate { get; set; }
        public string UpdatesIpiDir     { get; set; }
        public DateTime UpdatesLastDate { get; set; }
        public string LocalWorkFilesDir { get; set; }

        public void ResetDatabase()
        {
            PurgeTables();
            LoadCompleteIpi();
            ApplyUpdates();
        }

        private void PurgeTables()
        {
            // !!! For database connection we rely on DBContext that takes connection string from appsettings.json
            var dbContext = new IpiUpdatesDbContext();
            var conn = dbContext.Database.GetDbConnection();
            conn.Open();
            using (SqlCommand cmd = (SqlCommand)conn.CreateCommand())
            {
                cmd.CommandText = @"
                    select name 
                    from Sys.Tables 
                    where name like ('Rec%') 
                        or name like ('Ipi%') 
                        or name like ('Upd%')";
                var tableNames = new List<string>();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    { 
                        tableNames.Add(r.GetString(0));
                    }
                }

                tableNames.Where(x => !x.Equals("UpdFiles", StringComparison.OrdinalIgnoreCase)).ToList().ForEach(x =>
                {
                    Console.WriteLine($"Truncating table {x}");
                    cmd.CommandTimeout = 0;
                    cmd.CommandText = $"truncate table {x}";
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"... tablse {x} truncated");
                });

                tableNames.Where(x => x.Equals("UpdFiles", StringComparison.OrdinalIgnoreCase)).ToList().ForEach(x =>
                {
                    cmd.CommandText = $"delete from {x}";
                    cmd.ExecuteNonQuery();
                });
            }
        }

        private void LoadCompleteIpi()
        {
            var ftpClient = new SocFtpClient.FtpClient(IpiFtpUrl
                , IpiFtpLogin
                , IpiFtpPassword
                , IpiFtpPort
                , IpiFtpUseSftp
                , IpiFtpUseSsl);
            var inputDir = Path.Combine(CompleteIpiDir, CompleteIpiDate.ToString("yyyyMMdd"));
            var dir = ftpClient.ReadDirectory(inputDir);
            var fileNames = new List<string>();
            dir.ForEach(x => fileNames.Add(x.Split(' ').Last()));
            var outputDir = LocalWorkFilesDir;
            var completeIpiDirForDate = Path.Combine(CompleteIpiDir, CompleteIpiDate.ToString("yyyyMMdd"));
            fileNames.Where(x => x.EndsWith(".zip")).OrderBy(x => x).ToList().ForEach(fileName =>
            {
                ftpClient.DownloadFile(completeIpiDirForDate, fileName, outputDir);
                ZipFile.ExtractToDirectory(Path.Combine(outputDir, fileName), outputDir, true);
                File.Delete(Path.Combine(outputDir, fileName));
                var targetFileFullName = (Path.Combine(outputDir, fileName.Substring(0, fileName.Length - 4)));
                IpiUpdateService.LoadDumpFile(targetFileFullName, x => { });
                File.Delete(targetFileFullName);
            });
        }

        private List<string> GetUpdateFilesList()
        {
            var ftpClient = new SocFtpClient.FtpClient(IpiFtpUrl
                , IpiFtpLogin
                , IpiFtpPassword
                , IpiFtpPort
                , IpiFtpUseSftp
                , IpiFtpUseSsl);
            var inputDir = UpdatesIpiDir;
            var dir = ftpClient.ReadDirectory(inputDir);
            var fileNames = new List<string>();
            dir.ForEach(x => fileNames.Add(x.Split(' ').Last()));
            var firstFileName = $"{CompleteIpiDate.ToString("yyyMMdd")}.IPI";
            var lastFileName = $"{UpdatesLastDate.ToString("yyyMMdd")}.IPI";
            fileNames = fileNames
                .Where(x => string.Compare(x, firstFileName, StringComparison.OrdinalIgnoreCase) >= 0 &&
                    string.Compare(x, lastFileName, StringComparison.OrdinalIgnoreCase) <= 0)
                .OrderBy(x => x)
                .ToList();
            return fileNames;
        }

        private void ApplyUpdates()
        {
            var fileNames = GetUpdateFilesList();

            var ftpClient = new SocFtpClient.FtpClient(IpiFtpUrl
                , IpiFtpLogin
                , IpiFtpPassword
                , IpiFtpPort
                , IpiFtpUseSftp
                , IpiFtpUseSsl);
            fileNames.ForEach(fileName =>
            {
                ftpClient.DownloadFile(UpdatesIpiDir, fileName, LocalWorkFilesDir);
                IpiUpdateService.LoadUpdFile(Path.Combine(LocalWorkFilesDir, fileName), x => { });
                IpiUpdateService.ApplySingleFileUpdates(Path.Combine(LocalWorkFilesDir, fileName), x => { });
                File.Delete(Path.Combine(LocalWorkFilesDir, fileName));
            });
        }

   }
}
