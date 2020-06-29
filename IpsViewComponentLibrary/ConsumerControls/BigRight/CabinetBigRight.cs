using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerControls.BigRight.Cabinet;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    public partial class CabinetBigRight : UserControl
    {
        private readonly ConsumerBigRightService _service;
        private readonly PartnerService _partnerService;

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

        private Customer _customer;

        public Action UpdateDataAction { get; set; }

        public CabinetBigRight()
        {
            InitializeComponent();
            
            _service = ConsumerBigRightService.GetInstance();
            _partnerService = PartnerService.GetInstance();

            //new Calculation.CalculationInfoControlPresenter(ctrlCalculation, _service);

            ctrlTabNavigation.SetDefaultState(null, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += CtrlTabNavigation_SaveClick;
            ctrlTabNavigation.CancelClick += CancelChange;

            ctrlReference.TypeControl = ControlRequestOrReferenceType.Reference;
            ctrlRequest.TypeControl = ControlRequestOrReferenceType.Request;

            VisibleChanged += OnVisibleChanged;
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
            ctrlGeneralAgreement.GeneralAgreementSaveChanges += (agrId, licenseAgreement) => _service.SaveAgreementAddBrById(agrId, licenseAgreement);
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
            ctrlPayslips.OnGetRegisterRatedList += (custId) => _service.GetRatedListForCust(custId);
            ctrlPayslips.OnRegisterItemListNeed += (regId) => _service.GetRegisterItems(regId);
            ctrlPayslips.SavePariodCommandExecuted += (id, e) => _service.SavePeriods(id, e);
            // представник
            ctrlPartner.OnGetPartnerListNeed += () => _partnerService.GetPartnerList();
            ctrlPartner.OnSetPartner += (clientId, partnerId) => _partnerService.SetPartnerForCustomer(clientId, partnerId);
            ctrlPartner.OnChangePartner += (clientId, partnerId, oldClientId) => _partnerService.ChangePartnerForCustomer(clientId, partnerId, oldClientId);
            ctrlPartner.OnRemovePartner += (clientId, partnerId) => _partnerService.RemovePartnerForCustomer(clientId, partnerId);
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
            ctrlCalculationBR.UpdateData += UpdateData;
            ctrlPaysInfo.UpdateData += UpdateData;
            ctrlFiles.UpdateData += UpdateData;
        }

        private void CancelChange()
        {
            _customer = _service.GetData(_customer.CustId);
            ctrlAnketaConsumer.SetDataAndDictionaries(_customer);
            ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
        }

        // оновлення даних
        private void UpdateData()
        {
            if (_customer == null)
                return;

            int custId = _customer.CustId;

            if (_currenCabinetTab == CabinetTabType.All)
            {
                LoadData(custId);
                return;
            }

            UpdateAllViews(custId);
            _customer = _service.GetData(custId);

            switch (_currenCabinetTab)
            {
                case CabinetTabType.None: break;

                case CabinetTabType.Anketa:
                    ctrlContactHeader.SetControlTextInfoBigRight(_customer);
                    ctrlAnketaConsumer.SetDataAndDictionaries(_customer);
                    ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
                    break;

                case CabinetTabType.GeneralAgreement:
                    ctrlGeneralAgreement.SetAndUpdateData(_customer);
                    break;

                case CabinetTabType.RegisterRatedList:
                case CabinetTabType.Calculations:
                    ctrlPayslips.SetAndUpdateData(_customer);
                    var custRl = _service.GetRatedListForCust(custId);
                    SetupRl(_customer, custRl);
                    ctrlCalculationBR.SetDataByCustId(_customer.CustId);
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
                    ctrlPartner.SetPartnerData(_partnerService.GetPartnerAnketa(custId), custId);
                    break;
            }
        }

        // збереження анкети
        private void CtrlTabNavigation_SaveClick(object sender, EventArgs e)
        {
            var result = _service.Save(_customer);
            UpdateDataAction?.Invoke();

            if (result)
                UpdateData();
            MessageShow.ShowInfoAfterChanges(result);
        }

        private bool CtrlPayslips_DeleteRegisterRatedList(int custId, int rmId)
        {
            var result = _service.DeleteRatedList(rmId);

            if (result)
                UpdateDataAction?.Invoke();

            return result;
        }

        public void LoadData(int custId)
        {
            UpdateAllViews(custId);
            _customer = _service.GetData(custId);

            ctrlAnketaConsumer.SetDataAndDictionaries(_customer);
            ctrlAnketaConsumer.InitializeControl(null, null, ConsumerAnketeType.EditAnketa);
            ctrlGeneralAgreement.SetAndUpdateData(_customer);
            ctrlLicense.SetData(_customer);
            ctrlPayslips.SetAndUpdateData(_customer);
            var custRl = _service.GetRatedListForCust(custId);
            SetupRl(_customer, custRl);
            ctrlCalculationBR.SetDataByCustId(_customer.CustId);
            ctrlPaysInfo.Customer = _customer;
            ctrlRequest.SetAndUpdateData(_customer);
            ctrlReference.SetAndUpdateData(_customer);
            ctrlContactHeader.SetControlTextInfoBigRight(_customer);
            ctrlFiles.SetAndUpdateData(_customer);
            ctrlPartner.SetPartnerData(_partnerService.GetPartnerAnketa(custId), custId);
        }

        private void UpdateAllViews(int id)
        {
            var generalAgreementBigRightViews = _service.GetBigRightViewByName(typeof(GeneralAgreementBigRightView), "vTSK_1_BRMaster", id).ToListOfType<GeneralAgreementBigRightView>();
            ViewsSingleton.SetGeneralAgreementBigRightView(generalAgreementBigRightViews);

            var licenseAgreementBigRightViews = _service.GetBigRightViewByName(typeof(LicenseAgreementBigRightView), "vTsk_vBRLicense", id).ToListOfType<LicenseAgreementBigRightView>();
            ViewsSingleton.SetLicenseAgreementBigRightView(licenseAgreementBigRightViews);

            var requestsBigRightViews = _service.GetBigRightViewByName(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRBid", id).ToListOfType<RequestsOrReferenceBigRightView>();
            ViewsSingleton.SetRequestsBigRightView(requestsBigRightViews);

            var referenceBigRightViews = _service.GetBigRightViewByName(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRNotice", id).ToListOfType<RequestsOrReferenceBigRightView>();
            ViewsSingleton.SetReferenceBigRightView(referenceBigRightViews);

            var ratedListBigRightViews = _service.GetBigRightViewByName(typeof(RatedListBigRightView), "vTSK_1_BRRegister", id).ToListOfType<RatedListBigRightView>();
            ViewsSingleton.SetRatedListBigRightView(ratedListBigRightViews);

            var spectacleBigRightViews = _service.GetBigRightViewByName(typeof(RatedListSpectacleBigRightView), "vTsk_1_BRAuthorsDistributed", null).ToListOfType<RatedListSpectacleBigRightView>();
            ViewsSingleton.SetRatedListSpectacleBigRightView(spectacleBigRightViews);

            var authorsForLicenseBigRightViews = _service.GetBigRightViewByName(typeof(AuthorsForLicenseBigRightView), "vTsk_1_BRBidAuthors", id).ToListOfType<AuthorsForLicenseBigRightView>();
            ViewsSingleton.SetAuthorsForLicenseBigRightView(authorsForLicenseBigRightViews);

            var ratedListMusicDesignBigRightViews = _service.GetBigRightViewByName(typeof(RatedListMusicDesignBigRightView), "vTsk_1_BRMusic", null).ToListOfType<RatedListMusicDesignBigRightView>();
            ViewsSingleton.SetRatedListMusicDesignBigRightView(ratedListMusicDesignBigRightViews);
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

        private bool CtrlPayslips_OnSavePayslip(RegisterRatedList list)
        {
            var result = _service.SaveRegisterRatedList(list, out RegisterRatedList outlist);
            
            if (result)
                UpdateDataAction?.Invoke();

            return result;
        }

        //збереження customer
        private bool Ctrls_OnSaveCustomer(Customer customer)
        {
            var result = _service.Save(customer);
            UpdateDataAction?.Invoke();
            return result;
        }

        private bool CtrlRequest_OnLicenseTypeChange(LicenseAgreement agreement, LicType licType)
        {
            var result = _service.SetLicenseType(agreement, licType);

            if (result)
                UpdateDataAction?.Invoke();

            return result;
        }

        private bool Ctrls_OnLicStatusChange(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            var result = _service.SetLicAgreementStatus(agr, version, status, changeVer);

            if (result)
                UpdateDataAction?.Invoke();

            return result;
        }

        private IList<BigRightSpectacleView> CtrlPayslips_OnSpectacleViewNeed(int custId)
        {
            return _service.GetBigRightViewByName(typeof(BigRightSpectacleView), "vTSK_1_BRObjects", custId).Select(item => item as BigRightSpectacleView).ToList();
        }

        private void CtrlFilesViewCurrentFile(int custId, int typeDocument, string fileName)
        {
            try
            {
                string fullpath = @"DocumentFiles\" + fileName;
                if (!Directory.Exists("DocumentFiles"))
                    Directory.CreateDirectory("DocumentFiles");

                using (var fileStream = File.Create(fullpath))
                {
                    using (var stream = _service.DownloadDocument(custId, typeDocument, fileName))
                    {
                        stream.CopyTo(fileStream);
                        stream.Close();
                    }
                }

                if (File.Exists(fullpath))
                {
                    System.Diagnostics.Process.Start(fullpath);
                }
            }
            catch (Exception excpt)
            {
                MessageShow.ShowError(excpt.Message);
            }
        }

        private void CtrlFilesAddNewFile(int custId, int typeDocument, string fileName, string comment)
        {
            _service.uploadDocument(custId, typeDocument, comment, fileName);
        }

        private bool CtrlFiles_DeleteCurrentFile(int fileId)
        {
            return _service.DeleteFileById(fileId);
        }

        //оновлення даних на вкладкі при переході на іншу
        private void PageView_SelectedPageChanged(object sender, EventArgs e)
        {
            string tabName = ((RadPageViewItem)((Telerik.WinControls.RadControl)sender).FocusedElement)?.Page?.Name ?? string.Empty;
            _currenCabinetTab = _cabinetTab.SingleOrDefault(key => key.Key == tabName).Value;
        }
    }
}