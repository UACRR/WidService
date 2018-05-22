using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Definition;

namespace ipsAnketaClient
{
    public class Presenter
    {
        private IFormConsumerComany _view;
        private IModelCompany _model;

        public Presenter(IFormConsumerComany form, IModelCompany model, int custId)
        {

            _view = form;
            _model = model;
            var sors = _model.GetData(custId);
            var dic = _model.GetDictionary();
            form.SetDictionary(dic);

            _view.SetData(sors);

        }
    }
}
