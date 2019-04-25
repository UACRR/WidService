using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CatalogStatus
    {
        public CatalogStatus()
        {
            CatalogFile = new HashSet<CatalogFile>();
            PubСatalogItem = new HashSet<PubСatalogItem>();
            RhсatalogItem = new HashSet<RhсatalogItem>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CatalogFile> CatalogFile { get; set; }
        public virtual ICollection<PubСatalogItem> PubСatalogItem { get; set; }
        public virtual ICollection<RhсatalogItem> RhсatalogItem { get; set; }
    }
}
