using Microsoft.Data.SqlClient;
using SharedLib;
using System;
using IpiUpdatesLib;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WidServiceLib;
using static WidReplicationServiceLib.IWidReplicationService;

namespace WidReplicationServiceLib
{
    public class WidReplicationService : IWidReplicationService
    {
        public event EventHandler<ActionStatusChangedArgs> ActionStatusChanged;

        public string WidFtpUrl { get; set; }
        public string WidFtpLogin { get; set; }
        public string WidFtpPassword { get; set; }
        public string WidFtpDumpPath { get; set; }
        public string WidFtpUpdatesPath { get; set; }
        public string WidWorkFilesRootPath { get; set; }
        public string IpiFtpUrl { get; set; }
        public string IpiFtpLogin { get; set; }
        public string IpiFtpPassword { get; set; }
        public string IpiFtpDumpPath { get; set; }
        public string IpiFtpUpdatesPath { get; set; }
        public string IpiWorkFilesRootPath { get; set; }
        public string ConnectionString { get; set; }

        private void EmulateTaskRun()
        {
            /*
            InvokeEvent(ActionEventType.Started, 0);
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(_delay).Wait();
                InvokeEvent(ActionEventType.InProgress, i / 10);
            }
            */
            InvokeEvent(ActionEventType.Completed, 0);
        }
        private void InvokeEvent(ActionEventType eventType, object eventInfo)
        {
            ActionStatusChanged?.Invoke(this,
                new ActionStatusChangedArgs
                {
                    EventType = eventType,
                    EventInfo = eventInfo,
                });
        }

        public void RunWidFileDownload(string ftpPath, string fileName)
        {
            var ftpClient = new FtpClient(WidFtpUrl, WidFtpLogin, WidFtpPassword);

            var fileExt = Path.GetExtension(fileName);
            var adjustedFileName = fileName;
            if(!fileExt.Equals(".zip", StringComparison.OrdinalIgnoreCase))
            {
                if(!ftpClient.FileExists(ftpPath, fileName))
                {
                    if(fileExt.Equals(".021"))
                    {
                        adjustedFileName = $"{fileName}.gz";
                    }
                    else
                    {
                        adjustedFileName = Path.GetFileNameWithoutExtension(fileName);
                    }
                }
            }

            ftpClient.FtpEvent += (sender, e) =>
            {
                switch (e.EventType)
                {
                    case FtpClient.FtpEventType.FileDownloadStarted:
                        InvokeEvent(ActionEventType.Started, e.EventInfo);
                        break;
                    case FtpClient.FtpEventType.FileDownloadInProgress:
                        InvokeEvent(ActionEventType.InProgress, e.EventInfo);
                        break;
                    case FtpClient.FtpEventType.FileDownloadCompleted:
                        InvokeEvent(ActionEventType.Completed, e.EventInfo);
                        break;
                    case FtpClient.FtpEventType.FileDownloadFailed:
                        InvokeEvent(ActionEventType.Failed, e.EventInfo);
                        break;
                }
            };

            ftpClient.DownloadFile(ftpPath, adjustedFileName, WidWorkFilesRootPath);
        }
        public void RunWidFileUnzip(string fileName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                var fileExt = Path.GetExtension(fileName);
                var adjustedFileName = fileName;
                if (fileExt.Equals(".021"))
                {
                    adjustedFileName = $"{fileName}.gz";
                    fileExt = ".gz";
                }

                InvokeEvent(ActionEventType.InProgress, 50);
                var localPath = WidWorkFilesRootPath;
                var fileFullName = Path.Combine(localPath, adjustedFileName);

                if (File.Exists(fileFullName))
                {
                    if (fileExt.Equals(".zip", StringComparison.OrdinalIgnoreCase))
                    {
                        ZipFile.ExtractToDirectory(fileFullName, localPath, true);
                    }
                    else
                    {
                        var targetFileName = Path.Combine(localPath, Path.GetFileNameWithoutExtension(fileFullName));
                        using FileStream compressedFileStream = File.Open(fileFullName, FileMode.Open);
                        using FileStream outputFileStream = File.Create(Path.Combine(localPath, targetFileName));
                        using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
                        decompressor.CopyTo(outputFileStream);
                    }
                }

                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidFileZipDelete(string fileName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                var fileExt = Path.GetExtension(fileName);
                var adjustedFileName = fileName;
                if (fileExt.Equals(".021"))
                {
                    adjustedFileName = $"{fileName}.gz";
                }
                var localPath = WidWorkFilesRootPath;
                var fileFullName = Path.Combine(localPath, adjustedFileName);
                InvokeEvent(ActionEventType.InProgress, 50);
                if (File.Exists(fileFullName))
                {
                    File.Delete(fileFullName);
                }
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidDumpFileApplyToDb(string entityName, string dbName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                var socWidConnString = ConnectionString.Replace("SocWidAdmin", dbName);
                using (var conn = new SqlConnection(socWidConnString))
                {
                    conn.Open();

                    using(var cmd = conn.CreateCommand())
                    {
                        var info = WidServiceLib.EntityInfo.GetEntityInfoEntry(entityName);
                        cmd.CommandText = $"truncate table {dbName}..{info.tableName}";
                        cmd.ExecuteNonQuery();
                    }

                    var loader = new WidServiceLib.EntityBulkLoader
                    {
                        FilePath = WidWorkFilesRootPath,
                        Conn = conn,
                    };
                    loader.LoadSingle(entityName, percentDone =>
                    {
                        InvokeEvent(ActionEventType.InProgress, percentDone);
                    });
                    InvokeEvent(ActionEventType.Completed, 0);
                }
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidCreateHistRecords(string entityName, string dbName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                var connectionString = ConnectionString.Replace("SocWidAdmin", "SocWid");
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandTimeout = 0;
                        var info = WidServiceLib.EntityInfo.GetEntityInfoEntry(entityName);
                        var cols = info.entityPropInfoList[0].propertyInfo.Name;
                        for (var i = 1; i < info.entityPropInfoList.Count; i++) // Skip Id and Wic
                        {
                            var propInfo = info.entityPropInfoList[i];
                            cols += $", {propInfo.propertyInfo.Name}";
                        }
                        cmd.CommandText = $"insert {info.tableNameHist}({cols}, ValidFrom, ValidTo) \r\n" +
                            $"select {cols}, @minDate, @maxDate\r\n" +
                            $"from {info.tableName}";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@minDate", WidServiceLib.Helpers.msSqlMinDate);
                        cmd.Parameters.AddWithValue("@maxDate", WidServiceLib.Helpers.msSqlMaxDate);

                        InvokeEvent(ActionEventType.InProgress, 50);
                        cmd.ExecuteNonQuery();

                        InvokeEvent(ActionEventType.Completed, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidUpdateFileApplyToDb(string fileName, int? firstLineIdx)
        {
            InvokeEvent(ActionEventType.Started, 0);

            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandTimeout = 0;
                        var fileExt = Path.GetExtension(fileName);
                        var adjustedFileName = fileName;
                        if (fileExt.Equals(".gz"))
                        {
                            adjustedFileName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName));
                        }
                        WidUpdatesLib.WidUpdatesService.ApplyUpdates(WidWorkFilesRootPath, adjustedFileName, cmd, firstLineIdx,
                            percentDone =>
                            {
                                InvokeEvent(ActionEventType.InProgress, percentDone);
                            },
                            lineIdx =>
                            {
                                InvokeEvent(ActionEventType.TransStarted, lineIdx);
                            }
                        );
                    }
                    InvokeEvent(ActionEventType.Completed, 0);
                }
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidFileDelete(string fileName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                var localPath = WidWorkFilesRootPath;
                InvokeEvent(ActionEventType.InProgress, 50);
                File.Delete(Path.Combine(localPath, fileName));
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidCalcDumpTs(string dbName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        DateTime dumpDt = new DateTime(1900, 1, 1);
                        var entityCount = WidServiceLib.EntityInfo.GetEntityInfoList().Count;
                        for (int entityIdx = 0; entityIdx < entityCount; entityIdx++)
                        {
                            var entityInfo = WidServiceLib.EntityInfo.entityInfoList[entityIdx];

                            cmd.CommandText = $"select max(UpdTs) from {dbName}..{entityInfo.tableName}";
                            var res = cmd.ExecuteScalar();
                            if (res != DBNull.Value)
                            {
                                var tableMaxDt = Convert.ToDateTime(res);
                                if (dumpDt < tableMaxDt)
                                {
                                    dumpDt = tableMaxDt;
                                }
                            }
                            InvokeEvent(ActionEventType.InProgress, 100 * (entityIdx + 1) / entityCount);
                        }
                        InvokeEvent(ActionEventType.Completed, dumpDt);
                    }
                }
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidDbRename(string sourceDbName, string targetDbName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandTimeout = 300;
                        cmd.CommandText = $@"
                            if db_id('{sourceDbName}') is not null
                            alter database {sourceDbName} set single_user with rollback immediate
                        ";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $@"
                            if db_id('{sourceDbName}') is not null
                            alter database {sourceDbName} modify name = {targetDbName}
                        ";
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = $@"
                            if db_id('{targetDbName}') is not null
                            alter database {targetDbName} set multi_user
                        ";
                        cmd.ExecuteNonQuery();
                        InvokeEvent(ActionEventType.Completed, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunWidFileApplyToSocDb(string fileName)
        {
            InvokeEvent(ActionEventType.Started, 0);

            try
            {
                var fileExt = Path.GetExtension(fileName);
                var adjustedFileName = fileName;
                if(fileExt.Equals(".gz"))
                {
                    adjustedFileName = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName));
                }
                WidUpdatesLib.WidUpdatesService.LoadUpdFile(WidWorkFilesRootPath, adjustedFileName, percentDone =>
                {
                    InvokeEvent(ActionEventType.InProgress, percentDone);
                });
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }

        public void RunIpiFileDownload(string ftpPath, string fileName)
        {
            var ftpClient = new FtpClient(IpiFtpUrl, IpiFtpLogin, IpiFtpPassword, true);
            ftpClient.FtpEvent += (sender, e) =>
            {
                switch (e.EventType)
                {
                    case FtpClient.FtpEventType.FileDownloadStarted:
                        InvokeEvent(ActionEventType.Started, e.EventInfo);
                        break;
                    case FtpClient.FtpEventType.FileDownloadInProgress:
                        InvokeEvent(ActionEventType.InProgress, e.EventInfo);
                        break;
                    case FtpClient.FtpEventType.FileDownloadCompleted:
                        InvokeEvent(ActionEventType.Completed, e.EventInfo);
                        break;
                    case FtpClient.FtpEventType.FileDownloadFailed:
                        InvokeEvent(ActionEventType.Failed, e.EventInfo);
                        break;
                }
            };
            ftpClient.DownloadFile(ftpPath, fileName, IpiWorkFilesRootPath);
        }
        public void RunIpiFileUnzip(string fileName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                var localPath = IpiWorkFilesRootPath;
                var fileFullName = Path.Combine(localPath, Path.GetFileName(fileName));
                InvokeEvent(ActionEventType.InProgress, 50);
                ZipFile.ExtractToDirectory(fileFullName, localPath, true);
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunIpiFileZipDelete(string fileName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                var localPath = IpiWorkFilesRootPath;
                var fileFullName = Path.Combine(localPath, Path.GetFileName(fileName));
                InvokeEvent(ActionEventType.InProgress, 50);
                if (File.Exists(fileFullName))
                {
                    File.Delete(fileFullName);
                }
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunIpiDumpFileApplyToDb(string fileFullName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                IpiUpdatesLib.IpiUpdateService.LoadDumpFile(fileFullName, percentDone =>
                {
                    InvokeEvent(ActionEventType.InProgress, percentDone);
                });
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunIpiUpdateFileApplyToDb(string fileFullName)
        {
            InvokeEvent(ActionEventType.Started, 0);

            try
            {
                IpiUpdatesLib.IpiUpdateService.ApplySingleFileUpdates(fileFullName, percentDone =>
                {
                    InvokeEvent(ActionEventType.InProgress, percentDone);
                });
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunIpiFileDelete(string fileFullName)
        {
            InvokeEvent(ActionEventType.Started, 0);
            try
            {
                InvokeEvent(ActionEventType.InProgress, 50);
                File.Delete(fileFullName);
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
        public void RunIpiFileApplyToSocDb(string fileFullName)
        {
            InvokeEvent(ActionEventType.Started, 0);

            try
            {
                IpiUpdatesLib.IpiUpdateService.LoadUpdFile(fileFullName, percentDone =>
                {
                    InvokeEvent(ActionEventType.InProgress, percentDone);
                });
                InvokeEvent(ActionEventType.Completed, 0);
            }
            catch (Exception ex)
            {
                InvokeEvent(ActionEventType.Failed, ex.Message);
            }
        }
    }
}
