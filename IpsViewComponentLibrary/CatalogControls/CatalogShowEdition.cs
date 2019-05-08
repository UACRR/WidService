using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.CatalogControls.Presenters;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.Export;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        private const string PerformSuccessMsg = "Виконано";
        private const string PerformErrorMsg = "Не виконано";
        private const string success = "Контроль виконано";
        private const string fail = "Контроль невиконано";

        private CatalogFile _catalogFile = null;
        private readonly ICatalogFileItemsHandler _catalogFileItemsHandler;
        protected bool IsDesingMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        public CatalogShowEdition()
        {
            InitializeComponent();
            if (!IsDesingMode)
                _catalogFileItemsHandler = new CatalogPresenter();
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

                btnPerform.Enabled = _catalogFile.Status == 1 || catalogFile.CountOk == 2;

                if (_catalogFile.PubCatalogItem.Any())
                {
                    bsPubCatalogItem.DataSource = _catalogFile.PubCatalogItem;
                    bsPubCatalogItem.ResetBindings(false);
                }
            }
        }

        // перевірка валідності. . .
        private void btnAuditItems_Click(object sender, EventArgs e)
        {
            var result = _catalogFileItemsHandler.AuditCatalogFileItems(_catalogFile);
            var boolResult = result != null;
            if (boolResult)
                DataSource = result;
            
            MessageShow.ShowInfoByResult(success, fail, boolResult);
        }

        private void btnGetExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.FileName = "exportFile";
                var spreadExporter = new GridViewSpreadExport(gridDetailInfo);
                spreadExporter.ExportFormat = SpreadExportFormat.Xlsx;
                dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SpreadExportRenderer renderer = new SpreadExportRenderer();
                    spreadExporter.RunExport(dialog.FileName, renderer);
                }
            }
        }

        private void btnPerform_Click(object sender, EventArgs e)
        {
            var result = _catalogFileItemsHandler.AttachCatalogFileItems(_catalogFile);
            var boolResult = result != null;
            if (boolResult)
                DataSource = result;
            MessageShow.ShowInfoByResult(PerformSuccessMsg, PerformErrorMsg, boolResult);
        }
    }
}
