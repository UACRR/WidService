using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{

    public interface IActivityType
    {
        int CodeI { get; set; }
        string Name { get; set; }
    }
    public interface IAgrLicenseType
    {

        int CodeI { get; set; }
        string Name { get; set; }
        int? KindCode { get; set; }
        int? UsesKind { get; set; }

    }

    public interface IAgreementStatus
    {

        int CodeI { get; set; }
        string Name { get; set; }

    }


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

    public interface IConsumer : ICustCompany
    {
        IList<IClnBusinessPlace> clnBusinessPlaceList { get; set; }
        IList<IClnPlaceHoll> clnPlaceHoll { get; set; }
        IList<ILicPlaceHoll> licPlaceHoll { get; set; }
    }
}
