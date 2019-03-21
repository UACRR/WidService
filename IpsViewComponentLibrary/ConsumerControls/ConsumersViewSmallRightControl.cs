using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ConsumersViewSmallRightControl : UserControl
    {
        public event LoadCustomerCabinetSREventHandler OnLoadCustomerCabinetNeed;
        public event EventHandler OnAddNewCustomer;
        public ConsumerSmallRightView ViewRow => gvViewConsumers.CurrentRow?.DataBoundItem as ConsumerSmallRightView;
        private readonly GridStateRecorder _gridStateRecorder = new GridStateRecorder();

        public ConsumersViewSmallRightControl()
        {
            InitializeComponent();
            _gridStateRecorder.AddGrid(gvViewConsumers);
            ctrlSearch.SetUsageGrid(gvViewConsumers);
        }

        public void SetGridDataSource(IList<ConsumerSmallRightView> source, bool withSaveRow = true)
        {
            if (withSaveRow)
            {
                _gridStateRecorder.RecordState();
                gvViewConsumers.DataSource = source;
                _gridStateRecorder.RestoreState();
            }
            else
            {
                _gridStateRecorder.ClearGridStates();
                gvViewConsumers.DataSource = source;
            }
        }

        private void rGridViewConsumers_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            OnLoadCustomerCabinetNeed?.Invoke(e.Row.DataBoundItem as ConsumerSmallRightView);
        }

        // створити споживача юридичної особи
        private void btnAddJurConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(3, EventArgs.Empty);
        }

        // створити споживача фізичної особи
        private void btnAddPhisConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(1, EventArgs.Empty);
        }

        private void gvViewConsumers_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnLoadCustomerCabinetNeed?.Invoke(e.Row.DataBoundItem as ConsumerSmallRightView);
        }
    }
}
