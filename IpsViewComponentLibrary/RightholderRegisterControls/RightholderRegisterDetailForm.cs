using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Utilities;
using IpsCommonTypes.Enums;
using IpsCommonTypes.Wrappers;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.RightholderRegisterControls.Presenters;
using IpsViewComponentLibrary.Shared.Interfaces;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderRegisterControls
{
    public partial class RightholderRegisterDetailForm : RadForm
    {
        private const string ValidateSuccessMsg = "Контроль виконано!";

        private CatalogFile _catalogFile;
        private readonly ICatalogFileItemsHandler<RhcatalogItem> _catalogFileItemsHandler;

        protected new bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public RightholderRegisterDetailForm(CatalogFile file)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            if (!IsDesignMode)
                _catalogFileItemsHandler = new RightholderRegisterPresenter();

            UpdateDataSources(file);
            
            btnPerform.Enabled = _catalogFile.Status == 1;

            Text = _catalogFile.FileName;

            lblStatus.Text = IpsGlobal.ObjectRightDictionaries.catalogStatus
                .SingleOrDefault(rec => rec.CodeI == _catalogFile.Status)?.Name;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void UpdateDataSources(CatalogFile catalogFile)
        {
            _catalogFile = catalogFile;
            bsCatalogFile.DataSource = catalogFile;
            bsCatalogFile.ResetBindings(false);
            bsRHCatalogItem.DataSource = catalogFile?.RhcatalogItem;
            bsRHCatalogItem.ResetBindings(false);
        }

        // заупустити перевірку
        private async void btnAuditItems_Click(object sender, EventArgs e)
        {
            ExecSqlResponse<CatalogFile> result = null;
            waitingBar.StartWaiting();
            await Task.Factory.StartNew(() =>
            {
                result = _catalogFileItemsHandler.ValidateCatalogFileItems(_catalogFile);
            });
            waitingBar.StopWaiting();

            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

            MessageShow.ShowInfoByResult($"{ValidateSuccessMsg} {result.Message}", result.Message, boolResult);
            UpdateDataSources(result.Data);
            UpdateEventHandlerUtility<RhcatalogItem>.InvokeEvent();
            btnPerform.Enabled = _catalogFile.Status == 1;
        }

        // вивантажити в excel
        private async void btnGetExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName = $"{_catalogFile.FileName}_export";
                dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

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
            }
        }

        // запустити процес завантаження в бд
        private async void btnPerform_Click(object sender, EventArgs e)
        {
            ExecSqlResponse<CatalogFile> result = null;

            waitingBar.StartWaiting();
            await Task.Factory.StartNew(() =>
            {
                result = _catalogFileItemsHandler.ProcessCatalogFileItems(_catalogFile);
            });
            waitingBar.StopWaiting();

            var boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;
            
            UpdateDataSources(result.Data);
            UpdateEventHandlerUtility<RhcatalogItem>.InvokeEvent();
            MessageShow.ShowInfoByResult(result.Message, result.Message, boolResult);
        }
    }
}
