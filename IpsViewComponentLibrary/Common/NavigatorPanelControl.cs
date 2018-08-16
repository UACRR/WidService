using System;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.Common
{
    public partial class NavigatorPanelControl : UserControl
    {
        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                UpdateCurrentPage();
                OnCurrentPageChanged();
            }
        }

        private int _totalPages;
        public int TotalPages
        {
            get { return _totalPages; }
            set
            {
                _totalPages = value;
                UpdateTotalPages();
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                UpdatePageSize();
                OnPageSizeChanged();
            }
        }

        public event EventHandler CurrentPageChanged;
        public event EventHandler PageSizeChanged;

        public NavigatorPanelControl()
        {
            InitializeComponent();

            // default values
            _currentPage = 1;
            _pageSize = 20;
            UpdateCurrentPage();
            UpdatePageSize();
        }

        private void btnMoveFirst_Click(object sender, EventArgs e)
        {
            if (CurrentPage != 1)
            {
                CurrentPage = 1;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage -= 1;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage += 1;
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (CurrentPage != TotalPages)
            {
                CurrentPage = TotalPages;
            }
        }

        private void mebPositionItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int page;
                if (int.TryParse(mebPositionItem.Text, out page))
                {
                    if (page < 1)
                    {
                        CurrentPage = 1;
                    }
                    else if (page > TotalPages)
                    {
                        CurrentPage = TotalPages;
                    }
                    else
                    {
                        CurrentPage = page;
                    }
                }
            }
        }

        private void mebCountPerPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int size;
                if (int.TryParse(mebCountPerPage.Text, out size))
                {
                    if (size < 10)
                    {
                        PageSize = 10;
                    }
                    else
                    {
                        PageSize = size;
                    }
                }
            }
        }

        private void UpdateCurrentPage()
        {
            mebPositionItem.Text = _currentPage.ToString();
        }

        private void UpdateTotalPages()
        {
            lblCountItem.Text = string.Format(" з {0} ", TotalPages);
        }

        private void UpdatePageSize()
        {
            mebCountPerPage.Text = _pageSize.ToString();
        }

        protected void OnCurrentPageChanged()
        {
            CurrentPageChanged?.Invoke(this, EventArgs.Empty);
        }

        protected void OnPageSizeChanged()
        {
            PageSizeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
