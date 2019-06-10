using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerCabinetAnketaPhisControl : UserControl, IAnketaControls
    {
        public event EventHandler<bool> SaveClick;
        public event EventHandler CancelClick;

        public PartnerCabinetAnketaPhisControl()
        {
            InitializeComponent();
            ctrlSaveCancel.SaveClck += btnSave_Click;
            ctrlSaveCancel.CancelClick += btnCancel_Click;
        }

        public void BeginBindings(Customer customer)
        {
            var anketaPerson = customer.Person.AnketaPerson.SingleOrDefault();
            // представник
            ctrlPartnerName.DataSourceAnketa = anketaPerson;

            // контакти
            ctrlContacts.SetDataSource(customer);

            // паспортні дані
            ctrlInternalPassport.DataSource = anketaPerson;

            // банківські реквізити
            ctrlBankAccount.DataSource = customer.BankAccount.FirstOrDefault();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClick?.Invoke(sender, false);
        }
    }
}
