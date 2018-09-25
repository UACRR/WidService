using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelReqObj : IRelReqObj
    {
        public int categoryCode { get; set; }
        public int reqType { get; set; }
        public int kindGroupId { get; set; }
        public int? CRKindCode { get; set; }

        public RequestType reqTypeNavigation { get; set; }
    }
}

