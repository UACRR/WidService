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
    class baseDictionaryEng
    {
        public Func<Task<object>> getLis;
        public Func<object, object> toObject;
        public Func<object, Task<object>> getObjectById;

    }

    [Produces("application/json")]
    [Route("api/dictionary")]
    public class DictionariesController : Controller
    {
        private MediaServiceContext _dbContext;
        private Dictionary<string, baseDictionaryEng> baseEng;
        public DictionariesController(MediaServiceContext context)
        {
            _dbContext = context;
        }

        private void setEng()
        {
            baseEng = new Dictionary<string, baseDictionaryEng>();
            baseEng.Add( "category", new {
                () => { return await _dbContext.Category.Include(rec => rec.CategoryTr).AsNoTracking().ToListAsync(); },
                str => 
        });
        }

        [HttpGet("base/{dictionay}")]
        public async Task<ActionResult> GetBaseDictionary(string dictionary)
        {
            object list = null;
            Func<Task<object>> prc = async () =>
            {
                return await _dbContext.Category.Include(rec => rec.CategoryTr).AsNoTracking().ToListAsync();
            };


            list = await prc();

            return Json(list);
        }
        //[HttpPost("base/{dictionay}")]
        //public async Task<ActionResult> CreateBaseDictionary(string dictionary, object data )
        //{
        //    var entity = _dbContext.Category;
        //    switch (dictionary)
        //    {
        //        case "category":
        //    }


        //}
    }
}