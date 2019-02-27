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
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ConsumerWorkplace_v_1._0.Presenters
{
    class SmallRightPresenter: IUpdateProviderSmallRight
    {
        private const string ConsumerAdded = "Нового користувача додано!";
        private const string ConsumerNotAdded = "Не вдалося додати нового користувача!";

        private readonly CabinetSmallRightForm _cabinetSmallRightForm = new CabinetSmallRightForm
        {
            StartPosition = FormStartPosition.CenterParent,
            WindowState = FormWindowState.Maximized
        };
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private readonly ConsumerService _service;
        private readonly PartnerService _partnerService;
        private readonly ConsumersViewSmallRightControl _mainGrid;

        public SmallRightPresenter(ConsumerService service, PartnerService partnerService, RadTreeView treeView, ConsumersViewSmallRightControl mainGrid)
        {
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            _service = service;
            _partnerService = partnerService;
            _mainGrid = mainGrid;
            _mainGrid.OnLoadCustomerCabinetNeed += LoadCustomerCabinet;
            _mainGrid.OnAddNewCustomer += CreateNewCustomerAnketa;

            _cabinetSmallRightForm.OnUpdate += LoadCustomerCabinet;
            _cabinetSmallRightForm.cabinet.SaveCustomer += SaveCustomer;
            _cabinetSmallRightForm.cabinet.OnChangeLicenseStatus += ChangeLicenseStatus;
            _cabinetSmallRightForm.cabinet.GetPartner += Cabinet_GetPartner;
            _cabinetSmallRightForm.cabinet.OnSetPartner += Cabinet_OnSetPartner;
            _cabinetSmallRightForm.cabinet.OnChangePartner += Cabinet_OnChangePartner;
            _cabinetSmallRightForm.cabinet.OnRemovePartner += Cabinet_OnRemovePartner;
            _cabinetSmallRightForm.cabinet.OnGetPartnerListNeed += Cabinet_OnGetPartnerListNeed;
            _cabinetSmallRightForm.cabinet.OnAddNewFile += Cabinet_OnAddNewFile;
            _cabinetSmallRightForm.cabinet.OnViewCurrentFile += Cabinet_OnViewCurrentFile;
            _cabinetSmallRightForm.cabinet.OnDeleteCurrentFile += Cabinet_OnDeleteCurrentFile;
            new CalculationInfoControlPresenter(_cabinetSmallRightForm.cabinet.calculationCtrl, _service);
            new ReportsControlPresenter(_cabinetSmallRightForm.cabinet.reportsControl, _service);
        }

        private bool Cabinet_OnDeleteCurrentFile(int id)
        {
            return _service.DeleteFileById(id);
        }

        private void Cabinet_OnViewCurrentFile(int custId, int typeDocument, string fileName)
        {
            // TODO: змінити підхід
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

        private void Cabinet_OnAddNewFile(int custId, int typeDocument, string fileName, string comment)
        {
            _service.uploadDocument(custId, typeDocument, comment, fileName);
        }

        public CabinetSmallRightForm Cabinet => _cabinetSmallRightForm;

        private List<Customer> Cabinet_OnGetPartnerListNeed()
        {
            return _partnerService.GetPartnerList();
        }

        private bool Cabinet_OnRemovePartner(int clientId, int partnerId)
        {
            return _partnerService.RemovePartnerForCustomer(clientId, partnerId);
        }

        private bool Cabinet_OnChangePartner(int clientId, int partnerId, int oldPartnerId)
        {
            return _partnerService.ChangePartnerForCustomer(clientId, partnerId,oldPartnerId);
        }

        private bool Cabinet_OnSetPartner(int clientId, int partnerId)
        {
            return _partnerService.SetPartnerForCustomer(clientId, partnerId);
        }

        private Customer Cabinet_GetPartner(int custId)
        {
            return _partnerService.GetPartnerAnketa(custId);
        }

        //зміна фільтра
        private void TreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            _currentNodeValue = (e.Node.Value is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None);
            // Передати в поточний контрол зміну фільтра ???
            _mainGrid?.SetGridDataSource(_service.getMainView(_currentNodeValue), false);
        }
        
        //відкрити кабінет користувача
        private void LoadCustomerCabinet(int custId)
        {
            Customer mainCust = null, regCust = null;
            Task[] getCustData = new Task[2];

            getCustData[0] = Task.Run(() => { mainCust = _service.GetData(custId); });
            getCustData[1] = Task.Run(() => { regCust = _service.GetRatedListForCust(custId); });
            Task.WaitAll(getCustData);

            CloneRegisterRL(mainCust, regCust);

            _cabinetSmallRightForm.SetCustomer(mainCust);
            _cabinetSmallRightForm.cabinet.reportsControl.Customer = regCust;
            // форма відкрита -> зміна даних
            if (_cabinetSmallRightForm.Visible)
                _mainGrid?.SetGridDataSource(_service.getMainView(_currentNodeValue));
            _cabinetSmallRightForm.Title = _mainGrid?.ViewRow?.Name;
            if (!_cabinetSmallRightForm.Visible)
                _cabinetSmallRightForm.Show();
            GC.Collect();
        }

        private static void CloneRegisterRL(Customer mainCust, Customer regCust)
        {
            if (mainCust == null || regCust == null)
                return;
            // Прив'язати розрахункові листи до договорів
            foreach (var mainLic in mainCust.Client.LicenseAgreement)
            {
                var destLic = regCust.Client.LicenseAgreement.SingleOrDefault(rec => rec.LicId == mainLic.LicId);
                if (destLic == null) continue;

                foreach (var mainPeriod in mainLic.PaidPeriod)
                {
                    var destPeriod = destLic.PaidPeriod.SingleOrDefault(rec => rec.PeriodId == mainPeriod.PeriodId);
                    if (destPeriod == null) continue;

                    foreach (var destRl in destPeriod.RegisterRatedList)
                    {
                        var mainRl = mainPeriod.RegisterRatedList.SingleOrDefault(rec => rec.RmId == destRl.RmId);
                        if (mainRl == null)
                            mainPeriod.RegisterRatedList.Add(destRl);
                    }
                }
            }
        }

        // Додавання нового споживача юридична особа (діалогова форма)
        private void CreateNewCustomerAnketa(object sender, EventArgs e)
        {
            int custType = (int)sender;
            var cust = _service.NewCustomer(custType);
            switch (custType)
            {
                case 1:
                    var formPhis = new AnketaConsumerPhisForm(cust)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (formPhis.ShowDialog() == DialogResult.OK)
                    {
                        var relust = _service.Save(cust);
                        MessageShow.ShowInfoByResult(ConsumerAdded, ConsumerNotAdded, relust);
                    }
                    if (!formPhis.Disposing)
                    {
                        formPhis.Dispose();
                        formPhis = null;
                    }
                    break;
                case 3: // Юридична особа
                    var form = new AnketaConsumerJurForm(cust, _service.GetAutoCompleteList, _service.GetData)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var relust = _service.Save(cust);
                        MessageShow.ShowInfoByResult(ConsumerAdded, ConsumerNotAdded, relust);
                    }
                    if (!form.Disposing)
                    {
                        form.Dispose();
                        form = null;
                    }
                    break;
            }
            GC.Collect();
            //оновлення даних
            _mainGrid?.SetGridDataSource(_service.getMainView(_currentNodeValue));
        }

        // збереження customer
        private bool SaveCustomer(Customer customer)
        {
            var relust = _service.Save(customer);
            return relust;
        }

        //змінити статус ліцензії
        private bool ChangeLicenseStatus(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            var relust = _service.SetLicAgreementStatus(agr, version, status, changeVer);
            return relust;
        }

        public void UpdateDataGrid()
        {
            _mainGrid?.SetGridDataSource(_service.getMainView(_currentNodeValue));
        }
    }
}
