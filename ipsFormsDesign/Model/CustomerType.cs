using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CustomerType : ICustomerType
    {
        public CustomerType()
        {
            Customer = new ObservableListSource<Customer>();
            CustomerTypeTr = new ObservableListSource<CustomerTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Customer> Customer { get; set; }
        public virtual ObservableListSource<CustomerTypeTr> CustomerTypeTr { get; set; }
    }
}

