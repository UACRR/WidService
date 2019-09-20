using ipsFormsDesign.Model;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Utilities;
using IpsCommonTypes.Enums;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.Export;
using System.IO;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using IpsCommonTypes.Wrappers;
using IpsViewComponentLibrary.RightholderCatalogControls.Presenters;
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
                _catalogFileItemsHandler = new RightholderCatalogPresenter();
            ctrlNavigatorPanel.CurrentPageChanged += NavigatorPanel_UpdateData;
            ctrlNavigatorPanel.PageSizeChanged += CtrlNavigatorPanel_PageSizeChanged;
        }

        private void CtrlNavigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            ctrlNavigatorPanel.TotalPages = _pubCatalogItemList.Count / ctrlNavigatorPanel.PageSize;
            ctrlNavigatorPanel.CurrentPage = 1;
        }

        private void NavigatorPanel_UpdateData(object sender, EventArgs e)
        {
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

        // перевірка валідності
        private async void btnAuditItems_Click(object sender, EventArgs e)
        {
            ExecSqlResponce<CatalogFile> result = null;
            waitingBar.StartWaiting();
            await Task.Factory.StartNew(() =>
            {
                result = _catalogFileItemsHandler.ValidateCatalogFileItems(_catalogFile);
            });
            waitingBar.StopWaiting();
            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            DataSource = result.Data;
            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();
            MessageShow.ShowInfoByResult($"{ValidateSuccessMsg} {result.Message}", result.Message, boolResult);
        }

        // вивантажити в excel
        private async void btnGetExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName = $"{_catalogFile.FileName}_export";
                dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                bsPubCatalogItem.DataSource = _catalogFile.PubCatalogItem;
                var spreadExporter = new GridViewSpreadExport(gridDetailInfo, SpreadExportFormat.Xlsx);
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(dialog.FileName))
                        File.Delete(dialog.FileName);

                    waitingBar.StartWaiting();
                    string fileName = dialog.FileName;
                    await Task.Factory.StartNew(() =>
                    {
                        var renderer = new SpreadExportRenderer();
                        spreadExporter.RunExport(fileName, renderer);
                    });
                    waitingBar.StopWaiting();
                }

                int skip = (ctrlNavigatorPanel.CurrentPage - 1) * ctrlNavigatorPanel.PageSize;
                bsPubCatalogItem.DataSource = _catalogFile.PubCatalogItem.Skip(skip).Take(ctrlNavigatorPanel.PageSize);
                bsPubCatalogItem.ResetBindings(false);
            }
        }

        // запустити процес завантаження в бд
        private async void btnPerform_Click(object sender, EventArgs e)
        {
            ExecSqlResponce<CatalogFile> result = null;
            waitingBar.StartWaiting();
            await Task.Factory.StartNew(() =>
            {
                result = _catalogFileItemsHandler.ProcessCatalogFileItems(_catalogFile);
            });
            waitingBar.StartWaiting();
            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            DataSource = result.Data;
            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();
            MessageShow.ShowInfoByResult(result.Message, result.Message, boolResult);
        }
    }
}
