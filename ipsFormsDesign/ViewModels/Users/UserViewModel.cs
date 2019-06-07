using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.ViewModels.Users
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public string FIO
        {
            get
            {
                var initials = FirstName[0].ToString() + ".";
                initials += string.IsNullOrEmpty(SurName) ? "" : SurName[0].ToString() + ".";
                return LastName + " " + initials;
            }
        }
    }
}
