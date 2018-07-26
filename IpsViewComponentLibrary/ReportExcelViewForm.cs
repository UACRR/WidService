using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Excel = Microsoft.Office.Interop.Excel;

namespace IpsViewComponentLibrary
{
    public partial class ReportExcelViewForm : Telerik.WinControls.UI.RadForm
    {
        private readonly string _filePath;
        private List<RegisterItem> datasource = new List<RegisterItem>();

        public string TitleReport
        {
            get => lblTitle.Text.Remove(0,5);
            set => lblTitle.Text = "Звіт " + value;
        }


        public ReportExcelViewForm(List<RegisterItem> list)
        {
            InitializeComponent();

        }

        private void btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
