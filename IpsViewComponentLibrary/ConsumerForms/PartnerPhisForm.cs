using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class PartnerPhisForm : Telerik.WinControls.UI.RadForm
    {
        private bool _buttonClick = false;
        public PartnerPhisForm()
        {
            InitializeComponent();
            btnBack.Text = "< ";
            btnBack.Enabled = false;
            btnNext.Text = pageView.Pages[1].Text + " >";
        }

        private void TabNavigateAction(NavigateType navigateType)
        {
            int index = pageView.SelectedPage.TabIndex;
            _buttonClick = true;
            switch (navigateType)
            {
                case NavigateType.Next:
                    if(index == pageView.Pages.Last().TabIndex) break;
                    pageView.SelectedPage = pageView.Pages[index + 1];
                    break;
                case NavigateType.Previous:
                    if(index == 0) break;
                    pageView.SelectedPage = pageView.Pages[index - 1];
                    break;
            }
            index = pageView.SelectedPage.TabIndex;

            btnBack.Enabled = index != 0;
            btnBack.Text = btnBack.Enabled ? "< " + pageView.Pages[index - 1].Text : "< ";

            btnNext.Enabled = index != pageView.Pages.Last().TabIndex;
            btnNext.Text = btnNext.Enabled ? pageView.Pages[index + 1].Text + " >" : " >";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TabNavigateAction(NavigateType.Previous);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabNavigateAction(NavigateType.Next);
        }

        private void pageView_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            if (!_buttonClick)
                e.Cancel = true;
            else
                _buttonClick = false;
        }
    }

    public enum NavigateType
    {
        Next,
        Previous
    }
}
