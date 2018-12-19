using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class ImportDBFControl : UserControl
    {
        private const string DefaultFileName = "Файл не вибраний";
        public ImportDBFControl()
        {
            InitializeComponent();
            Leave += Control_Leave;
            lblFileName.Text = DefaultFileName;
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            lblFileName.Text = DefaultFileName;
            // clear stream or selected file
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
                    fileName = fileDialog.FileName;
                    lblFileName.Text = fileDialog.SafeFileName;
                    var fileStream = fileDialog.OpenFile();
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        // some code
                    }
                    btnLoadFile.Enabled = true;
                }
            }
        }

        // завантажити файл
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            // some code
            
            // генерація структури-таблиці
            // ---

            // HTTP запит на виявлення дублів
            // ---

            // виведення результату
            var importParseResult = new ImportParseResultForm(lblFileName.Text)
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Maximized
            };
            // заглушка
            var list = new List<object>
            {
                new
                {
                    custId = 0,
                    mfo = "050640"
                },
                new
                {
                    custId = 1,
                    mfo = "969200"
                },
                new
                {
                    custId = 2,
                    mfo = "252100"
                },
                new
                {
                    custId = 3,
                    mfo = "955636"
                },
                new
                {
                    custId = 4,
                    mfo = "050640"
                },
                new
                {
                    custId = 5,
                    mfo = "695564"
                },

            };

            importParseResult.SetParsedList(list);
            if (importParseResult.ShowDialog() == DialogResult.OK)
            {
                // збереження таблиці в базі
            }
        }
    }
}
