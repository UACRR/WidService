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

        public int CodeI { get; set; }
        public string Name { get; set; }
        public string TypeInetNameEn { get; set; }
        public string TypeInetNameRu { get; set; }

        public virtual ICollection<RequestInternet> RequestInternet { get; set; }
        public virtual ICollection<TypeInternetObjectTr> TypeInternetObjectTr { get; set; }
    }
}
