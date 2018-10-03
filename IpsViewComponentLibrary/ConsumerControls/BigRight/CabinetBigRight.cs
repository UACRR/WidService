using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.RightholderControls.Anketa;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
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
            {"pvPayslips" , CabinetTabType.Payslips},
            {"pvCalculation" , CabinetTabType.Calculations},
            {"pvFiles" , CabinetTabType.Files},
            {"pvAgent", CabinetTabType.Agent},
            {"pvPays", CabinetTabType.Payments},
            {"pvAvances", CabinetTabType.Prepays},
            {"pvContacts", CabinetTabType.Contacts}
        };
        private AnketaDictionaties _anketaDictionaties;
        private CabinetTabType _currenCabinetTab = CabinetTabType.Anketa;
        private readonly Dictionary<CabinetTabType, RadPageViewPage> _tab;

        //дані
        private Customer _customer;
        private MainGridConsumerBigRightView _gridMainView;
        private IList<GeneralAgreementBigRightView> _generalAgreementView;
        private IList<LicenseAgreementBigRightView> _licenseAgreementView;
        private IList<RequestsOrReferenceBigRightView> _requestsLicenseView;
        private IList<RequestsOrReferenceBigRightView> _referenceLicenseView;
        private IList<AuthorsForLicenseBigRightView> _authorsForLicenseView;
        private IList<UnattachedMoneyView> _unattachedMoneyView;
        private IList<RatedListMainBigRightView> _registerRatedListView;
        private IList<RatedListSpectacleBigRightView> _rlSpectacleView;
        private IList<RatedListMusicDesignBigRightView> _rlMusicDesignView;

        #region events точечного отримання даних


        public event ReturnObjectEventHandler<Customer> GetCustomer;
        public event ReturnObjectEventHandler<MainGridConsumerBigRightView> GetMainGridView;
        public event ReturnViewEventHandler<GeneralAgreementBigRightView> GetGeneralAgreementView;
        public event ReturnViewEventHandler<LicenseAgreementBigRightView> GetLicenseAgreementView;
        public event ReturnViewEventHandler<RequestsOrReferenceBigRightView> GetRequestsView;
        public event ReturnViewEventHandler<RequestsOrReferenceBigRightView> GetReferenceView;
        public event ReturnViewEventHandler<AuthorsForLicenseBigRightView> GetAuthorsForLicenseView;
        public event ReturnViewEventHandler<UnattachedMoneyView> GetUnattachedMoneyView;
        public event ReturnViewEventHandler<RatedListMainBigRightView> GetRatedListMainView;
        public event ReturnViewEventHandler<RatedListSpectacleBigRightView> GetRatedListSpectacleView;
        public event ReturnViewEventHandler<RatedListMusicDesignBigRightView> GetMusicDesignView;
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

        public event LisenseStatusChangeEventHandler OnChangeLicenseStatus;

        public event MiddleControlCabinetFiles.AddNewDocumentHandler OnAddNewDocument;
        public event MiddleControlCabinetFiles.ViewDocumentHandler OnViewDocumentNeed;
        public event MiddleControlCabinetPayslips.GetSpectacleView OnGetSpectacleNeed;
        public event WorkRhSaveEventHandler OnRequestWorkRhSaveNeed;
        public event ChangeLicenseTypeEventHandler OnChangeLicenseType;
        public event SaveRegisterRatedListEventHandler OnSaveRegisterRatedList;
        public event GetRegisterRatedList OnGetRegisterRatedList;
        public event GetRegisterItemsEventHandler OnRegisterItemListNeed;
        public event SaveAndReturnNewPeriodListEventHandler SavePariodCommandExecuted;
        public event ActionWithTwoId DeleteRegisterRatedList;


        public CabinetBigRight()
        {
            InitializeComponent();
            if(IpsGlobal.AnketaDictionaties != null)
            {
                ctrlReference.SetAnketaDictionary(IpsGlobal.AnketaDictionaties);
                ctrlRequest.SetAnketaDictionary(IpsGlobal.AnketaDictionaties);
            }
            ctrlReference.TypeControl = ControlRequestOrReferenceType.Reference;
            ctrlRequest.TypeControl = ControlRequestOrReferenceType.Request;
            
            // файли
            ctrlFiles.OnAddNewDocument += CtrlFiles_OnAddNewDocument;
            ctrlFiles.OnViewDocButtonClick += CtrlFiles_OnViewDocButtonClick;
            // генеральна угода
            ctrlGeneralAgreement.OnLicStatusChange += Ctrls_OnLicStatusChange;
            ctrlGeneralAgreement.ProlongationSave += CtrlGeneralAgreement_ProlongationSave;
            // ліцензія
            ctrlLicense.OnLicenseCloseAndDelete += Ctrls_OnLicStatusChange;
            ctrlLicense.OnSaveCustomer += Ctrls_OnSaveCustomer;
            // заявка
            ctrlRequest.OnWorkRhSave += CtrlRequest_OnWorkRhSave;
            ctrlRequest.OnLicenseSaveNeed += Ctrls_OnSaveCustomer;
            ctrlRequest.OnLicenseTypeChange += CtrlRequest_OnLicenseTypeChange;
            ctrlRequest.OnLicenseCloseAndDelete += Ctrls_OnLicStatusChange;
            // довідка
            ctrlReference.OnWorkRhSave += CtrlRequest_OnWorkRhSave;
            ctrlReference.OnLicenseCloseAndDelete += Ctrls_OnLicStatusChange;
            ctrlReference.OnLicenseTypeChange += CtrlRequest_OnLicenseTypeChange;
            ctrlReference.OnLicenseSaveNeed += Ctrls_OnSaveCustomer;
            // розрахункові листи
            ctrlPayslips.OnSpectacleViewNeed += CtrlPayslips_OnSpectacleViewNeed;
            ctrlPayslips.OnSavePayslip += CtrlPayslips_OnSavePayslip;
            ctrlPayslips.DeleteRegisterRatedList += CtrlPayslips_DeleteRegisterRatedList;
            ctrlPayslips.OnGetRegisterRatedList += CtrlPayslips_OnGetRegisterRatedList;
            ctrlPayslips.OnRegisterItemListNeed += CtrlPayslips_OnRegisterItemListNeed;
            ctrlPayslips.SavePariodCommandExecuted += CtrlPayslips_SavePariodCommandExecuted;
            ctrlPayslips.GetMusicDesing += DataNeedRatedList_GetMusicDesing;
            // представник
            ctrlPartner.OnGetPartnerListNeed += CtrlPartner_OnGetPartnerListNeed;
            ctrlPartner.OnSetPartner += CtrlPartner_OnSetPartner;
            ctrlPartner.OnChangePartner += CtrlPartner_OnChangePartner;
            ctrlPartner.OnRemovePartner += CtrlPartner_OnRemovePartner;

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
                {CabinetTabType.Payslips, pvPayslips},
                {CabinetTabType.Files, pvFiles},
                {CabinetTabType.Agent, pvAgent},
                {CabinetTabType.Payments, pvPays},
                {CabinetTabType.Prepays, pvAvances},
                {CabinetTabType.Contacts, pvContacts}
            };
        }

        private bool CtrlPayslips_DeleteRegisterRatedList(int custId, int id)
        {
            return DeleteRegisterRatedList?.Invoke(custId, id) ?? false;
        }

        private bool CtrlGeneralAgreement_ProlongationSave(int id, LicenseAgreement saveObj)
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


        /// <summary>
        /// Передати та встановити дані 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="gridMainView"></param>
        /// <param name="generalAgreementView"></param>
        /// <param name="licenseAgreementView"></param>
        /// <param name="requestsLicenseView"></param>
        /// <param name="referenceLicenseView"></param>
        /// <param name="authorsForLicenseView"></param>
        /// <param name="unattachedMoneyView"></param>
        /// <param name="registerRatedListView"></param>
        /// <param name="rlSpectacleView"></param>
        public void SetAllLoadData(Customer customer, MainGridConsumerBigRightView gridMainView, IList<GeneralAgreementBigRightView> generalAgreementView,
            IList<LicenseAgreementBigRightView> licenseAgreementView, IList<RequestsOrReferenceBigRightView> requestsLicenseView, IList<RequestsOrReferenceBigRightView> referenceLicenseView,
            IList<AuthorsForLicenseBigRightView> authorsForLicenseView, IList<UnattachedMoneyView> unattachedMoneyView, IList<RatedListMainBigRightView> registerRatedListView,
            IList<RatedListSpectacleBigRightView> rlSpectacleView)
        {
            _customer = customer;
            _gridMainView = gridMainView;
            _generalAgreementView = generalAgreementView;
            _licenseAgreementView = licenseAgreementView;
            _requestsLicenseView = requestsLicenseView;
            _referenceLicenseView = referenceLicenseView;
            _authorsForLicenseView = authorsForLicenseView;
            _unattachedMoneyView = unattachedMoneyView;
            _registerRatedListView = registerRatedListView;
            _rlSpectacleView = rlSpectacleView;

            if (pageView.SelectedPage != pvAnketa)
                pageView.SelectedPage = pvAnketa;
        }

        //оновлення даних обаної вкладки
        public void UpdateCurentTab(CabinetTabType tab)
        {
            if (_customer == null) return;
            int custId = _customer.CustId;
            _customer = GetCustomer?.Invoke(custId);
            _gridMainView = GetMainGridView?.Invoke(custId);
            switch (tab)
            {
                case CabinetTabType.None:
                    break;

                case CabinetTabType.Anketa:
                    ctrlAnketaConsumer.SetDataAndDictionaries(_customer, _anketaDictionaties);
                    ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);

                    break;

                case CabinetTabType.GeneralAgreement:
                {
                    _generalAgreementView = GetGeneralAgreementView?.Invoke(custId);
                    ctrlGeneralAgreement.SetAndUpdateData(_customer, _gridMainView, _generalAgreementView);
                }
                    break;

                case CabinetTabType.Licenses:
                {
                    _licenseAgreementView = GetLicenseAgreementView?.Invoke(custId);
                    ctrlLicense.SetDataSources(_gridMainView);
                    ctrlLicense.SetData(_customer, _licenseAgreementView?.ToList());
                }
                    break;

                case CabinetTabType.Payslips:
                {
                    _registerRatedListView = GetRatedListMainView?.Invoke(custId);
                    _rlSpectacleView = GetRatedListSpectacleView?.Invoke(custId);
                    ctrlPayslips.SetAndUpdateData(_customer, _gridMainView, _registerRatedListView, _rlSpectacleView);
                }
                    break;

                case CabinetTabType.Calculations:
                {
                    ctrlCalculation.Customer = _customer;
                }
                    break;

                case CabinetTabType.Payments:
                {

                }
                    break;

                case CabinetTabType.Prepays:
                {

                }
                    break;

                case CabinetTabType.Requests:
                {
                    _requestsLicenseView = GetRequestsView?.Invoke(custId);
                    _authorsForLicenseView = GetAuthorsForLicenseView?.Invoke(custId);
                    ctrlRequest.SetAndUpdateData(_customer, _gridMainView, _requestsLicenseView, _authorsForLicenseView);
                }
                    break;

                case CabinetTabType.References:
                {
                    _referenceLicenseView = GetReferenceView?.Invoke(custId);
                    _authorsForLicenseView = GetAuthorsForLicenseView?.Invoke(custId);
                    ctrlReference.SetAndUpdateData(_customer, _gridMainView, _referenceLicenseView, _authorsForLicenseView);
                }
                    break;

                case CabinetTabType.Contacts:
                {
                    ctrlContactHeader.SetControlTextInfoBigRight(_customer, _gridMainView);
                }
                    break;

                case CabinetTabType.Files:
                {
                    ctrlFiles.SetAndUpdateData(_customer, _gridMainView);
                }
                    break;

                case CabinetTabType.Agent:
                {
                    ctrlPartner.SetPartnerData(GetPartner?.Invoke(custId), custId);
                }
                    break;
            }
        }

        private List<Customer> CtrlPartner_OnGetPartnerListNeed()
        {
            return OnGetPartnerListNeed?.Invoke();
        }

        private List<RatedListMusicDesignBigRightView> DataNeedRatedList_GetMusicDesing()
        {
            return GetMusicDesignView?.Invoke(0);
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

        private bool CtrlRequest_OnWorkRhSave(int licenseId, List<WorkRh> workRhList)
        {
            return OnRequestWorkRhSaveNeed?.Invoke(licenseId, workRhList) ?? false;
        }

        private bool Ctrls_OnLicStatusChange(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            return OnChangeLicenseStatus?.Invoke(agr, version, status, false) ?? false;
        }

        private IList<BigRightSpectacleView> CtrlPayslips_OnSpectacleViewNeed(int custId)
        {
            return OnGetSpectacleNeed?.Invoke(custId);
        }

        private void CtrlFiles_OnViewDocButtonClick(int custId, int typeDocument, string fileName)
        {
            OnViewDocumentNeed?.Invoke(custId, typeDocument, fileName);
        }

        private void CtrlFiles_OnAddNewDocument(int custId, int typeDocument, string fileName, string comment)
        {
            OnAddNewDocument?.Invoke(custId, typeDocument, fileName, comment);
        }

        public void SetDictionaries(AnketaDictionaties dictionaries)
        {
            _anketaDictionaties = dictionaries;
        }

        public CabinetTabType CurentTab
        {
            get => _currenCabinetTab;
            set
            {
                _currenCabinetTab = value;
                pageView.SelectedPage = _tab[value];
            }
        }
        
        //оновлення даних на вкладкі при переході на іншу
        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            string tabName = ((Telerik.WinControls.UI.RadPageViewItem)((Telerik.WinControls.RadControl)sender).FocusedElement)?.Page?.Name ?? string.Empty;
            _currenCabinetTab = _cabinetTab.SingleOrDefault(key => key.Key == tabName).Value;
            UpdateCurentTab(_currenCabinetTab);
        }
    }
}