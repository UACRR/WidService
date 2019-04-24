using System;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogShowEdition : UserControl
    {
        //Telerik.WinControls.UI.Export.PivotExportToExcelML exporter;
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
                    
                }
            }
        }
    }
}
