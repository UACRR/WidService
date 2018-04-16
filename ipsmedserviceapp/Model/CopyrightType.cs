using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyrightType
    {
        public CopyrightType()
        {
            CopyrightTypeTr = new HashSet<CopyrightTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<CopyrightTypeTr> CopyrightTypeTr { get; set; }
    }
}
