using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KL_R030 : IKL_R030
    {
        public KL_R030()
        {
            BankAccount = new ObservableListSource<BankAccount>();
            CurrencyCourse = new ObservableListSource<CurrencyCourse>();
            KL_R030Tr = new ObservableListSource<KL_R030Tr>();
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
        public ObservableListSource<BankAccount> BankAccount { get; set; }
        public ObservableListSource<CurrencyCourse> CurrencyCourse { get; set; }
        public ObservableListSource<KL_R030Tr> KL_R030Tr { get; set; }
    }
}

