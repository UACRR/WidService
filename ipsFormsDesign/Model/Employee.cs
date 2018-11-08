using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Employee : IEmployee
    {
        public Employee()
        {
            RelEmployee = new ObservableListSource<RelEmployee>();
        }

        public int Emplid { get; set; }
        public int? CustId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public Customer Cust { get; set; }
        public AspNetUsers User { get; set; }
        public ObservableListSource<RelEmployee> RelEmployee { get; set; }
    }
}

