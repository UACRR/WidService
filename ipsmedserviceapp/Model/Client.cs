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
            LicenseAgreement = new HashSet<LicenseAgreement>();
            MoneyReceived = new HashSet<MoneyReceived>();
            PaidPeriod = new HashSet<PaidPeriod>();
            PartnerClient = new HashSet<PartnerClient>();
        }

        public int CustId { get; set; }

        [JsonIgnore]
        public Customer Cust { get; set; }
        [JsonIgnore]
        public ICollection<AgreementAddBr> AgreementAddBr { get; set; }
        [JsonIgnore]
        public ICollection<BrRegister> BrRegister { get; set; }
        public ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        [JsonIgnore]
        public ICollection<MoneyReceived> MoneyReceived { get; set; }
        [JsonIgnore]
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
        [JsonIgnore]
        public ICollection<PartnerClient> PartnerClient { get; set; }
    }
}











