using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestInternet
    {
        public int ReqId { get; set; }
        public int? TypeInternetObject { get; set; }
        public string Url { get; set; }
        public string UseDesc { get; set; }

        public virtual Request Req { get; set; }
        public virtual TypeInternetObject TypeInternetObjectNavigation { get; set; }
    }
}
