using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace IpsViewComponentLibrary.RegisterControls
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

        public object RegisterItemListDataSource
        {
            get { return ctrlRegisterItemList.DataSource; }
            set { ctrlRegisterItemList.DataSource = value; }
        }

        private BindingList<RegisterItemViewModel> _registerItemList;
        public ICollection<RegisterItemViewModel> RegisterItemList
        {
            get { return _registerItemList; }
        }

        private BindingList<RegisterSearchObject> _foundedObjectList;
        public ICollection<RegisterSearchObject> FoundedObjectList
        {
            get { return _foundedObjectList; }
        }

        private RegisterSearchObject _registerSearchObject;
        public RegisterSearchObject SelectedRegisterSearchObject
        {
            get
            {
                if (gvFoundedObjectList.CurrentRow == null)
                    return null;

                return gvFoundedObjectList.CurrentRow.DataBoundItem as RegisterSearchObject;
            }
            set
            {
                if (_registerSearchObject != value)
                {
                    _registerSearchObject = value;

                    if (_registerSearchObject != null)
                    {
                        var row = gvFoundedObjectList.Rows.FirstOrDefault(r => (int)r.Cells["ObjId"].Value == _registerSearchObject.ObjId);
                        if (row != null)
                        {
                            gvFoundedObjectList.CurrentRow = row;
                        }
                    }
                }
            }
        }

        public SearchObjectView()
        {
            InitializeComponent();

            _registerItemList = new BindingList<RegisterItemViewModel>();
            _foundedObjectList = new BindingList<RegisterSearchObject>();

            ctrlRegisterItemList.DataSource = _registerItemList;
            gvFoundedObjectList.DataSource = _foundedObjectList;
        }

        public void Run()
        {
            ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.Search(ctrlRegisterItemList.SelectedRegisterItem);
        }

        private void gvFoundedObjectList_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "LinkColumn")
            {
                _presenter.LinkObjectToRegisterItem(ctrlRegisterItemList.SelectedRegisterItem, SelectedRegisterSearchObject);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _presenter.Apply();
        }
    }
}
