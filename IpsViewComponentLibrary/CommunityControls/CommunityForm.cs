using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public CommunityForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            DialogResult = DialogResult.None;
            ctrlTabNavigation.SetDefaultState(pageView, FLoadType.Create);
            ctrlContactPerson.UnsubscribePhoneVldt();
            ctrlClientName.SetLabelName("Назва спільноти: ");
            SetBindings();
        }

        private void SetBindings()
        {
            var anketaCompany = _customer.Company.AnketaCompany.SingleOrDefault();
            var agreement = _customer.Community.AgreementAddCommunity.SingleOrDefault();

            //спільнота
            ctrlClientName.DataSource = anketaCompany;
            var empl = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3)?.Empl;
            ctrlContactPerson.DataSource = empl;

            // - - адреса
            // юридична
            ctrlAddressJu.AnketaCompanyDataSource = anketaCompany;
            ctrlAddressJu.AddressDataMember = "JuAddress";
            ctrlAddressJu.CityDataMember = "JuCity";
            ctrlAddressJu.CountryDataMember = "JuCountry";;
            // фактична
            ctrlAddressFa.AnketaCompanyDataSource = anketaCompany;
            ctrlAddressFa.AddressDataMember = "FaAddress";
            ctrlAddressFa.CityDataMember = "FaCity";
            ctrlAddressFa.CountryDataMember = "FaCountry";
            // для листування
            ctrlAddressLe.AnketaCompanyDataSource = anketaCompany;
            ctrlAddressLe.AddressDataMember = "LeAddress";
            ctrlAddressLe.CityDataMember = "LeCity";
            ctrlAddressLe.CountryDataMember = "LeCountry";

            // банківські дані
            var bank = _customer.BankAccount.SingleOrDefault();
            ctrlBankAccount.DataSource = bank;

            // договір
            ctrlAgreement.AgreementDataSource = agreement;

        }

    }
}
