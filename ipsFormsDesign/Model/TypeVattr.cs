using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeVattr
    {
        public int VType { get; set; }
        public string Lang { get; set; }
        public string VTypeName { get; set; }

        public TypeVat VTypeNavigation { get; set; }
    }
}
