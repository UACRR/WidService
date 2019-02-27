using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TermUse : ITermUse
    {
        public TermUse()
        {
            Request = new ObservableListSource<Request>();
            TermUseTr = new ObservableListSource<TermUseTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Request> Request { get; set; }
        public virtual ObservableListSource<TermUseTr> TermUseTr { get; set; }
    }
}

