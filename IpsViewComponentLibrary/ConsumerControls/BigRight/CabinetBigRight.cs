using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    public partial class CabinetBigRight : UserControl
    {
        //назви табів
        private readonly Dictionary<string, CabinetTabType> _cabinetTab = new Dictionary<string, CabinetTabType>
        {
            {string.Empty, CabinetTabType.None},
            {"pvAnketa" , CabinetTabType.Anketa},
            {"pvGeneralAgreement" , CabinetTabType.GeneralAgreement},
            {"pvLicence" , CabinetTabType.Licenses},
            {"pvRequest" , CabinetTabType.Requests},
            {"pvReference" , CabinetTabType.References},
            {"pvPayslips" , CabinetTabType.RegisterRatedList},
            {"pvCalculation" , CabinetTabType.Calculations},
            {"pvFiles" , CabinetTabType.Files},
            {"pvAgent", CabinetTabType.Agent},
            {"pvPays", CabinetTabType.PaysInfo},
            {"pvAvances", CabinetTabType.Prepays},
            {"pvContacts", CabinetTabType.Contacts}
        };
        private CabinetTabType _currenCabinetTab = CabinetTabType.GeneralAgreement;
        private readonly Dictionary<CabinetTabType, RadPageViewPage> _tab;

        //дані
        private Customer _customer;
        //private ConsumerBigRightView _gridMainView;
        private IList<GeneralAgreementBigRightView> _generalAgreementView;
        private IList<LicenseAgreementBigRightView> _licenseAgreementView;
        private IList<RequestsOrReferenceBigRightView> _requestsLicenseView;
        private IList<RequestsOrReferenceBigRightView> _referenceLicenseView;
        private IList<AuthorsForLicenseBigRightView> _authorsForLicenseView;
        private IList<RatedListBigRightView> _registerRatedListView;
        private IList<RatedListSpectacleBigRightView> _rlSpectacleView;

        #region events точечного отримання даних

        public event ActionByIdEventHandler UpdateAllViews;

        public event ReturnObjectEventHandler<Customer> GetCustomer;

        public event GetPartnerList OnGetPartnerListNeed;
        public event ReturnObjectEventHandler<Customer> GetPartner;

        #endregion

        public event SetPartnerEventHandler OnSetPartner;
        public event SetPartnerEventHandler OnRemovePartner;
        public event ChangePartnerEventHandler OnChangePartner;

        public event SaveObjectByIdEventHandler<LicenseAgreement> SaveAgreementAddBrChanges;

        /// <summary>
        /// Виникиє при необхідності зберегти Customer
        /// </summary>
        public event SaveCustomerEventHandler OnSaveCustomerNeed;

        public event LicenseStatusChangeEventHandler OnChangeLicenseStatus;

        public event MiddleControlCabinetFiles.AddNewDocumentHandler OnAddNewDocument;
        public event MiddleControlCabinetFiles.ViewDocumentHandler OnViewDocumentNeed;
        public event ActionByIdDelegate OnFileDelete;
        public event RegisterRatedListControl.GetSpectacleView OnGetSpectacleNeed;
        public event ChangeLicenseTypeEventHandler OnChangeLicenseType;
        public event SaveRegisterRatedListEventHandler OnSaveRegisterRatedList;
        public event GetRegisterRatedList OnGetRegisterRatedList;
        public event GetRegisterItemsEventHandler OnRegisterItemListNeed;
        public event SaveAndReturnNewPeriodListEventHandler SavePariodCommandExecuted;
        public event ActionWithTwoId DeleteRegisterRatedList;


        public CabinetBigRight()
        {
            InitializeComponent();

            ctrlTabNavigation.SetDefaultState(null, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += CtrlTabNavigation_SaveClick;
            ctrlTabNavigation.CancelClick += CancelChange;

            ctrlReference.TypeControl = ControlRequestOrReferenceType.Reference;
            ctrlRequest.TypeControl = ControlRequestOrReferenceType.Request;

            this.VisibleChanged += OnVisibleChanged;
            SubscribeEvents();
            SubscribeUpdateDataEvents();

            // static pages, call this in constructor
            _tab = new Dictionary<CabinetTabType, RadPageViewPage>
            {
                {CabinetTabType.None, null},
                {CabinetTabType.Anketa, pvAnketa},
                {CabinetTabType.GeneralAgreement, pvGeneralAgreement},
                {CabinetTabType.Licenses, pvLicence},
                {CabinetTabType.Requests, pvRequest},
                {CabinetTabType.References, pvReference},
                {CabinetTabType.Calculations, pvCalculation},
                {CabinetTabType.RegisterRatedList, pvPayslips},
                {CabinetTabType.Files, pvFiles},
                {CabinetTabType.Agent, pvAgent},
                {CabinetTabType.PaysInfo, pvPays},
                {CabinetTabType.Prepays, pvAvances},
                {CabinetTabType.Contacts, pvContacts}
            };
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (pageView.SelectedPage != pvGeneralAgreement)
                pageView.SelectedPage = pvGeneralAgreement;
        }

        // підписка на події контролів
        private void SubscribeEvents()
        {
            // файли
            ctrlFiles.AddNewFile += CtrlFilesAddNewFile;
            ctrlFiles.ViewCurrentFile += CtrlFilesViewCurrentFile;
            ctrlFiles.DeleteCurrentFile += CtrlFiles_DeleteCurrentFile;
            // генеральна угода
            ctrlGeneralAgreement.OnLicStatusChange += Ctrls_OnLicStatusChange;
            ctrlGeneralAgreement.GeneralAgreementSaveChanges += CtrlGeneralAgreementGeneralAgreementSaveChanges;
            // ліцензія
            ctrlLicense.OnLicenseCloseAndDelete += Ctrls_OnLicStatusChange;
            ctrlLicense.OnSaveCustomer += Ctrls_OnSaveCustomer;
            // заявка
            ctrlRequest.OnLicenseSaveNeed += Ctrls_OnSaveCustomer;
            ctrlRequest.OnLicenseTypeChange += CtrlRequest_OnLicenseTypeChange;
            ctrlRequest.OnLicenseStatusChange += Ctrls_OnLicStatusChange;
            // довідка
            ctrlReference.OnLicenseStatusChange += Ctrls_OnLicStatusChange;
            ctrlReference.OnLicenseTypeChange += CtrlRequest_OnLicenseTypeChange;
            ctrlReference.OnLicenseSaveNeed += Ctrls_OnSaveCustomer;
            // розрахункові листи
            ctrlPayslips.OnSpectacleViewNeed += CtrlPayslips_OnSpectacleViewNeed;
            ctrlPayslips.OnSavePayslip += CtrlPayslips_OnSavePayslip;
            ctrlPayslips.DeleteRegisterRatedList += CtrlPayslips_DeleteRegisterRatedList;
            ctrlPayslips.OnGetRegisterRatedList += CtrlPayslips_OnGetRegisterRatedList;
            ctrlPayslips.OnRegisterItemListNeed += CtrlPayslips_OnRegisterItemListNeed;
            ctrlPayslips.SavePariodCommandExecuted += CtrlPayslips_SavePariodCommandExecuted;
            // представник
            ctrlPartner.OnGetPartnerListNeed += CtrlPartner_OnGetPartnerListNeed;
            ctrlPartner.OnSetPartner += CtrlPartner_OnSetPartner;
            ctrlPartner.OnChangePartner += CtrlPartner_OnChangePartner;
            ctrlPartner.OnRemovePartner += CtrlPartner_OnRemovePartner;
        }

        // підписка на події * * ОНОВЛЕННЯ ДАНИХ * *
        private void SubscribeUpdateDataEvents()
        {
            ctrlGeneralAgreement.UpdateData += UpdateData;
            ctrlLicense.UpdateData += UpdateData;
            ctrlRequest.UpdateData += UpdateData;
            ctrlReference.UpdateData += UpdateData;
            ctrlPayslips.UpdateData += UpdateData;
            ctrlPartner.UpdateData += UpdateData;
            ctrlCalculation.UpdateData += UpdateData;
            ctrlPaysInfo.UpdateData += UpdateData;
            ctrlFiles.UpdateData += UpdateData;
        }

        private void CancelChange()
        {
            _customer = GetCustomer?.Invoke(_customer.CustId);
            ctrlAnketaConsumer.SetDataAndDictionaries(_customer);
            ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
        }

        // оновлення даних
        private void UpdateData()
        {
            UpdateCurentTab(_currenCabinetTab);
        }

        // збереження анкети
        private void CtrlTabNavigation_SaveClick(object sender, EventArgs e)
        {
            var result = OnSaveCustomerNeed?.Invoke(_customer) ?? false;
            if (result)
                MessageBox.Show("Успішно збережено!", "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Не можливо зберегти!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool CtrlPayslips_DeleteRegisterRatedList(int custId, int id)
        {
            return DeleteRegisterRatedList?.Invoke(custId, id) ?? false;
        }

        private bool CtrlGeneralAgreementGeneralAgreementSaveChanges(int id, LicenseAgreement saveObj)
        {
            return SaveAgreementAddBrChanges?.Invoke(id, saveObj) ?? false;
        }

        private bool CtrlPartner_OnRemovePartner(int clientId, int partnerId)
        {
            return OnRemovePartner?.Invoke(clientId, partnerId) ?? false;
        }

        private bool CtrlPartner_OnChangePartner(int clientId, int partnerId, int oldclientId)
        {
            return OnChangePartner?.Invoke(clientId, partnerId, oldclientId) ?? false;
        }

        private bool CtrlPartner_OnSetPartner(int clientId, int partnerId)
        {
            return OnSetPartner?.Invoke(clientId, partnerId) ?? false;
        }

        public void LoadData(int custId)
        {
            UpdateAllViews?.Invoke(custId);
            _customer = GetCustomer?.Invoke(custId);

            ctrlAnketaConsumer.SetDataAndDictionaries(_customer);
            ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
            ctrlGeneralAgreement.SetAndUpdateData(_customer);
            ctrlLicense.SetData(_customer);
            ctrlPayslips.SetAndUpdateData(_customer);
            var custRl = OnGetRegisterRatedList?.Invoke(_customer.CustId);
            SetupRl(_customer, custRl);
            ctrlCalculation.Customer = _customer;
            ctrlPaysInfo.Customer = _customer;
            ctrlRequest.SetAndUpdateData(_customer);
            ctrlReference.SetAndUpdateData(_customer);
            ctrlContactHeader.SetControlTextInfoBigRight(_customer);
            ctrlFiles.SetAndUpdateData(_customer);
            ctrlPartner.SetPartnerData(GetPartner?.Invoke(custId), custId);
        }

        //оновлення даних обраної вкладки
        public void UpdateCurentTab(CabinetTabType tab)
        {
            if (_customer == null)
                return;

            int custId = _customer.CustId;

            if (tab == CabinetTabType.All)
            {
                LoadData(custId);
                return;
            }

            UpdateAllViews?.Invoke(custId);
            _customer = GetCustomer?.Invoke(custId);

            switch (tab)
            {
                case CabinetTabType.None: break;

                case CabinetTabType.Anketa:
                    ctrlAnketaConsumer.SetDataAndDictionaries(_customer);
                    ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
                    break;

                case CabinetTabType.GeneralAgreement:
                    ctrlGeneralAgreement.SetAndUpdateData(_customer);
                    break;

                case CabinetTabType.RegisterRatedList:
                case CabinetTabType.Calculations:
                    ctrlPayslips.SetAndUpdateData(_customer);
                    var custRl = OnGetRegisterRatedList?.Invoke(_customer.CustId);
                    SetupRl(_customer, custRl);
                    ctrlCalculation.Customer = _customer;
                    break;

                case CabinetTabType.PaysInfo:
                    ctrlPaysInfo.Customer = _customer;
                    break;

                case CabinetTabType.Prepays:
                    break;

                case CabinetTabType.Licenses:
                case CabinetTabType.Requests:
                case CabinetTabType.References:
                    ctrlLicense.SetData(_customer);
                    ctrlRequest.SetAndUpdateData(_customer);
                    ctrlReference.SetAndUpdateData(_customer);
                    break;

                case CabinetTabType.Contacts:
                    ctrlContactHeader.SetControlTextInfoBigRight(_customer);
                    break;

                case CabinetTabType.Files:
                    ctrlFiles.SetAndUpdateData(_customer);
                    break;

                case CabinetTabType.Agent:
                    ctrlPartner.SetPartnerData(GetPartner?.Invoke(custId), custId);
                    break;
            }
        }

        /// <summary>
        /// Вставка в періоди поточні розрахункові листи
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="custRl"></param>
        private void SetupRl(Customer customer, Customer custRl)
        {
            foreach( var lic in customer.Client.LicenseAgreement )
            {
                var sorsLic = custRl.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == lic.LicId);
                if (sorsLic == null) continue;
                foreach (var period in lic.PaidPeriod)
                {
                    var sorsPeriod = sorsLic.PaidPeriod.SingleOrDefault(rec => rec.PeriodId == period.PeriodId);
                    if (sorsPeriod == null) continue;

                    period.RegisterRatedList.Clear();
                    foreach (var rm in sorsPeriod.RegisterRatedList)
                        period.RegisterRatedList.Add(rm);

                }
            }
        }

        private List<Customer> CtrlPartner_OnGetPartnerListNeed()
        {
            return OnGetPartnerListNeed?.Invoke();
        }

        private List<PaidPeriod> CtrlPayslips_SavePariodCommandExecuted(int id, List<PaidPeriod> e)
        {
            return SavePariodCommandExecuted?.Invoke(id, e);
        }

        private List<RegisterItem> CtrlPayslips_OnRegisterItemListNeed(int regId)
        {
            return OnRegisterItemListNeed?.Invoke(regId);
        }

        private Customer CtrlPayslips_OnGetRegisterRatedList(int custId)
        {
            return OnGetRegisterRatedList?.Invoke(custId);
        }

        private bool CtrlPayslips_OnSavePayslip(RegisterRatedList list)
        {
            return OnSaveRegisterRatedList?.Invoke(list) ?? false;
        }

        //збереження customer
        private bool Ctrls_OnSaveCustomer(Customer customer)
        {
            return OnSaveCustomerNeed?.Invoke(customer) ?? false;
        }

        private bool CtrlRequest_OnLicenseTypeChange(LicenseAgreement agreement, ipsFormsDesign.Services.ConsumerService.LicType licType)
        {
            return OnChangeLicenseType?.Invoke(agreement, licType) ?? false;
        }

        private bool Ctrls_OnLicStatusChange(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            return OnChangeLicenseStatus?.Invoke(agr, version, status, false) ?? false;
        }

        private IList<BigRightSpectacleView> CtrlPayslips_OnSpectacleViewNeed(int custId)
        {
            return OnGetSpectacleNeed?.Invoke(custId);
        }

        private void CtrlFilesViewCurrentFile(int custId, int typeDocument, string fileName)
        {
            OnViewDocumentNeed?.Invoke(custId, typeDocument, fileName);
        }

        private void CtrlFilesAddNewFile(int custId, int typeDocument, string fileName, string comment)
        {
            OnAddNewDocument?.Invoke(custId, typeDocument, fileName, comment);
        }
        private bool CtrlFiles_DeleteCurrentFile(int e)
        {
            return OnFileDelete?.Invoke(e) ?? false;
        }

        //оновлення даних на вкладкі при переході на іншу
        private void PageView_SelectedPageChanged(object sender, EventArgs e)
        {
            string tabName = ((RadPageViewItem)((Telerik.WinControls.RadControl)sender).FocusedElement)?.Page?.Name ?? string.Empty;
            _currenCabinetTab = _cabinetTab.SingleOrDefault(key => key.Key == tabName).Value;

            // ** Disable update when tab change
            //UpdateCurentTab(_currenCabinetTab);
        }
    }
}