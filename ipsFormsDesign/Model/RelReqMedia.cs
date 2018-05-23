using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RelReqMedia : IRelReqMedia
    {
        public int UseMediaTypeCode { get; set; }
        public int ReqId { get; set; }

        public Request Req { get; set; }
        public UseMediaType UseMediaTypeCodeNavigation { get; set; }
    }
}

