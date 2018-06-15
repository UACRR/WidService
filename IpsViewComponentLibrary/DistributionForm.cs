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
        private object _licDataSource;
        private object _distribMoneyDataSource;
        public DistributionForm()
        {
            InitializeComponent();
        }

        public DistributionForm(object dsUnDistrMoney, object distribMoney, Customer cust)
        {
            InitializeComponent();
            _licDataSource = dsUnDistrMoney;
            _distribMoneyDataSource = distribMoney;
            _cust = cust;
            

            SetDataSources();
        }

        //встановити джерело для грідів
        private void SetDataSources()
        {
            gvUserMoneys.DataSource = _licDataSource;
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
