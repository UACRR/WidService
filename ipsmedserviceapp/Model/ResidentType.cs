using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ResidentType
    {
        public ResidentType()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            ResidentTypeTr = new HashSet<ResidentTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
        public virtual ICollection<ResidentTypeTr> ResidentTypeTr { get; set; }
    }
}
