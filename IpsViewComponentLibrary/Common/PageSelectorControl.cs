using System;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    public partial class PageSelectorControl : UserControl
    {
        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private RadPageView _relatedPageView;
        public RadPageView RelatedPageView
        {
            get { return _relatedPageView; }
            set
            {
                if (_relatedPageView != value)
                {
                    if (_relatedPageView != null)
                    {
                        _relatedPageView.SelectedPageChanged -= RelatedPageView_SelectedPageChanged;
                    }
                    _relatedPageView = value;
                    _relatedPageView.SelectedPageChanged += RelatedPageView_SelectedPageChanged;
                    UpdateButtonsState();
                }
            }
        }

        private void RelatedPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        protected int SelectedPageIndex
        {
            get => _relatedPageView.Pages.IndexOf(_relatedPageView.SelectedPage);
        }

        public bool IsFirstPageSelected
        {
            get => SelectedPageIndex == 0;
        }

        public bool IsLastPageSelected
        {
            get => SelectedPageIndex == _relatedPageView.Pages.Count - 1;
        }

        public PageSelectorControl()
        {
            InitializeComponent();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (IsFirstPageSelected)
                return;

            _relatedPageView.SelectedPage = _relatedPageView.Pages[SelectedPageIndex - 1];
            UpdateButtonsState();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsLastPageSelected)
                return;

            _relatedPageView.SelectedPage = _relatedPageView.Pages[SelectedPageIndex + 1];
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            if (IsDesignMode)
                return;

            btnPrev.Text = GetPrevButtonText();
            btnNext.Text = GetNextButtonText();

            btnPrev.Visible = !IsFirstPageSelected;
            btnNext.Visible = !IsLastPageSelected;
        }

        private string GetNextButtonText()
        {
            if (IsLastPageSelected)
                return "";

            return _relatedPageView.Pages[SelectedPageIndex + 1].Text + " >";
        }

        private string GetPrevButtonText()
        {
            if (IsFirstPageSelected)
                return "";

            return "< " + _relatedPageView.Pages[SelectedPageIndex - 1].Text;
        }
    }
}
