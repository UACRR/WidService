using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypePlaceTr
    {
        public int PlCode { get; set; }
        public string Lang { get; set; }
        public string PlName { get; set; }

        public TypePlace PlCodeNavigation { get; set; }
    }
}
