using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class BankAccount : IBankAccount
    {
        public BankAccount()
        {
            AnketaCompany = new ObservableListSource<AnketaCompany>();
            AnketaPerson = new ObservableListSource<AnketaPerson>();
        }

        public int BanAccId { get; set; }
        public int? CustId { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public string TransitNumber { get; set; }
        public int? Mfo { get; set; }
        public string MfoName { get; set; }
        public string MfoOkpo { get; set; }
        public string PIndex { get; set; }
        public string PAddress { get; set; }
        public string PCity { get; set; }
        public string PCountry { get; set; }
        public int? PRegion { get; set; }

        public KlR030 CurrencyNavigation { get; set; }
        public Customer Cust { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
    }
}

