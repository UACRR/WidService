using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Text;

using System.Net;
using ipsmedserviceapp.DATA;
using ipsmedserviceapp.Model;
using ipsmedserviceapp.Services;
using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Auth;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        readonly MediaServiceContext _dbContext;
        readonly ApplicationDbContext _appDbContext;
        readonly UserManager<ApplicationUser> _userManager;
        readonly RoleManager<ApplicationRole> _roleManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly EmailService _emailService;

        public AuthController(
            ApplicationDbContext dbContext,
            MediaServiceContext mediaServiceContext,
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            RoleManager<ApplicationRole> roleManager,
            EmailService emailService)
        {
            this._appDbContext = dbContext;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._signInManager = signInManager;
            this._emailService = emailService;
            this._dbContext = mediaServiceContext;
        }

        [HttpGet()]
        public IActionResult TestAuth()
        {
            return Ok("Ok auth");
        }

        [HttpPost("tokenauth")]
        public async Task<IActionResult> GetAuthToken([FromBody]User user)
        {
            try
            {
                var curUser = await this._userManager.FindByNameAsync(user.userName);
                if (curUser == null)
                    return BadRequest(LoginResultResource.UserNamePasswordInvalid);

                var loginResult = await this._signInManager.PasswordSignInAsync(curUser, user.password, false, false);

                if (!loginResult.Succeeded)
                    return BadRequest(LoginResultResource.UserNamePasswordInvalid);

                if (!await _userManager.IsEmailConfirmedAsync(curUser))
                    return BadRequest(LoginResultResource.EmailNotConfirmed);

                curUser = await this._userManager.FindByIdAsync( curUser.Id );
                var roles = await _userManager.GetRolesAsync(curUser);
                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;

                var result = LoginResultResource.Succeess;
                result.Token = GenerateJwtToken(curUser.Email, curUser, roles);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("resendconfirm")]
        public async Task<IActionResult> ResendConfirmationEmail([FromForm] string email)
        {
            if (email == null)
                return BadRequest("Email can not be null.");

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return BadRequest();

            var confirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await _emailService.SendActivationEmailAsync(user, WebUtility.UrlEncode(confirmToken));

            return Ok();
        }

        [HttpPut("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailResource confirm)
        {
            if (confirm == null || confirm.UserId == null || confirm.Token == null)
                return BadRequest();

            var user = await _userManager.FindByIdAsync(confirm.UserId);

            if (user == null)
                return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, confirm.Token);

            if (!result.Succeeded)
                return BadRequest();

            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Registration model)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = model.email,
                PhoneNumber = model.phone,
                Email = model.email
            };


            var existsCust = await _userManager.FindByEmailAsync(model.email);
            if (existsCust != null)
                return BadRequest(RegisterResultResource.EmailExist);


            var result = await _userManager.CreateAsync(user, model.password);

            if (result.Succeeded)
            {

                try
                {

                    //Customer cust = new Customer { CustType = 2, AnkVersion = 1, LoginId = user.Id };
                    //cust.Client = new Client();
                    //cust.Person = new Person { Version = 1 };
                    //AnketaPerson newAnk = new AnketaPerson {
                    //                EMail = model.email,
                    //                FirstName = model.name,
                    //                LastName = model.lastname,
                    //                PhoneMobileMain = model.phone,
                    //                Version = 1 };

                    //cust.AnketaPerson.Add(newAnk);

                    //await _dbContext.Customer.AddAsync(cust);
                    //await _dbContext.SaveChangesAsync();

                    var confirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _emailService.SendActivationEmailAsync(user, WebUtility.UrlEncode(confirmToken));
                }
                catch(Exception e)
                {
                   
                    await _signInManager.SignOutAsync();
                    await _userManager.DeleteAsync(user);
                    return BadRequest(e.InnerException.Message);
                }

                return Ok();
            }
            else 
            {
                StringBuilder sb = new StringBuilder();
                bool firstStr = true;
                if (result.Errors.Count() > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        sb.AppendFormat(firstStr == true ? "{0}" : "\n{0}", error.Description);
                        firstStr = false;

                    }
                }
                else
                    sb.Append("Username is invalid");

                return BadRequest(sb.ToString());
            }

        }

        [HttpPost("reset")]
        public async Task<IActionResult> Reset([FromBody]User user)
        {

            try
            {

                var curUser = await _userManager.FindByNameAsync(user.userName);
                if (curUser == null)
                    return Json(new RequestResult
                    {
                        State = RequestState.Failed,
                        Msg = "Username is invalid"
                    });


                curUser.PasswordHash = _userManager.PasswordHasher.HashPassword(curUser, user.password);
                var res = await _userManager.UpdateAsync(curUser);

                var loginResult = await this._signInManager.PasswordSignInAsync(curUser, user.password, false, false);

                curUser = await _userManager.FindByEmailAsync(curUser.Email);
                var roles = await _userManager.GetRolesAsync(curUser);
                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;

                return Json(new { token = GenerateJwtToken(curUser.Email, curUser, roles) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet("test")]
        public IActionResult GetTestString()
        {
            return Json("Test");
        }


        private string GenerateJwtToken(string email, IdentityUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            if (roles != null)
            {
                var roleClaims = from climRole in roles select new Claim("Role", climRole);
                claims.AddRange(roleClaims);
            }

            var now = DateTime.UtcNow;
            var key = TokenAuthOption.Key;
            var creds = TokenAuthOption.SigningCredentials;
            var expires = now.Add(TokenAuthOption.ExpiresSpan);

            var token = new JwtSecurityToken(
                TokenAuthOption.Issuer,
                TokenAuthOption.Audience,
                claims,
                notBefore: now,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        new public class User
        {
            public string userName { get; set; }
            public string eMail { get; set; }
            public string password { get; set; }
        }


        public class Registration
        {
            public string email { get; set; }
            public string password { get; set; }
            public string lastname { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
        }
    }
}
