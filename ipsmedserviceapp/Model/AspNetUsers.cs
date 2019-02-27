using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AspNetUsers
    {
        public AspNetUsers()
        {
            AgreementAddRh = new HashSet<AgreementAddRh>();
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            BrRegister = new HashSet<BrRegister>();
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
            Fixation = new HashSet<Fixation>();
            Register = new HashSet<Register>();
            Request = new HashSet<Request>();
            UserRole = new HashSet<UserRole>();
        }

        public string Id { get; set; }
        public int AccessFailedCount { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public string SurName { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<AgreementAddRh> AgreementAddRh { get; set; }
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ICollection<BrRegister> BrRegister { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Fixation> Fixation { get; set; }
        public virtual ICollection<Register> Register { get; set; }
        public virtual ICollection<Request> Request { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
