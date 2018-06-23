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

        public ObservableListSource<Customer> Customer { get; set; }
        public ObservableListSource<CustomerTypeTr> CustomerTypeTr { get; set; }
    }
}

