using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class MonthName
    {
        public MonthName()
        {
            MonthNameTr = new HashSet<MonthNameTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MonthNameTr> MonthNameTr { get; set; }
    }
}
