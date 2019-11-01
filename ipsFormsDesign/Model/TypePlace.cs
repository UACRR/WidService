using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypePlace : ITypePlace
    {
        public TypePlace()
        {
            ClnBusinessPlace = new ObservableListSource<ClnBusinessPlace>();
            TypePlaceTr = new ObservableListSource<TypePlaceTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public bool? IsHoll { get; set; }
        public int? ParamType { get; set; }

        [JsonIgnore]
        public virtual TypePlaceParam ParamTypeNavigation { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<TypePlaceTr> TypePlaceTr { get; set; }
    }
}



