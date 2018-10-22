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
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerAnketaJurControl : UserControl, IAnketaControls
    {
        public event EventHandler<bool> SaveClick;
        public PartnerAnketaJurControl()
        {
            InitializeComponent();
            ctrlTabNavigationExpanded.SetDefaultState(pageView, FLoadType.Create);
            ctrlTabNavigationExpanded.SaveClick += Save;
        }

        public void BeginBindings(Customer customer)
        {
            //var anketaPerson = customer.Person.AnketaPerson.SingleOrDefault();
            //// представник
            //ctrlPartnerName.DataSourceAnketa = anketaPerson;

            //// контакти
            //ctrlContacts.DataSource = anketaPerson;
            //// - проживання
            //ctrlAddressLive.DataSource = anketaPerson;
            //ctrlAddressLive.AddressDataMember = "ReAddress";
            //ctrlAddressLive.CityDataMember = "ReCity";
            //ctrlAddressLive.CountryDataMember = "ReCountry";
            //ctrlAddressLive.RegionDataMember = "ReRegion";
            //// - фактична
            //ctrlAddressRegister.DataSource = anketaPerson;
            //ctrlAddressRegister.AddressDataMember = "FaAddress";
            //ctrlAddressRegister.CityDataMember = "FaCity";
            //ctrlAddressRegister.CountryDataMember = "FaCountry";
            //ctrlAddressRegister.RegionDataMember = "FaRegion";
            ////- -поштова


            ////поштова
            //ctrlAddressLetter.DataSource = anketaPerson;
            //ctrlAddressLetter.AddressDataMember = "LeAddress";
            //ctrlAddressLetter.CityDataMember = "LeCity";
            //ctrlAddressLetter.CountryDataMember = "LeCountry";
            //ctrlAddressLetter.CountriesDataSource = IpsGlobal.AnketaDictionaties.country;
            //ctrlAddressLetter.CountriesValueMember = "countryCode";
            //ctrlAddressLetter.CountriesDisplayMember = "countryName";
            //ctrlAddressLetter.RegionDataMember = "LeRegion";
            //ctrlAddressLetter.RegionsDataSource = IpsGlobal.AnketaDictionaties.region;
            //ctrlAddressLetter.RegionsValueMember = "codeI";
            //ctrlAddressLetter.RegionsDisplayMember = "name";
            //ctrlAddressLetter.PostIndexDataMember = "LePostIndex";

            //// паспортні дані
            //ctrlInternalPassport.DataSource = anketaPerson;

            //// банківські реквізити
            //ctrlBankAccount.DataSource = customer?.BankAccount.FirstOrDefault();

            //// договір
            //ctrlAgreement.AgreementDataSource = customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();
            //// умови договору
            //ctrlConditions.AgreementAddPartnerDataSource = customer?.AgreementMaster?.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault();

        }

        private void Save(object sender, bool accept)
        {
            SaveClick?.Invoke(sender, accept);
        }
    }
}
