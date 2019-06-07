using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyLinkStatus
    {
        public MoneyLinkStatus()
        {
            MoneyLinkStatusTr = new HashSet<MoneyLinkStatusTr>();
            MoneyPeriodLink = new HashSet<MoneyPeriodLink>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MoneyLinkStatusTr> MoneyLinkStatusTr { get; set; }
        public virtual ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
    }
}
