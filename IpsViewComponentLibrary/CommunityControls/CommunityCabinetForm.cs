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
    public partial class CommunityCabinetForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public CommunityCabinetForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            ctrlTabNavigation.SetDefaultState(pageViewAnketa, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += CtrlTabNavigation_SaveClick;
            ctrlSearch.SetUsageGrid(gvViewAutors);

            SetBindings();
        }

        private void CtrlTabNavigation_SaveClick(object sender, EventArgs e)
        {
            // call save
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
            ctrlAddressJu.AddressDataMember = "JaAddress";
            ctrlAddressJu.CityDataMember = "JaCity";
            ctrlAddressJu.CountryDataMember = "JaCountry"; ;
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
            ctrlAddressLe.PostIndexDataMember = "LePostIndex";

            // банківські дані
            var bank = _customer.BankAccount.SingleOrDefault();
            ctrlBankAccount.DataSource = bank;

            // договір
            ctrlAgreement.AgreementDataSource = agreement;
        }
    }
}
