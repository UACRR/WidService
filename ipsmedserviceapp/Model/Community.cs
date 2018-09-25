using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Community
    {
        public Community()
        {
            CustCmRight = new HashSet<CustCmRight>();
            RegisterCount = new HashSet<RegisterCount>();
        }

        public int custId { get; set; }

        public Customer cust { get; set; }
        public ICollection<CustCmRight> CustCmRight { get; set; }
        public ICollection<RegisterCount> RegisterCount { get; set; }
    }
}
