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

        public int codeI { get; set; }
        public int categoryCode { get; set; }
        public string name { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ObservableListSource<RelReqObj> RelReqObj { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<RequestTypeTr> RequestTypeTr { get; set; }
        public ObservableListSource<UseAreaType> UseAreaType { get; set; }
        public ObservableListSource<UseMediaType> UseMediaType { get; set; }
    }
}

