using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.ConsumerDialogForms;
using Telerik.Charting;
using Telerik.Charting.Styles;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace TestControls
{
    public partial class GridTestForm : RadForm
    {
        public GridTestForm()
        {
            InitializeComponent();
            DataSet();
        }

        private void DataSet()
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            
            CreateProgReportBigRight reportBigRight =new CreateProgReportBigRight();
            reportBigRight.ShowDialog();
        }
    }
}

