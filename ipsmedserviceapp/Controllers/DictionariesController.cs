using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Dictionary")]
    public class DictionariesController : Controller
    {
        private MediaServiceContext _dbContext;
        public DictionariesController(MediaServiceContext context)
        {
            _dbContext = context;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> Category()
        {
            var list = await _dbContext.Category
                     .Include( rec => rec.CategoryTr)
                .AsNoTracking().ToListAsync();
            return Json(list);
        }
    }
}