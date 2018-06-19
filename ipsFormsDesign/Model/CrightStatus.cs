using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CrightStatus : ICrightStatus
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

