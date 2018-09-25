using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RholderType
    {
        public RholderType()
        {
            RholderTypeTr = new HashSet<RholderTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<RholderTypeTr> RholderTypeTr { get; set; }
    }
}
