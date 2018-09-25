using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeVAT
    {
        public TypeVAT()
        {
            AnketaCompany = new HashSet<AnketaCompany>();
            AnketaPerson = new HashSet<AnketaPerson>();
            TypeVATTr = new HashSet<TypeVATTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<TypeVATTr> TypeVATTr { get; set; }
    }
}
