using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class ImportDBFControl : UserControl
    {
        public ImportDBFControl()
        {
            InitializeComponent();
        }

        // прив'язати платіж до клієнта
        private void gvUndistribPays_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            // some code
        }

        // обрати файл
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;

            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = @"C:\";
                fileDialog.Filter = "DBF files (*.dbf)|*.dbf";
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = fileDialog.SafeFileName;
                    lblFileName.Text = fileName;
                    btnLoadFile.Enabled = true;
                }
            }
        }

        // завантажити файл
        private void btnLoadFile_Click(object sender, EventArgs e)
        {

        }
    }
}
