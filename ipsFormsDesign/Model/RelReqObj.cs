using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelReqObj : IRelReqObj
    {
        public int CategoryCode { get; set; }
        public int ReqType { get; set; }
        public int KindGroupId { get; set; }
        public int? CrkindCode { get; set; }

        public RequestType ReqTypeNavigation { get; set; }
    }
}

