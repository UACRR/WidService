using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmRoPermitCommonLib;

namespace SmartRoyaltyPermitApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private string login;
        private string password;

        private delegate void ProtectedOperation<ResponseT>(ResponseT rsp);
        private static ResponseT RunProtectedOperation<ResponseT>(ProtectedOperation<ResponseT> oper) where ResponseT : Response, new()
        {
            ResponseT rsp = new ResponseT();
            try
            {
                oper(rsp);
                return rsp;
            }
            catch (Exception ex)
            {
                rsp.Code = -1;
                rsp.Message = ex.Message;
                return rsp;
            }
        }

        private void Authenticate()
        {
            if (User.Identity.IsAuthenticated) // Windows Authentication
            {
                string auth = Request.Headers["Basic"];
                if (auth == null)
                {
                    login = User.Identity.Name;
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
                string auth = Request.Headers["Authorization"];
                if(auth == null)
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
        }
        // GET: api/Login
        [HttpGet]
        public RspLogin Login()
        {
            Authenticate();
            return RunProtectedOperation<RspLogin>(rsp =>
            {

                var res = PermitAdminOperations.Login(login, password);
                rsp.UserCodeI = res.UserCodeI;
                rsp.Result = res.Result;
            });
        }

        // PUT: api/Login/Password/Admin
        [HttpPut("Password/{login}", Name = "ChangePasswordAndLogin")]
        public RspLogin ChangePasswordAndLogin([FromBody] RqChangePasswordAndLogin rq)
        {
            return RunProtectedOperation<RspLogin>(rsp =>
            {
                var res = PermitAdminOperations.ChangePasswordAndLogin(rq.UserLogin, rq.UserPassword, rq.NewPassword);
                rsp.UserCodeI = res.UserCodeI;
                rsp.Result = res.Result;
            });
        }


        [HttpGet("test")]
        public IActionResult TestMethod()
        {
            return Ok("Hello world!");
        }
    }
}
