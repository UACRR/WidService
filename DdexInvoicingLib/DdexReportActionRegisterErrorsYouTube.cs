using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportActionRegisterErrorsYouTube : DdexReportActionBase
    {
        private SqlConnection conn;
        BulkUploadToSql bulkUploader;

        public DdexReportActionRegisterErrorsYouTube()
        {
        }

        public override string GetDescription() { return "Реєстрація помилок у вхіному файлі для подальшого виправлення"; }

        public override bool DoFiltering() { return false; }

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
                cmd.CommandText = @"delete from DdexFileErrors where DdexReportId = @DdexReportId";
                cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }

            bulkUploader = new BulkUploadToSql
            {
                TableName = "DdexFileErrors",
                conn = conn,
                options = SqlBulkCopyOptions.TableLock
                        | SqlBulkCopyOptions.FireTriggers
                        | SqlBulkCopyOptions.UseInternalTransaction
            };
         }

        private void ValidateRecord(DdexRecordBase record, string tableName, int recordIndex)
        {
            try
            {
                int expectedFieldsCount = record.GetFieldCount();
                int actualFieldsCount = record.fields.Length;
                if (expectedFieldsCount != actualFieldsCount)
                {
                    string errorText = $"Error in record {record.fields[0]} - actual fields count ({actualFieldsCount}) is not like expected ({expectedFieldsCount})";
                    string recordText = "";
                    string sep = "";
                    foreach(var field in record.fields)
                    {
                        recordText += sep + field;
                        sep = "{TAB}";
                    }
                    Logger.WriteLine(errorText);
                    Logger.WriteLine(recordText);
                    var data = new List<object>();
                    data.Add(DBNull.Value);
                    data.Add(report.ddexReportId);
                    data.Add(record.IsBlockRecord() ? record.fields[1] : "");
                    data.Add(record.fields[0]);
                    data.Add(recordIndex);
                    data.Add(errorText);
                    data.Add(recordText);
                    bulkUploader.AddData(data);
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Помилки в таблиці {tableName}, {ex.Message}");
                Logger.WriteLine($"   Помилковий формат рядка");
                record.Dump(record.fields);
                throw;
            }
        }

        public override void ProcessHead(HEADRecordGoogle record)
        {
            report.RecordsToCorrect.Clear();
            ValidateRecord(record, "DdexRecordHead", 0);
        }

        public override void ProcessFoot(FOOTRecord record)
        {
            ValidateRecord(record, "DdexRecordFoot", 0);
            bulkUploader.Flush();
            if(report.IsLastFile())
                conn.Close();
        }

        public override void ProcessSY_02_02(SYRecord_02_02 record)
        {
            ValidateRecord(record, "DdexRecordSy", 0);
        }

        public override void ProcessBlock(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockYouTube;
            try
            {
                int ruRecordIndex = 0;
                int suRecordIndex = 0;
                int liRecordIndex = 0;
                int mwRecordIndex = 1;
                ValidateRecord(block.asRecord, "DdexRecordAs", 0);
                ValidateRecord(block.canonicalMwRecord, "DdexRecordMw", 0);
                foreach(var ruRecord in block.ruRecords)
                {
                    ValidateRecord(ruRecord, "DdexRecordRu", ruRecordIndex++);
                }
                foreach (var suRecord in block.suRecords)
                {
                    ValidateRecord(suRecord, "DdexRecordSu", suRecordIndex++);
                    foreach (var liRecord in suRecord.liRecords)
                    {
                        ValidateRecord(liRecord, "DdexRecordLi", liRecordIndex++);
                        ValidateRecord(liRecord.mwRecord, "DdexRecordMw", mwRecordIndex++);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
