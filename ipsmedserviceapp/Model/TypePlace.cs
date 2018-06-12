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

        [JsonIgnore]
        public ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public ICollection<TypePlaceTr> TypePlaceTr { get; set; }
    }
}









