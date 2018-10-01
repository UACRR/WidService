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

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class TabNavigationControl : UserControl
    {
        private RadPageView _pageView;
        private bool _buttonClick = false;
        public event EventHandler SaveClick;

        public TabNavigationControl()
        {
            InitializeComponent();
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public void SetDefaultState(RadPageView pageView, FLoadType loadType)
        {
            _pageView = pageView;
            switch (loadType)
            {
                case FLoadType.Create:
                    _pageView.SelectedPageChanging += pageView_SelectedPageChanging;
                    btnBack.Text = "< ";
                    btnBack.Enabled = false;
                    btnNext.Text = _pageView.Pages[1].Text + " >";
                    btnSave.DialogResult = DialogResult.OK;
                    break;
                case FLoadType.View:
                    break;
                case FLoadType.Edit:
                    btnBack.Visible = false;
                    btnNext.Visible = false;
                    btnSave.Enabled = true;
                    btnSave.Click += BtnSave_Click;
                    break;
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveClick?.Invoke(sender, e);
        }

        private void TabNavigateAction(NavigateType navigateType)
        {
            int index = _pageView.SelectedPage.TabIndex;
            _buttonClick = true;
            switch (navigateType)
            {
                case NavigateType.Next:
                    if (index == _pageView.Pages.Last().TabIndex) break;
                    _pageView.SelectedPage = _pageView.Pages[index + 1];
                    break;
                case NavigateType.Previous:
                    if (index == 0) break;
                    _pageView.SelectedPage = _pageView.Pages[index - 1];
                    break;
            }
            index = _pageView.SelectedPage.TabIndex;

            btnBack.Enabled = index != 0;
            btnBack.Text = btnBack.Enabled ? "< " + _pageView.Pages[index - 1].Text : "< ";

            btnNext.Enabled = index != _pageView.Pages.Last().TabIndex;
            btnSave.Enabled = index == _pageView.Pages.Last().TabIndex;
            btnNext.Text = btnNext.Enabled ? _pageView.Pages[index + 1].Text + " >" : " >";
        }

        private void pageView_SelectedPageChanging(object sender, Telerik.WinControls.UI.RadPageViewCancelEventArgs e)
        {
            if (!_buttonClick)
                e.Cancel = true;
            else
                _buttonClick = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TabNavigateAction(NavigateType.Previous);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            TabNavigateAction(NavigateType.Next);
        }
    }
    public enum NavigateType
    {
        Next,
        Previous
    }
}
