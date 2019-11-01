using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Client
    {
        public Client()
        {
            AgreementAddBr = new HashSet<AgreementAddBr>();
            BrRegister = new HashSet<BrRegister>();
            ClnBusinessPlace = new HashSet<ClnBusinessPlace>();
            Distribution = new HashSet<Distribution>();
            ExternalPay = new HashSet<ExternalPay>();
            Fixation = new HashSet<Fixation>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
            MoneyReceived = new HashSet<MoneyReceived>();
            PaidPeriod = new HashSet<PaidPeriod>();
            PartnerClient = new HashSet<PartnerClient>();
            Register = new HashSet<Register>();
        }

        public int CustId { get; set; }
        public string ClientBrand { get; set; }
        public string ClientGroup { get; set; }

        [JsonIgnore]
        public virtual Customer Cust { get; set; }
        [JsonIgnore]
        public virtual ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        [JsonIgnore]
        public virtual ICollection<BrRegister> BrRegister { get; set; }
        public virtual ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public virtual ICollection<Distribution> Distribution { get; set; }
        [JsonIgnore]
        public virtual ICollection<ExternalPay> ExternalPay { get; set; }
        [JsonIgnore]
        public virtual ICollection<Fixation> Fixation { get; set; }
        public virtual ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public virtual ICollection<MoneyReceived> MoneyReceived { get; set; }
        [JsonIgnore]
        public virtual ICollection<PaidPeriod> PaidPeriod { get; set; }
        [JsonIgnore]
        public virtual ICollection<PartnerClient> PartnerClient { get; set; }
        [JsonIgnore]
        public virtual ICollection<Register> Register { get; set; }
    }
}


