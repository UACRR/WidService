using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidAdminLib;
using WidReplicationServiceLib;

namespace WidAdminLib
{
    public class WidReplicationServiceDummy : IWidReplicationService
    {
        public event EventHandler<IWidReplicationService.ActionStatusChangedArgs> ActionStatusChanged;

        // => Not used here, for compatibility with actual service
        public string FtpUrl;
        public string FtpLogin;
        public string FtpPassword;
        public string FtpWidDumpPath;
        public string FtpWidUpdatesPath;
        public string LocalFilesRootPath;
        public string LocalWidDbConnectionString;
        // <=

        private static DateTime _widDumpTs;
        int _delay = 1;

        private void EmulateTaskRun()
        {
            InvokeEvent(IWidReplicationService.ActionEventType.Started, 0);
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(_delay).Wait();
                InvokeEvent(IWidReplicationService.ActionEventType.InProgress, i / 10);
            }
            InvokeEvent(IWidReplicationService.ActionEventType.Completed, 0);
        }
        private void InvokeEvent(IWidReplicationService.ActionEventType eventType, object eventInfo)
        {
            ActionStatusChanged?.Invoke(this,
                new IWidReplicationService.ActionStatusChangedArgs
                {
                    EventType = eventType,
                    EventInfo = eventInfo,
                });
        }

        public void RunWidFileDownload(string ftpPath, string fileName) => EmulateTaskRun();
        public void RunWidFileUnzip(string fileName) => EmulateTaskRun();
        public void RunWidFileZipDelete(string fileName) => EmulateTaskRun();
        public void RunWidDumpFileApplyToDb(string fileName, string dbName) => EmulateTaskRun();
        public void RunWidCreateHistRecords(string fileName, string dbName) => EmulateTaskRun();
        public void RunWidUpdateFileApplyToDb(string fileName, int? startLineIdx) => EmulateTaskRun();
        public void RunWidFileDelete(string fileName)
        {
            InvokeEvent(IWidReplicationService.ActionEventType.Started, 0);
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(_delay).Wait();
                InvokeEvent(IWidReplicationService.ActionEventType.InProgress, i / 10);
            }
            // Emulate situaton when new wid dump arrived
            if (fileName.StartsWith("WID"))
            {
                var fileDt = new DateTime(int.Parse(fileName.Substring(3, 4)), int.Parse(fileName.Substring(7, 2)), int.Parse(fileName.Substring(9, 2)));
                if(fileDt > _widDumpTs.AddDays(1))
                {
                    var dbContext = new WidAdminDbContext();
                    var period = dbContext.WidUpdatePeriods.Single(x => x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);
                    period.WidDumpFilesTotalSize = period.NewWidDumpFilesTotalSize - 1;
                    dbContext.SaveChanges();
                }
            }
            InvokeEvent(IWidReplicationService.ActionEventType.Completed, 0);
        }
        public void RunWidCalcDumpTs(string dbName)
        {
            InvokeEvent(IWidReplicationService.ActionEventType.Started, 0);
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(_delay).Wait();
                InvokeEvent(IWidReplicationService.ActionEventType.InProgress, i / 10);
            }
            var dbContext = new WidAdminDbContext();
            var period = dbContext.WidUpdatePeriods.SingleOrDefault(x => x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);
            if (period == null || period.WidDumpTs == null)
            {
                _widDumpTs = DateTime.Now.AddDays(-4);
            }
            else
            {
                _widDumpTs = ((DateTime)period.WidDumpTs).AddDays(2);
            }
            InvokeEvent(IWidReplicationService.ActionEventType.Completed, _widDumpTs);
        }
        public void RunWidDbRename(string sourceDbName, string targetDbName) => EmulateTaskRun();
        public void RunWidFileApplyToSocDb(string tableName) => EmulateTaskRun();

        public void RunIpiFileDownload(string ftpPath, string fileName) => EmulateTaskRun();
        public void RunIpiFileUnzip(string fileName) => EmulateTaskRun();
        public void RunIpiFileZipDelete(string fileName) => EmulateTaskRun();
        public void RunIpiDumpFileApplyToDb(string fileName) => EmulateTaskRun();
        public void RunIpiUpdateFileApplyToDb(string fileName) => EmulateTaskRun();
        public void RunIpiFileDelete(string fileName)
        {
            InvokeEvent(IWidReplicationService.ActionEventType.Started, 0);
            for (int i = 0; i < 1000; i += 100)
            {
                Task.Delay(_delay).Wait();
                InvokeEvent(IWidReplicationService.ActionEventType.InProgress, i / 10);
            }
            // Emulate situaton when new wid dump arrived
            if (fileName.StartsWith("WID"))
            {
                var fileDt = new DateTime(int.Parse(fileName.Substring(3, 4)), int.Parse(fileName.Substring(7, 2)), int.Parse(fileName.Substring(9, 2)));
                if (fileDt > _widDumpTs.AddDays(1))
                {
                    var dbContext = new WidAdminDbContext();
                    var period = dbContext.WidUpdatePeriods.Single(x => x.WidTaskStatusId != (int)WidTaskStatusCodeEnum.Completed);
                    period.WidDumpFilesTotalSize = period.NewWidDumpFilesTotalSize - 1;
                    dbContext.SaveChanges();
                }
            }
            InvokeEvent(IWidReplicationService.ActionEventType.Completed, 0);
        }
        public void RunIpiFileApplyToSocDb(string tableName) => EmulateTaskRun();


    }
}
