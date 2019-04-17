using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.Common.Enums;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public partial class TabNavigationControl : UserControl
    {
        private readonly Color GrayColor = Color.DarkGray;
        private RadPageView _pageView;
        private bool _buttonClick;
        public event EventHandler SaveClick;
        public event EmptyEventHandler CancelClick;

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
                    ChangeColorTabs();
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
                    btnSave.Click += btnSave_Click;
                    break;
            }
        }

        // < попередня вкладка
        private void btnBack_Click(object sender, EventArgs e)
        {
            TabNavigateAction(NavigateType.Previous);
        }

        // > наступна вкладка
        private void btnNext_Click(object sender, EventArgs e)
        {
            TabNavigateAction(NavigateType.Next);
        }

        // зберегти
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClick?.Invoke(sender, e);
        }

        // скасувати
        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClick?.Invoke();
        }

        /// <summary>
        /// Здійснити перехід на іншу вкладку
        /// </summary>
        /// <param name="navigateType">вперед/назад</param>
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

            ChangeColorTabs();
        }

        private void ChangeColorTabs()
        {
            foreach (var page in _pageView.Pages)
                page.Item.ForeColor = _pageView.SelectedPage == page ? DefaultForeColor : GrayColor;
        }

        private void pageView_SelectedPageChanging(object sender, RadPageViewCancelEventArgs e)
        {
            if (!_buttonClick)
                e.Cancel = true;
            else
                _buttonClick = false;
        }
    }
}
