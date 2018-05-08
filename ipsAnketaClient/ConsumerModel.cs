using ipsFormsDesign.Definition;
using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsAnketaClient
{
    class ConsumerModel : IModelCompany
    {
        private static readonly ApiConnector connector = new ApiConnector("http://localhost:54867/");
        private AnketaDictionaties _dictionary = null;
        public Customer GetData(int custId)
        {
            var customer = connector.GetItemById<Customer>("api/consumer/detail", custId.ToString());
            return customer;
        }

        public AnketaDictionaties GetDictionary()
        {
            if (_dictionary == null)
                _dictionary = connector.GetItemById<AnketaDictionaties>("api/Dictionary", "anketa");

            return _dictionary;
        }

        public bool Save(Customer cust)
        {
            throw new NotImplementedException();
        }
    }
}
