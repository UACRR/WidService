using ipsFormsDesign.Services;
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
        private readonly RightholderService _rightholderService;

        public CopyrightRequestPresenter(CopyrightRequestControl view, RightholderService rightholderService)
        {
            _view = view;
            _view.Presenter = this;

            _rightholderService = rightholderService;
        }

        public void UpdateRightholderList()
        {
            var rightholderList = _rightholderService.GetRightholdersWithNotAcceptedCopyrights();
            _view.RightholderListDataSource = rightholderList;
        }

        public void UpdateObjectsList(int custId)
        {
            var objectRightList = _rightholderService.GetNotAcceptedObjectsByRightholder(custId);
            _view.ObjectRightListDataSource = objectRightList;
        }
    }
}
