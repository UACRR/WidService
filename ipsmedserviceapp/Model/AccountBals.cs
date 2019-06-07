using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AccountBals
    {
        public AccountBals()
        {
            Account = new HashSet<Account>();
            AccountBalsTr = new HashSet<AccountBalsTr>();
        }

        public int CodeI { get; set; }
        public short? BalsType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<AccountBalsTr> AccountBalsTr { get; set; }
    }
}
