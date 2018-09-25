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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<RegisterListStatusTr> RegisterListStatusTr { get; set; }
        public ICollection<RegisterRatedList> RegisterRatedList { get; set; }
    }
}
