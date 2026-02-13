using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvoicingLib;
using System.Data.SqlClient;

namespace DdexInvoicing
{
    public partial class UcInvoiceDetails : UserControl
    {
        class DdexDetail
        {
            [Category("")]
            [ReadOnly(true)]
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

        private Dictionary<string, int> serviceToReportMap;

        public UcInvoiceDetails()
        {
            InitializeComponent();
        }

        private void UcInvoiceDetails_Load(object sender, EventArgs e)
        {
        }

        public void Init(int _leadingFileId)
        {
            leadingFileId = _leadingFileId;

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    select sum_amount_licensor from CcidInTrailer where fileId = @leadingFileId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@leadingFileId", leadingFileId);
                var amount = cmd.ExecuteScalar();

                cmd.CommandText = @"
                    select t2.ddexReportId
                    from CcidInFile t1
	                    join CcidInvoice t2 on t1.ccidInvoiceId = t2.Id
                    where t1.fileId = @leadingFileId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@leadingFileId", leadingFileId);
                var leadingDdexReportId = (int)cmd.ExecuteScalar();

                var agreementReportType = DdexReport.GetAgreementReportType(cmd, leadingDdexReportId);
                if(
                    agreementReportType == DdexReport.ReportTypeEnum.TIKTOK ||
                    agreementReportType == DdexReport.ReportTypeEnum.META
                )
                {
                    cmd.CommandText = @"
                        select distinct
	                          concat(Territory, ' - ', t2.Tisan) as Territory
	                        , t1.Id
                        from DdexReport t1
	                        left join SocIpi..DicTna t2 on t1.Territory = t2.Tisa
                        where t1.Id in (select id from ft_AgreementReportIds(@leadingDdexReportId))
                        order by concat(Territory, ' - ', t2.Tisan)
                    ";
                }
                else
                {
                    cmd.CommandText = @"
                        select ServiceDescription, DdexReportId
                        from DdexRecordHead
                        where ddexReportId in (select id from ft_AgreementReportIds(@leadingDdexReportId))
                        order by ServiceDescription
                    ";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@leadingDdexReportId", leadingDdexReportId);
                var r = cmd.ExecuteReader();
                serviceToReportMap = new Dictionary<string, int>();
                while (r.Read())
                {
                    serviceToReportMap.Add(r.GetString(0), r.GetInt32(1));
                }
                r.Close();
            });

            foreach (var serviceName in serviceToReportMap.Keys)
            {
                radCbServices.Items.Add(serviceName);
            }
            radCbServices.SelectedIndex = 0;
        }


        private void radBtnLoad_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                // Get selectedDdexReportId
                var selectedDdexReportId = serviceToReportMap[radCbServices.Text];

                // Set ccid table names depending upon file type (input or output)
                var fileTable = "CcidInFile";
                var detailTable = "CcidInDetail";

                // Set sales transaction id prefix depending on selected ddex report
                var stidPrefix = DdexReport.GetStidPrefixForDdexReport(cmd, selectedDdexReportId);

                // Set join text depending ddex report file type
                var joinText = DdexReport.IsYouTubeSrmfType(cmd, leadingFileId) ?
                    "t1.release_id = t4.DspReleaseId" :
                    $"'{stidPrefix}' + t1.sales_transaction_id = t4.SalesTransactionId";

                // get fileId of ccid file that corresponds to selected report among group defined by the leading file
                cmd.CommandText = $@"
                        select t2.ddexReportId
                        from {fileTable} t1
                            join CcidInvoice t2 on t1.ccidInvoiceId = t2.Id
                        where fileId = @fileId
                    ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fileId", leadingFileId);
                var leadingDdexReportId = Convert.ToInt32(cmd.ExecuteScalar());

                var fileId = 0;
                if (selectedDdexReportId == leadingDdexReportId)
                {
                    fileId = leadingFileId;
                }
                else
                {
                    cmd.CommandText = $@"
                            select t2.fileId
                            from {fileTable} t1
                                join {fileTable} t2 on t1.ccidInvoiceId = t2.ccidInvoiceId
                                    and t1.InstanceIndex = t2.InstanceIndex
                            where t1.fileId = @fileId
                                and t2.ddexReportId = @ddexReportId
                        ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@fileId", leadingFileId);
                    cmd.Parameters.AddWithValue("@ddexReportId", selectedDdexReportId);
                    fileId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (selectedDdexReportId == leadingDdexReportId)
                {
                    cmd.CommandText = $@"
                        {selectStmt}
                        from {detailTable} t1
                            join {fileTable} t2 on t2.fileId = t1.fileId
                            join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
                            join IdentBacklog t4 on {joinText}
                            join IdentMw t5 on t4.mwId = t5.id
                        where t1.fileId = @fileId and t3.ddexReportId = t4.ddexReportId
                        order by t4.NetRevenue desc
                    ";
                }
                else
                {
                    cmd.CommandText = $@"
                        {selectStmt}
                        from {detailTable} t1
                            join {fileTable} t2 on t2.fileId = t1.fileId
                            join IdentBacklog t4 on {joinText}
                            join IdentMw t5 on t4.mwId = t5.id
                        where t1.fileId = @fileId and t2.ddexReportId = t4.ddexReportId
                        order by t4.NetRevenue desc
                    ";
                }

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@fileId", fileId);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                radGridSales.DataSource = dt;
            });
        }

        private void radGridSales_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            DataTable dt = radGridSales.DataSource as DataTable;
            DataRow row = dt.Rows[e.CurrentRow.Index];
            var ddexDetail = new DdexDetail()
            {
                BlockId = row.Field<int>("BlockId"),
                SalesTransactionId = row.Field<string>("SalesTransactionId"),
                DspReleaseId = row.Field<string>("DspReleaseId"),
                DspResourceId = row.Field<string>("DspResourceId"),
                ContentCategory = row.Field<string>("ContentCategory"),
                NetRevenue = row.Field<decimal>("NetRevenue"),
                Usages = row.Field<decimal>("Usages"),
                ValidityPeriodStart = row.Field<DateTime>("ValidityPeriodStart"),
                ValidityPeriodEnd = row.Field<DateTime>("ValidityPeriodEnd"),
                rateTotalPer = row.Field<decimal>("rateTotalPer"),
                rateTotalMec = row.Field<decimal>("rateTotalMec"),
                Wic = row.Field<int?>("Wic"),
                ObjId = row.Field<int?>("ObjId"),
            };
            pgDdex.SelectedObject = ddexDetail;

            var ccidDetail = new CcidDetail()
            {
                record_type = row.Field<string>("record_type"),
                transaction_type = row.Field<string>("transaction_type"),
                sales_transaction_id = row.Field<string>("sales_transaction_id"),
                release_id = row.Field<string>("release_id"),
                resource_id = row.Field<string>("resource_id"),
                workcode = row.Field<string>("workcode"),
                work_title = row.Field<string>("work_title"),
                use_quantity = row.Field<decimal?>("use_quantity"),
                applied_tariff = row.Field<string>("applied_tariff"),
                original_release_revenue_basis = row.Field<decimal?>("original_release_revenue_basis"),
                original_resource_revenue_basis = row.Field<decimal?>("original_resource_revenue_basis"),
                claim_licensor_combined = row.Field<decimal?>("claim_licensor_combined"),
                claim_unmatched_combined = row.Field<decimal?>("claim_unmatched_combined"),
                amount_invoiced_total = row.Field<decimal?>("amount_invoiced_total"),
                claim_licensor_mech = row.Field<decimal?>("claim_licensor_mech"),
                claim_licensor_perf = row.Field<decimal?>("claim_licensor_perf"),
                amount_licensor_mech = row.Field<decimal?>("amount_licensor_mech"),
                amount_licensor_perf = row.Field<decimal?>("amount_licensor_perf")

            };
            pgCcid.SelectedObject = ccidDetail;
        }

        private void radCbServices_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radGridSales.DataSource = null;
        }
    }
}
