using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FolkType : IFolkType
    {
        public FolkType()
        {
            Authors = new HashSet<Authors>();
            FolkTypeTr = new HashSet<FolkTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Authors> Authors { get; set; }
        public ICollection<FolkTypeTr> FolkTypeTr { get; set; }
    }
}

