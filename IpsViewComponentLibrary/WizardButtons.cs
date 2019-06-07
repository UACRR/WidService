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

namespace TelerikWizard
{
    public partial class WizardButtons : UserControl
    {
        private int _pageIndex;
        private RadPageView _owner;
        public WizardButtons()
        {
            InitializeComponent();
        }

        public void EnterOnPage()
        {
            // Page -> PageView
            _owner = Parent?.Parent as RadPageView;
            if (_owner != null)
            {
                _pageIndex = _owner.Pages.IndexOf(Parent as RadPageViewPage);
                radButton2.Enabled = _pageIndex == _owner.Pages.Count - 1 ? false : true;
                radButton1.Enabled = _pageIndex == 0 ? false : true;
                // radButton1.Visible = _pageIndex == 0 ? false : true;
                // radButton2.Visible = _pageIndex == _owner.Pages.Count - 1 ? false : true;
            }
        }

        private void onClick(object sender, EventArgs e)
        {
            if (_owner.SelectedPage == Parent)
                _owner.SelectedPage = _owner.Pages[sender == radButton1 ? _pageIndex - 1 : _pageIndex + 1];
        }

        private void radButton1_MouseClick(object sender, MouseEventArgs e)
        {
            onClick(sender, null);
        }

        private void radButton1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                onClick(sender, null);
        }
    }
}
