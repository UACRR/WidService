using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerAnketaJurControl : UserControl, IAnketaControls
    {
        public event EventHandler<bool> SaveClick;
        public event EventHandler CancelClick;

        public PartnerAnketaJurControl()
        {
            InitializeComponent();
            ctrlTabNavigationExpanded.SetDefaultState(pageView, FLoadType.Create);
            ctrlTabNavigationExpanded.SaveClick += Save;
        }

        public void BeginBindings(Customer customer)
        {
            // представник
            var anketa = customer?.Company?.AnketaCompany?.SingleOrDefault(rec => rec.Version == customer.AnkVersion);
            ctrlClientName.DataSource = anketa;
            // контакти
            ctrlAddress.SetDataSources(customer);
            // керівники
            ctrlManagers.SetDataSources(customer);
            // банківські реквізити
            ctrlBankAccount.DataSource = customer?.BankAccount.FirstOrDefault();
            // договір
            ctrlAgreement.AgreementDataSource = customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();
            // умови договору
            ctrlConditions.AgreementAddPartnerDataSource = customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();
        }

        private void Save(object sender, bool accept)
        {
            SaveClick?.Invoke(sender, accept);
        }
    }
}
