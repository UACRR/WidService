using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Region : IRegion
    {
        public Region()
        {
            AnketaCompanyfaRegionNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyjaRegionNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyleRegionNavigation = new ObservableListSource<AnketaCompany>();
            AnketaPersonfaRegionNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonleRegionNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonreRegionNavigation = new ObservableListSource<AnketaPerson>();
            RegionTr = new ObservableListSource<RegionTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<AnketaCompany> AnketaCompanyfaRegionNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyjaRegionNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyleRegionNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonfaRegionNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonleRegionNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonreRegionNavigation { get; set; }
        public ObservableListSource<RegionTr> RegionTr { get; set; }
    }
}

