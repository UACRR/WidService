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


        public RightholderWorkplace()
        {
            InitializeComponent();

            newRightholdersPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
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
            };

            anketaPersonRightHolderControl1.DataSource = _anketa;
            ctrlContacts.DataSource = _anketa;
            ctrlRegistrations.DataSource = _anketa;
            //TODO: ctrlRegistrations.ResidentTypeDataSource = _anketa;
        }
    }
}
