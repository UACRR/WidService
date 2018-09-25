using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CRightStatus
    {
        public CRightStatus()
        {
            CRightStatusTr = new HashSet<CRightStatusTr>();
            CopyRight = new HashSet<CopyRight>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<CRightStatusTr> CRightStatusTr { get; set; }
        public ICollection<CopyRight> CopyRight { get; set; }
    }
}
