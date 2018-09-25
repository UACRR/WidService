using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AnketaAddName : IAnketaAddName
    {
        public int custId { get; set; }
        public string lang { get; set; }
        public string nikName { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string lastName { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }

        public Customer cust { get; set; }
    }
}

