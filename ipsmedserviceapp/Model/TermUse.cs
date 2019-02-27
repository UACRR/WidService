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

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<TermUseTr> TermUseTr { get; set; }
    }
}
