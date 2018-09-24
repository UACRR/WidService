using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.FixationControls
{
    public class FixationListPresenter
    {
        private readonly FixationListControl _view;
        private readonly FixationService _fixationService;
        
        public FixationListPresenter(FixationListControl view)
        {
            _view = view;
            _fixationService = new FixationService();
        }

        public void Load()
        {
            UpdateList();
        }

        private void UpdateList()
        {
            //var list = _fixationService.GetFixations();
            //_view.FixationsDataSource = list;
        }
    }
}
