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

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ICollection<RelReqObj> RelReqObj { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<RequestTypeTr> RequestTypeTr { get; set; }
        public virtual ICollection<UseAreaType> UseAreaType { get; set; }
        public virtual ICollection<UseMediaType> UseMediaType { get; set; }
    }
}
