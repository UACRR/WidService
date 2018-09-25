using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Company : ICompany
    {
        public Company()
        {
            AnketaCompany = new ObservableListSource<AnketaCompany>();
            RelEmployee = new ObservableListSource<RelEmployee>();
        }

        public int custId { get; set; }
        public int version { get; set; }

        public Customer cust { get; set; }
        public ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public ObservableListSource<RelEmployee> RelEmployee { get; set; }
    }
}

