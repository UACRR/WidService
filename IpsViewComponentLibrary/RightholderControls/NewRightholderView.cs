using System;
using System.IO;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class NewRightholderView : Telerik.WinControls.UI.RadForm
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

        private bool _isNew = false;
        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                if (_isNew != value)
                {
                    _isNew = value;

                    if (_isNew)
                        DisablePagesAndSaveButton();
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

        public NewRightholderView()
        {
            InitializeComponent();

            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            sbSave.DefaultItem = miSave;
            sbSave.Text = miSave.Text;

            ddlTypeMethodGet.SetDataSource(IpsGlobal.AnketaDictionaties.typeMethodGet);
        }

        public void Run()
        {
            ShowDialog();
        }

        private void mainPageView_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            // TODO: move to presenter
            var selectedPage = mainPageView.SelectedPage;
            var isValid = true;

            if (selectedPage == createRightholderFullNameComissionPage)
            {
                isValid = ctrlAnketaPerson.Validator() && ctrlServiceComissionControl.ValidateChildren();
            }
            else if (selectedPage == createRightholderAnketaPage)
            {
                isValid = ctrlContacts.Validator() & ctrlRegistrations.Validator();
            }

            if (isValid)
            {
                e.Page.Enabled = true;
                if (e.Page == mainPageView.Pages.Last())
                {
                    sbSave.Enabled = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void mainPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            // TODO: move to presenter
            var anketa = bsAnketaPerson.Current as AnketaPerson;

            if (anketa == null)
                return;

            if (mainPageView.SelectedPage == createRightholderPassportPage)
            {
                if (anketa.Citizenship == "804")
                    createRightholderPassportPageView.SelectedPage = createRightholderInternalPasportPage;
                else
                    createRightholderPassportPageView.SelectedPage = createRightholderForeignPassportPage;
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

        private void DisablePagesAndSaveButton()
        {
            sbSave.Enabled = false;
            for (int i = 1; i < mainPageView.Pages.Count; i++)
            {
                mainPageView.Pages[i].Enabled = false;
            }
        }
    }
}
