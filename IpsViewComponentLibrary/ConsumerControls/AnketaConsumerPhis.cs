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
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class AnketaConsumerPhis : UserControl
    {
        public AnketaConsumerPhis()
        {
            InitializeComponent();

            btnCopyFromLiveToLett.Click += BtnCopyFromLiveToLett_Click;
            btnCopyFromLiveToReg.Click += BtnCopyFromLiveToReg_Click;
            btnCopyFromRegToLett.Click += BtnCopyFromRegToLett_Click;
        }

        public void SetData(Customer customer, ConsumerAnketeType anketeType = ConsumerAnketeType.CreateNewAnketa)
        {
            if (anketeType == ConsumerAnketeType.EditAnketa)
            {
                pageAnketaConsumer.Pages["pvPrint"].Item.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
                pageAnketaConsumer.Pages["pvAgreement"].Item.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            }
            // binding

            // agreement
            if (anketeType != ConsumerAnketeType.EditAnketa)
            {
                var places = customer.Client.ClnBusinessPlace;
                var license = customer.Client.LicenseAgreement.SingleOrDefault();
                var licAgr = license?.LicenseAgrParam.SingleOrDefault();
                ctrlAgreementPhis.Rights = TypeRights.SmallRights;
                ctrlAgreementPhis.InitializeObjects(places, license, licAgr, ConsumerAgreementInitType.AddNewAgreement);
            }

            // anketaPerson
            var anketaPerson = customer.Person.AnketaPerson.SingleOrDefault();
            bsAnketaPerson.DataSource = anketaPerson;

            ctrlConsumerName.DataSourceAnketa = anketaPerson;

            // контакти
            ctrlContacts.DataSource = anketaPerson;
            // - проживання
            ctrlAddressLive.DataSource = anketaPerson;
            ctrlAddressLive.AddressDataMember = "FaAddress"; 
            ctrlAddressLive.CityDataMember = "FaCity";       
            ctrlAddressLive.CountryDataMember = "FaCountry"; 
            ctrlAddressLive.RegionDataMember = "FaRegion";
            // - реєстрації
            ctrlAddressRegister.DataSource = anketaPerson;
            ctrlAddressRegister.AddressDataMember = "ReAddress";
            ctrlAddressRegister.CityDataMember = "ReCity";
            ctrlAddressRegister.CountryDataMember = "ReCountry";
            ctrlAddressRegister.RegionDataMember = "ReRegion";
            //- -поштова

            //поштова
            ctrlAddressLetter.DataSource = anketaPerson;
            ctrlAddressLetter.AddressDataMember = "LeAddress";
            ctrlAddressLetter.CityDataMember = "LeCity";
            ctrlAddressLetter.CountryDataMember = "LeCountry";
            //ctrlAddressLetter.CountriesDataSource = IpsGlobal.AnketaDictionaties.country;
            //ctrlAddressLetter.CountriesValueMember = "countryCode";
            //ctrlAddressLetter.CountriesDisplayMember = "countryName";
            ctrlAddressLetter.RegionDataMember = "LeRegion";
            //ctrlAddressLetter.RegionsDataSource = IpsGlobal.AnketaDictionaties.region;
            //ctrlAddressLetter.RegionsValueMember = "codeI";
            //ctrlAddressLetter.RegionsDisplayMember = "name";
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
        }

        // TODO: CHANGE CONTROL!

        private void BtnCopyFromLiveToReg_Click(object sender, EventArgs e)
        {
            //ctrlAddressRegister.DdlCountry.SelectedValue = ctrlAddressLive.DdlCountry.SelectedValue;
            //ctrlAddressRegister.DdlRegion.SelectedIndex = ctrlAddressLive.DdlRegion.SelectedIndex;
            //ctrlAddressRegister.TxtCity.Select();
            //ctrlAddressRegister.TxtCity.Text = ctrlAddressLive.TxtCity.Text;
            //ctrlAddressRegister.TxtAddress.Select();
            //ctrlAddressRegister.TxtAddress.Text = ctrlAddressLive.TxtAddress.Text;
        }

        private void BtnCopyFromLiveToLett_Click(object sender, EventArgs e)
        {
            //ctrlAddressLetter.DdlCountry.SelectedValue = ctrlAddressLive.DdlCountry.SelectedValue;
            //ctrlAddressLetter.DdlRegion.SelectedIndex = ctrlAddressLive.DdlRegion.SelectedIndex;
            //ctrlAddressLetter.TxtCity.Select();
            //ctrlAddressLetter.TxtCity.Text = ctrlAddressLive.TxtCity.Text;
            //ctrlAddressLetter.TxtAddress.Select();
            //ctrlAddressLetter.TxtAddress.Text = ctrlAddressLive.TxtAddress.Text;
            //ctrlAddressLetter.TxtPostIndex.Select();
        }

        private void BtnCopyFromRegToLett_Click(object sender, EventArgs e)
        {
            //ctrlAddressLetter.DdlCountry.SelectedValue = ctrlAddressRegister.DdlCountry.SelectedValue;
            //ctrlAddressLetter.DdlRegion.SelectedIndex = ctrlAddressRegister.DdlRegion.SelectedIndex;
            //ctrlAddressLetter.TxtCity.Select();
            //ctrlAddressLetter.TxtCity.Text = ctrlAddressRegister.TxtCity.Text;
            //ctrlAddressLetter.TxtAddress.Select();
            //ctrlAddressLetter.TxtAddress.Text = ctrlAddressRegister.TxtAddress.Text;
            //ctrlAddressLetter.TxtPostIndex.Select();
        }
    }
}
