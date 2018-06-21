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
        private GlobalControlConsumerCabinet cabinet = null;
        private GlobalControlConsumerMainGrid mainGrid = null;
        private Control _currentControl = null;
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private ConsumerService _service = null;


        public SwitchPresenter(MainViewSwitcher switcher, ConsumerService service,RadTreeView treeView )
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
            _currentNodeValue =  (e.Node.Value is ConsumerFilterEnum @enum ? @enum : ConsumerFilterEnum.None);
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
            return _service.getMainView(_currentNodeValue);
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

            if (id != 0)
                mainGrid.SetSelectCustomer(id);

            _currentControl = mainGrid;
            _switcher.SwitchView(mainGrid);
        }

        public void SwitchToCabinet(int id)
        {
            if (cabinet == null)
            {
                cabinet = new GlobalControlConsumerCabinet();
                cabinet.OnGridRowSelectedChaged += Cabinet_OnGridRowSelectedChaged;
                cabinet.OnButtonBackClick += Cabinet_OnButtonBackClick;
                cabinet.OnAddNewCustomer += Cabinet_OnAddNewCustomer;
                cabinet.SetDictionary(_service.GetDictionary());
                cabinet.SetGridDataSource(getMainView());

                cabinet.Dock = DockStyle.Fill;
            }

            cabinet.SetSelectCustomer(id);
            _currentControl = cabinet;
            _switcher.SwitchView(cabinet);
        }

        private void Cabinet_OnAddNewCustomer(object sender, EventArgs e)
        {
            NewConsumer();
        }

        private void MainGrid_OnAddNewCustomer(object sender, EventArgs e)
        {
            NewConsumer();
        }

        private void NewConsumer()
        {
            int custType = 3; // Юридична особа
            var _cust = _service.NewCustomer(custType);
            var _dict = _service.GetDictionary();
            AnketaConsumerForm form = new AnketaConsumerForm(_cust, _dict);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
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
