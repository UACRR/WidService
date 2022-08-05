using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PeriodStatus
    {
        public PeriodStatus()
        {
            PaidPeriod = new HashSet<PaidPeriod>();
            PeriodStatusTr = new HashSet<PeriodStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PaidPeriod> PaidPeriod { get; set; }
        public virtual ICollection<PeriodStatusTr> PeriodStatusTr { get; set; }
    }
}
