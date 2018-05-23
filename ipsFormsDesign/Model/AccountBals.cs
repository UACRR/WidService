using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AccountBals : IAccountBals
    {
        public AccountBals()
        {
            Account = new HashSet<Account>();
        }

        public int BalsCode { get; set; }
        public short? BalsType { get; set; }
        public string BalsNameUk { get; set; }
        public string BalsNameRu { get; set; }
        public string BalsNameEn { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}

