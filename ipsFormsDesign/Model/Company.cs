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

        public int CustId { get; set; }
        public int Version { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual ObservableListSource<AnketaCompany> AnketaCompany { get; set; }
        public virtual ObservableListSource<RelEmployee> RelEmployee { get; set; }
    }
}

