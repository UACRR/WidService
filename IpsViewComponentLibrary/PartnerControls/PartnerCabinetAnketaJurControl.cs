using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerCabinetAnketaJurControl : UserControl, IAnketaControls
    {
        public event EventHandler<bool> SaveClick;
        public event EventHandler CancelClick;

        public PartnerCabinetAnketaJurControl()
        {
            InitializeComponent();
            ctrlSaveCancel.SaveClck += btnSave_Click;
            ctrlSaveCancel.CancelClick += btnCancel_Click;
        }

        public void BeginBindings(Customer customer)
        {
            var anketa = customer.Company?.AnketaCompany?.SingleOrDefault(rec => rec.Version == customer.AnkVersion);
            ctrlClientName.DataSource = anketa;

            ctrlAddress.SetDataSources(customer);
            ctrlManagers.SetDataSources(customer);
            ctrlBankAccount.DataSource = customer.BankAccount;
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
