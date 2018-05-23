using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestType : IRequestType
    {
        public RequestType()
        {
            DocTemplate = new HashSet<DocTemplate>();
            RelReqObj = new HashSet<RelReqObj>();
            Request = new HashSet<Request>();
            RequestAim = new HashSet<RequestAim>();
            UseAreaType = new HashSet<UseAreaType>();
            UseMediaType = new HashSet<UseMediaType>();
        }

        public int ReqType { get; set; }
        public int CategoryCode { get; set; }
        public string ReqTypeNameUk { get; set; }
        public string ReqTypeNameRu { get; set; }
        public string ReqTypeNameEn { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<DocTemplate> DocTemplate { get; set; }
        public ICollection<RelReqObj> RelReqObj { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<RequestAim> RequestAim { get; set; }
        public ICollection<UseAreaType> UseAreaType { get; set; }
        public ICollection<UseMediaType> UseMediaType { get; set; }
    }
}

