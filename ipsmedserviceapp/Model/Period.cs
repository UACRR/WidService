using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Period
    {
        public Period()
        {
            PeriodTr = new HashSet<PeriodTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<PeriodTr> PeriodTr { get; set; }
    }
}
