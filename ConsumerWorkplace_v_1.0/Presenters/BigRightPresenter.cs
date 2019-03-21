using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ConsumerWorkplace_v_1._0.Presenters
{
    class BigRightPresenter : IUpdateProviderBigRight
    {
        private const string AddNewConsumerSuccess = "Нового користувача додано!";
        private const string AddNewConsumerError = "Не вдалося додати нового користувача!";

        private CabinetBigRightForm _localcabinetBigRightForm = null;
        private CabinetBigRightForm _cabinetBigRightForm => _localcabinetBigRightForm ?? ( _localcabinetBigRightForm = new CabinetBigRightForm());

        private readonly ConsumerService _service;
        private readonly PartnerService _partnerService;
        private readonly ConsumersViewBigRightControl _mainGrid;

        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private TypeBRDocument _currentNodeDocType = TypeBRDocument.None;
        private ConsumerWorkplace _parentForm = null;

        public BigRightPresenter(ConsumerService service, PartnerService partnerService, RadTreeView treeView, ConsumersViewBigRightControl mainGrid, ConsumerWorkplace parentForm)
        {
            _parentForm = parentForm;
            _service = service;
            _partnerService = partnerService;
            _mainGrid = mainGrid;
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            SubscribeEvents();

            //new ReportsControlPresenter(_cabinetBigRightForm.cabinet..reportsControl, _service);
        }

        //всі підписки на події в контролах
        private void SubscribeEvents()
        {
            _mainGrid.OnAddNewCustomer += CreateNewCustomer;
            _mainGrid.OnLoadCustomerCabinetNeed += LoadCustomerCabinet;

            //SubscribeBRCabinet();
        }

        private void SubscribeBRCabinet()
        {
            _cabinetBigRightForm.cabinet.GetCustomer += DataNeed_GetCustomer;
            _cabinetBigRightForm.cabinet.GetGeneralAgreementView += DataNeed_GetGeneralAgreementView;
            _cabinetBigRightForm.cabinet.GetLicenseAgreementView += DataNeed_GetLicenseAgreementView;
            _cabinetBigRightForm.cabinet.GetAuthorsForLicenseView += DataNeed_GetAuthorsForLicenseView;
            _cabinetBigRightForm.cabinet.GetRatedListMainView += DataNeed_GetRatedListMainView;
            _cabinetBigRightForm.cabinet.GetRatedListSpectacleView += DataNeed_GetRatedListSpectacleView;
            _cabinetBigRightForm.cabinet.GetReferenceView += DataNeed_GetReferenceView;
            _cabinetBigRightForm.cabinet.GetRequestsView += DataNeed_GetRequestsView;
            _cabinetBigRightForm.cabinet.GetMusicDesignView += DataNeed_GetMusicDesignView;
            _cabinetBigRightForm.cabinet.OnSaveCustomerNeed += SaveCustomer;
            _cabinetBigRightForm.cabinet.OnAddNewDocument += AddNewDocument;
            _cabinetBigRightForm.cabinet.OnViewDocumentNeed += ViewExistDocument;
            _cabinetBigRightForm.cabinet.OnFileDelete += FileDelete;
            _cabinetBigRightForm.cabinet.OnChangeLicenseStatus += ChangeLicenseStatus;
            _cabinetBigRightForm.cabinet.OnChangeLicenseType += ChangeLicenseType;
            _cabinetBigRightForm.cabinet.OnGetRegisterRatedList += GetRegisterRatedList;
            _cabinetBigRightForm.cabinet.OnRegisterItemListNeed += GetRegisterItems;
            _cabinetBigRightForm.cabinet.OnSaveRegisterRatedList += SaveRegisterRatedLists;
            _cabinetBigRightForm.cabinet.SavePariodCommandExecuted += SavePariodCommandExecuted;
            _cabinetBigRightForm.cabinet.OnGetSpectacleNeed += GetSpectacle;
            _cabinetBigRightForm.cabinet.DeleteRegisterRatedList += DeleteRegisterRatedLists;
            _cabinetBigRightForm.cabinet.OnGetPartnerListNeed += GetPartnerList;
            _cabinetBigRightForm.cabinet.GetPartner += GetPartnerAnketa;
            _cabinetBigRightForm.cabinet.OnSetPartner += SetPartnerForCustomer;
            _cabinetBigRightForm.cabinet.OnChangePartner += ChangePartnerForCustomer;
            _cabinetBigRightForm.cabinet.OnRemovePartner += RemovePartnerForCustomer;
            _cabinetBigRightForm.cabinet.SaveAgreementAddBrChanges += SaveAgreementAddBrChanges;
            new CalculationInfoControlPresenter(_cabinetBigRightForm.cabinet.ctrlCalculation, _service);
            _cabinetBigRightForm.IsInit = true;
        }

        private bool FileDelete(int id)
        {
            return _service.DeleteFileById(id);
        }

        public CabinetBigRightForm Cabinet => _cabinetBigRightForm;

        #region * * * ОТРИМАННЯ ДАНИХ VIEW * * * 

        private Customer DataNeed_GetCustomer(int custId)
        {
            return _service.GetData(custId);
        }

        private List<GeneralAgreementBigRightView> DataNeed_GetGeneralAgreementView(int custId)
        {
            return _service.getBRView(typeof(GeneralAgreementBigRightView), "vTSK_1_BRMaster", custId).ToListOfType<GeneralAgreementBigRightView>();
        }

        private List<LicenseAgreementBigRightView> DataNeed_GetLicenseAgreementView(int custId)
        {
            return _service.getBRView(typeof(LicenseAgreementBigRightView), "vTsk_vBRLicense", custId).ToListOfType<LicenseAgreementBigRightView>();
        }

        private List<RequestsOrReferenceBigRightView> DataNeed_GetRequestsView(int custId)
        {
            return _service.getBRView(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRBid", custId).ToListOfType<RequestsOrReferenceBigRightView>();
        }

        private List<RequestsOrReferenceBigRightView> DataNeed_GetReferenceView(int custId)
        {
            return _service.getBRView(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRNotice", custId).ToListOfType<RequestsOrReferenceBigRightView>(); // - - - довідки   
        }

        private List<RatedListMainBigRightView> DataNeed_GetRatedListMainView(int custId)
        {
            return _service.getBRView(typeof(RatedListMainBigRightView), "vTSK_1_BRRegister", custId).ToListOfType<RatedListMainBigRightView>();
        }

        private List<RatedListSpectacleBigRightView> DataNeed_GetRatedListSpectacleView(int custId)
        {
            return _service.getBRView(typeof(RatedListSpectacleBigRightView), "vTsk_1_BRAuthorsDistributed", null).ToListOfType<RatedListSpectacleBigRightView>();
        }

        private List<AuthorsForLicenseBigRightView> DataNeed_GetAuthorsForLicenseView(int custId)
        {
            return _service.getBRView(typeof(AuthorsForLicenseBigRightView), "vTsk_1_BRBidAuthors", custId).ToListOfType<AuthorsForLicenseBigRightView>();
        }

        private List<RatedListMusicDesignBigRightView> DataNeed_GetMusicDesignView(int custId)
        {
            return _service.getBRView(typeof(RatedListMusicDesignBigRightView), "vTsk_1_BRMusic", null).ToListOfType<RatedListMusicDesignBigRightView>();
        }

        #endregion

        //зміна даних по фільтру
        private void TreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node.Value is ConsumerFilterEnum @curEnum)
            {
                _currentNodeDocType = e.Node.Parent?.Value is TypeBRDocument @element ? @element : TypeBRDocument.All;
                _currentNodeValue = @curEnum;
            }
            else
            {
                _currentNodeDocType = e.Node.Value is TypeBRDocument @element ? @element : TypeBRDocument.GenAgreement;
                _currentNodeValue = ConsumerFilterEnum.All;
            }
            // _currentNodeValue = (e.Node.Value is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None);
            // Передати в поточний контрол зміну фільтра ???
            //_mainGrid?.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue), false);
            _mainGrid.DataSource = _service.getMainViewBR(_currentNodeDocType, _currentNodeValue);
        }

        //створити нового користувача
        private void CreateNewCustomer(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            var customer = _service.NewCustomer(custType);

            var form = new AnketaConsumerJurForm(customer, _service.GetAutoCompleteList, _service.GetData, TypeRights.BigRights);

            if (form.ShowDialog() == DialogResult.OK)
            {
                customer = form.Customer;
                var relust = _service.Save(customer);
                MessageShow.ShowInfoByResult(AddNewConsumerSuccess, AddNewConsumerError, relust);
            }
            if (!form.Disposing)
            {
                form.Dispose();
                form = null;
                GC.Collect();
            }
            UpdateData(customer.CustId);
        }

        /// <summary>
        /// Відкрити кабінет користувача великих прав
        /// </summary>
        /// <param name="id"></param>
        private void LoadCustomerCabinet(ConsumerBigRightView item)
        {
            ViewsSingleton.SetConsumerBigRightView(item);
            if (!_cabinetBigRightForm.IsInit)
            {
                SubscribeBRCabinet();
            }

            // завантаження даних
            _cabinetBigRightForm.cabinet.LoadData(item.CustId);
            _cabinetBigRightForm.Title = item.Name;

            WindowsFormsVisible.ShowHiddenWindow(_cabinetBigRightForm);
        }

        //ЗБЕРЕЖЕННЯ Customer
        private bool SaveCustomer(Customer customer)
        {
            var relust = _service.Save(customer);
            UpdateData(customer.CustId);
            return relust;
        }

        private bool SaveAgreementAddBrChanges(int agrId, LicenseAgreement licenseAgreement)
        {
            return _service.SaveAgreementAddBrById(agrId, licenseAgreement);
        }

        //додати новий документ
        private void AddNewDocument(int custId, int typeDocument, string fileName, string comment)
        {
            _service.uploadDocument(custId, typeDocument, comment, fileName);
        }

        //переглянути існуючий документ
        private void ViewExistDocument(int custId, int typeDocument, string fileName)
        {
            try
            {
                string fullpath = @"DocumentFiles\" + fileName;
                if (!Directory.Exists("DocumentFiles"))
                    Directory.CreateDirectory("DocumentFiles");
                using (var fileStream = File.Create(fullpath))
                {
                    _service.downloadDocument(custId, typeDocument, fileName).CopyTo(fileStream);
                }

                string extn = Path.GetExtension(fullpath);
                if (File.Exists(fullpath))
                {
                    if (extn == ".doc" || extn == ".docx")
                    {
                        Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                        Microsoft.Office.Interop.Word.Document doc = app.Documents.Open(Path.GetFullPath(fullpath), Type.Missing, true);
                        app.Visible = true;
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    }
                    else if (extn == ".xls" || extn == ".xlsx")
                    {
                        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                        var workbook = app.Workbooks.Open(Path.GetFullPath(fullpath), 0, true, 5, null, null, false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows);
                        app.Visible = true;
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    }
                }
            }
            catch (FileNotFoundException flnfexcpt)
            {
                MessageShow.ShowError($"Файл \"{flnfexcpt.FileName}\" не знайдено!");
            }
            catch (FileLoadException flexcpt)
            {
                MessageShow.ShowError($"Неможливо відкрити файл \"{flexcpt.FileName}\"! {flexcpt.Message}");
            }
            catch (Exception excpt)
            {
                MessageShow.ShowError(excpt.Message);
            }
        }

        //змінити статус ліцензії
        private bool ChangeLicenseStatus(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            if (_service.SetLicAgreementStatus(agr, version, status, changeVer))
            {
                UpdateData((int)agr.CustId);
                return true;
            }
            return false;
        }

        // змінити тип ліцензії (заявка, довідка, ліцензія)
        private bool ChangeLicenseType(LicenseAgreement agreement, ConsumerService.LicType licType)
        {
            if (_service.SetLicenseType(agreement, licType))
            {
                UpdateData(agreement?.CustId ?? default(int));
                return true;
            }
            return false;
        }

        //розрахунковий лист в customer об'єкті
        private Customer GetRegisterRatedList(int custId)
        {
            return _service.GetRatedListForCust(custId);
        }
        // компоненти розрахункового листа
        private List<RegisterItem> GetRegisterItems(int regId)
        {
            return _service.GetRegisterItems(regId);
        }

        //збереження розрахункового листа
        private bool SaveRegisterRatedLists(RegisterRatedList list)
        {
            var result = _service.SaveRegisterRatedList(list, out RegisterRatedList outlist);
            if (outlist?.Register?.FirstOrDefault()?.CustId is int id)
                UpdateData(id);
            return result;
        }

        //видалння розрахункового листа
        private bool DeleteRegisterRatedLists(int custId, int rmId)
        {
            var result = _service.DeleteRatedList(rmId);
            UpdateData(custId);
            return result;
        }

        //зберегти періоди
        private List<PaidPeriod> SavePariodCommandExecuted(int id, List<PaidPeriod> e)
        {
            return _service.SavePeriods(id, e);
        }

        // отримати список вистав
        private IList<BigRightSpectacleView> GetSpectacle(int custId)
        {
            return _service.getBRView(typeof(BigRightSpectacleView), "vTSK_1_BRObjects", custId).Select(item => item as BigRightSpectacleView).ToList();
        }

        //отримати список партнерів
        private List<Customer> GetPartnerList()
        {
            return _partnerService.GetPartnerList();
        }

        //отримати представника по ID слієнта
        private Customer GetPartnerAnketa(int clientId)
        {
            return _partnerService.GetPartnerAnketa(clientId);
        }

        //зберегти клієнту обраного представника 
        private bool SetPartnerForCustomer(int clientId, int partnerId)
        {
            return _partnerService.SetPartnerForCustomer(clientId, partnerId);
        }

        private bool ChangePartnerForCustomer(int clientId, int partnerId, int oldClientId)
        {
            return _partnerService.ChangePartnerForCustomer(clientId, partnerId, oldClientId);
        }

        private bool RemovePartnerForCustomer(int clientId, int partnerId)
        {
            return _partnerService.RemovePartnerForCustomer(clientId, partnerId);
        }

        // TODO: перехід на точечне оновлення
        private void UpdateData(int id)
        {
            //_mainGrid?.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue));
            _mainGrid.DataSource = _service.getMainViewBR(_currentNodeDocType, _currentNodeValue);
        }

        public void UpdateDataGrid()
        {
            //_mainGrid?.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue));
            _mainGrid.DataSource = _service.getMainViewBR(_currentNodeDocType, _currentNodeValue);
        }
    }
}
