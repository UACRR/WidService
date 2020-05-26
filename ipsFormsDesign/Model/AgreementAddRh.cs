using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
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
        public string AgrNumber { get; set; }
        public DateTime? AgrDate { get; set; }
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
        public virtual AgreementMaster Agr { get; set; }
        [JsonIgnore]
        public virtual AgreementStatus AgrStatusNavigation { get; set; }
        [JsonIgnore]
        public virtual RightHolder Cust { get; set; }
        [JsonIgnore]
        public virtual TypeMethodGet GetCodeNavigation { get; set; }
        [JsonIgnore]
        public virtual Period PeriodCodeNavigation { get; set; }
    }
}




