using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AgreementMaster
    {
        public AgreementMaster()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
            AgreementAddCommunity = new HashSet<AgreementAddCommunity>();
            AgreementAddPartner = new HashSet<AgreementAddPartner>();
            AgreementAddRh = new HashSet<AgreementAddRh>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
        }

        public int AgrId { get; set; }
        public int CustId { get; set; }
        public int? AgrStatus { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public int? AgrType { get; set; }
        public int? Version { get; set; }

        [JsonIgnore]
        public AgreementStatus AgrStatusNavigation { get; set; }
        [JsonIgnore]
        public AgreementType AgrTypeNavigation { get; set; }
        [JsonIgnore]
        public Customer Cust { get; set; }
        public ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        [JsonIgnore]
        public ICollection<AgreementAddCommunity> AgreementAddCommunity { get; set; }
        [JsonIgnore]
        public ICollection<AgreementAddPartner> AgreementAddPartner { get; set; }
        public ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        [JsonIgnore]
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
    }
}

