using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class GlobalControlConsumerMainGridBR : UserControl
    {
        private int _rowId;

        public MainGridConsumerBigRightView ViewRow
        {
            get => gvViewConsumers?.CurrentRow?.DataBoundItem as MainGridConsumerBigRightView;
        }
        public event LoadCustomerCabinetBrEventHandler OnLoadCustomerCabinetNeed;
        
        public event EventHandler OnAddNewCustomer;


        public GlobalControlConsumerMainGridBR()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewConsumers);
        }


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
        public void SetGridDataSource(object source)
        {
            // джерело
            gvViewConsumers.DataSource = source;
        }

        private void gvViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            OnLoadCustomerCabinetNeed?.Invoke(_rowId);
        }

        private void gvViewConsumers_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            _rowId = (int?)e?.CurrentRow?.Cells["CustId"]?.Value ?? -1;
        }

        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(sender, e);
        }

    }
}
