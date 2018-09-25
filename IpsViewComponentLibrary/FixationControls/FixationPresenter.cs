using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.FixationControls
{
    public class FixationPresenter
    {
        private readonly FixationView _view;
        private readonly FixationService _fixationService;
        private bool _canClose;

        public FixationPresenter(FixationView view)
        {
            _view = view;
            _view.Presenter = this;

            _fixationService = new FixationService();
        }

        public void Show(int fixId)
        {
            _view.Run();
        }
    }
}
