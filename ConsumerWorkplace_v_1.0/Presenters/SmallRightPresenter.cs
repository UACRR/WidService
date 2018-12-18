using System;
using System.Collections.Generic;
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
using Telerik.WinControls.UI;

namespace ConsumerWorkplace_v_1._0.Presenters
{
    class SmallRightPresenter
    {
        private readonly CabinetSmallRightForm _cabinetSmallRightForm = new CabinetSmallRightForm
        {
            StartPosition = FormStartPosition.CenterParent,
            WindowState = FormWindowState.Maximized
        };
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private readonly ConsumerService _service;
        private readonly PartnerService _partnerService;
        private readonly GlobalControlConsumerMainGrid _mainGrid;

        public SmallRightPresenter(ConsumerService service, PartnerService partnerService, RadTreeView treeView, GlobalControlConsumerMainGrid mainGrid)
        {
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            _service = service;
            _partnerService = partnerService;
            _mainGrid = mainGrid;
            _mainGrid.OnLoadCustomerCabinetNeed += LoadCustomerCabinet;
            _mainGrid.OnAddNewCustomer += CreateNewCustomerAnketa;

            _cabinetSmallRightForm.Update += LoadCustomerCabinet;
            _cabinetSmallRightForm.cabinet.SaveCustomer += SaveCustomer;
            _cabinetSmallRightForm.cabinet.OnChangeLicenseStatus += ChangeLicenseStatus;
            _cabinetSmallRightForm.cabinet.GetPartner += Cabinet_GetPartner;
            _cabinetSmallRightForm.cabinet.OnSetPartner += Cabinet_OnSetPartner;
            _cabinetSmallRightForm.cabinet.OnChangePartner += Cabinet_OnChangePartner;
            _cabinetSmallRightForm.cabinet.OnRemovePartner += Cabinet_OnRemovePartner;
            _cabinetSmallRightForm.cabinet.OnGetPartnerListNeed += Cabinet_OnGetPartnerListNeed;
            new CalculationInfoControlPresenter(_cabinetSmallRightForm.cabinet.calculationCtrl, _service);
            new ReportsControlPresenter(_cabinetSmallRightForm.cabinet.reportsControl, _service);
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
            _mainGrid?.SetGridDataSource(_service.getMainView(_currentNodeValue));
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
                        // save
                        var relust = _service.Save(cust);
                        MessageBox.Show(relust ? "Успішно!" : "Не вдалося зберегти!");
                    }
                    if (!formPhis.Disposing)
                    {
                        formPhis.Dispose();
                        formPhis = null;
                    }
                    break;
                case 3: // Юридична особа
                    var form = new AnketaConsumerForm(cust, _service.GetAutoCompleteList, _service.GetData)
                    {
                        StartPosition = FormStartPosition.CenterParent
                    };
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // save
                        var relust = _service.Save(cust);
                        MessageBox.Show(relust ? "Успішно!" : "Не вдалося зберегти!");
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
    }
}
