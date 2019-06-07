using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AccountBals : IAccountBals
    {
        public AccountBals()
        {
            Account = new ObservableListSource<Account>();
            AccountBalsTr = new ObservableListSource<AccountBalsTr>();
        }

        public int CodeI { get; set; }
        public short? BalsType { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<Account> Account { get; set; }
        public virtual ObservableListSource<AccountBalsTr> AccountBalsTr { get; set; }
    }
}

