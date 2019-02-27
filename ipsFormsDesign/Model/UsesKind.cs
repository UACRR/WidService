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

        public virtual UsesType UsesTypeNavigation { get; set; }
        public virtual ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        public virtual ObservableListSource<UsesKindTr> UsesKindTr { get; set; }
    }
}

