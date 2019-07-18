using ipsFormsDesign.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Utilities;
using IpsCommonTypes.Enums;
using IpsViewComponentLibrary.CatalogControls.Presenters;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.Export;
using System.IO;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Shared.Interfaces;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        private const string ValidateSuccessMsg = "Контроль виконано!";

        private CatalogFile _catalogFile = null;
        private ObservableListSource<PubCatalogItem> _pubCatalogItemList = new ObservableListSource<PubCatalogItem>();

        private readonly ICatalogFileItemsHandler _catalogFileItemsHandler;
        protected bool IsDesingMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        public CatalogShowEdition()
        {
            InitializeComponent();
            if (!IsDesingMode)
                _catalogFileItemsHandler = new CatalogPresenter();
            ctrlNavigatorPanel.CurrentPageChanged += NavigatorPanel_UpdateData;
            ctrlNavigatorPanel.PageSizeChanged += CtrlNavigatorPanel_PageSizeChanged; ;
        }

        private void CtrlNavigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            ctrlNavigatorPanel.TotalPages = _pubCatalogItemList.Count / ctrlNavigatorPanel.PageSize;
            ctrlNavigatorPanel.CurrentPage = 1;
        }

        private void NavigatorPanel_UpdateData(object sender, EventArgs e)
        {
            //UpdateGridData();
            int skip = (ctrlNavigatorPanel.CurrentPage - 1) * ctrlNavigatorPanel.PageSize;
            bsPubCatalogItem.DataSource = _catalogFile.PubCatalogItem.Skip(skip).Take(ctrlNavigatorPanel.PageSize);
            bsPubCatalogItem.ResetBindings(false);
        }

        public object DataSource
        {
            get => bsCatalogFile.DataSource;
            set
            {
                if (!(value is CatalogFile catalogFile))
                    return;

                _catalogFile = catalogFile;

                bsCatalogFile.DataSource = _catalogFile;
                bsCatalogFile.ResetBindings(false);

                btnPerform.Enabled = _catalogFile.Status == 1;

                if (_catalogFile.PubCatalogItem.Any())
                {
                    _pubCatalogItemList = _catalogFile.PubCatalogItem;
                    ctrlNavigatorPanel.TotalPages = _pubCatalogItemList.Count / ctrlNavigatorPanel.PageSize;
                    ctrlNavigatorPanel.CurrentPage = 1;
                }
            }
        }

        // перевірка валідності. . .
        private void btnAuditItems_Click(object sender, EventArgs e)
        {
            var result = _catalogFileItemsHandler.ValidateCatalogFileItems(_catalogFile);
            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            DataSource = result.Data;
            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();
            MessageShow.ShowInfoByResult($"{ValidateSuccessMsg} {result.Message}", result.Message, boolResult);
        }

        private void btnGetExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName = $"{_catalogFile.FileName}_export";
                var spreadExporter = new GridViewSpreadExport(gridDetailInfo, SpreadExportFormat.Xlsx);
                //spreadExporter.ExportFormat = SpreadExportFormat.Xlsx;
                
                dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(dialog.FileName))
                        File.Delete(dialog.FileName);

                    SpreadExportRenderer renderer = new SpreadExportRenderer();
                    spreadExporter.RunExport(dialog.FileName, renderer);
                }
            }
        }

        private void btnPerform_Click(object sender, EventArgs e)
        {
            var result = _catalogFileItemsHandler.ProcessCatalogFileItems(_catalogFile);
            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            DataSource = result.Data;
            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();
            MessageShow.ShowInfoByResult(result.Message, result.Message, boolResult);
        }
    }
}
