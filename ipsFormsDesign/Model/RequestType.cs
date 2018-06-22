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

        public Category CategoryCodeNavigation { get; set; }
        public ObservableListSource<RelReqObj> RelReqObj { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<RequestTypeTr> RequestTypeTr { get; set; }
        public ObservableListSource<UseAreaType> UseAreaType { get; set; }
        public ObservableListSource<UseMediaType> UseMediaType { get; set; }
    }
}

