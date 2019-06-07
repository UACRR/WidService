using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestStatusType : IRequestStatusType
    {
        public RequestStatusType()
        {
            Request = new ObservableListSource<Request>();
            RequestStatusTypeTr = new ObservableListSource<RequestStatusTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Request> Request { get; set; }
        public virtual ObservableListSource<RequestStatusTypeTr> RequestStatusTypeTr { get; set; }
    }
}

