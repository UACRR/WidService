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
        public delegate void GridButtonClick(int id);
        public event GridButtonClick OnGridButtonClick;

        public GlobalControlConsumerMainGrid()
        {
            InitializeComponent();
        }

        public void SetGridDataSource(IList<ConsumerMainView> source)
        {
            gvViewConsumers.DataSource = source;
        }

        private void rGridViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            int custId = Convert.ToInt32(gvViewConsumers.Rows[e.RowIndex].Cells["CustId"].Value);
            OnGridButtonClick?.Invoke(custId);
            //_cust = GetCustomer(custId);
            //if (_cust?.Client?.ClnBusinessPlace != null)
            //    IsPlaceIn = _cust.Client.ClnBusinessPlace.Count != 0;
            //SetDataSources();
            //SetConsumerPageViewEdit();
        }

        public void SetDictionary(AnketaDictionaties dictionaties)
        {

        }

        public void SetSelectCustomer(int custId)
        {
            if (gvViewConsumers.Rows.Count != 0)
                gvViewConsumers.CurrentRow = gvViewConsumers.Rows[gvViewConsumers.Rows.Where(rec => (int)rec.Cells["CustId"].Value == custId).Select(rec => rec.Index).SingleOrDefault()];
        }

    }
}
