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
            //                new BaseDictionaryEng<DocumentKind, DocumentKindTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
            //                sors => (DictBaseTypeI)sors,
            //                sors => (DocumentKind)sors,
            //                sors => sors.DocumentKindTr.ToList(),
            //                (sors, dest) => ((DocumentKindTr)sors).CodeI == ((DocumentKindTr)dest).CodeI && ((DocumentKindTr)sors).Lang == ((DocumentKindTr)dest).Lang,
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
            //                new BaseDictionaryEng<ObjectType, ObjectTypeTr, DictBaseTypeI>(_dbContext, (sors, id) => sors.CodeI == int.Parse(id),
            //                sors => (DictBaseTypeI)sors,
            //                sors => (ObjectType)sors,
            //                sors => sors.ObjectTypeTr.ToList(),
            //                (sors, dest) => ((ObjectTypeTr)sors).CodeI == ((ObjectTypeTr)dest).CodeI && ((ObjectTypeTr)sors).Lang == ((ObjectTypeTr)dest).Lang,
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

        ///// <summary>
        ///// Оновити дані складного довідника
        ///// </summary>
        ///// <param name="dictionaryName"></param>
        ///// <param name="id"></param>
        ///// <param name="dataJObject"></param>
        ///// <returns></returns>
        //[HttpPut("complex/update/{dictionaryName}/{id}")]
        //public async Task<IActionResult> SaveComplexDictionary(string dictionaryName, string id, [FromBody]JObject dataJObject)
        //{
        //    IDbContextTransaction transaction = null;
        //    try
        //    {
        //        if(_complexDictionaryList.Contains(dictionaryName.ToLower()))
        //        switch (dictionaryName.ToLower())
        //        {
        //            case "copyrightkind":
        //                // convert copyrughtkind from JSON
        //                var copyrightKind = dataJObject.ToObject<CopyrightKind>();
        //                if (copyrightKind == null)
        //                    return NotFound("CopyrightKind not found!");
        //                //get copyrughtkind from DB by id
        //                var destination = await _dbContext.CopyrightKind
        //                    .Include(item => item.CopyrightKindTr)
        //                    .SingleOrDefaultAsync(rec => rec.CodeI == Convert.ToInt32(id));
        //                //update copyrightKind data 
        //                destination.SetFields(copyrightKind);
        //                // update CopyrightKindTr list
        //                foreach (var kindTr in copyrightKind.CopyrightKindTr)
        //                {
        //                    //get dictionary tr with current lang
        //                    var kind = destination.CopyrightKindTr.SingleOrDefault(rec => rec.Lang == kindTr.Lang);
        //                    //if not exist 
        //                    if (kind == null)    
        //                        destination.CopyrightKindTr.Add(new CopyrightKindTr
        //                        {
        //                            CodeI = kindTr.CodeI,
        //                            Lang = kindTr.Lang,
        //                            Name = kindTr.Name,
        //                        });
        //                    else
        //                        kind.SetFields(kindTr,new []{"Lang"});
        //                }
        //                    break;
        //                case "country":
        //                    // convert country object from json
        //                    var objCountryForNewData = dataJObject.ToObject<Country>();
        //                    //check on valid state
        //                    if (objCountryForNewData == null)
        //                        return NotFound("Country not found!");
        //                    //get country from DB by id
        //                    var getCountryDictionaryFromDB = await _dbContext.Country
        //                        .Include(item => item.CountryTr)
        //                        .SingleOrDefaultAsync(findById => findById.CountryCode == id);
        //                    //update country data
        //                    getCountryDictionaryFromDB.SetFields(objCountryForNewData);
        //                    //update country list
        //                    foreach(var dict in objCountryForNewData.CountryTr)
        //                    {
        //                        //get dictionary tr with current lang
        //                        var newLangValue = getCountryDictionaryFromDB.CountryTr.SingleOrDefault(find => find.Lang == dict.Lang);
        //                        //if not exist
        //                        if (newLangValue == null)
        //                        {
        //                            //if not exist
        //                            getCountryDictionaryFromDB.CountryTr.Add(new CountryTr
        //                            {
        //                                CountryCode = dict.CountryCode,
        //                                Lang = dict.Lang,
        //                                CountryName = dict.CountryName,
        //                            });
        //                        }
        //                        else
        //                        {
                                    
        //                            getCountryDictionaryFromDB.SetFields(dict, new[] { "Lang" });
        //                        }
        //                    }
        //                    break;
        //                case "creativeroletype":
        //                    //convert creativeroletype object from json
        //                    var objCreativeForNewData = dataJObject.ToObject<CreativeRoleType>();
        //                    //check on valid state
        //                    if (objCreativeForNewData == null)
        //                        return NotFound("Country not found!");
        //                    //get creartiveroletype from DB by id
        //                    var getCreativeDictionaryFromDB = await _dbContext.CreativeRoleType
        //                        .Include(item => item.CreativeRoleTypeTr)
        //                        .SingleOrDefaultAsync(item => item.CodeI == Convert.ToInt32(id));
        //                    //update creativeRoleType data
        //                    getCreativeDictionaryFromDB.SetFields(objCreativeForNewData);
        //                    //update creativeroletype list
        //                    foreach(var dict in objCreativeForNewData.CreativeRoleTypeTr)
        //                    {
        //                        //get dictionary tr with current lang
        //                        var newLangCreative = getCreativeDictionaryFromDB.CreativeRoleTypeTr.SingleOrDefault(rec => rec.Lang == dict.Lang);
        //                        //if not exist
        //                        if (newLangCreative == null)
        //                        {
        //                            //if not exist
        //                            getCreativeDictionaryFromDB.CreativeRoleTypeTr.Add(new CreativeRoleTypeTr
        //                            {
        //                                CodeI = dict.CodeI,
        //                                Lang = dict.Lang,
        //                                Name = dict.Name,
        //                            });
        //                        }
        //                        else
        //                        {
        //                            getCreativeDictionaryFromDB.SetFields(dict, new[] { "Lang" });
        //                        }
        //                    }
        //                    break;
        //                case "genretype":
        //                    //convert genretype object from json
        //                    var objGenreForNewData = dataJObject.ToObject<GenreType>();
        //                    //check on valid state
        //                    if (objGenreForNewData == null)
        //                        return NotFound("Genre not found!");
        //                    //get genre from DB by id
        //                    var getGenreDictionaryFromDB = await _dbContext.GenreType
        //                        .Include(item => item.GenreTypeTr)
        //                        .SingleOrDefaultAsync(item => item.CodeI == Convert.ToInt32(id));
        //                    //update genretype data
        //                    getGenreDictionaryFromDB.SetFields(objGenreForNewData);
        //                    //update genretype list
        //                    foreach(var dict in objGenreForNewData.GenreTypeTr)
        //                    {
        //                        //get dictionary tr with current lang
        //                        var newLangGenre = getGenreDictionaryFromDB.GenreTypeTr.SingleOrDefault(item => item.Lang == dict.Lang);
        //                        //if not exist
        //                        if (newLangGenre == null)
        //                        {
        //                            getGenreDictionaryFromDB.GenreTypeTr.Add(new GenreTypeTr
        //                            {
        //                                CodeI = dict.CodeI,
        //                                Lang = dict.Lang,
        //                                Name = dict.Name,
        //                            });
        //                        }
        //                        else
        //                        {
        //                            getGenreDictionaryFromDB.SetFields(dict, new[] { "Lang" });
        //                        }
        //                    }
        //                    break;
        //                case "klr030":
        //                    //convert klr030 object from json
        //                    var objKLRForNewData = dataJObject.ToObject<KlR030>();
        //                    //check on valud state
        //                    if (objKLRForNewData == null)
        //                        return NotFound("KLR030 not found!");
        //                    //get KLR030 from DB by id
        //                    var getKLRDictionaryFromDB = await _dbContext.KlR030
        //                        .Include(item => item.KlR030tr)
        //                        .SingleOrDefaultAsync(item => item.CountryCode == id);
        //                    //update KLR030 data
        //                    getKLRDictionaryFromDB.SetFields(objKLRForNewData);
        //                    //update KLR030 list
        //                    foreach(var dict in objKLRForNewData.KlR030tr)
        //                    {
        //                        //get dictionary tr with current lang
        //                        var newLangKLR = getKLRDictionaryFromDB.KlR030tr.SingleOrDefault(item => item.Lang == dict.Lang);
        //                        //if not exist
        //                        if (newLangKLR == null)
        //                        {
        //                            //if not exist
        //                            getKLRDictionaryFromDB.KlR030tr.Add(new KlR030tr
        //                            {
        //                                R030 = dict.R030,
        //                                Lang = dict.Lang,
        //                                R030Name = dict.R030Name,
        //                            });
        //                        }
        //                        else
        //                        {
        //                            getKLRDictionaryFromDB.SetFields(dict, new[] { "Lang" });
        //                        }
        //                    }
        //                    break;
        //                case "systemconstant":
        //                    //convert systemconstant object from json
        //                    var objSystemConstantForNewData = dataJObject.ToObject<SystemConstant>();
        //                    //check on valid state
        //                    if (objSystemConstantForNewData == null)
        //                        return NotFound("Country not found!");
        //                    //get systemconstant from DB by id
        //                    var getSystemConstantDictionaryFromDB = await _dbContext.SystemConstant
        //                        .Include(item => item.SystemConstantTr)
        //                        .SingleOrDefaultAsync(item => item.CodeI == Convert.ToInt32(id));
        //                    //update systemconstant data
        //                    getSystemConstantDictionaryFromDB.SetFields(objSystemConstantForNewData);
        //                    //update systemconstant list
        //                    foreach (var dict in objSystemConstantForNewData.SystemConstantTr)
        //                    {
        //                        //get dictionary tr with current lang
        //                        var newLangSystemConstant = getSystemConstantDictionaryFromDB.SystemConstantTr.SingleOrDefault(rec => rec.Lang == dict.Lang);
        //                        //if not exist
        //                        if (newLangSystemConstant == null)
        //                        {
        //                            //if not exist
        //                            getSystemConstantDictionaryFromDB.SystemConstantTr.Add(new SystemConstantTr
        //                            {
        //                                CodeI = dict.CodeI,
        //                                Lang = dict.Lang,
        //                                Name = dict.Name,
        //                            });
        //                        }
        //                        else
        //                        {
        //                            getSystemConstantDictionaryFromDB.SetFields(dict, new[] { "Lang" });
        //                        }
        //                    }
        //                    break;
        //                case "typeplace":
        //                    //convert typeplace object from json
        //                    var objTypePlaceForNewData = dataJObject.ToObject<TypePlace>();
        //                    //check on valid state
        //                    if (objTypePlaceForNewData == null)
        //                        return NotFound("Country not found!");
        //                    //get typeplace from DB by id
        //                    var getTypePlaceDictionaryFromDB = await _dbContext.TypePlace
        //                        .Include(item => item.TypePlaceTr)
        //                        .SingleOrDefaultAsync(item => item.CodeI == Convert.ToInt32(id));
        //                    //update creativeRoleType data
        //                    getTypePlaceDictionaryFromDB.SetFields(objTypePlaceForNewData);
        //                    //update typeplace list
        //                    foreach (var dict in objTypePlaceForNewData.TypePlaceTr)
        //                    {
        //                        //get dictionary tr with current lang
        //                        var newLangTypePlace = getTypePlaceDictionaryFromDB.TypePlaceTr.SingleOrDefault(rec => rec.Lang == dict.Lang);
        //                        //if not exist
        //                        if (newLangTypePlace == null)
        //                        {
        //                            //if not exist
        //                            getTypePlaceDictionaryFromDB.TypePlaceTr.Add(new TypePlaceTr
        //                            {
        //                                CodeI = dict.CodeI,
        //                                Lang = dict.Lang,
        //                                Name = dict.Name,
        //                            });
        //                        }
        //                        else
        //                        {
        //                            getTypePlaceDictionaryFromDB.SetFields(dict, new[] { "Lang" });
        //                        }
        //                    }
        //                    break;
        //            }

        //        transaction = _dbContext.Database.BeginTransaction();
        //        await _dbContext.SaveChangesAsync();
        //        transaction.Commit();
        //        transaction = null;

        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        transaction?.Rollback();
        //        return BadRequest(e.Message);
        //    }
        //}

        ///// <summary>
        ///// Видалити запис з довідника по ID
        ///// </summary>
        ///// <param name="dictionaryName"></param>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete("complex/delete/{dictionaryName}/{id}")]
        //public async Task<IActionResult> DeleteComplexDictionary(string dictionaryName, string id)
        //{
        //    IDbContextTransaction transaction = null;
        //    try
        //    {
        //        if (!_complexDictionaryList.Contains(dictionaryName.ToLower()))
        //            return NotFound("Complex dictionary not found!");
        //        switch (dictionaryName.ToLower())
        //        {
        //            case "copyrightkind":
        //                var copyrightKind = await _dbContext.CopyrightKind
        //                    .Include(item => item.CopyrightKindTr)
        //                    .SingleOrDefaultAsync(rec => rec.CodeI == Convert.ToInt32(id));
        //                _dbContext.CopyrightKindTr.RemoveRange(copyrightKind.CopyrightKindTr);
        //                _dbContext.CopyrightKind.Remove(copyrightKind);
        //                break;
        //            case "country":
        //                //filter only country and find by id
        //                var countryFindedIntoDB = await _dbContext.Country
        //                 .Include(item => item.CountryTr)
        //                 .SingleOrDefaultAsync(rec => rec.CountryCode == id);
                        
        //                //remove finded dictionaries
        //                _dbContext.CountryTr.RemoveRange(countryFindedIntoDB.CountryTr);
        //                //remove finded dictionary
        //                _dbContext.Country.Remove(countryFindedIntoDB);
        //                break;
        //            case "creativeroletype":
        //                //filter only craetiveroletype and find by id
        //                var creativeFindedIntoDB = await _dbContext.CreativeRoleType
        //                    .Include(item => item.CreativeRoleTypeTr)
        //                    .SingleOrDefaultAsync(rec => rec.CodeI == Convert.ToInt32(id));
        //                //remove finded dictionaries
        //                _dbContext.CreativeRoleTypeTr.RemoveRange(creativeFindedIntoDB.CreativeRoleTypeTr);
        //                //remove finded dictionary
        //                _dbContext.CreativeRoleType.Remove(creativeFindedIntoDB);
        //                break;
        //            case "genretype":
        //                //filter only genretype and find by id
        //                var genreFindedIntoDB = await _dbContext.GenreType
        //                    .Include(item => item.GenreTypeTr)
        //                    .SingleOrDefaultAsync(rec => rec.CodeI == Convert.ToInt32(id));
        //                //remove finded dictionaries
        //                _dbContext.GenreTypeTr.RemoveRange(genreFindedIntoDB.GenreTypeTr);
        //                //remove finded dictionary
        //                _dbContext.GenreType.Remove(genreFindedIntoDB);
        //                break;
        //            case "klr030":
        //                //filter only KlR030 and find by id
        //                var klrFindedIntoDB = await _dbContext.KlR030
        //                    .Include(item => item.KlR030tr)
        //                    .SingleOrDefaultAsync(rec => rec.R030 == id );
        //                //remove finded dictionaries
        //                _dbContext.KlR030tr.RemoveRange(klrFindedIntoDB.KlR030tr);
        //                //remove finded dictionary
        //                _dbContext.KlR030.Remove(klrFindedIntoDB);
        //                break;
        //            case "systemconstant":
        //                //filter only systemconstant and find by id
        //                var systemConstantFindedIntoDB = await _dbContext.SystemConstant
        //                 .Include(item => item.SystemConstantTr)
        //                 .SingleOrDefaultAsync(rec => rec.CodeI == Convert.ToInt32(id));

        //                //remove finded dictionaries
        //                _dbContext.SystemConstantTr.RemoveRange(systemConstantFindedIntoDB.SystemConstantTr);
        //                //remove finded dictionary
        //                _dbContext.SystemConstant.Remove(systemConstantFindedIntoDB);
        //                break;
        //            case "typeplace":
        //                //filter only typeplace and find by id
        //                var typePlaceFindedIntoDB = await _dbContext.TypePlace
        //                 .Include(item => item.TypePlaceTr)
        //                 .SingleOrDefaultAsync(rec => rec.CodeI == Convert.ToInt32(id));

        //                //remove finded dictionaries
        //                _dbContext.TypePlaceTr.RemoveRange(typePlaceFindedIntoDB.TypePlaceTr);
        //                //remove finded dictionary
        //                _dbContext.TypePlace.Remove(typePlaceFindedIntoDB);
        //                break;
        //        }

        //        transaction = await _dbContext.Database.BeginTransactionAsync();
        //        await _dbContext.SaveChangesAsync();
        //        transaction.Commit();
        //        transaction = null;
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        transaction?.Rollback();
        //        return BadRequest(e.Message);
        //    }
        //}

        ///// <summary>
        ///// Додати запис в довідник
        ///// </summary>
        ///// <param name="dictionaryName"></param>
        ///// <param name="dataJObject"></param>
        ///// <returns></returns>
        //[HttpPost("complex/addnew/{dictionaryName}")]
        //public async Task<IActionResult> AddComplexDictionary(string dictionaryName, [FromBody] JObject dataJObject)
        //{
        //    IDbContextTransaction transaction = null;
        //    try
        //    {
        //        if (!_complexDictionaryList.Contains(dictionaryName.ToLower()))
        //            return NotFound("Complex dictionary not found!");
        //        switch (dictionaryName.ToLower())
        //        {
        //            case "copyrightkind":
        //                var destinationCopyrightKind = new CopyrightKind();
        //                var copyrightKind = dataJObject.ToObject<CopyrightKind>();
        //                if (copyrightKind == null)
        //                    return NotFound("Data object not found!");

        //                destinationCopyrightKind.SetFields(copyrightKind);
        //                foreach (var kindTr in copyrightKind.CopyrightKindTr)
        //                {
        //                    var kind = new CopyrightKindTr();
        //                    kind.SetFields(kindTr);
        //                    destinationCopyrightKind.CopyrightKindTr.Add(kind);
        //                }

        //                await _dbContext.CopyrightKind.AddAsync(destinationCopyrightKind);
        //                await _dbContext.CopyrightKindTr.AddRangeAsync(destinationCopyrightKind.CopyrightKindTr);

        //                break;
        //            case "country":
        //                //initialize object Country for add new data
        //                var countryNewData = new Country();
        //                //convert to Country input data
        //                var inputCountryData = dataJObject.ToObject<Country>();
        //                //check valid state
        //                if (inputCountryData == null)
        //                    return NotFound("Data object not found!");
        //                //save new object Country
        //                countryNewData.SetFields(inputCountryData);
        //                //save every dictionary
        //                foreach(var dict in inputCountryData.CountryTr)
        //                {
        //                    //initialize obj for next add
        //                    var country = new CountryTr();
        //                    //add field data
        //                    country.SetFields(dict);
        //                    //add new country object
        //                    countryNewData.CountryTr.Add(country);
        //                }
        //                //add new object to DB
        //                await _dbContext.Country.AddAsync(countryNewData);
        //                //add new dictionaries
        //                await _dbContext.CountryTr.AddRangeAsync(countryNewData.CountryTr);
        //                break;
        //            case "creativeroletype":
        //                //initialize object CreativeRoleType for add new data
        //                var creativeNewData = new CreativeRoleType();
        //                //convert to CreativeRoleType input data
        //                var inputCreativeData = dataJObject.ToObject<CreativeRoleType>();
        //                //check valid state
        //                if (inputCreativeData == null)
        //                    return NotFound("Data object not found!");
        //                //save new object CreativeRoleType
        //                creativeNewData.SetFields(inputCreativeData);
        //                //save every dictionary
        //                foreach(var dict in inputCreativeData.CreativeRoleTypeTr)
        //                {
        //                    //initialize obj for next add
        //                    var creative = new CreativeRoleTypeTr();
        //                    //add field data
        //                    creative.SetFields(dict);
        //                    //add new CreativeRoleType object
        //                    creativeNewData.CreativeRoleTypeTr.Add(creative);
        //                }
        //                //add new object to DB
        //                await _dbContext.CreativeRoleType.AddAsync(creativeNewData);
        //                //add new dictionaries
        //                await _dbContext.CreativeRoleTypeTr.AddRangeAsync(creativeNewData.CreativeRoleTypeTr);
        //                break;
        //            case "genretype":
        //                //initialize object GenreType for add new data
        //                var genreNewData = new GenreType();
        //                //convert to GenreType input data
        //                var inputGenreData = dataJObject.ToObject<GenreType>();
        //                //check valid state
        //                if (inputGenreData == null)
        //                    return NotFound("Data object not found!");
        //                //save new object GenreType
        //                genreNewData.SetFields(inputGenreData);
        //                //save every dictionary
        //                foreach(var dict in inputGenreData.GenreTypeTr)
        //                {
        //                    //initialize obj for next add
        //                    var genre = new GenreTypeTr();
        //                    //add field data
        //                    genre.SetFields(dict);
        //                    //add new genretyoe object
        //                    genreNewData.GenreTypeTr.Add(genre);
        //                }
        //                //add new object to DB
        //                await _dbContext.GenreType.AddAsync(genreNewData);
        //                //add new dictionaries
        //                await _dbContext.GenreTypeTr.AddRangeAsync(genreNewData.GenreTypeTr);
        //                break;
        //            case "systemconstant":
        //                //initialize object systemConstant for add new data
        //                var systemConstantNewData = new SystemConstant();
        //                //convert to SystemConstant input data
        //                var inputSystemConstantNewData = dataJObject.ToObject<SystemConstant>();
        //                //check valid state
        //                if (inputSystemConstantNewData == null)
        //                    return NotFound("Data object not found!");
        //                //save new object SystemConstant
        //                systemConstantNewData.SetFields(inputSystemConstantNewData);
        //                //save every dictionary
        //                foreach(var dict in inputSystemConstantNewData.SystemConstantTr)
        //                {
        //                    //initialize obj for next add
        //                    var systemConstant = new SystemConstantTr();
        //                    //add field data
        //                    systemConstant.SetFields(dict);
        //                    //add new KlR030 object
        //                    systemConstantNewData.SystemConstantTr.Add(systemConstant);
        //                }
        //                //add new object to DB
        //                await _dbContext.SystemConstant.AddAsync(systemConstantNewData);
        //                //add new dictionaries
        //                await _dbContext.SystemConstantTr.AddRangeAsync(systemConstantNewData.SystemConstantTr);
        //                break;
        //            case "typeplace":
        //                //initialize object typeplace for add new data
        //                var typePlaceNewData = new TypePlace();
        //                //convert to TypePlace input data
        //                var inputTypePlaceData = dataJObject.ToObject<TypePlace>();
        //                //check valid state
        //                if (inputTypePlaceData == null)
        //                    return NotFound("Data object not found!");
        //                //save new object Country
        //                typePlaceNewData.SetFields(inputTypePlaceData);
        //                //save every dictionary
        //                foreach (var dict in inputTypePlaceData.TypePlaceTr)
        //                {
        //                    //initialize obj for next add
        //                    var typePlace = new TypePlaceTr();
        //                    //add field data
        //                    typePlace.SetFields(dict);
        //                    //add new country object
        //                    typePlaceNewData.TypePlaceTr.Add(typePlace);
        //                }
        //                //add new object to DB
        //                await _dbContext.TypePlace.AddAsync(typePlaceNewData);
        //                //add new dictionaries
        //                await _dbContext.TypePlaceTr.AddRangeAsync(typePlaceNewData.TypePlaceTr);
        //                break;
        //        }

        //        transaction = await _dbContext.Database.BeginTransactionAsync();
        //        await _dbContext.SaveChangesAsync();
        //        transaction.Commit();
        //        transaction = null;

        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        transaction?.Rollback();
        //        return BadRequest(e.Message);
        //    }
        //}

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

            _dbContext.UpdateList(sors.CopyrightKindTr, target.CopyrightKindTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            target.SetFields(sors);

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
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPost("extra/creativeroletype")]
        public async Task<IActionResult> CreateCreativeRoleType([FromBody] CreativeRoleType sors)
        {
            var dest = new CreativeRoleType();

            dest.SetFields(sors);
            _dbContext.AppendList(sors.CreativeRoleTypeTr, dest.CreativeRoleTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            _dbContext.CreativeRoleType.Add(dest);
            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPut("extra/creativeroletype/{id}")]
        public async Task<IActionResult> UpdateCreativeRoleType(int id, [FromBody] CreativeRoleType sors)
        {
            var dest = await _dbContext.CreativeRoleType.Where(rec => rec.CodeI == id)
                                .Include(rec => rec.CreativeRoleTypeTr)
                                .FirstOrDefaultAsync();
            if (dest == null)
                return NotFound();

            _dbContext.UpdateList(sors.CreativeRoleTypeTr, dest.CreativeRoleTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            dest.SetFields(sors);

            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("extra/creativeroletype/{id}")]
        public async Task<IActionResult> DeleteCreativeRoleType(int id)
        {
            var delRow = await _dbContext.CreativeRoleType.Where(rec => rec.CodeI == id)
                                .Include(rec => rec.CreativeRoleTypeTr)
                                .FirstOrDefaultAsync();
            if (delRow == null)
                return NotFound();

            _dbContext.CreativeRoleTypeTr.RemoveRange(delRow.CreativeRoleTypeTr);
            _dbContext.CreativeRoleType.Remove(delRow);

            IDbContextTransaction transaction = null;
            try
            {
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
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPost("extra/genretype")]
        public async Task<IActionResult> CreateGenreType([FromBody] GenreType sors)
        {
            var dest = new GenreType();

            dest.SetFields(sors);
            _dbContext.AppendList(sors.GenreTypeTr, dest.GenreTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            _dbContext.GenreType.Add(dest);
            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sors"></param>
        /// <returns></returns>
        [HttpPut("extra/genretype/{id}")]
        public async Task<IActionResult> UpdateGenreType(int id, [FromBody] GenreType sors)
        {
            var dest = await _dbContext.GenreType.Where(rec => rec.CodeI == id)
                                .Include(rec => rec.GenreTypeTr)
                                .FirstOrDefaultAsync();
            if (dest == null)
                return NotFound();

            _dbContext.UpdateList(sors.GenreTypeTr, dest.GenreTypeTr, i => { }, (l, r) => l.CodeI == r.CodeI && l.Lang == r.Lang);
            dest.SetFields(sors);

            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("extra/genretype/{id}")]
        public async Task<IActionResult> DeleteGenreType(int id)
        {
            var delRow = await _dbContext.GenreType.Where(rec => rec.CodeI == id)
                                .Include(rec => rec.GenreTypeTr)
                                .FirstOrDefaultAsync();
            if (delRow == null)
                return NotFound();

            _dbContext.GenreTypeTr.RemoveRange(delRow.GenreTypeTr);
            _dbContext.GenreType.Remove(delRow);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        #endregion

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
