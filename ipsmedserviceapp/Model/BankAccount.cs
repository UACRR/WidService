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

        public virtual KlR030 CurrencyNavigation { get; set; }
        public virtual Customer Cust { get; set; }
        public virtual ICollection<AnketaCompany> AnketaCompany { get; set; }
        public virtual ICollection<AnketaPerson> AnketaPerson { get; set; }
    }
}
