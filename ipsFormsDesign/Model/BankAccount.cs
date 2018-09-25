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

        public int banAccID { get; set; }
        public int? custId { get; set; }
        public string accountNumber { get; set; }
        public string currency { get; set; }
        public string transitNumber { get; set; }
        public int? mfo { get; set; }
        public string mfoName { get; set; }
        public string mfoOkpo { get; set; }
        public string pIndex { get; set; }
        public string pAddress { get; set; }
        public string pCity { get; set; }
        public string pCountry { get; set; }
        public int? pRegion { get; set; }

        public KL_R030 currencyNavigation { get; set; }
        public Customer cust { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public ObservableListSource<AnketaPerson> AnketaPerson { get; set; }
    }
}

