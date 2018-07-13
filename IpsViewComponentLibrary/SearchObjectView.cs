using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class SearchObjectView : Telerik.WinControls.UI.RadForm
    {
        private SearchObjectPresenter _presenter;
        public SearchObjectPresenter Presenter
        {
            set
            {
                if (_presenter == null)
                    _presenter = value;
            }
        }

        private BindingList<RegisterItem> _registerItemList;
        public ICollection<RegisterItem> RegisterItemList
        {
            get { return _registerItemList; }
        }

        public SearchObjectView()
        {
            InitializeComponent();

            _registerItemList = new BindingList<RegisterItem>();

            ctrlRegisterItemList.DataSource = _registerItemList;
        }

        public void Run()
        {
            ShowDialog();
        }
    }
}
