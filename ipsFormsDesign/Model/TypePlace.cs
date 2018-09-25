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

        public int codeI { get; set; }
        public string name { get; set; }
        public bool? isHoll { get; set; }
        public int? paramType { get; set; }

        public TypePlaceParam paramTypeNavigation { get; set; }
        public ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public ObservableListSource<TypePlaceTr> TypePlaceTr { get; set; }
    }
}

