using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class KlR030 : IKlR030
    {
        public KlR030()
        {
            BankAccount = new ObservableListSource<BankAccount>();
            CurrencyCourse = new ObservableListSource<CurrencyCourse>();
            KlR030tr = new ObservableListSource<KlR030tr>();
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
        public virtual ObservableListSource<BankAccount> BankAccount { get; set; }
        public virtual ObservableListSource<CurrencyCourse> CurrencyCourse { get; set; }
        public virtual ObservableListSource<KlR030tr> KlR030tr { get; set; }
    }
}

