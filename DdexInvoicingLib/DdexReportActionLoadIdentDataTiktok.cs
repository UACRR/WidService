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
    public class DdexReportActionLoadIdentDataTiktok : DdexReportActionBase
    {
        // work data
        private SqlConnection conn;
        private int lastProcessedBlockId;
        private decimal royaltyThreshold;
        private decimal netRevenuePerUsage;
        private decimal musicRate = 0;
        private string stidPrefix = "";
        private HEADRecordGoogle headRecord;

        // load statistics
        private int cntSalesInFile = 0;
        private int cntSalesLoaded = 0;

        // Work data
        Dictionary<string, BulkUploadToSql> bulkUploaders = new Dictionary<string, BulkUploadToSql>();

        public DdexReportActionLoadIdentDataTiktok()
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
                    SqlHelpers.DeleteRecords(conn, "delete from DdexRecordSY_Base where DdexReportId = @p0", report.ddexReportId);
                    Logger.WriteLine($"Записи видалено за таблиці DdexRecordSY_Base");

                    cmd.CommandText = @"
                        select 
                              royaltyThreshold
                            , musicRate
                        from DdexReport 
                        where id = @ddexReportId";
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        royaltyThreshold = r.GetDecimal(0);
                        musicRate = r.GetDecimal(1) * 0.01M;
                    }
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }

            RegisterBulkUploader("DdexIdentificationBacklog");
            RegisterBulkUploader("DdexRecordSY_Base");
        }

        public override int GetLastProcessedBlockId()
        {
            return lastProcessedBlockId;
        }

        private void InsertRecord(ASRecord_02_02 asRecord, SURecord_02 suRecord)
        {
            cntSalesLoaded++;
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders["DdexIdentificationBacklog"];
                var data = new List<object>();
                data.Add(report.ddexReportId);
                data.Add(int.Parse(suRecord.BlockId));
                data.Add(stidPrefix + suRecord.SalesTransactionId);
                data.Add(asRecord.DspResourceId);
                data.Add(asRecord.DspResourceId);
                data.Add("Music");
                data.Add(Formatter.ToDecimal(suRecord.NumberOfStreams));
                data.Add(Formatter.ToDecimal(suRecord.NumberOfStreams) * netRevenuePerUsage);
                string[] dateParts = headRecord.UsageStartDate.Split('-');
                data.Add(new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2])));
                dateParts = headRecord.UsageEndDate.Split('-');
                data.Add(new DateTime(int.Parse(dateParts[0]), int.Parse(dateParts[1]), int.Parse(dateParts[2])));
                data.Add("");
                data.Add(asRecord.DisplayArtistName);
                data.Add(asRecord.ISWC);
                data.Add(asRecord.Title);
                data.Add(asRecord.ComposerAuthor);
                int zero = 0;
                data.Add(zero);
                data.Add(zero);
                data.Add(zero);
                data.Add(zero);

                bulkUploader.AddData(data);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Помилки формату в блоці {asRecord.BlockId} - {ex.Message}");
                throw;
            }
        }

        private void InsertRecord(SYRecord_01_01 syRecord)
        {
            cntSalesLoaded++;
            try
            {
                BulkUploadToSql bulkUploader = bulkUploaders["DdexRecordSY_Base"];
                var data = new List<object>();
                data.Add(report.ddexReportId);
                data.Add(1);
                data.Add(syRecord.SummaryRecordId);
                data.Add(syRecord.DistributionChannel);
                data.Add(syRecord.DistributionChannelDPID);
                data.Add(syRecord.CommercialModel);
                data.Add(syRecord.UseType);
                data.Add(syRecord.Territory);
                data.Add(syRecord.ServiceDescription);
                data.Add(syRecord.Usages);
                data.Add(Formatter.ToDecimal(syRecord.Subscribers));
                data.Add(syRecord.CurrencyOfReporting);
                data.Add(Formatter.ToDecimal(syRecord.NetRevenue));
                data.Add(0.0);

                bulkUploader.AddData(data);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Помилка формату - {ex.Message}");
                throw;
            }
        }

        public override void ProcessHead(HEADRecordGoogle headRecord)
        {
            this.headRecord = headRecord;
            stidPrefix = $"{headRecord.SenderName}_{headRecord.ServiceDescription}_{headRecord.UsageStartDate}@";
        }

        public override void ProcessSY_01_01(SYRecord_01_01 record)
        {
            netRevenuePerUsage = Formatter.ToDecimal(record.NetRevenue) / Formatter.ToDecimal(record.Usages);
            InsertRecord(record);
        }

        public override void ProcessBlock(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockTiktok;
            cntSalesInFile += 1;

            if (Formatter.ToDecimal(block.suRecord.NumberOfStreams) * netRevenuePerUsage < royaltyThreshold)
                return;
            InsertRecord(block.asRecord, block.suRecord);
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
                    cmd.Parameters.Add(new SqlParameter("@cntMwInFile", cntSalesInFile));
                    cmd.Parameters.Add(new SqlParameter("@cntSalesLoaded", cntSalesLoaded));
                    cmd.Parameters.Add(new SqlParameter("@cntMwLoaded", cntSalesLoaded));
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spDdexTikTokCalcNetRevenuePerResource";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new SqlParameter("@DdexReportId", report.ddexReportId));

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }
        }

    }
}
