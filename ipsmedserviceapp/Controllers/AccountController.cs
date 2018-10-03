using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using ipsmedserviceapp.DATA;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        public string WebSecurity { get; private set; }

        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        RoleManager<ApplicationRole> roleManager
            )
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("userinfo")]
        public IActionResult GetGroups()
        {
            try
            {
                List<string> fullName = new List<string>();

                using (var context = new PrincipalContext(ContextType.Domain))
                {
                    var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
                    fullName.Add($"{principal.Surname} {principal.Name} -- ({User.Identity.Name})");
                    var groups = principal.GetGroups();
                    foreach (var group in groups)
                        fullName.Add(group.Name);
                }

                return Ok(fullName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        public async Task syncFixingGroupByAD()
        {
            List<ApplicationUser> adUsers = new List<ApplicationUser>();

            // Користувачі АД
            using (var context = new PrincipalContext(ContextType.Domain))
            {
                var FixingGroup = GroupPrincipal.FindByIdentity(context, IdentityType.Name, "Фіксація Порушень");
                if (FixingGroup != null)
                {
                    foreach (var princ in FixingGroup.Members)
                        if (princ is UserPrincipal adUser) adUsers.Add(new ApplicationUser {
                            UserName = adUser.SamAccountName,
                            Email = adUser.EmailAddress,
                            FirstName = adUser.Name,
                            LastName = adUser.Surname
                        });
                }

            }

            string roleName = "Фіксація Порушень";
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                ApplicationRole addRole = new ApplicationRole { Name = roleName };
                if ((await _roleManager.CreateAsync(addRole)).Succeeded == false)
                    return;
                role = await _roleManager.FindByNameAsync(roleName);
            }

            // Сінхронізація з AspNetIdentity по новим користувачам
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            var listNewUsers = adUsers.Where(rec => !users.Any(user => user.UserName == rec.UserName));

            foreach (var addUser in listNewUsers)
            {
                var newUser = await _userManager.FindByNameAsync(addUser.UserName);
                if( newUser != null 
                    || (await _userManager.CreateAsync(addUser)).Succeeded )
                {
                    await _userManager.AddToRoleAsync(newUser, role.Name);
                }
            }

            // Видаляем роль по закритим користувачам
            listNewUsers = users.Where(rec => !adUsers.Any(item => item.UserName == rec.UserName));
            foreach (var delUser in listNewUsers)
                await _userManager.RemoveFromRoleAsync(delUser, role.Name);

        }

        [Authorize]
        [HttpGet("toch")]
        public async Task<IActionResult> Toch()
        {

            bool inGroup = true;
            await syncFixingGroupByAD();


            return Ok(inGroup);
        }

    }

}