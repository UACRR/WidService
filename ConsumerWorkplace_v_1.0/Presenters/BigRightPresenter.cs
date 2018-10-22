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
using IpsViewComponentLibrary.ConsumerForms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ConsumerWorkplace_v_1._0.Presenters
{
    class BigRightPresenter
    {
        //кабінет великих прав

        private CabinetBigRightForm _localcabinetBigRightForm = null;
        private CabinetBigRightForm _cabinetBigRightForm
        {
            get
            {
                if (_localcabinetBigRightForm == null)
                {
                    _localcabinetBigRightForm = new CabinetBigRightForm
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        WindowState = FormWindowState.Maximized
                    };
                }
                return _localcabinetBigRightForm;
            }
        }


        private readonly ConsumerService _service;
        private readonly GlobalControlConsumerMainGridBR _mainGrid;

        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private TypeBRDocument _currentNodeDocType = TypeBRDocument.None;
        private RadForm _parentForm = null;

        public BigRightPresenter(ConsumerService service, RadTreeView treeView, GlobalControlConsumerMainGridBR mainGrid, RadForm parentForm)
        {
            _parentForm = parentForm;
            _service = service;
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
            _cabinetBigRightForm.cabinet.GetMainGridView += DataNeed_GetMainGridView;
            _cabinetBigRightForm.cabinet.GetGeneralAgreementView += DataNeed_GetGeneralAgreementView;
            _cabinetBigRightForm.cabinet.GetLicenseAgreementView += DataNeed_GetLicenseAgreementView;
            _cabinetBigRightForm.cabinet.GetAuthorsForLicenseView += DataNeed_GetAuthorsForLicenseView;
            _cabinetBigRightForm.cabinet.GetRatedListMainView += DataNeed_GetRatedListMainView;
            _cabinetBigRightForm.cabinet.GetRatedListSpectacleView += DataNeed_GetRatedListSpectacleView;
            _cabinetBigRightForm.cabinet.GetReferenceView += DataNeed_GetReferenceView;
            _cabinetBigRightForm.cabinet.GetRequestsView += DataNeed_GetRequestsView;
            _cabinetBigRightForm.cabinet.GetUnattachedMoneyView += DataNeed_GetUnattachedMoneyView;
            _cabinetBigRightForm.cabinet.GetMusicDesignView += DataNeed_GetMusicDesignView;
            _cabinetBigRightForm.cabinet.OnSaveCustomerNeed += SaveCustomer;
            _cabinetBigRightForm.cabinet.OnAddNewDocument += AddNewDocument;
            _cabinetBigRightForm.cabinet.OnViewDocumentNeed += ViewExistDocument;
            _cabinetBigRightForm.cabinet.OnChangeLicenseStatus += ChangeLicenseStatus;
            _cabinetBigRightForm.cabinet.OnChangeLicenseType += ChangeLicenseType;
            _cabinetBigRightForm.cabinet.OnGetRegisterRatedList += GetRegisterRatedList;
            _cabinetBigRightForm.cabinet.OnRegisterItemListNeed += GetRegisterItems;
            _cabinetBigRightForm.cabinet.OnSaveRegisterRatedList += SaveRegisterRatedLists;
            _cabinetBigRightForm.cabinet.OnRequestWorkRhSaveNeed += SaveWorkRh;
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

        public CabinetBigRightForm Cabinet => _cabinetBigRightForm;

        #region - - - ОТРИМАННЯ ДАНИХ - - -

        private Customer DataNeed_GetCustomer(int custId)
        {
            return _service.GetData(custId);
        }

        private MainGridConsumerBigRightView DataNeed_GetMainGridView(int custId)
        {
            return _mainGrid.ViewRow;
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

        private List<UnattachedMoneyView> DataNeed_GetUnattachedMoneyView(int custId)
        {
            return _service.getBRView(typeof(UnattachedMoneyView), "vTsk_1_MoneyUndescrib", custId).ToListOfType<UnattachedMoneyView>();
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
            _mainGrid?.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue));
        }

        //створити нового користувача
        private void CreateNewCustomer(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            var _cust = _service.NewCustomer(custType);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData, true, TypeRights.BigRights) { StartPosition = FormStartPosition.CenterParent };
            form.OnSaveCustomerNeed += SaveCustomer;
            form.ShowDialog();
            if (!form.Disposing)
            {
                form.Dispose();
                form = null;
                GC.Collect();
            }
            UpdateData(_cust.CustId);
        }

        //відкрити кабінет
        private void LoadCustomerCabinet(int id)
        {

            if (!_cabinetBigRightForm.IsInit)
            {
                SubscribeBRCabinet();
            }
            _cabinetBigRightForm.radWaitingBar1.StartWaiting();

            if (!_cabinetBigRightForm.Visible)
                _cabinetBigRightForm.Show();



            Task.Run(() =>
            {
                var customer = _service.GetData(id);
                var mainGridView = _mainGrid.ViewRow;//- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - view основного гріда
                var generalAgrView = _service.getBRView(typeof(GeneralAgreementBigRightView), "vTSK_1_BRMaster", id).ToListOfType<GeneralAgreementBigRightView>(); // - - - - генеральні угоди
                var licenseView = _service.getBRView(typeof(LicenseAgreementBigRightView), "vTsk_vBRLicense", id).ToListOfType<LicenseAgreementBigRightView>();// - - - - - - ліцензії
                var requestView = _service.getBRView(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRBid", id).ToListOfType<RequestsOrReferenceBigRightView>(); //- - - - - - заявки
                var referenceView = _service.getBRView(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRNotice", id).ToListOfType<RequestsOrReferenceBigRightView>(); // - - - довідки
                var licAutorsView = _service.getBRView(typeof(AuthorsForLicenseBigRightView), "vTsk_1_BRBidAuthors", id).ToListOfType<AuthorsForLicenseBigRightView>(); // - - автори для всіх типів ліцензій
                var moneyUnattachedView = _service.getBRView(typeof(UnattachedMoneyView), "vTsk_1_MoneyUndescrib", id).ToListOfType<UnattachedMoneyView>(); // - - - незакріплені кошти користувачів великих прав
                var ratedListMainView = _service.getBRView(typeof(RatedListMainBigRightView), "vTSK_1_BRRegister", id).ToListOfType<RatedListMainBigRightView>(); // - - - Р/Л основні дані
                var rlSpectacleView = _service.getBRView(typeof(RatedListSpectacleBigRightView), "vTsk_1_BRAuthorsDistributed", null).ToListOfType<RatedListSpectacleBigRightView>();// Р/Л вистави

                _cabinetBigRightForm.Invoke((MethodInvoker)delegate ()
                   {
                       _cabinetBigRightForm.cabinet.SetAllLoadData(customer, mainGridView, generalAgrView, licenseView, requestView, referenceView, licAutorsView, moneyUnattachedView, ratedListMainView, rlSpectacleView);
                       _cabinetBigRightForm.cabinet.UpdateCurentTab(CabinetTabType.Anketa);
                       _cabinetBigRightForm.radWaitingBar1.StopWaiting();

                   });
            });
        }

        // Редагування існуючого споживача юридичної особи
        private void EditJuridicalConsumer(int custId)
        {
            var _cust = _service.GetData(custId);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData, false, TypeRights.BigRights) { StartPosition = FormStartPosition.CenterParent };
            form.OnSaveCustomerNeed += SaveCustomer;
            form.ShowDialog();
            if (!form.Disposing)
            {
                form.Dispose();
                form = null;
                GC.Collect();
            }
            UpdateData(_cust.CustId);
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
            UpdateData(custId);
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
                RadMessageBox.ThemeName = "Office2013Light";
                RadMessageBox.Show("Файл не знайдено: " + flnfexcpt.FileName + "\nПовідомлення: " + flnfexcpt.Message, "Помилка", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            catch (FileLoadException flexcpt)
            {
                RadMessageBox.ThemeName = "Office2013Light";
                RadMessageBox.Show("Не можливо відкрити файл: " + flexcpt.FileName + "\nПовідомлення: " + flexcpt.Message, "Помилка відкривання файла", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            catch (Exception excpt)
            {
                RadMessageBox.ThemeName = "Office2013Light";
                RadMessageBox.Show("Повідомлення: " + excpt.Message, "Помилка", MessageBoxButtons.OK, RadMessageIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    " Data: " + excpt.Data + Environment.NewLine + " StackTrace: " + excpt.StackTrace);
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

        private bool SaveWorkRh(int licId, List<WorkRh> workRhList)
        {
            if (workRhList == null)
                return false;
            return _service.SaveBRWorkRH(licId, workRhList);
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
            return _service.GetPartnerList();
        }

        //отримати представника по ID слієнта
        private Customer GetPartnerAnketa(int clientId)
        {
            return _service.GetPartnerAnketa(clientId);
        }

        //зберегти клієнту обраного представника 
        private bool SetPartnerForCustomer(int clientId, int partnerId)
        {
            return _service.SetPartnerForCustomer(clientId, partnerId);
        }

        private bool ChangePartnerForCustomer(int clientId, int partnerId, int oldClientId)
        {
            return _service.ChangePartnerForCustomer(clientId, partnerId, oldClientId);
        }

        private bool RemovePartnerForCustomer(int clientId, int partnerId)
        {
            return _service.RemovePartnerForCustomer(clientId, partnerId);
        }

        // TODO: перехід на точечне оновлення
        private void UpdateData(int id)
        {
            _mainGrid?.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue));
        }

    }
}
