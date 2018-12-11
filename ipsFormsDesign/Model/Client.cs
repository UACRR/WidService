using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Client : IClient
    {
        public Client()
        {
            AgreementAddBr = new ObservableListSource<AgreementAddBr>();
            BrRegister = new ObservableListSource<BrRegister>();
            ClnBusinessPlace = new ObservableListSource<ClnBusinessPlace>();
            Distribution = new ObservableListSource<Distribution>();
            Fixation = new ObservableListSource<Fixation>();
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
            MoneyReceived = new ObservableListSource<MoneyReceived>();
            PaidPeriod = new ObservableListSource<PaidPeriod>();
            PartnerClient = new ObservableListSource<PartnerClient>();
            Register = new ObservableListSource<Register>();
        }

        public int CustId { get; set; }
        public string ClientBrand { get; set; }
        public string ClientGroup { get; set; }

        [JsonIgnore]
        public Customer Cust { get; set; }
        [JsonIgnore]
        public ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        [JsonIgnore]
        public ObservableListSource<BrRegister> BrRegister { get; set; }
        public ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public ObservableListSource<Distribution> Distribution { get; set; }
        [JsonIgnore]
        public ObservableListSource<Fixation> Fixation { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public ObservableListSource<MoneyReceived> MoneyReceived { get; set; }
        [JsonIgnore]
        public ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        [JsonIgnore]
        public ObservableListSource<PartnerClient> PartnerClient { get; set; }
        [JsonIgnore]
        public ObservableListSource<Register> Register { get; set; }
    }
}


