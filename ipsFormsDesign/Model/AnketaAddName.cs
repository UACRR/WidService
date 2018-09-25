using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaAddName : IAnketaAddName
    {
        public int CustId { get; set; }
        public string Lang { get; set; }
        public string NikName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public Customer Cust { get; set; }
    }
}

