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

        public int codeI { get; set; }
        public string name { get; set; }

        public PeriodStatusTr PeriodStatusTr { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}
