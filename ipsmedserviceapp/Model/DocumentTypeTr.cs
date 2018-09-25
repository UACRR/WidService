using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocumentTypeTr
    {
        public int codeI { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public FileType codeINavigation { get; set; }
    }
}
