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

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual ObservableListSource<Request> Request { get; set; }
        public virtual ObservableListSource<RequestAimTr> RequestAimTr { get; set; }
    }
}

