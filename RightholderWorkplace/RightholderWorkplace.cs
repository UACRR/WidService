using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using RightholderWorkplace.Localisation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using WebAPIConnector;

namespace RightholderWorkplace
{
    public partial class RightholderWorkplace : Telerik.WinControls.UI.RadForm, IRightholderForm
    {
        Customer _customer;
        ObjectRight _objectRight;
        RightholderStatusType _rightholderStatusType;

        AnketaPerson _anketa;
        BankAccount _bankAccount;
        AnketaDictionaties _dictionaries;
        ObjectRightDictionaries _dictionariesObjectRight;
        List<TermsOfServiceWrapper> _termsOfServices;
        RightHolder _rightHolder;

        ObjectRightService _objectRightService = new ObjectRightService();

        #region IRightholderForm immplementation

        public Func<IList<RightholderMainView>> GetMainViewData { get; set; }
        public Func<RightholderStatusType, IList<RightholderMainView>> GetMainViewDataByStatus { get; set; }
        public Func<int, Customer> NewCustomer { get; set; }
        public Func<int, Customer> GetCustomer { get; set; }
        public Func<Customer, bool> SaveCustomer { get; set; }

        public event Func<bool> Save;

        public void EndPresenterLink()
        {
            if (GetMainViewData != null)
            {
                tbtnActive.IsChecked = true;
                RightholdersListFilterChanged(RightholderStatusType.Active);
            }
        }

        public void SetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        public void GetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        public void SetDictionary(AnketaDictionaties dictionaries)
        {
            _dictionaries = dictionaries;

            ctrlAnketaPerson.SexTypeDataSource = dictionaries.sexType;
            ctrlAnketaPerson.SexTypeValueMember = "CodeI";
            ctrlAnketaPerson.SexTypeDisplayMember = "Name";

            ctrlFaAddress.CountriesDataSource = dictionaries.country;
            ctrlFaAddress.CountriesValueMember = "CountryCode";
            ctrlFaAddress.CountriesDisplayMember = "CountryName";

            ctrlFaAddress.RegionsDataSource = dictionaries.region;
            ctrlFaAddress.RegionsValueMember = "CodeI";
            ctrlFaAddress.RegionsDisplayMember = "Name";

            ctrlReAddress.CountriesDataSource = dictionaries.country;
            ctrlReAddress.CountriesValueMember = "CountryCode";
            ctrlReAddress.CountriesDisplayMember = "CountryName";

            ctrlReAddress.RegionsDataSource = dictionaries.region;
            ctrlReAddress.RegionsValueMember = "CodeI";
            ctrlReAddress.RegionsDisplayMember = "Name";

            ctrlLeAddress.CountriesDataSource = dictionaries.country;
            ctrlLeAddress.CountriesValueMember = "CountryCode";
            ctrlLeAddress.CountriesDisplayMember = "CountryName";

            ctrlLeAddress.RegionsDataSource = dictionaries.region;
            ctrlLeAddress.RegionsValueMember = "CodeI";
            ctrlLeAddress.RegionsDisplayMember = "Name";

            ctrlRegistrations.CountriesDataSource = dictionaries.country;
            ctrlRegistrations.CountriesValueMember = "CountryCode";
            ctrlRegistrations.CountriesDisplayMember = "CountryName";

            ctrlRegistrations.ResidentTypesDataSource = dictionaries.residentType;
            ctrlRegistrations.ResidentTypesValueMember = "CodeI";
            ctrlRegistrations.ResidentTypesDisplayMember = "Name";

            ddlTypeMethodGet.DataSource = dictionaries.typeMethodGet;
            ddlTypeMethodGet.ValueMember = "CodeI";
            ddlTypeMethodGet.DisplayMember = "Name";

            ctrlBaAddress.RegionsDataSource = dictionaries.region;
            ctrlBaAddress.RegionsValueMember = "CodeI";
            ctrlBaAddress.RegionsDisplayMember = "Name";

            ctrlBaAddress.CountriesDataSource = dictionaries.country;
            ctrlBaAddress.CountriesValueMember = "CountryCode";
            ctrlBaAddress.CountriesDisplayMember = "CountryName";

            ctrlBaAddress.RegionsDataSource = dictionaries.region;
            ctrlBaAddress.RegionsValueMember = "CodeI";
            ctrlBaAddress.RegionsDisplayMember = "Name";

            ctrlExclusionsLimitations.CommunitiesDataSource = dictionaries.communities;
            ctrlTerritoryIncludeExclude.CountriesDataSource = dictionaries.country;
        }

        #endregion

        public RightholderWorkplace()
        {
            InitializeComponent();

            WireUpObjectsRightsPageEvents();

            newRightholdersPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            actualObjectsPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new RadGridViewUkraineLocalizationProvider();

            sbSaveRightholder.DefaultItem = miSaveRightholder;
            sbSaveRightholder.Text = miSaveRightholder.Text;

            // data
            //anketaPersonBindingSource.DataSource = _anketa;
            //bankAccountBindingSource.DataSource = _bankAccount;

            ctrlAnketaPerson.DataSourceAnketa = anketaPersonBindingSource;
            ctrlFaAddress.DataSource = anketaPersonBindingSource;
            ctrlContacts.DataSource = anketaPersonBindingSource;
            ctrlRegistrations.DataSource = anketaPersonBindingSource;
            ctrlInternalPassport.DataSource = anketaPersonBindingSource;
            ctrlInternationalPassport.DataSource = anketaPersonBindingSource;
            ctrlTerritoryIncludeExclude.DataSource = rightHolderBindingSource;
            //ctrlBankAccount.DataSource = _bankAccount;
            //ctrlExclusionsLimitations.DataSource = _termsOfServices;
            //gvTerritoryExclusions.DataSource = _rightHolder.TerritoryExclude;
            //cbAroundWorld.DataBindings.Add("Checked", _rightHolder, "AroundWord", true, DataSourceUpdateMode.OnPropertyChanged, false);
        }

        #region Rightholders page

        public RightholderMainView SelectedRightholder
        {
            get
            {
                return (gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView);
            }
            set { }
        }

        #region Next / Prev buttons

        private void btnNextAnketa_Click(object sender, EventArgs e)
        {
            if (ctrlAnketaPerson.Validator())
            {
                createRightholderAnketaPage.Enabled = true;
                newCreateRightholderPageView.SelectedPage = createRightholderAnketaPage;
            }
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
                createRightholderPassportPage.Enabled = true;
                newCreateRightholderPageView.SelectedPage = createRightholderPassportPage;
            }

        }

        private void btnPrevAnketa_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderAnketaPage;
        }

        private void btnNextRoyalty_Click(object sender, EventArgs e)
        {
            createRightholderRoyaltyPage.Enabled = true;
            newCreateRightholderPageView.SelectedPage = createRightholderRoyaltyPage;
        }

        private void btnPrevPassport_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderPassportPage;
        }

        private void btnNextExclusionLimitation_Click(object sender, EventArgs e)
        {
            createRightholderRigthLimitationsPage.Enabled = true;
            newCreateRightholderPageView.SelectedPage = createRightholderRigthLimitationsPage;
        }

        private void btnPrevRoyalty_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderRoyaltyPage;
        }

        private void btnNextTerritoryLimitation_Click(object sender, EventArgs e)
        {
            createRightholderTerritoryLimitationsPage.Enabled = true;
            newCreateRightholderPageView.SelectedPage = createRightholderTerritoryLimitationsPage;
        }

        private void btnPrevRightLimitation_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderRigthLimitationsPage;
        }

        private void btnNextAgreement_Click(object sender, EventArgs e)
        {
            createRightholderAgreementPage.Enabled = true;
            newCreateRightholderPageView.SelectedPage = createRightholderAgreementPage;
        }

        private void btnPrevTerritoryLimitation_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderTerritoryLimitationsPage;
        }

        #endregion

        private void newCreateRightholderPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (newCreateRightholderPageView.SelectedPage == createRightholderPassportPage)
            {
                if (_anketa.Citizenship == "804")
                    createRightholderPassportPageView.SelectedPage = createRightholderInternalPasportPage;
                else
                    createRightholderPassportPageView.SelectedPage = createRightholderForeignPassportPage;
            }
        }

        private void ddlTypeMethodGet_SelectedValueChanged(object sender, EventArgs e)
        {
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

        private void tbtn_Click(object sender, EventArgs e)
        {
            var rightholderFilterType = (RightholderStatusType)Convert.ToInt32((sender as RadToggleButton).Tag);
            RightholdersListFilterChanged(rightholderFilterType);
            
            // deselect all buttons, excluding sender
            foreach (var control in panelFilterButtons.Controls)
            {
                if (control != sender && control is RadToggleButton toggleButton)
                {
                    toggleButton.ToggleState = ToggleState.Off;
                }
            }
        }

        private void RightholdersListFilterChanged(RightholderStatusType rightholderStatusType)
        {
            _rightholderStatusType = rightholderStatusType;

            SetRightholdersListColumns();

            UpdateRightholdersList();
        }

        private void UpdateRightholdersList()
        {
            var list = GetMainViewDataByStatus(_rightholderStatusType);
            rightHolderMainViewBindingSource.DataSource = list;
        }

        private void SetRightholdersListColumns()
        {
            var editColumn = gvRightholdersList.Columns["EditColumn"];
            var acceptColumn = gvRightholdersList.Columns["AcceptColumn"];

            editColumn.IsVisible = true;
            acceptColumn.IsVisible = _rightholderStatusType != RightholderStatusType.Active;
        }

        private void gvRightholdersList_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            SetTooltipTextFromHeader(sender, e);
        }


        private async void btnGenerateRightholderAgreement_Click(object sender, EventArgs e)
        {
            if (_customer == null)
                return;

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_DOGOVIR-NA-UPRAVLINNYA-PRAVAMI-Avtora-2018-1_.docx");

            var wordEngine = new WordEngine(_dictionaries);

            btnGenerateRightholderAgreement.Enabled = false;
            waitbarAgreement.StartWaiting();

            await Task.Factory.StartNew(() => wordEngine.processRightHolder(template, _customer, _customer.AgreementMaster.First()));

            pdfvRightholderAgreement.LoadDocument(wordEngine.Pdf);

            waitbarAgreement.StopWaiting();
            btnGenerateRightholderAgreement.Enabled = true;
        }

        #region Rightolder commands

        private void miNewRightholderPerson_Click(object sender, EventArgs e)
        {
            _customer = NewCustomer(1);//3 - юр. 

            UpdateDataSources();

            for (int i = 1; i < newCreateRightholderPageView.Pages.Count; i++)
            {
                newCreateRightholderPageView.Pages[i].Enabled = false;
            }

            newRightholdersPageView.SelectedPage = newRightholdersCreatePage;
            newCreateRightholderPageView.SelectedPage = createRightholderFullNameComissionPage;
        }

        private void btnNewRightholderCancel1_Click(object sender, EventArgs e)
        {
            newRightholdersPageView.SelectedPage = newRightholdersListPage;
        }

        private void gvRightholdersList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                EditRightholder();
            }
            else if (currentColumnName == "ObjectListColumn")
            {
                ShowObjectsRightsForRightholder(SelectedRightholder);
            }
        }

        private void gvRightholdersList_DoubleClick(object sender, EventArgs e)
        {
            EditRightholder();
        }

        private void miSaveRightholder_Click(object sender, EventArgs e)
        {
            SaveRightholder(accept: false);
        }

        private void miAcceptAndSaveRightholder_Click(object sender, EventArgs e)
        {
            SaveRightholder(accept: true);
        }

        #endregion

        #region Rightholder page Helpers

        private void EditRightholder(RightholderMainView rightholder = null)
        {
            if (rightholder == null)
                rightholder = SelectedRightholder;

            _customer = GetCustomer(rightholder.CustId);

            UpdateDataSources();

            for (int i = 1; i < newCreateRightholderPageView.Pages.Count; i++)
            {
                newCreateRightholderPageView.Pages[i].Enabled = true;
            }

            MainPageView.SelectedPage = mainPageRightholders;
            newRightholdersPageView.SelectedPage = newRightholdersCreatePage;
            newCreateRightholderPageView.SelectedPage = createRightholderFullNameComissionPage;
            pdfvRightholderAgreement.UnloadDocument();
        }

        private void SaveRightholder(bool accept)
        {
            if (_customer == null)
            {
                return;
            }

            if (accept)
                _customer.Status = 2; // Активний

            // TODO: additional validation

            SaveCustomer?.Invoke(_customer);

            UpdateRightholdersList();

            newRightholdersPageView.SelectedPage = newRightholdersListPage;
        }

        #endregion

        #endregion

        private void UpdateDataSources()
        {
            ctrlAnketaPerson.DataSourceCustomer = _customer;
            _anketa = _customer.Person.AnketaPerson.Where( row => row.Version == _customer.AnkVersion ).SingleOrDefault();
            if (_customer.BankAccount.Any())
                _bankAccount = _customer.BankAccount.FirstOrDefault();
            else
            {
                _bankAccount = new BankAccount();
                _customer.BankAccount.Add(_bankAccount);
            }

            anketaPersonBindingSource.DataSource = _anketa;
            bankAccountBindingSource.DataSource = _bankAccount;
            ctrlExclusionsLimitations.DataSource = _customer.RightHolder.TermsOfService.Select( rec => new TermsOfServiceWrapper(rec));

            var agreement = _customer.AgreementMaster.FirstOrDefault();

            if (agreement != null)
            {
                agreementMasterBindingSource.DataSource = agreement;

                agreementAddRhBindingSource.DataSource = agreement.AgreementAddRh;
            }
            else
            {
                agreement = new AgreementMaster();
                _customer.AgreementMaster.Add(agreement);
            }

            // if type of collection is HashSet, then adding new row is not allowed
            _customer.RightHolder.TerritoryExclude = _customer.RightHolder.TerritoryExclude.ToList();
            _customer.RightHolder.TerritoryInclude = _customer.RightHolder.TerritoryInclude.ToList();

            rightHolderBindingSource.DataSource = _customer.RightHolder;
        }

        private void RightholderWorkplace_Load(object sender, EventArgs e)
        {
            _dictionariesObjectRight = _objectRightService.GetDictionary();

            SetObjectRightDictionaries();

            UpdateObjectRightsList();
        }

        #region Objectrights page

        public ObjectRightMainView SelectedObjectRight
        {
            get
            {
                return gvObjectsRightsList.CurrentRow.DataBoundItem as ObjectRightMainView;
            }
            set
            {
                var row = gvObjectsRightsList.Rows.FirstOrDefault(r => (int)r.Cells["ObjId"].Value == value.ObjId);
                if (row != null)
                {
                    gvObjectsRightsList.CurrentRow = row;
                }
            }
        }

        public ObjectAuthorRightholder SelectedObjectAuthorRightholder
        {
            get
            {
                return gvObjectAuthorsRightholders.CurrentRow.DataBoundItem as ObjectAuthorRightholder;
            }
            set { }
        }

        private void SetObjectRightDictionaries()
        {
            ddlSpecType.DataSource = _dictionariesObjectRight.specType;
            ddlSpecType.ValueMember = "CodeI";
            ddlSpecType.DisplayMember = "Name";

            var columnRoleCode = gvObjectAuthorsRightholders.Columns["RoleCode"] as GridViewComboBoxColumn;
            columnRoleCode.DataSource = _dictionariesObjectRight.creativeRoleType;
            columnRoleCode.ValueMember = "CodeI";
            columnRoleCode.DisplayMember = "Name";

            var columnFolkType = gvObjectAuthorsRightholders.Columns["FolkType"] as GridViewComboBoxColumn;
            columnFolkType.DataSource = _dictionariesObjectRight.folkType;
            columnFolkType.ValueMember = "CodeI";
            columnFolkType.DisplayMember = "Name";

            //var columnCopyrightStatus = gvObjectAuthorsRightholders.Columns["CopyrightStatus"] as GridViewCheckBoxColumn;
            //columnCopyrightStatus.NullValue = false;
            //columnCopyrightStatus.DataSourceNullValue = false;
        }

        private void SetAvalaibleGenres(int category)
        {
            ddlGenreType.DataSource = _dictionariesObjectRight.genreType.Where(g => g.CategoryCode == category);
            ddlGenreType.ValueMember = "CodeI";
            ddlGenreType.DisplayMember = "Name";
        }

        private void WireUpObjectsRightsPageEvents()
        {
            ctrlRightholderSelector.RightholderChanged += CtrlRightholderSelector_RightholderChanged;
            ctrlRightholderSelector.ShowAnketaCommandExecuted += CtrlRightholderSelector_ShowAnketaCommandExecuted;
        }

        private void CtrlRightholderSelector_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            var rigthholdersObjectsRightsList = _objectRightService.GetRightholdersObjectsRights(selectedRightholder.CustId);

            objectRightForRightholderBindingSource.DataSource = rigthholdersObjectsRightsList;
        }

        private void CtrlRightholderSelector_ShowAnketaCommandExecuted(object sender, EventArgs e)
        {
            if (ctrlRightholderSelector.Rightholder != null)
                EditRightholder(ctrlRightholderSelector.Rightholder);
        }

        #region Objectrights list event handlers

        private void miAddMusicalComposition_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                int category;
                if (int.TryParse(menuItem.Tag.ToString(), out category))
                {
                    AddObjectRight(category);
                }
            }
        }

        private void AddObjectRight(int category)
        {
            if (category == 0)
                return;

            _objectRight = _objectRightService.NewObjectRight(category);

            SetAvalaibleGenres(category);
            UpdateObjectRightDataSources(_objectRight, null);

            MainPageView.SelectedPage = mainPageRightsObjects;
            objectsPageView.SelectedPage = actualObjectsPage;
            actualObjectsPageView.SelectedPage = actualObjectsItemPage;
        }

        private void gvObjectsRightsList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                EditObjectRight();
            }
        }

        private void gvObjectsRightsList_DoubleClick(object sender, EventArgs e)
        {
            EditObjectRight();
        }

        private void EditObjectRight()
        {
            var objectRightContainer = _objectRightService.GetData(SelectedObjectRight.ObjId);

            SetAvalaibleGenres(objectRightContainer.objectRight.CategoryCode);
            UpdateObjectRightDataSources(objectRightContainer.objectRight, objectRightContainer.rhList);

            CalculateTotalPersent();

            MainPageView.SelectedPage = mainPageRightsObjects;
            objectsPageView.SelectedPage = actualObjectsPage;
            actualObjectsPageView.SelectedPage = actualObjectsItemPage;
        }

        private void UpdateObjectRightDataSources(ObjectRight objectRight, IList<ViewCustomer> rightholders)
        {
            _objectRight = objectRight;

            if (rightholders == null)
                rightholders = new List<ViewCustomer>();

            objectRightBindingSource.DataSource = _objectRight;
            mediaTrackBindingSource.DataSource = _objectRight.MediaTrack;

            // transform Authors and Copyright table into single table
            var objectAuthorRightholderList = _objectRight.Authors.Select(a =>
            {

                var foundedCopyright = _objectRight.CopyRight.FirstOrDefault(c => c.CustId == a.CustId);
                var foundedRightholder = rightholders.FirstOrDefault(r => r.custId == a.CustId);

                return new ObjectAuthorRightholder
                {
                    AuthId = a.AuthId,
                    ObjId = a.ObjId,
                    RoleCode = a.RoleCode,
                    FolkType = a.FolkType,
                    AuthorName = a.AuthorName,
                    IsRightholder = a.CustId != null,
                    CustId = a.CustId,
                    CRightId = foundedCopyright?.CRightId,
                    CopyrightStatus = foundedCopyright?.Status,
                    CommunityName = foundedRightholder?.Community_Name,
                    Rate = foundedCopyright?.Rate,
                    BeginDate = foundedCopyright?.BeginDate,
                    EndDate = foundedCopyright?.EndDate,
                };
            }).ToList();

            objectAuthorRightholderBindingSource.DataSource = objectAuthorRightholderList;
        }

        #endregion

        #region Objectrights item event handlers

        private void gvObjectAuthorsRightholders_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                EditObjectAuthorRightholder();
            }
            else if (currentColumnName == "DeleteColumn")
            {
                DeleteObjectAuthorRightholder();
            }
        }

        private void gvObjectAuthorsRightholders_DoubleClick(object sender, EventArgs e)
        {
            EditObjectAuthorRightholder();
        }

        private void btnAddAuthorRightholder_Click(object sender, EventArgs e)
        {
            var objectAuthorRightholder = new ObjectAuthorRightholder();
            EditObjectAuthorRightholder(objectAuthorRightholder);
        }

        private void btnObjectRightItemCancel_Click(object sender, EventArgs e)
        {
            actualObjectsPageView.SelectedPage = actualObjectsListPage;
        }

        private void btnObjectRightItemSave_Click(object sender, EventArgs e)
        {
            if (_objectRight == null)
            {
                return;
            }

            // transform from single table to Authors and Copyright tables
            var objectAuthorRightholderList = objectAuthorRightholderBindingSource.List.Cast<ObjectAuthorRightholder>().ToList();

            _objectRight.Authors = objectAuthorRightholderList.Select(ar =>
            {
                return new Authors
                {
                    AuthId = ar.AuthId,
                    ObjId = ar.ObjId,
                    RoleCode = ar.RoleCode,
                    CustId = ar.CustId,
                    AuthorName = ar.AuthorName,
                    FolkType = ar.FolkType,
                };
            }).ToList();

            _objectRight.CopyRight = objectAuthorRightholderList
                .Where(ar => ar.IsRightholder)
                .Select(ar =>
                {
                    return new CopyRight
                    {
                        CRightId = ar.CRightId ?? 0,
                        CustId = (int)ar.CustId,
                        ObjId = ar.ObjId,
                        Rate = ar.Rate,
                        BeginDate = ar.BeginDate,
                        EndDate = ar.EndDate,
                        Status = ar.CopyrightStatus,
                    };
                }).ToList();

            if (_objectRight.CopyRight.Where(cr => cr.Rate != null).Sum(cr => cr.Rate) > 100)
            {
                MessageBox.Show("Загальний відсоток володіння не може бути більше 100.", "Помилка");
                return;
            }

            _objectRightService.Save(_objectRight);

            UpdateObjectRightsList();

            SelectedObjectRight = new ObjectRightMainView { ObjId = _objectRight.ObjId };

            actualObjectsPageView.SelectedPage = actualObjectsListPage;
        }


        private void gvObjectAuthorsRightholders_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            SetTooltipTextFromHeader(sender, e);
        }

        #endregion

        #region Objectrights page helpers

        private void UpdateObjectRightsList()
        {
            var objectsRightsList = _objectRightService.GetMainView();

            gvObjectsRightsList.DataSource = objectsRightsList;
        }

        private void ShowObjectsRightsForRightholder(RightholderMainView selectedRightholder)
        {
            MainPageView.SelectedPage = mainPageRightsObjects;
            objectsPageView.SelectedPage = rightholdersObjectsPage;

            ctrlRightholderSelector.Rightholder = selectedRightholder;
        }

        private void EditObjectAuthorRightholder(ObjectAuthorRightholder objectAuthorRightholder = null)
        {
            if (objectAuthorRightholder == null)
                objectAuthorRightholder = SelectedObjectAuthorRightholder;


            using (var authorRightholderItemView = new AuthorRightholderItemView(objectAuthorRightholder, _dictionariesObjectRight, _objectRight.CategoryCode))
            {
                objectAuthorRightholderBindingSource.RaiseListChangedEvents = false;

                authorRightholderItemView.StartPosition = FormStartPosition.CenterParent;
                authorRightholderItemView.ShowDialog();

                objectAuthorRightholderBindingSource.RaiseListChangedEvents = true;

                if (authorRightholderItemView.DialogResult == DialogResult.OK && objectAuthorRightholderBindingSource.IndexOf(objectAuthorRightholder) == -1)
                {
                    objectAuthorRightholderBindingSource.Add(objectAuthorRightholder);
                }

                CalculateTotalPersent();
            }

            MainPageView.SelectedPage = mainPageRightsObjects;
            objectsPageView.SelectedPage = actualObjectsPage;
            actualObjectsPageView.SelectedPage = actualObjectsItemPage;
        }

        private void DeleteObjectAuthorRightholder()
        {
            objectAuthorRightholderBindingSource.Remove(SelectedObjectAuthorRightholder);
            CalculateTotalPersent();
        }

        private void CalculateTotalPersent()
        {
            var list = objectAuthorRightholderBindingSource.List.Cast<ObjectAuthorRightholder>();

            var totalPersent = list.Where(ar => ar.Rate != null).Sum(s => s.Rate);

            txtTotalPersent.Text = totalPersent.ToString();

            if (totalPersent > 100)
                txtTotalPersent.ForeColor = Color.Red;
            else
                txtTotalPersent.ForeColor = SystemColors.ControlText;
        }

        #endregion

        #endregion

        #region Common Helpers

        private static void SetTooltipTextFromHeader(object sender, ToolTipTextNeededEventArgs e)
        {
            if (sender is GridHeaderCellElement headerCell)
            {
                e.ToolTipText = headerCell.Text;
            }
        }

        #endregion
    }
}
