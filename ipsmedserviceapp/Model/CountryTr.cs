using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CountryTr
    {
        public string countryCode { get; set; }
        public string lang { get; set; }
        public string countryName { get; set; }
        public string countryNameShort { get; set; }

        public Country countryCodeNavigation { get; set; }
    }
}
