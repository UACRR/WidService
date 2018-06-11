using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestType : IRequestType
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

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<RelReqObj> RelReqObj { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<RequestTypeTr> RequestTypeTr { get; set; }
        public ICollection<UseAreaType> UseAreaType { get; set; }
        public ICollection<UseMediaType> UseMediaType { get; set; }
    }
}

