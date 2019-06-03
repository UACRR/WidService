using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.RightholderRegisterControls.Presenters;
using IpsViewComponentLibrary.Shared.Interfaces;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderRegisterControls
{
    public partial class RightholderRegisterDetailForm : RadForm
    {
        private CatalogFile _catalogFile;
        private readonly ICatalogFileItemsHandler _catalogFileItemsHandler;

        protected new bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public RightholderRegisterDetailForm(CatalogFile file)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            _catalogFile = file;

            if (!IsDesignMode)
                _catalogFileItemsHandler = new RightholderRegisterPresenter();

            btnPerform.Enabled = _catalogFile.Status == 1 || _catalogFile.CountOk == 2;
            Text = _catalogFile.FileName;

            bsCatalogFile.DataSource = _catalogFile;
            lblStatus.Text = IpsGlobal.ObjectRightDictionaries.catalogStatus
                .SingleOrDefault(rec => rec.CodeI == _catalogFile.Status)?.Name;

            bsRHCatalogItem.DataSource = file.RhcatalogItem;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void btnAuditItems_Click(object sender, EventArgs e)
        {
            var result = _catalogFileItemsHandler.ValidateCatalogFileItems(_catalogFile);
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
        }
    }
}
