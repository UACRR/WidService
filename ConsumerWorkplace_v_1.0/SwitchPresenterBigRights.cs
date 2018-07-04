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
    class SwitchPresenterBigRights
    {
        private readonly MainViewSwitcher _switcher;
        private GlobalControlConsumerCabinet cabinet = null;
        private GlobalControlConsumerMainGrid mainGrid = null;
        private Control _currentControl = null;
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
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
            _currentNodeValue = (e.Node.Value is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None);
            // Передати в поточний контрол зміну фільтра ???
            mainGrid?.SetGridDataSource(getMainView());
            cabinet?.SetGridDataSource(getMainView());
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
            return _service.getMainViewBR(_currentNodeValue);
        }

        public void SwitchToGrid(int id = 0)
        {
            if (mainGrid == null)
            {
                mainGrid = new GlobalControlConsumerMainGrid();
                mainGrid.OnGridButtonClick += MainGrid_OnGridButtonClick;
                mainGrid.OnAddNewCustomer += MainGrid_OnAddNewCustomer;
                mainGrid.SetDictionary(_service.GetDictionary());
                mainGrid.SetGridDataSource(getMainView());

                mainGrid.Dock = DockStyle.Fill;
            }
            mainGrid.FilterString = cabinet?.FilterString ?? string.Empty;
            if (id != 0)
                mainGrid.SetSelectCustomer(id);

            _currentControl = mainGrid;
            _switcher.SwitchView(mainGrid);
        }

        public void SwitchToCabinet(int id)
        {
            if (cabinet == null)
            {
                cabinet = new GlobalControlConsumerCabinet(TypeRights.BigRights);
                cabinet.OnGridRowSelectedChaged += Cabinet_OnGridRowSelectedChaged;
                cabinet.OnButtonBackClick += Cabinet_OnButtonBackClick;
                cabinet.OnAddNewCustomer += Cabinet_OnAddNewCustomer;
                cabinet.OnEditCustomer += Cabinet_OnEditCustomer1;
                cabinet.OnSaveCustomer += Cabinet_OnSaveCustomer;
                cabinet.SetDictionary(_service.GetDictionary());
                cabinet.SetGridDataSource(getMainView());
                cabinet.Dock = DockStyle.Fill;
            }
            cabinet.Rights = TypeRights.BigRights;
            cabinet.FilterString = mainGrid?.FilterString ?? string.Empty;
            cabinet.SetSelectCustomer(id);
            _currentControl = cabinet;
            _switcher.SwitchView(cabinet);
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
            var _cust = _service.GetData(custId);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.getAutoCompleteList, _service.GetData ,false, TypeRights.BigRights ) { StartPosition = FormStartPosition.CenterParent };
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
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict, _service.getAutoCompleteList, _service.GetData, true, TypeRights.BigRights) { StartPosition = FormStartPosition.CenterParent };
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void UpdateData(int id)
        {
            if (_currentControl == cabinet)
            {
                cabinet?.SetGridDataSource(getMainView());
                cabinet?.SetSelectCustomer(id);
            }

            if (_currentControl == mainGrid)
            {
                mainGrid?.SetGridDataSource(getMainView());
                mainGrid?.SetSelectCustomer(id);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        private bool Form_OnSaveCustomerNeed(ipsFormsDesign.Model.Customer cust)
        {
            var result = _service.Save(cust);
            return result;
        }

        private ipsFormsDesign.Model.Customer Cabinet_OnGridRowSelectedChaged(int id)
        {
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
