using ipsFormsDesign.Interfaces;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsFormsDesign.Definition
{
    public interface IModelCompany 
    {
        Customer GetData(int custId);
        bool Save(Customer cust);
    }
}
