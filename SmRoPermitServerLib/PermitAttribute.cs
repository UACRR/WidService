using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmRoPermitServerLib
{
    public class PermitAttribute : TypeFilterAttribute
    {
        public PermitAttribute(string claimType, string claimValue) : base(typeof(PermitFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }

    public class PermitFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public PermitFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string login;
            string password;
            if (context.HttpContext.User.Identity.IsAuthenticated) // Windows Authentication
            {
                string auth = context.HttpContext.Request.Headers["Basic"];
                if (auth == null)
                {
                    login = context.HttpContext.User.Identity.Name;
                    password = "";
                }
                else
                {
                    var encoding = Encoding.GetEncoding("iso-8859-1");
                    string[] loginPassword = encoding.GetString(Convert.FromBase64String(auth)).Split(':');
                    login = loginPassword[0];
                    password = loginPassword[1];
                }
            }
            else // Basic Authentication
            {
                string auth = context.HttpContext.Request.Headers["Authorization"];
                if (auth == null)
                {
                    login = "";
                    password = "";
                    return;
                }
                string loginPasswordEncoded = auth.Split(' ')[1];
                var encoding = Encoding.GetEncoding("iso-8859-1");
                string[] loginPassword = encoding.GetString(Convert.FromBase64String(loginPasswordEncoded)).Split(':');
                login = loginPassword[0];
                password = loginPassword[1];
            }
            if (!AllPermissions.HasPermit(login, password, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}
