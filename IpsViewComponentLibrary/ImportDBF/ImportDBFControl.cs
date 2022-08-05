using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Engines;
using ipsFormsDesign.Model.SQLViewsData;
using IpsViewComponentLibrary.ImportDBF.Presenters;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class ImportDBFControl : UserControl
    {
        private const string DefaultFileName = "Файл не вибраний";
        private InputFile _inputFile;
        private List<vCustomer> _clientsList;
        private readonly DbfEngine _dbfEngine = new DbfEngine();
        private readonly DBFPresenter _presenter;
        private IUpdateProviderSmallRight _updateProviderSmallRight;
        private IUpdateProviderBigRight _updateProviderBigRight;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public ImportDBFControl()
        {
            InitializeComponent();
            if (!IsDesignMode)
                _presenter = new DBFPresenter();
            Leave += Control_Leave;
            ctrlGridRowCount.RadGridViewDataSource = gvUndistribPays;
            lblFileName.Text = DefaultFileName;
        }

        public TypeRights TypeRights { get; set; }

        private bool CheckNullUpdateProvider => _updateProviderSmallRight != null || _updateProviderBigRight != null;

        // оновити дані
        private void Control_Paint(object sender, PaintEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (_presenter == null)
                return;

            bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
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
            var importParseResult = new ImportParseResultForm(lblFileName.Text);

            importParseResult.SetParsedList(_inputFile.CheckParamPays.ToList());

            if (importParseResult.ShowDialog() == DialogResult.OK)
            {
                // збереження таблиці в базі
                _presenter.SaveInputFile(_inputFile);
                bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
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
            if (!(gridViewCell.Row.DataBoundItem is ExternalPay row))
                return;

            var paymentsAttach = new PaymentsAttachForm(_clientsList, row);
            if (paymentsAttach.ShowDialog() == DialogResult.OK)
            {
                var result = _presenter.SaveLinkedPay(row);
                bindingExtrnPay.DataSource = _presenter.GetListUnlinkPays();
                _updateProviderSmallRight?.UpdateDataGrid();
                _updateProviderBigRight?.UpdateDataGrid();
            }
        }

        // обрати файл
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            using (var fileDialog = new OpenFileDialog())
            {
                //fileDialog.InitialDirectory = @"C:\";
                fileDialog.Filter = "DBF files (*.dbf)|*.dbf";
                //fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    lblFileName.Text = fileDialog.SafeFileName;
                    try
                    {
                        _inputFile = _dbfEngine.ReadDbfFile(fileDialog.FileName);
                        ShowFileResult();
                    }
                    catch( Exception ex )
                    {
                        MessageBox.Show(ex.Message, "Помилка завантаження", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
            }
        }

        // прив'язати платіж до клієнта (double click)
        private void gvUndistribPays_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName == "btnAttach")
                return;
            PaymentsAttach(e);
        }

        // прив'язати платіж до клієнта (cell click)
        private void gvUndistribPays_CommandCellClick(object sender, GridViewCellEventArgs e)
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
            LoadData();

            if (!CheckNullUpdateProvider && IpsGlobal.Instances.Any())
            {
                if (TypeRights == TypeRights.SmallRights)
                    _updateProviderSmallRight = IpsGlobal.Instances[typeof(IUpdateProviderSmallRight)] as IUpdateProviderSmallRight;
                else if (TypeRights == TypeRights.BigRights)
                    _updateProviderBigRight = IpsGlobal.Instances[typeof(IUpdateProviderBigRight)] as IUpdateProviderBigRight;
            }
        }

        private void gvUndistribPays_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }
    }
}
