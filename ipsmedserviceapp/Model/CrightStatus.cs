using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CrightStatus
    {
        public CrightStatus()
        {
            CopyRight = new HashSet<CopyRight>();
            CrightStatusTr = new HashSet<CrightStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<CopyRight> CopyRight { get; set; }
        public ICollection<CrightStatusTr> CrightStatusTr { get; set; }
    }
}
