using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class UcRoyaltyDistributionSingleReport : UserControl
    {
        public const string MESSAGE_BOX_TITLE = "Розподіл і оплата";
        public class DdexReportInfo
        {
            public int          DdexReportId            { get; set; }
            public int          LicId                   { get; set; }
            public string       ServiceName             { get; set; }
            public int          Year                    { get; set; }
            public int          Quarter                 { get; set; }
            public int?         DistributionStatus      { get; set; }
            public string       DistributionStatusName  { get; set; }
            public int?         RegId                   { get; set; }
	        public int?         PeriodId                { get; set; }
	        public decimal?     ExchangeRate            { get; set; }
	        public int?         PaidId                  { get; set; }
	        public string       NumberInvoice           { get; set; }
	        public string       GoalInvoice             { get; set; }
	        public DateTime?    DateInvoice             { get; set; }
	        public decimal?     AmountReceivedTotal     { get; set; }
	        public decimal?     AmountReceivedPeriod    { get; set; }
        }

        private readonly Dictionary<int, string> _licName = new Dictionary<int, string>()
        {
            { 1333, "Реклама" },
            { 1339, "Музика"  },
            { 1338, "Преміум" }
        };

        private const int GOOGLE_CUST_ID = 39556;

        private List<DdexReportInfo> _ddexReportInfo;
        private bool _hasData = false;

        public UcRoyaltyDistributionSingleReport()
        {
            InitializeComponent();
        }

        private void UcRoyaltyDistributionSingleReport_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvReports.View = View.Details;
            lvReports.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvReports.FullRowSelect = true;
            lvReports.GridLines = true;
            lvReports.MultiSelect = false;
            lvReports.Columns.Add("Сервіс", 100);
            lvReports.Columns.Add("Рік", 60);
            lvReports.Columns.Add("Квартал", 60);
            lvReports.Columns.Add("Стан розподілу", 210);

            ConfigureFilter();
        }

        private void ConfigureFilter()
        {
            cbFilterStatus.Items.Add("Не виконано");
            cbFilterStatus.Items.Add("Виконано");
            cbFilterStatus.SelectedIndex = 0; 

            cbFilterService.Items.Add("<Всі>");
            foreach (var item in _licName)
            {
                cbFilterService.Items.Add(item.Value);
            }
            cbFilterService.SelectedIndex = 0;

            var minYear = 0;
            var maxYear = 0;
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    select
                          min(t2.Year)
                        , max(t2.Year)
                    from DdexReport t1
                        join DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
                    where t1.CustId = @custId
                        and t1.Status = 16
                ";
                cmd.Parameters.AddWithValue("@custId", GOOGLE_CUST_ID);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    minYear = r.GetInt32(0);
                    maxYear = r.GetInt32(1);
                }
            });
            cbFilterYear.Items.Add("<Всі>");
            for (var year = minYear; year <= maxYear; year++)   
            {
                cbFilterYear.Items.Add(year.ToString());
            }
            cbFilterYear.SelectedIndex = 0;

            cbFilterQuarter.Items.Add("<Всі>");
            for (var quarter = 1; quarter <= 4; quarter++)   
            {
                cbFilterQuarter.Items.Add(quarter.ToString());
            }
            cbFilterQuarter.SelectedIndex = 0;
        }

        private void ReadDdexReportInfoMain(SqlDataReader r, DdexReportInfo ddexReportInfo)
        {
            ddexReportInfo.DdexReportId = r.GetInt32(0);
            ddexReportInfo.LicId = r.GetInt32(1);
            ddexReportInfo.ServiceName = _licName[ddexReportInfo.LicId];
            ddexReportInfo.Year = r.GetInt32(2);
            ddexReportInfo.Quarter = r.GetInt32(3); 
            ddexReportInfo.DistributionStatus = -1;
            ddexReportInfo.DistributionStatusName = "Не передано в СМАРТ";
        }

        private void ReadDdexReportInfoDetails(SqlDataReader r, DdexReportInfo ddexReportInfo)
        {
            var idx = 1;
            ddexReportInfo.RegId                  = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++; 
	        ddexReportInfo.DistributionStatus     = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++;
	        ddexReportInfo.DistributionStatusName = r.IsDBNull(idx) ? null           : r.GetString(idx);  idx++;
            ddexReportInfo.PeriodId               = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++;
	        ddexReportInfo.ExchangeRate           = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx); idx++;
	        ddexReportInfo.PaidId                 = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++;
	        ddexReportInfo.NumberInvoice          = r.IsDBNull(idx) ? null           : r.GetString(idx);  idx++;
	        ddexReportInfo.GoalInvoice            = r.IsDBNull(idx) ? null           : r.GetString(idx);  idx++;
            ddexReportInfo.DateInvoice            = r.IsDBNull(idx) ? (DateTime?)null: r.GetDateTime(idx);idx++;
	        ddexReportInfo.AmountReceivedTotal    = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx); idx++;
            ddexReportInfo.AmountReceivedPeriod   = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx); idx++;
        }

        public void ReadData()
        {
            if (_hasData)
            {
                return;
            }

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    select
	                      t1.Id
	                    , t1.LicId
	                    , t2.Year
	                    , t2.Quarter
                    from DdexReport t1
	                    join DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
                    where t1.CustId = @custId
                        and t1.Status = 16
                    order by t2.Year desc, t2.Quarter desc, t1.LicId
                ";
                cmd.Parameters.AddWithValue("@custId", GOOGLE_CUST_ID);
                using(var r = cmd.ExecuteReader())
                {
                    _ddexReportInfo = new List<DdexReportInfo>();
                    while (r.Read())
                    {
                        var ddexReportInfo = new DdexReportInfo();
                        ReadDdexReportInfoMain(r, ddexReportInfo);
                        _ddexReportInfo.Add(ddexReportInfo);
                    }
                }
            });

            Helpers.RunSqlOperationMs(cmd =>
            {
                cmd.CommandText = @"
                    select 
                          t2.DdexReportId   as DdexReportId
	                    , t1.RegId			as RegId
	                    , t1.rgStatus		as RegStatus
	                    , t6.Name			as RegStatusName
	                    , t1.PeriodId		as PeriodId
	                    , t2.ExchangeRate	as ExchangeRate
	                    , t5.PaidId			as PaidId
	                    , t5.NumberInvoice	as NumberInvoice
	                    , t5.GoalInvoice	as GoalInvoice
	                    , t5.DateInvoice	as DateInvoice
	                    , t5.Amount			as AmountReceivedTotal
	                    , t4.Amount			as AmountReceivedPeriod
                    from Register t1
	                    join RegisterCCID			t2 on t1.RegId = t2.RegId
	                    join PaidPeriod				t3 on t1.PeriodId = t3.PeriodId
	                    left join MoneyPeriodLink	t4 on t3.periodId = t4.periodId
	                    left join MoneyReceived		t5 on t4.paidId = t5.paidId
	                    join RegisterStatus			t6 on t1.rgStatus = t6.codeI
                    where t1.CustId = @custId
                ";
                cmd.Parameters.AddWithValue("@custId", GOOGLE_CUST_ID);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var ddexReportId = r.GetInt32(0);
                        var ddexReportInfo = _ddexReportInfo.SingleOrDefault(x => x.DdexReportId == ddexReportId);
                        if(ddexReportInfo == null)
                        {
                            continue;
                        }

                        ReadDdexReportInfoDetails(r, ddexReportInfo);
                    }
                }
            });



            FillLvReports();
            _hasData = true;
        }

        private bool CheckFilter(DdexReportInfo ddexReportInfo)
        {
            if( cbFilterStatus.SelectedIndex == 0 
                && ddexReportInfo.DistributionStatusName == "Виконано" 
            )
                return false;
            else if( cbFilterStatus.SelectedIndex == 1
                && ddexReportInfo.DistributionStatusName != "Виконано" 
            )
                return false;
            else if( cbFilterService.SelectedIndex > 0
                && ddexReportInfo.ServiceName != (string)cbFilterService.SelectedItem
            )
                return false;
            else if( cbFilterYear.SelectedIndex > 0
                && ddexReportInfo.Year.ToString() != (string)cbFilterYear.SelectedItem
            )
                return false;
            else if( cbFilterQuarter.SelectedIndex > 0
                && ddexReportInfo.Quarter.ToString() != (string)cbFilterQuarter.SelectedItem
            )
                return false;
            else
                return true;
 
        }

        private void FillLvReports()
        {
            if(_ddexReportInfo == null)
            {
                return;
            }

            lvReports.Items.Clear();
            _ddexReportInfo.ForEach(x =>
            {
                if (CheckFilter(x))
                {
                    var item = lvReports.Items.Add(x.ServiceName);
                    item.SubItems.Add(x.Year.ToString());
                    item.SubItems.Add(x.Quarter.ToString());
                    item.SubItems.Add(x.DistributionStatusName ?? "Не розпочато");
                    item.Tag = x;
                }
            });

            FillDetails();
        }

        private void FillDetails()
        {
            if(lvReports.SelectedItems.Count == 0)
            {
                panelReportDetails.Visible = false;
            }
            else
            {
                panelReportDetails.Visible = true;
                var reportInfo = (DdexReportInfo)lvReports.SelectedItems[0].Tag;
                tbRegIdOld               .Text  = reportInfo.RegId                  == null ? "" : reportInfo.RegId                 .ToString();
	            tbPeriodIdOld            .Text  = reportInfo.PeriodId               == null ? "" : reportInfo.PeriodId              .ToString();
	            tbExchangeRateOld        .Text  = reportInfo.ExchangeRate           == null ? "" : reportInfo.ExchangeRate          .ToString();
	            tbPaidIdOld              .Text  = reportInfo.PaidId                 == null ? "" : reportInfo.PaidId                .ToString();
                tbNumberInvoiceOld       .Text  = reportInfo.NumberInvoice          == null ? "" : reportInfo.NumberInvoice         .ToString();
	            tbGoalInvoiceOld         .Text  = reportInfo.GoalInvoice            == null ? "" : reportInfo.GoalInvoice           .ToString();
	            tbDateInvoiceOld         .Text  = reportInfo.DateInvoice            == null ? "" : reportInfo.DateInvoice           .ToString();
	            tbAmountReceivedTotalOld .Text  = reportInfo.AmountReceivedTotal    == null ? "" : reportInfo.AmountReceivedTotal   .ToString();
                tbAmountReceivedPeriodOld.Text  = reportInfo.AmountReceivedPeriod   == null ? "" : reportInfo.AmountReceivedPeriod  .ToString();

                tbExchangeRateNew           .Text  = tbExchangeRateOld.Text        ;
	            tbPaidIdNew                 .Text  = tbPaidIdOld.Text              ;
                tbNumberInvoiceNew          .Text  = tbNumberInvoiceOld.Text       ;
	            tbGoalInvoiceNew            .Text  = tbGoalInvoiceOld.Text         ;
	            tbDateInvoiceNew            .Text  = tbDateInvoiceOld.Text         ;
	            tbAmountReceivedTotalNew    .Text  = tbAmountReceivedTotalOld.Text ;
                tbAmountReceivedPeriodNew   .Text  = tbAmountReceivedPeriodOld.Text;  
            }

            UpdateControls();
            
        }

        private void UpdateControls()
        {
            if(lvReports.SelectedItems.Count == 0)
            {
                panelReportDetails.Visible = false;
                return;
            }

            var reportInfo = (DdexReportInfo)lvReports.SelectedItems[0].Tag;
            
            panelReportDetails.Visible = true;

            chkCreateGooglePaiment.Enabled = reportInfo.PaidId == null;
            if(reportInfo.PaidId != null) chkCreateGooglePaiment.Checked = false;

            radioBindGooglePayment.Enabled   = chkCreateGooglePaiment.Checked;
            radioCreateGooglePayment.Enabled = chkCreateGooglePaiment.Checked;

            if (reportInfo.PaidId != null || !chkCreateGooglePaiment.Checked)
            {
                tbPaidIdNew.Visible                 = false;
                tbNumberInvoiceNew.Visible          = false;
                tbGoalInvoiceNew.Visible            = false;
                tbDateInvoiceNew.Visible            = false;
                tbAmountReceivedTotalNew.Visible    = false;
                tbAmountReceivedPeriodNew.Visible   = false;
            }
            else
            {
                tbPaidIdNew.Visible                 = radioBindGooglePayment  .Checked;
                tbNumberInvoiceNew.Visible          = radioCreateGooglePayment.Checked;
                tbGoalInvoiceNew.Visible            = radioCreateGooglePayment.Checked;
                tbDateInvoiceNew.Visible            = radioCreateGooglePayment.Checked;
                tbAmountReceivedTotalNew.Visible    = radioCreateGooglePayment.Checked;
                tbAmountReceivedPeriodNew.Visible   = true;
            }

        }

        private bool ApplyNewData(DdexReportInfo reportInfo)
        {
            // КУРС ОБМІНУ
            decimal exchangeRate = 0;
            if(!decimal.TryParse(tbExchangeRateNew.Text, out exchangeRate))
            {
                ShowError("Не вірний курс обміну");
                return false;
            }
            reportInfo.ExchangeRate = exchangeRate;

            // ІНФОРМАЦІЮ ДЛЯ ПЛАТЕЖУ ГУГЛ НЕ СТВОРЮЄМО
            if(!chkCreateGooglePaiment.Checked)
            {
                return true;
            }

            // ІНФОРМАЦІЮ ДЛЯ ПЛАТЕЖУ ГУГЛ ПОВЯЗУЄМО З ПЛАТЕЖОМ В БД
            if(radioBindGooglePayment.Checked)
            {
                var paidId = 0;
                if(!int.TryParse(tbPaidIdNew.Text, out paidId))
                {
                    ShowError("Не вірний формат значення для коду платежу від ГУГЛ");
                    return false;
                }

                var res = true;
                Helpers.RunSqlOperationMs(cmd =>
                {
                    cmd.CommandText = "select null from MoneyReceived where PaidId = @paidId and CustId = @custId";
                    cmd.Parameters.AddWithValue("@paidId", paidId);
                    cmd.Parameters.AddWithValue("@custId", GOOGLE_CUST_ID);
                    using(var r = cmd.ExecuteReader())
                    {
                        if (!r.HasRows)
                        {
                            res = false;
                        }
                    }
                });
                if(!res)
                {
                    ShowError("Платежу від ГУГЛ із введеним кодом не існує в БД СМАРТ");
                    return false;
                }
                reportInfo.PaidId = paidId;
            }
            // ІНФОРМАЦІЮ ДЛЯ ПЛАТЕЖУ ГУГЛ СТВОРЮЄМО НОВУ
            else
            {
                //  Номер платежу
                if(string.IsNullOrEmpty(tbNumberInvoiceNew.Text))
                {
                    ShowError("Не вказано номер платежу від ГУГЛ");
                    return false;
                }
                reportInfo.NumberInvoice = tbNumberInvoiceNew.Text;

                //  Призначення
                if(string.IsNullOrEmpty(tbGoalInvoiceNew.Text))
                {
                    ShowError("Не вказано призначення платежу від ГУГЛ");
                    return false;
                }
                reportInfo.GoalInvoice = tbGoalInvoiceNew.Text;

                //  Дата платежу
                DateTime dateInvoice = DateTime.Now;
                if(!DateTime.TryParse(tbDateInvoiceNew.Text, out dateInvoice))
                {
                    ShowError("Не вірна дата платежу від ГУГЛ");
                    return false;
                }
                reportInfo.DateInvoice = dateInvoice;

                //  Загальна сума
                decimal amountReceivedTotal = 0;
                if(!decimal.TryParse(tbAmountReceivedTotalNew.Text, out amountReceivedTotal))
                {
                    ShowError("Не вірна сума платежу від ГУГЛ");
                    return false;
                }
                reportInfo.AmountReceivedTotal = amountReceivedTotal;
            }

            // ІНФОРМАЦІЯ ПРО СУМУ ПЛАТЕЖУ ДЛЯ ЗВІТУ
            decimal amountReceivedPeriod = 0;
            if(!decimal.TryParse(tbAmountReceivedPeriodNew.Text, out amountReceivedPeriod))
            {
                ShowError("Не вірна сума платежу від ГУГЛ для звіту");
                return false;
            }
            reportInfo.AmountReceivedPeriod = amountReceivedPeriod;

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDestribute_Click(object sender, EventArgs e)
        {
            var reportInfo = (DdexReportInfo)lvReports.SelectedItems[0].Tag;

            if(!ApplyNewData(reportInfo))
            {
                return;
            }
            
            var form = new FormDistributionRunner(reportInfo, chkCreateGooglePaiment.Checked, radioCreateGooglePayment.Checked);
            form.ShowDialog();

            _hasData = false;
            ReadData();
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDetails();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillLvReports();
        }

        private void chkCreateGooglePaiment_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioBindGooglePayment_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioCreateGooglePayment_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }
    }
}
