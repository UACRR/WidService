using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.CatalogControls.Presenters;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogControl : UserControl
    {
        public EventHandler command;
        private CatalogPresenter _catalogPresenter;
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public CatalogControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
                _catalogPresenter = new CatalogPresenter();

            bsGridData.DataSource = FillGrid();
        }

        /// <summary>
        /// show files into grid
        /// </summary>
        private List<CatalogFile> FillGrid()
        {
            //return _catalogPresenter.GetFileList<CatalogFile>();
            return new List<CatalogFile> {
                new CatalogFile {
                    FileId = 666,
                    CustName = "CustName",
                    FileName = "fileName",
                    UserId = "userId",
                    Status = 0,
                    Comment = "comment",
                    CountZap = 1,
                    CountOk = 2,
                    CountErr = 3
                }
            };
        }

        /// <summary>
        /// choise exel file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileExel = new OpenFileDialog())
            {
                //open dialog
                fileExel.InitialDirectory = @"C:\";
                fileExel.Filter = "Excel files (.xlsx)|*.xlsx";
                fileExel.RestoreDirectory = true;

                //show file into grid
                if (fileExel.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void gridCatalogFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            command.Invoke(sender, e);
        }
    }
}
