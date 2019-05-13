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

        public ConsumersViewSmallRightControl()
        {
            InitializeComponent();
            ctrlGridRowCount.RadGridViewDataSource = gvViewConsumers;
            ctrlSearch.SetUsageGrid(gvViewConsumers);
        }

        public object DataSource
        {
            get => bsConsumerSmallRightView.DataSource;
            set
            {
                bsConsumerSmallRightView.DataSource = value;
                bsConsumerSmallRightView.ResetBindings(false);
            }
        }

        private void gvConsumers_CommandCellClick(object sender, GridViewCellEventArgs e)
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
