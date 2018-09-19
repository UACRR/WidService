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

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class PartnerPhisForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public PartnerPhisForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            ctrlTabNavigation.SetDefaultState(pageView);
            ctrlTabNavigation.OnSave += CtrlTabNavigation_OnSave;
            CancelButton = ctrlTabNavigation.CancelButton;

            #region BINDINGS

            var anketaPerson = _customer.AnketaPerson.SingleOrDefault();
            //представник
            ctrlPartnerName.DataSourceAnketa = anketaPerson;

            //контакти
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
            ctrlAddressLetter.RegionDataMember = "LeRegion";
            ctrlAddressLetter.PostIndexDataMember = "LePostIndex";


            //паспортні дані
            ctrlInternalPassport.DataSource = anketaPerson;

            //банківські реквізити
            //
            bsBankAccount.DataSource = _customer?.BankAccount.FirstOrDefault();
            

            #endregion

        }

        private void CtrlTabNavigation_OnSave(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
