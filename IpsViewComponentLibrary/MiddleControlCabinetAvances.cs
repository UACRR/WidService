using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlCabinetAvances : UserControl
    {
        public MiddleControlCabinetAvances()
        {
            InitializeComponent();
        }

        //перший грід
        private void gvPayments_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvPayments.Rows.Count == 0 || e?.CurrentRow == null) return;

            var row = e.CurrentRow;
        }

        #region ФІЛЬТРАЦІЯ (пошук)

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvPayments.MasterTemplate.Refresh();
        }

        private void gvPayments_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvPayments.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvPayments.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvPayments.EndUpdate(false);
                return;
            }
            //фільтр не пустий
            gvPayments.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvPayments.ColumnCount; i++)
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
                gvPayments.EndUpdate(false);
            }
        }

        #endregion

        //другий грід
        private void gvAvances_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if(gvAvances.Rows.Count == 0 || e?.CurrentRow == null) return;

            var row = e.CurrentRow;
        }

    }
}
