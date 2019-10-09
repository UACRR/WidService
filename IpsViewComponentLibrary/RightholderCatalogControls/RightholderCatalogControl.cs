using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Utilities;
using IpsCommonTypes.Enums;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.RightholderCatalogControls.Presenters;
using IpsViewComponentLibrary.Shared.Forms;
using IpsViewComponentLibrary.Utilities;

namespace IpsViewComponentLibrary.RightholderCatalogControls
{
    public partial class RightholderCatalogControl : UserControl
    {
        private const string ConfirmDeleteCatalogFile = "Ви дійсно хочете видалити файл?";
        private const string EditCommentSuccessMsg = "Коментар змінений!";
        private const string EditCommentErrorMsg = "Неможливо змінити коментар!";

        private const string LoadCatalogFileSuccessMsg = "Файл завантажено!";
        private const string LoadCatalogFileErrorMsg = "Неможливо завантажити файл!";
        private const string DeleteCatalogFileSuccessMsg = "Файл видалено!";
        private const string DeleteCatalogFileErrorMsg = "Неможливо видалити файл!";

        private readonly RightholderCatalogPresenter _catalogPresenter;
        private readonly DialogService _dialogService = new DialogService(); 

        //public int CustomerId { get; set; }
        public int CustId { get; set; }

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public RightholderCatalogControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            if (!IsDesignMode)
                _catalogPresenter = new RightholderCatalogPresenter();

            Load += CatalogControl_Load;
        }

        private void CatalogControl_Load(object sender, EventArgs e)
        {
            UpdateGridData();
            UpdateEventHandlerUtility<PubCatalogItem>.GetEventWrap().UpdateEventHandler += CatalogFileUpdateNeed_EventHandler;
        }

        private void CatalogFileUpdateNeed_EventHandler(object sender, PubCatalogItem e)
        {
            UpdateGridData();
            bsGridData.ResetBindings(false);
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
        }

        /// <summary>
        /// Обрати та завантажити exel каталог
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnLoadFile_Click(object sender, EventArgs e)
        {
            using (var fileExel = new OpenFileDialog())
            {
                fileExel.Filter = "Excel files (.xlsx)|*.xlsx";

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
                        result = _catalogPresenter.UploadCatalogFile(catalogFile, fileExel.FileName);
                    });
                    waitingBar.StopWaiting();
                    var boolResult = result != null;
                    MessageShow.ShowInfoByResult(LoadCatalogFileSuccessMsg, LoadCatalogFileErrorMsg, boolResult);
                    if (boolResult)
                        UpdateGridData();
                }
            }
            GC.Collect();
        }

        private async void gridCatalogFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as CatalogFile;
            switch (e.Column.FieldName)
            {
                case "infoBtn":
                    var commentForm = new ChangeCommentForm(row);
                    if (commentForm.ShowDialog() == DialogResult.OK)
                    {
                        var result = _catalogPresenter.SaveCatalogFileComment(row);
                        MessageShow.ShowInfoByResult(EditCommentSuccessMsg, EditCommentErrorMsg, result);
                        if (result)
                            UpdateGridData();
                    }
                    break;

                case "editBtn":
                    //CatalogFile file = null;

                    //waitingBar.StartWaiting();
                    //await Task.Factory.StartNew(() =>
                    //{
                    //    file = _catalogPresenter.GetCatalogFile(row.CustId ?? 0, row.FileId);
                    //});
                    //waitingBar.StopWaiting();

                    //if (file == null)
                    //{
                    //    _dialogService.ShowError("Помилка отримання каталога з бази даних!");
                    //}
                    //else
                    //{
                    //    var form = new RightholderCatalogDetailWPFForm(file);
                    //    form.ShowDialog();
                    //}

                    var form = new RightholderCatalogDetailWPFForm(row);
                    form.ShowDialog();

                    break;

                case "deleteBtn":
                    if (MessageShow.ConfirmAction(ConfirmDeleteCatalogFile) == DialogResult.Yes)
                    {
                        IpsCommonTypes.Wrappers.ExecSqlResponce result = null;
                        
                        waitingBar.StartWaiting();
                        await Task.Factory.StartNew(() => 
                        {
                            result = _catalogPresenter.DeleteCatalogFile((int)row.CustId, row.FileId);
                        });
                        waitingBar.StopWaiting();

                        bool boolResult = result.StatusCode == ExecSqlResponceStatus.Successed;

                        string successMsg = $"{DeleteCatalogFileSuccessMsg} \n{result.Message}";
                        string errorMsg = $"{DeleteCatalogFileErrorMsg} \n{result.Message}";

                        MessageShow.ShowInfoByResult(successMsg, errorMsg, boolResult);

                        if (boolResult)
                            UpdateGridData();
                    }
                    break;
            }
        }

        private void gridCatalogFiles_DoubleClick(object sender, EventArgs e)
        {
            var row = gridCatalogFiles.CurrentRow.DataBoundItem as CatalogFile;
            var form = new RightholderCatalogDetailWPFForm(row);
            form.ShowDialog();
            //var form = new RightholderCatalogDetailForm(row);
            //form.ShowDialog();
        }
    }
}
