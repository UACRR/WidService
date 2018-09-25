using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeMethodGet
    {
        public TypeMethodGet()
        {
            AgreementAddRH = new HashSet<AgreementAddRH>();
            TypeMethodGetTr = new HashSet<TypeMethodGetTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<AgreementAddRH> AgreementAddRH { get; set; }
        public ICollection<TypeMethodGetTr> TypeMethodGetTr { get; set; }
    }
}
