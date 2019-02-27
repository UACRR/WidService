using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PeriodStatus : IPeriodStatus
    {
        public PeriodStatus()
        {
            PaidPeriod = new ObservableListSource<PaidPeriod>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual PeriodStatusTr PeriodStatusTr { get; set; }
        public virtual ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
    }
}

