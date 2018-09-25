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

        public int codeI { get; set; }
        public string name { get; set; }
        public string typeInetNameEn { get; set; }
        public string typeInetNameRu { get; set; }

        public ObservableListSource<RequestInternet> RequestInternet { get; set; }
        public ObservableListSource<TypeInternetObjectTr> TypeInternetObjectTr { get; set; }
    }
}

