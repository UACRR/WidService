using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class PersonalAddressControl : UserControl
    {
        public PersonalAddressControl()
        {
            InitializeComponent();
        }

        public void SetDataSource(Customer customer)
        {
            var anketa = customer.Person.AnketaPerson.SingleOrDefault(rec => rec.Version == customer.AnkVersion);
            bsAnketaPerson.DataSource = anketa;
        }

        public bool Validator()
        {
            return ctrlAddressLive.Validator() && ctrlAddressRegister.Validator() && ctrlAddressLetter.Validator();
        }

        private void btnCopyFromLiveToReg_Click(object sender, EventArgs e)
        {
            if (!(bsAnketaPerson.DataSource is AnketaPerson anketa))
                return;

            anketa.ReCountry = anketa.FaCountry;
            anketa.ReRegion = anketa.FaRegion;
            anketa.ReCity = anketa.FaCity;
            anketa.ReAddress = anketa.FaAddress;

            bsAnketaPerson.ResetBindings(false);
        }

        private void btnCopyFromLiveToLett_Click(object sender, EventArgs e)
        {
            if (!(bsAnketaPerson.DataSource is AnketaPerson anketa))
                return;

            anketa.LeCountry = anketa.FaCountry;
            anketa.LeRegion = anketa.FaRegion;
            anketa.LeCity = anketa.FaCity;
            anketa.LeAddress = anketa.FaAddress;

            bsAnketaPerson.ResetBindings(false);
        }

        private void btnCopyFromRegToLett_Click(object sender, EventArgs e)
        {
            if (!(bsAnketaPerson.DataSource is AnketaPerson anketa))
                return;

            anketa.LeCountry = anketa.ReCountry;
            anketa.LeRegion = anketa.ReRegion;
            anketa.LeCity = anketa.ReCity;
            anketa.LeAddress = anketa.ReAddress;

            bsAnketaPerson.ResetBindings(false);
        }
    }
}
