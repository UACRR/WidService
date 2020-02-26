using System;
using System.Collections.Generic;
using System.Linq;
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

        // PUT: api/Login/Admin
        [HttpPut("{login}", Name = "Login")]
        public RspLogin Login([FromBody] RqLogin rq)
        {
            return RunProtectedOperation<RspLogin>( rsp =>
            {
                var res = PermitAdminOperations.Login(rq.UserLogin, rq.UserPassword);
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
                var res = PermitAdminOperations.ChangePasswordAndLogin(rq.UserLogin, rq.NewPassword);
                rsp.UserCodeI = res.UserCodeI;
                rsp.Result = res.Result;
            });
        }
    }
}
