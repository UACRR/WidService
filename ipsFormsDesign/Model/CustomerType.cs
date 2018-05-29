using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CustomerType : ICustomerType
    {
        public CustomerType()
        {
            Customer = new HashSet<Customer>();
            CustomerTypeTr = new HashSet<CustomerTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<CustomerTypeTr> CustomerTypeTr { get; set; }
    }
}

