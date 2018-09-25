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

        public int codeI { get; set; }
        public string name { get; set; }
        public bool? isHoll { get; set; }
        public int? paramType { get; set; }

        [JsonIgnore]
        public TypePlaceParam paramTypeNavigation { get; set; }
        [JsonIgnore]
        public ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public ICollection<TypePlaceTr> TypePlaceTr { get; set; }
    }
}

