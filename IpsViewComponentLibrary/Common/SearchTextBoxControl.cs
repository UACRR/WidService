using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public partial class SearchTextBoxControl : UserControl
    {
        private RadGridView _gvViewConsumers;
        public SearchTextBoxControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Передати грід в якому буде здійснюватись пошук
        /// </summary>
        /// <param name="grid"></param>
        public void SetUsageGrid(RadGridView grid)
        {
            _gvViewConsumers = grid;
            txtSearch.TextChanged += SearchTextChanged;
            _gvViewConsumers.CustomFiltering += CustomFiltering;
        }

        private void SearchTextChanged(object sender, EventArgs e)
        {
            _gvViewConsumers.MasterTemplate.Refresh();
        }

        private void CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                _gvViewConsumers.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < _gvViewConsumers.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                _gvViewConsumers.EndUpdate(false);
                return;
            }
            //фільтр не пустий
            _gvViewConsumers.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < _gvViewConsumers.ColumnCount; i++)
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
                _gvViewConsumers.EndUpdate(false);
            }
        }
    }
}
