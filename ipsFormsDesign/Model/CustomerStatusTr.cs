using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CustomerStatusTr
    {
        public int CustStatus { get; set; }
        public string Lang { get; set; }
        public string CustStatusName { get; set; }

        public CustomerStatus CustStatusNavigation { get; set; }
    }
}
