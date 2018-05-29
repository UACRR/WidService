using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerWorkplace_v_1._0
{
    public class FormPresenter
    {
        private IConsumerForm _form;
        private IConsumerService _service;
        public FormPresenter(IConsumerForm form, IConsumerService service)
        {
            _form = form;
            _service = service;
            _form.getMainViewData = _service.getMainView;
            _form.SetDictionary(_service.GetDictionary());
            _form.NewCustomer = _service.NewCustomer;
            _form.SaveCustomer = _service.Save;
            _form.GetCustomer = _service.GetData;
            _form.EndPresenterLink();
        }
    }
}
