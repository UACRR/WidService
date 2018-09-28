using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ipsmedserviceapp.DATA
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(48)]
        public override string Id { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string SurName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
    }

}
