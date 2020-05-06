using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportActionFillSubscriptionData : DdexReportActionBase
    {
        private SqlConnection conn;
        private int lastProcessedBlockId;
        private bool overwrite;

        private int recordIndexSy_04_01 = 1;
        private int recordIndexSy_05_02 = 1;

        Dictionary<string, BulkUploadToSql> bulkUploaders = new Dictionary<string, BulkUploadToSql>();
        HashSet<string> recordsToCorrect;
        
        public DdexReportActionFillSubscriptionData(bool overwrite)
        {
            this.overwrite = overwrite;
        }

        private void RegisterBulkUploader(string tableName)
        {
           var bulkUploader = new BulkUploadToSql
                {
                    TableName = tableName,
                    conn = conn
                };
            bulkUploaders.Add(tableName, bulkUploader);
        }

        public override string GetDescription() { return "Завантаження даних для підписки із звіту"; }

        public override void Init(DdexReport report)
        {
            this.report = report;
            try
            {
                conn = new SqlConnection(report.ConnectString);
                conn.Open();
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }

            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));
                Logger.WriteLine("Видалення раніше створенной інформації");
                SqlHelpers.DeleteRecords(conn, "delete from DdexRecordSY_04_01 where DdexReportId = @p0", report.ddexReportId);
                SqlHelpers.DeleteRecords(conn, "delete from DdexRecordSY_05_02 where DdexReportId = @p0", report.ddexReportId);
                Logger.WriteLine($"Записи видалено за таблиці DdexRecordHead");
            }

            RegisterBulkUploader("DdexRecordSy_04_01");
            RegisterBulkUploader("DdexRecordSy_05_02");
         }

        public override int GetLastProcessedBlockId()
        {
            return lastProcessedBlockId;
        }

        private void InsertRecord(DdexRecordBase record, string tableName, int recordIndex)
        {
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders[tableName];
                var data = new List<object>();
                data.Add(report.ddexReportId);
                data.Add(recordIndex);
                for (int i = 1; i < record.fields.Length; i++)
                {
                    try
                    {
                        data.Add(record.ConvertField(i));
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLine($"Помилки в таблиці {tableName}, {ex.Message}");
                        Logger.WriteLine($"   Помилковий формат рядка");
                        throw;
                    }
                }
                bulkUploader.AddData(data);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Помилки в таблиці {tableName}, {ex.Message}");
                Logger.WriteLine($"   Помилковий формат рядка");
                record.Dump(record.fields);
                throw;
            }
        }

        public override void ProcessFoot(FOOTRecord record)
        {
            foreach (var bulkUploader in bulkUploaders.Values)
                bulkUploader.Flush();
        }

        public override void ProcessSY_04_01(SYRecord_04_01 record)
        {
            InsertRecord(record, "DdexRecordSy_04_01", recordIndexSy_04_01++);
        }
        public override void ProcessSY_05_02(SYRecord_05_02 record)
        {
            InsertRecord(record, "DdexRecordSy_05_02", recordIndexSy_05_02++);
        }

     }
}
