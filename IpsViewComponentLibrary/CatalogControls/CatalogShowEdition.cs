using System;
using System.Windows.Forms;
using Telerik.WinControls.Export;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        private GridViewSpreadExport spreadExporter;
        public CatalogShowEdition()
        {
            InitializeComponent();
            spreadExporter = new GridViewSpreadExport(gridDetailInfo);
        }

        private void btnGetExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "exportFile";
            spreadExporter.ExportFormat = SpreadExportFormat.Xlsx;
            dialog.Filter = "xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SpreadExportRenderer renderer = new SpreadExportRenderer();
                spreadExporter.RunExport(dialog.FileName, renderer);
            }
        }
    }
}
