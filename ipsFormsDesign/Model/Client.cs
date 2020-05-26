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
            ExternalPay = new ObservableListSource<ExternalPay>();
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
        public virtual Customer Cust { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<BrRegister> BrRegister { get; set; }
        public virtual ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<Distribution> Distribution { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<ExternalPay> ExternalPay { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<Fixation> Fixation { get; set; }
        public virtual ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public virtual ObservableListSource<MoneyReceived> MoneyReceived { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<PartnerClient> PartnerClient { get; set; }
        [JsonIgnore]
        public virtual ObservableListSource<Register> Register { get; set; }
    }
}




