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

        public delegate void GridButtonClick(int id);
        public event GridButtonClick OnGridButtonClick;
        public event EventHandler OnAddNewCustomer;

        public string FilterString
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public GlobalControlConsumerMainGrid()
        {
            InitializeComponent();
            gvViewConsumers.CurrentRowChanged += GvViewConsumers_CurrentRowChanged;
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
            OnGridButtonClick?.Invoke(_rowId);
        }

        public void SetDictionary(AnketaDictionaties dictionaties)
        {

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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewConsumers.MasterTemplate.Refresh();
        }

        private void gvViewConsumers_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewConsumers.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewConsumers.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvViewConsumers.EndUpdate(false);
                return;
            }
            //фільтр не пустий
            gvViewConsumers.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewConsumers.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvViewConsumers.EndUpdate(false);
            }
        }
    }
}
