using System;
using System.Collections.Generic;
using System.Text;
using ipsFormsDesign.Dictionary;
using ipsmedserviceapp.Model;

namespace ipsFormsDesign.Interfaces
{
    public interface ICunsomerDic
    {
        IList<IActivityType> activityType { get; set; }
        IList<IAgrLicenseType> agrLicenseType { get; set; }
        IList<IAgreementStatus> agreementStatus { get; set; }
        IList<IAgreementType> agreementType { get; set; }
        IList<IAnketaStatus> anketaStatus { get; set; }
        IList<ICopyrightKind> copyrightKind { get; set; }
        IList<ICopyrightType> copyrightType { get; set; }
        IList<ICountry> country { get; set; }
        IList<ICrkindGroup> crkindGroup { get; set; }
        IList<ICustomerStatus> customerStatus { get; set; }
        IList<ICustomerType> customerType { get; set; }
        IList<IKlR030> klR030 { get; set; }
        IList<ILicenseClass> licenseClass { get; set; }
        IList<ILicenseType> licenseType { get; set; }
        IList<IPeriod> period { get; set; }
        IList<IPeriodStatus> periodStatus { get; set; }
        IList<IPositionType> positionType { get; set; }
        IList<IRegion> region { get; set; }
        IList<IResidentType> residentType { get; set; }
        IList<ISexType> sexType { get; set; }
        IList<ITypePlace> typePlace { get; set; }
        IList<ITypeVat> typeVat { get; set; }
        IList<IUserRoleType> userRoleType { get; set; }
        IList<IUsesKind> usesKind { get; set; }
        IList<IUsesType> usesType { get; set; }

    }

    public class AnketaDictionaties : ICunsomerDic
    {
        public IList<IActivityType> activityType {get; set;}
        public IList<IAgrLicenseType> agrLicenseType {get; set;}
        public IList<IAgreementStatus> agreementStatus {get; set;}
        public IList<IAgreementType> agreementType {get; set;}
        public IList<IAnketaStatus> anketaStatus {get; set;}
        public IList<ICopyrightKind> copyrightKind {get; set;}
        public IList<ICopyrightType> copyrightType {get; set;}
        public IList<ICountry> country {get; set;}
        public IList<ICrkindGroup> crkindGroup {get; set;}
        public IList<ICustomerStatus> customerStatus {get; set;}
        public IList<ICustomerType> customerType {get; set;}
        public IList<IKlR030> klR030 {get; set;}
        public IList<ILicenseClass> licenseClass {get; set;}
        public IList<ILicenseType> licenseType {get; set;}
        public IList<IPeriod> period {get; set;}
        public IList<IPeriodStatus> periodStatus {get; set;}
        public IList<IPositionType> positionType {get; set;}
        public IList<IRegion> region {get; set;}
        public IList<IResidentType> residentType {get; set;}
        public IList<ISexType> sexType {get; set;}
        public IList<ITypePlace> typePlace {get; set;}
        public IList<ITypeVat> typeVat {get; set;}
        public IList<IUserRoleType> userRoleType {get; set;}
        public IList<IUsesKind> usesKind {get; set;}
        public IList<IUsesType> usesType {get; set;}
    }
}
