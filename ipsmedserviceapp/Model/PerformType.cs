using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PerformType
    {
        public PerformType()
        {
            LicenseBigR = new HashSet<LicenseBigR>();
            PerformTypeTr = new HashSet<PerformTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<LicenseBigR> LicenseBigR { get; set; }
        public ICollection<PerformTypeTr> PerformTypeTr { get; set; }
    }
}
