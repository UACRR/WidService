using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestStatusType
    {
        public RequestStatusType()
        {
            Request = new HashSet<Request>();
        }

        public int ReqStatusCode { get; set; }
        public string ReqStatusNameUk { get; set; }
        public string ReqStatusNameRu { get; set; }
        public string ReqStatusNameEn { get; set; }

        public ICollection<Request> Request { get; set; }
    }
}
