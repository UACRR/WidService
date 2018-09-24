using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AspNetUsers : IAspNetUsers
    {
        public AspNetUsers()
        {
            AgreementAddRh = new ObservableListSource<AgreementAddRh>();
            AspNetUserClaims = new ObservableListSource<AspNetUserClaims>();
            AspNetUserLogins = new ObservableListSource<AspNetUserLogins>();
            AspNetUserRoles = new ObservableListSource<AspNetUserRoles>();
            BrRegister = new ObservableListSource<BrRegister>();
            Employee = new ObservableListSource<Employee>();
            Fixation = new ObservableListSource<Fixation>();
            Register = new ObservableListSource<Register>();
            Request = new ObservableListSource<Request>();
            UserRole = new ObservableListSource<UserRole>();
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

        public ObservableListSource<AgreementAddRh> AgreementAddRh { get; set; }
        public ObservableListSource<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ObservableListSource<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ObservableListSource<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ObservableListSource<BrRegister> BrRegister { get; set; }
        public ObservableListSource<Employee> Employee { get; set; }
        public ObservableListSource<Fixation> Fixation { get; set; }
        public ObservableListSource<Register> Register { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<UserRole> UserRole { get; set; }
    }
}

