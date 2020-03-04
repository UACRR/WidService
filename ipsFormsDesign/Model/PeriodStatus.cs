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
            PeriodStatusTr = new ObservableListSource<PeriodStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        public virtual ObservableListSource<PeriodStatusTr> PeriodStatusTr { get; set; }
    }
}

