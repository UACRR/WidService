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

        public int emplid { get; set; }
        public int? custId { get; set; }
        public string userId { get; set; }
        public string firstName { get; set; }
        public string surName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public Customer cust { get; set; }
        public AspNetUsers user { get; set; }
        public ICollection<RelEmployee> RelEmployee { get; set; }
    }
}
