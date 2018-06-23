using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaExternal
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string InterCode { get; set; }

        public Customer Cust { get; set; }
    }
}
