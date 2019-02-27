using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ReqLocationUse : IReqLocationUse
    {
        public int LocUsId { get; set; }
        public int? ReqId { get; set; }
        public string CountryCode { get; set; }
        public int? ContinentCode { get; set; }

        public virtual Continent ContinentCodeNavigation { get; set; }
        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Request Req { get; set; }
    }
}

