using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public partial class RightholderItemView : Telerik.WinControls.UI.RadForm
    {
        public RightholderItemView()
        {
            InitializeComponent();

            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private RightholderItemViewPresenter _presenter;
        public RightholderItemViewPresenter Presenter
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

        public void Run()
        {
            Show();
        }
    }
}
