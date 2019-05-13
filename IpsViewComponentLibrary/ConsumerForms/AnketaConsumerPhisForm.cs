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
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class AnketaConsumerPhisForm : RadForm
    {
        private const string DefaultTitle = "Анкета користувача [фізична особа]";

        private readonly LicenseAgreement _license;
        private readonly Customer _customer;
        public AnketaConsumerPhisForm(Customer customer)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            ctrlConsumerName.TextNameChanged += CtrlConsumerName_TextNameChanged;

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
            
            // agreement
            var places = customer.Client.ClnBusinessPlace;
            _license = customer.Client.LicenseAgreement.SingleOrDefault();
            var licAgr = _license?.LicenseAgrParam.SingleOrDefault();
            ctrlAgreementPhis.Rights = TypeRights.SmallRights;
            ctrlAgreementPhis.InitializeObjects(places, _license, licAgr, ConsumerAgreementInitType.AddNewAgreement);

            _customer = customer;
        }

        private void CtrlConsumerName_TextNameChanged(string lastName, string firstName, string surName)
        {
            if (lastName.Length == 0 && firstName.Length == 0 && surName.Length == 0)
            {
                Text = DefaultTitle;
                return;
            }

            Text = string.Concat(DefaultTitle, $": {lastName} {firstName} {surName}");
        }

        private void Save(object sender, bool e)
        {
            // відразу підтверджений договір?
            var status = e ? 2 : 0;
            _customer.Status = status;
            _customer.AgreementMaster.SingleOrDefault().AgrStatus = status;
            _customer.Person.AnketaPerson.SingleOrDefault().Status = status;

            _license.LicStatus = status;
            _license.Agr.AgrStatus = status;
            // ReSharper disable once PossibleNullReferenceException - is not null
            _license.LicenseAgrParam.SingleOrDefault().LicStatus = status;
            ctrlAgreementPhis.UpdateLicenses();
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

        private void btnLoadPdf_Click(object sender, EventArgs e)
        {
            var printForm = new ViewAndPrintAgreementForm(_customer, _license);
            printForm.ShowDialog();
        }
    }
}
