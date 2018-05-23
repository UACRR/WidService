using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsFormsDesign.Interfaces
{
    public interface IModel 
    {
        Customer NewCustomer(int custType);
        Customer GetData(int custId);
        bool Save(Customer cust);
        AnketaDictionaties GetDictionary();
    }
}
