using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public partial class RightholderView : Telerik.WinControls.UI.RadForm
    {
        public RightholderView()
        {
            InitializeComponent();

            TopLevel = false;
            Dock = DockStyle.Fill;
        }

        private RightholderViewPresenter _presenter;
        public RightholderViewPresenter Presenter
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

        public void ShowView(Control view)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(view);
        }
    }
}
