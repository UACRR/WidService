using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class ReportsControl : UserControl
    {
        private Customer _data;
        public ReportsControl()
        {
            InitializeComponent();
        }

        public void SetData(Customer data)
        {
            _data = data;
        }


        public void SetDataSourceForLicAgrGrid(object obj)
        {
            if(obj == null) return;
            gvLicenseAgr.DataSource = obj;
        }

        private void gvLicenseAgr_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {

        }

        private void gvPeriods_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {

        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {

        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {

        }
    }
}
