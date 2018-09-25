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

        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<RequestStatusTypeTr> RequestStatusTypeTr { get; set; }
    }
}

