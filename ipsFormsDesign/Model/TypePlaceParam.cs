using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypePlaceParam : ITypePlaceParam
    {
        public TypePlaceParam()
        {
            TypePlace = new ObservableListSource<TypePlace>();
            TypePlaceParamTr = new ObservableListSource<TypePlaceParamTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<TypePlace> TypePlace { get; set; }
        public ObservableListSource<TypePlaceParamTr> TypePlaceParamTr { get; set; }
    }
}

