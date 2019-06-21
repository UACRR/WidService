using System;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetFiles : UserControl
    {
        private const string TextMsg = "Видалити обраний файл?";
        private Customer _customer;

        public delegate void AddNewDocumentHandler(int custId, int typeDocument, string fileName, string comment);
        public event AddNewDocumentHandler AddNewFile;

        public delegate void ViewDocumentHandler(int custId, int typeDocument, string fileName);
        public event ViewDocumentHandler ViewCurrentFile;

        public event ActionByIdDelegate DeleteCurrentFile;
        public event EmptyEventHandler UpdateData;

        public MiddleControlCabinetFiles()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer)
        {
            _customer = customer;
            gvListFiles.DataSource = _customer?.FileCustomer;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var fileAdd = new AddFileDialogForm();
            if (fileAdd.ShowDialog() == DialogResult.OK)
            {
                AddNewFile?.Invoke(_customer.CustId, fileAdd.DocumentType, fileAdd.FileName, fileAdd.Comment);
                UpdateData?.Invoke();
            }
        }

        private void gvListFiles_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is FileCustomer rec)
                switch (e.Column.FieldName)
                {
                    case "viewBtn":
                        ViewCurrentFile?.Invoke(_customer.CustId, rec.DocType, rec.DocFile);
                        break;
                    case "deleteBtn":
                        if(MessageShow.ConfirmAction(TextMsg) == DialogResult.Yes)
                        {
                            var result = DeleteCurrentFile?.Invoke(rec.DocId);
                            UpdateData?.Invoke();
                        }
                        break;
                }
        }
    }
}

