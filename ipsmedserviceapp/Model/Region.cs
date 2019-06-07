using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Region
    {
        public Region()
        {
            AnketaCompanyFaRegionNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyJaRegionNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyLeRegionNavigation = new HashSet<AnketaCompany>();
            AnketaPersonFaRegionNavigation = new HashSet<AnketaPerson>();
            AnketaPersonLeRegionNavigation = new HashSet<AnketaPerson>();
            AnketaPersonReRegionNavigation = new HashSet<AnketaPerson>();
            RegionTr = new HashSet<RegionTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnketaCompany> AnketaCompanyFaRegionNavigation { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompanyJaRegionNavigation { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompanyLeRegionNavigation { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPersonFaRegionNavigation { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPersonLeRegionNavigation { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPersonReRegionNavigation { get; set; }
        public virtual ICollection<RegionTr> RegionTr { get; set; }
    }
}
