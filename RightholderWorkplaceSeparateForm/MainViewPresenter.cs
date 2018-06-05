using RightholderWorkplaceSeparateForm.Rightholder;
using RightholderWorkplaceSeparateForm.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightholderWorkplaceSeparateForm
{
    public class MainViewPresenter
    {
        private readonly ViewStack _viewStack;
        private readonly MainView _view;

        public MainViewPresenter(MainView view, ViewStack viewStack)
        {
            _viewStack = viewStack;
            _view = view;
            _view.Presenter = this;
        }

        public void Run()
        {
            ShowRightholders();
            _view.Run();
        }

        public void ShowRightholders()
        {
            var rightholderView = new RightholderView();
            var rightholderPresenter = new RightholderViewPresenter(rightholderView, this, _viewStack);
            rightholderPresenter.Run();

            _view.ShowRightholders(rightholderView);
        }
    }
}
