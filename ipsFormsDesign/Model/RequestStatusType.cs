using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestStatusType : IRequestStatusType
    {
        public RequestStatusType()
        {
            Request = new HashSet<Request>();
            RequestStatusTypeTr = new HashSet<RequestStatusTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Request> Request { get; set; }
        public ICollection<RequestStatusTypeTr> RequestStatusTypeTr { get; set; }
    }
}

