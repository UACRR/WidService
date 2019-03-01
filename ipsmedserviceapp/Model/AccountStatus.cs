using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AccountStatus
    {
        public AccountStatus()
        {
            Account = new HashSet<Account>();
            AccountStatusTr = new HashSet<AccountStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<AccountStatusTr> AccountStatusTr { get; set; }
    }
}
