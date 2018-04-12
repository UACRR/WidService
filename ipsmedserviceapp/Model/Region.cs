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

        public int RegionCode { get; set; }
        public string CountryCode { get; set; }
        public string RegionName { get; set; }

        public Country CountryCodeNavigation { get; set; }
        public ICollection<RegionTr> RegionTr { get; set; }
    }
}
