using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RequestAim
    {
        public RequestAim()
        {
            Request = new HashSet<Request>();
            RequestAimTr = new HashSet<RequestAimTr>();
        }

        public int codeI { get; set; }
        public int reqType { get; set; }
        public string name { get; set; }
        public int categoryCode { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<RequestAimTr> RequestAimTr { get; set; }
    }
}
