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
    public interface TypedDict
    {
        Type dicType;
    }
    public class BaseDictionaryEng<T>
    {
        public Type dicType;
        public Func<List<T>> getList;
        public Func<JObject, object> toObject;
        public Func<string, Task<object>> getObjectById;
        public Action<JObject> insertObject;
        public Action<object, object> updateObject;
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


        private List<TEntity> getList<TEntity>(params Expression<Func<TEntity, object>>[] children)  where TEntity : class
        {
            DbSet<TEntity> dbSet = _dbContext.Set<TEntity>();
            children.ToList().ForEach(x => dbSet.Include(x).Load());

            return dbSet.ToList();

        }

        private void SetEng()
        {
            baseEng = new Dictionary<string, object>();


            baseEng.Add("category", new BaseDictionaryEng<Category>
            {
                dicType = typeof(Category),
                getList = () => getList<Category>(r=>r.CategoryTr),
                toObject = obj => (Category)obj.ToObject<DictBaseTypeI>(),
                getObjectById = async id => await _dbContext.Category.Where(rec => rec.CategoryCode == Convert.ToInt32(id)).Include(rec => rec.CategoryTr).SingleOrDefaultAsync(),
                insertObject = newItem => { var addItem = newItem.ToObject<DictBaseTypeI>(); _dbContext.Category.Add((Category)addItem); },
                updateObject = ( sors, dest) => {
                    Category left = (Category)dest, right = (Category)sors;
                    left.SetFields(right);
                    List<CategoryTr> tempItems = left.CategoryTr.Where( rec => !right.CategoryTr.Any( item => item.CategoryCode == rec.CategoryCode && item.Lang == rec.Lang )).ToList();
                    tempItems.ForEach( item => left.CategoryTr.Remove(item));

                    tempItems = right.CategoryTr.Where(rec => !left.CategoryTr.Any(item => item.CategoryCode == rec.CategoryCode)).ToList();
                    tempItems.ForEach( rec => { left.CategoryTr.Add(rec); right.CategoryTr.Remove(rec); });
                    right.CategoryTr.ToList().ForEach(rec => left.CategoryTr.First(item => item.CategoryCode == rec.CategoryCode && rec.Lang == item.Lang).CategoryName = rec.CategoryName);
                } 
            }
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

            object list = null;
            object eng = baseEng[dictionay.ToLower()];
            list = await eng.getList();

            return Json(list);
        }

        [HttpGet("base/{dictionary}/{id}")]
        public async Task<ActionResult> GetBaseDictionaryById(string dictionary, string id)
        {

            string normalizeName = dictionary.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            BaseDictionaryEng eng = baseEng[normalizeName];
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

            BaseDictionaryEng eng = baseEng[normalizeName];
            eng.insertObject(data);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        [HttpPut("base/{dictionay}/{id}")]
        public async Task<ActionResult> UpdateBaseItem(string dictionary, string id, JObject data)
        {
            string normalizeName = dictionary.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            BaseDictionaryEng eng = baseEng[normalizeName];
            var dest = eng.getObjectById(id);
            var sors = eng.toObject(data);



            await _dbContext.SaveChangesAsync();

            return Ok();

        }
    }
}