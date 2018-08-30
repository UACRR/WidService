using System;
using System.Collections.Generic;
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
        private readonly CabinetBigRightForm _cabinetBigRightForm = new CabinetBigRightForm
        {
            StartPosition = FormStartPosition.CenterParent,
            WindowState = FormWindowState.Maximized
        };
        private readonly ConsumerService _service;
        private readonly GlobalControlConsumerMainGridBR _mainGrid;

        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private TypeBRDocument _currentNodeDocType = TypeBRDocument.None;

        public BigRightPresenter(ConsumerService service, RadTreeView treeView, GlobalControlConsumerMainGridBR mainGrid)
        {
            _service = service;
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            _mainGrid = mainGrid;
            _mainGrid.OnAddNewCustomer += CreateNewCustomer;
            _mainGrid.OnLoadCustomerCabinetNeed += LoadCustomerCabinet;


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
            _mainGrid?.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue));
        }

        //створити нового користувача
        private void CreateNewCustomer(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            var _cust = _service.NewCustomer(custType);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData, true, TypeRights.BigRights) { StartPosition = FormStartPosition.CenterParent };
            form.OnSaveCustomerNeed += Form_OnSaveCustomerNeed;
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
        private void LoadCustomerCabinet(int id, CabinetTabType tabType = CabinetTabType.None)
        {
            
            _cabinetBigRightForm.SetCustomerData(_service.GetData(id));
            if(!_cabinetBigRightForm.Visible)
                _cabinetBigRightForm.Show();
        }

        // Редагування існуючого споживача юридичної особи
        private void EditJuridicalConsumer(int custId)
        {
            var _cust = _service.GetData(custId);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData, false, TypeRights.BigRights) { StartPosition = FormStartPosition.CenterParent };
            form.OnSaveCustomerNeed += Form_OnSaveCustomerNeed;
            form.ShowDialog();
            form.OnSaveCustomerNeed -= Form_OnSaveCustomerNeed;
            if (!form.Disposing)
            {
                form.Dispose();
                form = null;
                GC.Collect();
            }
            UpdateData(_cust.CustId);
        }


        public IList<ConsumerBigRightView> GetMainView(TypeBRDocument typeDoc, ConsumerFilterEnum what)
        {
            return _service.getMainViewBR(typeDoc, what);
            // return new List<ConsumerBigRightView>( typeDoc, what );
        }

       
        //public void SwitchToCabinet(int id, CabinetTabType tabType = CabinetTabType.None)
        //{
        //    if (_cabinetBr == null)
        //    {
        //        _cabinetBr = new GlobalControlConsumerCabinetBR();
        //        var a = new CalculationInfoControlPresenter(_cabinetBr.ctrlCabinet.ctrlCalculation, _service);
        //        _cabinetBr.OnBackToGridNeed += CabinetBr_OnBackToGridNeed;
        //        _cabinetBr.OnCustomerUpdateDataNeed += CabinetBr_OnCustomerUpdateDataNeed;
        //        _cabinetBr.OnAddNewCustomer += _cabinetBr_OnAddNewCustomer;
        //        _cabinetBr.OnEditCustomer += _cabinetBr_OnEditCustomer;
        //        _cabinetBr.OnSaveCustomer += _cabinetBr_OnSaveCustomer;
        //        _cabinetBr.OnAddNewDocument += CabinetBr_OnAddNewDocument;
        //        _cabinetBr.OnViewDocument += CabinetBr_OnViewDocument;
        //        _cabinetBr.OnGetSpectacleNeed += _cabinetBr_OnGetSpectacleNeed;
        //        _cabinetBr.OnLicenseStatusChanging += _cabinetBr_OnLicenseStatusChanging;
        //        _cabinetBr.OnWorkRhSaveNeed += SaveWorkRh;
        //        _cabinetBr.OnChangeLicenseType += ChangeLicenseType;
        //        _cabinetBr.OnSavePayslip += SavePayslips;
        //        _cabinetBr.OnGetRegisterRatedList += _cabinetBr_OnGetRegisterRatedList;
        //        _cabinetBr.OnRegisterItemListNeed += GetRegisterItems;
        //        _cabinetBr.SavePariodCommandExecuted += SavePariodCommandExecuted;
        //        _cabinetBr.SetDataAnketaDictionaties(_service.GetDictionary());
        //        _cabinetBr.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue));
        //        _cabinetBr.Dock = DockStyle.Fill;
        //    }
            
        //    _cabinetBr.SetSelectCustomer(id);
        //    if (tabType != CabinetTabType.None)
        //        _cabinetBr.SetTab(tabType);
        //}

        private List<PaidPeriod> SavePariodCommandExecuted(int id, List<PaidPeriod> e)
        {
            return _service.SavePeriods(id, e);
        }

        private List<RegisterItem> GetRegisterItems(int regId)
        {
            return _service.GetRegisterItems(regId);
        }

        private Customer _cabinetBr_OnGetRegisterRatedList(int custId)
        {
            return _service.GetRatedListForCust(custId);
        }

        private bool SavePayslips(RegisterRatedList list)
        {
            var result = _service.SaveRegisterRatedList(list, out RegisterRatedList outlist);
            if (outlist?.Register?.FirstOrDefault()?.CustId is int id)
                UpdateData(id);
            return result;
        }


        private bool ChangeLicenseType(LicenseAgreement agreement, ConsumerService.LicType licType)
        {
            if (_service.SetLicenseType(agreement, licType))
            {
                UpdateData(agreement?.CustId ?? default(int));
                return true;
            }
            return false;
        }

        private bool SaveWorkRh(int licId, List<WorkRh> workRhList)
        {
            if (workRhList == null)
                return false;
            return _service.SaveBRWorkRH(licId, workRhList);
        }

        private bool _cabinetBr_OnLicenseStatusChanging(ipsFormsDesign.Model.LicenseAgreement agr, int version, int status, bool changeVer)
        {
            if (_service.SetLicAgreementStatus(agr, version, status, changeVer))
            {
                UpdateData((int)agr.CustId);
                return true;
            }
            return false;
        }

        private IList<BigRightSpectacleView> _cabinetBr_OnGetSpectacleNeed(int custId)
        {
            return _service.getBRView(typeof(BigRightSpectacleView), "vTSK_1_BRObjects", custId).Select(item => item as BigRightSpectacleView).ToList();
        }

        private void CabinetBr_OnAddNewDocument(int custId, int typeDocument, string fileName, string comment)
        {
            _service.uploadDocument(custId, typeDocument, comment, fileName);
            UpdateData(custId);
        }

        private void CabinetBr_OnViewDocument(int custId, int typeDocument, string fileName)
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

        private bool _cabinetBr_OnSaveCustomer(ipsFormsDesign.Model.Customer customer)
        {
            var relust = _service.Save(customer);
            UpdateData(customer.CustId);
            return relust;
        }

        private void _cabinetBr_OnEditCustomer(int id)
        {
            EditJuridicalConsumer(id);
        }

        //private void CabinetBr_OnCustomerUpdateDataNeed(int id)
        //{
        //    _cabinetBr.SetDataCustomer(_service.GetData(id));

        //    _cabinetBr.SetAgrMasterList(_service.getBRView(typeof(BigRightMasterGenAgr), "vTSK_1_BRMaster", id));
        //    _cabinetBr.SetAgreementViewData(_service.getBRView(typeof(VbrLicense), "vTsk_vBRLicense", id));
        //    _cabinetBr.SetRequestData(_service.getBRView(typeof(BigRightRequests), "vTsk_1_BRBid", id));
        //    _cabinetBr.SetBigRightBidAuthors(_service.getBRView(typeof(BigRightRequestBidAuthors), "vTsk_1_BRBidAuthors", id));
        //    _cabinetBr.SetReferanceData(_service.getBRView(typeof(BigRightRequests), "vTsk_1_BRNotice", id));
        //    _cabinetBr.SetMoneyUndescribsData(_service.getBRView(typeof(BigRightMoneyUndescrib), "vTsk_1_MoneyUndescrib", id));
        //    _cabinetBr.SetPayslipsDate(_service.getBRView(typeof(BigRightRegister), "vTSK_1_BRRegister", id),
        //                               _service.getBRView(typeof(BigRightPayslipsSpectacleView), "vTsk_1_BRAuthorsDistributed", null),
        //                               _service.getBRView(typeof(MusicDesignRatedListView), "vTsk_1_BRMusic", null));

        //}




        /// <summary>
        /// Оновлення даних
        /// </summary>
        /// <param name="id"></param>
        private void UpdateData(int id)
        {
            _mainGrid?.SetGridDataSource(_service.getMainViewBR(_currentNodeDocType, _currentNodeValue));
        }


        // Збереження даних
        private bool Form_OnSaveCustomerNeed(Customer customer)
        {
            var result = _service.Save(customer);
            return result;
        }
    }
}
