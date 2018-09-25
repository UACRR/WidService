using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Region
    {
        public Region()
        {
            AnketaCompanyfaRegionNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyjaRegionNavigation = new HashSet<AnketaCompany>();
            AnketaCompanyleRegionNavigation = new HashSet<AnketaCompany>();
            AnketaPersonfaRegionNavigation = new HashSet<AnketaPerson>();
            AnketaPersonleRegionNavigation = new HashSet<AnketaPerson>();
            AnketaPersonreRegionNavigation = new HashSet<AnketaPerson>();
            RegionTr = new HashSet<RegionTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<AnketaCompany> AnketaCompanyfaRegionNavigation { get; set; }
        public ICollection<AnketaCompany> AnketaCompanyjaRegionNavigation { get; set; }
        public ICollection<AnketaCompany> AnketaCompanyleRegionNavigation { get; set; }
        public ICollection<AnketaPerson> AnketaPersonfaRegionNavigation { get; set; }
        public ICollection<AnketaPerson> AnketaPersonleRegionNavigation { get; set; }
        public ICollection<AnketaPerson> AnketaPersonreRegionNavigation { get; set; }
        public ICollection<RegionTr> RegionTr { get; set; }
    }
}
