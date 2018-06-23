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
//    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class DistributionForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _cust;
        private object _distribMoneyDataSource;
        public DistributionForm()
        {
            InitializeComponent();
        }


        public DistributionForm(object undistrinbMoney, object licenseAgr, object periodsList, Customer cust)
        {
            InitializeComponent();

            bindingSource.DataSource = undistrinbMoney;
            bindingSourceAgreement.DataSource = licenseAgr;
            _cust = cust;
            var source = periodsList as List<GridPeriods>;
            gvDistributionPayment.DataSource = source;
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
            
        }

        private void btnCreateNewPeriod_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveDistrib_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
