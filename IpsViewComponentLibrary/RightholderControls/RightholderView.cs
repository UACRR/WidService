using System;
using System.IO;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderView : Telerik.WinControls.UI.RadForm, IRightholderView
    {
        private IRightholderPresenter _presenter;
        public IRightholderPresenter Presenter
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

            passportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            sbSave.DefaultItem = miSave;
            sbSave.Text = miSave.Text;

            ddlTypeMethodGet.SetDataSource(IpsGlobal.AnketaDictionaties.typeMethodGet);
        }

        public void Run()
        {
            ShowDialog();
        }

        public bool IsValid
        {
            get
            {
                return ctrlAnketaPerson.Validator() & ctrlServiceComissionControl.ValidateChildren() & ctrlContacts.Validator() & ctrlRegistrations.Validator();
            }
        }

        private void mainPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            // TODO: move to presenter
            var anketa = bsAnketaPerson.Current as AnketaPerson;

            if (anketa == null)
                return;

            if (anketaPageView.SelectedPage == createRightholderPassportPage)
            {
                if (anketa.Citizenship == "804")
                    passportPageView.SelectedPage = createRightholderInternalPasportPage;
                else
                    passportPageView.SelectedPage = createRightholderForeignPassportPage;
            }
        }

        private void ddlTypeMethodGet_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            // TODO: move to presenter
            if (ddlTypeMethodGet.SelectedValue is int)
            {
                var value = (int)ddlTypeMethodGet.SelectedValue;

                if (value == 1)
                    createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyCashPage;
                else if (value == 2)
                    createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyBankPage;
                else if (value == 3 || value == 4)
                    createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyPostalTransfer;
            }
        }

        private async void btnGenerateRightholderAgreement_Click(object sender, EventArgs e)
        {
            // TODO: move to presenter and show in the separate dialog
            var customer = bsCustomer.Current as Customer;

            if (customer == null)
                return;

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_DOGOVIR-NA-UPRAVLINNYA-PRAVAMI-Avtora-2018-1_.docx");

            btnGenerateRightholderAgreement.Enabled = false;
            waitbarAgreement.StartWaiting();

            var wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);
            await wordEngine.processRightHolder(template, customer, customer.AgreementMaster.First());

            pdfvRightholderAgreement.LoadDocument(wordEngine.Pdf);
            waitbarAgreement.StopWaiting();

            btnGenerateRightholderAgreement.Enabled = true;
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            _presenter.Save(accept: false);
        }

        private void miAcceptAndSave_Click(object sender, EventArgs e)
        {
            _presenter.Save(accept: true);
        }

        private void RightholderView_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            _presenter.Close();
            e.Cancel = true;
        }
    }
}
