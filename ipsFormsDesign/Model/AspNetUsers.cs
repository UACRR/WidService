using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AspNetUsers : IAspNetUsers
    {
        public AspNetUsers()
        {
            AgreementAddRH = new ObservableListSource<AgreementAddRH>();
            AspNetUserClaims = new ObservableListSource<AspNetUserClaims>();
            AspNetUserLogins = new ObservableListSource<AspNetUserLogins>();
            AspNetUserRoles = new ObservableListSource<AspNetUserRoles>();
            BrRegister = new ObservableListSource<BrRegister>();
            Employee = new ObservableListSource<Employee>();
            Fixation = new ObservableListSource<Fixation>();
            Register = new ObservableListSource<Register>();
            Request = new ObservableListSource<Request>();
            userRole = new ObservableListSource<userRole>();
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

        public ObservableListSource<AgreementAddRH> AgreementAddRH { get; set; }
        public ObservableListSource<AspNetUserClaims> AspNetUserClaims { get; set; }
        public ObservableListSource<AspNetUserLogins> AspNetUserLogins { get; set; }
        public ObservableListSource<AspNetUserRoles> AspNetUserRoles { get; set; }
        public ObservableListSource<BrRegister> BrRegister { get; set; }
        public ObservableListSource<Employee> Employee { get; set; }
        public ObservableListSource<Fixation> Fixation { get; set; }
        public ObservableListSource<Register> Register { get; set; }
        public ObservableListSource<Request> Request { get; set; }
        public ObservableListSource<userRole> userRole { get; set; }
    }
}

