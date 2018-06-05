using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeMethodGet
    {
        public TypeMethodGet()
        {
            AgreementAddRh = new HashSet<AgreementAddRh>();
            TypeMethodGetTr = new HashSet<TypeMethodGetTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public ICollection<TypeMethodGetTr> TypeMethodGetTr { get; set; }
    }
}
