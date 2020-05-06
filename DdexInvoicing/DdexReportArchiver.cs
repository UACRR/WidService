using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public class DdexReportArchiver
    {
        public class TableInfo
        {
            public string tableName;
            public string parentTableName;
            public string pkColName;
            public string fkColName;
            public List<string> nestedTableNames;
        }

        const char sep = '\t';
        const char esc = '\\';
        const string quote = "\"";
        const string doubleQuote = "\"\"";

        public const string statNotStarted = "i";
        public const string statInProgress = "p";
        public const string statFailed = "f";
        public const string statCompleted = "c";

        public class StatusInfo
        {
            public string code;
            public string description;
            public int imageIndex;
        }

        public static Dictionary<string, StatusInfo> statDsc = new Dictionary<string, StatusInfo>()
        {
            { statNotStarted, new StatusInfo() {code = statNotStarted, description = "Не розпочата", imageIndex = -1 } },
            { statInProgress, new StatusInfo() {code = statInProgress, description = "Виконується", imageIndex = 3 } },
            { statFailed, new StatusInfo() {code = statFailed, description = "Завершена з помилками", imageIndex = 2 } },
            { statCompleted, new StatusInfo() {code = statCompleted, description = "Завершена", imageIndex = 0 } },
        };

        public const string operCheckArchiveFolder = "afld";
        public const string operCreateFolder = "flda";
        public const string operArchiveTable = "arch";
        public const string operDeleteArchived = "dlta";
        public const string operPackArchive = "zipa";
        public const string operDeleteFolder = "dltf";
        public const string operCreateRestoredFolder = "fldr";
        public const string operUnpackArchive = "uzip";
        public const string operRestoreFile = "rstf";
        public const string operDeleteRestoredFolder = "dltr";

        public delegate void Oper(DdexReportArchiver ddexReportArchiver, string data);
        public class OperInfo
        {
            public string code;
            public string description;
            public Oper operRunner;
        }

        public static Dictionary<string, OperInfo> operDsc = new Dictionary<string, OperInfo>()
        {
            { operCheckArchiveFolder, new OperInfo(){code = operCheckArchiveFolder, description = "Перевірка наявності папки з архівами" , operRunner = CheckArchiveFolder } },
            { operCreateFolder, new OperInfo(){code = operCreateFolder, description = "Створення робочої папки" , operRunner = CreateWorkingFolder } },
            { operArchiveTable, new OperInfo(){code = operArchiveTable, description = "Запис таблиці в файл" , operRunner = ArchiveTable } },
            { operDeleteArchived, new OperInfo(){code = operDeleteArchived, description = "Видалення записів, занесених до файлу" , operRunner = DeleteArchived } },
            { operPackArchive, new OperInfo(){code = operPackArchive, description = "Створення архівного файлу" , operRunner = PackArchive } },
            { operDeleteFolder, new OperInfo(){code = operDeleteFolder, description = "Видалення робочої папки" , operRunner = DeleteFolder } },
            { operCreateRestoredFolder, new OperInfo(){code = operCreateRestoredFolder, description = "Створення робочої папки" , operRunner = CreateWorkingFolder } },
            { operUnpackArchive, new OperInfo(){code = operUnpackArchive, description = "Запис файлів з архіву до робочої папки" , operRunner = UnpackArchive } },
            { operRestoreFile, new OperInfo(){code = operRestoreFile, description = "Запис інформації з файлу в базу даних" , operRunner = RestoreFile } },
            { operDeleteRestoredFolder, new OperInfo(){code = operDeleteRestoredFolder, description = "Видалення робочої папки" , operRunner = DeleteRestoredFolder } }
        };

        public static Dictionary<string, TableInfo> tableInfos = new Dictionary<string, TableInfo>()
        {
              //{"DdexReportingPeriod", new TableInfo() { tableName = "DdexReportingPeriod", pkColName = "Id", fkColName = "", parentTableName = "", nestedTableNames = new List<string>() } }
                 { "DdexReport", new TableInfo() { tableName = "DdexReport", pkColName = "Id", fkColName = "", parentTableName = "", nestedTableNames = new List<string>() } }
                    , { "DdexIdentificationBacklog", new TableInfo() { tableName = "DdexIdentificationBacklog", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "DdexFileErrors", new TableInfo() { tableName = "DdexFileErrors", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "DdexNetRevenueDistr", new TableInfo() { tableName = "DdexNetRevenueDistr", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    //, { "DdexRecordHead", new TableInfo() { tableName = "DdexRecordHead", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "DdexRecordSY_04_01", new TableInfo() { tableName = "DdexRecordSY_04_01", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "DdexRecordSY_05_02", new TableInfo() { tableName = "DdexRecordSY_05_02", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "DdexReportProcessingData", new TableInfo() { tableName = "DdexReportProcessingData", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "IdentBacklog", new TableInfo() { tableName = "IdentBacklog", pkColName = "ddexReportId", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "IdentMWAuthor", new TableInfo() { tableName = "IdentMWAuthor", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "IdentProgress", new TableInfo() { tableName = "IdentProgress", pkColName = "Id", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                        , { "IdentProgressByBlock", new TableInfo() { tableName = "IdentProgressByBlock", pkColName = "", fkColName = "IdentProgressId", parentTableName = "IdentProgress", nestedTableNames = new List<string>() } }
                    , { "IdentReportMwRecords", new TableInfo() { tableName = "IdentReportMwRecords", pkColName = "", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                    , { "CcidInvoice", new TableInfo() { tableName = "CcidInvoice", pkColName = "Id", fkColName = "ddexReportId", parentTableName = "DdexReport", nestedTableNames = new List<string>() } }
                        , { "CcidInFile", new TableInfo() { tableName = "CcidInFile", pkColName = "fileId", fkColName = "ccidInvoiceId", parentTableName = "CcidInvoice", nestedTableNames = new List<string>() } }
                            , { "CcidInHeader", new TableInfo() { tableName = "CcidInHeader", pkColName = "fileId", fkColName = "fileId", parentTableName = "CcidInFile", nestedTableNames = new List<string>() } }
                            , { "CcidInTrailer", new TableInfo() { tableName = "CcidInTrailer", pkColName = "fileId", fkColName = "fileId", parentTableName = "CcidInFile", nestedTableNames = new List<string>() } }
                            , { "CcidInDetail", new TableInfo() { tableName = "CcidInDetail", pkColName = "fileId", fkColName = "fileId", parentTableName = "CcidInFile", nestedTableNames = new List<string>() } }
                        , { "CcidClFile", new TableInfo() { tableName = "CcidClFile", pkColName = "fileId", fkColName = "ccidInvoiceId", parentTableName = "CcidInvoice", nestedTableNames = new List<string>() } }
                            , { "CcidClHeader", new TableInfo() { tableName = "CcidClHeader", pkColName = "fileId", fkColName = "fileId", parentTableName = "CcidInFile", nestedTableNames = new List<string>() } }
                            , { "CcidClTrailer", new TableInfo() { tableName = "CcidClTrailer", pkColName = "fileId", fkColName = "fileId", parentTableName = "CcidInFile", nestedTableNames = new List<string>() } }
                            , { "CcidClDetail", new TableInfo() { tableName = "CcidClDetail", pkColName = "fileId", fkColName = "fileId", parentTableName = "CcidInFile", nestedTableNames = new List<string>() } }
         };

        static DdexReportArchiver()
        {
            foreach (var ti in tableInfos.Values)
            {
                if (!string.IsNullOrEmpty(ti.parentTableName))
                {
                    var pti = tableInfos[ti.parentTableName];
                    pti.nestedTableNames.Add(ti.tableName);
                }
            }
        }

        public enum OperationMode
        {
            Archive, Restore, CleanRestored
        }

        private int ddexReportId; // = 14;
        private string archiveRootFolder; // = @"D:\IPS\DdexReportsArchive";
        private OperationMode operationMode;
        private string workingFolderName;

        public DataTable dtOperations;

        public DdexReportArchiver(int ddexReportId, string archiveRootFolder, OperationMode operationMode)
        {
            this.ddexReportId = ddexReportId;
            this.archiveRootFolder = archiveRootFolder;
            this.operationMode = operationMode;
            //workingFolderName = $"DdexReportArch_{ddexReportId}_{DateTime.Now.ToString("yyyy-MM-dd-hhmmss")}";

            CreateProtocol(ddexReportId, archiveRootFolder);

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);

                if (operationMode == OperationMode.CleanRestored)
                {
                    cmd.CommandText = $@"update DdexReportArchRestoreProtocol
                        set status = 'i'
                        where ddexReportId = @ddexReportId 
                            and oper = 'dlta'
                    ";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $@"update DdexReportArchRestoreProtocol
                        set status = 'i'
                        where ddexReportId = @ddexReportId 
                            and oper in ('fldr','uzip','rstf','dltr')
                    ";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = $@"select * 
                        from DdexReportArchRestoreProtocol 
                        where ddexReportId = @ddexReportId 
                            and oper = 'dlta'
                        order by ordinal";
                }
                else
                {
                    string not = operationMode == OperationMode.Archive ? "not" : "";
                    cmd.CommandText = $@"select * 
                        from DdexReportArchRestoreProtocol 
                        where ddexReportId = @ddexReportId 
                            and oper {not} in ('fldr','uzip','rstf','dltr')
                        order by ordinal";
                }
                dtOperations = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtOperations);
                if(operationMode == OperationMode.Archive)
                    workingFolderName = (string)dtOperations.Rows[1][3];
                else
                    workingFolderName = (string)dtOperations.Rows[0][3];
            });
        }

        static private void BuildSqlCmd(string curTableName, string rootTableName, int pk, SqlCommand cmd, bool isSelect)
        {
            int i = 1;
            cmd.CommandText = $"from {curTableName} t{i++}\r\n";
            TableInfo curTableInfo = tableInfos[curTableName];
            if (!curTableName.Equals(rootTableName, StringComparison.OrdinalIgnoreCase))
            {
                while (!(string.IsNullOrEmpty(curTableInfo.parentTableName)))
                {
                    TableInfo parentTableInfo = tableInfos[curTableInfo.parentTableName];
                    cmd.CommandText += $"    join {parentTableInfo.tableName} t{i} on t{i - 1}.{curTableInfo.fkColName} = t{i++}.{parentTableInfo.pkColName}\r\n";
                    curTableInfo = parentTableInfo;
                    if (parentTableInfo.tableName.Equals(rootTableName, StringComparison.OrdinalIgnoreCase))
                        break;
                }
            }
            cmd.CommandText = (isSelect ? $"select t1.*\r\n" : $"delete t1\r\n")
                         + cmd.CommandText + $"where t{i - 1}.{curTableInfo.pkColName} = @pk";
            cmd.Parameters.AddWithValue("@pk", pk);
        }

        /*
        private void WriteArchivePlan()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter($@"{ARCHIVE_FOLDER}\ArchivePlan.bcc"))
            {
                file.Write($"tableName{sep}parentTableName{sep}pkColName{sep}fkColName");
                foreach (var tableInfo in tableInfos.Values)
                {
                    file.Write($"\r\n{tableInfo.tableName}{sep}{tableInfo.parentTableName}{sep}{tableInfo.pkColName}{sep}{tableInfo.fkColName}");
                }
            }
        }
        */

        static private string[] SplitSpecial(string text)
        {
            int startPos = 0;
            int quoteCnt = 0;
            List<string> fields = new List<string>();
            int curPos;
            for (curPos = 0; curPos < text.Length; curPos++)
            {
                if (text[curPos] == quote[0])
                    quoteCnt++;
                else if (text[curPos] == sep && quoteCnt % 2 == 0)
                {
                    fields.Add(text.Substring(startPos, curPos - startPos));
                    startPos = curPos + 1;
                }
            }
            fields.Add(text.Substring(startPos, curPos - startPos));
            return fields.ToArray();
        }

        private void ArchiveTable(string tableName, string rootTableName, int rootPk)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                // Needed to get information about table columns
                BulkUploadToSql bulkUploader = new BulkUploadToSql();
                bulkUploader.TableName = tableName;
                bulkUploader.conn = cmd.Connection;
                //bulkUploader.CommitBatchSize = 1;
                bulkUploader.Init();

                BuildSqlCmd(tableName, rootTableName, rootPk, cmd, true);
                using (SqlDataReader r = cmd.ExecuteReader())
                using (System.IO.StreamWriter file = new System.IO.StreamWriter($@"{workingFolderName}\{tableName}.bcc"))
                {
                    // write header record
                    for (int i = 0; i < r.FieldCount; i++)
                    {
                        DataRow colInfo = bulkUploader.dtColInfo.Rows[i];
                        file.Write(colInfo[0].ToString());
                        if (i < r.FieldCount - 1)
                            file.Write(sep);
                    }
                    file.Write("\r\n");

                    while (r.Read())
                    {
                        for (int i = 0; i < r.FieldCount; i++)
                        {
                            DataRow colInfo = bulkUploader.dtColInfo.Rows[i];
                            string dataType = (string)colInfo[1];
                            string fieldValue;
                            if (r.IsDBNull(i))
                            {
                                fieldValue = "null";
                            }
                            else if (dataType.Equals("int", StringComparison.OrdinalIgnoreCase))
                            {
                                fieldValue = r.GetInt32(i).ToString();
                            }
                            else if (dataType.Equals("decimal", StringComparison.OrdinalIgnoreCase) || dataType.Equals("numeric", StringComparison.OrdinalIgnoreCase))
                            {
                                fieldValue = Formatter.ToString(r.GetDecimal(i));
                            }
                            else if (dataType.Equals("date", StringComparison.OrdinalIgnoreCase))
                            {
                                fieldValue = r.GetDateTime(i).ToString("yyyyMMdd");
                            }
                            else if (dataType.Equals("datetime", StringComparison.OrdinalIgnoreCase))
                            {
                                fieldValue = r.GetDateTime(i).ToString("yyyyMMddhhmmss");
                            }
                            else
                                fieldValue = r.GetValue(i).ToString().Replace(quote, doubleQuote);

                            file.Write(quote + fieldValue + quote);
                            if (i < r.FieldCount - 1)
                                file.Write(sep);
                        }
                        file.Write("\r\n");
                    }
                }
            }, true);
        }

        private void ClearTable(string tableName, string rootTableName, int rootPk)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                BuildSqlCmd(tableName, rootTableName, rootPk, cmd, false);
                cmd.ExecuteNonQuery();
            }, true);
        }

        private void RestoreTable(string tableName)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                BulkUploadToSql bulkUploader = new BulkUploadToSql();
                bulkUploader.TableName = tableName;
                bulkUploader.conn = cmd.Connection;
                //bulkUploader.CommitBatchSize = 1;
                bulkUploader.Init();

                //cmd.CommandText = $"set identity_insert {tableName} on";
                //cmd.ExecuteNonQuery();

                using (System.IO.StreamReader file = new System.IO.StreamReader($@"{workingFolderName}\{tableName}.bcc"))
                {
                    string line;
                    file.ReadLine();
                    while ((line = file.ReadLine()) != null)
                    {
                        var data = new List<object>();
                        string[] fields = line.Split(sep);
                        if (fields.Length > bulkUploader.dtColInfo.Rows.Count)
                            fields = SplitSpecial(line);
                        for (int i = 0; i < fields.Length; i++)
                        {
                            DataRow colInfo = bulkUploader.dtColInfo.Rows[i];
                            string dataType = (string)colInfo[1];
                            string fieldValue = fields[i].Substring(1, fields[i].Length - 2);
                            fieldValue.Replace(doubleQuote, quote);
                            if (fieldValue.Equals("'null'", StringComparison.OrdinalIgnoreCase))
                            {
                                data.Add(fieldValue.Substring(1, 4));
                            }
                            else if (fieldValue.Equals("null", StringComparison.OrdinalIgnoreCase))
                            {
                                data.Add(DBNull.Value);
                            }
                            else if (dataType.Equals("int", StringComparison.OrdinalIgnoreCase))
                            {
                                data.Add(int.Parse(fieldValue));
                            }
                            else if (dataType.Equals("decimal", StringComparison.OrdinalIgnoreCase) || dataType.Equals("numeric", StringComparison.OrdinalIgnoreCase))
                            {
                                if (fieldValue == "")
                                    continue;
                                data.Add(Formatter.ToDecimal(fieldValue));
                            }
                            else if (dataType.Equals("date", StringComparison.OrdinalIgnoreCase))
                            {
                                data.Add(new DateTime(int.Parse(fieldValue.Substring(0, 4)), int.Parse(fieldValue.Substring(4, 2)), int.Parse(fieldValue.Substring(6, 2))));
                            }
                            else if (dataType.Equals("datetime", StringComparison.OrdinalIgnoreCase))
                            {
                                data.Add(new DateTime(int.Parse(fieldValue.Substring(0, 4)), int.Parse(fieldValue.Substring(4, 2)), int.Parse(fieldValue.Substring(6, 2))
                                    , int.Parse(fieldValue.Substring(8, 2)), int.Parse(fieldValue.Substring(10, 2)), int.Parse(fieldValue.Substring(12, 2))));
                            }
                            else
                                data.Add(fieldValue);
                        }
                        bulkUploader.AddData(data);
                    }
                    bulkUploader.Flush();
                    //cmd.CommandText = $"set identity_insert {tableName} off";
                    //cmd.ExecuteNonQuery();
                }
            }, true);
        }

        private void ArchiveAll(string tableName, string rootTableName, int rootPk)
        {
            ArchiveTable(tableName, rootTableName, rootPk);
            TableInfo tableInfo = tableInfos[tableName];
            foreach (var nestedTableName in tableInfo.nestedTableNames)
            {
                TableInfo nestedTableInfo = tableInfos[nestedTableName];
                ArchiveAll(nestedTableInfo.tableName, rootTableName, rootPk);
            }
        }

        private void ClearAll(string tableName, string rootTableName, int rootPk, bool childrenOnly)
        {
            TableInfo tableInfo = tableInfos[tableName];
            foreach (var nestedTableName in tableInfo.nestedTableNames)
            {
                TableInfo nestedTableInfo = tableInfos[nestedTableName];
                ClearAll(nestedTableInfo.tableName, rootTableName, rootPk, false);
            }
            if (!childrenOnly)
                ClearTable(tableName, rootTableName, rootPk);
        }

        private void RestoreAll(string tableName, bool childrenOnly)
        {
            if (!childrenOnly)
                RestoreTable(tableName);
            TableInfo tableInfo = tableInfos[tableName];
            for (int i = tableInfo.nestedTableNames.Count - 1; i >= 0; i--)
            {
                var nestedTableName = tableInfo.nestedTableNames[i];
                RestoreAll(nestedTableName, false);
            }
        }

        private void AddProtocolEntry(BulkUploadToSql bulkUploader, int ddexReportId, int ordinal, string oper, string entity, string status)
        {
            List<object> data = new List<object>();
            data.Add(ddexReportId);
            data.Add(ordinal);
            data.Add(oper);
            data.Add(entity);
            data.Add(status);
            bulkUploader.AddData(data);
        }

        private void CreateProtocol(int ddexReportId, string archiveRootFolder)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.CommandText = "select status from ddexReport where id = @ddexReportId";
                int status = (int)cmd.ExecuteScalar();
                if (status != Meta.DdexReportStatus.INVOICING_COMPLETED)
                    return;

                cmd.CommandText = "delete from DdexReportArchRestoreProtocol where ddexReportId = @ddexReportId";
                cmd.ExecuteNonQuery();

                BulkUploadToSql bulkUploader = new BulkUploadToSql();
                bulkUploader.TableName = "DdexReportArchRestoreProtocol";
                bulkUploader.conn = cmd.Connection;

                // Archive
                int ordinal = 1;
                AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operCheckArchiveFolder, archiveRootFolder, statNotStarted);
                string workingFolderName = $"{archiveRootFolder}\\DdexReportArch_{ddexReportId}_{DateTime.Now.ToString("yyyy-MM-dd-hhmmss")}";
                AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operCreateFolder, workingFolderName, statNotStarted);
                foreach (var tableInfo in tableInfos.Values)
                {
                    AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operArchiveTable, tableInfo.tableName, statNotStarted);
                }
                foreach (var tableInfo in tableInfos.Values.Reverse())
                {
                    if (!tableInfo.tableName.Equals("DdexReport", StringComparison.OrdinalIgnoreCase))
                        AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operDeleteArchived, tableInfo.tableName, statNotStarted);
                }
                AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operPackArchive, $"{workingFolderName}.zip", statNotStarted);
                AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operDeleteFolder, $"{workingFolderName}", statNotStarted);

                // Restore
                AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operCreateRestoredFolder, workingFolderName, statNotStarted);
                AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operUnpackArchive, $"{workingFolderName}.zip", statNotStarted);
                foreach (var tableInfo in tableInfos.Values)
                {
                    if (!tableInfo.tableName.Equals("DdexReport", StringComparison.OrdinalIgnoreCase))
                        AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operRestoreFile, tableInfo.tableName, statNotStarted);
                }
                AddProtocolEntry(bulkUploader, ddexReportId, ordinal++, operDeleteRestoredFolder, $"{workingFolderName}", statNotStarted);
                bulkUploader.Flush();
                cmd.CommandText = "update DdexReport set status = 16 where id = @ddexReportId";
                cmd.ExecuteNonQuery();
            }, true);
        }

        static private void CheckArchiveFolder(DdexReportArchiver ddexReportArchiver, string data)
        {
            if (!Directory.Exists(ddexReportArchiver.archiveRootFolder))
                throw new Exception($"Вказаної папки архівів не існує: {ddexReportArchiver.archiveRootFolder}");
        }
        static private void CreateWorkingFolder(DdexReportArchiver ddexReportArchiver, string data)
        {
            Directory.CreateDirectory(ddexReportArchiver.workingFolderName);
        }
        static private void ArchiveTable(DdexReportArchiver ddexReportArchiver, string tableName)
        {
            ddexReportArchiver.ArchiveTable(tableName, "DdexReport", ddexReportArchiver.ddexReportId);
        }
        static private void DeleteArchived(DdexReportArchiver ddexReportArchiver, string tableName)
        {
            ddexReportArchiver.ClearTable(tableName, "DdexReport", ddexReportArchiver.ddexReportId);
        }
        static private void PackArchive(DdexReportArchiver ddexReportArchiver, string data)
        {
            File.Delete(data);
            System.IO.Compression.ZipFile.CreateFromDirectory(ddexReportArchiver.workingFolderName, data);
        }

        static private void DeleteFolder(DdexReportArchiver ddexReportArchiver, string data)
        {
            Directory.Delete(ddexReportArchiver.workingFolderName, true);
        }

        static private void UnpackArchive(DdexReportArchiver ddexReportArchiver, string data)
        {
            Directory.CreateDirectory(ddexReportArchiver.workingFolderName);
            System.IO.Compression.ZipFile.ExtractToDirectory(data, ddexReportArchiver.workingFolderName);
        }

        static private void RestoreFile(DdexReportArchiver ddexReportArchiver, string tableName)
        {
            ddexReportArchiver.ClearTable(tableName, "DdexReport", ddexReportArchiver.ddexReportId);
            ddexReportArchiver.RestoreTable(tableName);
        }

        static private void DeleteRestoredFolder(DdexReportArchiver ddexReportArchiver, string data)
        {
            Directory.Delete(ddexReportArchiver.workingFolderName, true);
        }

        public void RunOperations(BackgroundWorker bw)
        {
            int pendingOperIndex = 0;
            foreach (DataRow row in dtOperations.Rows)
            {
                string status = (string)row[4];
                if (!status.Equals(statCompleted))
                    break;
                pendingOperIndex++;
            }

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@status", operationMode == OperationMode.Archive ? Meta.DdexReportStatus.ARCHIVING :
                        operationMode == OperationMode.Restore ? Meta.DdexReportStatus.RESTORING : Meta.DdexReportStatus.CLEANING);
                cmd.CommandText = "update DdexReport set status = @status where id = @ddexReportId";
                cmd.ExecuteNonQuery();
            }, true);

            for (; pendingOperIndex < dtOperations.Rows.Count; pendingOperIndex++)
            {
                DataRow row = dtOperations.Rows[pendingOperIndex];
                string oper = (string)row[2];
                OperInfo operInfo = operDsc[oper];

                row[4] = statInProgress;
                UpdateOperState((int)row[1], statInProgress);
                bw.ReportProgress(pendingOperIndex, statInProgress);
                try
                {
                    operInfo.operRunner(this, (string)row[3]);
                    row[4] = statCompleted;
                    UpdateOperState((int)row[1], statCompleted);
                    bw.ReportProgress(pendingOperIndex, statCompleted);
                }
                catch (Exception ex)
                {
                    row[4] = statFailed;
                    UpdateOperState((int)row[1], statFailed);
                    MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bw.ReportProgress(pendingOperIndex, statFailed);
                    return;
                }
            }
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@status", operationMode == OperationMode.Archive ? Meta.DdexReportStatus.ARCHIVED :
                        operationMode == OperationMode.Restore ? Meta.DdexReportStatus.RESTORED : Meta.DdexReportStatus.ARCHIVED);
                cmd.CommandText = "update DdexReport set status = @status where id = @ddexReportId";
                cmd.ExecuteNonQuery();
            }, true);
        }

        private void UpdateOperState(int ordinal, string state)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "update DdexReportArchRestoreProtocol set status = @status where ddexReportId = @ddexReportId and ordinal = @ordinal";
                cmd.Parameters.AddWithValue("@ddexReportId", ddexReportId);
                cmd.Parameters.AddWithValue("@ordinal", ordinal);
                cmd.Parameters.AddWithValue("@status", state);
                cmd.ExecuteNonQuery();
            }, true);
        }
    }

}

