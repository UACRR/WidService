using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Community : ICommunity
    {
        public Community()
        {
            CustCmRight = new ObservableListSource<CustCmRight>();
            RegisterCount = new ObservableListSource<RegisterCount>();
        }

        public int CustId { get; set; }

        public Customer Cust { get; set; }
        public ObservableListSource<CustCmRight> CustCmRight { get; set; }
        public ObservableListSource<RegisterCount> RegisterCount { get; set; }
    }
}

