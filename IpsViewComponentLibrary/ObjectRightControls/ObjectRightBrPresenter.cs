using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class ObjectRightBrPresenter
    {
        private readonly ObjectRightBrView _view;

        public ObjectRightBrPresenter(ObjectRightBrView view)
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
