using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using MSWord = Microsoft.Office.Interop.Word;
using MSExcel = Microsoft.Office.Interop.Excel;


namespace ConsumerWorkplace_v_1._0
{
    class SwitchPresenterBigRights
    {
        private readonly MainViewSwitcher _switcher;
        private GlobalControlConsumerMainGridBR _mainGridBr = null;
        private GlobalControlConsumerCabinetBR _cabinetBr = null;
        private Control _currentControl = null;
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private TypeBRDocument _currentNodeDocType = TypeBRDocument.None;
        private ConsumerService _service = null;


        public SwitchPresenterBigRights(MainViewSwitcher switcher, ConsumerService service, RadTreeView treeView)
        {
            _switcher = switcher;
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            _service = service;
            SwitchToGrid();
        }

        private void TreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (_currentControl == null)
                return;

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
            _mainGridBr?.SetGridDataSource(getMainView(_currentNodeDocType, _currentNodeValue));
            _cabinetBr?.SetGridDataSource(getMainView(_currentNodeDocType, _currentNodeValue));
        }

        public IList<ConsumerBigRightView> getMainView(TypeBRDocument typeDoc, ConsumerFilterEnum what)
        {
            return _service.getMainViewBR(typeDoc, what);
            // return new List<ConsumerBigRightView>( typeDoc, what );
        }

        /// <summary>
        /// Перейти з кабінету до гріда
        /// </summary>
        /// <param name="id">ID запису який було обрано до переходу</param>
        public void SwitchToGrid(int id = 0)
        {
            if (_mainGridBr == null)
            {
                _mainGridBr = new GlobalControlConsumerMainGridBR();
                _mainGridBr.OnAddNewCustomer += MainGridBr_OnAddNewCustomer;
                _mainGridBr.OnGridButtonViewClick += MainGridBr_OnGridButtonViewClick;
                _mainGridBr.SetGridDataSource(getMainView(_currentNodeDocType, _currentNodeValue));
                _mainGridBr.Dock = DockStyle.Fill;
            }

            _mainGridBr.FilterString = _cabinetBr?.FilterString ?? string.Empty;
            if(id!=0)
                _mainGridBr.SetSelectCustomer(id);


            _currentControl = _mainGridBr;
            _switcher.SwitchView(_mainGridBr);
        }

        /// <summary>
        /// Перейти з гріда до кабінету
        /// </summary>
        /// <param name="id">ID запису який було обрано до переходу</param>
        public void SwitchToCabinet(int id)
        {
            if (_cabinetBr == null)
            {
                _cabinetBr = new GlobalControlConsumerCabinetBR();
                _cabinetBr.OnBackToGridNeed += CabinetBr_OnBackToGridNeed;
                _cabinetBr.OnCustomerUpdateDataNeed += CabinetBr_OnCustomerUpdateDataNeed;
                _cabinetBr.OnAddNewCustomer += _cabinetBr_OnAddNewCustomer;
                _cabinetBr.OnEditCustomer += _cabinetBr_OnEditCustomer;
                _cabinetBr.OnSaveCustomer += _cabinetBr_OnSaveCustomer;
                _cabinetBr.OnAddNewDocument += CabinetBr_OnAddNewDocument;
                _cabinetBr.OnViewDocument += CabinetBr_OnViewDocument;
                _cabinetBr.OnGetSpectacleNeed += _cabinetBr_OnGetSpectacleNeed;
                _cabinetBr.SetDataAnketaDictionaties(_service.GetDictionary());
                _cabinetBr.SetGridDataSource(getMainView(_currentNodeDocType, _currentNodeValue));
                _cabinetBr.Dock = DockStyle.Fill;
            }

            _cabinetBr.FilterString = _mainGridBr?.FilterString ?? string.Empty;
            _cabinetBr.SetSelectCustomer(id);
            _currentControl = _cabinetBr;
            _switcher.SwitchView(_cabinetBr);
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
                        MSWord.Application app = new MSWord.Application();
                        MSWord.Document doc = app.Documents.Open(Path.GetFullPath(fullpath), Type.Missing, true);
                        app.Visible = true;
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    }
                    else if (extn == ".xls" || extn == ".xlsx")
                    {
                        MSExcel.Application app = new MSExcel.Application();
                        var workbook = app.Workbooks.Open(Path.GetFullPath(fullpath), 0, true, 5, null, null, false, MSExcel.XlPlatform.xlWindows);
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
                RadMessageBox.Show("Не можливо відкрити файл: "+ flexcpt.FileName + "\nПовідомлення: " + flexcpt.Message, "Помилка відкривання файла", MessageBoxButtons.OK, RadMessageIcon.Error);
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

        private void _cabinetBr_OnAddNewCustomer(object sender, EventArgs e)
        {
            NewJuridicalConsumer();
        }

        private void CabinetBr_OnCustomerUpdateDataNeed(int id)
        {
            _cabinetBr.SetDataCustomer(_service.GetData(id));

            _cabinetBr.SetAgrMasterList(_service.getBRView(typeof(BigRightMasterGenAgr), "vTSK_1_BRMaster", id));
            _cabinetBr.SetAgreementViewData(_service.getBRView(typeof(VbrLicense), "vTsk_vBRLicense", id));
            _cabinetBr.SetRequestData(_service.getBRView(typeof(BigRightRequests), "vTsk_1_BRBid", id));
            _cabinetBr.SetBigRightBidAuthors(_service.getBRView(typeof(BigRightRequestBidAuthors), "vTsk_1_BRBidAuthors", id));
            _cabinetBr.SetReferanceData(_service.getBRView(typeof(BigRightRequests), "vTsk_1_BRNotice",id));
            _cabinetBr.SetMoneyUndescribsData(_service.getBRView(typeof(BigRightMoneyUndescrib), "vTsk_1_MoneyUndescrib", id));
        }

        private void CabinetBr_OnBackToGridNeed(int custId)
        {
            SwitchToGrid(custId);
        }

        private void MainGridBr_OnGridButtonViewClick(int id)
        {
            SwitchToCabinet(id);
        }

        //додавання нового користувача (випадаючі кнопки)
        private void MainGridBr_OnAddNewCustomer(PersonType person)
        {
            switch (person)
            {
                case PersonType.PhysicalPerson:
                    //
                    break;
                case PersonType.JuridicalPerson:
                {
                    NewJuridicalConsumer();
                }
                    break;
            }
        }


        /// <summary>
        /// Редагування існуючого споживача юридичної особи
        /// </summary>
        private void EditJuridicalConsumer(int custId)
        {
            var _cust = _service.GetData(custId);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData ,false, TypeRights.BigRights ) { StartPosition = FormStartPosition.CenterParent };
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

        /// <summary>
        /// Додавання нового споживача юридична особа (діалогова форма)
        /// </summary>
        private void NewJuridicalConsumer()
        {
            int custType = 3; // Юридична особа
            var _cust = _service.NewCustomer(custType);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData, true, TypeRights.BigRights) { StartPosition = FormStartPosition.CenterParent };
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

        /// <summary>
        /// Оновлення даних
        /// </summary>
        /// <param name="id"></param>
        private void UpdateData(int id)
        {
            if (_currentControl == _cabinetBr)
            {
                _cabinetBr?.SetGridDataSource(getMainView(_currentNodeDocType, _currentNodeValue));
                _cabinetBr?.SetSelectCustomer(id);
            }

            if (_currentControl == _mainGridBr)
            {
                _mainGridBr?.SetGridDataSource(getMainView(_currentNodeDocType, _currentNodeValue));
                _mainGridBr?.SetSelectCustomer(id);
            }
        }

        /// <summary>
        /// Збереження даних
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        private bool Form_OnSaveCustomerNeed(ipsFormsDesign.Model.Customer cust)
        {
            var result = _service.Save(cust);
            return result;
        }

        public void Done()
        {
            if (_switcher.Count == 0)
            {
                // Exit
            }

            // Save if need
            _currentControl = _switcher.CloseView();
        }

        public void Cancel()
        {
            if (_switcher.Count == 0)
            {
                // Exit
            }

            // without save
            _currentControl = _switcher.CloseView();
        }
    }
}
