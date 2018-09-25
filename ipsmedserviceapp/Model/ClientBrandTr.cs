using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ClientBrandTr
    {
        public int codeI { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public ClientBrand codeINavigation { get; set; }
    }
}
