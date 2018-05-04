using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementAddPartner
    {
        public int AgrId { get; set; }
        public int? CustId { get; set; }
        public decimal? SrFirstRate { get; set; }
        public decimal? SrMonthRate { get; set; }
        public decimal? PfFirstRate { get; set; }
        public decimal? PfMonthRate { get; set; }
        public decimal? CourtRate { get; set; }
        public decimal? NoCourtRate { get; set; }
        public decimal? CourtCompRate { get; set; }

        public AgreementMaster Agr { get; set; }
        public Partner Cust { get; set; }
    }
}
