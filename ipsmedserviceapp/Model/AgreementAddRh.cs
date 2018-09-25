using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementAddRH
    {
        public int agrId { get; set; }
        public decimal? rateCourt { get; set; }
        public decimal? rateCommiss { get; set; }
        public string responsUser { get; set; }
        public int? custId { get; set; }
        public int version { get; set; }
        public string agrNumber { get; set; }
        public DateTime? agrDate { get; set; }
        public DateTime? dateBegin { get; set; }
        public DateTime? dateEnd { get; set; }
        public int? periodCode { get; set; }
        public int? dayForPay { get; set; }
        public int? ankVersion { get; set; }
        public int? agrStatus { get; set; }
        public int? getCode { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }

        [JsonIgnore]
        public AgreementMaster agr { get; set; }
        [JsonIgnore]
        public AgreementStatus agrStatusNavigation { get; set; }
        [JsonIgnore]
        public RightHolder cust { get; set; }
        [JsonIgnore]
        public TypeMethodGet getCodeNavigation { get; set; }
        [JsonIgnore]
        public Period periodCodeNavigation { get; set; }
        [JsonIgnore]
        public AspNetUsers responsUserNavigation { get; set; }
    }
}

