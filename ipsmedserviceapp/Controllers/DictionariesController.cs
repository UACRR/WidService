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
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.SqlClient;
using System.Collections;
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
        public Func<TTr, TTr, bool> CompareTr;


        public BaseDictionaryEng(
            MediaServiceContext dbContext,
            Func<T, string, bool> compareId,
            Func<T, TBase> convertToBase,
            Func<TBase, T> convertFromBase,
            Func<T, IList<TTr>> getTr,
            Func<TTr, TTr, bool> compareTr,
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
            var item = await set.FirstOrDefaultAsync();
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
        public void Update(List<TTr> dest, List<TTr> sors, string[] fieldExclude)
        {
            var listTemp = sors.ToList();
            listTemp.ForEach(item => { dest.First(destItem => CompareTr(item, destItem)).SetFields(item, fieldExclude); });
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

        private readonly MediaServiceContext _dbContext;
        private Dictionary<string, object> baseEng;
        private readonly List<string> _complexDictionaryList = new List<string>
        {
            "copyrightkind",
            "country",
            "creativeroletype",
            "genretype",
            "kl_r030",
            "systemconstant",
            "typeplace",
            "relgenrepercent"
        };

        public DictionariesController(MediaServiceContext context)
        {
            _dbContext = context;
            SetEng();
        }

        private void SetEng()
        {
            baseEng = new Dictionary<string, object>();

            #region Init Dictionary

            baseEng.Add("activitytype".ToLower(),
                new BaseDictionaryEng<ActivityType, ActivityTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (ActivityType) sors,
                    sors => sors.ActivityTypeTr.ToList(),
                    (sors, dest) => ((ActivityTypeTr) sors).CodeI == ((ActivityTypeTr) dest).CodeI &&
                                    ((ActivityTypeTr) sors).Lang == ((ActivityTypeTr) dest).Lang,
                    rec => rec.ActivityTypeTr)
            );
            baseEng.Add("agreementstatus".ToLower(),
                new BaseDictionaryEng<AgreementStatus, AgreementStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (AgreementStatus) sors,
                    sors => sors.AgreementStatusTr.ToList(),
                    (sors, dest) => ((AgreementStatusTr) sors).CodeI == ((AgreementStatusTr) dest).CodeI &&
                                    ((AgreementStatusTr) sors).Lang == ((AgreementStatusTr) dest).Lang,
                    rec => rec.AgreementStatusTr)
            );
            baseEng.Add("agrlicensetype".ToLower(),
                new BaseDictionaryEng<AgrLicenseType, AgrLicenseTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (AgrLicenseType) sors,
                    sors => sors.AgrLicenseTypeTr.ToList(),
                    (sors, dest) => ((AgrLicenseTypeTr) sors).CodeI == ((AgrLicenseTypeTr) dest).CodeI &&
                                    ((AgrLicenseTypeTr) sors).Lang == ((AgrLicenseTypeTr) dest).Lang,
                    rec => rec.AgrLicenseTypeTr)
            );
            baseEng.Add("anketastatus".ToLower(),
                new BaseDictionaryEng<AnketaStatus, AnketaStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (AnketaStatus) sors,
                    sors => sors.AnketaStatusTr.ToList(),
                    (sors, dest) => ((AnketaStatusTr) sors).CodeI == ((AnketaStatusTr) dest).CodeI &&
                                    ((AnketaStatusTr) sors).Lang == ((AnketaStatusTr) dest).Lang,
                    rec => rec.AnketaStatusTr)
            );
            baseEng.Add("categorystatustype".ToLower(),
                new BaseDictionaryEng<CategoryStatusType, CategoryStatusTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (CategoryStatusType) sors,
                    sors => sors.CategoryStatusTypeTr.ToList(),
                    (sors, dest) => ((CategoryStatusTypeTr) sors).CodeI == ((CategoryStatusTypeTr) dest).CodeI &&
                                    ((CategoryStatusTypeTr) sors).Lang == ((CategoryStatusTypeTr) dest).Lang,
                    rec => rec.CategoryStatusTypeTr)
            );
            baseEng.Add("continent".ToLower(),
                new BaseDictionaryEng<Continent, ContinentTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (Continent) sors,
                    sors => sors.ContinentTr.ToList(),
                    (sors, dest) => ((ContinentTr) sors).CodeI == ((ContinentTr) dest).CodeI &&
                                    ((ContinentTr) sors).Lang == ((ContinentTr) dest).Lang,
                    rec => rec.ContinentTr)
            );
            baseEng.Add("copyrightkind".ToLower(),
                new BaseDictionaryEng<CopyrightKind, CopyrightKindTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (CopyrightKind) sors,
                    sors => sors.CopyrightKindTr.ToList(),
                    (sors, dest) => ((CopyrightKindTr) sors).CodeI == ((CopyrightKindTr) dest).CodeI &&
                                    ((CopyrightKindTr) sors).Lang == ((CopyrightKindTr) dest).Lang,
                    rec => rec.CopyrightKindTr)
            );
            baseEng.Add("copyrighttype".ToLower(),
                new BaseDictionaryEng<CopyrightType, CopyrightTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (CopyrightType) sors,
                    sors => sors.CopyrightTypeTr.ToList(),
                    (sors, dest) => ((CopyrightTypeTr) sors).CodeI == ((CopyrightTypeTr) dest).CodeI &&
                                    ((CopyrightTypeTr) sors).Lang == ((CopyrightTypeTr) dest).Lang,
                    rec => rec.CopyrightTypeTr)
            );
            baseEng.Add("creativeroletype".ToLower(),
                new BaseDictionaryEng<CreativeRoleType, CreativeRoleTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (CreativeRoleType) sors,
                    sors => sors.CreativeRoleTypeTr.ToList(),
                    (sors, dest) => ((CreativeRoleTypeTr) sors).CodeI == ((CreativeRoleTypeTr) dest).CodeI &&
                                    ((CreativeRoleTypeTr) sors).Lang == ((CreativeRoleTypeTr) dest).Lang,
                    rec => rec.CreativeRoleTypeTr)
            );
            baseEng.Add("crkindgroup".ToLower(),
                new BaseDictionaryEng<CrkindGroup, CrkindGroupTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.CrkindGroupTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI &&
                                    sors.Lang == dest.Lang,
                    rec => rec.CrkindGroupTr, rec => rec.CopyrightKind)
            );
            baseEng.Add("customerstatus".ToLower(),
                new BaseDictionaryEng<CustomerStatus, CustomerStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (CustomerStatus) sors,
                    sors => sors.CustomerStatusTr.ToList(),
                    (sors, dest) => ((CustomerStatusTr) sors).CodeI == ((CustomerStatusTr) dest).CodeI &&
                                    ((CustomerStatusTr) sors).Lang == ((CustomerStatusTr) dest).Lang,
                    rec => rec.CustomerStatusTr)
            );
            baseEng.Add("customertype".ToLower(),
                new BaseDictionaryEng<CustomerType, CustomerTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (CustomerType) sors,
                    sors => sors.CustomerTypeTr.ToList(),
                    (sors, dest) => ((CustomerTypeTr) sors).CodeI == ((CustomerTypeTr) dest).CodeI &&
                                    ((CustomerTypeTr) sors).Lang == ((CustomerTypeTr) dest).Lang,
                    rec => rec.CustomerTypeTr)
            );
            baseEng.Add("popgenre".ToLower(),
                new BaseDictionaryEng<PopGenre, PopGenreTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.Id == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.PopGenreTr.ToList(),
                    (sors, dest) => sors.Id == dest.Id && sors.Lang == dest.Lang,
                    rec => rec.PopGenreTr)
            );
            baseEng.Add("legalbasis".ToLower(),
                new BaseDictionaryEng<LegalBasis, LegalBasisTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (LegalBasis) sors,
                    sors => sors.LegalBasisTr.ToList(),
                    (sors, dest) => ((LegalBasisTr) sors).CodeI == ((LegalBasisTr) dest).CodeI &&
                                    ((LegalBasisTr) sors).Lang == ((LegalBasisTr) dest).Lang,
                    rec => rec.LegalBasisTr)
            );
            baseEng.Add("licensetype".ToLower(),
                new BaseDictionaryEng<LicenseType, LicenseTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (LicenseType) sors,
                    sors => sors.LicenseTypeTr.ToList(),
                    (sors, dest) => ((LicenseTypeTr) sors).CodeI == ((LicenseTypeTr) dest).CodeI &&
                                    ((LicenseTypeTr) sors).Lang == ((LicenseTypeTr) dest).Lang,
                    rec => rec.LicenseTypeTr)
            );
            baseEng.Add("objectstatus".ToLower(),
                new BaseDictionaryEng<ObjectStatus, ObjectStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (ObjectStatus) sors,
                    sors => sors.ObjectStatusTr.ToList(),
                    (sors, dest) => ((ObjectStatusTr) sors).CodeI == ((ObjectStatusTr) dest).CodeI &&
                                    ((ObjectStatusTr) sors).Lang == ((ObjectStatusTr) dest).Lang,
                    rec => rec.ObjectStatusTr)
            );
            baseEng.Add("paymentkind".ToLower(),
                new BaseDictionaryEng<PaymentKind, PaymentKindTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (PaymentKind) sors,
                    sors => sors.PaymentKindTr.ToList(),
                    (sors, dest) => ((PaymentKindTr) sors).CodeI == ((PaymentKindTr) dest).CodeI &&
                                    ((PaymentKindTr) sors).Lang == ((PaymentKindTr) dest).Lang,
                    rec => rec.PaymentKindTr)
            );
            baseEng.Add("paymentstatus".ToLower(),
                new BaseDictionaryEng<PaymentStatus, PaymentStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (PaymentStatus) sors,
                    sors => sors.PaymentStatusTr.ToList(),
                    (sors, dest) => ((PaymentStatusTr) sors).CodeI == ((PaymentStatusTr) dest).CodeI &&
                                    ((PaymentStatusTr) sors).Lang == ((PaymentStatusTr) dest).Lang,
                    rec => rec.PaymentStatusTr)
            );
            baseEng.Add("paymethodtype".ToLower(),
                new BaseDictionaryEng<PayMethodType, PayMethodTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (PayMethodType) sors,
                    sors => sors.PayMethodTypeTr.ToList(),
                    (sors, dest) => ((PayMethodTypeTr) sors).CodeI == ((PayMethodTypeTr) dest).CodeI &&
                                    ((PayMethodTypeTr) sors).Lang == ((PayMethodTypeTr) dest).Lang,
                    rec => rec.PayMethodTypeTr)
            );
            baseEng.Add("period".ToLower(),
                new BaseDictionaryEng<Period, PeriodTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (Period) sors,
                    sors => sors.PeriodTr.ToList(),
                    (sors, dest) => ((PeriodTr) sors).CodeI == ((PeriodTr) dest).CodeI &&
                                    ((PeriodTr) sors).Lang == ((PeriodTr) dest).Lang,
                    rec => rec.PeriodTr)
            );
            baseEng.Add("positiontype".ToLower(),
                new BaseDictionaryEng<PositionType, PositionTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (PositionType) sors,
                    sors => sors.PositionTypeTr.ToList(),
                    (sors, dest) => ((PositionTypeTr) sors).CodeI == ((PositionTypeTr) dest).CodeI &&
                                    ((PositionTypeTr) sors).Lang == ((PositionTypeTr) dest).Lang,
                    rec => rec.PositionTypeTr)
            );
            baseEng.Add("region".ToLower(),
                new BaseDictionaryEng<Region, RegionTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (Region) sors,
                    sors => sors.RegionTr.ToList(),
                    (sors, dest) => ((RegionTr) sors).CodeI == ((RegionTr) dest).CodeI &&
                                    ((RegionTr) sors).Lang == ((RegionTr) dest).Lang,
                    rec => rec.RegionTr)
            );
            baseEng.Add("registerstatus".ToLower(),
                new BaseDictionaryEng<RegisterStatus, RegisterStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (RegisterStatus) sors,
                    sors => sors.RegisterStatusTr.ToList(),
                    (sors, dest) => ((RegisterStatusTr) sors).CodeI == ((RegisterStatusTr) dest).CodeI &&
                                    ((RegisterStatusTr) sors).Lang == ((RegisterStatusTr) dest).Lang,
                    rec => rec.RegisterStatusTr)
            );
            baseEng.Add("residenttype".ToLower(),
                new BaseDictionaryEng<ResidentType, ResidentTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (ResidentType) sors,
                    sors => sors.ResidentTypeTr.ToList(),
                    (sors, dest) => ((ResidentTypeTr) sors).CodeI == ((ResidentTypeTr) dest).CodeI &&
                                    ((ResidentTypeTr) sors).Lang == ((ResidentTypeTr) dest).Lang,
                    rec => rec.ResidentTypeTr)
            );
            baseEng.Add("sextype".ToLower(),
                new BaseDictionaryEng<SexType, SexTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (SexType) sors,
                    sors => sors.SexTypeTr.ToList(),
                    (sors, dest) => ((SexTypeTr) sors).CodeI == ((SexTypeTr) dest).CodeI &&
                                    ((SexTypeTr) sors).Lang == ((SexTypeTr) dest).Lang,
                    rec => rec.SexTypeTr)
            );
            baseEng.Add("typeplace".ToLower(),
                new BaseDictionaryEng<TypePlace, TypePlaceTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (TypePlace) sors,
                    sors => sors.TypePlaceTr.ToList(),
                    (sors, dest) => ((TypePlaceTr) sors).CodeI == ((TypePlaceTr) dest).CodeI &&
                                    ((TypePlaceTr) sors).Lang == ((TypePlaceTr) dest).Lang,
                    rec => rec.TypePlaceTr)
            );

            baseEng.Add("typeplaceparam".ToLower(),
                new BaseDictionaryEng<TypePlaceParam, TypePlaceParamTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.TypePlaceParamTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.TypePlaceParamTr)
            );

            baseEng.Add("typevat".ToLower(),
                new BaseDictionaryEng<TypeVat, TypeVattr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (TypeVat) sors,
                    sors => sors.TypeVattr.ToList(),
                    (sors, dest) => ((TypeVattr) sors).CodeI == ((TypeVattr) dest).CodeI &&
                                    ((TypeVattr) sors).Lang == ((TypeVattr) dest).Lang,
                    rec => rec.TypeVattr)
            );
            baseEng.Add("AlgorithmType".ToLower(),
                new BaseDictionaryEng<AlgorithmType, AlgorithmTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (AlgorithmType) sors,
                    sors => sors.AlgorithmTypeTr.ToList(),
                    (sors, dest) => ((AlgorithmTypeTr) sors).CodeI == ((AlgorithmTypeTr) dest).CodeI &&
                                    ((AlgorithmTypeTr) sors).Lang == ((AlgorithmTypeTr) dest).Lang,
                    rec => rec.AlgorithmTypeTr)
            );
            baseEng.Add("SeekType".ToLower(),
                new BaseDictionaryEng<SeekType, SeekTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => (DictBaseTypeI) sors,
                    sors => (SeekType) sors,
                    sors => sors.SeekTypeTr.ToList(),
                    (sors, dest) => ((SeekTypeTr) sors).CodeI == ((SeekTypeTr) dest).CodeI &&
                                    ((SeekTypeTr) sors).Lang == ((SeekTypeTr) dest).Lang,
                    rec => rec.SeekTypeTr)
            );
            baseEng.Add("ObjAct".ToLower(),
                new BaseDictionaryEng<ObjAct, ObjActTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.ObjActTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.ObjActTr)
            );
            baseEng.Add("Category".ToLower(),
                new BaseDictionaryEng<Category, CategoryTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.CategoryTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.CategoryTr)
            );
            baseEng.Add("CRightStatus".ToLower(),
                new BaseDictionaryEng<CrightStatus, CrightStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.CrightStatusTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.CrightStatusTr)
            );
            baseEng.Add("RholderType".ToLower(),
                new BaseDictionaryEng<RholderType, RholderTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.RholderTypeTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.RholderTypeTr)
            );
            baseEng.Add("TypeMethodGet".ToLower(),
                new BaseDictionaryEng<TypeMethodGet, TypeMethodGetTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.TypeMethodGetTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.TypeMethodGetTr)
            );
            baseEng.Add("GenreType".ToLower(),
                new BaseDictionaryEng<GenreType, GenreTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.GenreTypeTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.GenreTypeTr)
            );
            baseEng.Add("WorkType".ToLower(),
                new BaseDictionaryEng<WorkType, WorkTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.WorkTypeTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.WorkTypeTr)
            );
            baseEng.Add("AgreementType".ToLower(),
                new BaseDictionaryEng<AgreementType, AgreementTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.AgreementTypeTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.AgreementTypeTr)
            );
            baseEng.Add("DocumentType".ToLower(),
                new BaseDictionaryEng<DocumentType, DocumentTypeTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.DocumentTypeTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.DocumentTypeTr)
            );
            baseEng.Add("systemconstant".ToLower(),
                new BaseDictionaryEng<SystemConstant, SystemConstantTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.SystemConstantTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.SystemConstantTr));
            baseEng.Add("MonthName".ToLower(),
                new BaseDictionaryEng<MonthName, MonthNameTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.MonthNameTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.MonthNameTr));
            baseEng.Add("CatalogStatus".ToLower(),
                new BaseDictionaryEng<CatalogStatus, CatalogStatusTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.CatalogStatusTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.CatalogStatusTr));

            #endregion
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetDictrionaryList()
        {
            var list = await _dbContext.DictCategory.ToListAsync();
            // Отбираем только стандартные словари с целым ключем

            foreach (var item in list)
                await _dbContext.Entry(item).Collection(rec => rec.DicCategoryItems).Query()
                        .Where(rec => rec.DicType == "i" || rec.DicLevel == 2).LoadAsync();

            var listOut = list.Where(rec => rec.DicCategoryItems.Count > 0).ToList();
            return Json(listOut);
        }

        /// <summary>
        /// Отримати словник за його назвою
        /// </summary>
        /// <param name="dictionay">Найменування словника</param>
        /// <returns></returns>
        [HttpGet("base/{dictionay}")]
        public async Task<IActionResult> GetDictionaryList(string dictionay)
        {
            string normalizeName = dictionay.ToLower();
            if (!_complexDictionaryList.Contains(normalizeName) && baseEng.Keys.Contains(normalizeName))
               return await GetBaseDictionary(normalizeName);
            
            if (_complexDictionaryList.Contains(normalizeName))
                return await GetComplexDictionary(normalizeName);

            return NotFound();
        }

        /// <summary>
        /// Внустрішній метод отримання простого словника
        /// </summary>
        /// <param name="dictionaryName">Назва словника</param>
        /// <returns></returns>
        private async Task<IActionResult> GetBaseDictionary(string dictionaryName)
        {
            dynamic eng = baseEng[dictionaryName];
            var list = await eng.GetList();
            return Json(list);
        }

        /// <summary>
        /// Внустрішній метод отримання складного словника
        /// </summary>
        /// <returns></returns>
        private async Task<IActionResult> GetComplexDictionary(string dictionaryName)
        {   
            switch (dictionaryName)
            {
                case "copyrightkind":
                    var copyrightkind = await _dbContext.CopyrightKind
                        .Include(item => item.CopyrightKindTr)
                        .ToListAsync();
                    return Json(copyrightkind);
                case "country":
                    var country = await _dbContext.Country
                        .Include(item => item.CountryTr)
                        .ToListAsync();
                    return Json(country);
                case "creativeroletype":
                    var creativeroletype = await _dbContext.CreativeRoleType
                        .Include(item => item.CreativeRoleTypeTr)
                        .ToListAsync();
                    return Json(creativeroletype);
                case "genretype":
                    var genretype = await _dbContext.GenreType
                        .Include(item => item.GenreTypeTr)
                        .ToListAsync();
                    return Json(genretype);
                case "kl_r030":
                    var klr030 = await _dbContext.KlR030
                        .Include(item => item.KlR030tr)
                        .ToListAsync();
                    return Json(klr030);
                case "systemconstant":
                    var systemConstant = await _dbContext.SystemConstant
                        .Include(item => item.SystemConstantTr)
                        .ToListAsync();
                    return Json(systemConstant);
                case "typeplace":
                    var typePlace = await _dbContext.TypePlace
                        .Include(item => item.TypePlaceTr)
                        .ToListAsync();
                    return Json(typePlace);
                case "relgenrepercent":
                    var relgenrepercent = await _dbContext.RelGenrePercent
                        .ToListAsync();
                    return Json(relgenrepercent);
                default:
                    return NotFound();
            }
        }

        [HttpGet("base/{dictionary}/{id}")]
        public async Task<IActionResult> GetBaseDictionaryById(string dictionary, string id)
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
        public async Task<IActionResult> UpdateBaseItem(string dictionay, string id, [FromBody]JObject data)
        {
            IDbContextTransaction transaction = null;
            try
            {
                string normalizeName = dictionay.ToLower();

                if (!baseEng.Keys.Contains(normalizeName))
                    return BadRequest();

                dynamic eng = baseEng[normalizeName];
                var dest = await eng.GetById(id);
                var sors = eng.ConvertFromBase(eng.ToObject(data));

                ((object) dest).SetFields((object) sors, new[] { "CategoryCode", "Crtype" });

                var listDst = eng.GetTr(dest);
                var listSrs = eng.GetTr(sors);

                eng.DeleteAbsent(listDst, listSrs);
                eng.InserNew(listDst, listSrs);
                eng.Update(listDst, listSrs);
                //eng.Update(listDst, listSrs, new[]{ "" });

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                transaction = null;

                return Ok();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                return BadRequest(ex.Message);
            }
        }
        
        #region * * * * * СКЛАДНІ ДОВІДНИКИ * * * * *

        #region * * * CopyRightKind * * * 

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPost("extra/create/copyrightkind")]
        public async Task<IActionResult> CreateCopyRightKind([FromBody] CopyrightKind sors)
        {
            var target = new CopyrightKind();
            target.SetFields(sors);

            _dbContext.AppendList(sors.CopyrightKindTr, target.CopyrightKindTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            _dbContext.CopyrightKind.Add(target);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPut("extra/update/copyrightkind")]
        public async Task<IActionResult> UpdateCopyRightKind([FromBody] CopyrightKind sors)
        {
            var target = await _dbContext.CopyrightKind.Where(rec => rec.CodeI == sors.CodeI)
                .Include(rec => rec.CopyrightKindTr)
                .FirstOrDefaultAsync();

            if (target == null)
                return NotFound();

            target.SetFields(sors);
            _dbContext.UpdateList(sors.CopyrightKindTr, target.CopyrightKindTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("extra/delete/copyrightkind/{id}")]
        public async Task<IActionResult> DeleteCopyRightKind(int id)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var delRow = await _dbContext.CopyrightKind.Where(rec => rec.CodeI == id)
                    .Include(rec => rec.CopyrightKindTr)
                    .FirstOrDefaultAsync();
                if (delRow == null)
                    return NotFound();

                _dbContext.CopyrightKindTr.RemoveRange(delRow.CopyrightKindTr);
                _dbContext.CopyrightKind.Remove(delRow);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        #endregion

        #region * * * RelGenrePercent * * *

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("extra/create/relgenrepercent")]
        public async Task<IActionResult> CreateRelGenrePercent([FromBody] RelGenrePercent source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = new RelGenrePercent();
                target.SetFields(source);
                await _dbContext.RelGenrePercent.AddAsync(target);

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("extra/update/relgenrepercent")]
        public async Task<IActionResult> UpdateRelGenrePercent([FromBody] RelGenrePercent source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.RelGenrePercent.SingleOrDefaultAsync(rec => rec.ActCode == source.ActCode && rec.GenreType == source.GenreType);
                if (target == null)
                    return NotFound();

                target.Rate = source.Rate;

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="actCode"></param>
        /// <param name="genreCode"></param>
        /// <returns></returns>
        [HttpDelete("extra/delete/relgenrepercent/{actCode}/{genreCode}")]
        public async Task<IActionResult> DeleteRelGenrePercent(int actCode, int genreCode)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var deleteItem = await _dbContext.RelGenrePercent.SingleOrDefaultAsync(rec => rec.ActCode == actCode && rec.GenreType == genreCode);
                if (deleteItem == null)
                    return NotFound();

                _dbContext.RelGenrePercent.Remove(deleteItem);

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();
                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        #endregion

        // -
        #region * * * Country * * *

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPost("extra/country")]
        public async Task<IActionResult> CreateCountry([FromBody] Country sors)
        {
            Country dest = new Country();

            dest.SetFields(sors);
            _dbContext.AppendList(sors.CountryTr, dest.CountryTr, i => { }, (l, r) => l.CountryCode == r.CountryCode && l.Lang == r.Lang);
            _dbContext.Country.Add(dest);
            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPut("extra/country/{countryCode}")]
        public async Task<IActionResult> UpdateCountry(string countryCode, [FromBody] Country sors)
        {
            Country dest = await _dbContext.Country.Where(rec => rec.CountryCode == countryCode)
                                    .Include(rec => rec.CountryTr)
                                    .FirstOrDefaultAsync();

            if (dest == null)
                return NotFound();

            _dbContext.UpdateList(sors.CountryTr, dest.CountryTr, i => { }, (l, r) => l.CountryCode == r.CountryCode && l.Lang == r.Lang);
            dest.SetFields(sors);

            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        [HttpDelete("extra/country/{countryCode}")]
        public async Task<IActionResult> DeleteCountry(int countryCode)
        {
            Country delRow = await _dbContext.Country.Where(rec => Convert.ToInt32(rec.CountryCode) == countryCode)
                                        .Include(rec => rec.CountryTr)
                                        .FirstOrDefaultAsync();

            if (delRow == null)
                return NotFound();

            _dbContext.CountryTr.RemoveRange(delRow.CountryTr);
            _dbContext.Country.Remove(delRow);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion

        
        #region * * * CreativeRoleType * * *

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("extra/create/creativeroletype")]
        public async Task<IActionResult> CreateCreativeRoleType([FromBody] CreativeRoleType source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = new CreativeRoleType();
                target.SetFields(source);

                _dbContext.AppendList(source.CreativeRoleTypeTr, target.CreativeRoleTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
                _dbContext.CreativeRoleType.Add(target);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok(target);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("extra/update/creativeroletype")]
        public async Task<IActionResult> UpdateCreativeRoleType([FromBody] CreativeRoleType source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.CreativeRoleType.Where(rec => rec.CodeI == source.CodeI)
                    .Include(rec => rec.CreativeRoleTypeTr)
                    .FirstOrDefaultAsync();

                if (target == null)
                    return NotFound();

                target.SetFields(source);
                _dbContext.UpdateList(source.CreativeRoleTypeTr, target.CreativeRoleTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok(target);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("extra/delete/creativeroletype/{id}")]
        public async Task<IActionResult> DeleteCreativeRoleType(int id)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var deleteItem = await _dbContext.CreativeRoleType.Where(rec => rec.CodeI == id)
                    .Include(rec => rec.CreativeRoleTypeTr)
                    .FirstOrDefaultAsync();

                if (deleteItem == null)
                    return NotFound();

                _dbContext.CreativeRoleTypeTr.RemoveRange(deleteItem.CreativeRoleTypeTr);
                _dbContext.CreativeRoleType.Remove(deleteItem);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok();
            }
            catch
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        #endregion

        #region * * * GenreType * * *

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("extra/create/genretype")]
        public async Task<IActionResult> CreateGenreType([FromBody] GenreType source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = new GenreType();

                target.SetFields(source);
                _dbContext.AppendList(source.GenreTypeTr, target.GenreTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
                _dbContext.GenreType.Add(target);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("extra/update/genretype")]
        public async Task<IActionResult> UpdateGenreType([FromBody] GenreType source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.GenreType.Where(rec => rec.CodeI == source.CodeI)
                    .Include(rec => rec.GenreTypeTr)
                    .FirstOrDefaultAsync();
                if (target == null)
                    return NotFound();

                target.SetFields(source);
                _dbContext.UpdateList(source.GenreTypeTr, target.GenreTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok(target);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("extra/delete/genretype/{id}")]
        public async Task<IActionResult> DeleteGenreType(int id)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var delRow = await _dbContext.GenreType.Where(rec => rec.CodeI == id)
                    .Include(rec => rec.GenreTypeTr)
                    .FirstOrDefaultAsync();
                if (delRow == null)
                    return NotFound();

                _dbContext.GenreTypeTr.RemoveRange(delRow.GenreTypeTr);
                _dbContext.GenreType.Remove(delRow);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        #endregion

        // -
        #region * * * Kl_R030 * * *
        
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPost("extra/kl_r030")]
        public async Task<IActionResult> CreateKlR030([FromBody] KlR030 sors)
        {
            var dest = new KlR030();

            dest.SetFields(sors);
            _dbContext.AppendList(sors.KlR030tr, dest.KlR030tr, i => { }, (l, r) => l.R030 == r.R030 && l.Lang == r.Lang);
            _dbContext.KlR030.Add(dest);
            //await _dbContext.SaveChangesAsync();

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            return Ok(dest);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPut("extra/kl_r030/{id}")]
        public async Task<IActionResult> UpdateKlR030(int id, [FromBody] KlR030 sors)
        {
            var dest = await _dbContext.KlR030.Where(rec => Convert.ToInt32(rec.R030) == id)
                                .Include(rec => rec.KlR030tr)
                                .FirstOrDefaultAsync();
            if (dest == null)
                return NotFound();

            _dbContext.UpdateList(sors.KlR030tr, dest.KlR030tr, i => { }, (l, r) => l.R030 == r.R030 && l.Lang == r.Lang);
            dest.SetFields(sors);

            try
            {
                await _dbContext.SaveChangesAsync();
                return Ok(dest);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("extra/kl_r030/{id}")]
        public async Task<IActionResult> DeleteKlR030(int id)
        {
            var delRow = await _dbContext.KlR030.Where(rec => Convert.ToInt32(rec.R030) == id)
                                .Include(rec => rec.KlR030tr)
                                .FirstOrDefaultAsync();
            if (delRow == null)
                return NotFound();

            _dbContext.KlR030tr.RemoveRange(delRow.KlR030tr);
            _dbContext.KlR030.Remove(delRow);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion
        // -
        #region * * * SystemConstant * * *

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPost("extra/systemconstant")]
        public async Task<IActionResult> CreateSystemConstant([FromBody] SystemConstant sors)
        {
            var dest = new SystemConstant();

            dest.SetFields(sors);
            _dbContext.AppendList(sors.SystemConstantTr, dest.SystemConstantTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            _dbContext.SystemConstant.Add(dest);
            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPut("extra/systemconstant/{id}")]
        public async Task<IActionResult> UpdateSystemConstant(int id, [FromBody] SystemConstant sors)
        {
            var dest = await _dbContext.SystemConstant.Where(rec => rec.CodeI == id)
                                .Include(rec => rec.SystemConstantTr)
                                .FirstOrDefaultAsync();
            if (dest == null)
                return NotFound();

            _dbContext.UpdateList(sors.SystemConstantTr, dest.SystemConstantTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            dest.SetFields(sors);

            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("extra/systemconstant/{id}")]
        public async Task<IActionResult> DeleteSystemConstant(int id)
        {
            var delRow = await _dbContext.SystemConstant.Where(rec => rec.CodeI == id)
                                .Include(rec => rec.SystemConstantTr)
                                .FirstOrDefaultAsync();
            if (delRow == null)
                return NotFound();

            _dbContext.SystemConstantTr.RemoveRange(delRow.SystemConstantTr);
            _dbContext.SystemConstant.Remove(delRow);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion
        // -
        #region * * * TypePlace * * *

        // Create
        [HttpPost("extra/typeplace")]
        public async Task<IActionResult> CreateTypePlace([FromBody] TypePlace sors)
        {
            var dest = new TypePlace();

            dest.SetFields(sors);
            _dbContext.AppendList(sors.TypePlaceTr, dest.TypePlaceTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            _dbContext.TypePlace.Add(dest);
            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        // Update
        [HttpPut("extra/typeplace/{id}")]
        public async Task<IActionResult> UpdateTypePlace(int id, [FromBody] TypePlace sors)
        {
            var dest = await _dbContext.TypePlace.Where(rec => rec.CodeI == id)
                .Include(rec => rec.TypePlaceTr)
                .FirstOrDefaultAsync();
            if (dest == null)
                return NotFound();

            _dbContext.UpdateList(sors.TypePlaceTr, dest.TypePlaceTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            dest.SetFields(sors);

            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        // Delete
        [HttpDelete("extra/typeplace/{id}")]
        public async Task<IActionResult> DeleteTypePlace(int id)
        {
            var delRow = await _dbContext.TypePlace.Where(rec => rec.CodeI == id)
                .Include(rec => rec.TypePlaceTr)
                .FirstOrDefaultAsync();
            if (delRow == null)
                return NotFound();

            _dbContext.TypePlaceTr.RemoveRange(delRow.TypePlaceTr);
            _dbContext.TypePlace.Remove(delRow);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion
        // -
        #endregion

        #region * * *  ОТРИМАТИ ДОВІДНИКИ СИСТЕМИ * * *

        /// <summary>
        /// Отримати довідники для інтерфейсів роботи з анкетами та договорами
        /// </summary>
        /// <returns></returns>
        [HttpGet("anketa")]
        public async Task<ActionResult> GetAnketaDictionary()
        {
            Dictionary<string, object> retDictionary = new Dictionary<string, object>();

            
            retDictionary.Add("activityType", await _dbContext.ActivityType.AsNoTracking().ToListAsync());
            retDictionary.Add("algorithmType", await _dbContext.AlgorithmType.AsNoTracking().ToListAsync());
            retDictionary.Add("agrLicenseType", await _dbContext.AgrLicenseType.AsNoTracking().ToListAsync());
            retDictionary.Add("agreementStatus", await _dbContext.AgreementStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("agreementType", await _dbContext.AgreementType.AsNoTracking().ToListAsync());
            retDictionary.Add("anketaStatus", await _dbContext.AnketaStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("copyrightKind", await _dbContext.CopyrightKind.AsNoTracking().ToListAsync());
            retDictionary.Add("copyrightType", await _dbContext.CopyrightType.AsNoTracking().ToListAsync());
            retDictionary.Add("country", await _dbContext.Country
                            //.Where(rec=>rec.ShortChoise == 1)
                            .OrderBy( rec => rec.OrderBy ?? 1000).ThenBy( rec =>rec.CountryName ).AsNoTracking().ToListAsync());
            retDictionary.Add("creativeRoleType", await _dbContext.CreativeRoleType.AsNoTracking().ToListAsync());
            retDictionary.Add("crkindGroup", await _dbContext.CrkindGroup.AsNoTracking().ToListAsync());
            retDictionary.Add("customerStatus", await _dbContext.CustomerStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("customerType", await _dbContext.CustomerType.AsNoTracking().ToListAsync());
            retDictionary.Add("fileType", await _dbContext.FileType.AsNoTracking().ToListAsync());
            retDictionary.Add("klR030", await _dbContext.KlR030.Where(c => c.PrWork != 0).OrderBy(c => c.PrWork).AsNoTracking().ToListAsync());
            retDictionary.Add("licenseClass", await _dbContext.LicenseClass.AsNoTracking().ToListAsync());
            retDictionary.Add("licenseType", await _dbContext.LicenseType.AsNoTracking().ToListAsync());
            retDictionary.Add("period", await _dbContext.Period.AsNoTracking().ToListAsync());
            retDictionary.Add("periodStatus", await _dbContext.PeriodStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("positionType", await _dbContext.PositionType.AsNoTracking().ToListAsync());
            retDictionary.Add("prePayType", await _dbContext.PrePayType.AsNoTracking().ToListAsync());
            retDictionary.Add("region", await _dbContext.Region.AsNoTracking().ToListAsync());
            retDictionary.Add("registerStatus", await _dbContext.RegisterStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("registerListStatus", await _dbContext.RegisterListStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("residentType", await _dbContext.ResidentType.AsNoTracking().ToListAsync());
            retDictionary.Add("rholderType", await _dbContext.RholderType.AsNoTracking().ToListAsync());
            retDictionary.Add("sexType", await _dbContext.SexType.AsNoTracking().ToListAsync());
            retDictionary.Add("typeMethodGet", await _dbContext.TypeMethodGet.AsNoTracking().ToListAsync());
            retDictionary.Add("typePlace", await _dbContext.TypePlace.Include(rec => rec.ParamTypeNavigation).AsNoTracking().ToListAsync());
            retDictionary.Add("typePlaceParam", await _dbContext.TypePlaceParam.AsNoTracking().ToListAsync());
            retDictionary.Add("typeVat", await _dbContext.TypeVat.AsNoTracking().ToListAsync());
            retDictionary.Add("userRoleType", await _dbContext.UserRoleType.AsNoTracking().ToListAsync());
            retDictionary.Add("usesKind", await _dbContext.UsesKind.AsNoTracking().ToListAsync());
            retDictionary.Add("usesType", await _dbContext.UsesType.AsNoTracking().ToListAsync());
            retDictionary.Add("workType", await _dbContext.WorkType.AsNoTracking().ToListAsync());
            retDictionary.Add("relGenrePercent", await _dbContext.RelGenrePercent.AsNoTracking().ToListAsync());
            retDictionary.Add("fixStageStatus", await _dbContext.FixStageStatus.AsNoTracking().ToListAsync());

            retDictionary.Add("objAct", await _dbContext.ObjAct.AsNoTracking().ToListAsync());
            retDictionary.Add("performType", await _dbContext.PerformType.AsNoTracking().ToListAsync());
            retDictionary.Add("genreType", await _dbContext.GenreType.AsNoTracking().ToListAsync());
            retDictionary.Add("language", await _dbContext.Language.Where(l => l.ShortChoise == 1).AsNoTracking().ToListAsync());

            retDictionary.Add("systemconstant", await _dbContext.SystemConstant.AsNoTracking().ToListAsync());

            retDictionary.Add("isAuthorType", await _dbContext.IsAuthorType.AsNoTracking().ToListAsync());

            string queryCommunities = "select t2.name, t2.custId from community t1 join vCustomer t2 on t2.custId = t1.custId";
            retDictionary.Add("Communities", await _dbContext.getViewData(queryCommunities, new SqlParameter[0]));

            retDictionary.Add("schemaType", await _dbContext.SchemaType.AsNoTracking().ToListAsync());

            return Json(retDictionary);
        }

        /// <summary>
        /// Отримати довідники для інтерфейсів роботи з анкетами та договорами
        /// </summary>
        /// <returns></returns>
        [HttpGet("anketa/{lang}")]
        public async Task<ActionResult> GetAnketaDictionary(string lang)
        {
            var dictionary = new Dictionary<string, object>
            {
                {
                    "activityType", TranslateDictionary(
                        await _dbContext.ActivityType.Include(rec => rec.ActivityTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.ActivityTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.ActivityTypeTr.Clear();
                        })
                },
                {
                    "agreementStatus", TranslateDictionary(
                        await _dbContext.AgreementStatus.Include(rec => rec.AgreementStatusTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.AgreementStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.AgreementStatusTr.Clear();
                        })
                },
                {
                    "agreementType", TranslateDictionary(
                        await _dbContext.AgreementType.Include(rec => rec.AgreementTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.AgreementTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.AgreementTypeTr.Clear();
                        })
                },
                {
                    "agrLicenseType", TranslateDictionary(
                        await _dbContext.AgrLicenseType.Include(rec => rec.AgrLicenseTypeTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.AgrLicenseTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.AgrLicenseTypeTr.Clear();
                        })
                },
                {
                    "algorithmType", TranslateDictionary(
                        await _dbContext.AlgorithmType.Include(rec => rec.AlgorithmTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.AlgorithmTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.AlgorithmTypeTr.Clear();
                        })
                },
                {
                    "anketaStatus", TranslateDictionary(
                        await _dbContext.AnketaStatus.Include(rec => rec.AnketaStatusTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.AnketaStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.AnketaStatusTr.Clear();
                        })
                },
                {
                    "catalogStatus", TranslateDictionary(
                        await _dbContext.CatalogStatus.Include(rec => rec.CatalogStatusTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CatalogStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CatalogStatusTr.Clear();
                        })
                },
                {
                    "category", TranslateDictionary(
                        await _dbContext.Category.Include(rec => rec.CategoryTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.CategoryTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CategoryTr.Clear();
                        })
                },
                {
                    "categoryStatusType", TranslateDictionary(
                        await _dbContext.CategoryStatusType.Include(rec => rec.CategoryStatusTypeTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.CategoryStatusTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CategoryStatusTypeTr.Clear();
                        })
                },
                {
                    "continent", TranslateDictionary(
                        await _dbContext.Continent.Include(rec => rec.ContinentTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.ContinentTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.ContinentTr.Clear();
                        })
                },
                {
                    "copyrightKind", TranslateDictionary(
                        await _dbContext.CopyrightKind.Include(rec => rec.CopyrightKindTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CopyrightKindTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CopyrightKindTr.Clear();
                        })
                },
                {
                    "copyrightType", TranslateDictionary(
                        await _dbContext.CopyrightType.Include(rec => rec.CopyrightTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CopyrightTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CopyrightTypeTr.Clear();
                        })
                },
                {
                    "country", TranslateDictionary(
                        await _dbContext.Country.Include(rec => rec.CountryTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.CountryTr.SingleOrDefault(tr => tr.Lang == lang)?.CountryName;
                            rec.CountryName = name ?? rec.CountryName;
                            rec.CountryTr.Clear();
                        })
                },
                {
                    "creativeRoleType", TranslateDictionary(
                        await _dbContext.CreativeRoleType.Include(rec => rec.CreativeRoleTypeTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.CreativeRoleTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CreativeRoleTypeTr.Clear();
                        })
                },
                {
                    "cRightStatus", TranslateDictionary(
                        await _dbContext.CrightStatus.Include(rec => rec.CrightStatusTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CrightStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CrightStatusTr.Clear();
                        })
                },
                {
                    "cRKindGroup", TranslateDictionary(
                        await _dbContext.CrkindGroup.Include(rec => rec.CrkindGroupTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CrkindGroupTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CrkindGroupTr.Clear();
                        })
                },
                {
                    "customerStatus", TranslateDictionary(
                        await _dbContext.CustomerStatus.Include(rec => rec.CustomerStatusTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.CustomerStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CustomerStatusTr.Clear();
                        })
                },
                {
                    "customerType", TranslateDictionary(
                        await _dbContext.CustomerType.Include(rec => rec.CustomerTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CustomerTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CustomerTypeTr.Clear();
                        })
                },
                {
                    "documentType", TranslateDictionary(
                        await _dbContext.DocumentType.Include(rec => rec.DocumentTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.DocumentTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.DocumentTypeTr.Clear();
                        })
                },
                {
                    "genreType", TranslateDictionary(
                        await _dbContext.GenreType.Include(rec => rec.GenreTypeTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.GenreTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.GenreTypeTr.Clear();
                        })
                },
                {
                    "klR030", TranslateDictionary(
                        await _dbContext.KlR030.Include(rec => rec.KlR030tr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.KlR030tr.SingleOrDefault(tr => tr.Lang == lang)?.R030Name;
                            rec.R030Name = name ?? rec.R030Name;
                            rec.KlR030tr.Clear();
                        })
                },
                {
                    "lang", TranslateDictionary(
                        await _dbContext.Lang.Include(rec => rec.LangTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.LangTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.LangTr.Clear();
                        })
                },
                {
                    "legalBasis", TranslateDictionary(
                        await _dbContext.LegalBasis.Include(rec => rec.LegalBasisTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.LegalBasisTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.LegalBasisTr.Clear();
                        })
                },
                {
                    "licenseType", TranslateDictionary(
                        await _dbContext.LicenseType.Include(rec => rec.LicenseTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.LicenseTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.LicenseTypeTr.Clear();
                        })
                },
                {
                    "monthName", TranslateDictionary(
                        await _dbContext.MonthName.Include(rec => rec.MonthNameTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.MonthNameTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.MonthNameTr.Clear();
                        })
                },
                {
                    "objAct", TranslateDictionary(
                        await _dbContext.ObjAct.Include(rec => rec.ObjActTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.ObjActTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.ObjActTr.Clear();
                        })
                },
                {
                    "objectStatus", TranslateDictionary(
                        await _dbContext.ObjectStatus.Include(rec => rec.ObjectStatusTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.ObjectStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.ObjectStatusTr.Clear();
                        })
                },
                {
                    "paymentKind", TranslateDictionary(
                        await _dbContext.PaymentKind.Include(rec => rec.PaymentKindTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.PaymentKindTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.PaymentKindTr.Clear();
                        })
                },
                {
                    "paymentStatus", TranslateDictionary(
                        await _dbContext.PaymentStatus.Include(rec => rec.PaymentStatusTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.PaymentStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.PaymentStatusTr.Clear();
                        })
                },
                {
                    "payMethodType", TranslateDictionary(
                        await _dbContext.PayMethodType.Include(rec => rec.PayMethodTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.PayMethodTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.PayMethodTypeTr.Clear();
                        })
                },
                {
                    "period", TranslateDictionary(
                        await _dbContext.Period.Include(rec => rec.PeriodTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.PeriodTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.PeriodTr.Clear();
                        })
                },
                {
                    "permitType", TranslateDictionary(
                        await _dbContext.PermitType.Include(rec => rec.PermitTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.PermitTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.PermitTypeTr.Clear();
                        })
                },
                {
                    "positionType", TranslateDictionary(
                        await _dbContext.PositionType.Include(rec => rec.PositionTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.PositionTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.PositionTypeTr.Clear();
                        })
                },
                {
                    "region", TranslateDictionary(
                        await _dbContext.Region.Include(rec => rec.RegionTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.RegionTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.RegionTr.Clear();
                        })
                },
                {
                    "registerStatus", TranslateDictionary(
                        await _dbContext.RegisterStatus.Include(rec => rec.RegisterStatusTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.RegisterStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.RegisterStatusTr.Clear();
                        })
                },
                {
                    "residentType", TranslateDictionary(
                        await _dbContext.ResidentType.Include(rec => rec.ResidentTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.ResidentTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.ResidentTypeTr.Clear();
                        })
                },
                {
                    "rHolderType", TranslateDictionary(
                        await _dbContext.RholderType.Include(rec => rec.RholderTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.RholderTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.RholderTypeTr.Clear();
                        })
                },
                {
                    "seekType", TranslateDictionary(
                        await _dbContext.SeekType.Include(rec => rec.SeekTypeTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.SeekTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.SeekTypeTr.Clear();
                        })
                },
                {
                    "sexType", TranslateDictionary(
                        await _dbContext.SexType.Include(rec => rec.SexTypeTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.SexTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.SexTypeTr.Clear();
                        })
                },
                {
                    "systemConstant", TranslateDictionary(
                        await _dbContext.SystemConstant.Include(rec => rec.SystemConstantTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.SystemConstantTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.SystemConstantTr.Clear();
                        })
                },
                {
                    "typeMethodGet", TranslateDictionary(
                        await _dbContext.TypeMethodGet.Include(rec => rec.TypeMethodGetTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.TypeMethodGetTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.TypeMethodGetTr.Clear();
                        })
                },
                {
                    "typePlace", TranslateDictionary(
                        await _dbContext.TypePlace.Include(rec => rec.TypePlaceTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.TypePlaceTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.TypePlaceTr.Clear();
                        })
                },
                {
                    "typePlaceParam", TranslateDictionary(
                        await _dbContext.TypePlaceParam.Include(rec => rec.TypePlaceParamTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.TypePlaceParamTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.TypePlaceParamTr.Clear();
                        })
                },
                {
                    "typeVAT", TranslateDictionary(
                        await _dbContext.TypeVat.Include(rec => rec.TypeVattr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.TypeVattr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.TypeVattr.Clear();
                        })
                },
                {
                    "workType", TranslateDictionary(
                        await _dbContext.WorkType.Include(rec => rec.WorkTypeTr).AsNoTracking().ToListAsync(), 
                        rec =>
                        {
                            var name = rec.WorkTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.WorkTypeTr.Clear();
                        })
                },
            };


            return Json(dictionary);
        }

        /// <summary>
        /// Довідники об'єкту права
        /// </summary>
        /// <returns></returns>
        [HttpGet("objectright")]
        public async Task<ActionResult> GetObjectRightDictionary()
        {
            Dictionary<string, object> retDictionary = new Dictionary<string, object>();

            retDictionary.Add("category", await _dbContext.Category.AsNoTracking().ToListAsync());
            retDictionary.Add("copyrightType", await _dbContext.CopyrightType.AsNoTracking().ToListAsync());
            retDictionary.Add("creativeRoleType", await _dbContext.CreativeRoleType.AsNoTracking().ToListAsync());
            retDictionary.Add("etGenre", await _dbContext.EtGenre.AsNoTracking().ToListAsync());
            retDictionary.Add("etRole", await _dbContext.EtRole.AsNoTracking().ToListAsync());
            retDictionary.Add("genreType", await _dbContext.GenreType.AsNoTracking().ToListAsync());
            retDictionary.Add("legalBasis", await _dbContext.LegalBasis.AsNoTracking().ToListAsync());
            retDictionary.Add("objAct", await _dbContext.ObjAct.AsNoTracking().ToListAsync());
            retDictionary.Add("objectStatus", await _dbContext.ObjectStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("permitType", await _dbContext.PermitType.AsNoTracking().ToListAsync());
            retDictionary.Add("seekType", await _dbContext.SeekType.AsNoTracking().ToListAsync());
            retDictionary.Add("specType", await _dbContext.SpecType.AsNoTracking().ToListAsync());
            retDictionary.Add("folkType", await _dbContext.FolkType.AsNoTracking().ToListAsync());
            retDictionary.Add("registerStatuses", await _dbContext.RegisterStatus.AsNoTracking().ToListAsync());
            retDictionary.Add("catalogStatus", await _dbContext.CatalogStatus.AsNoTracking().ToListAsync());

            return Json(retDictionary);
        }

        /// <summary>
        /// Довідники об'єкту права
        /// </summary>
        /// <returns></returns>
        [HttpGet("objectright/{lang}")]
        public async Task<ActionResult> GetObjectRightDictionary(string lang)
        {
            var dictionary = new Dictionary<string, object>
            {
                {
                    "category", TranslateDictionary(
                        await _dbContext.Category.Include(rec => rec.CategoryTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CategoryTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CategoryTr.Clear();
                        })
                },
                {
                    "copyrightType", TranslateDictionary(
                        await _dbContext.CopyrightType.Include(rec => rec.CopyrightTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CopyrightTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CopyrightTypeTr.Clear();
                        })
                },
                {
                    "creativeRoleType", TranslateDictionary(
                        await _dbContext.CreativeRoleType.Include(rec => rec.CreativeRoleTypeTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.CreativeRoleTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CreativeRoleTypeTr.Clear();
                        })
                },
                {
                    "etGenre", await _dbContext.EtGenre.AsNoTracking().ToListAsync()
                },
                {
                    "etRole", await _dbContext.EtRole.AsNoTracking().ToListAsync()
                },
                {
                    "genreType", TranslateDictionary(
                        await _dbContext.GenreType.Include(rec => rec.GenreTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.GenreTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.GenreTypeTr.Clear();
                        })
                },
                {
                    "legalBasis", TranslateDictionary(
                        await _dbContext.LegalBasis.Include(rec => rec.LegalBasisTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.LegalBasisTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.LegalBasisTr.Clear();
                        })
                },
                {
                    "objAct", TranslateDictionary(
                        await _dbContext.ObjAct.Include(rec => rec.ObjActTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.ObjActTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.ObjActTr.Clear();
                        })
                },
                {
                    "objectStatus", TranslateDictionary(
                        await _dbContext.ObjectStatus.Include(rec => rec.ObjectStatusTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.ObjectStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.ObjectStatusTr.Clear();
                        })
                },
                {
                    "permitType", TranslateDictionary(
                        await _dbContext.PermitType.Include(rec => rec.PermitTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.PermitTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.PermitTypeTr.Clear();
                        })
                },
                {
                    "seekType", TranslateDictionary(
                        await _dbContext.SeekType.Include(rec => rec.SeekTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.SeekTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.SeekTypeTr.Clear();
                        })
                },
                {
                    "specType", TranslateDictionary(
                        await _dbContext.SpecType.Include(rec => rec.SpecTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.SpecTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.SpecTypeTr.Clear();
                        })
                },
                {
                    "folkType", TranslateDictionary(
                        await _dbContext.FolkType.Include(rec => rec.FolkTypeTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.FolkTypeTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.FolkTypeTr.Clear();
                        })
                },
                {
                    "registerStatuses", TranslateDictionary(
                        await _dbContext.RegisterStatus.Include(rec => rec.RegisterStatusTr).AsNoTracking()
                            .ToListAsync(), rec =>
                        {
                            var name = rec.RegisterStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.RegisterStatusTr.Clear();
                        })
                },
                {
                    "catalogStatus", TranslateDictionary(
                        await _dbContext.CatalogStatus.Include(rec => rec.CatalogStatusTr).AsNoTracking().ToListAsync(),
                        rec =>
                        {
                            var name = rec.CatalogStatusTr.SingleOrDefault(tr => tr.Lang == lang)?.Name;
                            rec.Name = name ?? rec.Name;
                            rec.CatalogStatusTr.Clear();
                        })
                },
            };
            
            return Json(dictionary);
        }

        /// <summary>
        /// Довідник параметрів пошуку
        /// </summary>
        /// <param name="lang"></param>
        /// <returns></returns>
        [HttpGet("searchhelper/{lang}")]
        public async Task<IActionResult> GetSearchHelperDictionary(string lang)
        {
            var data = await _dbContext.FrameTask
                .Include(item => item.FrameParam)
                .ThenInclude(item => item.FrameParamTr)
                .ToListAsync();

            foreach (var frameTask in data)
            {
                foreach (var frameParam in frameTask.FrameParam)
                {
                    var name = frameParam.FrameParamTr.SingleOrDefault(tr => tr.Lang == lang)?.SeekName;
                    frameParam.SeekName = name ?? frameParam.SeekName;
                    frameParam.FrameParamTr.Clear();
                }
            }

            return Ok(data);
        }

        /// <summary>
        /// Отримати дані по анкеті компанії
        /// </summary>
        /// <returns></returns>
        [HttpGet("myanketa")]
        public async Task<IActionResult> GetMyAnketa()
        {
            var data = await _dbContext.MyAnketa.SingleAsync();
            return Ok(data);
        }

        private static List<T> TranslateDictionary<T>(List<T> dictionaries, Action<T> setValue)
        {
            foreach (var item in dictionaries)
                setValue(item);

            return dictionaries;
        }

        #endregion
    }
}
