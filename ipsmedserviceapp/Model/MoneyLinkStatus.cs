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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<MoneyLinkStatusTr> MoneyLinkStatusTr { get; set; }
        public ICollection<MoneyPeriodLink> MoneyPeriodLink { get; set; }
    }
}
