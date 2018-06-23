using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class DistributionForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _cust;
        private object _distribMoneyDataSource;
        public DistributionForm()
        {
            InitializeComponent();
        }

        public DistributionForm(object undistrinbMoney, object licenseAgr, object source, Customer cust)
        {
            var undistribMoneyReceived = undistrinbMoney as MoneyReceived;
            var licenseAgreementParams = licenseAgr as LicenseAgrParam;
            _cust = cust;
            _distribMoneyDataSource = source;
            InitializeComponent();

            SetDataSources();
        }

        //встановити джерело для грідів
        private void SetDataSources()
        {
            DistributionMoneys();
        }

        //розподілити кошти по періодах
        private void DistributionMoneys()
        {
            gvDistributionPayment.DataSource = _distribMoneyDataSource;
        }

        private void btnCreateNewPeriod_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDistrib_Click(object sender, EventArgs e)
        {

        }
    }
}
