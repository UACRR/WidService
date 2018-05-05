using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TermUse
    {
        public TermUse()
        {
            Request = new HashSet<Request>();
        }

        public int TermUseCode { get; set; }
        public string TermUseNameUk { get; set; }
        public string TermUseNameRu { get; set; }
        public string TermUseNameEn { get; set; }

        public ICollection<Request> Request { get; set; }
    }
}
