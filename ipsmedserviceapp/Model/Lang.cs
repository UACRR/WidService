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

        public string CodeS { get; set; }
        public string Name { get; set; }
        public string Lang1 { get; set; }

        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
        public virtual ICollection<LangTr> LangTr { get; set; }
    }
}
