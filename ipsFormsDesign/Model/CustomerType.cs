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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<CustomerTypeTr> CustomerTypeTr { get; set; }
    }
}
