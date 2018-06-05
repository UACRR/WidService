using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeMethodGet : ITypeMethodGet
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

