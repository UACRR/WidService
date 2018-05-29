using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Company : ICompany
    {
        public Company()
        {
            AnketaCompany = new HashSet<AnketaCompany>();
            RelEmployee = new HashSet<RelEmployee>();
        }

        public int CustId { get; set; }
        public int Version { get; set; }

        public Customer Cust { get; set; }
        public ICollection<AnketaCompany> AnketaCompany { get; set; }
        public ICollection<RelEmployee> RelEmployee { get; set; }
    }
}

