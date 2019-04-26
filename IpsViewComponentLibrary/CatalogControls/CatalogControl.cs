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
        public EventHandler command;
        //public int CustomerId { get; set; }
        public delegate int ShowCustomerId();
        private CatalogPresenter _catalogPresenter;
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        private List<CatalogFile> _files;
        public CatalogControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            if (!IsDesignMode)
                _catalogPresenter = new CatalogPresenter();

            Load += CatalogControl_Load;

            //ShowCustomerId id = new ShowCustomerId(com.ShowCustId);
            //CustomerId = id();
        }

        private void CatalogControl_Load(object sender, EventArgs e)
        {
            bsGridData.DataSource = FillGridData();
        }


        /// <summary>
        /// show files into grid
        /// </summary>
        private List<CatalogFile> FillGridData()
        {
            //return _catalogPresenter.GetFileList(CustId);
            _files = new List<CatalogFile> {
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
            return _files;
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
                        //CustId = CustId,
                        FileName = fileExel.SafeFileName,
                    };
                    _catalogPresenter.UploadCatalogFile(catalogFile, fileExel.FileName);
                }
            }
        }
        
        // some method

        private void gridCatalogFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            //command.Invoke(sender, e);
            //var row = e.Row.DataBoundItem as T;
            switch (e.Column.FieldName)
            {
                case "infoBtn":
                    CatalogFile selected = _files[gridCatalogFiles.CurrentRow.Index];
                    CatalogDetailForm form = new CatalogDetailForm(selected);
                    form.Text = selected.FileName;
                    form.Show();
                    break;
                case "editBtn":
                    CatalogFile commentedFile = _files[gridCatalogFiles.CurrentRow.Index];
                    ChangeComment comment = new ChangeComment(commentedFile.Comment);
                    comment.Text = commentedFile.FileName;
                    comment.Show();
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

        private void gridCatalogFiles_DoubleClick(object sender, EventArgs e)
        {
            CatalogFile selected = _files[gridCatalogFiles.CurrentRow.Index];
            CatalogDetailForm form = new CatalogDetailForm(selected);
            form.Text = selected.FileName;
            form.Show();
        }
    }
}
