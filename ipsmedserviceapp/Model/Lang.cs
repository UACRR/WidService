using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Lang
    {
        public Lang()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            LangTr = new HashSet<LangTr>();
        }

        public string codeS { get; set; }
        public string name { get; set; }

        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<LangTr> LangTr { get; set; }
    }
}
