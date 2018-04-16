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
    public class BaseDictionaryEng<T,TTr, TBase> where T : class where TBase : class
    {
        private MediaServiceContext _dbContext;
        private Func<T, string, bool> _compareId;
        private Expression<Func<T, object>> _includes;
        public Func<T, TBase> ConvertToBase;
        public Func<TBase, T> ConvertFromBase;
        public Func<T, IList<TTr>> GetTr;
        public Func<object, object, bool> CompareTr;


        public BaseDictionaryEng(
            MediaServiceContext dbContext,
            Func<T, string, bool> compareId,
            Func<T, TBase> convertToBase,
            Func<TBase, T> convertFromBase,
            Func<T, IList<TTr>> getTr,
            Func<object, object, bool> compareTr,
        Expression<Func<T, object>> includes
            )
        {
            _dbContext = dbContext;
            _compareId = compareId;
            _includes = includes;
            ConvertToBase = convertToBase;
            GetTr = getTr;
            CompareTr = compareTr;
            ConvertFromBase = convertFromBase;
        }

        public Type dicType { get; } = typeof(T);
        public Type dicTrType { get; } = typeof(TTr);
        public Type dicBaseType { get; } = typeof(TBase);
        public DbSet<T> entity()
        {
            return _dbContext.Set<T>();
        }

        public TBase ToObject(JObject data )
        {
            return data.ToObject<TBase>();
        }

        private IQueryable<T> addInclude(IQueryable<T> set)
        {
            if (_includes != null)
            {
                set = set.Include(_includes);

            }

            return set;
        }

        public async Task<List<TBase>> GetList()
        {

            IQueryable<T> set = _dbContext.Set<T>();
            set = addInclude(set);
            var list = await set.ToListAsync();
            return list.Select( rec => ConvertToBase(rec)).ToList();
        }

        public async Task<T> GetById( string id )
        {

            IQueryable<T> set = _dbContext.Set<T>().Where( r => _compareId(r, id) );
            set = addInclude(set);
            var item = await set.SingleOrDefaultAsync();
            return item;
        }

        public void DeleteAbsent(List<TTr> dest, List<TTr> sors)
        {
            var listTemp = dest.Where(rec => !sors.Any(item => CompareTr(rec, item))).ToList();
            listTemp.ForEach(item => dest.Remove(item));
        }
        public void InserNew(List<TTr> dest, List<TTr> sors)
        {
            var listTemp = sors.Where(rec => !dest.Any(item => CompareTr(rec, item))).ToList();
            listTemp.ForEach(item => { dest.Add(item); sors.Remove(item); });
        }
        public void Update(List<TTr> dest, List<TTr> sors)
        {
            var listTemp = sors.ToList();
            listTemp.ForEach(item => { dest.First(destItem => CompareTr(item, destItem)).SetFields(item); });
        }
        public void runActionByTr( T rec, Action<object> exec )
        {
            var listTr = GetTr(rec);
            foreach (var item in listTr)
                exec(item);
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
                new BaseDictionaryEng<ActivityType, ActivityTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                sors => (DictBaseTypeI)sors, sors => (ActivityType)sors, 
                sors => sors.ActivityTypeTr.ToList(),
                (sors, dest) => ((ActivityTypeTr)sors).CodeI == ((ActivityTypeTr)dest).CodeI && ((ActivityTypeTr)sors).Lang == ((ActivityTypeTr)dest).Lang,
                rec => rec.ActivityTypeTr)
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

            return Json(eng.ConvertToBase(obj));
        }


        [HttpDelete("base/{dictionary}/{id}")]
        public async Task<ActionResult> DeleteBaseDictionaryById(string dictionary, string id)
        {

            string normalizeName = dictionary.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            dynamic eng = baseEng[normalizeName];
            var obj = await eng.GetById(id);
            Action<object> delAct = item => _dbContext.Entry(item).State = EntityState.Deleted;
            eng.runActionByTr(obj, delAct ); 
            _dbContext.Entry(obj).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();

            return Json(eng.ConvertToBase(obj));
        }


        [HttpPost("base/{dictionary}")]
        public async Task<ActionResult> NewBaseItem(string dictionary, [FromBody]JObject data)
        {
            string normalizeName = dictionary.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            dynamic eng = baseEng[normalizeName];
            // BaseDictionaryEng<ActivityType, DictBaseTypeI> eng = (BaseDictionaryEng<ActivityType, DictBaseTypeI>)baseEng[normalizeName];
            var entity = eng.entity();
            var newItem = eng.ConvertFromBase( eng.ToObject(data) );
            
            entity.Add(newItem);
            //eng.insertObject(data);

            await _dbContext.SaveChangesAsync();

            return Json(eng.ConvertToBase( newItem ));

        }

        [HttpPut("base/{dictionay}/{id}")]
        public async Task<ActionResult> UpdateBaseItem(string dictionay, string id, [FromBody]JObject data)
        {
            string normalizeName = dictionay.ToLower();

            if (!baseEng.Keys.Contains(normalizeName))
                return BadRequest();

            // BaseDictionaryEng<ActivityType, ActivityTypeTr, DictBaseTypeI> eng = (BaseDictionaryEng<ActivityType, ActivityTypeTr, DictBaseTypeI>)baseEng[normalizeName];
            dynamic eng = baseEng[normalizeName];
            var dest = await eng.GetById(id);
            var sors = eng.ConvertFromBase( eng.ToObject(data) );

            ((object)dest).SetFields((object)sors);
            Type trType = (Type) eng.dicTrType;

            var listDst = eng.GetTr(dest);
            var listSrs = eng.GetTr(sors);

            eng.DeleteAbsent(listDst, listSrs);
            eng.InserNew(listDst, listSrs);
            eng.Update(listDst, listSrs);


            await _dbContext.SaveChangesAsync();

            return Ok();

        }
    }
}