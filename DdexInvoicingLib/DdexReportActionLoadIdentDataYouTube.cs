using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicingLib
{
    public class DdexReportActionLoadIdentDataYouTube : DdexReportActionBase
    {
        // work data
        private SqlConnection conn;
        private int lastProcessedBlockId;
        private int recordIndexSy_04_01 = 1;
        private int recordIndexSy_05_02 = 1;
        private int pseudoBlockId = 1;
        private double royaltyThreshold;

        // variables for SVOD calculations
        private bool isFirstBlock = true;
        private bool isSWOD = false;
        private double musicRate = 0;
        private double geRate = 0;
        private double mechSplit = 0;
        private double perfSplit = 0;
        private double constantPSMRoyaltyValue = 0;
        private double constantGrossRevenueValue = 0;
        private double totalRevSharePayable = 0;
        private double totalPSMPayable = 0;
        private double blendedRevshareRate = 0;

        // load statistics
        private int cntSalesInFile = 0;
        private int cntMwInFile = 0;
        private int cntSalesLoaded = 0;
        private int cntMwLoaded = 0;

        // Work data
        Dictionary<string, BulkUploadToSql> bulkUploaders = new Dictionary<string, BulkUploadToSql>();
        HashSet<string> recordsToCorrect;

        public DdexReportActionLoadIdentDataYouTube()
        {

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

        public override string GetDescription() { return "Завантаження даних для ідентифікації із звіту"; }

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
                try
                {
                    cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));
                    Logger.WriteLine("Знаходження останнього обробленого блоку");
                    cmd.CommandText = @"declare @lastBlockId int;
                            select @lastBlockId = isnull(max(cast(blockid as int)), 0) from DdexIdentificationBacklog where DdexReportId = @DdexReportId;
                            select @lastBlockId";
                    lastProcessedBlockId = (int)cmd.ExecuteScalar();

                    Logger.WriteLine("Видалення раніше створенной інформації");
                    SqlHelpers.DeleteRecords(conn, "delete from DdexRecordSY_04_01 where DdexReportId = @p0", report.ddexReportId);
                    SqlHelpers.DeleteRecords(conn, "delete from DdexRecordSY_05_02 where DdexReportId = @p0", report.ddexReportId);
                    Logger.WriteLine($"Записи видалено за таблиць DdexRecordSY_04_01, DdexRecordSY_05_02");

                    recordsToCorrect = new HashSet<string>();
                    cmd.CommandText = @"select BlockId, RecordType, RecordIndex from DdexFileErrors where DdexReportId = @DdexReportId";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                recordsToCorrect.Add($"{reader.GetString(0)}-{reader.GetString(1)}-{reader.GetInt32(2)}");
                            }
                        }
                    }

                    cmd.CommandText = @"
                        select 
                              royaltyThreshold
                            , musicRate
                            , geRate
                        from DdexReport 
                        where id = @ddexReportId";
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        royaltyThreshold = Convert.ToDouble(r.GetDecimal(0));
                        musicRate = Convert.ToDouble(r.GetDecimal(1)) * 0.01;
                        geRate = Convert.ToDouble(r.GetDecimal(2)) * 0.01;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }

            RegisterBulkUploader("DdexIdentificationBacklog");
            RegisterBulkUploader("DdexRecordSY_04_01");
            RegisterBulkUploader("DdexRecordSY_05_02");

        }

        public override int GetLastProcessedBlockId()
        {
            return lastProcessedBlockId;
        }

        private void InsertRecord(ASRecord_01_01 asRecord, MWRecord mwRecord, SURecord_03_02 suRecord)
        {
            if (!isSWOD && royaltyThreshold > 0 && Formatter.ToDouble(suRecord.NetRevenue) == 0)
                return;

            cntSalesLoaded++;
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders["DdexIdentificationBacklog"];
                var data = new List<object>();
                data.Add(report.ddexReportId);
                data.Add(int.Parse(asRecord.BlockId));
                data.Add(suRecord.SalesTransactionId);
                data.Add(suRecord.DspReleaseId);
                data.Add(asRecord.DspResourceId);
                data.Add(suRecord.ContentCategory);
                data.Add(string.IsNullOrEmpty(suRecord.Usages.Trim()) ? 0 : Formatter.ToDecimal(suRecord.Usages));
                data.Add(string.IsNullOrEmpty(suRecord.NetRevenue.Trim()) ? 0 : Formatter.ToDecimal(suRecord.NetRevenue));
                string[] dateParts = suRecord.ValidityPeriodStart.Split('-');
                data.Add(new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2])));
                dateParts = suRecord.ValidityPeriodEnd.Split('-');
                data.Add(new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2])));
                data.Add(asRecord.Title);
                data.Add(asRecord.DisplayArtistName);
                data.Add(mwRecord.ISWC);
                data.Add(mwRecord.Title);
                data.Add(mwRecord.ComposerAuthor);
                int zero = 0;
                data.Add(zero);
                data.Add(zero);
                data.Add(zero);
                data.Add(zero);

                bulkUploader.AddData(data);
            }
            catch (Exception)
            {
                Logger.WriteLine($"Помилки формату в блоці {asRecord.BlockId}");
                throw;
            }
        }

        private void InsertRecord(DdexRecordBase record, string tableName, int recordIndex, int ownerRecordIndex)
        {
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders[tableName];
                var data = new List<object>();
                data.Add(report.ddexReportId);
                if (recordIndex != -1)
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
            using (SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    cmd.CommandText = @"
                        update DdexReport
                        set
                              cntSalesInFile = @cntSalesInFile
                            , cntMwInFile = @cntMwInFile
                            , cntSalesLoaded = @cntSalesLoaded
                            , cntMwLoaded = @cntMwLoaded
                        where id = @ddexReportId
                    ";
                    cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));
                    cmd.Parameters.Add(new SqlParameter("@cntSalesInFile", cntSalesInFile));
                    cmd.Parameters.Add(new SqlParameter("@cntMwInFile", cntMwInFile));
                    cmd.Parameters.Add(new SqlParameter("@cntSalesLoaded", cntSalesLoaded));
                    cmd.Parameters.Add(new SqlParameter("@cntMwLoaded", cntMwLoaded));
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public override void ProcessSY_04_01(SYRecord_04_01 record)
        {
            isSWOD = true;
            InsertRecord(record, "DdexRecordSY_04_01", recordIndexSy_04_01++);
        }
        public override void ProcessSY_05_02(SYRecord_05_02 record)
        {
            InsertRecord(record, "DdexRecordSY_05_02", recordIndexSy_05_02++);
        }
        public override void ProcessAP(APRecord record)
        {
            if(pseudoBlockId <= lastProcessedBlockId)
            {
                pseudoBlockId++;
                return;
            }
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders["DdexIdentificationBacklog"];
                var data = new List<object>();
                data.Add(report.ddexReportId);
                data.Add(pseudoBlockId++);
                data.Add(record.TrackISRC);
                data.Add(record.AlbumDspId);
                data.Add(record.TrackDspId);
                data.Add(record.ContentType);
                data.Add(pseudoBlockId); // pseudo value for usages
                data.Add(pseudoBlockId * 0.0001); // pseudo value for net revenue
                int year = 2000;
                //if (!string.IsNullOrEmpty(record.ReleaseYear))
                    //year = int.Parse(record.ReleaseYear);
                data.Add(new DateTime(year, 1, 1));
                data.Add(new DateTime(year + 100, 1, 1));
                data.Add(record.AlbumTitle);
                data.Add(record.TrackPrimaryArtist);
                data.Add(record.ISWC);
                data.Add(record.TrackTitle);
                data.Add(record.ComposerAuthor);
                int zero = 0;
                data.Add(zero);
                data.Add(zero);
                data.Add(zero);
                data.Add(zero);

                bulkUploader.AddData(data);
            }
            catch (Exception)
            {
                Logger.WriteLine($"Помилки формату в рядку {record.TrackISRC}");
                throw;
            }
        }

        private double CalcRoyalty(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockYouTube;
            double royalty = 0;
            if (!isSWOD)
            {
                royalty = block.suRecords.Sum(x =>
                    Formatter.ToDouble(x.NetRevenue) *
                    (x.ContentCategory.Equals("Music", StringComparison.OrdinalIgnoreCase) ? musicRate : geRate));
            }
            else
            {
                if (totalRevSharePayable > totalPSMPayable)
                {
                    royalty = block.suRecords.Sum(x =>
                        blendedRevshareRate * double.Parse(x.Usages, CultureInfo.InvariantCulture) * constantGrossRevenueValue);
                }
                else
                {
                    royalty = block.suRecords.Sum(x =>
                        constantPSMRoyaltyValue * double.Parse(x.Usages, CultureInfo.InvariantCulture));
                }
            }
            return royalty;
        }

        public override void ProcessBlock(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockYouTube;
            cntSalesInFile += block.suRecords.Count;
            cntMwInFile++;
            if (isFirstBlock)
            {
                isFirstBlock = false;
                if(isSWOD)
                {
                    foreach (var bulkUploader in bulkUploaders.Values)
                        bulkUploader.Flush();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        try
                        {
                            cmd.CommandText = @"spCreateCcidParamsForSubscr";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));
                            cmd.Parameters.Add(new SqlParameter("@musicRate", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@geRate", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@mechSplit", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@perfSplit", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@totalRevSharePayable", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@totalPSMPayable", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@constantGrossRevenueValue", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@constantPSMRoyaltyValue", SqlDbType.Float) { Direction = ParameterDirection.Output });
                            cmd.Parameters.Add(new SqlParameter("@blendedRevshareRate", SqlDbType.Float) { Direction = ParameterDirection.Output });

                            cmd.ExecuteNonQuery();

                            musicRate = (double)cmd.Parameters["@musicRate"].Value;
                            geRate = (double)cmd.Parameters["@geRate"].Value;
                            mechSplit = (double)cmd.Parameters["@mechSplit"].Value;
                            perfSplit = (double)cmd.Parameters["@perfSplit"].Value;
                            totalRevSharePayable = (double)cmd.Parameters["@totalRevSharePayable"].Value;
                            totalPSMPayable = (double)cmd.Parameters["@totalPSMPayable"].Value;
                            constantGrossRevenueValue = (double)cmd.Parameters["@constantGrossRevenueValue"].Value;
                            constantPSMRoyaltyValue = (double)cmd.Parameters["@constantPSMRoyaltyValue"].Value;
                            blendedRevshareRate = (double)cmd.Parameters["@blendedRevshareRate"].Value;
                        }
                        catch (Exception ex)
                        {
                            Logger.WriteLine(ex.Message);
                            throw;
                        }
                    }
                }
            }

            if (CalcRoyalty(block) < Convert.ToDouble(royaltyThreshold))
                return;

            cntMwLoaded++;
            try
            {
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
                        InsertRecord(block.asRecord, block.canonicalMwRecord, suRecord);
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
                            decimal masterNetRevenue = Formatter.ToDecimal(masterSuRecord.NetRevenue);
                            decimal duplicateNetRevenue = Formatter.ToDecimal(suRecord.NetRevenue);
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
                        InsertRecord(block.asRecord, block.canonicalMwRecord, masterSuRecord);
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
