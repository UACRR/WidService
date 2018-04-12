using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CustomerTypeTr
    {
        public int CustType { get; set; }
        public string Lang { get; set; }
        public string CustTypeName { get; set; }

        public CustomerType CustTypeNavigation { get; set; }
    }
}
