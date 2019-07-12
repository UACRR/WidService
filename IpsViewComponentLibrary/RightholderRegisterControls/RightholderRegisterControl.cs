using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.Model;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.RightholderRegisterControls.Presenters;
using IpsViewComponentLibrary.Shared.Forms;

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

            if (!IsDesignMode)
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
        private async void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (var fileExel = new OpenFileDialog())
            {
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
                    CatalogFile result = null;
                    waitingBar.StartWaiting();
                    await Task.Factory.StartNew(() =>
                    {
                        result = _presenter.UploadCatalogFile(catalogFile, fileExel.FileName);
                    });
                    waitingBar.StopWaiting();
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
                    LoadDetailForm(row);
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
            LoadDetailForm(row);
        }

        /// <summary>
        /// Завантажити та показати список елементів файлу
        /// </summary>
        /// <param name="file"></param>
        private void LoadDetailForm(CatalogFile file)
        {
            // todo: waibar for load
            var item = _presenter.GetFileWithRHCatalogItems((int)file.CustId, file.FileId);
            var form = new RightholderRegisterDetailForm(item);
            form.ShowDialog();
        }

        private void RightholderRegisterControl_Load(object sender, EventArgs e)
        {
            UpdateEventHandlerUtility<RhcatalogItem>.GetEventWrap().UpdateEventHandler += CatalogFileUpdateNeed_EventHandler;
            UpdateGridData();
        }

        private void CatalogFileUpdateNeed_EventHandler(object sender, RhcatalogItem e)
        {
            UpdateGridData();
            bsGridData.ResetBindings(false);
        }
    }
}
