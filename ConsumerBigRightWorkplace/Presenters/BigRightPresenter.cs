using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace ConsumerBigRightWorkplace.Presenters
{
    class BigRightPresenter : IUpdateProviderBigRight
    {
        private const string AddNewConsumerSuccess = "Нового користувача додано!";
        private const string AddNewConsumerError = "Не вдалося додати нового користувача!";

        private CabinetBigRightForm _localcabinetBigRightForm;
        private CabinetBigRightForm _cabinetBigRightForm => _localcabinetBigRightForm ?? ( _localcabinetBigRightForm = new CabinetBigRightForm());

        private readonly ConsumerBigRightService _service;
        private readonly PartnerService _partnerService;
        private readonly ConsumersViewBigRightControl _mainGrid;

        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private TypeBRDocument _currentNodeDocType = TypeBRDocument.None;

        public BigRightPresenter(RadTreeView treeView, ConsumersViewBigRightControl mainGrid)
        {
            _service = ConsumerBigRightService.GetInstance();
            _partnerService = PartnerService.GetInstance();
            _mainGrid = mainGrid;
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            SubscribeEvents();
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
            _cabinetBigRightForm.cabinet.UpdateAllViews += UpdateAllViews;

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

        private void UpdateAllViews(int id)
        {
            var generalAgreementBigRightViews = _service.GetBigRightViewByName(typeof(GeneralAgreementBigRightView), "vTSK_1_BRMaster", id).ToListOfType<GeneralAgreementBigRightView>();
            ViewsSingleton.SetGeneralAgreementBigRightView(generalAgreementBigRightViews);

            var licenseAgreementBigRightViews = _service.GetBigRightViewByName(typeof(LicenseAgreementBigRightView), "vTsk_vBRLicense", id).ToListOfType<LicenseAgreementBigRightView>();
            ViewsSingleton.SetLicenseAgreementBigRightView(licenseAgreementBigRightViews);

            var requestsBigRightViews =_service.GetBigRightViewByName(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRBid", id).ToListOfType<RequestsOrReferenceBigRightView>();
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

        private bool FileDelete(int id)
        {
            return _service.DeleteFileById(id);
        }


        private Customer DataNeed_GetCustomer(int custId)
        {
            return _service.GetData(custId);
        }

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
            _mainGrid.DataSource = _service.GetMainBigRightView(_currentNodeDocType, _currentNodeValue);
        }

        //створити нового користувача
        private void CreateNewCustomer(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            var customer = _service.NewCustomer(custType);
            using (var form = new AnketaConsumerJurForm(customer, _service.GetAutoCompleteList, _service.GetData, TypeRights.BigRights))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var relust = _service.Save(customer);
                    MessageShow.ShowInfoByResult(AddNewConsumerSuccess, AddNewConsumerError, relust);
                }
            }
            UpdateDataGrid();
        }

        /// <summary>
        /// Відкрити кабінет користувача великих прав
        /// </summary>
        /// <param name="item"></param>
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
            UpdateDataGrid();
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
            var result = _service.SetLicAgreementStatus(agr, version, status, changeVer);
            if (result)
                UpdateDataGrid();
            
            return result;
        }

        // змінити тип ліцензії (заявка, довідка, ліцензія)
        private bool ChangeLicenseType(LicenseAgreement agreement, LicType licType)
        {
            var result = _service.SetLicenseType(agreement, licType);
            if (result)
                UpdateDataGrid();
            
            return result;
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
            if (result)
                UpdateDataGrid();
            return result;
        }

        //видалння розрахункового листа
        private bool DeleteRegisterRatedLists(int custId, int rmId)
        {
            var result = _service.DeleteRatedList(rmId);
            if (result)
                UpdateDataGrid();
            return result;
        }

        //зберегти періоди
        private List<PaidPeriod> SavePariodCommandExecuted(int id, List<PaidPeriod> e)
        {
            return _service.SavePeriods(id, e);
        }

        // отримати список вистав
        private List<BigRightSpectacleView> GetSpectacle(int custId)
        {
            return _service.GetBigRightViewByName(typeof(BigRightSpectacleView), "vTSK_1_BRObjects", custId).Select(item => item as BigRightSpectacleView).ToList();
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

        public void UpdateDataGrid()
        {
            var viewList = _service.GetMainBigRightView(_currentNodeDocType, _currentNodeValue);
            _mainGrid.DataSource = viewList;

            if (viewList == null || ViewsSingleton.ConsumerBigRightView == null)
                return;

            var item = viewList.SingleOrDefault(rec => rec.CustId == ViewsSingleton.ConsumerBigRightView.CustId);
            ViewsSingleton.SetConsumerBigRightView(item);
            _cabinetBigRightForm.Title = item?.Name;
        }
    }
}
