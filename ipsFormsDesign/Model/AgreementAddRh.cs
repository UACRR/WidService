using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AgreementAddRh : IAgreementAddRh
    {
        public int AgrId { get; set; }
        public decimal? RateCourt { get; set; }
        public decimal? RateCommiss { get; set; }
        public string ResponsUser { get; set; }
        public int? CustId { get; set; }
        public int Version { get; set; }
        public int? IsCurrent { get; set; }
        public string AddNumber { get; set; }
        public DateTime? AddDate { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? PeriodCode { get; set; }
        public int? DayForPay { get; set; }
        public int? AnkVersion { get; set; }
        public int? AgrStatus { get; set; }
        public int? GetCode { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        public AgreementMaster Agr { get; set; }
        public AgreementStatus AgrStatusNavigation { get; set; }
        public RightHolder Cust { get; set; }
        public TypeMethodGet GetCodeNavigation { get; set; }
        public Period PeriodCodeNavigation { get; set; }
        public AspNetUsers ResponsUserNavigation { get; set; }
    }
}

