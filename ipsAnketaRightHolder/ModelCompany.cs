using ipsFormsDesign.Definition;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsAnketaRightHolder
{
    public class ModelCompany : IModelCompany
    {
        private readonly ApiConnector connector = new ApiConnector("http://localhost:54867/");

        public Customer GetData(int custId)
        {
            var customer = connector.GetItemById<Customer>("api/rh/detail", custId.ToString());
            return customer;
        }

        public bool Save(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
