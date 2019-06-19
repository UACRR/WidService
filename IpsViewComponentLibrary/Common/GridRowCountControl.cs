using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public partial class GridRowCountControl : UserControl
    {
        private const string DefaultCountString = "0";
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
            if (_gridView?.RowCount is int count && count != 0)
                lblCount.Text = count.ToString("### ### ###");
            else
                lblCount.Text = DefaultCountString;
        }
    }
}
