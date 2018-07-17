using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetGroups()
        {
            var wi = (WindowsIdentity)User.Identity;
            if (wi == null)
                return BadRequest();

            var groups = new List<string>();
            await Task.Run(() =>
            {

                foreach (var item in wi.Groups)
                {
                    groups.Add(item.Translate(typeof(NTAccount)).ToString());
                }

                groups.Add(wi.Name);
            });

            return Json(groups.ToArray());
        }

    }
}