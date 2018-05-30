using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RightholderService : IRightHolderService
    {
        private ApiConnector _webApi = new ApiConnector("http://IPSDATA:5200/api/");

        public Customer GetData(int custId)
        {
            var anketaDic = _webApi.GetItemById<Customer>("rh/detail", custId.ToString() );
            return anketaDic;
        }

        public AnketaDictionaties GetDictionary()
        {
            var anketaDic = _webApi.GetItemById<AnketaDictionaties>("dictionary","anketa");
            return anketaDic;
        }

        public IList<RightholderMainView> GetMainView()
        {
            var anketaDic = _webApi.GetList<RightholderMainView>("rh/listrh");
            return anketaDic;
        }

        public Customer NewCustomer(int custType)
        {
            var anketaDic = _webApi.GetItemById<Customer>("rh/newrightholder", custType.ToString());
            return anketaDic;
        }

        public bool Save(Customer cust)
        {
            if( cust.CustId == 0 ) // Новий споживач
            {
                return _webApi.NewItem<Customer>("rh/newrightholder", cust);
            }

            return _webApi.UpdateItem<Customer>("rh/detail", cust.CustId.ToString(), cust);
        }
    }
}
