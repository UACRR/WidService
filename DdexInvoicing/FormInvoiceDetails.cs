using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class FormInvoiceDetails : Form
    {
        class DdexDetail
        {
            [Category("")] [ReadOnly(true)]
            public int BlockId { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public string SalesTransactionId { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public string DspReleaseId { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public string DspResourceId { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public string ContentCategory { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public decimal NetRevenue { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public decimal Usages { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public DateTime ValidityPeriodStart { get; set; }
            [Category("Input information")]
            [ReadOnly(true)]
            public DateTime ValidityPeriodEnd { get; set; }
            [Category("Result of search")]
            [ReadOnly(true)]
            public decimal rateTotalPer { get; set; }
            [Category("Result of search")]
            [ReadOnly(true)]
            public decimal rateTotalMec { get; set; }
            [Category("Result of search")]
            [ReadOnly(true)]
            public int? Wic { get; set; }
            [Category("Result of search")]
            [ReadOnly(true)]
            public int? ObjId { get; set; }
        }

        class CcidDetail
        {
            [Category("1 - System Information")]
            [ReadOnly(true)]
            public string record_type { get; set; }
            [Category("1 - System Information")]
            [ReadOnly(true)]
            public string transaction_type { get; set; }
            [Category("2 - From Ddex")]
            [ReadOnly(true)]
            public string sales_transaction_id { get; set; }
            [Category("2 - From Ddex")]
            [ReadOnly(true)]
            public string release_id { get; set; }
            [Category("2 - From Ddex")]
            [ReadOnly(true)]
            public string resource_id { get; set; }
            [Category("2 - From Ddex")]
            [ReadOnly(true)]
            public decimal? use_quantity { get; set; }
            [Category("3 - Found/Identified")]
            [ReadOnly(true)]
            public string workcode { get; set; }
            [Category("3 - Found/Identified")]
            [ReadOnly(true)]
            public string work_title { get; set; }
            [Category("4 - Basis for Calculations")]
            [ReadOnly(true)]
            public string applied_tariff { get; set; }
            [Category("4 - Basis for Calculations")]
            [ReadOnly(true)]
            public decimal? original_release_revenue_basis { get; set; }
            [Category("4 - Basis for Calculations")]
            [ReadOnly(true)]
            public decimal? original_resource_revenue_basis { get; set; }
            [Category("5 - Calculated")]
            [ReadOnly(true)]
            public decimal? claim_licensor_combined { get; set; }
            [Category("5 - Calculated")]
            [ReadOnly(true)]
            public decimal? claim_unmatched_combined { get; set; }
            [Category("5 - Calculated")]
            [ReadOnly(true)]
            public decimal? amount_invoiced_total { get; set; }
            [Category("5 - Calculated")]
            [ReadOnly(true)]
            public decimal? claim_licensor_mech { get; set; }
            [Category("5 - Calculated")]
            [ReadOnly(true)]
            public decimal? claim_licensor_perf { get; set; }
            [Category("5 - Calculated")]
            [ReadOnly(true)]
            public decimal? amount_licensor_mech { get; set; }
            [Category("5 - Calculated")]
            [ReadOnly(true)]
            public decimal? amount_licensor_perf { get; set; }
        }

        private const string selectStmt = @"
            select top 1000
                    t4.*
                ,   t5.ResourceTitle
                ,   t5.Title
                ,   t5.ComposerAuthor
                ,   t5.DisplayArtistName
                ,   t5.ISWC
                ,   t5.Wic
                ,   t5.[ObjId]
                ,   t1.record_type
                ,   t1.transaction_type
                ,   t1.sales_transaction_id
                ,   t1.release_id
                ,   t1.resource_id
                ,   t1.workcode
                ,   t1.work_title
                ,   t1.use_quantity
                ,   t1.applied_tariff
                ,   t1.original_release_revenue_basis
                ,   t1.original_resource_revenue_basis
                ,   t1.claim_licensor_combined
                ,   t1.claim_unmatched_combined
                ,   t1.amount_invoiced_total
                ,   t1.claim_licensor_mech
                ,   t1.claim_licensor_perf
                ,   t1.amount_licensor_mech
                ,   t1.amount_licensor_perf
            ";

        public int leadingFileId;
        public int fileType;

        public FormInvoiceDetails()
        {
            InitializeComponent();
        }

        private void FormInvoiceDetails_Load(object sender, EventArgs e)
        {
            Text = Text + (fileType == 0 ? " (заявка на отримання коштів)" : " (відповідь від клієнта)");

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                        select sum_amount_licensor from CcidInTrailer where fileId = @leadingFileId
                        ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@leadingFileId", leadingFileId);
                var amount = cmd.ExecuteScalar();
                radTbTotalAmount.Text = amount.ToString().Replace(',', '.');

                cmd.CommandText = @"
                        select setCodeDate from CcidInFile where fileId = @leadingFileId
                        ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@leadingFileId", leadingFileId);
                var setCodeDate = cmd.ExecuteScalar();
                radTbExceptionSetDate.Text = setCodeDate != DBNull.Value ? ((DateTime)setCodeDate).ToString("yyyy-MM-dd hh:mm:ss") : "";

                cmd.CommandText = @"
                        select t2.setName from CcidInFile t1 join ExceptionSet t2 on t1.setCode = t2.setCode where fileId = @leadingFileId
                        ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@leadingFileId", leadingFileId);
                var setName = (string)cmd.ExecuteScalar();
                radTbExceptionSet.Text = setName;
            });

            ucInvoiceDetails.Init(leadingFileId);
            ucCcidInvoiceTestResults.Init(leadingFileId);
            ucCcidInvoiceExpectedDist.Init(leadingFileId);
            ucCcidInvoiceWrongIpBaseNr.Init(leadingFileId);
        }

        private void radBtnLoad_Click(object sender, EventArgs e)
        {
        }

        private void radGridSales_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {

        }

        private void radCbServices_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
        }
    }
}
