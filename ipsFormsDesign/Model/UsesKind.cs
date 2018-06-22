using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UsesKind : IUsesKind
    {
        public UsesKind()
        {
            AgrLicenseType = new ObservableListSource<AgrLicenseType>();
            UsesKindTr = new ObservableListSource<UsesKindTr>();
        }

        public int CodeI { get; set; }
        public int? UsesType { get; set; }
        public string Name { get; set; }

        public UsesType UsesTypeNavigation { get; set; }
        public ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        public ObservableListSource<UsesKindTr> UsesKindTr { get; set; }
    }
}

