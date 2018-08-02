using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.RightholderControls
{
    public class RightholderPresenter
    {
        private readonly RightholderView _view;

        public RightholderPresenter(RightholderView view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public void Show()
        {
            _view.Run();
        }
    }
}
