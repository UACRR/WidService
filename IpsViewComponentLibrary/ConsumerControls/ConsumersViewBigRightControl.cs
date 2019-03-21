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
        public MainGridConsumerBigRightView ViewRow => gvViewConsumers?.CurrentRow?.DataBoundItem as MainGridConsumerBigRightView;
        public event LoadCustomerCabinetEventHandler OnLoadCustomerCabinetNeed;
        public event EventHandler OnAddNewCustomer;
        private readonly GridStateRecorder _gridStateRecorder = new GridStateRecorder();

        public ConsumersViewBigRightControl()
        {
            InitializeComponent();
            _gridStateRecorder.AddGrid(gvViewConsumers);
            ctrlSearch.SetUsageGrid(gvViewConsumers);
        }

        /// <summary>
        /// <summary>
        /// Обрати рядок по ID
        /// </summary>
        /// <param name="custId"></param>
        public void SetSelectCustomer(int custId)
        {
            if (gvViewConsumers.Rows.Count != 0)
                gvViewConsumers.CurrentRow = gvViewConsumers.Rows.SingleOrDefault(rec => (int)rec.Cells["CustId"].Value == custId);
        }

        /// <summary>
        /// Джерело даних для грід
        /// </summary>
        /// <param name="source"></param>
        public void SetGridDataSource(object source, bool withSaveRow = true)
        {
            if (withSaveRow)
            {
                _gridStateRecorder.RecordState();
                gvViewConsumers.DataSource = source;
                // show count Consumers
                lblCountConsumers.Text = gvViewConsumers.RowCount.ToString();
                _gridStateRecorder.RestoreState();
            }
            else
            {
                _gridStateRecorder.ClearGridStates();
                gvViewConsumers.DataSource = source;
                // show count Consumers
                lblCountConsumers.Text = gvViewConsumers.RowCount.ToString();
            }
        }

        private void gvViewConsumers_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            OnLoadCustomerCabinetNeed?.Invoke((e.Row.DataBoundItem as MainGridConsumerBigRightView).CustId);
        }

        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(sender, e);
        }

        private void gvViewConsumers_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnLoadCustomerCabinetNeed?.Invoke((e.Row.DataBoundItem as MainGridConsumerBigRightView).CustId);
        }
    }
}
