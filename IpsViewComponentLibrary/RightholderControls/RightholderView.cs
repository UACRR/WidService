using System;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderView : Telerik.WinControls.UI.RadForm
    {
        private RightholderPresenter _presenter;
        public RightholderPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        #region Data sources

        public object AgreementAddRhDataSource
        {
            get => bsAgreementAddRh.DataSource;
            set => bsAgreementAddRh.DataSource = value;
        }

        public object AnketaPersonDataSource
        {
            get => bsAnketaPerson.DataSource;
            set => bsAnketaPerson.DataSource = value;
        }

        public object BankAccountDataSource
        {
            get => bsBankAccount.DataSource;
            set => bsBankAccount.DataSource = value;
        }

        public object CustomerDataSource
        {
            get => bsCustomer.DataSource;
            set => bsCustomer.DataSource = value;
        }

        public object TermsOfServiceDataSource
        {
            get => ctrlRightLimitations.DataSource;
            set => ctrlRightLimitations.DataSource = value;
        }

        public object RightholderDataSource
        {
            get => bsRightHolder.DataSource;
            set => bsRightHolder.DataSource = value;
        }

        #endregion

        public RightholderView()
        {
            InitializeComponent();

            ddlTypeMethodGet.SetDataSource(IpsGlobal.AnketaDictionaties.typeMethodGet);
        }

        public void Run()
        {
            ShowDialog();
        }

        private void btnNewRightholderCancel1_Click(object sender, EventArgs e)
        {

        }

        private void btnNextAnketa_Click(object sender, EventArgs e)
        {

        }

        private void btnNextPassport_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevFullNameComission_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevAnketa_Click(object sender, EventArgs e)
        {

        }

        private void btnNextRoyalty_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevPassport_Click(object sender, EventArgs e)
        {

        }

        private void ddlTypeMethodGet_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btnNextExclusionLimitation_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevRoyalty_Click(object sender, EventArgs e)
        {

        }

        private void btnNextTerritoryLimitation_Click(object sender, EventArgs e)
        {

        }

        private void btnNextAgreement_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevRightLimitation_Click(object sender, EventArgs e)
        {

        }

        private void miSaveRightholder_Click(object sender, EventArgs e)
        {

        }

        private void miAcceptAndSaveRightholder_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevTerritoryLimitation_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerateRightholderAgreement_Click(object sender, EventArgs e)
        {

        }

        private void ddlTypeMethodGet_SelectedValueChanged_1(object sender, EventArgs e)
        {
            var val = ddlTypeMethodGet.SelectedValue;
        }
    }
}
