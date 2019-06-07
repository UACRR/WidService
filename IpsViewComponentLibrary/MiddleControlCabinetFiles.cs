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
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetFiles : UserControl
    {
        private Customer _customer;
        private const string TitleMsg = "Підтвердження";
        private const string TextMsg = "Видалити обраний файл?";

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
            //SetGridDataSource(_customer?.FileCustomer ?? new ObservableListSource<FileCustomer>());
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            AddFileDialogForm fileAdd = new AddFileDialogForm();
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
                        if (MessageBox.Show(TextMsg, TitleMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var result = DeleteCurrentFile?.Invoke(rec.DocId);
                            if (result ?? false)
                                UpdateData?.Invoke();
                        }
                        break;
                }
        }
    }
}

