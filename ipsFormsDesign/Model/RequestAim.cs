using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RequestAim : IRequestAim
    {
        public RequestAim()
        {
            Request = new ObservableListSource<Request>();
            RequestAimTr = new ObservableListSource<RequestAimTr>();
        }

        public int CodeI { get; set; }
        public int ReqType { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<RequestAimTr> RequestAimTr { get; set; }
    }
}

