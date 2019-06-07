using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestAdvertising
    {
        public int ReqId { get; set; }
        public string TradeMark { get; set; }
        public TimeSpan? DurationAll { get; set; }
        public TimeSpan? DurationShort { get; set; }

        public virtual Request Req { get; set; }
    }
}
