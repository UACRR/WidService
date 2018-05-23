using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AccountStatus : IAccountStatus
    {
        public int StatusCode { get; set; }
        public string StatusNameUk { get; set; }
        public string StatusNameRu { get; set; }
        public string StatusNameEn { get; set; }
    }
}

