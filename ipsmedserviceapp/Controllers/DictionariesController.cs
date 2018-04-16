using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ipsmedserviceapp.Controllers;
using System.Linq.Expressions;

namespace ipsmedserviceapp.Controllers
{
    public interface ITypedDict
    {
        Type dicType { get; }
    }
    public class BaseDictionaryEng<T,TBase> where T : class where TBase : class
    {
        private MediaServiceContext _dbContext;
        private Func<T, string, bool> _compareId;
        private Expression<Func<T, object>>[] _includes;


        public BaseDictionaryEng(
            MediaServiceContext dbContext,
            Func<T, string, bool> compareId,
            params Expression<Func<T, object>>[] includes
            )
        {
            _dbContext = dbContext;
            _compareId = compareId;
            _includes = includes;
        }

        public Type dicType { get; } = typeof(T);
        public Type dicBaseType { get; } = typeof(TBase);
        private IQueryable<T> addInclude(IQueryable<T> set)
        {
            if (_includes.Any())
            {
                foreach (var item in _includes)
                    set = set.Include(item);

            }

            return set;
        }

        public async Task<List<T>> GetList()
        {

            IQueryable<T> set = _dbContext.Set<T>();
            set = addInclude(set);
            return await set.ToListAsync();
        }

        public async Task<T> GetById( string id )
        {

            IQueryable<T> set = _dbContext.Set<T>().Where( r => _compareId(r, id) );
            set = addInclude(set);

            return await set.SingleOrDefaultAsync();
        }

    }



    [Produces("application/json")]
    [Route("api/dictionary")]
    public class DictionariesController : Controller
    {

        private MediaServiceContext _dbContext;
        private Dictionary<string, object> baseEng;
        public DictionariesController(MediaServiceContext context)
        {
            _dbContext = context;
            SetEng();
        }

        //MediaServiceContext dbContext,
        //Func<T, string, bool> compareId,
        //params Expression<Func<T, object>>[] includes

        private void SetEng()
        {
            baseEng = new Dictionary<string, object>();
            baseEng.Add("activitytype".ToLower(), 
                new BaseDictionaryEng<ActivityType, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id), rec => rec.ActivityTypeTr)
            );
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetDictrionaryList()
        {
            var list = await _dbContext.DictCategory.Include(rec => rec.DicCategoryItems).AsNoTracking().ToListAsync();
            var listOut = list.Where(rec => rec.DicCategoryItems.Count > 0).ToList();
            return Json(listOut);
        }

        [HttpGet("base/{dictionay}")]
        public async Task<ActionResult> GetBaseDictionaryList(string dictionay)
        {
            string normalizeName = dictionay.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            dynamic eng = baseEng[dictionay.ToLower()];
            var list = await eng.GetList();

            return Json(list);
        }

        [HttpGet("base/{dictionary}/{id}")]
        public async Task<ActionResult> GetBaseDictionaryById(string dictionary, string id)
        {

            string normalizeName = dictionary.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            dynamic eng = baseEng[normalizeName];
            var obj = await eng.GetById(id);
            return Json(obj);
        }

        //[HttpPost("base/{dictionay}")]
        //public async Task<ActionResult> NewBaseItem(string dictionary, JObject data)
        //{
        //    string normalizeName = dictionary.ToLower();

        //    if (!baseEng.Keys.Contains(normalizeName))
        //        return BadRequest();

        //    //BaseDictionaryEng eng = baseEng[normalizeName];
        //    //eng.insertObject(data);

        //    //await _dbContext.SaveChangesAsync();

        //    return Ok();

        //}

        //[HttpPut("base/{dictionay}/{id}")]
        //public async Task<ActionResult> UpdateBaseItem(string dictionary, string id, JObject data)
        //{
        //    string normalizeName = dictionary.ToLower();

        //    if (!baseEng.Keys.Contains(normalizeName))
        //        return BadRequest();

        //    //BaseDictionaryEng eng = baseEng[normalizeName];
        //    //var dest = eng.getObjectById(id);
        //    //var sors = eng.toObject(data);



        //    await _dbContext.SaveChangesAsync();

        //    return Ok();

        //}
    }
}