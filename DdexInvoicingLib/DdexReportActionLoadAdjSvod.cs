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
    public class DdexReportActionLoadAdjSvod : DdexReportActionBase
    {
        private SqlConnection conn;

        // Work data
        Dictionary<string, BulkUploadToSql> bulkUploaders = new Dictionary<string, BulkUploadToSql>();

        public DdexReportActionLoadAdjSvod()
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

        public override void Init(DdexReport report)
        {
            this.report = report;
            conn = new SqlConnection(report.ConnectString);
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.Parameters.AddWithValue("@DdexReportId", report.ddexReportId);
                cmd.CommandText = "delete from DdexAdjConsolidatedSummary where DdexReportId = @DdexReportId";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from DdexAdjConsolidatedDetail where DdexReportId = @DdexReportId";
                cmd.ExecuteNonQuery();
            }

            RegisterBulkUploader("DdexAdjConsolidatedSummary");
            RegisterBulkUploader("DdexAdjConsolidatedDetail");

        }

        public override void ProcessSY_05_02(SYRecord_05_02 syRecord)
        {
            if (!syRecord.RightsController.Equals(UACRR_CS, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            BulkUploadToSql bulkUploader = bulkUploaders["DdexAdjConsolidatedSummary"];
            List<object> data = new List<object>();
            data.Add(report.ddexReportId);
            data.Add(syRecord.SummaryRecordId);
            data.Add(Formatter.ToDecimal(syRecord.AllocatedUsages));
            data.Add(Formatter.ToDecimal(syRecord.AllocatedRevenue));
            data.Add(Meta.DdexEnumRightsType.Value(syRecord.RightsType));
            data.Add(Meta.DdexEnumContentCategory.Value(syRecord.ContentCategory));
            bulkUploader.AddData(data);
        }

        public override void ProcessFoot(FOOTRecord record)
        {
            foreach (var bulkUploader in bulkUploaders.Values)
                bulkUploader.Flush();
        }

        public override void ProcessBlock(DdexReportBlock block)
        {
            BulkUploadToSql bulkUploader = bulkUploaders["DdexAdjConsolidatedDetail"];
            try
            {
                foreach (var suRecord in block.suRecords)
                {
                    foreach (var liRecord in suRecord.liRecords)
                    {
                        if (liRecord.RightsController.Equals(UACRR_CS, StringComparison.OrdinalIgnoreCase))
                        {
                            List<object> data = new List<object>();
                            data.Add(report.ddexReportId);
                            data.Add(suRecord.SalesTransactionId);
                            data.Add(Formatter.ToDecimal(liRecord.AllocatedUsages));
                            data.Add(Formatter.ToDecimal(liRecord.AllocatedAmount));
                            data.Add(Meta.DdexEnumRightsType.Value(liRecord.RightType));
                            data.Add(Meta.DdexEnumContentCategory.Value(suRecord.ContentCategory));
                            data.Add(0M); // Initial compensated amount
                            // WorkCode skiooed, will be null
                            bulkUploader.AddData(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
