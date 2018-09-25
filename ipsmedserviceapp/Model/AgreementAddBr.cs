using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementAddBR
    {
        public int agrId { get; set; }
        public int version { get; set; }
        public string agrNumber { get; set; }
        public DateTime? agrDate { get; set; }
        public DateTime? dateBegin { get; set; }
        public DateTime? dateEnd { get; set; }
        public int? periodCode { get; set; }
        public int? agrStatus { get; set; }
        public int? dayForPay { get; set; }
        public int? ankVersion { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? custId { get; set; }

        [JsonIgnore]
        public AgreementMaster agr { get; set; }
        [JsonIgnore]
        public AgreementStatus agrStatusNavigation { get; set; }
        [JsonIgnore]
        public Client cust { get; set; }
        [JsonIgnore]
        public Period periodCodeNavigation { get; set; }
    }
}

