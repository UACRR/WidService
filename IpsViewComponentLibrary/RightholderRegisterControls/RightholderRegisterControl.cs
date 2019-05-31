using System;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.CatalogControls;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.RightholderRegisterControls.Presenters;

namespace IpsViewComponentLibrary.RightholderRegisterControls
{
    public partial class RightholderRegisterControl : UserControl
    {
        private const string ConfirmDeleteCatalogFile = "Ви дійсно хочете видалити файл?";
        private const string EditCommentSuccessMsg = "Коментар змінений!";
        private const string EditCommentErrorMsg = "Неможливо змінити коментар!";

        private const string LoadCatalogFileSuccessMsg = "Файл завантажено!";
        private const string LoadCatalogFileErrorMsg = "Неможливо завантажити файл!";
        private const string DeleteCatalogFileSuccessMsg = "Файл видалено!";
        private const string DeleteCatalogFileErrorMsg = "Неможливо видалити файл!";

        private readonly RightholderRegisterPresenter _presenter;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public RightholderRegisterControl()
        {
            InitializeComponent();

            if (!DesignMode)
                _presenter = new RightholderRegisterPresenter();
        }

        public int CustId { get; set; }

        /// <summary>
        /// show files into grid
        /// </summary>
        private void UpdateGridData()
        {
            if (_presenter == null)
                return;

            var list = _presenter.GetFileList(CustId);
            bsGridData.DataSource = list;
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
                // fileExel.InitialDirectory = @"C:\";
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
                    var result = _presenter.UploadCatalogFile(catalogFile, fileExel.FileName);
                    var boolResult = result != null;
                    MessageShow.ShowInfoByResult(LoadCatalogFileSuccessMsg, LoadCatalogFileErrorMsg, boolResult);
                    if (boolResult)
                        UpdateGridData();
                }
            }
        }

        private void gridCatalogFiles_CommandCellClick(object sender, GridViewCellEventArgs e)
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
                        var result = _presenter.SaveRightholderRegister(row);
                        MessageShow.ShowInfoByResult(EditCommentSuccessMsg, EditCommentErrorMsg, result);
                        if (result)
                            UpdateGridData();
                    }

                    break;

                case "deleteBtn":
                    if (MessageShow.ConfirmAction(ConfirmDeleteCatalogFile) == DialogResult.Yes)
                    {
                        var result = _presenter.DeleteCatalogFile((int)row.CustId, row.FileId);
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
