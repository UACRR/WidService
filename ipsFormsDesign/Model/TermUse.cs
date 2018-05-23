using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TermUse : ITermUse
    {
        public TermUse()
        {
            Request = new HashSet<Request>();
            TermUseTr = new HashSet<TermUseTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Request> Request { get; set; }
        public ICollection<TermUseTr> TermUseTr { get; set; }
    }
}

