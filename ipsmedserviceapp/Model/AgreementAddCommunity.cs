using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementAddCommunity
    {
        public int AgrId { get; set; }
        public int Version { get; set; }
        public decimal? RateCourt { get; set; }
        public decimal? RateCommiss { get; set; }
        public int? CustId { get; set; }
        public string AgrNumber { get; set; }
        public DateTime? AgrDate { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? PeriodCode { get; set; }
        public int? DayForPay { get; set; }
        public int? AnkVersion { get; set; }
        public int? AgrStatus { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        public virtual AgreementMaster Agr { get; set; }
        public virtual AgreementStatus AgrStatusNavigation { get; set; }
        public virtual Community Cust { get; set; }
        public virtual Period PeriodCodeNavigation { get; set; }
    }
}
