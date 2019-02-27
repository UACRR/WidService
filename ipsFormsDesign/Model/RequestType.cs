using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestType : IRequestType
    {
        public RequestType()
        {
            RelReqObj = new ObservableListSource<RelReqObj>();
            Request = new ObservableListSource<Request>();
            RequestTypeTr = new ObservableListSource<RequestTypeTr>();
            UseAreaType = new ObservableListSource<UseAreaType>();
            UseMediaType = new ObservableListSource<UseMediaType>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ObservableListSource<RelReqObj> RelReqObj { get; set; }
        public virtual ObservableListSource<Request> Request { get; set; }
        public virtual ObservableListSource<RequestTypeTr> RequestTypeTr { get; set; }
        public virtual ObservableListSource<UseAreaType> UseAreaType { get; set; }
        public virtual ObservableListSource<UseMediaType> UseMediaType { get; set; }
    }
}

