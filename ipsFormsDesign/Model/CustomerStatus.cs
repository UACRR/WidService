using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CustomerStatus : ICustomerStatus
    {
        public CustomerStatus()
        {
            Customer = new ObservableListSource<Customer>();
            CustomerStatusTr = new ObservableListSource<CustomerStatusTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<Customer> Customer { get; set; }
        public ObservableListSource<CustomerStatusTr> CustomerStatusTr { get; set; }
    }
}

