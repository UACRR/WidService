using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeInternetObject : ITypeInternetObject
    {
        public TypeInternetObject()
        {
            RequestInternet = new HashSet<RequestInternet>();
            TypeInternetObjectTr = new HashSet<TypeInternetObjectTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string TypeInetNameEn { get; set; }
        public string TypeInetNameRu { get; set; }

        public ICollection<RequestInternet> RequestInternet { get; set; }
        public ICollection<TypeInternetObjectTr> TypeInternetObjectTr { get; set; }
    }
}

