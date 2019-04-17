using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IpsViewComponentLibrary.Common.Enums;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public partial class TabNavigationExpandedControl : UserControl
    {
        private readonly Color GrayColor = Color.DarkGray;
        private RadPageView _pageView;
        private bool _buttonClick = false;
        public event EventHandler<bool> SaveClick;

        public TabNavigationExpandedControl()
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
                    ddbtnSave.Enabled = false;
                    break;
                case FLoadType.View:
                    break;
                case FLoadType.Edit:
                    btnBack.Visible = false;
                    btnNext.Visible = false;
                    break;
            }
        }

        // зберегти / ..та погодити
        private void Save_Click(object sender, EventArgs e)
        {
            var accept = ((Telerik.WinControls.RadElement) sender).Name == btnSaveAccepted.Name;
            SaveClick?.Invoke(sender, accept);
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
            ddbtnSave.Enabled = index == _pageView.Pages.Last().TabIndex;
            btnNext.Text = btnNext.Enabled ? _pageView.Pages[index + 1].Text + " >" : " >";

            ChangeColorTabs();
        }

        /// <summary>
        /// Змінити підсвічування вкладок
        /// </summary>
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
