using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmRoPermitCommonLib;
using SmRoPermitServerLib;

namespace SmartRoyaltyPermitApi.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class PermitController : ControllerBase
    {
        private delegate void ProtectedOperation<ResponseT>(ResponseT rsp);
        private ResponseT RunProtectedOperation<ResponseT>(ProtectedOperation<ResponseT> oper) where ResponseT : Response, new()
        {
            ResponseT rsp = new ResponseT();
            try
            {
                string auth = Request.Headers["Authorization"];
                string loginPassword = auth.Split(' ')[1];
                var encoding = Encoding.GetEncoding("iso-8859-1");
                var qqq = encoding.GetString(Convert.FromBase64String(loginPassword));

                oper(rsp);
                return rsp;
            }
            catch (LoginNotUniqueException ex)
            {
                rsp.Code = -2;
                rsp.Message = ex.Message;
                return rsp;
            }
            catch (Exception ex)
            {
                rsp.Code = -1;
                rsp.Message = ex.Message;
                return rsp;
            }

        }

        // GET: api/Permit/Users
        [HttpGet("Users", Name = "GetAllUsers")]
        [Permit("UserAdmin", "Read")]
        public RspGetAllUsers GetAllUsers()
        {
            return RunProtectedOperation<RspGetAllUsers>(rsp =>
            {
                rsp.Result = PermitAdminOperations.GetAllUsers();
            });
        }

        // GET: api/Permit/Users
        [HttpGet("UserRoles/{codeI}", Name = "GetUserRoles")]
        [Permit("UserAdmin", "Read")]
        public RspGetUserRoles GetUserRoles(int codeI)
        {
            return RunProtectedOperation<RspGetUserRoles>(rsp =>
            {
                rsp.Result = PermitAdminOperations.GetUserRoles(codeI);
            });
        }

        // Post: api/Permit/User/CodeI
        [HttpPost("User/{codeI}", Name = "SaveUser")]
        [Permit("UserAdmin", "Write")]
        public Response SaveUser(RqSaveUser rq)
        {
            return RunProtectedOperation<Response>(rsp =>
            {
                PermitAdminOperations.SaveUser(rq.User, rq.Roles);
            });
        }

        // Post: api/Permit/User
        [HttpPut("User", Name = "AddUser")]
        [Permit("UserAdmin", "Write")]
        public Response AddUser(RqAddUser rq)
        {
            return RunProtectedOperation<RspAddUser>(rsp =>
            {
                rsp.Result = PermitAdminOperations.AddUser(rq.User, rq.Roles);
            });
        }

        // Delete: api/Permit/User/{CodeI}
        [HttpDelete("User/{codeI}", Name = "DeleteUser")]
        [Permit("UserAdmin", "Write")]
        public Response DeleteUser(int codeI)
        {
            return RunProtectedOperation<RspAddUser>(rsp =>
            {
                PermitAdminOperations.DeleteUser(codeI);
            });
        }

        // Post: api/Permit/User/CodeI
        [HttpPost("User/{codeI}/ResetPassword", Name = "ResetPassword")]
        [Permit("UserAdmin", "Write")]
        public RspResetPassword ResetPassword(int codeI)
        {
            return RunProtectedOperation<RspResetPassword>(rsp =>
            {
                rsp.NewPassword = PermitAdminOperations.ResetPassword(codeI);
            });
        }

        // GET: api/User/{codeI}/Permissions
        [HttpGet("User/{codeI}/Permissions", Name = "GetUserPermissions")]
        public RspGetUserPermissions GetUserPermissions(int codeI)
        {
            return RunProtectedOperation<RspGetUserPermissions>(rsp =>
            {
                rsp.UserParmissions = PermitAdminOperations.GetUserPermissions(codeI);
            });
        }
    }
}
