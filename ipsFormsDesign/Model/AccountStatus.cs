using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AccountStatus : IAccountStatus
    {
        public AccountStatus()
        {
            Account = new ObservableListSource<Account>();
            AccountStatusTr = new ObservableListSource<AccountStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Account> Account { get; set; }
        public virtual ObservableListSource<AccountStatusTr> AccountStatusTr { get; set; }
    }
}

