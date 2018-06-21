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
        private Control _currentControl = null;
        private ConsumerFilterEnum _currentNodeValue = ConsumerFilterEnum.None;
        private ConsumerService _service = null;


        public SwitchPresenter(MainViewSwitcher switcher, ConsumerService service,RadTreeView treeView )
        {
            _switcher = switcher;
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            _service = service;
            SwitchToCabinet();

        }

        private void TreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (_currentControl == null)
                return;
            _currentNodeValue =  (e.Node.Value is ConsumerFilterEnum ? (ConsumerFilterEnum) e.Node.Value : ConsumerFilterEnum.None);
            // Передати в поточний контрол зміну фільтра ???
            cabinet.SetGridDataSource(getMainView());


        }

        public void SwitchToGrid()
        {

        }

        public IList<ConsumerMainView> getMainView()
        {
            return _service.getMainView(_currentNodeValue);
        }
        public void SwitchToCabinet()
        {
            if (cabinet == null)
            {
                cabinet = new GlobalControlConsumerCabinet();
                cabinet.SetDictionary( _service.GetDictionary());
                cabinet.SetGridDataSource(getMainView());

                cabinet.Dock = DockStyle.Fill;
                cabinet.OnGridRowSelectedChaged += Cabinet_OnGridRowSelectedChaged; ;
            }

            _currentControl = cabinet;
            // _currentControl.SetFilter(_currentNodeValue);
            _switcher.SwitchView( cabinet );
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
