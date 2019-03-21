using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ConsumersViewBigRightControl : UserControl
    {
        public event LoadCustomerCabinetBREventHandler OnLoadCustomerCabinetNeed;
        public event EventHandler OnAddNewCustomer;

        public ConsumersViewBigRightControl()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvConsumers);
        }

        public object DataSource
        {
            get => bsConsumerBigRightView.DataSource;
            set => bsConsumerBigRightView.DataSource = value;
        }

        private void gvViewConsumers_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (!(e.Row.DataBoundItem is ConsumerBigRightView item))
                return;

            OnLoadCustomerCabinetNeed?.Invoke(item);
        }

        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(sender, e);
        }

        private void gvViewConsumers_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            // ReSharper disable once PossibleNullReferenceException
            OnLoadCustomerCabinetNeed?.Invoke(e.Row.DataBoundItem as ConsumerBigRightView);
        }
    }
}
