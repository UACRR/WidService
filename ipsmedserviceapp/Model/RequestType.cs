using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestType
    {
        public RequestType()
        {
            RelReqObj = new HashSet<RelReqObj>();
            Request = new HashSet<Request>();
            RequestTypeTr = new HashSet<RequestTypeTr>();
            UseAreaType = new HashSet<UseAreaType>();
            UseMediaType = new HashSet<UseMediaType>();
        }

        public int codeI { get; set; }
        public int categoryCode { get; set; }
        public string name { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ICollection<RelReqObj> RelReqObj { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<RequestTypeTr> RequestTypeTr { get; set; }
        public ICollection<UseAreaType> UseAreaType { get; set; }
        public ICollection<UseMediaType> UseMediaType { get; set; }
    }
}
