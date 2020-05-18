using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UsesKind
    {
        public UsesKind()
        {
            AgrLicenseType = new HashSet<AgrLicenseType>();
            UsesKindTr = new HashSet<UsesKindTr>();
        }

        public int CodeI { get; set; }
        public int? UsesType { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual UsesType UsesTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        [JsonIgnore]
        public virtual ICollection<UsesKindTr> UsesKindTr { get; set; }
    }
}


