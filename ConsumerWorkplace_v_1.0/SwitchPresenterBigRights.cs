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
        private GlobalControlConsumerMainGridBR _mainGridBr = null;
        private GlobalControlConsumerCabinetBR _cabinetBr = null;
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
            _mainGridBr?.SetGridDataSource(getMainView());
            _cabinetBr?.SetGridDataSource(getMainView());
        }

        public IList<ConsumerMainView> getMainView()
        {
            // return _service.getMainViewBR(_currentNodeValue);
            return new List<ConsumerMainView>();
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
                _mainGridBr.SetGridDataSource(getMainView());
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
                _cabinetBr.SetAnketaDictionaties(_service.GetDictionary());
                _cabinetBr.SetGridDataSource(getMainView());
                _cabinetBr.Dock = DockStyle.Fill;
            }

            _cabinetBr.FilterString = _mainGridBr?.FilterString ?? string.Empty;
            _cabinetBr.SetSelectCustomer(id);
            _currentControl = _cabinetBr;
            _switcher.SwitchView(_cabinetBr);
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

        private ipsFormsDesign.Model.Customer CabinetBr_OnCustomerUpdateDataNeed(int id)
        {
            return _service.GetData(id);
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
                _cabinetBr?.SetGridDataSource(getMainView());
                _cabinetBr?.SetSelectCustomer(id);
            }

            if (_currentControl == _mainGridBr)
            {
                _mainGridBr?.SetGridDataSource(getMainView());
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
