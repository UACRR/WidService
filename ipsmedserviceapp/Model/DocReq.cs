using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocReq
    {
        public int docId { get; set; }
        public int reqId { get; set; }

        public Request req { get; set; }
    }
}
