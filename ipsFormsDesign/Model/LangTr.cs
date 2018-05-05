using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LangTr
    {
        public string CodeS { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public Lang CodeSNavigation { get; set; }
    }
}
