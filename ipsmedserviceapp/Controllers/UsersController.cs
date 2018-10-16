using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public UsersController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            if (userId == null)
                BadRequest("UserId can not be null.");

            var user = (await GetUsers(userId: userId)).FirstOrDefault();

            if (user == null)
                NotFound($"User with id '{userId}' not found.");
            
            return Ok(user);
        }

        [HttpGet("byroles/fixation")]
        public async Task<IActionResult> GetUsersWithRoleFixation()
        {
            var list = await GetUsers(normalizedRoleName: "ФІКСАЦІЯ ПОРУШЕНЬ");
            return Ok(list);
        }

        private async Task<List<Dictionary<string, object>>> GetUsers(string normalizedRoleName = null, string userId = null)
        {
            return await _dbContext.getViewData($"select * from ft_Tsk_7_Users(@normalizedRoleName, @userId)", new[] {
                new SqlParameter("normalizedRoleName", normalizedRoleName),
                new SqlParameter("userId", userId),
            });
        }
    }
}