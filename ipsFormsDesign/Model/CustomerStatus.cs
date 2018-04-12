using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CustomerStatus
    {
        public CustomerStatus()
        {
            CustomerStatusTr = new HashSet<CustomerStatusTr>();
        }

        public int CustStatus { get; set; }
        public string CustStatusName { get; set; }

        public ICollection<CustomerStatusTr> CustomerStatusTr { get; set; }
    }
}
