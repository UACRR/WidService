using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class CalculationInfoControl : UserControl
    {
        private AnketaDictionaties _dict;
        private Customer _data;
        public CalculationInfoControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Встановлення даних
        /// </summary>
        /// <param name="o"></param>
        public void SetData(Customer o)
        {
            if (o == null) return;

            _data = o;
            SetDataSource();
        }
        /// <summary>
        /// Встановлення словника даних
        /// </summary>
        /// <param name="dict"></param>
        public void SetDictionary(AnketaDictionaties dict)
        {
            _dict = dict;
        }

        private void SetDataSource()
        {
            var dsourceUserMoney = _data?.Client?.MoneyReceived?.ToList();
            gvUserMoneys.DataSource = dsourceUserMoney;

        }

        // подія зміни обраного рядка [Нерозподілені грн користувача]
        private void gvUserMoneys_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvUserMoneys.Rows.Count == 0)
            {
                gvLicenseAgr.DataSource = null;
                return;
            }
            //int id = gvUserMoneys.CurrentRow.Cells[0].Value;
            SetDataSourceLicenseAgr();
            
        }

        // подія зміни обраного рядка [ліцензійних договорів (активні договора) ]
        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvLicenseAgr.Rows.Count == 0)
            {
                gvPeriodsPayment.DataSource = null;
                return;
            }

            SetDataSourcePeriodsPayment(Convert.ToInt32(e.CurrentRow.Cells["LicenseId"].Value));
        }

        // подія зміни обраного рядка [періодів платежів]
        private void gvPeriodsPayment_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvPeriodsPayment.Rows.Count == 0)
            {
                gvPayments.DataSource = null;
                return;
            }

            SetDataSourcePayments(idPeriod: Convert.ToInt32(e.CurrentRow.Cells["PeriodId"].Value), 
                                  idLic: Convert.ToInt32(gvLicenseAgr.CurrentRow.Cells["LicenseId"].Value));
        }
        

        // Джерело для [ліцензійних договорів]
        private void SetDataSourceLicenseAgr()
        {
            List<GridLicAgr> source = new List<GridLicAgr>();
            foreach (var item in _data.Client.LicenseAgreement)
            {
                var licenseParam = item?.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == item.LicVersion);
                source.Add(new GridLicAgr
                {
                    Id = item?.AgrId ?? default(int),
                    LicenseId = item?.LicId ?? default(int),
                    License = _dict?.agrLicenseType?.SingleOrDefault(rec => rec?.CodeI == item?.LicCode)?.Name,
                    Series = string.Empty,
                    AgrNumber = item?.Agr?.AgrNumber ?? string.Empty,
                    DateBegin = licenseParam?.DateBegin?.ToShortDateString() ?? string.Empty,
                    DateEnd = licenseParam?.DateEnd?.ToShortDateString() ?? string.Empty,
                    Amount = licenseParam?.MinAmount ?? default(decimal),
                    State = _dict?.agreementStatus?.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name ?? string.Empty,
                    PeriodPayment = _dict?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name ?? string.Empty,
                    Debt = ""
                });
            }
            gvLicenseAgr.DataSource = source;
        }

        public object DataSourceReturn
        {
            get => gvLicenseAgr.DataSource;
        }

        // Джерело для [періодів платежів]
        private void SetDataSourcePeriodsPayment(int idLic)
        {
            var period = _data.Client.LicenseAgreement.Where(recId => recId.LicId == idLic).Select(item => item.PaidPeriod).SingleOrDefault();
            if (period == null)
            {
                gvPeriodsPayment.DataSource = null;
                return;
            }

            List<GridPeriods> source = new List<GridPeriods>();
            foreach (var paidPeriod in period)
            {
                source.Add(new GridPeriods
                {
                    PeriodId = paidPeriod.PeriodId,
                    PeriodName = paidPeriod.PeriodName,
                    Status = paidPeriod.Status,
                    Amount = paidPeriod.Amount,
                    AmountBound = paidPeriod.Distribamount + paidPeriod.Undistribamount,
                    Distribamount = paidPeriod.Distribamount,
                    Undistribamount = paidPeriod.Undistribamount,
                    Arrears = paidPeriod.Amount - (paidPeriod.Distribamount + paidPeriod.Undistribamount)
                });
            }
            gvPeriodsPayment.DataSource = source;
        }

        // Джерело для [платежів обраного періоду]
        private void SetDataSourcePayments(int idPeriod = 0, int idLic = 0)
        {
            var period = _data.Client.LicenseAgreement.Where(rec => rec.LicId == idLic).Select(rec => rec.PaidPeriod).SingleOrDefault();
            var moneyPeriod = period?.Where(recId => recId.PeriodId == idPeriod).Select(rec => rec.MoneyPeriodLink).SingleOrDefault();
            List<GridPayments> source = new List<GridPayments>();
            foreach (var item in moneyPeriod?.Select(rec => rec.Paid)?.ToList())
            {
                if(item != null)
                    source.Add(new GridPayments
                    {
                        SelectPeriod = "Period 01",
                        PaidId = item.PaidId,
                        NumberInvoice = item.NumberInvoice,
                        DateInvoice = item.DateInvoice.ToShortDateString(),
                        State = "Стан",
                        Amount = item.Amount,
                        DestribAmount = item.DestribAmount,
                        GoalInvoice = item.GoalInvoice
                    });
            }

            gvPayments.DataSource = source;

        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            //TODO: переробити конструктор, другий параметр повинен створюватись з даних (тестова версія)
            DistributionForm distr = new DistributionForm(gvUserMoneys.DataSource, gvPeriodsPayment.DataSource, _data);
            distr.StartPosition = FormStartPosition.CenterScreen;
            distr.ShowDialog();
        }
    }

    public class GridLicAgr
    {
        public int Id { get; set; }
        public int LicenseId { get; set; }
        public string License { get; set; }
        public string Series { get; set; }
        public string AgrNumber { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
        public decimal Amount { get; set; }
        public string State { get; set; }
        public string PeriodPayment { get; set; }
        public string Debt { get; set; }
    }
    public class GridPeriods
    {
        //public int LicId { get; set; }

        public int PeriodId { get; set; }

        public string PeriodName { get; set; }
        public int Status { get; set; }
        public decimal Amount { get; set; }
        public decimal AmountBound { get; set; }
        public decimal Undistribamount { get; set; }
        public decimal Distribamount { get; set; }
        public decimal Arrears { get; set; }
    }

    public class GridPayments
    {
        public int PaidId { get; set; }
        public string SelectPeriod { get; set; }
        public string State{ get; set; }
        public string DateInvoice { get; set; }
        public string NumberInvoice { get; set; }
        public string GoalInvoice { get; set; }
        public decimal Amount { get; set; }
        public decimal DestribAmount { get; set; }
    }
}
