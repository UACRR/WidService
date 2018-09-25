using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestAdvertising
    {
        public int reqId { get; set; }
        public string tradeMark { get; set; }
        public TimeSpan? durationAll { get; set; }
        public TimeSpan? durationShort { get; set; }

        public Request req { get; set; }
    }
}
