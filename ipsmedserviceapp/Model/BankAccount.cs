using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            AnketaCompany = new HashSet<AnketaCompany>();
            AnketaPerson = new HashSet<AnketaPerson>();
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
        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<AnketaPerson> AnketaPerson { get; set; }
    }
}
