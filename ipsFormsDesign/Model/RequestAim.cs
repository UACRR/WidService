using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestAim : IRequestAim
    {
        public RequestAim()
        {
            Request = new HashSet<Request>();
        }

        public int ReqAimCode { get; set; }
        public int ReqType { get; set; }
        public string ReqAimNameUk { get; set; }
        public string ReqAimNameRu { get; set; }
        public string ReqAimNameEn { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}

