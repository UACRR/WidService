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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<RequestStatusTypeTr> RequestStatusTypeTr { get; set; }
    }
}
