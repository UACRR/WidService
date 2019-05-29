using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class JuridicalAddressControl : UserControl
    {
        public JuridicalAddressControl()
        {
            InitializeComponent();
        }

        public void SetDataSources(Customer customer)
        {
            var anketa = customer.Company?.AnketaCompany?.SingleOrDefault(rec => rec?.Version == customer.AnkVersion);
            bsAnketaCompany.DataSource = anketa;
        }

        public bool Validator()
        {
            return addressFactual.Validator() && addressLegal.Validator() && addressLetter.Validator();
        }

        // з юридичної до фактичної
        private void btnCopyFromJaToFa_Click(object sender, EventArgs e)
        {
            if (!(bsAnketaCompany.DataSource is AnketaCompany anketa))
                return;

            anketa.FaCountry = anketa.JaCountry;
            anketa.FaRegion = anketa.JaRegion;
            anketa.FaAddress = anketa.JaAddress;
            anketa.FaCity = anketa.JaCity;

            bsAnketaCompany.ResetBindings(false);
        }

        // з юридичної до поштової
        private void btnCopyFromJaToLe_Click(object sender, EventArgs e)
        {
            if (!(bsAnketaCompany.DataSource is AnketaCompany anketa))
                return;

            anketa.LeCountry = anketa.JaCountry;
            anketa.LeRegion = anketa.JaRegion;
            anketa.LeAddress = anketa.JaAddress;
            anketa.LeCity = anketa.JaCity;

            bsAnketaCompany.ResetBindings(false);
        }

        // з фактичної до поштової
        private void btnCopyFromFaToLe_Click(object sender, EventArgs e)
        {
            if (!(bsAnketaCompany.DataSource is AnketaCompany anketa))
                return;

            anketa.LeCountry = anketa.FaCountry;
            anketa.LeRegion = anketa.FaRegion;
            anketa.LeAddress = anketa.FaAddress;
            anketa.LeCity = anketa.FaCity;

            bsAnketaCompany.ResetBindings(false);
        }
    }
}
