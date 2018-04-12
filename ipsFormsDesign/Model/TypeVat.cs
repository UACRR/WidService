using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeVat
    {
        public TypeVat()
        {
            TypeVattr = new HashSet<TypeVattr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<TypeVattr> TypeVattr { get; set; }
    }
}
