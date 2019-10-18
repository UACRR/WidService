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
    public sealed partial class RightholderCatalogDetailWPFForm : RadForm
    {
        private const string ValidateSuccessMsg = "Контроль виконано!";
        private const string FileExportCompleteMsg = "Експорт файлу завершено!";

        private CatalogFile _catalogFile;

        private int Skip => (ctrlNavigatorPanel.CurrentPage - 1) * ctrlNavigatorPanel.PageSize;
        private int Take => ctrlNavigatorPanel.PageSize;

        private readonly ICatalogFileItemsHandler<PubCatalogItem> _catalogFileItemsHandler;

        public RightholderCatalogDetailWPFForm(CatalogFile file)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Text = file.FileName;

            _catalogFileItemsHandler = new RightholderCatalogPresenter();

            ctrlNavigatorPanel.CurrentPageChanged += NavigatorPanel_UpdateData;
            ctrlNavigatorPanel.PageSizeChanged += NavigatorPanel_PageSizeChanged;

            //gvPubCatalogItem.SubscribeToolTipTextNeeded();

            DataSource = file;
            Load += RightholderCatalogDetailForm_Load;
        }

        private void RightholderCatalogDetailForm_Load(object sender, EventArgs e)
        {
            GetPubCatalogItemFromDB();
        }

        private void NavigatorPanel_PageSizeChanged(object sender, EventArgs e)
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
            List<object[]> items = null;

            ctrlGridItemList.ClearData();
            GC.Collect();

            waitingBar.StartWaiting();
            await Task.Factory.StartNew(() =>
            {
                items = _catalogFileItemsHandler.GetCatalogItemList(_catalogFile.FileId);
            });
            waitingBar.StopWaiting();

            ctrlGridItemList.LoadData(items);
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
        private void btnAuditItems_Click(object sender, EventArgs e)
        {
            ExecSqlResponce<CatalogFile> result;

            waitingBar.StartWaiting();
            result = _catalogFileItemsHandler.ValidateCatalogFileItems(_catalogFile);
            waitingBar.StopWaiting();

            if (result == null)
                return;

            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            DataSource = result.Data;
            ctrlNavigatorPanel.CurrentPage = 1;

            UpdateEventHandlerUtility<PubCatalogItem>.InvokeEvent();
            MessageShow.ShowInfoByResult($"{ValidateSuccessMsg} {result.Message}", result.Message, boolResult);
        }

        // вивантажити в excel
        private void btnGetExcel_Click(object sender, EventArgs e)
        {
            var fileName = $"{_catalogFile.FileName.Replace(".xlsx", "")}_export";
            ctrlGridItemList.Export(fileName);
            //if (result)
            //    MessageShow.ShowInfo(FileExportCompleteMsg);
        }

        // запустити процес завантаження в бд
        private async void btnPerform_Click(object sender, EventArgs e)
        {
            ExecSqlResponce<CatalogFile> result = null;
            
            GC.Collect();

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
