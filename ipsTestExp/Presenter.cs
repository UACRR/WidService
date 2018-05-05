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

        public Presenter(IFormCompany form, IModelCompany model )
        {
            Customer sors = new Customer { AnkVersion = 1, AnketaCompany = new List<AnketaCompany> { new AnketaCompany { Version = 1, Name = "Test row for Ankets" } } };
            Customer modelSource = new Customer { AnkVersion = 1, AnketaCompany = new List<AnketaCompany> { new AnketaCompany { Version = 1 } } };

            _view = form;
            _model = model;
            _view.SetData(sors);
            _model.SetData( modelSource );

            _view.FieldsValueChanged += _model.FieldChanging;
        }
    }
}
