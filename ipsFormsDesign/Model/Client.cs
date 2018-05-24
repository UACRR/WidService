using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Client : IClient
    {
        public Client()
        {
            BrRegister = new HashSet<BrRegister>();
            ClnBusinessPlace = new HashSet<ClnBusinessPlace>();
            Distribution = new HashSet<Distribution>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
            MoneyReceived = new HashSet<MoneyReceived>();
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int CustId { get; set; }

        public Customer Cust { get; set; }
        public ICollection<BrRegister> BrRegister { get; set; }
        public ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public ICollection<Distribution> Distribution { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public ICollection<MoneyReceived> MoneyReceived { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}

