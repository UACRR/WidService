using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.CatalogControls.Presenters;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.Export;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        private CatalogFile _catalogFile = null;
        private readonly ICatalogFileItemsHandler _catalogFileItemsHandler;
        public CatalogShowEdition()
        {
            InitializeComponent();
            _catalogFileItemsHandler = new CatalogPresenter();
        }

        public object DataSource
        {
            get => bsCatalogFile.DataSource;
            set
            {
                if (!(value is CatalogFile catalogFile))
                    return;

                bsCatalogFile.DataSource = catalogFile;
                _catalogFile = catalogFile;

                if (catalogFile.PubCatalogItem.Any())
                    bsPubCatalogItem.DataSource = catalogFile.PubCatalogItem;
            }
        }

        // перевірка валідності. . .
        private void btnAuditItems_Click(object sender, EventArgs e)
        {
            var result = _catalogFileItemsHandler.AuditCatalogFileItems(_catalogFile);
            var boolResult = result != null;
            if (boolResult)
                DataSource = result;
            MessageShow.ShowInfoByResult("", "", boolResult);
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
            MessageShow.ShowInfoByResult("", "", boolResult);
        }
    }
}
