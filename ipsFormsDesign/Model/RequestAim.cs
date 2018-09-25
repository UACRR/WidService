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

        public int codeI { get; set; }
        public int reqType { get; set; }
        public string name { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<RequestAimTr> RequestAimTr { get; set; }
    }
}

