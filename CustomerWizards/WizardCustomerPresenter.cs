using ipsFormsDesign.Definition;
using ipsmedserviceapp.Model;
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

            // test bank account
            var anketa = data.AnketaCompany.SingleOrDefault();
            anketa.FaRegion = 9;
            anketa.RegistrNumber = "918273645";
            anketa.RegistrWho = "<registrator>";
            anketa.NumberVat = "105105105";
            anketa.BanAcc = new BankAccount
            {
                MfoName = "Приватбанк ПАТ",
                Mfo = 123456,
                MfoOkpo = "987654321",
                TransitNumber = "tr56966666666",
                AccountNumber = "an23567879547"
            };

            _view.SetData(data);

            WireUpEvents();
        }

        private void WireUpEvents()
        {
        }
    }
}
