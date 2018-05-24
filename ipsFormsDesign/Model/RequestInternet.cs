using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestInternet : IRequestInternet
    {
        public int ReqId { get; set; }
        public int? TypeInternetObject { get; set; }
        public string Url { get; set; }
        public string UseDesc { get; set; }

        public Request Req { get; set; }
        public TypeInternetObject TypeInternetObjectNavigation { get; set; }
    }
}

