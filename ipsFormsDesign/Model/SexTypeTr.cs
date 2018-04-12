using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SexTypeTr
    {
        public int SexCode { get; set; }
        public string Lang { get; set; }
        public string SexName { get; set; }

        public SexType SexCodeNavigation { get; set; }
    }
}
