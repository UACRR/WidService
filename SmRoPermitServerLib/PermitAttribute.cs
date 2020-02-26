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
            string auth = context.HttpContext.Request.Headers["Authorization"];
            string loginPasswordEncoded = auth.Split(' ')[1];
            var encoding = Encoding.GetEncoding("iso-8859-1");
            string[] loginPassword = encoding.GetString(Convert.FromBase64String(loginPasswordEncoded)).Split(':');
            if (!AllPermissions.HasPermit(loginPassword[0], loginPassword[1], _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}
