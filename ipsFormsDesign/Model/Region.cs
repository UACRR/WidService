using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Region : IRegion
    {
        public Region()
        {
            AnketaCompanyFaRegionNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyJaRegionNavigation = new ObservableListSource<AnketaCompany>();
            AnketaCompanyLeRegionNavigation = new ObservableListSource<AnketaCompany>();
            AnketaPersonFaRegionNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonLeRegionNavigation = new ObservableListSource<AnketaPerson>();
            AnketaPersonReRegionNavigation = new ObservableListSource<AnketaPerson>();
            RegionTr = new ObservableListSource<RegionTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<AnketaCompany> AnketaCompanyFaRegionNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyJaRegionNavigation { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompanyLeRegionNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonFaRegionNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonLeRegionNavigation { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPersonReRegionNavigation { get; set; }
        public ObservableListSource<RegionTr> RegionTr { get; set; }
    }
}

