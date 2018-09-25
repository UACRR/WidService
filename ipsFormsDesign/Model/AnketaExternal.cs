using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaExternal : IAnketaExternal
    {
        public int custId { get; set; }
        public string name { get; set; }
        public string interCode { get; set; }
        public string countryCode { get; set; }
        public string innOkpo { get; set; }

        public Country countryCodeNavigation { get; set; }
        public Customer cust { get; set; }
    }
}

