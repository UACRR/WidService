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

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<Account> Account { get; set; }
        public ObservableListSource<AccountStatusTr> AccountStatusTr { get; set; }
    }
}

