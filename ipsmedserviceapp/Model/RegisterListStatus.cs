using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterListStatus
    {
        public RegisterListStatus()
        {
            RegisterListStatusTr = new HashSet<RegisterListStatusTr>();
            RegisterRatedList = new HashSet<RegisterRatedList>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<RegisterListStatusTr> RegisterListStatusTr { get; set; }
        public ICollection<RegisterRatedList> RegisterRatedList { get; set; }
    }
}
