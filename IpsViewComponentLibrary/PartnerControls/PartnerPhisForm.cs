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
            ctrlTabNavigationExpanded.SetDefaultState(pageView, loadType);
            ctrlTabNavigationExpanded.SaveClick += SaveClick;

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

            // паспортні дані
            ctrlInternalPassport.DataSource = anketaPerson;

            // банківські реквізити
            bsBankAccount.DataSource = _customer?.BankAccount.FirstOrDefault();
            
            // договір
            ctrlAgreement.AgreementDataSource = _customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();
            // умови договору
            ctrlConditions.AgreementAddPartnerDataSource = _customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();

            #endregion
        }

        private void SaveClick(object sender, DialogResult e)
        {
            string name = ((Telerik.WinControls.RadElement) sender).Name;
            if (name == "btnSaveAccepted" && _customer != null)
            {
                // підтверджений представник
                _customer.Status = 2;
                _customer.AgreementMaster.SingleOrDefault().AgrStatus = 2;
                _customer.AgreementMaster.SingleOrDefault().AgreementAddPartner.SingleOrDefault().AgrStatus = 2;
                _customer.Person.AnketaPerson.SingleOrDefault().Status = 2;
            }
            DialogResult = e;
        }

        private void btnCopyFromLiveToReg_Click(object sender, EventArgs e)
        {
            ctrlAddressRegister.DdlCountry.SelectedValue = ctrlAddressLive.DdlCountry.SelectedValue;
            ctrlAddressRegister.DdlRegion.SelectedIndex = ctrlAddressLive.DdlRegion.SelectedIndex;
            ctrlAddressRegister.TxtCity.Select();
            ctrlAddressRegister.TxtCity.Text = ctrlAddressLive.TxtCity.Text;
            ctrlAddressRegister.TxtAddress.Select();
            ctrlAddressRegister.TxtAddress.Text = ctrlAddressLive.TxtAddress.Text;
        }

        private void btnCopyFromLiveToLett_Click(object sender, EventArgs e)
        {
            ctrlAddressLetter.DdlCountry.SelectedValue = ctrlAddressLive.DdlCountry.SelectedValue;
            ctrlAddressLetter.DdlRegion.SelectedIndex = ctrlAddressLive.DdlRegion.SelectedIndex;
            ctrlAddressLetter.TxtCity.Select();
            ctrlAddressLetter.TxtCity.Text = ctrlAddressLive.TxtCity.Text;
            ctrlAddressLetter.TxtAddress.Select();
            ctrlAddressLetter.TxtAddress.Text = ctrlAddressLive.TxtAddress.Text;
            ctrlAddressLetter.TxtPostIndex.Select();
        }

        private void btnCopyFromRegToLett_Click(object sender, EventArgs e)
        {
            ctrlAddressLetter.DdlCountry.SelectedValue = ctrlAddressRegister.DdlCountry.SelectedValue;
            ctrlAddressLetter.DdlRegion.SelectedIndex = ctrlAddressRegister.DdlRegion.SelectedIndex;
            ctrlAddressLetter.TxtCity.Select();
            ctrlAddressLetter.TxtCity.Text = ctrlAddressRegister.TxtCity.Text;
            ctrlAddressLetter.TxtAddress.Select();
            ctrlAddressLetter.TxtAddress.Text = ctrlAddressRegister.TxtAddress.Text;
            ctrlAddressLetter.TxtPostIndex.Select();
        }
    }
}
