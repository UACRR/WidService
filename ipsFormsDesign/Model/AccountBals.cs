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

        public int codeI { get; set; }
        public short? balsType { get; set; }
        public string name { get; set; }

        public ObservableListSource<Account> Account { get; set; }
        public ObservableListSource<AccountBalsTr> AccountBalsTr { get; set; }
    }
}

