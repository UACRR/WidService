using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementMaster
    {
        public AgreementMaster()
        {
            AgreementAddBR = new HashSet<AgreementAddBR>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRH = new HashSet<AgreementAddRH>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int agrId { get; set; }
        public int custId { get; set; }
        public int? agrStatus { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public int? agrType { get; set; }
        public int? version { get; set; }

        [JsonIgnore]
        public AgreementStatus agrStatusNavigation { get; set; }
        [JsonIgnore]
        public AgreementType agrTypeNavigation { get; set; }
        [JsonIgnore]
        public Customer cust { get; set; }
        [JsonIgnore]
        public ICollection<AgreementAddBR> AgreementAddBR { get; set; }
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        [JsonIgnore]
        public ICollection<AgreementAddRH> AgreementAddRH { get; set; }
        [JsonIgnore]
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

