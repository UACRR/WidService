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

        public int codeI { get; set; }
        public string name { get; set; }

        public PeriodStatusTr PeriodStatusTr { get; set; }
        public ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
    }
}

