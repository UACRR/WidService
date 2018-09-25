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
using ipsFormsDesign.Services;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetPartnerForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event ReturnViewEventHandler<PartnerClientListView> GetPartnerClientList;
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        public event SetPartnerEventHandler OnAddClientToPartner;
        public event SetPartnerEventHandler OnDetachClientInPartner;
        public event PartnerAgreementStatusChangeEventHandler ChangeStatusAgr;
        public event GetCustomerEventHandler UpdateCustomer;


        public CabinetPartnerForm(Customer customer)
        {
            InitializeComponent();
            Load += CabinetPartnerForm_Load;
            DialogResult = DialogResult.None;
            _customer = customer;

            
            BeginBinding();
            SubscribeEvents();
        }

        private void BeginBinding()
        {
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
            // статус договору
            var statusid = _customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault()?.AgrStatus;
            lblStatusName.Text = IpsGlobal.AnketaDictionaties.agreementStatus.SingleOrDefault(rec => rec.CodeI == statusid)?.Name;

            // умови договору
            ctrlConditions.AgreementAddPartnerDataSource = _customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();

            //найменування клієнта
            ctrlPartnerClients.ClientName = anketaPerson;
        }

        private void SubscribeEvents()
        {
            ctrlPartnerClients.GetFreeClientList += CtrlPartnerClients_GetFreeClientList;
            ctrlPartnerClients.OnAddClientToPartner += CtrlPartnerClients_OnAddClientToPartner;
            ctrlPartnerClients.OnDetachClientInPartner += CtrlPartnerClients_OnDetachClientInPartner;
            ctrlPartnerClients.UpdateData += CabinetPartnerForm_Load;
        }

        private bool CtrlPartnerClients_OnDetachClientInPartner(int clientId, int partnerId)
        {
            return OnDetachClientInPartner?.Invoke(clientId, partnerId) ?? false;
        }

        private bool CtrlPartnerClients_OnAddClientToPartner(int clientId, int partnerId)
        {
            return OnAddClientToPartner?.Invoke(clientId, partnerId) ?? false;
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

        // підтвердити
        private void btnAcceptAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeStatusAgr?.Invoke(_customer.CustId, CPartnerObjectStatus.Activate);
            if (result ?? false)
            {
                _customer = UpdateCustomer?.Invoke(_customer.CustId);
                BeginBinding();
            }
        }

        // закрити
        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeStatusAgr?.Invoke(_customer.CustId, CPartnerObjectStatus.Close);
            if (result ?? false)
            {
                _customer = UpdateCustomer?.Invoke(_customer.CustId);
                BeginBinding();
            }
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
