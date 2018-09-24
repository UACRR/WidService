using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetPartnerForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event ReturnViewEventHandler<PartnerClientListView> GetPartnerClientList;
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        public CabinetPartnerForm(Customer customer)
        {
            InitializeComponent();
            Load += CabinetPartnerForm_Load;
            DialogResult = DialogResult.None;
            _customer = customer;

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

            ctrlPartnerClients.ClientName = anketaPerson;
            ctrlPartnerClients.GetFreeClientList += CtrlPartnerClients_GetFreeClientList;
        }

        private List<PartnerAllFreeClientsView> CtrlPartnerClients_GetFreeClientList(int custId)
        {
            return GetFreeClientList?.Invoke(custId);
        }

        private void CabinetPartnerForm_Load(object sender, EventArgs e)
        {
            var list = GetPartnerClientList?.Invoke(_customer.CustId);
            ctrlPartnerClients.SetData(list);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cancel changes
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSaveCustomer?.Invoke(_customer);
        }
    }
}
