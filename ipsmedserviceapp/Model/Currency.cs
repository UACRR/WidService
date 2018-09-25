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

        public string r030 { get; set; }
        public string a3 { get; set; }
        public string countryCode { get; set; }
        public string r030NameEn { get; set; }
        public string r030NameRu { get; set; }
        public string r030NameUk { get; set; }
        public int? nOMIN { get; set; }
        public string nAIM { get; set; }
        public short? prWork { get; set; }
        public short? prNC { get; set; }
        public int? orderBy { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}
