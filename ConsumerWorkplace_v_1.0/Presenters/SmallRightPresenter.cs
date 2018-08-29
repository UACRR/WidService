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
        private CabinetSmallRightForm _smallRightForm = new CabinetSmallRightForm
        {
            StartPosition = FormStartPosition.CenterScreen,
            WindowState = FormWindowState.Maximized
        };
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private readonly ConsumerService _service;
        private GlobalControlConsumerMainGrid _mainGrid;

        public SmallRightPresenter(ConsumerService service, RadTreeView treeView, GlobalControlConsumerMainGrid mainGrid)
        {
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            _service = service;
            _mainGrid = mainGrid;
            _mainGrid.OnGridButtonClick += LoadCustomerCabinet;
            _mainGrid.OnAddNewCustomer += CreateNewCustomerAnketa;

            _smallRightForm.OnGetCustomerNeed += GetAndReturnCustomer;
            _smallRightForm.cabinet.OnEditCustomer += EditExistCustomerAnketa;
            _smallRightForm.cabinet.OnSaveCustomer += SaveCustomer;
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
            _smallRightForm.SetCustomer(_service.GetData(custId));
            if(!_smallRightForm.Visible)
                _smallRightForm.Show();

            GC.Collect();
        }

        //оновлення customer за вимогою контролів
        private Customer GetAndReturnCustomer(int customerId)
        {
            return _service.GetData(customerId);
        }

        // Додавання нового споживача юридична особа (діалогова форма)
        private void CreateNewCustomerAnketa(object sender, EventArgs e)
        {
            int custType = 3; // Юридична особа
            var _cust = _service.NewCustomer(custType);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData) { StartPosition = FormStartPosition.CenterParent };

            form.OnSaveCustomerNeed += Form_OnSaveCustomerNeed;
            form.ShowDialog();
            form.OnSaveCustomerNeed -= Form_OnSaveCustomerNeed;
            if (!form.Disposing)
            {
                form.Dispose();
                form = null;
                GC.Collect();
            }

            //оновлення даних
            _mainGrid?.SetGridDataSource(_service.getMainView(_currentNodeValue));
        }

        // Редагування існуючого споживача юридичної особи
        private void EditExistCustomerAnketa(int custId)
        {
            var _cust = GetAndReturnCustomer(custId);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.GetAutoCompleteList, _service.GetData, false) { StartPosition = FormStartPosition.CenterParent };
            form.OnSaveCustomerNeed += Form_OnSaveCustomerNeed;
            form.ShowDialog();
            form.OnSaveCustomerNeed -= Form_OnSaveCustomerNeed;
            if (!form.Disposing)
            {
                form.Dispose();
                form = null;
                GC.Collect();
            }

            //оновлення даних
            _mainGrid?.SetGridDataSource(_service.getMainView(_currentNodeValue));
        }

        // збереження customer
        private bool SaveCustomer(Customer customer)
        {
            var relust = _service.Save(customer);
            return relust;
        }

        //public void SwitchToCabinet(int id)
        //{
        //    if (cabinet == null)
        //    {
        //        cabinet = new CabinetSmallRight(TypeRights.SmallRights);
        //        var a = new CalculationInfoControlPresenter(cabinet.pagesControl.calculationCtrl, _service);
        //        var b = new ReportsControlPresenter(cabinet.pagesControl.reportsControl, _service);
        //        cabinet.OnGridRowSelectedChaged += Cabinet_OnGridRowSelectedChaged;
        //        cabinet.OnButtonBackClick += Cabinet_OnButtonBackClick;
        //        cabinet.OnAddNewCustomer += Cabinet_OnAddNewCustomer;
        //        cabinet.OnEditCustomer += Cabinet_OnEditCustomer1;
        //        cabinet.OnSaveCustomer += Cabinet_OnSaveCustomer;
        //        cabinet.OnChangeLicenseStatus += Cabinet_OnChangeLicenseStatus;
        //        cabinet.pagesControl.calculationCtrl.UpdateData += CalculationCtrl_UpdateData;
        //        cabinet.SetDictionary(_service.GetDictionary());
        //        cabinet.SetGridDataSource(getMainView());
        //        cabinet.Dock = DockStyle.Fill;
        //    }

        //    cabinet.Rights = TypeRights.SmallRights;
        //    cabinet.FilterString = _mainGrid?.FilterString ?? string.Empty;
        //    cabinet.SetSelectCustomer(id);
        //    _currentControl = cabinet;
        //    _switcher.SwitchView(cabinet);
        //}

        //private void CalculationCtrl_UpdateData(int id)
        //{
        //    cabinet.pagesControl.SetCustomerData(_service.GetData(id));
        //    cabinet.pagesControl.reportsControl.Customer = _service.GetRatedListForCust(id);
        //}

        private bool Cabinet_OnChangeLicenseStatus(ipsFormsDesign.Model.LicenseAgreement agr, int version, int status, bool changeVer)
        {
            var relust = _service.SetLicAgreementStatus(agr, version, status, changeVer);
            return relust;
        }



        private bool Form_OnSaveCustomerNeed(ipsFormsDesign.Model.Customer cust)
        {
            var result = _service.Save(cust);
            return result;
        }
    }
}
