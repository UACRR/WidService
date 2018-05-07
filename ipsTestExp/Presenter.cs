using ipsFormsDesign.Definition;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsTestExp
{
    public class Presenter
    {
        private IFormCompany _view;
        private IModelCompany _model;

        public Presenter(IFormCompany form, IModelCompany model, int custId )
        {

            _view = form;
            _model = model;
            var sors = _model.GetData(custId);
            _view.SetData(sors);

        }
    }
}
