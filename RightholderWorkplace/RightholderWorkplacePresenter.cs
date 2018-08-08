using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RightholderWorkplace
{
    public class RightholderWorkplacePresenter
    {
        private RightholderWorkplace _view;
        private IRightHolderService _service;

        public RightholderWorkplacePresenter(RightholderWorkplace view, IRightHolderService service)
        {
            _view = view;
            _service = service;
        }
    }
}
