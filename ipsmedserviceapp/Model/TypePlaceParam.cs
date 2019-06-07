using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypePlaceParam
    {
        public TypePlaceParam()
        {
            TypePlace = new HashSet<TypePlace>();
            TypePlaceParamTr = new HashSet<TypePlaceParamTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TypePlace> TypePlace { get; set; }
        public virtual ICollection<TypePlaceParamTr> TypePlaceParamTr { get; set; }
    }
}
