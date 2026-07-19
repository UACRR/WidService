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
using static DdexInvoicing.UcRoyaltyDistribution;

namespace DdexInvoicing
{
    public partial class UcRoyaltyDistribution : UserControl
    {
        public const string MESSAGE_BOX_TITLE = "Розподіл і оплата";
        public class DdexReportInfo
        {
            public int          DdexReportId            { get; set; }
            public string       FileType                   { get; set; }
            public int          LicId                   { get; set; }
            public string       ServiceName             { get; set; }
            public int          Year                    { get; set; }
            public int          Quarter                 { get; set; }
            public int          Month                 { get; set; }
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
            { 1333,  "Гугл Реклама" },
            { 1339,  "Гугл Музика"  },
            { 1338,  "Гугл Преміум" },
            { 1830,  "Спотифай Реклама" },
            { 1831,  "Спотифай Підписка" },
            { 16107, "ТікТок" },
        };

        private const int GOOGLE_CUST_ID = 39556;


        private int _ddexReportId;
        private string _initialFileFullName;
        private string _reportTitle;

        private DdexReportInfo _ddexReportInfo;
        private bool _hasData = false;

        public UcRoyaltyDistribution()
        {
            InitializeComponent();
        }

        public void Init(int ddexReportId, string initialFileFullName)
        {
            _ddexReportId = ddexReportId;
            _initialFileFullName = initialFileFullName;

            try
            {
                ReadData();
            }
            catch
            {

            }
        }
        private void UcRoyaltyDistribution_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    select dbo.fnDdexReportTitle(t1.licId, t2.year, t2.quarter, t2.month)
                        from Ddex..DdexReport t1
	                        join Ddex..DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
                        where t1.Id = @ddexReportId
                ";
                cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                _reportTitle = (string)cmd.ExecuteScalar();
            });

            tbReportTitle.Text = _reportTitle;
            tbInputFile.Text = _initialFileFullName;

            chkCreatePaiment.Checked = false;
            try
            {
                UpdateControls();
            }
            catch { }
        }

        private void UpdateControls()
        {
            chkCreatePaiment.Enabled = _ddexReportInfo.PaidId == null;
            if(_ddexReportInfo.PaidId != null) chkCreatePaiment.Checked = false;

            radioBindPayment.Enabled   = chkCreatePaiment.Checked;
            radioCreatePayment.Enabled = chkCreatePaiment.Checked;

            if (_ddexReportInfo.PaidId != null || !chkCreatePaiment.Checked)
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
                tbPaidIdNew.Visible                 = radioBindPayment  .Checked;
                tbNumberInvoiceNew.Visible          = radioCreatePayment.Checked;
                tbGoalInvoiceNew.Visible            = radioCreatePayment.Checked;
                tbDateInvoiceNew.Visible            = radioCreatePayment.Checked;
                tbAmountReceivedTotalNew.Visible    = radioCreatePayment.Checked;
                tbAmountReceivedPeriodNew.Visible   = true;
            }

        }

        private void ReadDdexReportInfoMain(SqlDataReader r)
        {
            _ddexReportInfo.DdexReportId = r.GetInt32(0);
            _ddexReportInfo.FileType = r.GetString(1);
            _ddexReportInfo.LicId = r.GetInt32(2);
            _ddexReportInfo.ServiceName = _licName[_ddexReportInfo.LicId];
            _ddexReportInfo.Year = r.GetInt32(3);
            _ddexReportInfo.Quarter = r.GetInt32(4); 
            _ddexReportInfo.Month = r.GetInt32(5); 
            _ddexReportInfo.DistributionStatus = -1;
            _ddexReportInfo.DistributionStatusName = "Не передано в СМАРТ";
        }

        private void ReadDdexReportInfoDetails(SqlDataReader r)
        {
            var idx = 1;
            _ddexReportInfo.RegId                  = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++; 
	        _ddexReportInfo.DistributionStatus     = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++;
	        _ddexReportInfo.DistributionStatusName = r.IsDBNull(idx) ? null           : r.GetString(idx);  idx++;
            _ddexReportInfo.PeriodId               = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++;
	        _ddexReportInfo.ExchangeRate           = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx); idx++;
	        _ddexReportInfo.PaidId                 = r.IsDBNull(idx) ? (int?)null     : r.GetInt32(idx);   idx++;
	        _ddexReportInfo.NumberInvoice          = r.IsDBNull(idx) ? null           : r.GetString(idx);  idx++;
	        _ddexReportInfo.GoalInvoice            = r.IsDBNull(idx) ? null           : r.GetString(idx);  idx++;
            _ddexReportInfo.DateInvoice            = r.IsDBNull(idx) ? (DateTime?)null: r.GetDateTime(idx);idx++;
	        _ddexReportInfo.AmountReceivedTotal    = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx); idx++;
            _ddexReportInfo.AmountReceivedPeriod   = r.IsDBNull(idx) ? (decimal?)null : r.GetDecimal(idx); idx++;
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
                        , t1.FileType
	                    , t1.LicId
	                    , t2.Year
	                    , isnull(t2.Quarter, 0)
                        , isnull(t2.Month, 0)
                    from DdexReport t1
	                    join DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
                    where t1.Id = @ddexReportId
                ";
                cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    _ddexReportInfo = new DdexReportInfo();
                    ReadDdexReportInfoMain(r);
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
                    where t2.DdexReportId = @ddexReportId
                ";
                cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.HasRows)
                    {
                        r.Read();
                        ReadDdexReportInfoDetails(r);
                    }
                }
            });



            _hasData = true;
        }

        private void FillDetails()
        {
            {
                panelReportDetails.Visible = true;
                tbRegIdOld               .Text  = _ddexReportInfo.RegId                  == null ? "" : _ddexReportInfo.RegId                 .ToString();
	            tbPeriodIdOld            .Text  = _ddexReportInfo.PeriodId               == null ? "" : _ddexReportInfo.PeriodId              .ToString();
	            tbExchangeRateOld        .Text  = _ddexReportInfo.ExchangeRate           == null ? "" : _ddexReportInfo.ExchangeRate          .ToString();
	            tbPaidIdOld              .Text  = _ddexReportInfo.PaidId                 == null ? "" : _ddexReportInfo.PaidId                .ToString();
                tbNumberInvoiceOld       .Text  = _ddexReportInfo.NumberInvoice          == null ? "" : _ddexReportInfo.NumberInvoice         .ToString();
	            tbGoalInvoiceOld         .Text  = _ddexReportInfo.GoalInvoice            == null ? "" : _ddexReportInfo.GoalInvoice           .ToString();
	            tbDateInvoiceOld         .Text  = _ddexReportInfo.DateInvoice            == null ? "" : _ddexReportInfo.DateInvoice           .ToString();
	            tbAmountReceivedTotalOld .Text  = _ddexReportInfo.AmountReceivedTotal    == null ? "" : _ddexReportInfo.AmountReceivedTotal   .ToString();
                tbAmountReceivedPeriodOld.Text  = _ddexReportInfo.AmountReceivedPeriod   == null ? "" : _ddexReportInfo.AmountReceivedPeriod  .ToString();

                tbExchangeRateNew           .Text  = tbExchangeRateOld.Text        ;
	            tbPaidIdNew                 .Text  = tbPaidIdOld.Text              ;
                tbNumberInvoiceNew          .Text  = tbNumberInvoiceOld.Text       ;
	            tbGoalInvoiceNew            .Text  = tbGoalInvoiceOld.Text         ;
	            tbDateInvoiceNew            .Text  = tbDateInvoiceOld.Text         ;
	            tbAmountReceivedTotalNew    .Text  = tbAmountReceivedTotalOld.Text ;
                tbAmountReceivedPeriodNew   .Text  = tbAmountReceivedPeriodOld.Text;  
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
            if(!chkCreatePaiment.Checked)
            {
                return true;
            }

            // ІНФОРМАЦІЮ ДЛЯ ПЛАТЕЖУ ГУГЛ ПОВЯЗУЄМО З ПЛАТЕЖОМ В БД
            if(radioBindPayment.Checked)
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
            if(!ApplyNewData(_ddexReportInfo))
            {
                return;
            }
            
            var form = new FormDistributionRunner(_initialFileFullName, _ddexReportInfo, chkCreatePaiment.Checked, radioCreatePayment.Checked);
            form.ShowDialog();

            _hasData = false;
            ReadData();
        }

        private void chkCreatePaiment_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioBindPayment_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        private void radioCreatePayment_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }
    }
}
