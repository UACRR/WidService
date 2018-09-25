using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CustomerStatus
    {
        public CustomerStatus()
        {
            Customer = new HashSet<Customer>();
            CustomerStatusTr = new HashSet<CustomerStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<CustomerStatusTr> CustomerStatusTr { get; set; }
    }
}
