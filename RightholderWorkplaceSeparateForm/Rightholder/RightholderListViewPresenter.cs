using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public class RightholderListViewPresenter
    {
        private readonly RightholderListView _view;

        public RightholderListViewPresenter(RightholderListView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        private RightholderListViewPresenter _presenter;
        public RightholderListViewPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        public void Run()
        {
            _view.Run();
        }
    }
}
