using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class SearchObjectView : Telerik.WinControls.UI.RadForm
    {
        private SearchObjectPresenter _presenter;
        public SearchObjectPresenter Presenter
        {
            set
            {
                if (_presenter == null)
                    _presenter = value;
            }
        }

        public SearchObjectView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }
    }
}
