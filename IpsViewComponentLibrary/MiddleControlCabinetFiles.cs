using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetFiles : UserControl
    {
        private Customer _customer;
        private ConsumerBigRightView _bigRightView;
        public MiddleControlCabinetFiles()
        {
            InitializeComponent();
        }

        public void SetAndUpdateData(Customer customer, ConsumerBigRightView bigRightView)
        {
            _customer = customer;
            _bigRightView = bigRightView;
            SetBigRightHeaderData();

            gvListFiles.DataSource = _customer?.FileCustomer ?? new ObservableListSource<FileCustomer>();
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
            AddFileDialogForm fileDialog = new AddFileDialogForm();
            fileDialog.ShowDialog();
        }
    }
}
