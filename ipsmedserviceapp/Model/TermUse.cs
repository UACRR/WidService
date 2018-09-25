using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TermUse
    {
        public TermUse()
        {
            Request = new HashSet<Request>();
            TermUseTr = new HashSet<TermUseTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<Request> Request { get; set; }
        public ICollection<TermUseTr> TermUseTr { get; set; }
    }
}
