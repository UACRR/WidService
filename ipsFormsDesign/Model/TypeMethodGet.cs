using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeMethodGet : ITypeMethodGet
    {
        public TypeMethodGet()
        {
            TypeMethodGetTr = new HashSet<TypeMethodGetTr>();
        }

        public int GetCode { get; set; }
        public string GetName { get; set; }

        public ICollection<TypeMethodGetTr> TypeMethodGetTr { get; set; }
    }
}

