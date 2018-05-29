using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeVat : ITypeVat
    {
        public TypeVat()
        {
            AnketaCompany = new HashSet<AnketaCompany>();
            AnketaPerson = new HashSet<AnketaPerson>();
            TypeVattr = new HashSet<TypeVattr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<TypeVattr> TypeVattr { get; set; }
    }
}

