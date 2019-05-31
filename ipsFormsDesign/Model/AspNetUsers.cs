using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class AspNetUsers : IAspNetUsers
    {
        public AspNetUsers()
        {
            AspNetUserClaims = new ObservableListSource<AspNetUserClaims>();
            AspNetUserLogins = new ObservableListSource<AspNetUserLogins>();
            AspNetUserRoles = new ObservableListSource<AspNetUserRoles>();
            Customer = new ObservableListSource<Customer>();
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

        public virtual ObservableListSource<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual ObservableListSource<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual ObservableListSource<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual ObservableListSource<Customer> Customer { get; set; }
    }
}

