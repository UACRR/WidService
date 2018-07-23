using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.RightholderControls;
using IpsViewComponentLibrary.Utilities;
using RightholderWorkplace.Localisation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace RightholderWorkplace
{
    public partial class RightholderWorkplace : Telerik.WinControls.UI.RadForm, IRightholderForm
    {
        Customer _customer;
        RightholderStatusType _rightholderStatusType;

        AnketaPerson _anketa;
        BankAccount _bankAccount;
        AnketaDictionaties _dictionaries;
        List<TermsOfServiceWrapper> _termsOfServices;
        RightHolder _rightHolder;

        RightholderService _rightholderService = new RightholderService();
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

            newRightholdersPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderPassportPageView.ViewElement.Visibility = ElementVisibility.Hidden;
            createRightholderRoyaltyPageView.ViewElement.Visibility = ElementVisibility.Hidden;

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
            set
            {
                var row = gvRightholdersList.Rows.FirstOrDefault(r => (int)r.Cells["CustId"].Value == value.CustId);
                if (row != null)
                {
                    gvRightholdersList.CurrentRow = row;
                    gvRightholdersList.TableElement.ScrollToRow(row);
                }
            }
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

            UpdateRightholdersList();
        }

        private void UpdateRightholdersList(RightholderMainView selectedRightholder = null)
        {
            var list = GetMainViewDataByStatus(_rightholderStatusType);
            rightHolderMainViewBindingSource.DataSource = list;

            if (selectedRightholder != null)
            {
                SelectedRightholder = selectedRightholder;
            }
        }

        private void gvRightholdersList_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            IpsViewComponentLibrary.Utilities.GridViewHelper.SetTooltipTextForColumnHeader(sender, e);
        }


        private async void btnGenerateRightholderAgreement_Click(object sender, EventArgs e)
        {
            if (_customer == null)
                return;

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_DOGOVIR-NA-UPRAVLINNYA-PRAVAMI-Avtora-2018-1_.docx");

            btnGenerateRightholderAgreement.Enabled = false;
            waitbarAgreement.StartWaiting();

            var wordEngine = new WordEngine(_dictionaries);
            await wordEngine.processRightHolder(template, _customer, _customer.AgreementMaster.First());

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
            else if (currentColumnName == "SetStatusColumn")
            {
                ShowChangeRightholderStatusMenu();
            }
            else if (currentColumnName == "AcceptColumn")
            {
                _rightholderService.SetStatus(SelectedRightholder.CustId, RightholderStatusType.Active);
                UpdateRightholdersList();
            }
        }

        private void ShowChangeRightholderStatusMenu()
        {
            var rightholder = gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;

            if (rightholder != null)
            {
                Point absolutePosition = gvRightholdersList.CurrentCell.PointToScreen(gvRightholdersList.CurrentCell.Location);
                absolutePosition.Y += gvRightholdersList.CurrentCell.Size.Height;

                var menu = RightholderStatusMenuFactory.Create((RightholderStatusType)rightholder.Status, RightholderStatusMenu_Click);
                menu.Show(absolutePosition);
            }
        }

        private void RightholderStatusMenu_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                var newStatus = (RightholderStatusType)menuItem.Tag;

                var result = _rightholderService.SetStatus(SelectedRightholder.CustId, newStatus);

                if (result)
                    UpdateRightholdersList();
                else
                    MessageBox.Show("Не вдалося змінити статус.", "Помилка");
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
            rightholdersPageView.SelectedPage = rightholdersPage;
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
                agreementAddRhBindingSource.DataSource = agreement.AgreementAddRh;
            }
            else
            {
                agreement = new AgreementMaster();
                _customer.AgreementMaster.Add(agreement);
                var agreementAddRh = new AgreementAddRh();
                agreement.AgreementAddRh.Add(agreementAddRh);

                agreementAddRhBindingSource.DataSource = agreementAddRh;
            }

            // if type of collection is HashSet, then adding new row is not allowed
            _customer.RightHolder.TerritoryExclude = _customer.RightHolder.TerritoryExclude;
            _customer.RightHolder.TerritoryInclude = _customer.RightHolder.TerritoryInclude;

            rightHolderBindingSource.DataSource = _customer.RightHolder;
        }

        private void RightholderWorkplace_Load(object sender, EventArgs e)
        {
            // Change rightholders page init
            GridViewRelation relation = new GridViewRelation(gvChangeCopyrights.MasterTemplate, gvChangeCopyrightsTemplate);
            relation.RelationName = "RightholdersObjects";
            relation.ParentColumnNames.Add("ObjId");
            relation.ChildColumnNames.Add("ObjId");
            gvChangeCopyrights.Relations.Add(relation);

            dtChangeCopyrightDateFrom.Value = DateTime.Now;
            dtChangeCopyrightDateTill.Value = DateTime.Now;

            ctrlChangeRightholderOperation.SelectedValue = 3;
        }

        #region Objectrights page

        private RadPageViewPage _previousPage;

        #region Objectrights list event handlers

        private void miAddMusicalComposition_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                int category;
                if (int.TryParse(menuItem.Tag.ToString(), out category))
                {
                    // TODO: move to presenter
                    AddObjectRight(category);
                }
            }
        }

        private void AddObjectRight(int category, RightholderMainView defaultRightholder = null)
        {
            if (category == 0)
                return;

            _previousPage = objectsPageView.SelectedPage; // TODO

            using (var view = new ObjectRightSrView())
            {
                var presenter = new ObjectRightSrPresenter(view);
                presenter.DefaultRightholder = defaultRightholder;
                presenter.ShowNew(category);
            }

            UpdateLists(0);
        }

        private void ctrlObjectRightList_EditCommandExecuted(object sender, ObjectRightMainView selectedObject)
        {
            EditObjectRight(selectedObject.ObjId);
        }

        private void ctrlObjectRightList_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            EditObjectRight(selectedObject.ObjId);
        }

        private void EditObjectRight(int objId)
        {
            _previousPage = objectsPageView.SelectedPage; // TODO

            using (var view = new ObjectRightSrView())
            {
                var presenter = new ObjectRightSrPresenter(view);
                presenter.Show(objId);
            }

            UpdateLists(objId);
        }

        private void UpdateLists(int objId)
        {
            // TODO: Update list using broadcast event {
            if (_previousPage == actualObjectsPage)
            {
                ctrlObjectRightList.UpdateList(new ObjectRightMainView { ObjId = objId });
                ctrlRightholdersObjectsRight.UpdateList();
            }
            else if (_previousPage == rightholdersObjectsPage)
            {
                ctrlRightholdersObjectsRight.UpdateList(new ObjectRightForRightholder { ObjId = objId });
                ctrlObjectRightList.UpdateList();
            }

            UpdateRightholdersList(SelectedRightholder);
            // } TODO
        }

        #endregion

        #region Rightholders objectrights list event handlers

        private void ctrlRightholdersObjectsRight_EditObjectCommandExecuted(object sender, ObjectRightForRightholder selectedObject)
        {
            EditObjectRight(selectedObject.ObjId);
        }

        private void ctrlRightholdersObjectsRight_ShowAnketaCommandExetuted(object sender, RightholderMainView selectedRightholder)
        {
            EditRightholder(selectedRightholder);
        }

        private void miAddMusicalCompositionForRightholder_Click(object sender, EventArgs e)
        {
            if (!IsRightholderSelected())
                return;

            if (sender is RadMenuItem menuItem)
            {
                int category;
                if (int.TryParse(menuItem.Tag.ToString(), out category))
                {
                    // TODO: move to presenter
                    AddObjectRight(category, ctrlRightholdersObjectsRight.SelectedRightholder);
                }
            }
        }

        private void btnAddExistingObjectRightForRightholder_Click(object sender, EventArgs e)
        {
            if (!IsRightholderSelected())
                return;

            // TODO: move to presenter
            using (var selectionView = new ObjectRightSelectionView())
            {
                selectionView.ObjectSelected += SelectionView_ObjectSelected;
                selectionView.ShowDialog();
            }
        }

        private void SelectionView_ObjectSelected(object sender, ObjectRightMainView selectedObject)
        {
            var selectedRightholder = ctrlRightholdersObjectsRight.SelectedRightholder;
            var objectRightContainer = _objectRightService.GetData(selectedObject.ObjId);
            var objectRight = objectRightContainer.objectRight;
            
            if (objectRight.CopyRight.GetTotalRate() >= 100)
            {
                MessageBox.Show("Спільний відсоток володіння для вибраного об'єкта вже становить 100%.");
                return;
            }

            //if (objectRight.CopyRight.Any(cr => cr.CustId == selectedRightholder.CustId))
            //{
            //    // може бути, що додається копірайт для цього ж об'єкта, але по іншій творчій ролі - треба подумати
            //    MessageBox.Show("");
            //    return;
            //}

            var objectAuthorRightholder = new ObjectAuthorRightholder(selectedRightholder);

            using (var authorRightholderItemView = new AuthorRightholderItemView(objectAuthorRightholder, _objectRightService.GetDictionary(), objectRight.CategoryCode))
            {
                authorRightholderItemView.ShowDialog();

                if (authorRightholderItemView.DialogResult == DialogResult.OK)
                {
                    objectRight.AddObjectAuthorRightholder(objectAuthorRightholder);
                }

                if (objectRight.CopyRight.GetTotalRate() > 100)
                {
                    MessageBox.Show("Спільний відсоток володіння з врахуванням доданого перевищує 100%. Об'єкт не доданий.");
                    return;
                }

                var result = _objectRightService.Save(objectRight);

                if (result)
                {
                    ctrlRightholdersObjectsRight.UpdateList(new ObjectRightForRightholder { ObjId = objectRight.ObjId });
                    ctrlObjectRightList.UpdateList();
                }
                else
                    MessageBox.Show("Не вдалося зберегти зміни. Об'єкт не доданий.", "Помилка");
            }
        }

        private bool IsRightholderSelected()
        {
            if (ctrlRightholdersObjectsRight.SelectedRightholder == null)
            {
                MessageBox.Show("Оберіть правовласника.");
                return false;
            }

            return true;
        }

        #endregion

        #region Objectrights page helpers

        private void ShowObjectsRightsForRightholder(RightholderMainView selectedRightholder)
        {
            MainPageView.SelectedPage = mainPageRightsObjects;
            objectsPageView.SelectedPage = rightholdersObjectsPage;

            ctrlRightholdersObjectsRight.SelectedRightholder = selectedRightholder;
        }

        #endregion

        #endregion

        #region Change rightholders page

        private BindingList<ObjectCopyright> _objectsCopyrightList = new BindingList<ObjectCopyright>();

        private void ctrlRightholdersObjectsForChange_RightholderChanged(object sender, RightholderMainView selectedRightholder)
        {
            objectRightForChangeBindingSource.DataSource = ctrlRightholdersObjectsForChange.ObjectsRightsList;
            _objectsCopyrightList.Clear();
            objectCopyrightBindingSource.DataSource = _objectsCopyrightList;
        }

        private void ctrlChangeRightholderOperation_SelectedValueChanged(object sender, EventArgs e)
        {
            var isTransfer = ctrlChangeRightholderOperation.SelectedValue == 5;
            var isDeath = ctrlChangeRightholderOperation.SelectedValue == 3;

            lblChangeCopyrightDateTill.Visible = isTransfer;
            dtChangeCopyrightDateTill.Visible = isTransfer;
        }

        private void btnAddNewRightholder_Click(object sender, EventArgs e)
        {
            if (ctrlRightholdersObjectsForChange.SelectedRightholder == null)
            {
                MessageBox.Show("Виберіть правовласника, чиї об'єкти треба передати.");
                return;
            }
            if (ctrlRightholdersObjectsForChange.SelectedRightholder != null && ctrlRightholdersObjectsForChange.ObjectsRightsList.Count == 0)
            {
                MessageBox.Show("У вибраного правовласника відсутні об'єкти для передачі.");
                return;
            }

            using (var selectionView = new RightholderSelectionView())
            {
                selectionView.RightholderSelected += SelectionView_RightholderSelected;
                selectionView.ShowDialog();
            }
        }

        private void SelectionView_RightholderSelected(object sender, RightholderMainView addedRightholder)
        {
            if (ctrlRightholdersObjectsForChange.SelectedRightholder.CustId == addedRightholder.CustId)
            {
                MessageBox.Show("Не можна додати правовласника, з якого передаються об'єкти, в якості правонаступника.");
                return;
            }
            if (_objectsCopyrightList.Any(oc => oc.CustId == addedRightholder.CustId))
            {
                MessageBox.Show("Вибраний правовласник вже є в списку правонаступників.");
                return;
            }

            var objectsRightsList = ctrlRightholdersObjectsForChange.ObjectsRightsList;

            using (gvChangeCopyrights.DeferRefresh())
            {

                objectsRightsList.ForEach(or =>
                {
                    var newObjectCopyright = new ObjectCopyright
                    {
                        ObjId = or.ObjId,
                        CustId = addedRightholder.CustId,
                        //RoleCode = or.RoleCode, ???
                        InnerCode = addedRightholder.InnerCode,
                        InterCode = addedRightholder.InterCode,
                        Name = addedRightholder.Name,
                        Rate = 0,
                        Rightholder = addedRightholder,
                    };
                    _objectsCopyrightList.Add(newObjectCopyright);
                });

                DistributePersent();

                gvChangeCopyrights.MasterTemplate.ExpandAll();
            }
        }

        private void DistributePersent()
        {
            foreach (var row in gvChangeCopyrights.Rows)
            {
                // if manual distribution is set then continue
                if (row.Cells["IsManualPersent"].Value != null && (bool)row.Cells["IsManualPersent"].Value)
                    continue;

                var obj = row.DataBoundItem as ObjectRightForRightholder;

                var copyrightList = _objectsCopyrightList.Where(cr => cr.ObjId == obj.ObjId);
                var copyrightCount = copyrightList.Count();
                double newRate = (obj.RateRh ?? 0) / copyrightCount;
                double newRoundRate = Math.Round(newRate, 2);
                var delta = (newRate - newRoundRate) * copyrightCount;

                foreach (var copyright in copyrightList)
                {
                    copyright.Rate = newRoundRate + delta;
                    delta = 0.0;
                }
            }
        }

        private void gvChangeCopyrights_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.ViewTemplate.Parent == null)
            {
                e.RowElement.DrawFill = true;
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = Color.LightGray;
                e.RowElement.Font = new Font(e.RowElement.Font, FontStyle.Bold);
            }
        }

        private void gvChangeCopyrights_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (e.Column.Name == "Rate")
            {
                var parentRow = e.Row.Parent as GridViewHierarchyRowInfo;

                // if manual distribution is not set then cancel
                if (parentRow.Cells["IsManualPersent"].Value == null || !(bool)parentRow.Cells["IsManualPersent"].Value)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSaveNewCopyrights_Click(object sender, EventArgs e)
        {
            if (_objectsCopyrightList.Count == 0)
            {
                MessageBox.Show("Додайте нових правонаступників.");
                return;
            }

            var rightholders = new List<RightHolder>();

            // old rightholder
            var oldRightholder = new RightHolder
            {
                CustId = ctrlRightholdersObjectsForChange.SelectedRightholder.CustId,
                CopyRight = new ObservableListSource<CopyRight>(),
            };

            oldRightholder.CopyRight.Add(new CopyRight { EndDate = dtChangeCopyrightDateFrom.Value.AddDays(-1) });
            
            rightholders.Add(oldRightholder);


            // new copyrighs
            var groupedCopyright = _objectsCopyrightList
                .Where(oc => oc.Rate != 0)
                .GroupBy(oc => oc.CustId);

            foreach (var rightholderGroup in groupedCopyright)
            {
                var newRightholder = new RightHolder
                {
                    CustId = rightholderGroup.Key,
                    Cust = new Customer { Status = 9 },
                    CopyRight = new ObservableListSource<CopyRight>(),
                };

                foreach (var copyright in rightholderGroup)
                {
                    var newCprt = new CopyRight
                    {
                        CustId = newRightholder.CustId,
                        ObjId = copyright.ObjId,
                        RoleCode = 8, // Правовласник
                        LBasis = 3,
                        Rate = (decimal)copyright.Rate, // decimal or double?
                        BeginDate = dtChangeCopyrightDateFrom.Value,
                        EndDate = new DateTime(3000, 1, 1),
                        //ParentId = 
                        Obj = new ObjectRight(),
                    };
                    newCprt.Obj.Authors.Add(new Authors
                    {
                        CustId = newRightholder.CustId,
                        ObjId = copyright.ObjId,
                        FolkType = 1,
                        RoleCode = 8, // Правовласник
                        AuthorName = copyright.Name,
                    });
                    newRightholder.CopyRight.Add(newCprt);
                }
                rightholders.Add(newRightholder);
            }

            var result = _rightholderService.Inherit(ctrlRightholdersObjectsForChange.SelectedRightholder.CustId, rightholders);

            MessageBox.Show("Зміна правовласників виконана успішно.");

            ctrlRightholdersObjectsForChange.SelectedRightholder = _objectsCopyrightList.FirstOrDefault()?.Rightholder;
            UpdateRightholdersList(SelectedRightholder);
        }

        private void btnCancelNewCopyright_Click(object sender, EventArgs e)
        {
            ctrlRightholdersObjectsForChange.SelectedRightholder = null;
        }

        private void ctrlRightholdersObjectsForChange_EditObjectCommandExecuted(object sender, ObjectRightForRightholder selectedObject)
        {
            EditObjectRight(selectedObject.ObjId);
        }

        #endregion

        #region Search rightholder

        private void txtSearchRightholder_TextChanged(object sender, EventArgs e)
        {
            gvRightholdersList.MasterTemplate.Refresh();
        }

        private void gvRightholdersList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchRightholder.Text))
            {
                gvRightholdersList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRightholdersList.EndUpdate(false);
                return;
            }

            gvRightholdersList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearchRightholder.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRightholdersList.EndUpdate(false);
            }
        }

        #endregion
    }
}
