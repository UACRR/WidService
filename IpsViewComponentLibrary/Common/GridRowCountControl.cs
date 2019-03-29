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
    public partial class GridRowCountControl : UserControl
    {
        private RadGridView _gridView;
        public GridRowCountControl()
        {
            InitializeComponent();
        }

        public RadGridView RadGridViewDataSource
        {
            get => _gridView;
            set
            {
                if (value == null)
                    return;
                
                _gridView = value;
                _gridView.DataBindingComplete += DataBindingComplete;
            }
        }

        private void DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
        {
            if (_gridView?.RowCount is int count)
                lblCount.Text = count.ToString("### ### ###");
            else
                lblCount.Text = "0";
        }
    }
}
