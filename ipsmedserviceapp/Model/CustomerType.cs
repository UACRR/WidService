using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CustomerType
    {
        public CustomerType()
        {
            Customer = new HashSet<Customer>();
            CustomerTypeTr = new HashSet<CustomerTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<CustomerTypeTr> CustomerTypeTr { get; set; }
    }
}
