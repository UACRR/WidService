using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Currency
    {
        public Currency()
        {
            Account = new HashSet<Account>();
        }

        public string R030 { get; set; }
        public string A3 { get; set; }
        public string CountryCode { get; set; }
        public string R030NameEn { get; set; }
        public string R030NameRu { get; set; }
        public string R030NameUk { get; set; }
        public int? NOmin { get; set; }
        public string NAim { get; set; }
        public short? PrWork { get; set; }
        public short? PrNc { get; set; }
        public int? OrderBy { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}
