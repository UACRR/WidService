using RightholderWorkplaceSeparateForm.Models;
using RightholderWorkplaceSeparateForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public partial class RightholderViewPresenter
    {

        private readonly RightholderView _view;
        private readonly MainViewPresenter _parentPresenter; // TODO: IPresenter or IChildPresenter
        private readonly RightholdersService _service;
        private viewAction _currentViewAction = null;

        public RightholderViewPresenter(RightholderView view, MainViewPresenter parentPresenter)
        {
            _parentPresenter = parentPresenter;
            _view = view;
            _view.Presenter = this;

            _service = new RightholdersService();
        }

        public void Run()
        {
            ShowRightholderList();
            _view.Run();
        }

        public void ShowRightholderList(int id = 0)
        {
            var rightholderListView = new RightholderListView();
            var rightholderListViewPresenter = new RightholderListViewPresenter(rightholderListView, this, _service);
            rightholderListViewPresenter.SelectedRightholderId = id;
            //rightholderListViewPresenter.AddedRightholder += AddRightholder;
            rightholderListViewPresenter.Run();

            _view.ShowView(rightholderListView);
            if (_currentViewAction != null)
                ViewStack.Push(_currentViewAction);
            _currentViewAction = new viewAction { view = rightholderListView,
                doneActionWithParam = (oid) => rightholderListViewPresenter.GetList(oid),
                doneAction = () => rightholderListViewPresenter.GetList(null),
                TypeParam = typeof(RightholderModel)
            };
        }

        public void ShowRightholderItem(int id = 0)
        {

            var rightholderItemView = new RightholderItemView();
            var rightholderItemViewPresenter = new RightholderItemViewPresenter(rightholderItemView, this, _service);
            //rightholderItemViewPresenter.SavedRightholder += SaveRightholder;
            rightholderItemViewPresenter.RightholderId = id;
            rightholderItemViewPresenter.Run();

            _view.ShowView(rightholderItemView);
            if (_currentViewAction != null)
            {
                ViewStack.Push(_currentViewAction);
            }

            _currentViewAction = new viewAction { view = rightholderItemView ,
                doneActionWithParam =(oid)=> { },
                doneAction = ()=> { },
                TypeParam=typeof(void)
            };
        }

        public void ShowObjectRightItem(int id = 0)
        {

            //var rightholderItemView = new RightholderItemView();
            //var rightholderItemViewPresenter = new RightholderItemViewPresenter(rightholderItemView, this, _service);
            ////rightholderItemViewPresenter.SavedRightholder += SaveRightholder;
            //rightholderItemViewPresenter.RightholderId = id;
            //rightholderItemViewPresenter.Run();

            //_view.ShowView(rightholderItemView);
            //if (_currentViewAction != null)
            //{
            //    _currentViewAction.WithParam = true;
            //    ViewStack.Push(_currentViewAction);
            //}

            //_currentViewAction = new viewAction
            //{
            //    view = rightholderItemView,
            //    doneActionWithParam = (oid) => { },
            //    doneAction = () => { },
            //    WithParam = true
            //};
        }
        public void Done( Type returnType, object id )
        {
            if (ViewStack.Count == 0) return;

            _currentViewAction = ViewStack.Pop();

            if (_currentViewAction.TypeParam == returnType )
                _currentViewAction.doneActionWithParam(id);
             else
                _currentViewAction.doneAction();

            _view.ShowView(_currentViewAction.view);


        }
        public void Cancel()
        {
            if (ViewStack.Count == 0) return;

            _currentViewAction = ViewStack.Pop();

            _view.ShowView(_currentViewAction.view);


        }

        //public void AddRightholder(object sender, EventArgs e)
        //{
        //    //TODO: create empty object

        //    ShowRightholderItem();
        //}

        //public void SaveRightholder(object sender, EventArgs e)
        //{
        //    // SelectedRightholderId = Id; ???
        //    ShowRightholderList();
        //}
    }
}
