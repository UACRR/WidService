using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
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
        AnketaPerson _anketa;
        BankAccount _bankAccount;
        AnketaDictionaties _dictionaries;
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
            //throw new NotImplementedException();
        }

        public void SetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        public void GetData(ICustomer data)
        {
            throw new NotImplementedException();
        }

        public void SetDictionary(AnketaDictionaties dic)
        {
            //throw new NotImplementedException();
        }

        #endregion

        public RightholderWorkplace()
        {
            InitializeComponent();

            newRightholdersPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

            ThemeResolutionService.ApplicationThemeName = "Office2007Silver";

            //debug
            //rightholdersPageView.SelectedPage = newRightholdersPage;
            //newRightholdersPageView.SelectedPage = newRightholdersCreatePage;
        }

        #region Next / Prev buttons

        private void btnNextAnketa_Click(object sender, EventArgs e)
        {
            if (ctrlAnketaPerson.Validator())
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
            newCreateRightholderPageView.SelectedPage = createRightholderRigthLimitationsPage;
        }

        private void btnPrevRoyalty_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderRoyaltyPage;
        }

        private void btnNextTerritoryLimitation_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderTerritoryLimitationsPage;
        }

        private void btnPrevRightLimitation_Click(object sender, EventArgs e)
        {
            newCreateRightholderPageView.SelectedPage = createRightholderRigthLimitationsPage;
        }

        #endregion

        private void RightholderWorkplace_Load(object sender, EventArgs e)
        {
            var connector = new ApiConnector("http://localhost:54867/");
            _dictionaries = connector.GetItemById<AnketaDictionaties>("api/Dictionary", "anketa");
            var customer = connector.GetItemById<Customer>("api/rh/detail", "140");
            _anketa = customer.AnketaPerson.SingleOrDefault();

            //// fake data
            //_anketa = new AnketaPerson
            //{
            //    LastName = "LastName",
            //    FirstName = "FirstName",
            //    SurName = "SurName",
            //    NikName = "NikName",
            //    BirthDate = new DateTime(2000, 08, 17),
            //    Sex = 2,
            //    PhoneMobileMain = "+380501111111",
            //    Inn = "1234567890",
            //    Citizenship = "1",
            //    Residency = 1,
            //    PUseries = "ПС",
            //    PUnumber = "973179",
            //    PUissuedWho = "PUissuedWho",
            //    PUissuedWhen = new DateTime(2005, 7, 10),
            //    FaCountry = "804",
            //    FaRegion = 25,
            //    FaCity = "FaCity",
            //    FaAddress = "FaAddress",
            //    ReCountry = "804",
            //    ReRegion = 25,
            //    ReCity = "ReCity",
            //    ReAddress = "ReAddress",
            //    LeCountry = "804",
            //    LeRegion = 25,
            //    LeCity = "LeCity",
            //    LeAddress = "LeAddress",
            //};

            _bankAccount = new BankAccount
            {
                AccountNumber = "ac",
                Mfo = 380380,
                MfoName = "Mfo name",
                MfoOkpo = "okpo",
                TransitNumber = "tr num",
                PCountry = "804",
                PRegion = 25,
                PCity = "PCity",
                PAddress = "PAddress",
                PIndex = "20800",
            };

            _termsOfServices = new List<TermsOfServiceWrapper>
            {
                new TermsOfServiceWrapper(new TermsOfService { OurService = true,
                    CrkindCodeNavigation = new CopyrightKind { Name = "Name 1",
                        CrGroupCodeNavigation = new CrkindGroup { Name = "Groupe 1" },
                    },
                }),
            };

            _rightHolder = new RightHolder();
            _rightHolder.AroundWord = false;
            _rightHolder.TerritoryExclude = new List<TerritoryExclude>
            {
                new TerritoryExclude { CountryCode = "826" },
                new TerritoryExclude { CountryCode = "024" },
            };

            // dictionaries
            ctrlAnketaPerson.SexTypeDataSource = _dictionaries.sexType;
            ctrlAnketaPerson.SexTypeValueMember = "CodeI";
            ctrlAnketaPerson.SexTypeDisplayMember = "Name";

            ctrlFaAddress.CountriesDataSource = _dictionaries.country;
            ctrlFaAddress.CountriesValueMember = "CountryCode";
            ctrlFaAddress.CountriesDisplayMember = "CountryName";

            ctrlFaAddress.RegionsDataSource = _dictionaries.region;
            ctrlFaAddress.RegionsValueMember = "CodeI";
            ctrlFaAddress.RegionsDisplayMember = "Name";

            ctrlReAddress.CountriesDataSource = _dictionaries.country;
            ctrlReAddress.CountriesValueMember = "CountryCode";
            ctrlReAddress.CountriesDisplayMember = "CountryName";

            ctrlReAddress.RegionsDataSource = _dictionaries.region;
            ctrlReAddress.RegionsValueMember = "CodeI";
            ctrlReAddress.RegionsDisplayMember = "Name";

            ctrlLeAddress.CountriesDataSource = _dictionaries.country;
            ctrlLeAddress.CountriesValueMember = "CountryCode";
            ctrlLeAddress.CountriesDisplayMember = "CountryName";

            ctrlLeAddress.RegionsDataSource = _dictionaries.region;
            ctrlLeAddress.RegionsValueMember = "CodeI";
            ctrlLeAddress.RegionsDisplayMember = "Name";

            ctrlRegistrations.CountriesDataSource = _dictionaries.country;
            ctrlRegistrations.CountriesValueMember = "CountryCode";
            ctrlRegistrations.CountriesDisplayMember = "CountryName";

            ctrlRegistrations.ResidentTypesDataSource = _dictionaries.residentType;
            ctrlRegistrations.ResidentTypesValueMember = "CodeI";
            ctrlRegistrations.ResidentTypesDisplayMember = "Name";

            ddlTypeMethodGet.DataSource = _dictionaries.typeMethodGet;
            ddlTypeMethodGet.ValueMember = "getCode";
            ddlTypeMethodGet.DisplayMember = "getName";

            ctrlBaAddress.RegionsDataSource = _dictionaries.region;
            ctrlBaAddress.RegionsValueMember = "CodeI";
            ctrlBaAddress.RegionsDisplayMember = "Name";

            ctrlBaAddress.CountriesDataSource = _dictionaries.country;
            ctrlBaAddress.CountriesValueMember = "CountryCode";
            ctrlBaAddress.CountriesDisplayMember = "CountryName";

            ctrlBaAddress.RegionsDataSource = _dictionaries.region;
            ctrlBaAddress.RegionsValueMember = "CodeI";
            ctrlBaAddress.RegionsDisplayMember = "Name";

            //gvTerritoryExclusions.AutoGenerateColumns = false;
            //var columnCountry = new GridViewComboBoxColumn();
            //gvTerritoryExclusions.Columns.Add(columnCountry);

            var col = gvTerritoryExclusions.Columns["CountryCode"] as GridViewComboBoxColumn;
            col.DataSource = _dictionaries.country;
            col.ValueMember = "CountryCode";
            col.DisplayMember = "CountryName";

            // data
            anketaPersonBindingSource.DataSource = _anketa;
            bankAccountBindingSource.DataSource = _bankAccount;

            ctrlAnketaPerson.DataSource = _anketa;
            ctrlFaAddress.DataSource = _anketa;
            ctrlContacts.DataSource = _anketa;
            ctrlRegistrations.DataSource = _anketa;
            ctrlInternalPassport.DataSource = _anketa;
            ctrlBankAccount.DataSource = _bankAccount;
            ctrlExclusionsLimitations.DataSource = _termsOfServices;
            gvTerritoryExclusions.DataSource = _rightHolder.TerritoryExclude;
            cbAroundWorld.DataBindings.Add("Checked", _rightHolder, "AroundWord", true, DataSourceUpdateMode.OnPropertyChanged, false);

            RadGridLocalizationProvider.CurrentProvider = new RadGridViewUkraineLocalizationProvider();
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
            ////TODO: move to selected value changed event
            //if (ddlTypeMethodGet.SelectedIndex == 0)
            //    createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyCashPage;
            //else if (ddlTypeMethodGet.SelectedIndex == 1)
            //    createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyBankPage;
            //else if (ddlTypeMethodGet.SelectedIndex == 2 || ddlTypeMethodGet.SelectedIndex == 3)
            //    createRightholderRoyaltyPageView.SelectedPage = createRightholderRoyaltyPostalTransfer;
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

        #region Rightolders list commands

        private void miNewRightholderPerson_Click(object sender, EventArgs e)
        {
            newRightholdersPageView.SelectedPage = newRightholdersCreatePage;
        }

        private void btnNewRightholderCancel1_Click(object sender, EventArgs e)
        {
            newRightholdersPageView.SelectedPage = newRightholdersListPage;
        }

        #endregion
    }
}
