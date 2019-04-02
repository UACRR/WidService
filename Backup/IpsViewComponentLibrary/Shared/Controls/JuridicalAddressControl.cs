using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class JuridicalAddressControl : UserControl
    {
        private readonly AnketaDictionaties _dictionaties;
        public JuridicalAddressControl()
        {
            InitializeComponent();
            if (IpsGlobal.AnketaDictionaties != null)
                _dictionaties = IpsGlobal.AnketaDictionaties;
        }

        public void SetDataSources(Customer customer)
        {
            //юридична
            var anketa = customer.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == customer.AnkVersion);
            addressLegal.DataSource = anketa;
            addressLegal.AddressDataMember = "JaAddress";
            addressLegal.CityDataMember = "JaCity";
            addressLegal.CountryDataMember = "JaCountry";
            addressLegal.RegionDataMember = "JaRegion";

            //фактична
            addressFactual.DataSource = anketa;
            addressFactual.AddressDataMember = "FaAddress";
            addressFactual.CityDataMember = "FaCity";
            addressFactual.CountryDataMember = "FaCountry";
            addressFactual.RegionDataMember = "FaRegion";

            //поштова
            addressLetter.DataSource = anketa;
            addressLetter.AddressDataMember = "LeAddress";
            addressLetter.CityDataMember = "LeCity";
            addressLetter.CountryDataMember = "LeCountry";
            addressLetter.CountriesDataSource = _dictionaties.country;
            addressLetter.CountriesValueMember = "countryCode";
            addressLetter.CountriesDisplayMember = "countryName";
            addressLetter.RegionDataMember = "LeRegion";
            addressLetter.RegionsDataSource = _dictionaties.region;
            addressLetter.RegionsValueMember = "codeI";
            addressLetter.RegionsDisplayMember = "name";
            addressLetter.PostIndexDataMember = "LePostIndex";
        }

        public bool Validator()
        {
            return addressFactual.Validator() && addressLegal.Validator() && addressLetter.Validator();
        }


        // з юридичної до фактичної
        private void btnCopyFromJaToFa_Click(object sender, EventArgs e)
        {
            addressFactual.DdlCountry.SelectedValue = addressLegal.DdlCountry.SelectedValue;
            addressFactual.DdlRegion.SelectedIndex = addressLegal.DdlRegion.SelectedIndex;
            addressFactual.TxtCity.Select();
            addressFactual.TxtCity.Text = addressLegal.TxtCity.Text;
            addressFactual.TxtAddress.Select();
            addressFactual.TxtAddress.Text = addressLegal.TxtAddress.Text;
        }

        // з юридичної до поштової
        private void btnCopyFromJaToLe_Click(object sender, EventArgs e)
        {
            addressLetter.DdlCountry.SelectedValue = addressLegal.DdlCountry.SelectedValue;
            addressLetter.DdlRegion.SelectedIndex = addressLegal.DdlRegion.SelectedIndex;
            addressLetter.TxtCity.Select();
            addressLetter.TxtCity.Text = addressLegal.TxtCity.Text;
            addressLetter.TxtAddress.Select();
            addressLetter.TxtAddress.Text = addressLegal.TxtAddress.Text;
            addressLetter.TxtPostIndex.Select();
        }

        // з фактичної до поштової
        private void btnCopyFromFaToLe_Click(object sender, EventArgs e)
        {
            addressLetter.DdlCountry.SelectedValue = addressFactual.DdlCountry.SelectedValue;
            addressLetter.DdlRegion.SelectedIndex = addressFactual.DdlRegion.SelectedIndex;
            addressLetter.TxtCity.Select();
            addressLetter.TxtCity.Text = addressFactual.TxtCity.Text;
            addressLetter.TxtAddress.Select();
            addressLetter.TxtAddress.Text = addressFactual.TxtAddress.Text;
            addressLetter.TxtPostIndex.Select();
        }

        internal void SetDefaultState()
        {
            addressFactual.SetDefaultState();
            addressLegal.SetDefaultState();
            addressLetter.SetDefaultState();
        }

    }
}
