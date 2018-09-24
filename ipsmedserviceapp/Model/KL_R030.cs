using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class KL_R030
    {
        public KL_R030()
        {
            BankAccount = new HashSet<BankAccount>();
            CurrencyCourse = new HashSet<CurrencyCourse>();
            KL_R030Tr = new HashSet<KL_R030Tr>();
        }

        public string r030 { get; set; }
        public short? r031 { get; set; }
        public string countryCode { get; set; }
        public string a3 { get; set; }
        public string r030Name { get; set; }
        public int? nOMIN { get; set; }
        public string nAIM { get; set; }
        public short? pr_work { get; set; }

        public Country countryCodeNavigation { get; set; }
        public KL_R031 r031Navigation { get; set; }
        public ICollection<BankAccount> BankAccount { get; set; }
        public ICollection<CurrencyCourse> CurrencyCourse { get; set; }
        public ICollection<KL_R030Tr> KL_R030Tr { get; set; }
    }
}
