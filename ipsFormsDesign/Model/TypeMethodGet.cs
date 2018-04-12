using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeMethodGet
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
