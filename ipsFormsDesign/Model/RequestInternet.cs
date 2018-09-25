using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestInternet : IRequestInternet
    {
        public int reqId { get; set; }
        public int? typeInternetObject { get; set; }
        public string url { get; set; }
        public string useDesc { get; set; }

        public Request req { get; set; }
        public TypeInternetObject typeInternetObjectNavigation { get; set; }
    }
}

