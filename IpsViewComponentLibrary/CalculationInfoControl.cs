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
            //DateInvoice
        }

        public void SetData(Customer o)
        {
            if (o == null) return;

            _data = o;
            SetDataSource();
        }
        public void SetDictionary(AnketaDictionaties dict)
        {
            _dict = dict;
        }

        private void SetDataSource()
        {
            var dsourceUserMoney = _data?.Client?.MoneyReceived?.ToList();
            gvUserMoneys.DataSource = dsourceUserMoney;

            foreach (var item in gvUserMoneys.Rows)
            {
                item.Cells["DateInvoice"].Value =
                    Convert.ToDateTime(item.Cells["DateInvoice"].Value).ToShortDateString();
            }
        }

        private void gvUserMoneys_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvUserMoneys.Rows.Count == 0) return;
            //int id = gvUserMoneys.CurrentRow.Cells[0].Value;
            SetDataSourceLicenseAgr();
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvLicenseAgr.Rows.Count == 0) return;
            SetDataSourcePeriodsPayment();
        }

        private void gvLicenseAgr_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void gvPeriodsPayment_SelectionChanged(object sender, EventArgs e)
        {
            if (gvPeriodsPayment.Rows.Count == 0) return;
            SetDataSourcePayments();
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
        // Джерело для [періодів платежів]
        private void SetDataSourcePeriodsPayment()
        {
            gvLicenseAgr.DataSource = new object();
        }
        // Джерело для [платежів обраного періоду]
        private void SetDataSourcePayments()
        {

        }


    }
    public class GridLicAgr
    {
        public int Id { get; set; }
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
}
