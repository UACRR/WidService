using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace ipsmedserviceapp.Controllers
{
    public class baseDictionaryEng
    {
        public Func<Task<object>> getList;
        public Func<JObject, object> toObject;
        public Func<int, Task<object>> getObjectById;
        public Action<JObject> insertObject;
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
            setEng();
        }

        private void setEng()
        {
            baseEng = new Dictionary<string, baseDictionaryEng>();


            baseEng.Add("category", new baseDictionaryEng
            {
                getList = async () => await _dbContext.Category.Include(rec => rec.CategoryTr).AsNoTracking().ToListAsync(),
                toObject = obj => obj.ToObject<Category>(),
                getObjectById = async id => await _dbContext.Category.Where(rec => rec.CategoryCode == Convert.ToInt32(id)).Include(rec => rec.CategoryTr).SingleOrDefaultAsync(),
                insertObject = newItem => { var addItem = newItem.ToObject<Category>(); _dbContext.Category.Add(addItem); }
            }
        );
        }

        [HttpGet("base/{dictionay}")]
        public async Task<ActionResult> GetBaseDictionaryList(string dictionay)
        {
            string normalizeName = dictionay.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            object list = null;
            baseDictionaryEng eng = baseEng[dictionay.ToLower()];
            list = await eng.getList();

            return Json(list);
        }

        [HttpGet("base/{dictionary}/{id}")]
        public async Task<ActionResult> GetBaseDictionaryById(string dictionary, int id)
        {

            string normalizeName = dictionary.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            baseDictionaryEng eng = baseEng[normalizeName];
            object obj = null;
            obj = await eng.getObjectById( id );

            return Json(obj);
        }

        [HttpPost("base/{dictionay}")]
        public async Task<ActionResult> NewBaseItem(string dictionary, JObject data)
        {
            string normalizeName = dictionary.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            baseDictionaryEng eng = baseEng[normalizeName];
            eng.insertObject(data);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }
    }
}