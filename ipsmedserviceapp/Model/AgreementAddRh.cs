using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementAddRh
    {
        public int AgrId { get; set; }
        public decimal? RateCourt { get; set; }
        public decimal? RateCommiss { get; set; }
        public string ResponsUser { get; set; }
        public int? CustId { get; set; }

        public AgreementMaster Agr { get; set; }
        public RightHolder Cust { get; set; }
        public AspNetUsers ResponsUserNavigation { get; set; }
    }
}
