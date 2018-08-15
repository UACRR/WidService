using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetFiles : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;

        public delegate void AddNewDocumentHandler(int custId, int typeDocument, string fileName, string comment);
        public event AddNewDocumentHandler OnAddNewDocument;

        public delegate void ViewDocumentHandler(int custId, int typeDocument, string fileName);
        public event ViewDocumentHandler OnViewDocButtonClick;

        public MiddleControlCabinetFiles()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            SetGridDataSource(_customer?.FileCustomer ?? new ObservableListSource<FileCustomer>());
        }

        private void SetGridDataSource(ObservableListSource<FileCustomer> fileCust)
        {
            ObservableListSource<FilesDataSource> source = new ObservableListSource<FilesDataSource>();
            foreach (var fileCustomer in fileCust)
                source.Add(new FilesDataSource
                {
                    DocId = fileCustomer?.DocId ?? default(int),
                    DocTypeInt = fileCustomer?.DocType ?? default(int),
                    DocType = IpsGlobal.AnketaDictionaties?.fileType?.SingleOrDefault(rec => rec.CodeI == fileCustomer?.DocType)?.Name,
                    DocComment = fileCustomer?.DocComment,
                    DocFile = fileCustomer?.DocFile
                });
            gvListFiles.DataSource = source;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            AddFileDialogForm fileAdd = new AddFileDialogForm();
            if (fileAdd.ShowDialog() == DialogResult.OK)
            {
                OnAddNewDocument?.Invoke(_customer.CustId, fileAdd.DocumentType, fileAdd.FileName, fileAdd.Comment);
            }
        }

        private void gvListFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Row.DataBoundItem is FilesDataSource rec)
                OnViewDocButtonClick?.Invoke(_customer.CustId, rec.DocTypeInt, rec.DocFile);
        }
    }

    internal class FilesDataSource
    {
        public int DocId { get; set; }
        public int DocTypeInt { get; set; }
        public string DocType { get; set; }
        public string DocFile { get; set; }
        public string DocComment { get; set; }
    }
}

