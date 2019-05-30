using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerAnketaPhisControl : UserControl, IAnketaControls
    {
        public event EventHandler<bool> SaveClick;
        public event EventHandler CancelClick;

        public PartnerAnketaPhisControl()
        {
            InitializeComponent();

            ctrlTabNavigationExpanded.SetDefaultState(pageView, FLoadType.Create);
            ctrlTabNavigationExpanded.SaveClick += Save;
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
            ctrlBankAccount.DataSource = customer?.BankAccount.FirstOrDefault();

            // договір
            ctrlAgreement.AgreementDataSource = customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();
            // умови договору
            ctrlConditions.AgreementAddPartnerDataSource = customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();
            bsPartner.DataSource = customer.Partner;
        }

        private void Save(object sender, bool e)
        {
            SaveClick?.Invoke(sender, e);
        }
    }
}
