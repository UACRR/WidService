using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public class CopyrightRequestPresenter
    {
        private readonly CopyrightRequestControl _view;

        public CopyrightRequestPresenter(CopyrightRequestControl view)
        {
            _view = view;
            _view.Presenter = this;
        }

        public void Do()
        {

        }
    }
}
