using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KlR030
    {
        public KlR030()
        {
            BankAccount = new HashSet<BankAccount>();
            CurrencyCourse = new HashSet<CurrencyCourse>();
            KlR030tr = new HashSet<KlR030tr>();
            RegisterCcid = new HashSet<RegisterCcid>();
        }

        public string R030 { get; set; }
        public short? R031 { get; set; }
        public string CountryCode { get; set; }
        public string A3 { get; set; }
        public string R030Name { get; set; }
        public int? NOmin { get; set; }
        public string NAim { get; set; }
        public short? PrWork { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual KlR031 R031Navigation { get; set; }
        public virtual ICollection<BankAccount> BankAccount { get; set; }
        public virtual ICollection<CurrencyCourse> CurrencyCourse { get; set; }
        public virtual ICollection<KlR030tr> KlR030tr { get; set; }
        public virtual ICollection<RegisterCcid> RegisterCcid { get; set; }
    }
}
