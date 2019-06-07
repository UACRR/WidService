using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RholderType
    {
        public RholderType()
        {
            CatalogFile = new HashSet<CatalogFile>();
            RholderTypeTr = new HashSet<RholderTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CatalogFile> CatalogFile { get; set; }
        public virtual ICollection<RholderTypeTr> RholderTypeTr { get; set; }
    }
}
