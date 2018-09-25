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

        public int codeI { get; set; }
        public int? usesType { get; set; }
        public string name { get; set; }

        public UsesType usesTypeNavigation { get; set; }
        public ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        public ObservableListSource<UsesKindTr> UsesKindTr { get; set; }
    }
}

