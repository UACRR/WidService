using System;
using System.IO;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderView : Telerik.WinControls.UI.RadForm, IRightholderView
    {
        private bool _isCompany;

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

        public object AnketaCompanyDataSource
        {
            get => bsAnketaCompany.DataSource;
            set => bsAnketaCompany.DataSource = value;
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

            SetDictionaries();

            passportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            sbSave.DefaultItem = miSave;
            sbSave.Text = miSave.Text;
        }

        public void Run()
        {
            var customer = (Customer)bsCustomer.Current;

            _isCompany = customer.CustType == 3;

            if (_isCompany)
            {
                rightholderCompanyPage.Item.Visibility = ElementVisibility.Visible;
                rightholderPersonPage.Item.Visibility = ElementVisibility.Collapsed;
                anketaPageView.SelectedPage = rightholderCompanyPage;

                contactsCompanyPage.Item.Visibility = ElementVisibility.Visible;
                contactsPersonPage.Item.Visibility = ElementVisibility.Collapsed;
                ctrlMiddleControlAddress.SetDataSources(customer, IpsGlobal.AnketaDictionaties);

                managersPage.Item.Visibility = ElementVisibility.Visible;
                passportPage.Item.Visibility = ElementVisibility.Collapsed;
                ctrlMiddleControlManagers.SetDataSources(customer, IpsGlobal.AnketaDictionaties);
            }
            else
            {
                rightholderCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
                rightholderPersonPage.Item.Visibility = ElementVisibility.Visible;
                anketaPageView.SelectedPage = rightholderPersonPage;

                contactsCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
                contactsPersonPage.Item.Visibility = ElementVisibility.Visible;

                managersPage.Item.Visibility = ElementVisibility.Collapsed;
                passportPage.Item.Visibility = ElementVisibility.Visible;
            }

            ShowDialog();
        }

        public bool IsValid
        {
            get
            {
                var result = true;

                if (_isCompany)
                {
                    result = ctrlAnketaPersonRightholderPage.Validator();
                }
                else
                {
                    result = ctrlAnketaCompanyRightholderPage.Validator() & ctrlMiddleControlManagers.Validator();
                }

                return result & ctrlServiceComissionControl.ValidateChildren() & ctrlContacts.Validator();
            }
        }

        public void SetHeader(string header)
        {
            Text = header + " - Анкета правовласника";
        }

        private void mainPageView_SelectedPageChanged(object sender, EventArgs e)
        {

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

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_ГО УААСП Автор.docx");

            btnGenerateRightholderAgreement.Enabled = false;
            waitbarAgreement.StartWaiting();

            var wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);
            wordEngine.processRightHolder(template, customer, customer.AgreementMaster.First());

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
            _presenter.SetAgreementRightholderStatus(AgreementStatuses.Active);
            _presenter.Save(accept: true);
        }

        private void btnSetAgreementRightholderStatus_Click(object sender, EventArgs e)
        {
            _presenter.SetAgreementRightholderStatus((AgreementStatuses)btnSetAgreementRightholderStatus.Tag);
            bsAgreementAddRh.ResetCurrentItem();
        }

        private void btnSetAgreementRightholderStatusInheritance_Click(object sender, EventArgs e)
        {
            _presenter.SetAgreementRightholderStatus(AgreementStatuses.Inheritance);
            bsAgreementAddRh.ResetCurrentItem();
        }

        private void btnSetStatusClosed_Click(object sender, EventArgs e)
        {
            _presenter.SetAgreementRightholderStatus(AgreementStatuses.Closed);
            bsAgreementAddRh.ResetCurrentItem();
        }

        private void btnCopyAddressFaRe_Click(object sender, EventArgs e)
        {
            _presenter.CopyAddressFactToRegister();
            bsAnketaPerson.ResetCurrentItem();
        }

        private void btnCopyAddressFaLe_Click(object sender, EventArgs e)
        {
            _presenter.CopyAddressFactToLetter();
            bsAnketaPerson.ResetCurrentItem();
        }

        private void btnCopyAddressReLe_Click(object sender, EventArgs e)
        {
            _presenter.CopyAddressRegisterToLetter();
            bsAnketaPerson.ResetCurrentItem();
        }

        private void RightholderView_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            _presenter.Close();
            e.Cancel = true;
        }

        private void bsAgreementAddRh_BindingComplete(object sender, System.Windows.Forms.BindingCompleteEventArgs e)
        {
            SetAllowedStatuses();
        }

        private void SetDictionaries()
        {
            ddlTypeMethodGet.SetDataSource(IpsGlobal.AnketaDictionaties.typeMethodGet);
            ddlAgreementStatus.SetDataSource(IpsGlobal.AnketaDictionaties.agreementStatus);
        }

        private void SetAllowedStatuses()
        {
            if (bsAgreementAddRh.Current != null)
            {
                var agreementStatus = (AgreementStatuses)((AgreementAddRh)bsAgreementAddRh.Current).AgrStatus;

                if (agreementStatus == AgreementStatuses.Active)
                {
                    gboxRightholderStatus.Enabled = true;
                    btnSetStatusInheritance.Enabled = true;
                    btnSetStatusClosed.Enabled = true;

                    btnSetAgreementRightholderStatus.Text = "Заблокувати";
                    btnSetAgreementRightholderStatus.Tag = AgreementStatuses.Blocked;
                }
                else if (agreementStatus == AgreementStatuses.Blocked)
                {
                    gboxRightholderStatus.Enabled = true;
                    btnSetStatusInheritance.Enabled = false;
                    btnSetStatusClosed.Enabled = false;

                    btnSetAgreementRightholderStatus.Text = "Розблокувати";
                    btnSetAgreementRightholderStatus.Tag = AgreementStatuses.Active;
                }
                else if (agreementStatus == AgreementStatuses.NotAccepted || agreementStatus == AgreementStatuses.OnAcception)
                {
                    gboxRightholderStatus.Enabled = true;
                    btnSetStatusInheritance.Enabled = false;
                    btnSetStatusClosed.Enabled = false;

                    btnSetAgreementRightholderStatus.Text = "Активний";
                    btnSetAgreementRightholderStatus.Tag = AgreementStatuses.Active;
                }
                else
                {
                    gboxRightholderStatus.Enabled = false;
                }
            }
        }

        private void pageViewMain_SelectedPageChanged(object sender, EventArgs e)
        {
            if (pageViewMain.SelectedPage == pageObjects && ctrlRightholdersObjectsRight.SelectedRightholder == null)
            {
                ctrlRightholdersObjectsRight.SelectedRightholder = new RightholderMainView { CustId = ((RightHolder)bsRightHolder.Current).CustId };
            }

        }

        private void miAddMusicalCompositionForRightholder_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                int category;
                if (int.TryParse(menuItem.Tag.ToString(), out category))
                {
                    _presenter.AddNewObject(category);
                }
            }
        }

        private void btnAddExistingObjectRightForRightholder_Click(object sender, EventArgs e)
        {
            _presenter.AddExistingObject();
        }

        private void btnUploadFromExcel_Click(object sender, EventArgs e)
        {
            _presenter.UploadFromExcel();
        }

        private void anketaPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            // Патлякевич
            // Виправлення MED-404
            if (anketaPageView.SelectedPage == passportPage)
            {
                var anketa = bsAnketaPerson.Current as AnketaPerson;
                if (anketa != null)
                {
                    if (anketa.Citizenship == "804")
                        passportPageView.SelectedPage = createRightholderInternalPasportPage;
                    else
                        passportPageView.SelectedPage = createRightholderForeignPassportPage;
                }
            }
        }
    }
}
