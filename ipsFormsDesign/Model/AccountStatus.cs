using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AccountStatus : IAccountStatus
    {
        public AccountStatus()
        {
            Account = new HashSet<Account>();
            AccountStatusTr = new HashSet<AccountStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Account { get; set; }
        public ICollection<AccountStatusTr> AccountStatusTr { get; set; }
    }
}

