using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CrkindGroup
    {
        public CrkindGroup()
        {
            CopyrightKind = new HashSet<CopyrightKind>();
            CrkindGroupTr = new HashSet<CrkindGroupTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CopyrightKind> CopyrightKind { get; set; }
        public virtual ICollection<CrkindGroupTr> CrkindGroupTr { get; set; }
    }
}
