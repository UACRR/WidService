using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LangTr
    {
        public string codeS { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public Lang codeSNavigation { get; set; }
    }
}
