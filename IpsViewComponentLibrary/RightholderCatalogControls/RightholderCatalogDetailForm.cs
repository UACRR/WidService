using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsCommonTypes.Enums;
using IpsCommonTypes.Wrappers;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.RightholderCatalogControls.Presenters;
using IpsViewComponentLibrary.Shared.Interfaces;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderCatalogControls
{
    public sealed partial class RightholderCatalogDetailForm : RadForm
    {
        private const string ValidateSuccessMsg = "Контроль виконано!";

        private CatalogFile _catalogFile;

        private int Skip => (ctrlNavigatorPanel.CurrentPage - 1) * ctrlNavigatorPanel.PageSize;
        private int Take => ctrlNavigatorPanel.PageSize;

        private readonly ICatalogFileItemsHandler<PubCatalogItem> _catalogFileItemsHandler;

        public RightholderCatalogDetailForm(CatalogFile file)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Text = file.FileName;

            _catalogFileItemsHandler = new RightholderCatalogPresenter();

            ctrlNavigatorPanel.CurrentPageChanged += NavigatorPanel_UpdateData;
            ctrlNavigatorPanel.PageSizeChanged += CtrlNavigatorPanel_PageSizeChanged;

            gvPubCatalogItem.SubscribeToolTipTextNeeded();

            DataSource = file;
            Load += RightholderCatalogDetailForm_Load;
        }

        private void RightholderCatalogDetailForm_Load(object sender, EventArgs e)
        {
            GetPubCatalogItemFromDB();
        }

        private void CtrlNavigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            // ReSharper disable once PossibleInvalidOperationException
            ctrlNavigatorPanel.TotalPages = _catalogFile.CountZap.Value / ctrlNavigatorPanel.PageSize;
            ctrlNavigatorPanel.CurrentPage = 1;
        }

        private void NavigatorPanel_UpdateData(object sender, EventArgs e)
        {
            GetPubCatalogItemFromDB();
        }

        private async void GetPubCatalogItemFromDB()
        {
            List<PubCatalogItem> items = null;

            waitingBar.StartWaiting();
            await Task.Factory.StartNew(() =>
            {
                items = _catalogFileItemsHandler.GetCatalogFileItems(_catalogFile.FileId, Skip, Take);
            });
            waitingBar.StopWaiting();

            bsPubCatalogItem.DataSource = items;
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

                if (_catalogFile.CountZap.HasValue)
                    ctrlNavigatorPanel.TotalPages = _catalogFile.CountZap.Value / ctrlNavigatorPanel.PageSize;
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
            ctrlNavigatorPanel.CurrentPage = 1;

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
                var spreadExporter = new GridViewSpreadExport(gvPubCatalogItem, SpreadExportFormat.Xlsx);

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
            waitingBar.StopWaiting();
            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            DataSource = result.Data;
            ctrlNavigatorPanel.CurrentPage = 1;
            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();

            MessageShow.ShowInfoByResult(result.Message, result.Message, boolResult);
        }
    }
}
