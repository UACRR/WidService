using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PeriodStatus : IPeriodStatus
    {
        public PeriodStatus()
        {
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public PeriodStatusTr PeriodStatusTr { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}

