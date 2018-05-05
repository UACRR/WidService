using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    interface ICustCompany : ICustomer
    {
        IAnketaCompany AnketaCompany { get; set; }

    }
}
