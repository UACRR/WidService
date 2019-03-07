using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerCabinetAnketaJurControl : UserControl, IAnketaControls
    {
        public event EventHandler<bool> SaveClick;

        public PartnerCabinetAnketaJurControl()
        {
            InitializeComponent();
        }

        public void BeginBindings(Customer customer)
        {
            var dict = IpsGlobal.AnketaDictionaties;
            ctrlClientName.SetDataSources(customer, dict);
            ctrlAddress.SetDataSources(customer);
            ctrlManagers.SetDataSources(customer);
            ctrlBankAccount.DataSource = customer.BankAccount;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // some code
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClick?.Invoke(sender, false);
        }
    }
}
