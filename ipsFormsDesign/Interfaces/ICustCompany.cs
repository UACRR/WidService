using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public interface ICustCompany : ICustomer
    {
        void SetData(Customer data);
        IAnketaCompany AnketaCompany { get }

    }
}
