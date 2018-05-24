using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class MoneyLinkStatus : IMoneyLinkStatus
    {
        public MoneyLinkStatus()
        {
            MoneyLinkStatusTr = new HashSet<MoneyLinkStatusTr>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<MoneyLinkStatusTr> MoneyLinkStatusTr { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
    }
}

