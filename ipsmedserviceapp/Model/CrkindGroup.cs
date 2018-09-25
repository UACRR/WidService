using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CRKindGroup
    {
        public CRKindGroup()
        {
            CRKindGroupTr = new HashSet<CRKindGroupTr>();
            CopyrightKind = new HashSet<CopyrightKind>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<CRKindGroupTr> CRKindGroupTr { get; set; }
        public ICollection<CopyrightKind> CopyrightKind { get; set; }
    }
}
