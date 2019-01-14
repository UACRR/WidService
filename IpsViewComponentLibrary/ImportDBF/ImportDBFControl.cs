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
using Telerik.WinControls.UI;
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
        private readonly IDBFPresenter _presenter;
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
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = @"C:\";
                fileDialog.Filter = "DBF files (*.dbf)|*.dbf";
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = fileDialog.SafeFileName;
                    inputFile = dbfEngine.ReadDbfFile(fileDialog.FileName);
                    ShowFileResult();
                    //MessageBox.Show($"Файл {fileName} завантажено", "Завантаження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // показати результат завантаження
        private void ShowFileResult()
        {
            if (inputFile.FileId == 0)
                _presenter.CheckInputFile(inputFile);

            // форма результату
            var importParseResult = new ImportParseResultForm(lblFileName.Text)
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Maximized
            };
            importParseResult.SetParsedList(inputFile.CheckParamPays.ToList());

            if (importParseResult.ShowDialog() == DialogResult.OK)
            {
                // збереження таблиці в базі
                _presenter.SaveInputFile(inputFile);
                bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
            }
            else
            {
                // видалення непотрібних даних
            }
        }

        private void gvUndistribPays_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.FieldName == "btnAttach")
                return;
            PaymentsAttach(e);
        }

        // прив'язати платіж до клієнта
        private void gvUndistribPays_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            // some code
            PaymentsAttach(e);
        }

        private void PaymentsAttach(GridViewCellEventArgs gridViewCell)
        {
            var row = gridViewCell.Row.DataBoundItem as ExternalPay;
            var paymentsAttach = new PaymentsAttachForm(new[] { "5256365", "Ресторанний комплекс на Дніпрі", "оплата за рік на рахунок №9919450654456" })
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            paymentsAttach.ShowDialog();
        }
    }
}
