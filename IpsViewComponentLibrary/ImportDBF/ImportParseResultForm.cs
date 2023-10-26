using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class ImportParseResultForm : RadForm
    {
        public ImportParseResultForm(string fileName)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            lblFileName.Text = fileName;
        }

        public void SetParsedList(List<CheckParamPays> parsedList)
        {
            gvPaysFromFile.DataSource = parsedList;

            if (parsedList.Any(rec => rec.InputStatus == 0))
            {
                parsedList = parsedList.Where(rec => rec.InputStatus == 1).ToList();
            }

            btnAcceptData.Enabled = parsedList.Any(rec => rec.InputStatus != 0);
        }

        private void btnAcceptData_Click(object sender, EventArgs e)
        {
            // some code 
            DialogResult = DialogResult.OK;
        }
    }
}
