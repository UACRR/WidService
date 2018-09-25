using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CountryTr : ICountryTr
    {
        public string CountryCode { get; set; }
        public string Lang { get; set; }
        public string CountryName { get; set; }
        public string CountryNameShort { get; set; }

        public Country CountryCodeNavigation { get; set; }
    }
}

