using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class AnketaConsumerPhisForm : RadForm
    {
        private readonly LicenseAgreement _license;
        public AnketaConsumerPhisForm(Customer customer)
        {
            InitializeComponent();

            ctrlTabNavigationExpanded.SetDefaultState(pageAnketaConsumer, FLoadType.Create);
            ctrlTabNavigationExpanded.SaveClick += Save;
            btnCopyFromLiveToLett.Click += btnCopyFromLiveToLett_Click;
            btnCopyFromLiveToReg.Click += btnCopyFromLiveToReg_Click;
            btnCopyFromRegToLett.Click += btnCopyFromRegToLett_Click;

            // binding
            var anketaPerson = customer.Person.AnketaPerson.SingleOrDefault();
            ctrlConsumerName.DataSourceAnketa = anketaPerson;
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
            ctrlConsumerPassport.DataSource = anketaPerson;

            // банківські реквізити
            if (!customer.BankAccount.Any())
            {
                customer.BankAccount.Add(new BankAccount());
            }
            ctrlBankAccount.DataSource = customer.BankAccount.FirstOrDefault();
            
            // майданчики
            ctrlPlaces.SetData(customer);

            _license = customer.Client.LicenseAgreement.SingleOrDefault();
            // agreement
            ctrlAgreementPhis.LicenseAgreementDataSource = _license;
        }

        private void Save(object sender, bool e)
        {
            // відразу підтверджений договір?
            var status = e ? 2 : 0;
            _license.LicStatus = status;
            // ReSharper disable once PossibleNullReferenceException - is not null
            _license.LicenseAgrParam.SingleOrDefault().LicStatus = status;
            
            DialogResult = DialogResult.OK;
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
