using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ResidentType
    {
        public ResidentType()
        {
            ResidentTypeTr = new HashSet<ResidentTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<ResidentTypeTr> ResidentTypeTr { get; set; }
    }
}
