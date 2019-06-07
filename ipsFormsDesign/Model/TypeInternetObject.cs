using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeInternetObject : ITypeInternetObject
    {
        public TypeInternetObject()
        {
            RequestInternet = new ObservableListSource<RequestInternet>();
            TypeInternetObjectTr = new ObservableListSource<TypeInternetObjectTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string TypeInetNameEn { get; set; }
        public string TypeInetNameRu { get; set; }

        public virtual ObservableListSource<RequestInternet> RequestInternet { get; set; }
        public virtual ObservableListSource<TypeInternetObjectTr> TypeInternetObjectTr { get; set; }
    }
}

