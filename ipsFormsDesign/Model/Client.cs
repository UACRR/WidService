using System;
using System.Collections.Generic;
using ipsFormsDesign.Interfaces;

namespace ipsmedserviceapp.Model
{
    public partial class Client : IClient
    {
        public Client()
        {
            ClnBusinessPlace = new HashSet<ClnBusinessPlace>();
            LicenseAgreement = new HashSet<LicenseAgreement>();
            MoneyReceived = new HashSet<MoneyReceived>();
            PaidPeriod = new HashSet<PaidPeriod>();
        }

        public int CustId { get; set; }

        public Customer Cust { get; set; }
        public ICollection<ClnBusinessPlace> ClnBusinessPlace { get; set; }
        public ICollection<LicenseAgreement> LicenseAgreement { get; set; }
        public ICollection<MoneyReceived> MoneyReceived { get; set; }
        public ICollection<PaidPeriod> PaidPeriod { get; set; }
    }
}
