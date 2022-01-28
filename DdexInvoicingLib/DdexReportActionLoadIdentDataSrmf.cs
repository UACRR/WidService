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
    public class DdexReportActionLoadIdentDataSrmf : DdexReportActionBase
    {
        // work data
        private SqlConnection conn;
        private int lastProcessedBlockId;
        private DateTime usageStartDate;
        private DateTime usageEndDate;

        // load statistics
        private int cntSalesInFile = 0;

        // Work data
        BulkUploadToSql bulkUploader;

        public DdexReportActionLoadIdentDataSrmf() {}

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

            bulkUploader = new BulkUploadToSql
            {
                TableName = "DdexIdentificationBacklog",
                conn = conn
            };
        }

        public override int GetLastProcessedBlockId()
        {
            return lastProcessedBlockId;
        }

        private void InsertRecord(DdexReportBlockSrmf block)
        {
            try
            {
                var data = new List<object>();
                data.Add(report.ddexReportId);
                data.Add(int.Parse(block.blockId));
                data.Add($"yt_presale_{report.ddexReportId}_{block.blockId}"); // salestransactionid
                data.Add(block.id); //DspReleaseId
                data.Add(block.comp_id); //DspResourceId
                data.Add("Music"); // ContentCategory
                data.Add(1 / Formatter.ToDecimal(block.quantile)); // Usages
                data.Add(1 / Formatter.ToDecimal(block.quantile)); /// NetRevenue
                data.Add(usageStartDate); // validityperiodstart
                data.Add(usageEndDate); // validityperiodend
                data.Add(block.title); // asTitle
                data.Add(block.artist); // displayartistname
                data.Add(block.comp_iswc); // iswc
                data.Add(block.comp_title); // mwtitle
                data.Add(block.comp_writers); // composerauthor
                int zero = 0;
                data.Add(zero); // status
                data.Add(zero); // ExcStatus
                data.Add(zero); // Wic
                data.Add(zero); // ObjId

                bulkUploader.AddData(data);
            }
            catch (Exception ex)
            {
                Logger.WriteLine($"Помилки формату в блоці {block.blockId} - {ex.Message}");
                throw;
            }
        }

        public override void ProcessBlock(DdexReportBlock blockBase)
        {
            var block = blockBase as DdexReportBlockSrmf;
            cntSalesInFile += 1;
            InsertRecord(block);
        }

        public override void ProcessFoot(FOOTRecord record)
        {
            bulkUploader.Flush();
        }

    }
}
