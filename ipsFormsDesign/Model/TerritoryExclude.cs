using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TerritoryExclude : ITerritoryExclude
    {
        public int custId { get; set; }
        public string countryCode { get; set; }

        public Country countryCodeNavigation { get; set; }
        public RightHolder cust { get; set; }
    }
}

