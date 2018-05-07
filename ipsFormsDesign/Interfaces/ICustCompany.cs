using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public interface ICustCompany
    {
        void SetData(Customer data);
        void getData(Customer data);
        IAnketaCompany AnketaCompany { get; }
        ICustomer Customer { get;  }
        IRelEmployee RelEmployer { get;  }
        IEmployee Employee { get;  }
    }
}
