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
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.ImportDBF
{
    // ReSharper disable once InconsistentNaming
    public partial class ImportDBFControl : UserControl
    {
        private const string DefaultFileName = "Файл не вибраний";
        private InputFile inputFile = null;
        private DbfEngine dbfEngine = new DbfEngine();
        private List<ExternalPay> listPay;
        private IDBFPresenter _presenter;
        public ImportDBFControl()
        {
            InitializeComponent();
            Leave += Control_Leave;
            lblFileName.Text = DefaultFileName;
            _presenter = IpsGlobal.Instances[typeof(IDBFPresenter)] as IDBFPresenter;

            if (_presenter != null)
                bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            lblFileName.Text = DefaultFileName;
            // clear stream or selected file
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
                    lblFileName.Text = fileDialog.SafeFileName;
                    fileName = fileDialog.FileName;
                    inputFile = dbfEngine.ReadDbfFile(fileDialog.FileName);
                    btnLoadFile.Enabled = true && _presenter != null;
                    MessageBox.Show($"Файл {fileName} завантажено", "Завантаження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // завантажити файл
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (inputFile.FileId == 0)
                _presenter.CheckInputFile(inputFile);

            // виведення результату
            var importParseResult = new ImportParseResultForm(lblFileName.Text)
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Maximized
            };

            importParseResult.SetParsedList(inputFile.CheckParamPays.ToList());
            if (importParseResult.ShowDialog() == DialogResult.OK)
            {
                // збереження таблиці в базі
            }
        }

        private void gvUndistribPays_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.FieldName == "btnAttach")
                return;
            PaymentsAttach();
        }

        // прив'язати платіж до клієнта
        private void gvUndistribPays_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            // some code
            PaymentsAttach();
        }

        private void PaymentsAttach()
        {
            var paymentsAttach = new PaymentsAttachForm(new[] { "5256365", "Ресторанний комплекс на Дніпрі", "оплата за рік на рахунок №9919450654456" })
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            paymentsAttach.ShowDialog();
        }
    }
}
