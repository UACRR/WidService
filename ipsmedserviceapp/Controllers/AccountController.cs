using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetGroups()
        {
            try
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
            catch( Exception ex )
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [Authorize]
        [HttpGet("toch")]
        public IActionResult Toch()
        {
            var wi = (WindowsIdentity)User.Identity;
            if (wi == null)
                return BadRequest();

            var myPrincipal = new WindowsPrincipal(wi);
            return Json(myPrincipal.UserClaims.Select(rec => rec.Value).ToArray());

            //System.Security.Principal.WindowsIdentity wi = WindowsIdentity.GetCurrent();
            //string[] a = User.Identity.Name.Split('\\');


            //System.DirectoryServices.DirectoryEntry ADEntry = new System.DirectoryServices.DirectoryEntry("WinNT://" + a[0] + "/" + a[1]);
            //string Name = ADEntry.Properties["FullName"].Value.ToString();


            //return Json(Name);
        }

    }

}