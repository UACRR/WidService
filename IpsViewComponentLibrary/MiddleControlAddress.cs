using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlAddress : UserControl, IMiddleCtrlAnketaConsumer
    {
        public MiddleControlAddress()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer cust, AnketaDictionaties dictionaties)
        {
            //юридична
            AnketaCompany anketa = cust?.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == cust?.AnkVersion);
            addressLegal.DataSource = anketa;
            addressLegal.AddressDataMember = "JaAddress";
            addressLegal.CityDataMember = "JaCity";
            addressLegal.CountryDataMember = "JaCountry";
            addressLegal.CountriesDataSource = dictionaties.country;
            addressLegal.CountriesValueMember = "countryCode";
            addressLegal.CountriesDisplayMember = "countryName";
            addressLegal.RegionDataMember = "JaRegion";
            addressLegal.RegionsDataSource = dictionaties.region;
            addressLegal.RegionsValueMember = "codeI";
            addressLegal.RegionsDisplayMember = "name";

            //фактична
            addressFactual.DataSource = anketa;
            addressFactual.AddressDataMember = "FaAddress";
            addressFactual.CityDataMember = "FaCity";
            addressFactual.CountryDataMember = "FaCountry";
            addressFactual.CountriesDataSource = dictionaties.country;
            addressFactual.CountriesValueMember = "countryCode";
            addressFactual.CountriesDisplayMember = "countryName";
            addressFactual.RegionDataMember = "FaRegion";
            addressFactual.RegionsDataSource = dictionaties.region;
            addressFactual.RegionsValueMember = "codeI";
            addressFactual.RegionsDisplayMember = "name";

            //поштова
            addressLetter.DataSource = anketa;
            addressLetter.AddressDataMember = "LeAddress";
            addressLetter.CityDataMember = "LeCity";
            addressLetter.CountryDataMember = "LeCountry";
            addressLetter.CountriesDataSource = dictionaties.country;
            addressLetter.CountriesValueMember = "countryCode";
            addressLetter.CountriesDisplayMember = "countryName";
            addressLetter.RegionDataMember = "LeRegion";
            addressLetter.RegionsDataSource = dictionaties.region;
            addressLetter.RegionsValueMember = "codeI";
            addressLetter.RegionsDisplayMember = "name";
            addressLetter.PostIndexDataMember = "LePostIndex";

            lblTitle.Text = anketa?.Name;
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
