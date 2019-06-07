using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementAddPartner : IAgreementAddPartner
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
        public int Version { get; set; }
        public string AgrNumber { get; set; }
        public DateTime? AgrDate { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? PeriodCode { get; set; }
        public int? AgrStatus { get; set; }
        public int? DayForPay { get; set; }
        public int? AnkVersion { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        public virtual AgreementMaster Agr { get; set; }
        public virtual AgreementStatus AgrStatusNavigation { get; set; }
        public virtual Partner Cust { get; set; }
        public virtual Period PeriodCodeNavigation { get; set; }
    }
}

