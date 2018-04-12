using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegionTr
    {
        public int RegionCode { get; set; }
        public string Lang { get; set; }
        public string RegionName { get; set; }

        public Region RegionCodeNavigation { get; set; }
    }
}
