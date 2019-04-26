using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.CatalogControls.Presenters;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.CatalogControls
{
    public partial class CatalogControl : UserControl
    {
        private const string ConfirmDeleteCatalogFile = "Ви дійсно хочете видалити файл?";
        private const string EditCommentSuccessMsg = "";
        private const string EditCommentErrorMsg = "";

        private const string DeleteCatalogFileSuccessMsg = "";
        private const string DeleteCatalogFileErrorMsg = "";

        private readonly CatalogPresenter _catalogPresenter;

        //public int CustomerId { get; set; }
        public int CustId { get; set; }

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
            UpdateGridData();
        }


        /// <summary>
        /// show files into grid
        /// </summary>
        private void UpdateGridData()
        {
            if (_catalogPresenter == null)
                return;

            var list = _catalogPresenter.GetFileList(CustId);
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
                        CustId = CustId,
                        FileName = fileExel.SafeFileName,
                    };
                    _catalogPresenter.UploadCatalogFile(catalogFile, fileExel.FileName);
                    UpdateGridData();
                }
            }
        }
        
        // some method

        private void gridCatalogFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as CatalogFile;
            switch (e.Column.FieldName)
            {
                case "infoBtn":
                    var form = new CatalogDetailForm(row);
                    form.ShowDialog();
                    break;
                case "editBtn":
                    var commentForm = new ChangeCommentForm(row);
                    if (commentForm.ShowDialog() == DialogResult.OK)
                    {
                        var result = _catalogPresenter.SaveCatalogFileComment(row);
                        MessageShow.ShowInfoByResult(EditCommentSuccessMsg, EditCommentErrorMsg, result);
                        if (result)
                            UpdateGridData();
                    }

                    break;

                case "deleteBtn":
                    if (MessageShow.ConfirmAction(ConfirmDeleteCatalogFile) == DialogResult.Yes)
                    {
                        var result = _catalogPresenter.DeleteCatalogFile((int)row.CustId, row.FileId);
                        MessageShow.ShowInfoByResult(DeleteCatalogFileSuccessMsg, DeleteCatalogFileErrorMsg, result);
                        if (result)
                            UpdateGridData();
                    }
                    break;
            }
        }

        private void gridCatalogFiles_DoubleClick(object sender, EventArgs e)
        {
            var row = gridCatalogFiles.CurrentRow.DataBoundItem as CatalogFile;
            var form = new CatalogDetailForm(row);
            form.ShowDialog();
        }
    }
}
