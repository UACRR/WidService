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
            LicenseAgreement = new ObservableListSource<LicenseAgreement>();
            MoneyReceived = new ObservableListSource<MoneyReceived>();
            PaidPeriod = new ObservableListSource<PaidPeriod>();
            PartnerClient = new ObservableListSource<PartnerClient>();
            Register = new ObservableListSource<Register>();
        }

        public int CustId { get; set; }
        public string ClientBrand { get; set; }
        public string ClientGroup { get; set; }

        public Customer Cust { get; set; }
        public ObservableListSource<AgreementAddBr> AgreementAddBr { get; set; }
        public ObservableListSource<BrRegister> BrRegister { get; set; }
        public ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public ObservableListSource<MoneyReceived> MoneyReceived { get; set; }
        public ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        public ObservableListSource<PartnerClient> PartnerClient { get; set; }
        public ObservableListSource<Register> Register { get; set; }
    }
}

