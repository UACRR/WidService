using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.ConsumerControls;
using IpsViewComponentLibrary.ConsumerControls.SmallRight;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;
using WordApplication = Microsoft.Office.Interop.Word.Application;
using ExcelApplication = Microsoft.Office.Interop.Excel.Application;

namespace ConsumerSmallRightWorkplace.Presenters
{
    class SmallRightPresenter: IUpdateProviderSmallRight
    {
        private const string ConsumerAdded = "Нового користувача додано!";
        private const string ConsumerNotAdded = "Не вдалося додати нового користувача!";

        private readonly CabinetSmallRightForm _cabinetSmallRightForm;
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private readonly ConsumerSmallRightService _service;
        private readonly PartnerService _partnerService;
        private readonly ConsumersViewSmallRightControl _mainGrid;

        public SmallRightPresenter(RadTreeView treeView, ConsumersViewSmallRightControl mainGrid)
        {
            _service = ConsumerSmallRightService.GetInstance();
            _cabinetSmallRightForm = new CabinetSmallRightForm();

            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            _partnerService = PartnerService.GetInstance();
            _mainGrid = mainGrid;
            _mainGrid.OnLoadCustomerCabinetNeed += LoadCustomerCabinet;
            _mainGrid.OnAddNewCustomer += CreateNewCustomerAnketa;
            _mainGrid.SearchOrPageChanged += GridDataUpdate;

            _cabinetSmallRightForm.OnUpdate += SmallRightForm_OnUpdate;
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
            GridDataUpdate();
        }

        //відкрити кабінет користувача
        private void LoadCustomerCabinet(ConsumerSmallRightView item)
        {
            UpdateData(item.CustId);
        }

        private void SmallRightForm_OnUpdate(int id)
        {
            UpdateData(id);
        }

        private void UpdateData(int custId)
        {
            Customer mainCust = null, regCust = null;
            Task[] getCustData = new Task[2];

            getCustData[0] = Task.Run(() => { mainCust = _service.GetData(custId); });
            getCustData[1] = Task.Run(() => { regCust = _service.GetRatedListForCust(custId); });
            Task.WaitAll(getCustData);

            CloneRegisterRL(mainCust, regCust);

            GridDataUpdate();

            _cabinetSmallRightForm.SetCustomer(mainCust);
            _cabinetSmallRightForm.cabinet.reportsControl.Customer = regCust;
            _cabinetSmallRightForm.Title = _mainGrid.ViewRow?.Name;

            WindowsFormsVisible.ShowHiddenWindow(_cabinetSmallRightForm);
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
            var customer = _service.NewCustomer(custType);
            switch (custType)
            {
                // фізична особа
                case 1:
                    using (var formPhis = new AnketaConsumerPhisForm(customer))
                    {
                        if (formPhis.ShowDialog() == DialogResult.OK)
                        {
                            var relust = _service.Save(customer);
                            MessageShow.ShowInfoByResult(ConsumerAdded, ConsumerNotAdded, relust);
                        }
                    }
                    break;
                // юридична особа
                case 3:
                    using (var form = new AnketaConsumerJurForm(customer, _service.GetAutoCompleteList, _service.GetData))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var relust = _service.Save(customer);
                            MessageShow.ShowInfoByResult(ConsumerAdded, ConsumerNotAdded, relust);
                        }
                    }
                    break;
            }
            GC.Collect();
            GridDataUpdate();
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

        /// <summary>
        /// Оновлення даних основного гріда
        /// </summary>
        public async void GridDataUpdate()
        {
            _mainGrid.StartWait();
            var result = await RunTask();
            _mainGrid.DataSource = result.List;
            _mainGrid.TotalItems = result.TotalItems;
            _mainGrid.StopWait();
        }

        private async Task<ItemListResponse<ConsumerSmallRightView>> RunTask()
        {
            return await Task.Factory.StartNew(() => _service.getMainView(_currentNodeValue, _mainGrid.PaginateAndSearchQuery));
        }

        public void UpdateDataGrid()
        {
            GridDataUpdate();
        }
    }
}
