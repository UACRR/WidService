using ipsFormsDesign.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerWizards
{
    public class WizardCustomerPresenter
    {
        private readonly IFormCompany _view;
        private readonly IModelCompany _model;

        public WizardCustomerPresenter(IFormCompany view, IModelCompany model, int custId)
        {
            _view = view;
            _model = model;

            var dictionaries = _model.GetDictionary();
            _view.SetDictionary(dictionaries);

            var data = _model.GetData(custId);
            _view.SetData(data);

            WireUpEvents();
        }

        private void WireUpEvents()
        {
        }
    }
}
