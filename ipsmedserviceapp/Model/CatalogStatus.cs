using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CatalogStatus
    {
        public CatalogStatus()
        {
            CatalogFile = new HashSet<CatalogFile>();
            CatalogStatusTr = new HashSet<CatalogStatusTr>();
            PubCatalogItem = new HashSet<PubCatalogItem>();
            RhcatalogItem = new HashSet<RhcatalogItem>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<CatalogFile> CatalogFile { get; set; }
        public virtual ICollection<CatalogStatusTr> CatalogStatusTr { get; set; }
        [JsonIgnore]
        public virtual ICollection<PubCatalogItem> PubCatalogItem { get; set; }
        [JsonIgnore]
        public virtual ICollection<RhcatalogItem> RhcatalogItem { get; set; }
    }
}



