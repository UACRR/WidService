using ipsFormsDesign.Interfaces;
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

        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        public virtual ObservableListSource<BrRegister> BrRegister { get; set; }
        public virtual ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public virtual ObservableListSource<Distribution> Distribution { get; set; }
        public virtual ObservableListSource<ExternalPay> ExternalPay { get; set; }
        public virtual ObservableListSource<Fixation> Fixation { get; set; }
        public virtual ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public virtual ObservableListSource<MoneyReceived> MoneyReceived { get; set; }
        public virtual ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        public virtual ObservableListSource<PartnerClient> PartnerClient { get; set; }
        public virtual ObservableListSource<Register> Register { get; set; }
    }
}

