using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestOther
    {
        public int reqId { get; set; }
        public string useDesc { get; set; }

        public Request req { get; set; }
    }
}
