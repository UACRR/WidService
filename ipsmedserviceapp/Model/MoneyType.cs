using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MoneyType
    {
        public MoneyType()
        {
            MoneyReceived = new HashSet<MoneyReceived>();
            MoneyTypeTr = new HashSet<MoneyTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<MoneyReceived> MoneyReceived { get; set; }
        public ICollection<MoneyTypeTr> MoneyTypeTr { get; set; }
    }
}
