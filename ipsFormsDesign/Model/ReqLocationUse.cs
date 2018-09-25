using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ReqLocationUse : IReqLocationUse
    {
        public int locUsId { get; set; }
        public int? reqId { get; set; }
        public string countryCode { get; set; }
        public int? continentCode { get; set; }

        public Continent continentCodeNavigation { get; set; }
        public Country countryCodeNavigation { get; set; }
        public Request req { get; set; }
    }
}

