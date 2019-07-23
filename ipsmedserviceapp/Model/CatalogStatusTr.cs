using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ipsmedserviceapp.Model
{
    public partial class CatalogStatusTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual CatalogStatus CodeINavigation { get; set; }
    }
}
