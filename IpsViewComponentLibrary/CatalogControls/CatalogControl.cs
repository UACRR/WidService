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
            Dock = DockStyle.Fill;
            if (!IsDesignMode)
                _catalogPresenter = new CatalogPresenter();

            Load += CatalogControl_Load;
        }

        private void CatalogControl_Load(object sender, EventArgs e)
        {
            bsGridData.DataSource = FillGridData();
        }

        public int CustomerId { get; set; }

        /// <summary>
        /// show files into grid
        /// </summary>
        private List<CatalogFile> FillGridData()
        {
            //return _catalogPresenter.GetFileList(CustomerId);

            return new List<CatalogFile> {
                new CatalogFile {
                    FileId = 666,
                    CustName = "CustName",
                    FileName = "fileName",
                    CreateDate = DateTime.Now,
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
            using (var fileExel = new OpenFileDialog())
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

        // some method

        private void gridCatalogFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            command.Invoke(sender, e);
            switch (e.Column.FieldName)
            {
                case "editBtn":
                    break;

                case "deleteBtn":
                    break;
            }
        }
    }
}
