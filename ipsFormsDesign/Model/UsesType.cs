using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UsesType
    {
        public UsesType()
        {
            UsesKind = new HashSet<UsesKind>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<UsesKind> UsesKind { get; set; }
    }
}
