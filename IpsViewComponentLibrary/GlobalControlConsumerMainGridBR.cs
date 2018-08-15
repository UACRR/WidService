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
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class GlobalControlConsumerMainGridBR : UserControl
    {
        private int _rowId;

        /// <summary>
        /// Рядкове начення фільтра
        /// </summary>
        public string FilterString
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public delegate void GridButtonViewClick(int id, CabinetTabType tabType = CabinetTabType.None);
        public event GridButtonViewClick OnGridButtonViewClick;

        public delegate void AddNewCustomer(PersonType person);
        public event AddNewCustomer OnAddNewCustomer;


        public GlobalControlConsumerMainGridBR()
        {
            InitializeComponent();
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
            switch (e.Column.FieldName)
            {
                case "btnsFiles":
                {
                    OnGridButtonViewClick?.Invoke(_rowId, CabinetTabType.Files);
                }break;

                case "btnsView":
                {
                    OnGridButtonViewClick?.Invoke(_rowId);
                }
                    break;
            }
        }

        private void gvViewConsumers_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            _rowId = (int?)e?.CurrentRow?.Cells["CustId"]?.Value ?? -1;
        }


        private void btnNewConsumer_Click(object sender, EventArgs e)
        {
            OnAddNewCustomer?.Invoke(PersonType.JuridicalPerson);
        }

        #region ФІЛЬТРАЦІЯ (пошук)

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

        #endregion
    }
}
