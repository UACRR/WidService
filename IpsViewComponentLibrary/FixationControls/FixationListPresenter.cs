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

        public FixationListPresenter(FixationListControl view)
        {
            _view = view;
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
