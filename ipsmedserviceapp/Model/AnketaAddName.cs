using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AnketaAddName
    {
        public int CustId { get; set; }
        public string Lang { get; set; }
        public string NikName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual Customer Cust { get; set; }
    }
}
