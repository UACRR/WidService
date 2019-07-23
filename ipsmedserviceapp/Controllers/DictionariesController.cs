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

        private MediaServiceContext _dbContext;
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

        //MediaServiceContext dbContext,
        //Func<T, string, bool> compareId,
        //params Expression<Func<T, object>>[] includes

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
                new BaseDictionaryEng<CrkindGroup, CrkindGroupTr, CrkindGroup>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => (CrkindGroup) sors,
                    sors => sors.CrkindGroupTr.ToList(),
                    (sors, dest) => ((CrkindGroupTr) sors).CodeI == ((CrkindGroupTr) dest).CodeI &&
                                    ((CrkindGroupTr) sors).Lang == ((CrkindGroupTr) dest).Lang,
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
            //baseEng.Add("documentkind".ToLower(),
            //                new BaseDictionaryEng<DocumentKind, DocumentKindTr, DictBaseTypeI>(_dbContext, (source, id) => source.CodeI == int.Parse(id),
            //                source => (DictBaseTypeI)source,
            //                source => (DocumentKind)source,
            //                source => source.DocumentKindTr.ToList(),
            //                (source, dest) => ((DocumentKindTr)source).CodeI == ((DocumentKindTr)dest).CodeI && ((DocumentKindTr)source).Lang == ((DocumentKindTr)dest).Lang,
            //                rec => rec.DocumentKindTr)
            //            );
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
            //baseEng.Add("objecttype".ToLower(),
            //                new BaseDictionaryEng<ObjectType, ObjectTypeTr, DictBaseTypeI>(_dbContext, (source, id) => source.CodeI == int.Parse(id),
            //                source => (DictBaseTypeI)source,
            //                source => (ObjectType)source,
            //                source => source.ObjectTypeTr.ToList(),
            //                (source, dest) => ((ObjectTypeTr)source).CodeI == ((ObjectTypeTr)dest).CodeI && ((ObjectTypeTr)source).Lang == ((ObjectTypeTr)dest).Lang,
            //                rec => rec.ObjectTypeTr)
            //            );
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
                    sors => (DictBaseTypeI) sors,
                    sors => (TypePlaceParam) sors,
                    sors => sors.TypePlaceParamTr.ToList(),
                    (sors, dest) => ((TypePlaceParamTr) sors).CodeI == ((TypePlaceParamTr) dest).CodeI &&
                                    ((TypePlaceParamTr) sors).Lang == ((TypePlaceParamTr) dest).Lang,
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
            baseEng.Add("systemconstant",
                new BaseDictionaryEng<SystemConstant, SystemConstantTr, DictBaseTypeI>(_dbContext,
                    (sors, id) => sors.CodeI == int.Parse(id),
                    sors => sors,
                    sors => sors,
                    sors => sors.SystemConstantTr.ToList(),
                    (sors, dest) => sors.CodeI == dest.CodeI && sors.Lang == dest.Lang,
                    rec => rec.SystemConstantTr));

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

            retDictionary.Add("Communities",
                await _dbContext.getViewData("select t2.name, t2.custId from community t1 join vCustomer t2 on t2.custId = t1.custId", new SqlParameter[0]));

            return Json(retDictionary);
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
    }
}
