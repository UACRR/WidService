using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestMVCStack.Interface;
using TestMVCStack.Main;

namespace TestMVCStack
{
    public class PresenterMain : IPresenterMain, IPresenterLevel
    {
        public IViewMain View { get; set; }
        public IService service { get; set; }

        public Type PresenterType { get { return typeof(IData); } }

        public IPresenterMain parent { get; set; }

        private Stack<IView> _stack = new Stack<IView>();
        private IView _currentView;


        public void Done(object id)
        {
            parent?.presenterDone(id);
        }
        public void Done()
        {
            parent?.presenterDone();
        }

        public void Cancel()
        {
            parent?.presenterCancel();
        }

        public void Refresh()
        {
            _currentView.presenter.Refresh();
        }

        public void Refresh(object id)
        {
            if (id.GetType() == _currentView.presenter.PresenterType)
                _currentView.presenter.Refresh(id);
            else
                _currentView.presenter.Refresh();
        }

        public void presenterDone(object id)
        {
            if (id != null)
                service.Save( id );

            IView tempView = _currentView;
            _currentView = _stack.Pop();

            if (tempView.presenter.PresenterType == _currentView.presenter.PresenterType)
                _currentView.presenter.Refresh(id);
                //_currentView.SetBindingSource(service.GetList());
            else
                _currentView.presenter.Refresh();

            View.SetView(_currentView as Control);
        }

        public void presenterDone()
        {
            _currentView = _stack.Pop();
            _currentView.presenter.Refresh();
            View.SetView(_currentView as Control);
        }

        public void presenterCancel()
        {
            if (_stack.Count == 0)
            {
                if (parent == null)
                    return;
                parent.presenterCancel();
                return;
            }
            _currentView = _stack.Pop();
            View.SetView(_currentView as Control);
        }

        private IView[] workingViews = { null, null, null };
        public void runGrid(IData curRow = null )
        {
            if (workingViews[0] == null)
            {
                var gridPresenter = new GridLevelPresenter(this, service );
                var gridView = new GridControl1(gridPresenter);
                gridPresenter.SetView(gridView);
                workingViews[0] = gridView;
            }

            if (_currentView == workingViews[0])
                return;

            if (_currentView != null)
                _stack.Push(_currentView);

            _currentView = workingViews[0];
            _currentView.SetBindingSource(service.GetList());
            View.SetView(_currentView as Control);
            service.AddNexItem();

            if (curRow != null)
                (_currentView as IViewWithCurrent)?.SetCurrentRow(curRow);
        }

        public void editData(IData curRow)
        {
            if (workingViews[1] == null)
            {
                var editPresenter = new GridLevelPresenter(this, service);

                var editView = new EditControl1(editPresenter);
                editPresenter.SetView(editView);
                workingViews[1] = editView;
            }

            if (_currentView != null)
                _stack.Push(_currentView);

            _currentView = workingViews[1];
            if (curRow == null)
                curRow = service.newItem();

            _currentView.SetBindingSource(curRow);
            View.SetView(_currentView as Control );

            ;
        }

        public void NewMainPresenter()
        {
            if (workingViews[2] == null)
            {
                var localService = new ServiceMain();
                var localPresenter = new PresenterMain();
                localPresenter.parent = this;
                MainView view = new MainView();
                localPresenter.service = localService;
                localPresenter.View = view;
                localPresenter.runGrid();


                workingViews[2] = view;
            }

            if (_currentView != null)
                _stack.Push(_currentView);

            _currentView = workingViews[2];
            View.SetView(_currentView as Control);

        }

        public void SetView(IView view)
        {
        }
    }
}
