using System;
using System.ComponentModel;
using System.Windows.Forms;
using Telerik.WinControls;
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
                    SetRelatedPageView(value);
                }
            }
        }

        private void SetRelatedPageView(RadPageView value)
        {
            if (_relatedPageView != null)
            {
                UnwireEvents();
            }

            _relatedPageView = value;

            WireEvents();

            UpdateButtonsState();
        }

        private void RelatedPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void RelatedOageView_VisibleChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        protected int SelectedPageIndex
        {
            get => _relatedPageView.Pages.IndexOf(_relatedPageView.SelectedPage);
        }

        public PageSelectorControl()
        {
            InitializeComponent();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            var prevPage = GetPrevPage();
            if (prevPage != null)
            {
                _relatedPageView.SelectedPage = prevPage;
                UpdateButtonsState();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var nextPage = GetNextPage();
            if (nextPage != null)
            {
                _relatedPageView.SelectedPage = nextPage;
                UpdateButtonsState();
            }
        }

        private void UpdateButtonsState()
        {
            if (IsDesignMode)
                return;

            var prevPage = GetPrevPage();
            var nextPage = GetNextPage();

            btnPrev.Text = prevPage == null ? "" : "< " + prevPage.Text;
            btnNext.Text = nextPage == null ? "" : nextPage.Text + " >";

            btnPrev.Visible = prevPage != null;
            btnNext.Visible = nextPage != null;
        }

        private RadPageViewPage GetPrevPage()
        {
            if (SelectedPageIndex == 0)
                return null;

            // looking for prev visible page
            for (var i = SelectedPageIndex - 1; i >= 0; i--)
            {
                if (_relatedPageView.Pages[i].Item.Visibility != ElementVisibility.Visible)
                    continue;

                return _relatedPageView.Pages[i];
            }

            return null;
        }

        private RadPageViewPage GetNextPage()
        {
            if (SelectedPageIndex == _relatedPageView.Pages.Count - 1)
                return null;
            
            // looking for next visible page
            for (var i = SelectedPageIndex + 1; i <= _relatedPageView.Pages.Count; i++)
            {
                if (_relatedPageView.Pages[i].Item.Visibility != ElementVisibility.Visible)
                    continue;

                return _relatedPageView.Pages[i];
            }

            return null;
        }

        private void WireEvents()
        {
            _relatedPageView.SelectedPageChanged += RelatedPageView_SelectedPageChanged;

            foreach (var page in _relatedPageView.Pages)
            {
                page.VisibleChanged += RelatedOageView_VisibleChanged;
            }
        }

        private void UnwireEvents()
        {
            _relatedPageView.SelectedPageChanged -= RelatedPageView_SelectedPageChanged;

            foreach (var page in _relatedPageView.Pages)
            {
                page.VisibleChanged -= RelatedOageView_VisibleChanged;
            }
        }
    }
}
