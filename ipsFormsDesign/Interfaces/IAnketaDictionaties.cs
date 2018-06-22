using System;
using System.Collections.Generic;
using System.Text;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;

namespace ipsFormsDesign.Interfaces
{
    public interface ICunsomerDic
    {
        IList<ActivityType> activityType { get; set; }
        IList<AgrLicenseType> agrLicenseType { get; set; }
        IList<AgreementStatus> agreementStatus { get; set; }
        IList<AgreementType> agreementType { get; set; }
        IList<AnketaStatus> anketaStatus { get; set; }
        IList<CopyrightKind> copyrightKind { get; set; }
        IList<CopyrightType> copyrightType { get; set; }
        IList<Country> country { get; set; }
        IList<CrkindGroup> crkindGroup { get; set; }
        IList<CustomerStatus> customerStatus { get; set; }
        IList<CustomerType> customerType { get; set; }
        IList<KlR030> klR030 { get; set; }
        IList<LicenseClass> licenseClass { get; set; }
        IList<LicenseType> licenseType { get; set; }
        IList<Period> period { get; set; }
        IList<PeriodStatus> periodStatus { get; set; }
        IList<PositionType> positionType { get; set; }
        IList<Region> region { get; set; }
        IList<ResidentType> residentType { get; set; }
        IList<SexType> sexType { get; set; }
        IList<TypeMethodGet> typeMethodGet { get; set; }
        IList<TypePlace> typePlace { get; set; }
        IList<TypeVat> typeVat { get; set; }
        IList<UserRoleType> userRoleType { get; set; }
        IList<UsesKind> usesKind { get; set; }
        IList<UsesType> usesType { get; set; }
        IList<CommunityInfo> communities { get; set; }
    }

    public class AnketaDictionaties : ICunsomerDic
    {
        public IList<ActivityType> activityType {get; set;}
        public IList<AgrLicenseType> agrLicenseType {get; set;}
        public IList<AgreementStatus> agreementStatus {get; set;}
        public IList<AgreementType> agreementType {get; set;}
        public IList<AnketaStatus> anketaStatus {get; set;}
        public IList<CopyrightKind> copyrightKind {get; set;}
        public IList<CopyrightType> copyrightType {get; set;}
        public IList<Country> country {get; set;}
        public IList<CrkindGroup> crkindGroup {get; set;}
        public IList<CustomerStatus> customerStatus {get; set;}
        public IList<CustomerType> customerType {get; set;}
        public IList<KlR030> klR030 {get; set;}
        public IList<LicenseClass> licenseClass {get; set;}
        public IList<LicenseType> licenseType {get; set;}
        public IList<Period> period {get; set;}
        public IList<PeriodStatus> periodStatus {get; set;}
        public IList<PositionType> positionType {get; set;}
        public IList<Region> region {get; set;}
        public IList<ResidentType> residentType {get; set;}
        public IList<SexType> sexType {get; set;}
        public IList<TypePlace> typePlace {get; set;}
        public IList<TypeVat> typeVat {get; set;}
        public IList<UserRoleType> userRoleType {get; set;}
        public IList<UsesKind> usesKind {get; set;}
        public IList<UsesType> usesType {get; set;}
        public IList<TypeMethodGet> typeMethodGet { get; set; }
        public IList<CommunityInfo> communities { get; set; }
    }


    public class ObjectRightDictionaries
    {
        public IList<Category> category {get; set; }
        public IList<CopyrightType> copyrightType {get; set; }
        public IList<CreativeRoleType> creativeRoleType {get; set; }
        public IList<EtGenre> etGenre {get; set; }
        public IList<EtRole> etRole {get; set; }
        public IList<GenreType> genreType {get; set; }
        public IList<LegalBasis> legalBasis {get; set; }
        public IList<ObjAct> objAct {get; set; }
        public IList<ObjectStatus> objectStatus {get; set; }
        public IList<PermitType> permitType {get; set; }
        public IList<SeekType> seekType {get; set; }
        public IList<SpecType> specType {get; set; }
        public IList<SpecType> folkType { get; set; }
    }
}
