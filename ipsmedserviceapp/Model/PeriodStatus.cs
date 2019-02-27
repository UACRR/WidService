using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PeriodStatus
    {
        public PeriodStatus()
        {
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual PeriodStatusTr PeriodStatusTr { get; set; }
        public virtual ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}
