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

        public int codeI { get; set; }
        public short? balsType { get; set; }
        public string name { get; set; }

        public ICollection<Account> Account { get; set; }
        public ICollection<AccountBalsTr> AccountBalsTr { get; set; }
    }
}
