using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeVat
    {
        public TypeVat()
        {
            AnketaCompany = new HashSet<AnketaCompany>();
            AnketaPerson = new HashSet<AnketaPerson>();
            TypeVattr = new HashSet<TypeVattr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnketaCompany> AnketaCompany { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
        public virtual ICollection<TypeVattr> TypeVattr { get; set; }
    }
}
