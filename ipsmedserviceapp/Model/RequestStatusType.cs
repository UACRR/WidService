using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestStatusType
    {
        public RequestStatusType()
        {
            Request = new HashSet<Request>();
            RequestStatusTypeTr = new HashSet<RequestStatusTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<Request> Request { get; set; }
        public ICollection<RequestStatusTypeTr> RequestStatusTypeTr { get; set; }
    }
}
