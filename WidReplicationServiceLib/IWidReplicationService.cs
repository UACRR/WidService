using System;

namespace WidReplicationServiceLib
{
    public interface IWidReplicationService
    {
        public enum ActionEventType
        {
            Started = 0,
            InProgress = 1,
            Completed = 2,
            Failed = 3,
            TransStarted = 4,
        }

        public class ActionStatusChangedArgs
        {
            public ActionEventType EventType { get; set; }
            public object EventInfo { get; set; }
        }

        public event EventHandler<ActionStatusChangedArgs> ActionStatusChanged;

        public void RunWidFileDownload(string ftpPath, string fileName);
        public void RunWidFileUnzip(string fileName);
        public void RunWidFileZipDelete(string fileName);
        public void RunWidDumpFileApplyToDb(string fileName, string dbName);
        public void RunWidCreateHistRecords(string fileName, string dbName);
        public void RunWidUpdateFileApplyToDb(string fileName, int? startLineIdx);
        public void RunWidFileDelete(string fileName);
        public void RunWidCalcDumpTs(string dbName);
        public void RunWidDbRename(string sourceDbName, string targetDbName);
        public void RunWidFileApplyToSocDb(string tableName);

        public void RunIpiFileDownload(string ftpPath, string fileName);
        public void RunIpiFileUnzip(string fileName);
        public void RunIpiFileZipDelete(string fileName);
        public void RunIpiDumpFileApplyToDb(string fileName);
        public void RunIpiUpdateFileApplyToDb(string fileName);
        public void RunIpiFileDelete(string fileName);
        public void RunIpiFileApplyToSocDb(string tableName);
    }
}

