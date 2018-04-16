using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Region
    {
        public Region()
        {
            RegionTr = new HashSet<RegionTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<RegionTr> RegionTr { get; set; }
    }
}
