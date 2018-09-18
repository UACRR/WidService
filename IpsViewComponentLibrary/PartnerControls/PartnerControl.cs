using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerControl : UserControl
    {
        public PartnerControl()
        {
            InitializeComponent();
        }

        private void btnNewPartnerJur_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPartnerPhis_Click(object sender, EventArgs e)
        {

        }

        #region ФІЛЬТРАЦІЯ (пошук)

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewPartners.MasterTemplate.Refresh();
        }

        private void gvViewConsumers_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewPartners.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewPartners.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvViewPartners.EndUpdate(false);
                return;
            }
            //фільтр не пустий
            gvViewPartners.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewPartners.ColumnCount; i++)
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
                gvViewPartners.EndUpdate(false);
            }
        }

        #endregion
    }
}
