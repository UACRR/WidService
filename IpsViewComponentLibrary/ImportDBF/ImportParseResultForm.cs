using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public void SetParsedList<T>(List<T> parsedList) where T: class
        {
            gvPaysFromFile.DataSource = parsedList;
        }

        private void btnAcceptData_Click(object sender, EventArgs e)
        {
            // some code 
            DialogResult = DialogResult.OK;
        }
    }
}
