using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Client : IClient
    {
        public Client()
        {
            AgreementAddBR = new ObservableListSource<AgreementAddBR>();
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

        public int custId { get; set; }
        public string clientBrand { get; set; }
        public string clientGroup { get; set; }

        public Customer cust { get; set; }
        public ObservableListSource<AgreementAddBR> AgreementAddBR { get; set; }
        public ObservableListSource<BrRegister> BrRegister { get; set; }
        public ObservableListSource<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public ObservableListSource<Distribution> Distribution { get; set; }
        public ObservableListSource<Fixation> Fixation { get; set; }
        public ObservableListSource<LicenseAgreement> LicenseAgreement { get; set; }
        public ObservableListSource<MoneyReceived> MoneyReceived { get; set; }
        public ObservableListSource<PaidPeriod> PaidPeriod { get; set; }
        public ObservableListSource<PartnerClient> PartnerClient { get; set; }
        public ObservableListSource<Register> Register { get; set; }
    }
}

