using ipsFormsDesign.Interfaces;
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

        public virtual TypePlaceParam ParamTypeNavigation { get; set; }
        public virtual ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public virtual ObservableListSource<TypePlaceTr> TypePlaceTr { get; set; }
    }
}

