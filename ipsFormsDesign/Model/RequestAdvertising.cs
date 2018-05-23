using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestAdvertising : IRequestAdvertising
    {
        public int ReqId { get; set; }
        public string TradeMark { get; set; }
        public double? DurationAll { get; set; }
        public double? DurationShort { get; set; }

        public Request Req { get; set; }
    }
}

