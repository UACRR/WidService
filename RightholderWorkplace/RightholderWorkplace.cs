using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using RightholderWorkplace.Localisation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using WebAPIConnector;

namespace RightholderWorkplace
{
    public partial class RightholderWorkplace : Telerik.WinControls.UI.RadForm, IRightholderForm
    {
        Customer _customer;
        ObjectRight _objectRight;

        AnketaPerson _anketa;
        BankAccount _bankAccount;
        AnketaDictionaties _dictionaries;
        ObjectRightDictionaries _dictionariesObjectRight;
        List<TermsOfServiceWrapper> _termsOfServices;
        RightHolder _rightHolder;

        #region IRightholderForm immplementation

        public Func<IList<RightholderMainView>> GetMainViewData { get; set; }
        public Func<int, Customer> NewCustomer { get; set; }
        public Func<int, Customer> GetCustomer { get; set; }
        public Func<Customer, bool> SaveCustomer { get; set; }

        public event Func<bool> Save;

        public void EndPresenterLink()
        {
            if (GetMainViewData != null)
            {
                var list = GetMainViewData();
                rightHolderMainViewBindingSource.DataSource = list;
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

            var columnCountry = gvTerritoryExclusions.Columns["CountryCode"] as GridViewComboBoxColumn;
            columnCountry.DataSource = dictionaries.country;
            columnCountry.ValueMember = "CountryCode";
            columnCountry.DisplayMember = "CountryName";
        }

        #endregion

        public RightholderWorkplace()
        {
            InitializeComponent();

            newRightholdersPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            ThemeResolutionService.ApplicationThemeName = "Office2013Light";
            RadGridLocalizationProvider.CurrentProvider = new RadGridViewUkraineLocalizationProvider();

            // data
            //anketaPersonBindingSource.DataSource = _anketa;
            //bankAccountBindingSource.DataSource = _bankAccount;

            ctrlAnketaPerson.DataSource = anketaPersonBindingSource;
            ctrlFaAddress.DataSource = anketaPersonBindingSource;
            ctrlContacts.DataSource = anketaPersonBindingSource;
            ctrlRegistrations.DataSource = anketaPersonBindingSource;
            ctrlInternalPassport.DataSource = anketaPersonBindingSource;
            //ctrlBankAccount.DataSource = _bankAccount;
            //ctrlExclusionsLimitations.DataSource = _termsOfServices;
            //gvTerritoryExclusions.DataSource = _rightHolder.TerritoryExclude;
            //cbAroundWorld.DataBindings.Add("Checked", _rightHolder, "AroundWord", true, DataSourceUpdateMode.OnPropertyChanged, false);
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

        #endregion

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

        private void cbAroundWorld_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            gvTerritoryExclusions.Enabled = !cbAroundWorld.Checked;
        }

        private void btnAddTerritoryExclude_Click(object sender, EventArgs e)
        {
            gvTerritoryExclusions.Rows.AddNew();

            var currentCell = gvTerritoryExclusions.CurrentRow.Cells[0];
            currentCell.IsSelected = true;
            currentCell.BeginEdit();
            var dropDownEditor = gvTerritoryExclusions.ActiveEditor as RadDropDownListEditor;
            if (dropDownEditor != null)
            {
                var element = dropDownEditor.EditorElement as RadDropDownListEditorElement;
                element.ShowPopup();
            }
        }

        private void btnRemoveTerritoryExclude_Click(object sender, EventArgs e)
        {
            gvTerritoryExclusions.Rows.Remove(gvTerritoryExclusions.CurrentRow);
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
            int custId = Convert.ToInt32(gvRightholdersList.CurrentRow.Cells["CustId"].Value);
            _customer = GetCustomer(custId);

            UpdateDataSources();
            //SetDataSources();
            //SetConsumerPageView();

            for (int i = 1; i < newCreateRightholderPageView.Pages.Count; i++)
            {
                newCreateRightholderPageView.Pages[i].Enabled = true;
            }

            newRightholdersPageView.SelectedPage = newRightholdersCreatePage;
            newCreateRightholderPageView.SelectedPage = createRightholderFullNameComissionPage;
        }

        private void gvRightholdersList_DoubleClick(object sender, EventArgs e)
        {
            gvRightholdersList_CommandCellClick(sender, null);
        }

        private void btnSaveRightholder_Click(object sender, EventArgs e)
        {
            if (_customer == null)
            {
                return;
            }

            // TODO: additional validation

            SaveCustomer?.Invoke(_customer);

            // TODO: move to single method (EndPresernterLink)
            var list = GetMainViewData();
            rightHolderMainViewBindingSource.DataSource = list;

            newRightholdersPageView.SelectedPage = newRightholdersListPage;
        }

        #endregion

        private void UpdateDataSources()
        {
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

            rightHolderBindingSource.DataSource = _customer.RightHolder;

            // if type of collection is HashSet, then adding new row is not allowed
            _customer.RightHolder.TerritoryExclude = _customer.RightHolder.TerritoryExclude.ToList();

            territoryExcludeBindingSource.DataSource = _customer.RightHolder.TerritoryExclude;
        }

        private void RightholderWorkplace_Load(object sender, EventArgs e)
        {
            var service = new ObjectRightService();

            _dictionariesObjectRight = service.GetDictionary();
            var objectsRightsList = service.GetMainView();
            var objectRightContainer = service.GetData(5848);
            _objectRight = objectRightContainer.objectRight;

            // dictionaries
            ddlGenreType.DataSource = _dictionariesObjectRight.genreType;
            ddlGenreType.ValueMember = "CodeI";
            ddlGenreType.DisplayMember = "Name";

            ddlSpecType.DataSource = _dictionariesObjectRight.specType;
            ddlSpecType.ValueMember = "CodeI";
            ddlSpecType.DisplayMember = "Name";

            var columnRoleAuth = gvObjectAuthors.Columns["RoleCode"] as GridViewComboBoxColumn;
            columnRoleAuth.DataSource = _dictionariesObjectRight.creativeRoleType;
            columnRoleAuth.ValueMember = "CodeI";
            columnRoleAuth.DisplayMember = "Name";

            var columnRoleRh = gvObjectRightholders.Columns["RoleCode"] as GridViewComboBoxColumn;
            columnRoleRh.DataSource = _dictionariesObjectRight.creativeRoleType;
            columnRoleRh.ValueMember = "CodeI";
            columnRoleRh.DisplayMember = "Name";

            var columnRh = gvObjectRightholders.Columns["CustId"] as GridViewComboBoxColumn;
            columnRh.DataSource = objectRightContainer.rhList;
            columnRh.ValueMember = "CustId";
            columnRh.DisplayMember = "Name";

            // update bidings
            gvObjectsRightsList.DataSource = objectsRightsList;
            objectRightBindingSource.DataSource = _objectRight;
            mediaTrackBindingSource.DataSource = _objectRight.MediaTrack;
            authorsBindingSource.DataSource = _objectRight.Authors;
            copyRightBindingSource.DataSource = _objectRight.CopyRight;
        }

        #region Object right commands

        private void btnSaveTest_Click(object sender, EventArgs e)
        {
            var service = new ObjectRightService();

            service.Save(_objectRight);
        }

        private void gvObjectAuthors_DoubleClick(object sender, EventArgs e)
        {
            using (var authorItemView = new AuthorItemView(authorsBindingSource, _dictionariesObjectRight))
            {
                authorItemView.StartPosition = FormStartPosition.CenterParent;
                authorItemView.ShowDialog();
                authorsBindingSource.ResetBindings(false);
            }
        }

        #endregion
    }
}
