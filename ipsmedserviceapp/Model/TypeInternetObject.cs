using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeInternetObject
    {
        public TypeInternetObject()
        {
            RequestInternet = new HashSet<RequestInternet>();
            TypeInternetObjectTr = new HashSet<TypeInternetObjectTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }
        public string typeInetNameEn { get; set; }
        public string typeInetNameRu { get; set; }

        public ICollection<RequestInternet> RequestInternet { get; set; }
        public ICollection<TypeInternetObjectTr> TypeInternetObjectTr { get; set; }
    }
}
