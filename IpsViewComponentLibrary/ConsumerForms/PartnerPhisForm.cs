using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class PartnerPhisForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public PartnerPhisForm(Customer customer, FLoadType loadType)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            _customer = customer;
            ctrlTabNavigation.SetDefaultState(pageView, loadType);

            #region BINDINGS

            var anketaPerson = _customer.Person.AnketaPerson.SingleOrDefault();
            // представник
            ctrlPartnerName.DataSourceAnketa = anketaPerson;

            // контакти
            ctrlContacts.DataSource = anketaPerson;
            // - проживання
            ctrlAddressLive.DataSource = anketaPerson;
            ctrlAddressLive.AddressDataMember = "ReAddress";
            ctrlAddressLive.CityDataMember = "ReCity";
            ctrlAddressLive.CountryDataMember = "ReCountry";
            ctrlAddressLive.RegionDataMember = "ReRegion";
            // - фактична
            ctrlAddressRegister.DataSource = anketaPerson;
            ctrlAddressRegister.AddressDataMember = "FaAddress";
            ctrlAddressRegister.CityDataMember = "FaCity";
            ctrlAddressRegister.CountryDataMember = "FaCountry";
            ctrlAddressRegister.RegionDataMember = "FaRegion";
            //- -поштова


            //поштова
            ctrlAddressLetter.DataSource = anketaPerson;
            ctrlAddressLetter.AddressDataMember = "LeAddress";
            ctrlAddressLetter.CityDataMember = "LeCity";
            ctrlAddressLetter.CountryDataMember = "LeCountry";
            ctrlAddressLetter.CountriesDataSource = IpsGlobal.AnketaDictionaties.country;
            ctrlAddressLetter.CountriesValueMember = "countryCode";
            ctrlAddressLetter.CountriesDisplayMember = "countryName";
            ctrlAddressLetter.RegionDataMember = "LeRegion";
            ctrlAddressLetter.RegionsDataSource = IpsGlobal.AnketaDictionaties.region;
            ctrlAddressLetter.RegionsValueMember = "codeI";
            ctrlAddressLetter.RegionsDisplayMember = "name";
            ctrlAddressLetter.PostIndexDataMember = "LePostIndex";

            //ctrlAddressLetter.DataSource = anketaPerson;
            //ctrlAddressLetter.AddressDataMember = "LeAddress";
            //ctrlAddressLetter.CityDataMember = "LeCity";
            //ctrlAddressLetter.CountryDataMember = "LeCountry";
            //ctrlAddressLetter.RegionDataMember = "LeRegion";
            //ctrlAddressLetter.PostIndexDataMember = "LePostIndex";


            // паспортні дані
            ctrlInternalPassport.DataSource = anketaPerson;

            // банківські реквізити
            bsBankAccount.DataSource = _customer?.BankAccount.FirstOrDefault();
            
            // договір
            ctrlAgreement.AgreementDataSource = _customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();
            // умови договору
            ctrlConditions.AgreementAddPartnerDataSource = _customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();

            #endregion

            SetFormType(loadType);
        }

        private void SetFormType(FLoadType loadType)
        {

        }
    }
}
