using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypePlace
    {
        public TypePlace()
        {
            ClnBusinessPlace = new HashSet<ClnBusinessPlace>();
            TypePlaceTr = new HashSet<TypePlaceTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public bool? IsHoll { get; set; }
        public int? ParamType { get; set; }

        [JsonIgnore]
        public virtual TypePlaceParam ParamTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public virtual ICollection<TypePlaceTr> TypePlaceTr { get; set; }
    }
}


