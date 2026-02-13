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
    public class DdexReportActionLoadIdentDataMeta : DdexReportActionBase
    {
        // work data
        private SqlConnection conn;
        private int lastProcessedBlockId;
        private DateTime usageStartDate;
        private DateTime usageEndDate;

        // load statistics
        private int cntSalesInFile = 0;

        // Work data
        BulkUploadToSql bulkUploaderSR;
        BulkUploadToSql bulkUploaderSY;

        public DdexReportActionLoadIdentDataMeta() {}

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

                    cmd.CommandText = @"select UsageStartDate from DdexRecordHead where DdexReportId = @DdexReportId";
                    usageStartDate = (DateTime)cmd.ExecuteScalar();

                    cmd.CommandText = @"select UsageEndDate from DdexRecordHead where DdexReportId = @DdexReportId";
                    usageEndDate = (DateTime)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Logger.WriteLine(ex.Message);
                    throw;
                }
            }

            bulkUploaderSY = new BulkUploadToSql { TableName = "DdexRecordSY_Base", conn = conn };
            bulkUploaderSR = new BulkUploadToSql { TableName = "DdexIdentificationBacklog", conn = conn };
        }

        public override int GetLastProcessedBlockId()
        {
            return lastProcessedBlockId;
        }

        private void InsertRecord(DdexReportBlockMeta block)
        {
            try
            {
                var rec = block.record;
                var netRevenue = rec.NetRevenue == "" ? 0 : double.Parse(rec.NetRevenue, CultureInfo.InvariantCulture);
                if(netRevenue == 0)
                {
                    return;
                }

                var data = new List<object>();
                data.Add(report.ddexReportId);
                data.Add(block.blockId);
                data.Add(rec.SalesTransactionId); // salestransactionid
                data.Add(rec.DspReleaseId); //DspReleaseId
                data.Add(rec.DspResourceId); //DspResourceId
                data.Add(rec.ContentCategory); // ContentCategory
                data.Add(rec.Usages == "" ? 0 : int.Parse(rec.Usages)); // Usages
                data.Add(rec.NetRevenue == "" ? 0 : double.Parse(rec.NetRevenue, CultureInfo.InvariantCulture)); // NetRevenue
                data.Add(DateTime.Parse(rec.ValidityPeriodStart)); // validityperiodstart
                data.Add(DateTime.Parse(rec.ValidityPeriodEnd)); // validityperiodend
                data.Add(rec.ResourceTitle); // asTitle
                data.Add(rec.ResourceDisplayArtistName); // displayartistname
                data.Add(rec.ISWC); // iswc
                data.Add(rec.WorkTitle); // mwtitle
                data.Add(rec.ComposerAuthor); // composerauthor
                int zero = 0;
                data.Add(zero); // status
                data.Add(zero); // ExcStatus
                data.Add(zero); // Wic
                data.Add(zero); // ObjId

                bulkUploaderSR.AddData(data);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Помилки формату в блоці {block.blockId} - {ex.Message}");
                throw;
            }
        }

        public void InsertRecord(SYRecord_02_02 rec)
        {
            try
            {
                var data = new List<object>();

                data.Add(report.ddexReportId);  // DdexReportId
                data.Add(int.Parse(rec.SummaryRecordId));// RecordIndex
                data.Add(rec.SummaryRecordId);// SummaryRecordId
                data.Add(rec.DistributionChannel);// DistributionChannel
                data.Add(rec.DistributionChannelDPID);// DistributionChannelDPID
                data.Add(rec.CommercialModel);// CommercialModel
                data.Add(rec.UseType);// UseType
                data.Add(rec.Territory);// Territory
                data.Add(rec.ServiceDescription);// ServiceDescription
                data.Add(rec.Usages == "" ? 0 : long.Parse(rec.Usages) / 100);// Usages
                data.Add(rec.Users == "" ? 0 : int.Parse(rec.Users));// Subscribers
                data.Add(rec.Currency);// Currency
                data.Add(rec.NetRevenue == "" ? 0 : double.Parse(rec.NetRevenue, CultureInfo.InvariantCulture));// NetRevenue
                data.Add(rec.AllocatedNetRevenue == "" ? 0 : double.Parse(rec.AllocatedNetRevenue, CultureInfo.InvariantCulture));// IndirectNetRevenue

                bulkUploaderSY.AddData(data);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Помилки формату в записі SY02.03 {rec.SummaryRecordId} - {ex.Message}");
                throw;
            }
        }

        public override void ProcessSY_02_02(SYRecord_02_02 record)
        {
            InsertRecord(record);
        }

        public override void ProcessBlock(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockMeta;
            cntSalesInFile += 1;
            InsertRecord(block);
        }

        public override void ProcessFoot(FOOTRecord record)
        {
            bulkUploaderSY.Flush();
            bulkUploaderSR.Flush();
        }

    }
}
