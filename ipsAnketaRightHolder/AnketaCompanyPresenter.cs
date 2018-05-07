using ipsFormsDesign.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ipsAnketaRightHolder
{
    public class AnketaCompanyPresenter
    {
        private IFormCompany _view;
        private IModelCompany _model;

        public AnketaCompanyPresenter(IFormCompany form, IModelCompany model, int custId)
        {
            _view = form;
            _model = model;
            var data = _model.GetData(custId);
            _view.SetData(data);
        }
    }
}
