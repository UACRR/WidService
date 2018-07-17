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

        public MiddleControlCabinetFiles()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            SetBigRightHeaderData();
            SetGridDataSource(_customer?.FileCustomer ?? new ObservableListSource<FileCustomer>());
        }

        private void SetGridDataSource(ObservableListSource<FileCustomer> fileCust)
        {
            ObservableListSource<FilesDataSource> source = new ObservableListSource<FilesDataSource>();
            foreach (var fileCustomer in fileCust)
                source.Add(new FilesDataSource
                {
                    DocId = fileCustomer?.DocId ?? default(int),
                    DocType = IpsGlobal.AnketaDictionaties?.fileType?.SingleOrDefault(rec => rec.CodeI == fileCustomer?.DocType)?.Name,
                    DocComment = fileCustomer?.DocComment,
                    DocFile = fileCustomer?.DocFile
                });
            gvListFiles.DataSource = source;
        }

        private void SetBigRightHeaderData()
        {
            var head = _customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 1);
            var contactPerson = _customer.Company?.RelEmployee?.SingleOrDefault(cId => cId.PositionCode == 3);


            ctrlHeaderInfo.NameInfo = _bigRightView.Name;
            ctrlHeaderInfo.Edrpou = _bigRightView.Innokpo;
            ctrlHeaderInfo.PibContactPerson = contactPerson?.Empl?.FirstName + " " + contactPerson?.Empl?.LastName + " " + contactPerson?.Empl?.SurName;
            ctrlHeaderInfo.PhoneContactPerson = contactPerson?.Empl?.PhoneNumber;
            ctrlHeaderInfo.EmailContactPerson = contactPerson?.Empl?.Email;
            ctrlHeaderInfo.PibManager = head?.Empl?.FirstName + " " + head?.Empl?.LastName + " " + head?.Empl?.SurName;
            ctrlHeaderInfo.PhoneManager = head?.Empl?.PhoneNumber;
            ctrlHeaderInfo.EmailManager = head?.Empl?.Email;

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

        }
    }

    internal class FilesDataSource
    {
        public int DocId { get; set; }
        public string DocType { get; set; }
        public string DocFile { get; set; }
        public string DocComment { get; set; }
    }
}

