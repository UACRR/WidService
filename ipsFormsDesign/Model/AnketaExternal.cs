using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaExternal : IAnketaExternal
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string InterCode { get; set; }
        public string CountryCode { get; set; }
        public string InnOkpo { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Customer Cust { get; set; }
    }
}

