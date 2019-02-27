using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FolkType
    {
        public FolkType()
        {
            Authors = new HashSet<Authors>();
            FolkTypeTr = new HashSet<FolkTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Authors> Authors { get; set; }
        public virtual ICollection<FolkTypeTr> FolkTypeTr { get; set; }
    }
}
