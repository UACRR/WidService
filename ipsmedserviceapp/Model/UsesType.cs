using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UsesType
    {
        public UsesType()
        {
            Fixation = new HashSet<Fixation>();
            UsesKind = new HashSet<UsesKind>();
            UsesTypeTr = new HashSet<UsesTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Fixation> Fixation { get; set; }
        public ICollection<UsesKind> UsesKind { get; set; }
        public ICollection<UsesTypeTr> UsesTypeTr { get; set; }
    }
}
