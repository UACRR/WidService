using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.FixationControls
{
    public partial class FixationView : Telerik.WinControls.UI.RadForm
    {
        private FixationPresenter _presenter;
        public FixationPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        public FixationView()
        {
            InitializeComponent();
        }

        public void Run()
        {
            ShowDialog();
        }
    }
}
