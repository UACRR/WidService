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
        public event LoadCustomerCabinetEventHandler OnLoadCustomerCabinetNeed;
        public event EventHandler OnAddNewCustomer;

        public GlobalControlConsumerMainGrid()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewConsumers);
        }

        public void SetGridDataSource(IList<ConsumerMainView> source)
        {
            gvViewConsumers.DataSource = source;
        }

        private void rGridViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            OnLoadCustomerCabinetNeed?.Invoke((e.Row.DataBoundItem as ConsumerMainView).CustId);
        }

        public void SetSelectCustomer(int custId)
        {
            if (gvViewConsumers.Rows.Count != 0)
                gvViewConsumers.CurrentRow = gvViewConsumers.Rows.SingleOrDefault(rec => (int)rec.Cells["CustId"].Value == custId);
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
    }
}
