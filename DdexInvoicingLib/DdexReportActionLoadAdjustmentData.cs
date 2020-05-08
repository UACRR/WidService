using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoicingLib
{
    public class DdexReportActionLoadAdjustmentData : DdexReportActionBase
    {
        private SqlConnection conn;
        private int fileId;

        BulkUploadToSql bulkUploader;
        public DdexReportActionLoadAdjustmentData(int fileId)
        {
            this.fileId = fileId;
        }

        public override void Init(DdexReport report)
        {
            this.report = report;
            conn = new SqlConnection(report.ConnectString);
            conn.Open();
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "delete from DdexAdjustment where fileId = @fileId";
                cmd.Parameters.AddWithValue("@fileId", fileId);
                cmd.ExecuteNonQuery();
            }

            bulkUploader = new BulkUploadToSql
            {
                TableName = "DdexAdjustment",
                conn = conn
            };

        }

        public override void ProcessFoot(FOOTRecord record)
        {
            bulkUploader.Flush();
        }

        public override void ProcessBlock(DdexReportBlock block)
        {
           try
            {
                foreach (var suRecord in block.suRecords)
                {
                    foreach(var liRecord in suRecord.liRecords)
                    {
                        if(liRecord.RightsController.Equals("UACRR_CS", StringComparison.OrdinalIgnoreCase))
                        {
                            List<object> data = new List<object>();
                            data.Add(fileId);
                            data.Add(suRecord.SalesTransactionId);
                            data.Add(Meta.DdexAdjustmentType.Value(liRecord.RightType));
                            data.Add(Formatter.ToDecimal(liRecord.AllocatedAmount));
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
