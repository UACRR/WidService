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
    public class DdexReportActionFillRawData : DdexReportActionBase
    {
        private SqlConnection conn;
        private int lastProcessedBlockId;
        private bool overwrite;

        Dictionary<string, BulkUploadToSql> bulkUploaders = new Dictionary<string, BulkUploadToSql>();
        HashSet<string> recordsToCorrect;
        
        public DdexReportActionFillRawData(bool overwrite)
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

        public override string GetDescription() { return "Завантаження інформації із звіту в базу даних" ; }

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
                overwrite = false;
                cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));
                if (!overwrite)
                {
                    Logger.WriteLine("Знаходження останнього обробленого блоку");
                    cmd.CommandText = @"declare @lastBlockIdAs int;
                        select @lastBlockIdAs = max(cast(BlockId as int)) from DdexRecordAs where DdexReportId = @DdexReportId;
                        
                        declare @lastBlockIdMw int;
                        select @lastBlockIdMw = max(cast(BlockId as int)) from DdexRecordMw where DdexReportId = @DdexReportId;

                        declare @lastBlockIdLi int;
                        select @lastBlockIdLi = max(cast(BlockId as int)) from DdexRecordLi where DdexReportId = @DdexReportId;

                        declare @lastBlockIdSu int;
                        select @lastBlockIdSu = max(cast(BlockId as int)) from DdexRecordSu where DdexReportId = @DdexReportId;

                        declare @lastBlockIdRu int;
                        select @lastBlockIdRu = max(cast(BlockId as int)) from DdexRecordRu where DdexReportId = @DdexReportId;

                        declare @lastBlockIdMwCanonical int;
                        select @lastBlockIdMwCanonical = max(cast(BlockId as int)) from DdexRecordMwCanonical where DdexReportId = @DdexReportId;
                        
                        declare @lastBlockId int;
                        ; with tbl as (
	                        select @lastBlockIdAs as BlockId
                            union select @lastBlockIdMw as BlockId
                            union select @lastBlockIdLi as BlockId
                            union select @lastBlockIdSu as BlockId
                            union select @lastBlockIdRu as BlockId
                            union select @lastBlockIdMwCanonical as BlockId
                        )
                        select @lastBlockId = isnull(min(BlockId), 0) from tbl

                        delete from DdexRecordMw where DdexReportId = @DdexReportId and cast(BlockId as int) >= @lastBlockId; 
                        delete from DdexRecordLi where DdexReportId = @DdexReportId and cast(BlockId as int) > = @lastBlockId; 
                        delete from DdexRecordSu where DdexReportId = @DdexReportId and cast(BlockId as int) > = @lastBlockId; 
                        delete from DdexRecordRu where DdexReportId = @DdexReportId and cast(BlockId as int) > = @lastBlockId; 
                        delete from DdexRecordMwCanonical where DdexReportId = @DdexReportId and cast(BlockId as int) > = @lastBlockId; 
                        delete from DdexRecordAs where DdexReportId = @DdexReportId and cast(BlockId as int) > = @lastBlockId;
                        select @lastBlockId";
                    cmd.Connection = conn;
                    try
                    {
                        object lastProcessed = cmd.ExecuteScalar();
                        lastProcessedBlockId = lastProcessed == DBNull.Value ? 0 : int.Parse(lastProcessed.ToString());
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLine(ex.Message);
                        throw;
                    }
                }
                else
                {
                    Logger.WriteLine("Видалення раніше створенной інформації");
                    SqlHelpers.DeleteByPortions(conn, "DdexRecordMw", "DdexReportId = @p0", report.ddexReportId);
                    SqlHelpers.DeleteByPortions(conn, "DdexRecordLi", "DdexReportId = @p0", report.ddexReportId);
                    SqlHelpers.DeleteByPortions(conn, "DdexRecordSu", "DdexReportId = @p0", report.ddexReportId);
                    SqlHelpers.DeleteByPortions(conn, "DdexRecordRu", "DdexReportId = @p0", report.ddexReportId);
                    SqlHelpers.DeleteByPortions(conn, "DdexRecordMwCanonical", "DdexReportId = @p0", report.ddexReportId);
                    SqlHelpers.DeleteByPortions(conn, "DdexRecordAs", "DdexReportId = @p0", report.ddexReportId);
                    SqlHelpers.DeleteRecords(conn, "delete from DdexRecordSy_02_02 where DdexReportId = @p0", report.ddexReportId);
                    Logger.WriteLine($"Один запис видалено за таблиці DdexRecordSy_02_02");
                    SqlHelpers.DeleteRecords(conn, "delete from DdexRecordFoot where DdexReportId = @p0", report.ddexReportId);
                    Logger.WriteLine($"Один запис видалено за таблиці DdexRecordFoot");
                    SqlHelpers.DeleteRecords(conn, "delete from DdexRecordHead where DdexReportId = @p0", report.ddexReportId);
                    Logger.WriteLine($"Один запис видалено за таблиці DdexRecordHead");

                }

                recordsToCorrect = new HashSet<string>();
                cmd.CommandText = @"select BlockId, RecordType, RecordIndex from DdexFileErrors where DdexReportId = @DdexReportId";
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            recordsToCorrect.Add($"{reader.GetString(0)}-{reader.GetString(1)}-{reader.GetInt32(2)}");
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }

            using (SqlCommand cmd = conn.CreateCommand())
            {
                Logger.WriteLine("Тимчасове зняття зовнішніх ключів");
                cmd.CommandText = @"alter table [DdexRecordMwCanonical] drop constraint if exists FK_MW01_01_Master_REFERENCE_AS01_01;
                    alter table [DdexRecordRu] drop constraint if exists FK_RU01_01_Ex_REFERENCE_AS01_01;
                    alter table [DdexRecordSu] drop constraint if exists FK_SU03_02_Ex_REFERENCE_AS01_01;
                    alter table [DdexRecordLi] drop constraint if exists FK_LI01_02_REFERENCE_SU03_02;
                    alter table [DdexRecordMw] drop constraint if exists FK_LI01_02_REFERENCE_LI;";
                cmd.Connection = conn;
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

            RegisterBulkUploader("DdexRecordHead");
            RegisterBulkUploader("DdexRecordFoot");
            RegisterBulkUploader("DdexRecordSy_02_02");
            RegisterBulkUploader("DdexRecordAs");
            RegisterBulkUploader("DdexRecordMwCanonical");
            RegisterBulkUploader("DdexRecordMw");
            RegisterBulkUploader("DdexRecordRu");
            RegisterBulkUploader("DdexRecordSu");
            RegisterBulkUploader("DdexRecordLi");
         }

        public override int GetLastProcessedBlockId()
        {
            return lastProcessedBlockId;
        }

        private void InsertRecord(DdexRecordBase record, string tableName, int recordIndex, int ownerRecordIndex)
        {
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders[tableName];
                var data = new List<object>();
                data.Add(report.ddexReportId);
                if(recordIndex != -1)
                    data.Add(recordIndex);
                if (ownerRecordIndex != -1)
                    data.Add(ownerRecordIndex);
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

        public override void ProcessHead(HEADRecordGoogle record)
        {
            int recordCount = (int)SqlHelpers.GetSingleValue(conn, "select isnull(count(*), 0) from DdexRecordHead where DdexReportId = @p0", report.ddexReportId);
            if (recordCount == 0)
                InsertRecord(record, "DdexRecordHead", -1, -1);
        }

        public override void ProcessFoot(FOOTRecord record)
        {
            int recordCount = (int)SqlHelpers.GetSingleValue(conn, "select isnull(count(*), 0) from DdexRecordFoot where DdexReportId = @p0", report.ddexReportId);
            if (recordCount == 0)
                InsertRecord(record, "DdexRecordFoot", -1, -1);
            foreach (var bulkUploader in bulkUploaders.Values)
                bulkUploader.Flush();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                Logger.WriteLine("Відновлення зовнішніх ключів");
                cmd.CommandText = @"ALTER TABLE [dbo].[DdexRecordMwCanonical]  WITH NOCHECK ADD  CONSTRAINT [FK_MW01_01_Master_REFERENCE_AS01_01] FOREIGN KEY([BlockId], [DdexReportId])
                    REFERENCES [dbo].[DdexRecordAs] ([BlockId], [DdexReportId])
                    ALTER TABLE [dbo].[DdexRecordMwCanonical] CHECK CONSTRAINT [FK_MW01_01_Master_REFERENCE_AS01_01]

                    ALTER TABLE [dbo].[DdexRecordRu]  WITH NOCHECK ADD  CONSTRAINT [FK_RU01_01_Ex_REFERENCE_AS01_01] FOREIGN KEY([BlockId], [DdexReportId])
                    REFERENCES [dbo].[DdexRecordAs] ([BlockId], [DdexReportId])
                    ALTER TABLE [dbo].[DdexRecordRu] CHECK CONSTRAINT [FK_RU01_01_Ex_REFERENCE_AS01_01]

                    ALTER TABLE [dbo].[DdexRecordSu]  WITH NOCHECK ADD  CONSTRAINT [FK_SU03_02_Ex_REFERENCE_AS01_01] FOREIGN KEY([BlockId], [DdexReportId])
                    REFERENCES [dbo].[DdexRecordAs] ([BlockId], [DdexReportId])
                    ALTER TABLE [dbo].[DdexRecordSu] CHECK CONSTRAINT [FK_SU03_02_Ex_REFERENCE_AS01_01]

                    ALTER TABLE [dbo].[DdexRecordLi]  WITH NOCHECK ADD  CONSTRAINT [FK_LI01_02_REFERENCE_SU03_02] FOREIGN KEY([DdexReportId], [OwnerSuRecordIndex], [BlockId])
                    REFERENCES [dbo].[DdexRecordSu] ([DdexReportId], [RecordIndex], [BlockId])
                    ALTER TABLE [dbo].[DdexRecordLi] CHECK CONSTRAINT [FK_LI01_02_REFERENCE_SU03_02]

                    ALTER TABLE [dbo].[DdexRecordMw]  WITH NOCHECK ADD  CONSTRAINT [FK_LI01_02_REFERENCE_LI] FOREIGN KEY([DdexReportId], [OwnerLiRecordIndex], [BlockId])
                    REFERENCES [dbo].[DdexRecordLi] ([DdexReportId], [RecordIndex], [BlockId])
                    ALTER TABLE [dbo].[DdexRecordMw] CHECK CONSTRAINT [FK_LI01_02_REFERENCE_LI]";

                cmd.Connection = conn;
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
        }

        public override void ProcessSY_02_02(SYRecord_02_02 record)
        {
            int recordCount = (int)SqlHelpers.GetSingleValue(conn
                , "select isnull(count(*), 0) from DdexRecordSy_02_02 where DdexReportId = @p0 and SummaryRecordId = @p1"
                , report.ddexReportId, record.SummaryRecordId);
            if (recordCount == 0)
                InsertRecord(record, "DdexRecordSy_02_02", -1, -1);
        }

        public override void ProcessBlock(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockYouTube;
            try
            {
                //int ruRecordIndex = 0;
                int suRecordIndex = 0;
                int liRecordIndex = 0;
                int mwRecordIndex = 1;
                InsertRecord(block.asRecord, "DdexRecordAs", -1, -1);
                InsertRecord(block.canonicalMwRecord, "DdexRecordMwCanonical", -1, -1);


                /*
                 * foreach (var ruRecord in block.ruRecords)
                {
                    InsertRecord(ruRecord, "DdexRecordRu", ruRecordIndex++, -1);
                }
                */
                Dictionary<string, SURecord_03_02> masterSuRecords = new Dictionary<string, SURecord_03_02>();
                Dictionary<string, List<SURecord_03_02>> duplicateSuRecords = new Dictionary<string, List<SURecord_03_02>>();

                foreach (var suRecord in block.suRecords)
                {
                    string stId = suRecord.SalesTransactionId;
                    if (!masterSuRecords.ContainsKey(stId))
                        masterSuRecords.Add(stId, suRecord);
                    else
                    {
                        if (!duplicateSuRecords.ContainsKey(stId))
                        {
                            List<SURecord_03_02> lst = new List<SURecord_03_02>();
                            lst.Add(suRecord);
                            duplicateSuRecords.Add(stId, lst);
                        }
                        else
                            duplicateSuRecords[stId].Add(suRecord);
                    }
                }

                if (duplicateSuRecords.Count == 0)
                {
                    foreach (var suRecord in block.suRecords)
                    {
                        InsertRecord(suRecord, "DdexRecordSu", suRecordIndex, -1);
                        foreach (var liRecord in suRecord.liRecords)
                        {
                            InsertRecord(liRecord, "DdexRecordLi", liRecordIndex, suRecordIndex);
                            InsertRecord(liRecord.mwRecord, "DdexRecordMw", mwRecordIndex++, liRecordIndex);
                            liRecordIndex++;
                        }
                        suRecordIndex++;
                    }
                }
                else
                {
                    foreach (var pair in masterSuRecords)
                    {
                        SURecord_03_02 masterSuRecord = pair.Value;
                        if (!duplicateSuRecords.ContainsKey(masterSuRecord.SalesTransactionId))
                            continue;
                        foreach (SURecord_03_02 suRecord in duplicateSuRecords[masterSuRecord.SalesTransactionId])
                        {
                            decimal masterNetRevenue = (Formatter.ToDecimal(masterSuRecord.NetRevenue));
                            decimal duplicateNetRevenue = (Formatter.ToDecimal(suRecord.NetRevenue));
                            masterNetRevenue += duplicateNetRevenue;
                            masterSuRecord.NetRevenue = Formatter.ToString(masterNetRevenue);

                            decimal masterUsages = Formatter.ToDecimal(masterSuRecord.Usages);
                            decimal duplicateUsages = Formatter.ToDecimal(suRecord.Usages);
                            masterUsages += duplicateUsages;
                            masterSuRecord.Usages = Formatter.ToString(masterUsages);
                        }
                    }

                    foreach (var pair in masterSuRecords)
                    {
                        SURecord_03_02 masterSuRecord = pair.Value;
                        InsertRecord(masterSuRecord, "DdexRecordSu", suRecordIndex, -1);
                        foreach (var liRecord in pair.Value.liRecords)
                        {
                            InsertRecord(liRecord, "DdexRecordLi", liRecordIndex, suRecordIndex);
                            InsertRecord(liRecord.mwRecord, "DdexRecordMw", mwRecordIndex++, liRecordIndex);
                            liRecordIndex++;
                        }
                        if (!duplicateSuRecords.ContainsKey(masterSuRecord.SalesTransactionId))
                        {
                            suRecordIndex++;
                            continue;
                        }

                        foreach (var suRecord in duplicateSuRecords[masterSuRecord.SalesTransactionId])
                        {
                            foreach (var liRecord in suRecord.liRecords)
                            {
                                InsertRecord(liRecord, "DdexRecordLi", liRecordIndex, suRecordIndex);
                                InsertRecord(liRecord.mwRecord, "DdexRecordMw", mwRecordIndex++, liRecordIndex);
                                liRecordIndex++;
                            }
                        }

                        suRecordIndex++;
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
