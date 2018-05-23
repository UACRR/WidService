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
        private IConsumerModel _model;
        public FormPresenter(IConsumerForm form, IConsumerModel model )
        {
            _form = form;
            _model = model;
            _form.getMainViewData = _model.getMainView;
            _form.SetDictionary(_model.GetDictionary());
            _form.NewCustomer = _model.NewCustomer;
            _form.SaveCustomer = _model.Save;
            _form.GetCustomer = _model.GetData;
            _form.EndPresenterLink();
        }
    }
}
