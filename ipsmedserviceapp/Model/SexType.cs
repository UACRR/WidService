using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SexType
    {
        public SexType()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            SexTypeTr = new HashSet<SexTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
        public virtual ICollection<SexTypeTr> SexTypeTr { get; set; }
    }
}
