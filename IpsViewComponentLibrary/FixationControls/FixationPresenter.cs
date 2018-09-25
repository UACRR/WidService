using ipsFormsDesign.Model;
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
        private Fixation _fixation;
        private bool _canClose;

        public FixationPresenter(FixationView view)
        {
            _view = view;
            _view.Presenter = this;

            _fixationService = new FixationService();
        }

        public void ShowNew()
        {
            _fixation = new Fixation { UsesType = 1 };
            _view.Fixation = _fixation;
            _view.Run();
        }

        public void Show(int fixId)
        {
            _fixation = _fixationService.GetById(fixId);
            _view.Fixation = _fixation;
            _view.Run();
        }
    }
}
