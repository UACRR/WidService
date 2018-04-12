using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypePlace
    {
        public TypePlace()
        {
            TypePlaceTr = new HashSet<TypePlaceTr>();
        }

        public int PlCode { get; set; }
        public string PlName { get; set; }

        public ICollection<TypePlaceTr> TypePlaceTr { get; set; }
    }
}
