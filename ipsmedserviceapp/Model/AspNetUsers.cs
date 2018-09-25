using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AgreementAddRH = new HashSet<AgreementAddRH>();
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            BrRegister = new HashSet<BrRegister>();
            Employee = new HashSet<Employee>();
            Fixation = new HashSet<Fixation>();
            Register = new HashSet<Register>();
            Request = new HashSet<Request>();
            userRole = new HashSet<userRole>();
        }

        public string id { get; set; }
        public int accessFailedCount { get; set; }
        public string concurrencyStamp { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool lockoutEnabled { get; set; }
        public DateTimeOffset? lockoutEnd { get; set; }
        public string normalizedEmail { get; set; }
        public string normalizedUserName { get; set; }
        public string passwordHash { get; set; }
        public string phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public string securityStamp { get; set; }
        public string surName { get; set; }
        public bool twoFactorEnabled { get; set; }
        public string userName { get; set; }

        public ICollection<AgreementAddRH> AgreementAddRH { get; set; }
        public ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ICollection<BrRegister> BrRegister { get; set; }
        public ICollection<Employee> Employee { get; set; }
        public ICollection<Fixation> Fixation { get; set; }
        public ICollection<Register> Register { get; set; }
        public ICollection<Request> Request { get; set; }
        public ICollection<userRole> userRole { get; set; }
    }
}
