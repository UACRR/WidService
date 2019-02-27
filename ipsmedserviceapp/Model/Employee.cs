using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Employee
    {
        public Employee()
        {
            RelEmployee = new HashSet<RelEmployee>();
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

        public virtual Customer Cust { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<RelEmployee> RelEmployee { get; set; }
    }
}
