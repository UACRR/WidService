using RightholderWorkplaceSeparateForm.Rightholder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightholderWorkplaceSeparateForm
{
    public class MainViewPresenter
    {
        private readonly MainView _view;

        public MainViewPresenter(MainView view)
        {
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
            _view.ShowRightholders();
        }

        public RightholderView GetRightHoldersView()
        {
            var rightholderView = new RightholderView();
            var rightholderPresenter = new RightholderViewPresenter(rightholderView);
            rightholderPresenter.Run();

            return rightholderView;
        }
    }
}
