using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIConnector;

namespace ipsFormsDesign.Controls
{
    public class ConsumerModel : IConsumerModel
    {
        private ApiConnector _webApi = new ApiConnector("http://localhost:54867/api/");
        public Customer GetData(int custId)
        {
            var anketaDic = _webApi.GetItemById<Customer>("consumer/detail", custId.ToString() );
            return anketaDic;
        }

        public AnketaDictionaties GetDictionary()
        {
            var anketaDic = _webApi.GetItemById<AnketaDictionaties>("dictionary","anketa");
            return anketaDic;
        }

        public IList<ConsumerMainView> getMainView()
        {
            var anketaDic = _webApi.GetList<ConsumerMainView>("consumer/listSR");
            return anketaDic;
        }

        public Customer NewCustomer(int custType)
        {
            var anketaDic = _webApi.GetItemById<Customer>("newconsumer", custType.ToString());
            return anketaDic;
        }

        public bool Save(Customer cust)
        {
            if( cust.CustId == 0 ) // Новий споживач
            {
                return _webApi.NewItem<Customer>("newconsumer", cust);
            }

            return _webApi.UpdateItem<Customer>("detail", cust.CustId.ToString(), cust);
        }
    }
}
