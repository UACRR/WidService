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
        private IRightholderForm _form;
        private IRightHolderService _service;

        public RightholderWorkplacePresenter(IRightholderForm form, IRightHolderService service)
        {
            _form = form;
            _service = service;
            _form.GetMainViewData = _service.GetMainView;
            _form.SetDictionary(_service.GetDictionary());
            _form.NewCustomer = _service.NewCustomer;
            _form.SaveCustomer = _service.Save;
            _form.GetCustomer = _service.GetData;
            _form.EndPresenterLink();
        }
    }
}
