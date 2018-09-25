using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class GlobalControlConsumerMainGrid : UserControl
    {
        private int _rowId;

        public delegate void LoadCustomerByIdEventHandler(int id);
        public event LoadCustomerByIdEventHandler OnLoadCustomerCabinetNeed;
        public event EventHandler OnAddNewCustomer;

        public GlobalControlConsumerMainGrid()
        {
            InitializeComponent();
            gvViewConsumers.CurrentRowChanged += GvViewConsumers_CurrentRowChanged;
            ctrlSearch.SetUsageGrid(gvViewConsumers);
        }

        private void GvViewConsumers_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            var id = (int?) e?.CurrentRow?.Cells["CustId"]?.Value ?? -1;
            _rowId = id;
        }

        public void SetGridDataSource(IList<ConsumerMainView> source)
        {
            gvViewConsumers.DataSource = source;
        }

        private void rGridViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            OnLoadCustomerCabinetNeed?.Invoke(_rowId);
        }

        public void SetSelectCustomer(int custId)
        {
            if (gvViewConsumers.Rows.Count != 0)
                gvViewConsumers.CurrentRow = gvViewConsumers.Rows.SingleOrDefault(rec => (int)rec.Cells["CustId"].Value == custId);
        }

        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(this,EventArgs.Empty);
        }
    }
}
