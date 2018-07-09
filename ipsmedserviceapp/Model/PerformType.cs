using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PerformType
    {
        public PerformType()
        {
            LicenseBigR = new HashSet<LicenseBigR>();
            PerformTypetTr = new HashSet<PerformTypetTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<LicenseBigR> LicenseBigR { get; set; }
        public ICollection<PerformTypetTr> PerformTypetTr { get; set; }
    }
}
