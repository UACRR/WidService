using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeInternetObject : ITypeInternetObject
    {
        public TypeInternetObject()
        {
            RequestInternet = new HashSet<RequestInternet>();
        }

        public int TypeInetCode { get; set; }
        public string TypeInetNameUk { get; set; }
        public string TypeInetNameEn { get; set; }
        public string TypeInetNameRu { get; set; }

        public ICollection<RequestInternet> RequestInternet { get; set; }
    }
}

