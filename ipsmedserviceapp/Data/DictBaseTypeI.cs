using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ipsFormsDesign.Dictionary
{
    public class DictBaseTypeI
    {
        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<DictTrI> DictTrI { get; set; }
        #region convert to dictionary objects and 
        // ActivityType
        public static implicit operator ActivityType(DictBaseTypeI test)
        {
            return new ActivityType { CodeI = test.CodeI, Name = test.Name, ActivityTypeTr = test.DictTrI.Select(rec => new ActivityTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ActivityType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ActivityTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator AgreementStatus(DictBaseTypeI test)
        {
            return new AgreementStatus { CodeI = test.CodeI, Name = test.Name, AgreementStatusTr = test.DictTrI.Select(rec => new AgreementStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(AgreementStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.AgreementStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator AgrLicenseType(DictBaseTypeI test)
        {
            return new AgrLicenseType { CodeI = test.CodeI, Name = test.Name, AgrLicenseTypeTr = test.DictTrI.Select(rec => new AgrLicenseTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(AgrLicenseType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.AgrLicenseTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator AnketaStatus(DictBaseTypeI test)
        {
            return new AnketaStatus { CodeI = test.CodeI, Name = test.Name, AnketaStatusTr = test.DictTrI.Select(rec => new AnketaStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(AnketaStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.AnketaStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CategoryStatusType(DictBaseTypeI test)
        {
            return new CategoryStatusType { CodeI = test.CodeI, Name = test.Name, CategoryStatusTypeTr = test.DictTrI.Select(rec => new CategoryStatusTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CategoryStatusType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CategoryStatusTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator Continent(DictBaseTypeI test)
        {
            return new Continent { CodeI = test.CodeI, Name = test.Name, ContinentTr = test.DictTrI.Select(rec => new ContinentTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(Continent test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ContinentTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CopyrightKind(DictBaseTypeI test)
        {
            return new CopyrightKind { CodeI = test.CodeI, Name = test.Name, CopyrightKindTr = test.DictTrI.Select(rec => new CopyrightKindTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CopyrightKind test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CopyrightKindTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CopyrightType(DictBaseTypeI test)
        {
            return new CopyrightType { CodeI = test.CodeI, Name = test.Name, CopyrightTypeTr = test.DictTrI.Select(rec => new CopyrightTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CopyrightType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CopyrightTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CreativeRoleType(DictBaseTypeI test)
        {
            return new CreativeRoleType { CodeI = test.CodeI, Name = test.Name, CreativeRoleTypeTr = test.DictTrI.Select(rec => new CreativeRoleTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CreativeRoleType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CreativeRoleTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CrkindGroup(DictBaseTypeI test)
        {
            return new CrkindGroup { CodeI = test.CodeI, Name = test.Name, CrkindGroupTr = test.DictTrI.Select(rec => new CrkindGroupTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CrkindGroup test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CrkindGroupTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CustomerStatus(DictBaseTypeI test)
        {
            return new CustomerStatus { CodeI = test.CodeI, Name = test.Name, CustomerStatusTr = test.DictTrI.Select(rec => new CustomerStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CustomerStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CustomerStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator CustomerType(DictBaseTypeI test)
        {
            return new CustomerType { CodeI = test.CodeI, Name = test.Name, CustomerTypeTr = test.DictTrI.Select(rec => new CustomerTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CustomerType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CustomerTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DocumentKind(DictBaseTypeI test)
        {
            return new DocumentKind { CodeI = test.CodeI, Name = test.Name, DocumentKindTr = test.DictTrI.Select(rec => new DocumentKindTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(DocumentKind test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.DocumentKindTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PopGenre(DictBaseTypeI test)
        {
            return new PopGenre { Id = test.CodeI, Name = test.Name, PopGenreTr = test.DictTrI.Select(rec => new PopGenreTr { Id = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PopGenre test)
        {
            return new DictBaseTypeI { CodeI = test.Id, Name = test.Name, DictTrI = test.PopGenreTr.Select(rec => new DictTrI { CodeI = rec.Id, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator LegalBasis(DictBaseTypeI test)
        {
            return new LegalBasis { CodeI = test.CodeI, Name = test.Name, LegalBasisTr = test.DictTrI.Select(rec => new LegalBasisTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(LegalBasis test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.LegalBasisTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator LicenseType(DictBaseTypeI test)
        {
            return new LicenseType { CodeI = test.CodeI, Name = test.Name, LicenseTypeTr = test.DictTrI.Select(rec => new LicenseTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(LicenseType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.LicenseTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator ObjectStatus(DictBaseTypeI test)
        {
            return new ObjectStatus { CodeI = test.CodeI, Name = test.Name, ObjectStatusTr = test.DictTrI.Select(rec => new ObjectStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ObjectStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ObjectStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator ObjectType(DictBaseTypeI test)
        {
            return new ObjectType { CodeI = test.CodeI, Name = test.Name, ObjectTypeTr = test.DictTrI.Select(rec => new ObjectTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ObjectType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ObjectTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PaymentKind(DictBaseTypeI test)
        {
            return new PaymentKind { CodeI = test.CodeI, Name = test.Name, PaymentKindTr = test.DictTrI.Select(rec => new PaymentKindTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PaymentKind test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PaymentKindTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PaymentStatus(DictBaseTypeI test)
        {
            return new PaymentStatus { CodeI = test.CodeI, Name = test.Name, PaymentStatusTr = test.DictTrI.Select(rec => new PaymentStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PaymentStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PaymentStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PayMethodType(DictBaseTypeI test)
        {
            return new PayMethodType { CodeI = test.CodeI, Name = test.Name, PayMethodTypeTr = test.DictTrI.Select(rec => new PayMethodTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PayMethodType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PayMethodTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator Period(DictBaseTypeI test)
        {
            return new Period { CodeI = test.CodeI, Name = test.Name, PeriodTr = test.DictTrI.Select(rec => new PeriodTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(Period test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PeriodTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator PositionType(DictBaseTypeI test)
        {
            return new PositionType { CodeI = test.CodeI, Name = test.Name, PositionTypeTr = test.DictTrI.Select(rec => new PositionTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(PositionType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.PositionTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator Region(DictBaseTypeI test)
        {
            return new Region { CodeI = test.CodeI, Name = test.Name, RegionTr = test.DictTrI.Select(rec => new RegionTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(Region test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.RegionTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator RegisterStatus(DictBaseTypeI test)
        {
            return new RegisterStatus { CodeI = test.CodeI, Name = test.Name, RegisterStatusTr = test.DictTrI.Select(rec => new RegisterStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(RegisterStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.RegisterStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator ResidentType(DictBaseTypeI test)
        {
            return new ResidentType { CodeI = test.CodeI, Name = test.Name, ResidentTypeTr = test.DictTrI.Select(rec => new ResidentTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ResidentType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ResidentTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator SexType(DictBaseTypeI test)
        {
            return new SexType { CodeI = test.CodeI, Name = test.Name, SexTypeTr = test.DictTrI.Select(rec => new SexTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(SexType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.SexTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator TypePlace(DictBaseTypeI test)
        {
            return new TypePlace { CodeI = test.CodeI, Name = test.Name, TypePlaceTr = test.DictTrI.Select(rec => new TypePlaceTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(TypePlace test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.TypePlaceTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator TypeVat(DictBaseTypeI test)
        {
            return new TypeVat { CodeI = test.CodeI, Name = test.Name, TypeVattr = test.DictTrI.Select(rec => new TypeVattr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(TypeVat test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.TypeVattr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // AlgorithmType
        public static implicit operator AlgorithmType(DictBaseTypeI test)
        {
            return new AlgorithmType { CodeI = test.CodeI, Name = test.Name, AlgorithmTypeTr = test.DictTrI.Select(rec => new AlgorithmTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(AlgorithmType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.AlgorithmTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // SeekType
        public static implicit operator SeekType(DictBaseTypeI test)
        {
            return new SeekType { CodeI = test.CodeI, Name = test.Name, SeekTypeTr = test.DictTrI.Select(rec => new SeekTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(SeekType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.SeekTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // SeekType
        public static implicit operator ObjAct(DictBaseTypeI test)
        {
            return new ObjAct { CodeI = test.CodeI, Name = test.Name, ObjActTr = test.DictTrI.Select(rec => new ObjActTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(ObjAct test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.ObjActTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // Category
        public static implicit operator Category(DictBaseTypeI test)
        {
            return new Category { CodeI = test.CodeI, Name = test.Name, CategoryTr = test.DictTrI.Select(rec => new CategoryTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(Category test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CategoryTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // CrightStatus
        public static implicit operator CrightStatus(DictBaseTypeI test)
        {
            return new CrightStatus { CodeI = test.CodeI, Name = test.Name, CrightStatusTr = test.DictTrI.Select(rec => new CrightStatusTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(CrightStatus test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.CrightStatusTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // RholderType
        public static implicit operator RholderType(DictBaseTypeI test)
        {
            return new RholderType { CodeI = test.CodeI, Name = test.Name, RholderTypeTr = test.DictTrI.Select(rec => new RholderTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(RholderType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.RholderTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // TypeMethodGet
        public static implicit operator TypeMethodGet(DictBaseTypeI test)
        {
            return new TypeMethodGet { CodeI = test.CodeI, Name = test.Name, TypeMethodGetTr = test.DictTrI.Select(rec => new TypeMethodGetTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(TypeMethodGet test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.TypeMethodGetTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // GenreType
        public static implicit operator GenreType(DictBaseTypeI test)
        {
            return new GenreType { CodeI = test.CodeI, Name = test.Name, GenreTypeTr = test.DictTrI.Select(rec => new GenreTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(GenreType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.GenreTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // WorkType
        public static implicit operator WorkType(DictBaseTypeI test)
        {
            return new WorkType { CodeI = test.CodeI, Name = test.Name, WorkTypeTr = test.DictTrI.Select(rec => new WorkTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(WorkType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.WorkTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // AgreementType
        public static implicit operator AgreementType(DictBaseTypeI test)
        {
            return new AgreementType { CodeI = test.CodeI, Name = test.Name, AgreementTypeTr = test.DictTrI.Select(rec => new AgreementTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(AgreementType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.AgreementTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // DocumentType
        public static implicit operator DocumentType(DictBaseTypeI test)
        {
            return new DocumentType { CodeI = test.CodeI, Name = test.Name, DocumentTypeTr = test.DictTrI.Select(rec => new DocumentTypeTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(DocumentType test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.DocumentTypeTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        // SystemConstant
        public static implicit operator SystemConstant(DictBaseTypeI test)
        {
            return new SystemConstant { CodeI = test.CodeI, Name = test.Name, SystemConstantTr = test.DictTrI.Select(rec => new SystemConstantTr { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeI(SystemConstant test)
        {
            return new DictBaseTypeI { CodeI = test.CodeI, Name = test.Name, DictTrI = test.SystemConstantTr.Select(rec => new DictTrI { CodeI = rec.CodeI, Name = rec.Name, Lang = rec.Lang }).ToList() };
        }

        #endregion

    }


    public class DictBaseTypeS
    {
        public string CodeS { get; set; }
        public string Name { get; set; }

        public ICollection<DictTrS> RegionTr { get; set; }

        // Lang
        #region 
        // Country
        public static implicit operator Country(DictBaseTypeS test)
        {
            return new Country { CountryCode = test.CodeS, CountryName = test.Name, CountryTr = test.RegionTr.Select(rec => new CountryTr { CountryCode = rec.CodeS, CountryName = rec.Name, Lang = rec.Lang }).ToList() };
        }
        public static implicit operator DictBaseTypeS(Country test)
        {
            return new DictBaseTypeS { CodeS = test.CountryCode, Name = test.CountryName, RegionTr = test.CountryTr.Select(rec => new DictTrS { CodeS = rec.CountryCode, Name = rec.CountryName, Lang = rec.Lang }).ToList() };
        }
        #endregion
    }

}
