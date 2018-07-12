using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Register")]
    public class RegisterController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public RegisterController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// ведомость
        /// </summary>
        /// <returns></returns>
        //[HttpGet("view/list_0401")]
        public async Task<IActionResult> GetList()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_R_04", null);
            return Json(list);
        }

        /// <summary>
        /// ведомость акц
        /// </summary>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> GetListByFilter()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_R_04", null);
            return Json(list);
        }

        /// <summary>
        /// Ведомость история
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_0403")]
        public async Task<IActionResult> vtsk_3_R_06()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_R_06", null);
            return Json(list);
        }
    }
}