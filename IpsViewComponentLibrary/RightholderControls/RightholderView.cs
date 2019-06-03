using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderView : RadForm, IRightholderView
    {
        //private bool _isCompany;
        private string _pdf;
        private string _doc;
        private string _custName;
        private WordEngine wordEngine;

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
            set
            {
                bsCustomer.DataSource = value;
                ctrlCatalog.CustId = ((Customer) value).CustId;
            }
        }

        public object TermsOfServiceDataSource
        {
            get => ctrlRightLimitations.DataSource;
            set => ctrlRightLimitations.DataSource = value;
        }

        //TernsOfService control for External Anketa
        public object TermsOfServiceExternalAnketaDataSource
        {
            get => rightLimitationsControl1_ExternalAnketa.DataSource;
            set => rightLimitationsControl1_ExternalAnketa.DataSource = value;
        }

        public object RightholderDataSource
        {
            get => bsRightHolder.DataSource;
            set => bsRightHolder.DataSource = value;
        }

        #endregion

        /// <summary>
        /// Активність вкладок реєстру/каталога залежно від типу правовласника
        /// </summary>
        /// <param name="rhType"></param>
        public void SetCatalogsTabVisible(int? rhType)
        {
            if (rhType == null)
            {
                pvCatalog.Enabled = false;
                pvRegisters.Enabled = false;
            }
            else if (rhType == 1)
            {
                pvCatalog.Enabled = false;
                pvRegisters.Enabled = true;
            }
            else
            {
                pvCatalog.Enabled = true;
                pvRegisters.Enabled = false;
            }
        }

        
        public RightholderView()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            setupSaveAs();
            SetDictionaries();

            passportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            sbSave.DefaultItem = miSave;
            sbSave.Text = miSave.Text;
        }

        ~RightholderView()
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
            if ( saveFileDialog1.ShowDialog() == DialogResult.OK )
            {
                FileInfo fi = new FileInfo(saveFileDialog1.FileName);
                var FileName = saveFileDialog1.FileName;

                if (File.Exists(FileName))
                    File.Delete(FileName);
                switch(saveFileDialog1.FilterIndex )
                {
                    case 1:
                        File.Copy(_doc, FileName);
                        break;
                    case 2:
                        {
                            File.Copy(_pdf, FileName);
                            break;
                        }
                }

            }
        }
        //define active pages
        private void ShowActivePages(Customer customer)
        {
            //check on exist state field 'CustType'
            if (customer.CustType == null) { return; }
            //get all pages
            foreach (var external in pageCatalog.Pages)
                //hide current page if it's: Anketa, Contract
                if (customer.CustType == 5 && (external.Name == "Anketa" || external.Name == "Contract"))
                    external.Item.Visibility = ElementVisibility.Collapsed;
                //hide current page if it's: ExternalAnketa
                else if (customer.CustType != 5 && external.Name == "AnketaExternal")
                    external.Item.Visibility = ElementVisibility.Collapsed;

        }

        public void Run()
        {
            var customer = (Customer)bsCustomer.Current;
            SetCatalogsTabVisible(customer.RightHolder.RHolderType);
            //set active pages on depends field 'CustType'
            //ShowActivePages(customer);

            //disable unusable code
            //_isCompany = customer.CustType == 3;


            //test model
            DirectorCustType _director = new DirectorCustType(this, customer);
            _director.CurrentTypeCustomer.ShowPages();
            _director.CurrentTypeCustomer.RunSetings();
            //if (customer.CustType == 3)
            //{
            //    rightholderCompanyPage.Item.Visibility = ElementVisibility.Visible;
            //    rightholderPersonPage.Item.Visibility = ElementVisibility.Collapsed;
            //    anketaPageView.SelectedPage = rightholderCompanyPage;

            //    contactsCompanyPage.Item.Visibility = ElementVisibility.Visible;
            //    contactsPersonPage.Item.Visibility = ElementVisibility.Collapsed;
            //    ctrlMiddleControlAddress.SetDataSources(customer);

            //    managersPage.Item.Visibility = ElementVisibility.Visible;
            //    passportPage.Item.Visibility = ElementVisibility.Collapsed;
            //    ctrlMiddleControlManagers.SetDataSources(customer);
            //}
            //else if (customer.CustType == 5)
            //{
            //    //set default active page for External Anketa
            //    pageViewMain.SelectedPage = AnketaExternal;
            //    //set data of the External Anketa
            //    anketaExternalRightholderControl1.DataSourceAnketaExternal = bsAnketaExternal;
            //    anketaExternalRightholderControl1.DataSourceRightHolder = bsRightHolder;

            //}
            //else
            //{
            //    rightholderCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
            //    rightholderPersonPage.Item.Visibility = ElementVisibility.Visible;
            //    anketaPageView.SelectedPage = rightholderPersonPage;

            //    contactsCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
            //    contactsPersonPage.Item.Visibility = ElementVisibility.Visible;

            //    managersPage.Item.Visibility = ElementVisibility.Collapsed;
            //    passportPage.Item.Visibility = ElementVisibility.Visible;
            //}

            ShowDialog();
        }

        public bool IsValid
        {

            get
            {
                var customer = (Customer)bsCustomer.Current;
                DirectorCustType director = new DirectorCustType(this, customer);
                return director.CurrentTypeCustomer.IsValidData();
                //var result = true;

                //if (customer.CustType == 3)
                //{
                //    result = ctrlAnketaCompanyRightholderPage.Validator() & ctrlMiddleControlManagers.Validator();
                //}
                //else if (customer.CustType == 5)
                //    result = true;
                //else
                //{
                //    result = ctrlAnketaPersonRightholderPage.Validator();
                //}

                //return result & ctrlServiceComissionControl.ValidateChildren(); // & ctrlContacts.Validator();
            }
        }

        public void SetHeader(string header)
        {
            Text = header + " - Анкета правовласника";
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

            if (customer == null)
                return;

            var agrMaster = customer.AgreementMaster.First();
            if (agrMaster == null) return;

            var templateName = IpsGlobal.AnketaDictionaties.agreementType.FirstOrDefault(item => item.CodeI == agrMaster.AgrType)?.TemplateName;
            if (string.IsNullOrEmpty(templateName))
                templateName = "F_ГО УААСП Автор.docx";

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", templateName);
            // var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_ГО УААСП Автор.docx");

            btnGenerateRightholderAgreement.Enabled = false;
            waitbarAgreement.StartWaiting();

            if(wordEngine == null)
                wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);
            wordEngine.ProcessRightHolder(template, customer, customer.AgreementMaster.First());

            if (wordEngine.ValidTemplate)
            {
                pdfvRightholderAgreement.LoadDocument(wordEngine.Pdf);

                _pdf = wordEngine.Pdf;
                _doc = wordEngine.Docx;
                _custName = CustomerUtility.CustomerName(customer);
                radPdfViewerNavigator1.Enabled = true;
            }
            waitbarAgreement.StopWaiting();

            btnGenerateRightholderAgreement.Enabled = true;
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if( IsValid == false )
            {
                MessageBox.Show("ПОМИЛКА ВАЛІДАЦІЇ ДАНИХ", "Перевірка даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _presenter.Save(accept: false);
        }

        private void miAcceptAndSave_Click(object sender, EventArgs e)
        {
            if (IsValid == false)
            {
                MessageBox.Show("Дані не пройшли валідацію", "Перевірка даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

        private void RightholderView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _presenter.Close();
            e.Cancel = true;
        }

        private void bsAgreementAddRh_BindingComplete(object sender, BindingCompleteEventArgs e)
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
            if (pageCatalog.SelectedPage == pageObjects && ctrlRightholdersObjectsRight.SelectedRightholder == null)
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

        
        /// <summary>
        /// define common class for all Types
        /// </summary>
        class DirectorCustType
        {
            //define current Customer type
            private ICustTypeCustomer _currentTypeCustomer;
            public ICustTypeCustomer CurrentTypeCustomer
            {
                get { return _currentTypeCustomer; }
            }

            //define necessary customer Type
            public DirectorCustType(RightholderView view, Customer customer)
            {
                //initialize customer type
                switch (customer.CustType)
                {
                    case 3:
                        _currentTypeCustomer = new JurFactoryCustomer(view, customer);
                        break;
                    case 5:
                        _currentTypeCustomer = new ExternalAnketaCustomer(view, customer);
                        break;
                    default:
                        _currentTypeCustomer = new DefaultCustomer(view, customer);
                        break;
                }
            }
        }
        
        /// <summary>
        /// define posibilities for Types of the customer
        /// </summary>
        public interface ICustTypeCustomer
        {
            //define first settings: set data source,
            //                       show certain pages
            void RunSetings();
            //check on valid state input data
            bool IsValidData();
            //show pages
            void ShowPages();
        }
        
        /// <summary>
        /// define class for CustType - 3
        /// </summary>
        class JurFactoryCustomer : ICustTypeCustomer
        {
            private RightholderView _rightholderView;
            //current customer
            private Customer _customer;
            public JurFactoryCustomer(RightholderView rightholderView, Customer customer)
            {
                _rightholderView = rightholderView;
                _customer = customer;
            }

            //define first settings: set data source,
            //                       show certain pages
            public void RunSetings()
            {
                _rightholderView.rightholderCompanyPage.Item.Visibility = ElementVisibility.Visible;
                _rightholderView.rightholderPersonPage.Item.Visibility = ElementVisibility.Collapsed;
                _rightholderView.anketaPageView.SelectedPage = _rightholderView.rightholderCompanyPage;

                _rightholderView.contactsCompanyPage.Item.Visibility = ElementVisibility.Visible;
                _rightholderView.contactsPersonPage.Item.Visibility = ElementVisibility.Collapsed;
                _rightholderView.ctrlMiddleControlAddress.SetDataSources(_customer);

                _rightholderView.managersPage.Item.Visibility = ElementVisibility.Visible;
                _rightholderView.passportPage.Item.Visibility = ElementVisibility.Collapsed;
                _rightholderView.ctrlMiddleControlManagers.SetDataSources(_customer);
            }

            //check on valid state input data
            public bool IsValidData()
            {
                bool result = _rightholderView.ctrlAnketaCompanyRightholderPage.Validator() & _rightholderView.ctrlMiddleControlManagers.Validator();
                return result & _rightholderView.ctrlServiceComissionControl.ValidateChildren();
            }

            //show pages
            public void ShowPages()
            {
                //get all pages
                foreach (var page in _rightholderView.pageCatalog.Pages)
                    //hide current page if it's: ExternalAnketa
                    if (_customer.CustType != 5 && page.Name == "AnketaExternal")
                        page.Item.Visibility = ElementVisibility.Collapsed;
            }
        }
        
        /// <summary>
        /// define class for CustType - 5
        /// </summary>
        class ExternalAnketaCustomer : ICustTypeCustomer
        {
            private RightholderView _rightholderView;
            //define customer
            private Customer _customer;
            public ExternalAnketaCustomer(RightholderView rightholderView, Customer customer)
            {
                _rightholderView = rightholderView;
                _customer = customer;
            }

            //define first settings: set data source,
            //                       show certain pages
            public void RunSetings()
            {
                //set default active page for External Anketa
                _rightholderView.pageCatalog.SelectedPage = _rightholderView.AnketaExternal;
                //set data of the External Anketa
                _rightholderView.anketaExternalRightholderControl1.DataSourceAnketaExternal = _rightholderView.bsAnketaExternal;
                _rightholderView.anketaExternalRightholderControl1.DataSourceRightHolder = _rightholderView.bsRightHolder;
            }
            
            //check on valid state input data
            public bool IsValidData()
            {
                bool result = true;
                return result & _rightholderView.ctrlServiceComissionControl.ValidateChildren();
            }

            //show necessary pages
            public void ShowPages()
            {
                foreach (var page in _rightholderView.pageCatalog.Pages)
                {
                    if (page.Name == "Anketa" || page.Name == "Contract")
                        page.Item.Visibility = ElementVisibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// define class for other CustType
        /// </summary>
        class DefaultCustomer : ICustTypeCustomer
        {
            private RightholderView _rightholderView;
            //define current Customer
            private Customer _customer;
            public DefaultCustomer(RightholderView rightholderView, Customer customer)
            {
                _rightholderView = rightholderView;
                _customer = customer;
            }

            //define first settings: set data source,
            //                       show certain pages
            public void RunSetings()
            {
                _rightholderView.rightholderCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
                _rightholderView.rightholderPersonPage.Item.Visibility = ElementVisibility.Visible;
                _rightholderView.anketaPageView.SelectedPage = _rightholderView.rightholderPersonPage;

                _rightholderView.contactsCompanyPage.Item.Visibility = ElementVisibility.Collapsed;
                _rightholderView.contactsPersonPage.Item.Visibility = ElementVisibility.Visible;

                _rightholderView.managersPage.Item.Visibility = ElementVisibility.Collapsed;
                _rightholderView.passportPage.Item.Visibility = ElementVisibility.Visible;
            }

            //check on valid state input data
            public bool IsValidData()
            {
                bool result = _rightholderView.ctrlAnketaPersonRightholderPage.Validator();
                return result & _rightholderView.ctrlServiceComissionControl.ValidateChildren();
            }

            //show necessary pages
            public void ShowPages()
            {
                //get all pages
                foreach (var page in _rightholderView.pageCatalog.Pages)
                    //hide current page if it's: ExternalAnketa
                    if (_customer.CustType != 5 && page.Name == "AnketaExternal")
                        page.Item.Visibility = ElementVisibility.Collapsed;
            }
        }
    }
}
