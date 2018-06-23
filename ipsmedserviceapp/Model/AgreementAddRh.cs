using Newtonsoft.Json;
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

        [JsonIgnore]
        public AgreementMaster Agr { get; set; }
        [JsonIgnore]
        public AgreementStatus AgrStatusNavigation { get; set; }
        [JsonIgnore]
        public RightHolder Cust { get; set; }
        [JsonIgnore]
        public TypeMethodGet GetCodeNavigation { get; set; }
        [JsonIgnore]
        public Period PeriodCodeNavigation { get; set; }
        [JsonIgnore]
        public AspNetUsers ResponsUserNavigation { get; set; }
    }
}

