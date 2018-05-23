using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UsesType : IUsesType
    {
        public UsesType()
        {
            UsesKind = new HashSet<UsesKind>();
            UsesTypeTr = new HashSet<UsesTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<UsesKind> UsesKind { get; set; }
        public ICollection<UsesTypeTr> UsesTypeTr { get; set; }
    }
}

