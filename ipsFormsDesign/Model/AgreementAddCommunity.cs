using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementAddCommunity : IAgreementAddCommunity
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

        public AgreementMaster Agr { get; set; }
        public AgreementStatus AgrStatusNavigation { get; set; }
        public Community Cust { get; set; }
        public Period PeriodCodeNavigation { get; set; }
    }
}

