using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SexType
    {
        public SexType()
        {
            SexTypeTr = new HashSet<SexTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<SexTypeTr> SexTypeTr { get; set; }
    }
}
