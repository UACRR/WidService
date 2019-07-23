using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.Common
{
    public partial class NavigatorPanelControl : UserControl
    {
        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage;
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
            get => _totalPages;
            set
            {
                _totalPages = value;
                UpdateTotalPages();
            }
        }

        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
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
        
        /// <summary>
        /// Зміна кількості елементів на сторінці закрита для редагування (тільки для читання)
        /// </summary>
        [Browsable(true)]
        public bool ReadOnlyPageSize
        {
            get => !mebCountPerPage.Enabled;
            set => mebCountPerPage.Enabled = !value;
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
                SetSize();
            }
        }

        private void SetSize()
        {
            var sizeString = mebCountPerPage.Text.Replace(" ", string.Empty);
            if (int.TryParse(sizeString, out int size))
            {
                // change current page to 1 without raising CurrentPageChanged event
                _currentPage = 1;
                UpdateCurrentPage();

                PageSize = size < 10 ? 10 : size;
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

        private void mebCountPerPage_Leave(object sender, EventArgs e)
        {
            SetSize();
        }
    }
}
