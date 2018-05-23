using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RightholderWorkplace
{
    public partial class RightholderWorkplace : Telerik.WinControls.UI.RadForm
    {
        AnketaPerson _anketa;
        BankAccount _bankAccount;

        public RightholderWorkplace()
        {
            InitializeComponent();

            newRightholdersPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;
        }

        private void btnNewRightholder_Click(object sender, EventArgs e)
        {
            newRightholdersPageView.SelectedPage = newRightholdersCreatePage;
        }

        #region Next / Prev buttons

        private void btnNextAnketa_Click(object sender, EventArgs e)
        {
            if (anketaPersonRightHolderControl1.Validator())
                newCreateRightholderPageView.SelectedPage = createRightholderAnketaPage;
        }

        private void btnPrevFullNameComission_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderFullNameComissionPage;
        }

        private void btnNextPassport_Click(object sender, EventArgs e)
        {
            // TODO: implement validation
            //ctrlJaAddress.Validator()
            //ctrlFaAddress.Validator()
            //ctrlLeAddress.Validator()

            if (ctrlContacts.Validator()
                & ctrlRegistrations.Validator())
            {
                newCreateRightholderPageView.SelectedPage = createRightholderPassportPage;
            }

        }

        private void btnPrevAnketa_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderAnketaPage;
        }

        private void btnNextRoyalty_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderRoyaltyPage;
        }

        private void btnPrevPassport_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderPassportPage;
        }

        private void btnNextExclusionLimitation_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderExclusionLimitationPage;
        }

        private void btnPrevRoyalty_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderRoyaltyPage;
        }

        #endregion

        private void btnSaveRightholder_Click(object sender, EventArgs e)
        {

        }

        private void RightholderWorkplace_Load(object sender, EventArgs e)
        {
            // fake data
            _anketa = new AnketaPerson
            {
                LastName = "LastName",
                FirstName = "FirstName",
                SurName = "SurName",
                NikName = "NikName",
                BirthDate = new DateTime(2000, 08, 17),
                Sex = 2,
                PhoneMobileMain = "+380501111111",
                Inn = "1234567890",
                Citizenship = "1",
                Residency = 1,
                PUseries = "ПС",
                PUnumber = "973179",
                PUissuedWho = "PUissuedWho",
                PUissuedWhen = new DateTime(2005, 7, 10),
            };

            _bankAccount = new BankAccount
            {
                AccountNumber = "ac",
                Mfo = 380380,
                MfoName = "Mfo name",
                MfoOkpo = "okpo",
                TransitNumber = "tr num",
            };

            anketaPersonRightHolderControl1.DataSource = _anketa;
            ctrlContacts.DataSource = _anketa;
            ctrlRegistrations.DataSource = _anketa;
            //TODO: ctrlRegistrations.ResidentTypeDataSource = _anketa;
            ctrlInternalPassport.DataSource = _anketa;
            ctrlBankAccount.DataSource = _bankAccount;
        }

        private void newCreateRightholderPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (newCreateRightholderPageView.SelectedPage == createRightholderPassportPage)
            {
                if (_anketa.Residency == 1)
                    createRightholderPassportPageView.SelectedPage = createRightholderInternalPasportPage;
                else
                    createRightholderPassportPageView.SelectedPage = createRightholderForeignPassportPage;
            }
        }

        private void ddlTypeMethodGet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //TODO: move to selected value changed event
            if (ddlTypeMethodGet.SelectedIndex == 0)
                createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyBankPage;
            else if (ddlTypeMethodGet.SelectedIndex == 1)
                createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyCashPage;
            else if (ddlTypeMethodGet.SelectedIndex == 2)
                createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyPostalTransfer;
        }
    }
}
