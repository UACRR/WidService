using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RegisterControls
{
    public partial class SearchObjectView : RadForm
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

        private readonly BindingList<RegisterItemViewModel> _registerItemList;
        public ICollection<RegisterItemViewModel> RegisterItemList => _registerItemList;

        private readonly BindingList<RegisterSearchObject> _foundedObjectList;
        public ICollection<RegisterSearchObject> FoundedObjectList => _foundedObjectList;

        private RegisterSearchObject _registerSearchObject;
        public RegisterSearchObject SelectedRegisterSearchObject
        {
            get => gvFoundedObjectList.CurrentRow?.DataBoundItem as RegisterSearchObject;
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
            StartPosition = FormStartPosition.CenterScreen;

            _registerItemList = new BindingList<RegisterItemViewModel>();
            _foundedObjectList = new BindingList<RegisterSearchObject>();

            ctrlRegisterItemList.DataSource = _registerItemList;
            bsRegisterSearchObject.DataSource = _foundedObjectList;
            //gvFoundedObjectList.DataSource = _foundedObjectList;

            ctrlRegisterItemList.ShowObjectDuration = false;
            ctrlRegisterItemList.AllowShowDeleteCommand = false;
        }

        public void Run()
        {
            ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _presenter.SearchInLocal(ctrlRegisterItemList.SelectedRegisterItem);
        }

        private void btnSearchWID_Click(object sender, EventArgs e)
        {
            _presenter.SearchInWID(ctrlRegisterItemList.SelectedRegisterItem);
        }

        public void StartWaiting()
        {
            waitingBar.StartWaiting();
        }

        public void StopWaiting()
        {
            waitingBar.StopWaiting();
        }

        private void gvFoundedObjectList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "LinkColumn")
            {
                _presenter.LinkObjectToRegisterItem(ctrlRegisterItemList.SelectedRegisterItem, SelectedRegisterSearchObject);
            }
        }

        private void gvFoundedObjectList_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            if (gvFoundedObjectList.RowCount == 0)
                gvFoundedObjectList.TableElement.Text = "Для пошуку співпадінь натисніть \"Шукати\"";
            else
                gvFoundedObjectList.TableElement.Text = "";
        }

        private void ctrlRegisterItemList_SelectedRegisterItemChanged(object sender, EventArgs e)
        {
            _foundedObjectList.Clear();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _presenter.Apply();
        }
    }
}
