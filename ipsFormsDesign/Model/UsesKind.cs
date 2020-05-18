using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
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

        [JsonIgnore]
        public virtual UsesType UsesTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<AgrLicenseType> AgrLicenseType { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<UsesKindTr> UsesKindTr { get; set; }
    }
}


