using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using Telerik.WinControls.UI;


namespace ConsumerWorkplace_v_1._0
{
    public class SwitchPresenter
    {
        private readonly MainViewSwitcher _switcher;
        private CabinetSmallRight cabinet = null;
        private GlobalControlConsumerMainGrid mainGrid = null;
        private Control _currentControl = null;
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private ConsumerService _service = null;


        public SwitchPresenter(MainViewSwitcher switcher, ConsumerService service, RadTreeView treeView)
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
            _currentNodeValue = (e.Node.Value is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None);
            // Передати в поточний контрол зміну фільтра ???
            mainGrid?.SetGridDataSource(getMainView());
            //cabinet?.SetGridDataSource(getMainView());
        }


        //перейти з гріда до кабінету
        private void MainGrid_OnGridButtonClick(int custId)
        {
            SwitchToCabinet(custId);
        }

        //перейти з кабінету до гріда
        private void Cabinet_OnButtonBackClick(int custId)
        {
            SwitchToGrid(custId);
        }

        public IList<ConsumerMainView> getMainView()
        {
            return _service.getMainView(_currentNodeValue);
        }

        public void SwitchToGrid(int id = 0)
        {
            if (mainGrid == null)
            {
                mainGrid = new GlobalControlConsumerMainGrid();
                mainGrid.OnGridButtonClick += MainGrid_OnGridButtonClick;
                mainGrid.OnAddNewCustomer += MainGrid_OnAddNewCustomer;
                //mainGrid.SetDictionary(_service.GetDictionary());
                mainGrid.SetGridDataSource(getMainView());

                mainGrid.Dock = DockStyle.Fill;
            }
            //mainGrid.FilterString = cabinet?.FilterString ?? string.Empty;
            if (id != 0)
                mainGrid.SetSelectCustomer(id);

            _currentControl = mainGrid;
            _switcher.SwitchView(mainGrid);
        }

        public void SwitchToCabinet(int id)
        {
            if (cabinet == null)
            {
                //cabinet = new CabinetSmallRight(TypeRights.SmallRights);
                var a = new CalculationInfoControlPresenter(cabinet.mсInfoAgrCalc.calculationCtrl, _service);
                var b = new ReportsControlPresenter(cabinet.mсInfoAgrCalc.reportsControl, _service);
                //cabinet.OnGridRowSelectedChaged += Cabinet_OnGridRowSelectedChaged;
                //cabinet.OnButtonBackClick += Cabinet_OnButtonBackClick;
                //cabinet.OnAddNewCustomer += Cabinet_OnAddNewCustomer;
                cabinet.OnEditCustomer += Cabinet_OnEditCustomer1;
                cabinet.OnSaveCustomer += Cabinet_OnSaveCustomer;
                cabinet.OnChangeLicenseStatus += Cabinet_OnChangeLicenseStatus;
                cabinet.mсInfoAgrCalc.calculationCtrl.UpdateData += CalculationCtrl_UpdateData;
                //cabinet.SetDictionary(_service.GetDictionary());
                //cabinet.SetGridDataSource(getMainView());
                cabinet.Dock = DockStyle.Fill;
            }

            cabinet.Rights = TypeRights.SmallRights;
            //cabinet.FilterString = mainGrid?.FilterString ?? string.Empty;
            //cabinet.SetSelectCustomer(id);
            _currentControl = cabinet;
            _switcher.SwitchView(cabinet);
        }

        private void CalculationCtrl_UpdateData(int id)
        {
            cabinet.mсInfoAgrCalc.SetCustomerData(_service.GetData(id));
            cabinet.mсInfoAgrCalc.reportsControl.Customer = _service.GetRatedListForCust(id);

        }

        private bool Cabinet_OnChangeLicenseStatus(ipsFormsDesign.Model.LicenseAgreement agr, int version, int status, bool changeVer)
        {
            var relust = _service.SetLicAgreementStatus(agr, version, status, changeVer);
            UpdateData(agr.CustId ?? default(int));
            return relust;
        }

        private bool Cabinet_OnSaveCustomer(ipsFormsDesign.Model.Customer customer)
        {
            var relust = _service.Save(customer);
            UpdateData(customer.CustId);
            return relust;
        }

        private void Cabinet_OnEditCustomer1(int id)
        {
            EditConsumer(id);
        }

        private void Cabinet_OnAddNewCustomer(object sender, EventArgs e)
        {
            NewConsumer();
        }

        private void MainGrid_OnAddNewCustomer(object sender, EventArgs e)
        {
            NewConsumer();
        }

        /// <summary>
        /// Редагування існуючого споживача юридичної особи
        /// </summary>
        private void EditConsumer(int custId)
        {

            //Task.Run(() => {
            //    var Customer = _service.GetCustomerRegisterRatedList(custId);
            //    cabinet.mсInfoAgrCalc.reportsControl.BeginInvoke((Action)(() => cabinet.mсInfoAgrCalc.reportsControl.Customer = Customer));
            //});
            var _cust = _service.GetData(custId);
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
            UpdateData(_cust.CustId);
        }

        /// <summary>
        /// Додавання нового споживача юридична особа (діалогова форма)
        /// </summary>
        private void NewConsumer()
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
            UpdateData(_cust.CustId);
        }

        private void UpdateData(int id)
        {
            if (_currentControl == cabinet)
            {
                //cabinet?.SetGridDataSource(getMainView());
                //cabinet?.SetSelectCustomer(id);
            }

            if (_currentControl == mainGrid)
            {
                mainGrid?.SetGridDataSource(getMainView());
                mainGrid?.SetSelectCustomer(id);
            }
        }

        private bool Form_OnSaveCustomerNeed(ipsFormsDesign.Model.Customer cust)
        {
            var result = _service.Save(cust);
            return result;
        }

        private ipsFormsDesign.Model.Customer Cabinet_OnGridRowSelectedChaged(int id)
        {
            //if (_currentControl == cabinet)
                //Task.Run(() => {
            //var Customer = _service.GetCustomerRegisterRatedList(id);
            cabinet.mсInfoAgrCalc.reportsControl.Customer = _service.GetRatedListForCust(id);
            
            //cabinet.mсInfoAgrCalc.reportsControl.BeginInvoke((Action)(() => ));
        //});
            return _service.GetData(id);
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
