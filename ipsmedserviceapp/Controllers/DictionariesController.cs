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
    public class BaseDictionaryEng<T, TTr, TBase> where T : class where TBase : class
    {
        private MediaServiceContext _dbContext;
        private Func<T, string, bool> _compareId;
        private Expression<Func<T, object>>[] _includes;
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
            params Expression<Func<T, object>>[] includes
            )
        {
            _dbContext = dbContext;
            _compareId = compareId;
            _includes = includes ?? throw new ArgumentNullException(nameof(includes));
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

        public TBase ToObject(JObject data)
        {
            return data.ToObject<TBase>();
        }

        private IQueryable<T> addInclude(IQueryable<T> set)
        {
            if (_includes != null)
            {
                foreach (var item in _includes)
                    set = set.Include(item);

            }

            return set;
        }

        public async Task<List<TBase>> GetList()
        {

            IQueryable<T> set = _dbContext.Set<T>();
            set = addInclude(set);
            var list = await set.ToListAsync();
            return list.Select(rec => ConvertToBase(rec)).ToList();
        }

        public async Task<T> GetById(string id)
        {

            IQueryable<T> set = _dbContext.Set<T>().Where(r => _compareId(r, id));
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
        public void runActionByTr(T rec, Action<object> exec)
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
            #region Init Dictionary

            baseEng.Add("activitytype".ToLower(),
                            new BaseDictionaryEng<ActivityType, ActivityTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (ActivityType)sors,
                            sors => sors.ActivityTypeTr.ToList(),
                            (sors, dest) => ((ActivityTypeTr)sors).CodeI == ((ActivityTypeTr)dest).CodeI && ((ActivityTypeTr)sors).Lang == ((ActivityTypeTr)dest).Lang,
                            rec => rec.ActivityTypeTr)
                        );
            baseEng.Add("agreementstatus".ToLower(),
                            new BaseDictionaryEng<AgreementStatus, AgreementStatusTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (AgreementStatus)sors,
                            sors => sors.AgreementStatusTr.ToList(),
                            (sors, dest) => ((AgreementStatusTr)sors).CodeI == ((AgreementStatusTr)dest).CodeI && ((AgreementStatusTr)sors).Lang == ((AgreementStatusTr)dest).Lang,
                            rec => rec.AgreementStatusTr)
                        );
            baseEng.Add("agrlicensetype".ToLower(),
                            new BaseDictionaryEng<AgrLicenseType, AgrLicenseTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (AgrLicenseType)sors,
                            sors => sors.AgrLicenseTypeTr.ToList(),
                            (sors, dest) => ((AgrLicenseTypeTr)sors).CodeI == ((AgrLicenseTypeTr)dest).CodeI && ((AgrLicenseTypeTr)sors).Lang == ((AgrLicenseTypeTr)dest).Lang,
                            rec => rec.AgrLicenseTypeTr)
                        );
            baseEng.Add("anketastatus".ToLower(),
                            new BaseDictionaryEng<AnketaStatus, AnketaStatusTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (AnketaStatus)sors,
                            sors => sors.AnketaStatusTr.ToList(),
                            (sors, dest) => ((AnketaStatusTr)sors).CodeI == ((AnketaStatusTr)dest).CodeI && ((AnketaStatusTr)sors).Lang == ((AnketaStatusTr)dest).Lang,
                            rec => rec.AnketaStatusTr)
                        );
            baseEng.Add("categorystatustype".ToLower(),
                            new BaseDictionaryEng<CategoryStatusType, CategoryStatusTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (CategoryStatusType)sors,
                            sors => sors.CategoryStatusTypeTr.ToList(),
                            (sors, dest) => ((CategoryStatusTypeTr)sors).CodeI == ((CategoryStatusTypeTr)dest).CodeI && ((CategoryStatusTypeTr)sors).Lang == ((CategoryStatusTypeTr)dest).Lang,
                            rec => rec.CategoryStatusTypeTr)
                        );
            baseEng.Add("continent".ToLower(),
                            new BaseDictionaryEng<Continent, ContinentTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (Continent)sors,
                            sors => sors.ContinentTr.ToList(),
                            (sors, dest) => ((ContinentTr)sors).CodeI == ((ContinentTr)dest).CodeI && ((ContinentTr)sors).Lang == ((ContinentTr)dest).Lang,
                            rec => rec.ContinentTr)
                        );
            baseEng.Add("copyrightkind".ToLower(),
                            new BaseDictionaryEng<CopyrightKind, CopyrightKindTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (CopyrightKind)sors,
                            sors => sors.CopyrightKindTr.ToList(),
                            (sors, dest) => ((CopyrightKindTr)sors).CodeI == ((CopyrightKindTr)dest).CodeI && ((CopyrightKindTr)sors).Lang == ((CopyrightKindTr)dest).Lang,
                            rec => rec.CopyrightKindTr)
                        );
            baseEng.Add("copyrighttype".ToLower(),
                            new BaseDictionaryEng<CopyrightType, CopyrightTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (CopyrightType)sors,
                            sors => sors.CopyrightTypeTr.ToList(),
                            (sors, dest) => ((CopyrightTypeTr)sors).CodeI == ((CopyrightTypeTr)dest).CodeI && ((CopyrightTypeTr)sors).Lang == ((CopyrightTypeTr)dest).Lang,
                            rec => rec.CopyrightTypeTr)
                        );
            baseEng.Add("creativeroletype".ToLower(),
                            new BaseDictionaryEng<CreativeRoleType, CreativeRoleTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (CreativeRoleType)sors,
                            sors => sors.CreativeRoleTypeTr.ToList(),
                            (sors, dest) => ((CreativeRoleTypeTr)sors).CodeI == ((CreativeRoleTypeTr)dest).CodeI && ((CreativeRoleTypeTr)sors).Lang == ((CreativeRoleTypeTr)dest).Lang,
                            rec => rec.CreativeRoleTypeTr)
                        );
            baseEng.Add("crkindgroup".ToLower(),
                            new BaseDictionaryEng<CrkindGroup, CrkindGroupTr, CrkindGroup>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => sors,
                            sors => (CrkindGroup)sors,
                            sors => sors.CrkindGroupTr.ToList(),
                            (sors, dest) => ((CrkindGroupTr)sors).CodeI == ((CrkindGroupTr)dest).CodeI && ((CrkindGroupTr)sors).Lang == ((CrkindGroupTr)dest).Lang,
                            rec => rec.CrkindGroupTr, rec => rec.CopyrightKind)
                        );
            baseEng.Add("customerstatus".ToLower(),
                            new BaseDictionaryEng<CustomerStatus, CustomerStatusTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (CustomerStatus)sors,
                            sors => sors.CustomerStatusTr.ToList(),
                            (sors, dest) => ((CustomerStatusTr)sors).CodeI == ((CustomerStatusTr)dest).CodeI && ((CustomerStatusTr)sors).Lang == ((CustomerStatusTr)dest).Lang,
                            rec => rec.CustomerStatusTr)
                        );
            baseEng.Add("customertype".ToLower(),
                            new BaseDictionaryEng<CustomerType, CustomerTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (CustomerType)sors,
                            sors => sors.CustomerTypeTr.ToList(),
                            (sors, dest) => ((CustomerTypeTr)sors).CodeI == ((CustomerTypeTr)dest).CodeI && ((CustomerTypeTr)sors).Lang == ((CustomerTypeTr)dest).Lang,
                            rec => rec.CustomerTypeTr)
                        );
            baseEng.Add("documentkind".ToLower(),
                            new BaseDictionaryEng<DocumentKind, DocumentKindTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (DocumentKind)sors,
                            sors => sors.DocumentKindTr.ToList(),
                            (sors, dest) => ((DocumentKindTr)sors).CodeI == ((DocumentKindTr)dest).CodeI && ((DocumentKindTr)sors).Lang == ((DocumentKindTr)dest).Lang,
                            rec => rec.DocumentKindTr)
                        );
            baseEng.Add("genre".ToLower(),
                            new BaseDictionaryEng<Genre, GenreTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.Id == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (Genre)sors,
                            sors => sors.GenreTr.ToList(),
                            (sors, dest) => ((GenreTr)sors).Id == ((GenreTr)dest).Id && ((GenreTr)sors).Lang == ((GenreTr)dest).Lang,
                            rec => rec.GenreTr)
                        );
            baseEng.Add("legalbasis".ToLower(),
                            new BaseDictionaryEng<LegalBasis, LegalBasisTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (LegalBasis)sors,
                            sors => sors.LegalBasisTr.ToList(),
                            (sors, dest) => ((LegalBasisTr)sors).CodeI == ((LegalBasisTr)dest).CodeI && ((LegalBasisTr)sors).Lang == ((LegalBasisTr)dest).Lang,
                            rec => rec.LegalBasisTr)
                        );
            baseEng.Add("licensetype".ToLower(),
                            new BaseDictionaryEng<LicenseType, LicenseTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (LicenseType)sors,
                            sors => sors.LicenseTypeTr.ToList(),
                            (sors, dest) => ((LicenseTypeTr)sors).CodeI == ((LicenseTypeTr)dest).CodeI && ((LicenseTypeTr)sors).Lang == ((LicenseTypeTr)dest).Lang,
                            rec => rec.LicenseTypeTr)
                        );
            baseEng.Add("objectstatus".ToLower(),
                            new BaseDictionaryEng<ObjectStatus, ObjectStatusTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (ObjectStatus)sors,
                            sors => sors.ObjectStatusTr.ToList(),
                            (sors, dest) => ((ObjectStatusTr)sors).CodeI == ((ObjectStatusTr)dest).CodeI && ((ObjectStatusTr)sors).Lang == ((ObjectStatusTr)dest).Lang,
                            rec => rec.ObjectStatusTr)
                        );
            baseEng.Add("objecttype".ToLower(),
                            new BaseDictionaryEng<ObjectType, ObjectTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (ObjectType)sors,
                            sors => sors.ObjectTypeTr.ToList(),
                            (sors, dest) => ((ObjectTypeTr)sors).CodeI == ((ObjectTypeTr)dest).CodeI && ((ObjectTypeTr)sors).Lang == ((ObjectTypeTr)dest).Lang,
                            rec => rec.ObjectTypeTr)
                        );
            baseEng.Add("paymentkind".ToLower(),
                            new BaseDictionaryEng<PaymentKind, PaymentKindTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (PaymentKind)sors,
                            sors => sors.PaymentKindTr.ToList(),
                            (sors, dest) => ((PaymentKindTr)sors).CodeI == ((PaymentKindTr)dest).CodeI && ((PaymentKindTr)sors).Lang == ((PaymentKindTr)dest).Lang,
                            rec => rec.PaymentKindTr)
                        );
            baseEng.Add("paymentstatus".ToLower(),
                            new BaseDictionaryEng<PaymentStatus, PaymentStatusTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (PaymentStatus)sors,
                            sors => sors.PaymentStatusTr.ToList(),
                            (sors, dest) => ((PaymentStatusTr)sors).CodeI == ((PaymentStatusTr)dest).CodeI && ((PaymentStatusTr)sors).Lang == ((PaymentStatusTr)dest).Lang,
                            rec => rec.PaymentStatusTr)
                        );
            baseEng.Add("paymethodtype".ToLower(),
                            new BaseDictionaryEng<PayMethodType, PayMethodTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (PayMethodType)sors,
                            sors => sors.PayMethodTypeTr.ToList(),
                            (sors, dest) => ((PayMethodTypeTr)sors).CodeI == ((PayMethodTypeTr)dest).CodeI && ((PayMethodTypeTr)sors).Lang == ((PayMethodTypeTr)dest).Lang,
                            rec => rec.PayMethodTypeTr)
                        );
            baseEng.Add("period".ToLower(),
                            new BaseDictionaryEng<Period, PeriodTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (Period)sors,
                            sors => sors.PeriodTr.ToList(),
                            (sors, dest) => ((PeriodTr)sors).CodeI == ((PeriodTr)dest).CodeI && ((PeriodTr)sors).Lang == ((PeriodTr)dest).Lang,
                            rec => rec.PeriodTr)
                        );
            baseEng.Add("positiontype".ToLower(),
                            new BaseDictionaryEng<PositionType, PositionTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (PositionType)sors,
                            sors => sors.PositionTypeTr.ToList(),
                            (sors, dest) => ((PositionTypeTr)sors).CodeI == ((PositionTypeTr)dest).CodeI && ((PositionTypeTr)sors).Lang == ((PositionTypeTr)dest).Lang,
                            rec => rec.PositionTypeTr)
                        );
            baseEng.Add("region".ToLower(),
                            new BaseDictionaryEng<Region, RegionTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (Region)sors,
                            sors => sors.RegionTr.ToList(),
                            (sors, dest) => ((RegionTr)sors).CodeI == ((RegionTr)dest).CodeI && ((RegionTr)sors).Lang == ((RegionTr)dest).Lang,
                            rec => rec.RegionTr)
                        );
            baseEng.Add("registerstatus".ToLower(),
                            new BaseDictionaryEng<RegisterStatus, RegisterStatusTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (RegisterStatus)sors,
                            sors => sors.RegisterStatusTr.ToList(),
                            (sors, dest) => ((RegisterStatusTr)sors).CodeI == ((RegisterStatusTr)dest).CodeI && ((RegisterStatusTr)sors).Lang == ((RegisterStatusTr)dest).Lang,
                            rec => rec.RegisterStatusTr)
                        );
            baseEng.Add("residenttype".ToLower(),
                            new BaseDictionaryEng<ResidentType, ResidentTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (ResidentType)sors,
                            sors => sors.ResidentTypeTr.ToList(),
                            (sors, dest) => ((ResidentTypeTr)sors).CodeI == ((ResidentTypeTr)dest).CodeI && ((ResidentTypeTr)sors).Lang == ((ResidentTypeTr)dest).Lang,
                            rec => rec.ResidentTypeTr)
                        );
            baseEng.Add("sextype".ToLower(),
                            new BaseDictionaryEng<SexType, SexTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (SexType)sors,
                            sors => sors.SexTypeTr.ToList(),
                            (sors, dest) => ((SexTypeTr)sors).CodeI == ((SexTypeTr)dest).CodeI && ((SexTypeTr)sors).Lang == ((SexTypeTr)dest).Lang,
                            rec => rec.SexTypeTr)
                        );
            baseEng.Add("typeplace".ToLower(),
                            new BaseDictionaryEng<TypePlace, TypePlaceTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (TypePlace)sors,
                            sors => sors.TypePlaceTr.ToList(),
                            (sors, dest) => ((TypePlaceTr)sors).CodeI == ((TypePlaceTr)dest).CodeI && ((TypePlaceTr)sors).Lang == ((TypePlaceTr)dest).Lang,
                            rec => rec.TypePlaceTr)
                        );
            baseEng.Add("typevat".ToLower(),
                            new BaseDictionaryEng<TypeVat, TypeVattr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
                            sors => (DictBaseTypeI)sors,
                            sors => (TypeVat)sors,
                            sors => sors.TypeVattr.ToList(),
                            (sors, dest) => ((TypeVattr)sors).CodeI == ((TypeVattr)dest).CodeI && ((TypeVattr)sors).Lang == ((TypeVattr)dest).Lang,
                            rec => rec.TypeVattr)
                        );

            #endregion
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
            eng.runActionByTr(obj, delAct);
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
            var newItem = eng.ConvertFromBase(eng.ToObject(data));

            entity.Add(newItem);
            //eng.insertObject(data);

            await _dbContext.SaveChangesAsync();

            return Json(eng.ConvertToBase(newItem));

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
            var sors = eng.ConvertFromBase(eng.ToObject(data));

            ((object)dest).SetFields((object)sors);
            Type trType = (Type)eng.dicTrType;

            var listDst = eng.GetTr(dest);
            var listSrs = eng.GetTr(sors);

            eng.DeleteAbsent(listDst, listSrs);
            eng.InserNew(listDst, listSrs);
            eng.Update(listDst, listSrs);


            await _dbContext.SaveChangesAsync();

            return Ok();

        }

        //CrkindGroup


        [HttpGet("extra/crkindgroup")]
        public async Task<ActionResult> GetCrkindgroup()
        {
            var crkindgroup = await _dbContext.CrkindGroup
                .Include(rec => rec.CrkindGroupTr)
                .Include(rec => rec.CopyrightKind)
                .ToListAsync();

            crkindgroup.ForEach(rec =>
            {
                foreach (var tr in rec.CopyrightKind)
                    _dbContext.Entry(tr).Collection(trItem => trItem.CopyrightKindTr).Load();
            });

            return Json(crkindgroup);
        }

        // Получити запис довідника по ключу
        private async Task<CrkindGroup> getCrkindGroup(int id)
        {
            var crkindgroup = await _dbContext.CrkindGroup.Where(rec => rec.CodeI == id)
                .Include(rec => rec.CrkindGroupTr)
                .Include(rec => rec.CopyrightKind)
                .SingleOrDefaultAsync();

            if (crkindgroup == null)
                return null;

            foreach (var tr in crkindgroup.CopyrightKind)
                _dbContext.Entry(tr).Collection(trItem => trItem.CopyrightKindTr).Load();

            return crkindgroup;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("extra/crkindgroup/{id}")]
        public async Task<ActionResult> GetCrkindgroupById(int id)
        {
            var crkindgroup = await getCrkindGroup(id);
            if (crkindgroup == null)
                return BadRequest();

            return Json(crkindgroup);
        }

        [HttpPost("extra/crkindgroup")]
        public async Task<ActionResult> NewCrkindgroup([FromBody] JObject data)
        {
            CrkindGroup newItem = data.ToObject<CrkindGroup>();
            if (newItem == null)
                return BadRequest();

            var dicCode = _dbContext.CopyrightKind.AsNoTracking().ToDictionary(row => row.CodeI);
            int MaxCodeI = dicCode.Keys.Max() + 1;
            var maxGroupId = _dbContext.CrkindGroup.AsNoTracking().OrderByDescending(row => row.CodeI).First()
                .CodeI + 1;

            newItem.CodeI = maxGroupId;

            // для кожного виду права, якщо проставлено Ід встановлюємо статус запису Модіфіковано
            foreach (var row in newItem.CopyrightKind)
            {
                bool isNew = row.CodeI == 0;

                _dbContext.Entry(row).State = isNew ? EntityState.Added : EntityState.Modified;
                row.CodeI = isNew ? MaxCodeI : row.CodeI;
                // Для записів перекладу назви  виду права, якщо проставлено Ід встановлюємо статус запису Модіфіковано
                foreach (var trRow in row.CopyrightKindTr)
                {
                    _dbContext.Entry(trRow).State = trRow.CodeI == 0 ? EntityState.Added : EntityState.Modified;
                    trRow.CodeI = isNew ? MaxCodeI : trRow.CodeI;
                }

                if (isNew) MaxCodeI++;
            }

            foreach (var item in newItem.CrkindGroupTr)
            {
                bool isNew = item.CodeI == 0;

                _dbContext.Entry(item).State = isNew ? EntityState.Added : EntityState.Modified;
                item.CodeI = isNew ? MaxCodeI : item.CodeI;
                if (isNew) MaxCodeI++;
            }

            // Для запису довідника встановлюємо статус 
            _dbContext.Entry(newItem).State = EntityState.Added;

            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return BadRequest(ex.InnerException.Message);
            }

            transaction.Commit();


            return Json(newItem);
        }


        private void UpdateList<T>(List<T> sors, List<T> dest, Func<T, T, bool> compId) where T : class
        {
            // Видалення
            List<T> tempList = dest.Where(row => !sors.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => _dbContext.Entry(item).State = EntityState.Deleted);
            // Додаємо нові
            tempList = sors.Where(row => !dest.Any(item => compId(row, item))).ToList();
            tempList.ForEach(item => { sors.Remove(item); dest.Add(item); });
            // Змінюємо спільні записи
            sors.ForEach(item => dest.First(row => compId(item, row)).SetFields(item));

        }
        [HttpPut("extra/crkindgroup/{id}")]
        public async Task<ActionResult> UpdateCrkindgroup(int id, [FromBody] JObject data)
        {
            CrkindGroup sorsItem = data.ToObject<CrkindGroup>();
            if (sorsItem == null)
                return BadRequest();
            var destItem = await getCrkindGroup(id);
            if (destItem == null)
                return BadRequest();

            var dicCode = _dbContext.CopyrightKind.AsNoTracking().ToDictionary(row => row.CodeI);
            int MaxCodeI = dicCode.Keys.Max() + 1;
            var maxGroupId = _dbContext.CrkindGroup.AsNoTracking().OrderByDescending(row => row.CodeI).First()
                                 .CodeI + 1;

            // sorsItem.CodeI = maxGroupId;

            List<CrkindGroupTr> dest = destItem.CrkindGroupTr.ToList();
            List<CrkindGroupTr> sors = sorsItem.CrkindGroupTr.ToList();

            UpdateList<CrkindGroupTr>(sors, dest, (sorsI, destI) => sorsI.CodeI == destI.CodeI);

            // List<>
            try
            {
                foreach (var row in sorsItem.CopyrightKind)
                {
                    bool isNew = row.CodeI == 0;

                    _dbContext.Entry(row).State = isNew ? EntityState.Added : EntityState.Modified;
                    row.CodeI = isNew ? MaxCodeI : row.CodeI;
                    // Для записів перекладу назви  виду права, якщо проставлено Ід встановлюємо статус запису Модіфіковано
                    foreach (var trRow in row.CopyrightKindTr)
                    {
                        _dbContext.Entry(trRow).State = trRow.CodeI == 0 ? EntityState.Added : EntityState.Modified;
                        trRow.CodeI = isNew ? MaxCodeI : trRow.CodeI;
                    }

                    if (isNew) MaxCodeI++;
                }

                //---

                foreach (var item in sorsItem.CrkindGroupTr)
                {
                    bool isNew = item.CodeI == 0;

                    _dbContext.Entry(item).State = isNew ? EntityState.Added : EntityState.Modified;
                    item.CodeI = isNew ? MaxCodeI : item.CodeI;
                    if (isNew) MaxCodeI++;
                }

                // Для запису довідника встановлюємо статус 
                _dbContext.Entry(sorsItem).State = EntityState.Modified;
                
            }
            catch (Exception e)
            {
                ;
            }

            var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                
                await _dbContext.SaveChangesAsync();
                //_dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                transaction.Rollback();
                return BadRequest(ex.InnerException.Message);
            }

            transaction.Commit();


            
       


            return Json(sorsItem);
        }


        [HttpDelete("extra/crkindgroup/{id}")]
        public async Task<ActionResult> DeleteCrkindgroup(int id)
        {
            var delItem = await _dbContext.CrkindGroup.Where(row => row.CodeI == id)
                .Include(rec => rec.CrkindGroupTr)
                .Include(rec => rec.CopyrightKind)
                .SingleOrDefaultAsync();


            // Помилковий Ід
            if (delItem == null)
                return BadRequest();

            // Видаляємо Вии права
            foreach (var row in delItem.CopyrightKind)
            {
                foreach (var item in row.CopyrightKindTr)
                    _dbContext.Entry(item).State = EntityState.Deleted;
                _dbContext.Entry(row).State = EntityState.Deleted;
            }
            // Видаляємо Трянсляцію
            foreach (var row in delItem.CrkindGroupTr)
                _dbContext.Entry(row).State = EntityState.Deleted;


            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                await _dbContext.SaveChangesAsync(); //помілка
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return BadRequest(ex.InnerException.Message);
            }

            transaction.Commit();


            return Ok();
        }

    }
}