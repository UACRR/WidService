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
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class CabinetBigRight : UserControl
    {
        private readonly Dictionary<string, CabinetTabType> _cabinetTab = new Dictionary<string, CabinetTabType>
        {
            {string.Empty, CabinetTabType.None},
            {"pvLicence" , CabinetTabType.Licenses},
            {"pvCalculation" , CabinetTabType.Calculations},
            {"pvPayslips" , CabinetTabType.Payslips},
            {"pvRequest" , CabinetTabType.Requests},
            {"pvReference" , CabinetTabType.References},
            {"pvGeneralAgreement" , CabinetTabType.GeneralAgreement},
            {"pvFiles" , CabinetTabType.Files},
            {"pvAgent", CabinetTabType.Agent},
            {"pvPays", CabinetTabType.Payments},
            {"pvAvances", CabinetTabType.Prepays},
            {"pvContacts", CabinetTabType.Contacts}
        };
        public MiddleControlCabinetPayslips.MusicDesingDelegate MusicDesignDelegate
        {
            get => ctrlPayslips.MusicDesing;
            set => ctrlPayslips.MusicDesing = value;
        }

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

        private AnketaDictionaties _anketaDictionaties;
        private CabinetTabType _currenCabinetTab = CabinetTabType.GeneralAgreement;

        /// <summary>
        /// Виникиє при необхідності зберегти Customer
        /// </summary>
        public event SaveCustomerEventHandler OnSaveCustomerNeed;

        public event LisenseStatusChangeEventHandler OnLicenseStatusChanging;

        public event MiddleControlCabinetFiles.AddNewDocumentHandler OnAddNewDocument;
        public event MiddleControlCabinetFiles.ViewDocumentHandler OnViewDocumentNeed;
        public event MiddleControlCabinetPayslips.GetSpectacleView OnGetSpectacleNeed;
        public event WorkRhSaveEventHandler OnRequestWorkRhSaveNeed;
        public event ChangeLicenseTypeEventHandler OnChangeLicenseType;
        public event SavePayslipsEventHandler OnSavePayslip;
        public event GetRegisterRatedList OnGetRegisterRatedList;
        public event GetRegisterItemsEventHandler OnRegisterItemListNeed;
        public event SaveAndReturnNewPeriodListEventHandler SavePariodCommandExecuted;

        private readonly Dictionary<CabinetTabType, RadPageViewPage> _tab;

        public CabinetBigRight()
        {
            InitializeComponent();
            ctrlReference.SetAnketaDictionary();
            ctrlRequest.SetAnketaDictionary();
            ctrlReference.TypeControl = ControlRequestOrReferenceType.Reference;
            ctrlRequest.TypeControl = ControlRequestOrReferenceType.Request;
            ctrlFiles.OnAddNewDocument += CtrlFiles_OnAddNewDocument;
            ctrlFiles.OnViewDocButtonClick += CtrlFiles_OnViewDocButtonClick;
            ctrlPayslips.OnSpectacleViewNeed += CtrlPayslips_OnSpectacleViewNeed;
            ctrlGeneralAgreement.OnLicStatusChange += Ctrls_OnLicStatusChange;
            ctrlRequest.OnWorkRhSave += CtrlRequest_OnWorkRhSave;
            ctrlReference.OnWorkRhSave += CtrlRequest_OnWorkRhSave;
            ctrlRequest.OnLicenseSaveNeed += Ctrls_OnSaveCustomer;
            ctrlRequest.OnLicenseTypeChange += CtrlRequest_OnLicenseTypeChange;
            ctrlReference.OnLicenseTypeChange += CtrlRequest_OnLicenseTypeChange;
            ctrlRequest.OnLicenseCloseAndDelete += Ctrls_OnLicStatusChange;
            ctrlReference.OnLicenseCloseAndDelete += Ctrls_OnLicStatusChange;
            ctrlLicense.OnLicenseCloseAndDelete += Ctrls_OnLicStatusChange;
            ctrlLicense.OnSaveCustomer += Ctrls_OnSaveCustomer;
            ctrlReference.OnLicenseSaveNeed += Ctrls_OnSaveCustomer;
            ctrlPayslips.OnSavePayslip += CtrlPayslips_OnSavePayslip;
            ctrlPayslips.OnGetRegisterRatedList += CtrlPayslips_OnGetRegisterRatedList;
            ctrlPayslips.OnRegisterItemListNeed += CtrlPayslips_OnRegisterItemListNeed;
            ctrlPayslips.SavePariodCommandExecuted += CtrlPayslips_SavePariodCommandExecuted;

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
            UpdateCurentTab(_currenCabinetTab);
        }

        public void UpdateData<T>(List<T> data) where T : class
        {
            Type type = typeof(T);
            switch (type)
            {
                    
            }
            UpdateCurentTab(_currenCabinetTab);
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
            return OnSavePayslip?.Invoke(list) ?? false;
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
            return OnLicenseStatusChanging?.Invoke(agr, version, status, false) ?? false;
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

        public void UpdateCurentTab(CabinetTabType tab)
        {
            switch (tab)
            {
                case CabinetTabType.None:
                    break;

                case CabinetTabType.Anketa:
                    break;

                case CabinetTabType.GeneralAgreement:
                {
                    ctrlGeneralAgreement.SetAndUpdateData(_customer, _gridMainView, _generalAgreementView);
                }break;

                case CabinetTabType.Licenses:
                {
                    ctrlLicense.SetDataSources(_gridMainView);
                    ctrlLicense.SetData(_customer,_licenseAgreementView);
                }break;

                case CabinetTabType.Payslips:
                {
                    ctrlPayslips.SetAndUpdateData(_customer, _gridMainView, _registerRatedListView, _rlSpectacleView);
                }break;

                case CabinetTabType.Calculations:
                {
                    ctrlCalculation.Customer = _customer;
                }break;

                case CabinetTabType.Payments:
                {

                }break;

                case CabinetTabType.Prepays:
                {

                }break;

                case CabinetTabType.Requests:
                {
                    ctrlRequest.SetAndUpdateData(_customer, _gridMainView, _requestsLicenseView, _authorsForLicenseView);
                }break;

                case CabinetTabType.References:
                {
                    ctrlReference.SetAndUpdateData(_customer, _gridMainView, _referenceLicenseView, _authorsForLicenseView);
                }break;

                case CabinetTabType.Contacts:
                {
                    ctrlContactHeader.SetControlTextInfoBigRight(_customer, _gridMainView);
                }break;

                case CabinetTabType.Files:
                {
                    ctrlFiles.SetAndUpdateData(_customer, _gridMainView);
                }break;

                case CabinetTabType.Agent:
                {
                    ctrlAgent.SetAndUpdateData(_customer, _gridMainView, _generalAgreementView);
                }break;
            }
        }

        private void pageView_SelectedPageChanged(object sender, EventArgs e)
        {
            string tabName = ((Telerik.WinControls.UI.RadPageViewItem)((Telerik.WinControls.RadControl)sender).FocusedElement)?.Page?.Name ?? string.Empty;
            _currenCabinetTab = _cabinetTab.SingleOrDefault(key => key.Key == tabName).Value;
            UpdateCurentTab(_currenCabinetTab);
        }
    }
}
