using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        public string WebSecurity { get; private set; }

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
            catch( Exception ex )
            {
                return BadRequest(ex.InnerException.Message);
            }
        }



        [Authorize]
        [HttpGet("toch")]
        public IActionResult Toch()
        {

            bool inGroup = false;

            using (var context = new PrincipalContext(ContextType.Domain))
            {
                var FixingGroup = GroupPrincipal.FindByIdentity(context, IdentityType.Name, "Фіксація Порушень");
                if(FixingGroup != null)
                {
                    var principal = UserPrincipal.FindByIdentity(context, User.Identity.Name);
                    inGroup = principal.IsMemberOf(FixingGroup);

                }

            }

            return Ok(inGroup);
        }

    }

}