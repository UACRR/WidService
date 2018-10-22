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
    public partial class PartnerAnketaJurControl : UserControl, IAnketaControls
    {
        public event EventHandler<bool> SaveClick;
        public PartnerAnketaJurControl()
        {
            InitializeComponent();
            ctrlTabNavigationExpanded.SetDefaultState(pageView, FLoadType.Create);
            ctrlTabNavigationExpanded.SaveClick += Save;
        }

        public void BeginBindings(Customer customer)
        {
            var dict = IpsGlobal.AnketaDictionaties;
            // представник
            ctrlClientName.SetDataSources(customer, dict);
            // контакти
            ctrlAddress.SetDataSources(customer, dict);
            // керівники
            ctrlManagers.SetDataSources(customer,dict);
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
