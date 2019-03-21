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
using ipsmedserviceapp.Model.SQLViewsData;

namespace IpsViewComponentLibrary.ImportDBF
{
    // ReSharper disable once InconsistentNaming
    public partial class ImportDBFControl : UserControl
    {
        private const string DefaultFileName = "Файл не вибраний";
        private InputFile _inputFile;
        private List<vCustomer> _clientsList;
        private readonly DbfEngine _dbfEngine = new DbfEngine();
        private IDBFPresenter _presenter;
        private IUpdateProviderSmallRight _updateProviderSmallRight;
        private IUpdateProviderBigRight _updateProviderBigRight;


        public ImportDBFControl()
        {
            InitializeComponent();
            Leave += Control_Leave;
            lblFileName.Text = DefaultFileName;
        }

        // оновити дані
        private void Control_Paint(object sender, PaintEventArgs e)
        {
            if (_presenter == null) return;
            bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
            //show count Pays
            lblCountPays.Text = bindingExtrnPay.Count.ToString();
            if (_clientsList == null)
                _clientsList = _presenter.GetConsumers();
        }

        /// <summary>
        /// Gоказати результат після завантаження та перевірки файлу
        /// </summary>
        private void ShowFileResult()
        {
            if (_inputFile.FileId == 0)
                _presenter.CheckInputFile(_inputFile);

            // форма результату для підтвердження або сказування збереження даних
            var importParseResult = new ImportParseResultForm(lblFileName.Text)
            {
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Maximized
            };
            importParseResult.SetParsedList(_inputFile.CheckParamPays.ToList());

            if (importParseResult.ShowDialog() == DialogResult.OK)
            {
                // збереження таблиці в базі
                _presenter.SaveInputFile(_inputFile);
                bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
                //show count Pays
                lblCountPays.Text = bindingExtrnPay.Count.ToString();
            }
            else
            {
                // видалення непотрібних даних
                var result = _presenter.DeleteInputFile(_inputFile);
            }
        }

        /// <summary>
        /// Прив'язка платежу до клієнта
        /// </summary>
        /// <param name="gridViewCell"></param>
        private void PaymentsAttach(GridViewCellEventArgs gridViewCell)
        {
            var row = gridViewCell.Row.DataBoundItem as ExternalPay;
            var paymentsAttach = new PaymentsAttachForm(_clientsList, row)
            {
                StartPosition = FormStartPosition.CenterScreen
            };
            if (paymentsAttach.ShowDialog() == DialogResult.OK)
            {
                var result = _presenter.SaveLinkedPay(row);
                bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
                //show count Pays
                lblCountPays.Text = bindingExtrnPay.Count.ToString();
                _updateProviderSmallRight?.UpdateDataGrid();
                _updateProviderBigRight?.UpdateDataGrid();
            }
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
                    _inputFile = _dbfEngine.ReadDbfFile(fileDialog.FileName);
                    ShowFileResult();
                    //MessageBox.Show($"Файл {fileName} завантажено", "Завантаження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // прив'язати платіж до клієнта (double click)
        private void gvUndistribPays_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.FieldName == "btnAttach")
                return;
            PaymentsAttach(e);
        }

        // прив'язати платіж до клієнта (cell click)
        private void gvUndistribPays_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            PaymentsAttach(e);
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            lblFileName.Text = DefaultFileName;
            // clear stream or selected file
        }

        private void ImportDBFControl_Load(object sender, EventArgs e)
        {
            _presenter = IpsGlobal.Instances[typeof(IDBFPresenter)] as IDBFPresenter;
            _updateProviderSmallRight = IpsGlobal.Instances[typeof(IUpdateProviderSmallRight)] as IUpdateProviderSmallRight;
            _updateProviderBigRight = IpsGlobal.Instances[typeof(IUpdateProviderBigRight)] as IUpdateProviderBigRight;
        }
    }
}
