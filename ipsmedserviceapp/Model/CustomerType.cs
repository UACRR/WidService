using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            CustomerTypeTr = new HashSet<CustomerTypeTr>();
        }

        public int CustType { get; set; }
        public string CustTypeName { get; set; }

        public ICollection<CustomerTypeTr> CustomerTypeTr { get; set; }
    }
}
