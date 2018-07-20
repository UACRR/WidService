using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using Telerik.WinControls;

namespace TestControls
{
    public partial class BindPayPeriod : UserControl
    {
        public BindPayPeriod()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 
        /// </summary>

        /// <summary>
        /// 
        /// </summary>
        private Customer _customer;
        public Customer Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                if (_customer == null)
                {
                    AllmoneyReceivedBindingSource.DataSource = typeof(MoneyReceived);
                    LicAgreementBindingSource.DataSource = typeof(LicenseAgrParam);
                    return;
                }

                BindAllSum();
                BindLicAgreements();

                SetGrid3DataSource();
                SetGrid4DataSource();

            }

        }

        private void BindLicAgreements()
        {
            var licAgr = _customer.Client.LicenseAgreement.Select(rec => rec.LicenseAgrParam.Single(item => item.LicVersion == rec.LicVersion));
            if (licAgr.Count() > 0)
                LicAgreementBindingSource.DataSource = licAgr;
            else
                LicAgreementBindingSource.DataSource = typeof(LicenseAgrParam);
        }

        private void BindAllSum()
        {
            var list = _customer.Client.MoneyReceived.Where(rec => rec.Amount > (rec.DestribAmount + rec.DestribPrepay));
            // radGridView1.RowCount = list.Count();
            if (list.Count() == 0)
            {
                AllmoneyReceivedBindingSource.DataSource = typeof(MoneyReceived);
            }
            else
                AllmoneyReceivedBindingSource.DataSource = list;
        }

        private void radGridView2_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            SetGrid3DataSource();
        }

        private void radGridView3_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            SetGrid4DataSource();
        }

        // Period
        private void SetGrid3DataSource()
        {
            if (radGridView2.CurrentRow != null)
            {
                var licItem = (LicenseAgrParam)radGridView2.CurrentRow.DataBoundItem;
                paidPeriodBindingSource.DataSource = licItem.Lic.PaidPeriod;
            }
            else
            {
                paidPeriodBindingSource.DataSource = typeof(PaidPeriod);
            }
        }
        //PeriodMoney
        private void SetGrid4DataSource()
        {
            if (radGridView3.CurrentRow != null)
            {
                var paydItem = (PaidPeriod)radGridView3.CurrentRow.DataBoundItem;

                PeriodMoneyReceivedBindingSource.DataSource = paydItem.MoneyPeriodLink;
            }
            else
            {
                PeriodMoneyReceivedBindingSource.DataSource = typeof(MoneyPeriodLink);
            }
        }


        private void MasterTemplate_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (e.Column.Name == "Debt")
            {
                var licAgreement = (LicenseAgrParam)e.Row.DataBoundItem;

                var debt = licAgreement.Lic.PaidPeriod.Sum(rec => rec.Amount - rec.Distribamount - rec.Undistribamount);
                e.CellElement.Text = Convert.ToDecimal(debt < 0 ? 0 : debt).ToString();
            }

        }
    }
}
