using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Community : ICommunity
    {
        public Community()
        {
            CustCmRight = new HashSet<CustCmRight>();
            RegisterCount = new HashSet<RegisterCount>();
        }

        public int CustId { get; set; }

        public Customer Cust { get; set; }
        public ICollection<CustCmRight> CustCmRight { get; set; }
        public ICollection<RegisterCount> RegisterCount { get; set; }
    }
}

