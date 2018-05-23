using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyLinkStatus : IMoneyLinkStatus
    {
        public MoneyLinkStatus()
        {
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
    }
}

