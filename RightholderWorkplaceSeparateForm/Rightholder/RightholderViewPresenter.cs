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
        private ViewAction _currentViewAction = null;

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
            rightholderListViewPresenter.Run();

            _view.ShowView(rightholderListView);
            if (_currentViewAction != null)
                ViewStack.Push(_currentViewAction);
            _currentViewAction = new ViewAction { View = rightholderListView,
                DoneActionWithParam = (oid) => rightholderListViewPresenter.GetList(oid),
                DoneAction = () => rightholderListViewPresenter.GetList(null),
                TypeParam = typeof(RightholderModel)
            };
        }

        public void ShowRightholderItem(int id = 0)
        {

            var rightholderItemView = new RightholderItemView();
            var rightholderItemViewPresenter = new RightholderItemViewPresenter(rightholderItemView, this, _service);
            rightholderItemViewPresenter.RightholderId = id;
            rightholderItemViewPresenter.Run();

            _view.ShowView(rightholderItemView);
            if (_currentViewAction != null)
            {
                ViewStack.Push(_currentViewAction);
            }

            _currentViewAction = new ViewAction { View = rightholderItemView ,
                DoneActionWithParam =(oid)=> { },
                DoneAction = ()=> { },
                TypeParam=typeof(void)
            };
        }

        public void Done( Type returnType, object id )
        {
            if (ViewStack.Count == 0) return;

            _currentViewAction = ViewStack.Pop();

            if (_currentViewAction.TypeParam == returnType )
                _currentViewAction.DoneActionWithParam(id);
             else
                _currentViewAction.DoneAction();

            _view.ShowView(_currentViewAction.View);
        }

        public void Cancel()
        {
            if (ViewStack.Count == 0) return;

            _currentViewAction = ViewStack.Pop();

            _view.ShowView(_currentViewAction.View);


        }
    }
}
