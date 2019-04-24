using System;
using System.ComponentModel;
using System.Windows.Forms;
using IpsViewComponentLibrary.CatalogControls.Presenters;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogControl : UserControl
    {
        private CatalogPresenter _catalogPresenter;
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public CatalogControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
                _catalogPresenter =new CatalogPresenter();

        }

        /// <summary>
        /// show files into grid
        /// </summary>
        private void DataGrid()
        {
            //download data
        }

        /// <summary>
        /// choise exel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadExl_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileExel = new OpenFileDialog())
            {
                //open dialog
                fileExel.InitialDirectory = @"C:\";
                fileExel.Filter = "Exсel files (.xlsx)|*.xlsx";
                fileExel.RestoreDirectory = true;

                //show file into grid
                if (fileExel.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }
    }
}
