using System;
using System.IO;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class NewRightholderView : RadForm, IRightholderView
    {
        private bool _isCompany;
        private WordEngine wordEngine;
        private string _custName;

        private IRightholderPresenter _presenter;
        public IRightholderPresenter Presenter
        {
            get => _presenter;
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

        public object AnketaExternalDataSource
        {
            get => bsAnketaExternal.DataSource;
            set => bsAnketaExternal.DataSource = value;
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

        //term of service for External Anketa
        public object TermsOfServiceExternalAnketaDataSource { get; set; }

        public object RightholderDataSource
        {
            get => bsRightHolder.DataSource;
            set => bsRightHolder.DataSource = value;
        }

        #endregion

        public NewRightholderView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            sbSave.DefaultItem = miSave;
            sbSave.Text = miSave.Text;

            ddlTypeMethodGet.SetDataSource(IpsGlobal.AnketaDictionaties.typeMethodGet);

            DisablePagesAndSaveButton();
            setupSaveAs();
        }

        ~NewRightholderView()
        {
            wordEngine = null;
        }

        private void setupSaveAs()
        {
            var oldButton = radPdfViewerNavigator1.CommandBarElement.Rows[0].Strips[0].Items[3];
            radPdfViewerNavigator1.CommandBarElement.Rows[0].Strips[0].Items.RemoveAt(3);
            CommandBarButton btn = new CommandBarButton();
            btn.Text = oldButton.Text;
            btn.Image = oldButton.Image;
            btn.Click += Btn_Click;
            radPdfViewerNavigator1.CommandBarElement.Rows[0].Strips[0].Items.Insert(3, btn);

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = _custName.Trim();
            saveFileDialog1.Filter = "docx files (*.docx)|*.docx|pdf files (*.pdf)|*.pdf";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() ==  DialogResult.OK)
            {
                var FileName = saveFileDialog1.FileName;

                if (File.Exists(FileName))
                    File.Delete(FileName);

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        File.Copy(wordEngine.Docx, FileName);
                        break;
                    case 2:
                        File.Copy(wordEngine.Pdf, FileName);
                        break;
                }
            }
        }

        public void Run()
        {
            var customer = (Customer)bsCustomer.Current;

            _isCompany = customer.CustType == 3;

            if (_isCompany)
            {
                rightholderCompanyPage.Item.Visibility = ElementVisibility.Visible;
                rightholderPersonPage.Item.Visibility = ElementVisibility.Collapsed;
                mainPageView.SelectedPage = rightholderCompanyPage;

                contactsCompanyPage.Item.Visibility = ElementVisibility.Visible;
                contactsPersonPage.Item.Visibility = ElementVisibility.Collapsed;
                ctrlMiddleControlAddress.SetDataSources(customer);

                managersPage.Item.Visibility = ElementVisibility.Visible;
                passportPage.Item.Visibility = ElementVisibility.Collapsed;
                ctrlMiddleControlManagers.SetDataSources(customer);
            }
            else
            {
                rightholderCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
                rightholderPersonPage.Item.Visibility = ElementVisibility.Visible;
                mainPageView.SelectedPage = rightholderPersonPage;

                contactsCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
                contactsPersonPage.Item.Visibility = ElementVisibility.Visible;

                managersPage.Item.Visibility = ElementVisibility.Collapsed;
                passportPage.Item.Visibility = ElementVisibility.Visible;
            }

            mainPageView.SelectedPageChanging += mainPageView_SelectedPageChanging;

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

        private void mainPageView_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            // TODO: move to presenter
            var selectedPage = mainPageView.SelectedPage;
            var isValid = true;

            if (selectedPage == rightholderPersonPage)
            {
                isValid = ctrlAnketaPersonRightholderPage.Validator() & ctrlServiceComissionControl.ValidateChildren();
            }
            else if (selectedPage == rightholderCompanyPage)
            {
                isValid = ctrlAnketaCompanyRightholderPage.Validator();
            }
            else if (selectedPage == contactsPersonPage)
            {
                //isValid = ctrlContacts.Validator();
            }
            else if (selectedPage == managersPage)
            {
                //isValid = ctrlMiddleControlManagers.Validator();
            }
            else if (selectedPage == agreementPage)
            {
                isValid = ctrlServiceComissionControl.ValidateChildren();
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

            if (mainPageView.SelectedPage == passportPage)
            {
                if (anketa.Citizenship == "804")
                    createRightholderPassportPageView.SelectedPage = pasportPage;
                else
                    createRightholderPassportPageView.SelectedPage = createRightholderForeignPassportPage;
            }

            if (mainPageView.SelectedPage == agreementPage)
            {
                _presenter.SetAgreementNumber();
                bsAgreementAddRh.ResetCurrentItem();
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

        private void btnGenerateRightholderAgreement_Click(object sender, EventArgs e)
        {
            // TODO: move to presenter and show in the separate dialog
            var customer = bsCustomer.Current as Customer;

            var agrMaster = customer?.AgreementMaster.First();
            if (agrMaster == null)
                return;

            var templateName = IpsGlobal.AnketaDictionaties.agreementType.FirstOrDefault(item => item.CodeI == agrMaster.AgrType)?.TemplateName;
            if (string.IsNullOrEmpty(templateName))
                templateName = "F_ГО УААСП Автор.docx";

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", templateName);


            btnGenerateRightholderAgreement.Enabled = false;
            waitbarAgreement.StartWaiting();

            if (wordEngine == null)
                wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);
            wordEngine.ProcessRightHolder(template, customer, customer.AgreementMaster.First());

            if (string.IsNullOrEmpty(wordEngine.Pdf))
                return;

            pdfvRightholderAgreement.LoadDocument(wordEngine.Pdf);
            _custName = CustomerUtility.CustomerName(customer);
            radPdfViewerNavigator1.Enabled = true;
            waitbarAgreement.StopWaiting();

            btnGenerateRightholderAgreement.Enabled = true;
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
            for (int i = 2; i < mainPageView.Pages.Count; i++)
            {
                mainPageView.Pages[i].Enabled = false;
            }
        }

        private void NewRightholderView_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            _presenter.Close();
            e.Cancel = true;
        }
    }
}
