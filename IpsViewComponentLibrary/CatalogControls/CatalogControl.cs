using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.CatalogControls.Presenters;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogControl : UserControl
    {
        private const string ConfirmDeleteCatalogFile = "Ви дійсно хочете видалити файл?";
        private const string UploadFileCatalogSuccessMsg = "";
        private const string UploadFileCatalogErrorMsg = "";

        public EventHandler command;
        private readonly CatalogPresenter _catalogPresenter;
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        public int CustomerId { get; set; }

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
            UpdateDataGrid();
        }


        /// <summary>
        /// show files into grid
        /// </summary>
        private void UpdateDataGrid()
        {
            var list =_catalogPresenter.GetFileList(CustomerId);
            bsGridData.DataSource = list;
            bsGridData.ResetBindings(false);
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
                    var catalogFile = new CatalogFile
                    {
                        CustId = CustomerId,
                        FileName = fileExel.SafeFileName,
                    };
                    var result = _catalogPresenter.UploadCatalogFile(catalogFile, fileExel.FileName);
                    if (result)
                        UpdateDataGrid();
                    MessageShow.ShowInfoByResult(UploadFileCatalogSuccessMsg, UploadFileCatalogErrorMsg, result);
                }
            }
        }

        // some method

        private void gridCatalogFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            command.Invoke(sender, e);
            //var row = e.Row.DataBoundItem as T;
            switch (e.Column.FieldName)
            {
                case "editBtn":
                    //var catalogFile = _catalogPresenter.DeleteCatalogFile(row.custId, row.fileId);
                    break;

                case "deleteBtn":
                    if (MessageShow.ConfirmAction(ConfirmDeleteCatalogFile) == DialogResult.Yes)
                    {
                        //_catalogPresenter.DeleteCatalogFile(row.custId, row.fileId);
                    }
                    break;
            }
        }
    }
}
