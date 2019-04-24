using System;
using System.Windows.Forms;
using Telerik.WinControls.UI.Export;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        PivotExportToExcelML exporter;
        //PivotExportToExcelML exporter = new PivotExportToExcelML(gridDetail);
        public CatalogShowEdition()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Export to excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog excel = new SaveFileDialog())
            {
                excel.Filter = "Excel ML|*xls";
                excel.Title = "Export to File";
                excel.ShowDialog();

                if (excel.FileName != "")
                {
                    exporter.RunExport(excel.FileName);
                    MessageBox.Show("Successfully exported to " + excel.FileName, "Information", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        System.Diagnostics.Process.Start(excel.FileName);
                    }
                    finally { }
                }
            }
        }
    }
}
