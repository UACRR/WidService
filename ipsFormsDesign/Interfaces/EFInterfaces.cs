using System;
namespace ipsFormsDesign.Interfaces
{
public interface IAccount
    {    int accId { get; set; }
         int? balsCode { get; set; }
         int? custId { get; set; }
         int? objId { get; set; }
         string r030 { get; set; }
         string accNls { get; set; }
         DateTime? dateOpen { get; set; }
         DateTime? dateClose { get; set; }
         int accStatus { get; set; }
         string accName { get; set; }
         short? accDK { get; set; }
         DateTime? dateModify { get; set; }
}
public interface IAccountBals
    {    int codeI { get; set; }
         short? balsType { get; set; }
         string name { get; set; }
}
public interface IAccountBalsTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IAccountStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IAccountStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IActivityType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IActivityTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IAgreementAddBR
    {
         int agrId { get; set; }
         int version { get; set; }
         string agrNumber { get; set; }
         DateTime? agrDate { get; set; }
         DateTime? dateBegin { get; set; }
         DateTime? dateEnd { get; set; }
         int? periodCode { get; set; }
         int? agrStatus { get; set; }
         int? dayForPay { get; set; }
         int? ankVersion { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         int? custId { get; set; }
}
public interface IAgreementAddPartner
    {
         int agrId { get; set; }
         int? custId { get; set; }
         decimal? srFirstRate { get; set; }
         decimal? srMonthRate { get; set; }
         decimal? pfFirstRate { get; set; }
         decimal? pfMonthRate { get; set; }
         decimal? courtRate { get; set; }
         decimal? noCourtRate { get; set; }
         decimal? courtCompRate { get; set; }
         int version { get; set; }
         string agrNumber { get; set; }
         DateTime? agrDate { get; set; }
         DateTime? dateBegin { get; set; }
         DateTime? dateEnd { get; set; }
         int? periodCode { get; set; }
         int? agrStatus { get; set; }
         int? dayForPay { get; set; }
         int? ankVersion { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
}
public interface IAgreementAddRH
    {
         int agrId { get; set; }
         decimal? rateCourt { get; set; }
         decimal? rateCommiss { get; set; }
         string responsUser { get; set; }
         int? custId { get; set; }
         int version { get; set; }
         string agrNumber { get; set; }
         DateTime? agrDate { get; set; }
         DateTime? dateBegin { get; set; }
         DateTime? dateEnd { get; set; }
         int? periodCode { get; set; }
         int? dayForPay { get; set; }
         int? ankVersion { get; set; }
         int? agrStatus { get; set; }
         int? getCode { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
}
public interface IAgreementMaster
    {    int agrId { get; set; }
         int custId { get; set; }
         int? agrStatus { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         int? agrType { get; set; }
         int? version { get; set; }
}
public interface IAgreementStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IAgreementStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IAgreementType
    {    int codeI { get; set; }
         string name { get; set; }
         string templateName { get; set; }
}
public interface IAgreementTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IAgrLicenseType
    {    int codeI { get; set; }
         string name { get; set; }
         int? kindCode { get; set; }
         int? usesKind { get; set; }
         string templateName { get; set; }
         bool? needPlace { get; set; }
         int? schemaId { get; set; }
         int? algorithmId { get; set; }
}
public interface IAgrLicenseTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IAlgorithmType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IAlgorithmTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAnketaAddName
    {
         int custId { get; set; }
         string lang { get; set; }
         string nikName { get; set; }
         string firstName { get; set; }
         string surName { get; set; }
         string lastName { get; set; }
         string name { get; set; }
         string shortName { get; set; }
}
public interface IAnketaAddNick
    {
         int addId { get; set; }
         int custId { get; set; }
         string nikName { get; set; }
}
public interface IAnketaAddParam
    {
         int paramCode { get; set; }
         string langCode { get; set; }
         string paramName { get; set; }
         int? custId { get; set; }
         string paramValue { get; set; }
}
public interface IAnketaCompany
    {
         int custId { get; set; }
         int version { get; set; }
         int? activityCode { get; set; }
         int status { get; set; }
         string name { get; set; }
         string shortName { get; set; }
         string faAddress { get; set; }
         string jaAddress { get; set; }
         string okpo { get; set; }
         DateTime? registrDate { get; set; }
         int? typeVAT { get; set; }
         string numberVAT { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         string jaCity { get; set; }
         string faCity { get; set; }
         string jaCountry { get; set; }
         string faCountry { get; set; }
         int? banAccId { get; set; }
         int? jaRegion { get; set; }
         int? faRegion { get; set; }
         string registrNumber { get; set; }
         string registrWho { get; set; }
         string leCity { get; set; }
         string leCountry { get; set; }
         string lePostIndex { get; set; }
         int? leRegion { get; set; }
         string leAddress { get; set; }
}
public interface IAnketaExternal
    {
         int custId { get; set; }
         string name { get; set; }
         string interCode { get; set; }
         string countryCode { get; set; }
         string innOkpo { get; set; }
}
public interface IAnketaPerson
    {
         int custId { get; set; }
         int version { get; set; }
         int status { get; set; }
         string firstName { get; set; }
         string surName { get; set; }
         string lastName { get; set; }
         string nikName { get; set; }
         int? sex { get; set; }
         DateTime? birthDate { get; set; }
         string phoneMobileMain { get; set; }
         string phoneMobileExtra { get; set; }
         string phoneHome { get; set; }
         string eMail { get; set; }
         string citizenship { get; set; }
         int? residency { get; set; }
         string reCountry { get; set; }
         string reAddress { get; set; }
         string inn { get; set; }
         string pUSeries { get; set; }
         string pUNumber { get; set; }
         string pUIssuedWho { get; set; }
         DateTime? pUIssuedWhen { get; set; }
         string pFSeries { get; set; }
         string pFNumber { get; set; }
         DateTime? pFIssuedDate { get; set; }
         DateTime? pFValidity { get; set; }
         string buisNumberRegistration { get; set; }
         DateTime? buisDateRegistration { get; set; }
         string buisNumberPayer { get; set; }
         string buisSertNumberPayer { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         int? typeVAT { get; set; }
         string reCity { get; set; }
         string faCountry { get; set; }
         string faCity { get; set; }
         string faAddress { get; set; }
         int? banAccId { get; set; }
         int? faRegion { get; set; }
         string lang { get; set; }
         int? reRegion { get; set; }
         string leCountry { get; set; }
         int? leRegion { get; set; }
         string leCity { get; set; }
         string leAddress { get; set; }
         string lePostIndex { get; set; }
}
public interface IAnketaStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IAnketaStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IAspNetRoleClaims
    {
         int id { get; set; }
         string claimType { get; set; }
         string claimValue { get; set; }
         string roleId { get; set; }
}
public interface IAspNetRoles
    {    string id { get; set; }
         string concurrencyStamp { get; set; }
         string description { get; set; }
         string name { get; set; }
         string normalizedName { get; set; }
}
public interface IAspNetUserClaims
    {
         int id { get; set; }
         string claimType { get; set; }
         string claimValue { get; set; }
         string userId { get; set; }
}
public interface IAspNetUserLogins
    {
         string loginProvider { get; set; }
         string providerKey { get; set; }
         string providerDisplayName { get; set; }
         string userId { get; set; }
}
public interface IAspNetUserRoles
    {
         string userId { get; set; }
         string roleId { get; set; }
}
public interface IAspNetUsers
    {    string id { get; set; }
         int accessFailedCount { get; set; }
         string concurrencyStamp { get; set; }
         string email { get; set; }
         bool emailConfirmed { get; set; }
         string firstName { get; set; }
         string lastName { get; set; }
         bool lockoutEnabled { get; set; }
         DateTimeOffset? lockoutEnd { get; set; }
         string normalizedEmail { get; set; }
         string normalizedUserName { get; set; }
         string passwordHash { get; set; }
         string phoneNumber { get; set; }
         bool phoneNumberConfirmed { get; set; }
         string securityStamp { get; set; }
         string surName { get; set; }
         bool twoFactorEnabled { get; set; }
         string userName { get; set; }
}
public interface IAspNetUserTokens
    {
         string userId { get; set; }
         string loginProvider { get; set; }
         string name { get; set; }
         string value { get; set; }
    }
public interface IAtreementStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAuthors
    {
         int authId { get; set; }
         int objId { get; set; }
         int roleCode { get; set; }
         int? custId { get; set; }
         string authorName { get; set; }
         int? isFolkOrUnknown { get; set; }
         int? folkType { get; set; }
}
public interface IBankAccount
    {    int banAccID { get; set; }
         int? custId { get; set; }
         string accountNumber { get; set; }
         string currency { get; set; }
         string transitNumber { get; set; }
         int? mfo { get; set; }
         string mfoName { get; set; }
         string mfoOkpo { get; set; }
         string pIndex { get; set; }
         string pAddress { get; set; }
         string pCity { get; set; }
         string pCountry { get; set; }
         int? pRegion { get; set; }
}
public interface IBrRegister
    {    int regId { get; set; }
         int? periodId { get; set; }
         int? custId { get; set; }
         DateTime? createDate { get; set; }
         decimal? fullAmount { get; set; }
         decimal? rAmount { get; set; }
         int? status { get; set; }
         string fileName { get; set; }
         string userId { get; set; }
}
public interface IBrRegItem
    {    int regItemId { get; set; }
         int regId { get; set; }
         int? objId { get; set; }
         int? licId { get; set; }
         string ItemName { get; set; }
         int? countUse { get; set; }
         int? numTicket { get; set; }
         decimal? fullAmount { get; set; }
         decimal? fullRate { get; set; }
         decimal? rAmount { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         int? status { get; set; }
         int? regIdSr { get; set; }
         decimal? musicRate { get; set; }
         decimal? musicAmount { get; set; }
         int? categoryCode { get; set; }
}
public interface ICategory
    {    int codeI { get; set; }
         string name { get; set; }
         int? status { get; set; }
         string TableObj { get; set; }
         int? utype { get; set; }
         string comment { get; set; }
}
public interface ICategoryStatusType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ICategoryStatusTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICategoryTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IClient
    {    int custId { get; set; }
         string clientBrand { get; set; }
         string clientGroup { get; set; }
}
public interface IClientBrand
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IClientBrandTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IClientGroup
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IClientGroupTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IClnBusinessPlace
    {    int placeId { get; set; }
         int? custId { get; set; }
         int? plCode { get; set; }
         string placeName { get; set; }
         string placeCountry { get; set; }
         int? placeRegion { get; set; }
         string placeCity { get; set; }
         string placeAddress { get; set; }
         string placePhone { get; set; }
         bool? freeEntry { get; set; }
}
public interface IClnPlaceHoll
    {
         int hollId { get; set; }
         int? placeId { get; set; }
         string hollName { get; set; }
         string valuePlace { get; set; }
         string valueAdd { get; set; }
}
public interface ICommentCause
    {    int causeCode { get; set; }
         string causeNameUk { get; set; }
         string causeNameRu { get; set; }
         string causeNameEn { get; set; }
}
public interface ICommunity
    {    int custId { get; set; }
}
public interface ICompany
    {    int custId { get; set; }
         int version { get; set; }
}
public interface IContinent
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IContinentTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICopyRight
    {
         int cRightId { get; set; }
         int custId { get; set; }
         int? objId { get; set; }
         int? lBasis { get; set; }
         decimal? rate { get; set; }
         decimal? roleRate { get; set; }
         DateTime? beginDate { get; set; }
         DateTime? endDate { get; set; }
         string lBasisComment { get; set; }
         DateTime? createDate { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         bool? permCode { get; set; }
         int? parentId { get; set; }
         int? roleCode { get; set; }
         int? status { get; set; }
}
public interface ICopyrightKind
    {    int codeI { get; set; }
         string name { get; set; }
         int? crGroupCode { get; set; }
}
public interface ICopyrightKindTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICopyrightType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ICopyrightTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICopyRTranslate
    {
         int cRightId { get; set; }
         int? roleCode { get; set; }
         string langFrom { get; set; }
         string langTo { get; set; }
}
public interface ICounterNumber
    {    int counterId { get; set; }
         string name { get; set; }
         int? cNum { get; set; }
         string prefix { get; set; }
         string symbolN { get; set; }
         short? templYear { get; set; }
}
public interface ICountry
    {    int? continentCode { get; set; }
         string countryCode { get; set; }
         string countryName { get; set; }
         string a2 { get; set; }
         string kOD_LIT { get; set; }
         string countryNameShort { get; set; }
         short? shortChoise { get; set; }
         int? orderBy { get; set; }
}
public interface ICountryTr
    {
         string countryCode { get; set; }
         string lang { get; set; }
         string countryName { get; set; }
         string countryNameShort { get; set; }
}
public interface ICreativeRoleType
    {    int codeI { get; set; }
         int CategoryCode { get; set; }
         string name { get; set; }
         int CRType { get; set; }
}
public interface ICreativeRoleTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICreativeTranslate
    {    int codeI { get; set; }
}
public interface ICRightStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ICRightStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICRKindGroup
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ICRKindGroupTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICurrency
    {    string r030 { get; set; }
         string a3 { get; set; }
         string countryCode { get; set; }
         string r030NameEn { get; set; }
         string r030NameRu { get; set; }
         string r030NameUk { get; set; }
         int? nOMIN { get; set; }
         string nAIM { get; set; }
         short? prWork { get; set; }
         short? prNC { get; set; }
         int? orderBy { get; set; }
}
public interface ICurrencyCourse
    {
         string r030 { get; set; }
         DateTime cDate { get; set; }
         int? cUnit { get; set; }
         decimal? cAmount { get; set; }
         decimal? cAmountNBU { get; set; }
}
public interface ICustCmRight
    {
         int custId { get; set; }
         int cRKindCode { get; set; }
         int cmCustId { get; set; }
         DateTime dateBegin { get; set; }
         DateTime dateEnd { get; set; }
}
public interface ICustomer
    {    int custId { get; set; }
         int? custType { get; set; }
         int status { get; set; }
         int? ankVersion { get; set; }
         byte? ankMy { get; set; }
         byte? ankPublish { get; set; }
         byte? ankTech { get; set; }
}
public interface ICustomerStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ICustomerStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ICustomerType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ICustomerTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IDicCategoryItems
    {
         string dicName { get; set; }
         int code { get; set; }
         string name { get; set; }
         string url { get; set; }
         string dicType { get; set; }
         int? dicLevel { get; set; }
}
public interface IDicList
    {
         int dicId { get; set; }
         string dKind { get; set; }
         int dCode { get; set; }
         string dNameUk { get; set; }
         string dNameRu { get; set; }
         string dNameEn { get; set; }
    }
public interface IDictCategory
    {    int code { get; set; }
         string name { get; set; }
}
public interface IDistribStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IDistribStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IDistribType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IDistribTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IDistribution
    {    int distId { get; set; }
         int? regId { get; set; }
         int? rmId { get; set; }
         int cRKindCode { get; set; }
         int status { get; set; }
         DateTime distribDate { get; set; }
         decimal amount { get; set; }
         decimal partnerCommiss { get; set; }
         decimal courtFee { get; set; }
         int? partnerId { get; set; }
         bool? isCourt { get; set; }
         int? regIdBr { get; set; }
         int? distType { get; set; }
         int custId { get; set; }
}
public interface IDistributionItem
    {
         int distId { get; set; }
         int? regId { get; set; }
         int? regIItemId { get; set; }
         decimal? amount { get; set; }
         int? status { get; set; }
         int? regIdBr { get; set; }
         int? regItemIdBr { get; set; }
         int distItemId { get; set; }
         int? objId { get; set; }
}
public interface IDocPreparePay
    {
         int docPayId { get; set; }
         DateTime dateWork { get; set; }
         int? regId { get; set; }
         int? distId { get; set; }
         string nD { get; set; }
         DateTime? nDDate { get; set; }
         int? accIdDebet { get; set; }
         int? accIdCredit { get; set; }
         string accDebet { get; set; }
         string accCredit { get; set; }
         decimal? amount { get; set; }
         decimal? amountCur { get; set; }
         string payNote { get; set; }
         string r030 { get; set; }
         DateTime dateOper { get; set; }
         int? payStatus { get; set; }
         int? paidid { get; set; }
         byte? flCourt { get; set; }
         int? custIdRh { get; set; }
}
public interface IDocReq
    {
         int docId { get; set; }
         int reqId { get; set; }
}
public interface IDocTemplate
    {
         int TemplId { get; set; }
         int DocTypeCode { get; set; }
         int? ReqType { get; set; }
         string TemplName { get; set; }
         string TemplPath { get; set; }
}
public interface IDocText
    {
         int Id { get; set; }
         int? DocTypeCode { get; set; }
         string Code { get; set; }
         string Text_Uk { get; set; }
         string Text_Ru { get; set; }
         string Text_En { get; set; }
    }
public interface IDocument
    {    int DocId { get; set; }
         int DocType { get; set; }
         DateTime DocDate { get; set; }
         string DocNumber { get; set; }
         string DocFile { get; set; }
         int? DocStatus { get; set; }
         int? PeriodId { get; set; }
}
public interface IDocumentKind
    {    int CodeI { get; set; }
         int? CategoryCode { get; set; }
         string Name { get; set; }
         string DocMaker { get; set; }
}
public interface IDocumentKindTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IDocumentStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IDocumentStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IDocumentType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IDocumentTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IEmployee
    {    int emplid { get; set; }
         int? custId { get; set; }
         string userId { get; set; }
         string firstName { get; set; }
         string surName { get; set; }
         string lastName { get; set; }
         string phoneNumber { get; set; }
         string email { get; set; }
}
public interface IEpisodeType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IEpisodeTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IEtGenre
    {    int codeI { get; set; }
         string name { get; set; }
         int? categoryCode { get; set; }
}
public interface IEtGenreRate
    {
         int actCode { get; set; }
         int genreCode { get; set; }
         decimal? rate { get; set; }
}
public interface IEtGenreRole
    {
         int genreCode { get; set; }
         int roleCode { get; set; }
         int actCode { get; set; }
         decimal? rate { get; set; }
}
public interface IEtRole
    {    int codeI { get; set; }
         string name { get; set; }
         int? categoryCode { get; set; }
}
public interface IExternalPay
    {
         int paidId { get; set; }
         DateTime? inputDate { get; set; }
         string mfo { get; set; }
         string okpol { get; set; }
         string account { get; set; }
         string r030 { get; set; }
         string codeOper { get; set; }
         string mfoCorr { get; set; }
         string nameMfoCorr { get; set; }
         string accountCorr { get; set; }
         string okpoCorr { get; set; }
         string nameCorr { get; set; }
         string docNum { get; set; }
         DateTime? docDate { get; set; }
         decimal? sDebet { get; set; }
         decimal? sCredit { get; set; }
         string nplat { get; set; }
         decimal? sNcCur { get; set; }
         int? status { get; set; }
         DateTime? dateOper { get; set; }
    }
public interface IFileCustomer
    {
         int docId { get; set; }
         int custId { get; set; }
         int docType { get; set; }
         DateTime? createDate { get; set; }
         string docFile { get; set; }
         string docComment { get; set; }
         string mimeType { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
}
public interface IFileType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IFixation
    {    int fixId { get; set; }
         int? partnerCustId { get; set; }
         int stageStatus { get; set; }
         int? clientCustId { get; set; }
         int? licId { get; set; }
         int? usesType { get; set; }
         string eventName { get; set; }
         string eventDates { get; set; }
         string city { get; set; }
         string address { get; set; }
         string placement { get; set; }
         int? countPlace { get; set; }
         decimal? ticketPriceMin { get; set; }
         decimal? ticketPriceMax { get; set; }
         DateTime? fixationDate { get; set; }
         decimal? rewardAmount { get; set; }
         decimal? courtFeeAmount { get; set; }
         string clientName { get; set; }
         string clientInnOkpo { get; set; }
         string userId { get; set; }
}
public interface IFixFile
    {
         int fileId { get; set; }
         int? fixId { get; set; }
         string name { get; set; }
         string path { get; set; }
}
public interface IFixStageStatus
    {    int codeI { get; set; }
         string StageName { get; set; }
         string StatusName { get; set; }
         int? StageCode { get; set; }
         int? StatusCode { get; set; }
}
public interface IFixStorageDevice
    {
         int storageId { get; set; }
         int fixId { get; set; }
         string name { get; set; }
         string serialNumber { get; set; }
         decimal? capacity { get; set; }
}
public interface IFolkType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IFolkTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IGenre
    {    int CategoryCode { get; set; }
         string Name { get; set; }
         int Id { get; set; }
}
public interface IGenreTr
    {
         int Id { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IGenreType
    {    int codeI { get; set; }
         int categoryCode { get; set; }
         string name { get; set; }
}
public interface IGenreTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IInvoice
    {
         int docId { get; set; }
         int? payCustId { get; set; }
         int? recCustId { get; set; }
         int? payAnk { get; set; }
         int? recAnk { get; set; }
         string r030 { get; set; }
         decimal? Amount { get; set; }
         string recMFO { get; set; }
         string recBankName { get; set; }
         string purpose { get; set; }
         int? status { get; set; }
    }
public interface IItemStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IItemStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IKindComposition
    {    int codeI { get; set; }
         string name { get; set; }
         int categoryCode { get; set; }
}
public interface IKindCompositionTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IKindFilm
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IKindFilmTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IKindSerial
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IKindSerialTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IKlR030
    {    string R030 { get; set; }
         short? R031 { get; set; }
         string CountryCode { get; set; }
         string A3 { get; set; }
         string R030Name { get; set; }
         int? NOmin { get; set; }
         string NAim { get; set; }
         short? PrWork { get; set; }
}
public interface IKlR030tr
    {
         string R030 { get; set; }
         string Lang { get; set; }
         string R030Name { get; set; }
}
public interface IKlR031
    {    short R031 { get; set; }
         string R031NameUk { get; set; }
         string R031NameRu { get; set; }
         string R031NameEn { get; set; }
}
public interface IKL_R030
    {    string r030 { get; set; }
         short? r031 { get; set; }
         string countryCode { get; set; }
         string a3 { get; set; }
         string r030Name { get; set; }
         int? nOMIN { get; set; }
         string nAIM { get; set; }
         short? pr_work { get; set; }
}
public interface IKL_R030Tr
    {
         string r030 { get; set; }
         string lang { get; set; }
         string r030Name { get; set; }
}
public interface IKL_R031
    {    short r031 { get; set; }
         string r031NameUk { get; set; }
         string r031NameRu { get; set; }
         string r031NameEn { get; set; }
}
public interface ILang
    {    string codeS { get; set; }
         string name { get; set; }
}
public interface ILangTr
    {
         string codeS { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ILanguage
    {    string codeS { get; set; }
         string name { get; set; }
         int? nameId { get; set; }
         string nameSh3 { get; set; }
         short? shortChoise { get; set; }
}
public interface ILegalBasis
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ILegalBasisTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ILicAuthor
    {
         int LicAutorId { get; set; }
         int? LicId { get; set; }
         int? CustId { get; set; }
         int? RoleType { get; set; }
         string NameAuthor { get; set; }
         DateTime? DateCreate { get; set; }
         DateTime? DateClose { get; set; }
         DateTime? DateModify { get; set; }
         DateTime? DateAccept { get; set; }
         decimal? Rate { get; set; }
         decimal? LumpSum { get; set; }
         decimal? R030LumpSum { get; set; }
         decimal? PrePay { get; set; }
         decimal? R030PrePay { get; set; }
}
public interface ILicAuthorBR
    {
         int cRightId { get; set; }
         int? prepayType { get; set; }
         DateTime? dateCreate { get; set; }
         DateTime? dateClose { get; set; }
         DateTime? dateModify { get; set; }
         DateTime? dateAccept { get; set; }
         decimal? rate { get; set; }
         decimal? prepaySum { get; set; }
         decimal? prepaySumAuthor { get; set; }
         string r030 { get; set; }
         DateTime? prepayDateDo { get; set; }
         decimal? prepayRest { get; set; }
         decimal? prepayUsed { get; set; }
}
public interface ILicense
    {
         int lId { get; set; }
         int? placeId { get; set; }
         int? licId { get; set; }
         int? licVersion { get; set; }
         string lNum { get; set; }
         DateTime? lDate { get; set; }
         int? status { get; set; }
}
public interface ILicenseAgreement
    {    int licId { get; set; }
         int licCode { get; set; }
         int? licType { get; set; }
         int? custId { get; set; }
         int? licStatus { get; set; }
         int licClass { get; set; }
         int agrId { get; set; }
         int? licSize { get; set; }
         int? licVersion { get; set; }
         int? prolongVersion { get; set; }
}
public interface ILicenseAgrParam
    {    int licId { get; set; }
         int licVersion { get; set; }
         string licNum { get; set; }
         DateTime? licDate { get; set; }
         DateTime? dateBegin { get; set; }
         DateTime? dateEnd { get; set; }
         decimal? minAmount { get; set; }
         decimal? rateAmount { get; set; }
         bool? isAutoprolog { get; set; }
         decimal? addRate { get; set; }
         decimal? indxInfl { get; set; }
         int? periodCode { get; set; }
         int? dayForPay { get; set; }
         int? licStatus { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         int? ankVersion { get; set; }
         string comment { get; set; }
}
public interface ILicenseBigR
    {    int licId { get; set; }
         DateTime? datePremiere { get; set; }
         int? objId { get; set; }
         decimal? fillingRate { get; set; }
         int? performNumb { get; set; }
         decimal? ticketPriceNC { get; set; }
         decimal? ticketPriceUSD { get; set; }
         bool? isTour { get; set; }
         string whereTour { get; set; }
         decimal? rate { get; set; }
         decimal? prepayRest { get; set; }
         string langCode { get; set; }
         int? performType { get; set; }
         short? licTerm { get; set; }
         decimal? rateMusic { get; set; }
}
public interface ILicenseClass
    {
         int codeI { get; set; }
         string name { get; set; }
    }
public interface ILicenseType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ILicenseTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IlicPlace
    {
         int licId { get; set; }
         int placeId { get; set; }
}
public interface ILicPlaceHoll
    {
         int LicId { get; set; }
         int PlaceId { get; set; }
         int HollId { get; set; }
}
public interface IMediaFile
    {
         int mediaFileId { get; set; }
         string fileType { get; set; }
         string path { get; set; }
         double? compress { get; set; }
         double? playTime { get; set; }
         int? objId { get; set; }
}
public interface IMediaSearchData
    {
         long id { get; set; }
         int objId { get; set; }
         int typeData { get; set; }
         string alterName { get; set; }
         string alterNameNormalize { get; set; }
    }
public interface IMediaTrack
    {    int objId { get; set; }
         string iswc { get; set; }
         string name { get; set; }
         string lyrics { get; set; }
         string composers { get; set; }
         string performers { get; set; }
         string Album { get; set; }
         string genre { get; set; }
         int? numberInAlbum { get; set; }
         int? year { get; set; }
         string label { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         TimeSpan? duration { get; set; }
}
public interface IModifyMusicType
    {    int codeI { get; set; }
         string name { get; set; }
         int? kindCompCode { get; set; }
         int categoryCode { get; set; }
}
public interface IModifyMusicTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IModifyTextType
    {    int codeI { get; set; }
         string name { get; set; }
         int? kindCompCode { get; set; }
         int categoryCode { get; set; }
}
public interface IModifyTextTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IModifyType
    {    int codeI { get; set; }
         string name { get; set; }
         int? kindCompCode { get; set; }
         int categoryCode { get; set; }
}
public interface IModifyTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IMoneyLinkStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IMoneyLinkStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IMoneyPeriodLink
    {
         int periodId { get; set; }
         int paidId { get; set; }
         int licId { get; set; }
         DateTime modifyDate { get; set; }
         decimal amount { get; set; }
         int? status { get; set; }
}
public interface IMoneyPrepayLink
    {
         int paidId { get; set; }
         int cRightId { get; set; }
         decimal? amount { get; set; }
}
public interface IMoneyReceived
    {    int paidId { get; set; }
         int custId { get; set; }
         int moneyType { get; set; }
         DateTime dateInvoice { get; set; }
         string numberInvoice { get; set; }
         string goalInvoice { get; set; }
         decimal amount { get; set; }
         decimal destribAmount { get; set; }
         decimal? destribPrepay { get; set; }
}
public interface IMoneyType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IMoneyTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IMusicalDesign
    {
         int mdId { get; set; }
         int licId { get; set; }
         int? objid { get; set; }
         int? actNumb { get; set; }
         string objName { get; set; }
         string nameMusician { get; set; }
         string nameSinger { get; set; }
         string authorText { get; set; }
         TimeSpan? duration { get; set; }
         int? numbPerfom { get; set; }
}
public interface IMyAnketa
    {    int custId { get; set; }
         string accCompany { get; set; }
         string accCommission { get; set; }
         string accInCommission { get; set; }
         string accCourt { get; set; }
}
public interface IMyCategory
    {
         int custId { get; set; }
         int codeI { get; set; }
}
public interface ImyCopyRightType
    {
         int custId { get; set; }
         int cRType { get; set; }
}
public interface IObjAct
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IObjActTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IObjectRight
    {    int categoryCode { get; set; }
         int objId { get; set; }
         int? reqId { get; set; }
         int? genreType { get; set; }
         string name { get; set; }
         string author { get; set; }
         string performer { get; set; }
         int? status { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         DateTime? createDate { get; set; }
         string ObjImg { get; set; }
         int? loadid { get; set; }
         int? specType { get; set; }
         int? actCode { get; set; }
         string innerCode { get; set; }
}
public interface IObjectStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IObjectStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IObjectType
    {    int CodeI { get; set; }
         int CategoryCode { get; set; }
         string Name { get; set; }
}
public interface IObjectTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
         int CategoryCode { get; set; }
}
public interface IPaidPeriod
    {    int periodId { get; set; }
         int custId { get; set; }
         int periodType { get; set; }
         int licId { get; set; }
         DateTime beginDate { get; set; }
         DateTime endDate { get; set; }
         int status { get; set; }
         decimal amount { get; set; }
         decimal undistribamount { get; set; }
         decimal distribamount { get; set; }
         string periodName { get; set; }
         bool? fagFirst { get; set; }
         DateTime? dateActPrint { get; set; }
}
public interface IParametersListBox
    {
         int repId { get; set; }
         int pId { get; set; }
         string valuePar { get; set; }
         string valueType { get; set; }
         string valueName { get; set; }
    }
public interface IPartner
    {    int custId { get; set; }
}
public interface IPartnerClient
    {
         int custId { get; set; }
         int clCustId { get; set; }
}
public interface IPaymentCase
    {
         int reqId { get; set; }
         int? payKind { get; set; }
         int? payMethod { get; set; }
         int? ptId { get; set; }
         DateTime? dateForPay { get; set; }
         DateTime? dateInvoce { get; set; }
         DateTime? datePay { get; set; }
         int? payStatus { get; set; }
         DateTime? datePayFact { get; set; }
         string otherCase { get; set; }
}
public interface IPaymentKind
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IPaymentKindTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IPaymentStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IPaymentStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IPayMethodType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IPayMethodTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IPayTurn
    {
         int turnId { get; set; }
         DateTime dateWork { get; set; }
         string nD { get; set; }
         DateTime? nDDate { get; set; }
         int? accIdDebet { get; set; }
         int? accIdCredit { get; set; }
         string accDebet { get; set; }
         string accCredit { get; set; }
         decimal? amount { get; set; }
         decimal? amountCur { get; set; }
         string payNote { get; set; }
         string r030 { get; set; }
         DateTime dateOper { get; set; }
         int? payStatus { get; set; }
         int? regId { get; set; }
         int? distId { get; set; }
         int? custIdRh { get; set; }
}
public interface IPerformer
    {    int perId { get; set; }
         string perName { get; set; }
}
public interface IPerformType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IPerformTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IPerformTypetTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPeriod
    {    int codeI { get; set; }
         string name { get; set; }
         string nameR { get; set; }
}
public interface IPeriodStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IPeriodStatusTr
    {
         int codeI { get; set; }
         string name { get; set; }
         string lang { get; set; }
}
public interface IPeriodTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
         string nameR { get; set; }
}
public interface IPermitType
    {    bool codeB { get; set; }
         string name { get; set; }
}
public interface IPermitTypeTr
    {
         bool codeB { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IPerson
    {    int custId { get; set; }
         int version { get; set; }
}
public interface IPopGenre
    {    int categoryCode { get; set; }
         string name { get; set; }
         int id { get; set; }
}
public interface IPopGenreTr
    {
         int Id { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IPortalObjectRights
    {
         int objId { get; set; }
         int cRKindCode { get; set; }
         int enable { get; set; }
}
public interface IPortalSupportRights
    {    int cRKindCode { get; set; }
}
public interface IPositionType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IPositionTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IPrePayType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IPrePayTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRegion
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IRegionTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRegister
    {    int regId { get; set; }
         int rmId { get; set; }
         string number { get; set; }
         int countRows { get; set; }
         int custId { get; set; }
         DateTime? createDate { get; set; }
         int durationticks { get; set; }
         int? rgStatus { get; set; }
         string fileName { get; set; }
         string userId { get; set; }
         int? periodId { get; set; }
         decimal? regAmount { get; set; }
         decimal? regRate { get; set; }
         decimal? regRoyalty { get; set; }
         decimal? musicAmount { get; set; }
         decimal? musicRate { get; set; }
         decimal? authAmount { get; set; }
         decimal? authRate { get; set; }
         decimal? paidAmount { get; set; }
         int licId { get; set; }
         int? schemaId { get; set; }
         int? algorithmId { get; set; }
}
public interface IRegisterAuthors
    {
         int regId { get; set; }
         int regIItemId { get; set; }
         int authId { get; set; }
         int codeRole { get; set; }
         string Name { get; set; }
}
public interface IRegisterCount
    {
         decimal regCntId { get; set; }
         int? regId { get; set; }
         int? regIItemId { get; set; }
         int? objId { get; set; }
         int? custId { get; set; }
         int? cRType { get; set; }
         int? cRKindCode { get; set; }
         decimal? rate { get; set; }
         decimal? rateCommiss { get; set; }
         int? cmCustId { get; set; }
         int? regIdBr { get; set; }
         int? regItemIdBr { get; set; }
         decimal? prepaySum { get; set; }
}
public interface IRegisterExtra
    {
         int regExtraId { get; set; }
         int regId { get; set; }
         int regIItemId { get; set; }
         int roleCode { get; set; }
         string name { get; set; }
}
public interface IRegisterItem
    {    int regId { get; set; }
         int regIItemId { get; set; }
         int? objId { get; set; }
         int codeItem { get; set; }
         string ItemName { get; set; }
         int? categoryCode { get; set; }
         string performer { get; set; }
         string authorMusic { get; set; }
         string authorText { get; set; }
         TimeSpan? durationUse { get; set; }
         int? countUse { get; set; }
         TimeSpan? durationItem { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         int? durationticks { get; set; }
         int? ticks { get; set; }
         bool isAuto { get; set; }
}
public interface IRegisterItemType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IRegisterListStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IRegisterListStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRegisterRatedList
    {    int periodId { get; set; }
         int rmId { get; set; }
         decimal? amount { get; set; }
         decimal? royalty { get; set; }
         DateTime? createDate { get; set; }
         string userId { get; set; }
         int? status { get; set; }
         int? cntReport { get; set; }
         decimal? paidAmount { get; set; }
}
public interface IRegisterStatus
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IRegisterStatusTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRelAdaptUseArea
    {
         int reqId { get; set; }
         int useAreaTypeCode { get; set; }
}
public interface IrelCounterDoc
    {
         int cDocId { get; set; }
         int counterId { get; set; }
         int docType { get; set; }
         int? licType { get; set; }
}
public interface IRelDocAgrType
    {
         int agrType { get; set; }
         int docType { get; set; }
}
public interface IRelEmployee
    {
         int emplid { get; set; }
         int custId { get; set; }
         int positionCode { get; set; }
         string relDocument { get; set; }
}
public interface IrelEtGenre
    {
         int genreCode { get; set; }
         int etGenreCode { get; set; }
}
public interface IrelEtRole
    {
         int roleCode { get; set; }
         int etRoleCode { get; set; }
}
public interface IRelGenreAdapt
    {
         int reqId { get; set; }
         int genreId { get; set; }
}
public interface IRelGenreMovie
    {
         int reqId { get; set; }
         int genreId { get; set; }
}
public interface IRelGenrePercent
    {
         int actCode { get; set; }
         int genreType { get; set; }
         decimal? rate { get; set; }
}
public interface IrelGenreRole
    {
         int roleCode { get; set; }
         int genreType { get; set; }
         decimal? rate { get; set; }
         int actCode { get; set; }
}
public interface IRelGenreSerial
    {
         int reqId { get; set; }
         int genreId { get; set; }
}
public interface IrelLicCopyR
    {
         int agrLlicCode { get; set; }
         int cRKindCode { get; set; }
}
public interface IRelMovieEpisode
    {
         int episodeTypeCode { get; set; }
         int reqId { get; set; }
         double? epDuration { get; set; }
}
public interface IRelObjGenre
    {
         int GenreId { get; set; }
         int ObjId { get; set; }
}
public interface IRelObjPerformer
    {
         int objId { get; set; }
         int perId { get; set; }
}
public interface IRelPopGenre
    {
         int genreId { get; set; }
         int objId { get; set; }
}
public interface IRelReqMedia
    {
         int useMediaTypeCode { get; set; }
         int reqId { get; set; }
}
public interface IRelReqObj
    {
         int categoryCode { get; set; }
         int reqType { get; set; }
         int kindGroupId { get; set; }
         int? CRKindCode { get; set; }
}
public interface IRelSerialEpisode
    {
         int reqId { get; set; }
         int episodeTypeCode { get; set; }
         double? epDuration { get; set; }
}
public interface IRelTVEpisode
    {
         int reqId { get; set; }
         int episodeTypeCode { get; set; }
         double? epDuration { get; set; }
}
public interface IReports
    {
         int id { get; set; }
         string repname { get; set; }
    }
public interface IReqAgreement
    {    int rAgrId { get; set; }
         int custId { get; set; }
         int? custIdRh { get; set; }
         int? reqId { get; set; }
         string r030 { get; set; }
         decimal? amount { get; set; }
         decimal? costOffer { get; set; }
         int status { get; set; }
         DateTime? agrDate { get; set; }
         string userId { get; set; }
         DateTime? modifyDate { get; set; }
         int? tradeId { get; set; }
         string r030Offer { get; set; }
         DateTime? statusDate { get; set; }
         string rAgrComment { get; set; }
}
public interface IReqAgreementStatus
    {    int statusCode { get; set; }
         string statusNameUk { get; set; }
         string statusNameRu { get; set; }
         string statusNameEn { get; set; }
}
public interface IReqCustomer
    {    int reqCustId { get; set; }
         int? custId { get; set; }
         string name { get; set; }
         string countryCode { get; set; }
         string okpo { get; set; }
         string nickName { get; set; }
         int? activityCode { get; set; }
         string comment { get; set; }
}
public interface IReqLocationUse
    {
         int locUsId { get; set; }
         int? reqId { get; set; }
         string countryCode { get; set; }
         int? continentCode { get; set; }
}
public interface IReqTrade
    {
         int tradeId { get; set; }
         int reqId { get; set; }
         string r030 { get; set; }
         decimal? costRHolder { get; set; }
         DateTime? createDate { get; set; }
         int rAgrId { get; set; }
         int status { get; set; }
         DateTime? statusDate { get; set; }
         DateTime? modifyDate { get; set; }
         decimal? costClient { get; set; }
         string tradeComment { get; set; }
         int? causeCode { get; set; }
}
public interface IRequest
    {    int reqId { get; set; }
         int? categoryCode { get; set; }
         int reqType { get; set; }
         DateTime? reqDate { get; set; }
         int? countUse { get; set; }
         DateTime? beginDate { get; set; }
         DateTime? endDate { get; set; }
         int reqstatus { get; set; }
         int? custId { get; set; }
         string userId { get; set; }
         int reqAimCode { get; set; }
         int? objId { get; set; }
         int? kindCompCode { get; set; }
         int? termUseCode { get; set; }
         DateTime? createDate { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
         int? licCode { get; set; }
         int? reqCustId { get; set; }
         string reqComment { get; set; }
         string r030 { get; set; }
         decimal? reqAmount { get; set; }
         string workName { get; set; }
         TimeSpan? durationUse { get; set; }
}
public interface IRequestAdapt
    {    int reqId { get; set; }
         string execNick { get; set; }
         int? modifyType { get; set; }
         int? modifyTextType { get; set; }
         string modifyTextComment { get; set; }
         int? modifyMusicType { get; set; }
         string modifyMusictComment { get; set; }
         string useAreaComment { get; set; }
}
public interface IRequestAdvertising
    {
         int reqId { get; set; }
         string tradeMark { get; set; }
         TimeSpan? durationAll { get; set; }
         TimeSpan? durationShort { get; set; }
}
public interface IRequestAim
    {    int codeI { get; set; }
         int reqType { get; set; }
         string name { get; set; }
         int categoryCode { get; set; }
}
public interface IRequestAimTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRequestInternet
    {
         int reqId { get; set; }
         int? typeInternetObject { get; set; }
         string url { get; set; }
         string useDesc { get; set; }
}
public interface IRequestMovie
    {    int reqId { get; set; }
         int? kindFilm { get; set; }
         string episodeComment { get; set; }
         bool? UseHire { get; set; }
         bool? UseFestival { get; set; }
}
public interface IRequestOther
    {
         int reqId { get; set; }
         string useDesc { get; set; }
}
public interface IRequestSerial
    {    int reqId { get; set; }
         int? kindSerial { get; set; }
         string episodeComment { get; set; }
         short? cntSeries { get; set; }
         bool? UseHire { get; set; }
         bool? UseFestival { get; set; }
}
public interface IRequestStatusType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IRequestStatusTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRequestTVRadio
    {    int reqId { get; set; }
         string shortTitle { get; set; }
         string nameTVChanel { get; set; }
         string episodeComment { get; set; }
}
public interface IRequestType
    {    int codeI { get; set; }
         int categoryCode { get; set; }
         string name { get; set; }
}
public interface IRequestTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IResidentType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IResidentTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRHolderType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IRHolderTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IRightHolder
    {    int custId { get; set; }
         byte? signP { get; set; }
         bool? aroundWord { get; set; }
         string interCode { get; set; }
         string innerCode { get; set; }
         int? rHolderType { get; set; }
}
public interface ISaldoDay
    {
         int accId { get; set; }
         DateTime dateBegin { get; set; }
         DateTime dateEnd { get; set; }
         string r030 { get; set; }
         decimal? rest { get; set; }
         decimal? restCourt { get; set; }
         decimal? deboborot { get; set; }
         decimal? krdOborot { get; set; }
         decimal? deboborotCourt { get; set; }
         decimal? krdOborotCourt { get; set; }
         decimal? restBegin { get; set; }
         decimal? restBeginCourt { get; set; }
    }
public interface ISeekObject
    {
         int id { get; set; }
         int? codeI { get; set; }
         int? objId { get; set; }
         string name { get; set; }
}
public interface ISeekType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ISeekTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ISexType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ISexTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ISpecType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ISpecTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ITableColumn
    {
         decimal id { get; set; }
         string lang { get; set; }
         string cName { get; set; }
         string tName { get; set; }
         string dText { get; set; }
         string hText { get; set; }
    }
public interface ITableColumnTech
    {
         decimal id { get; set; }
         string cname { get; set; }
         string tname { get; set; }
         string dnameUk { get; set; }
         string dnameRu { get; set; }
         string dnameEn { get; set; }
         short? typeTab { get; set; }
    }
public interface ITableObject
    {
         decimal id { get; set; }
         string lang { get; set; }
         string cName { get; set; }
         string dText { get; set; }
         string hText { get; set; }
    }
public interface ITableType
    {
         string tName { get; set; }
         short? tType { get; set; }
    }
public interface ITermsOfService
    {    int custId { get; set; }
         int CRKindCode { get; set; }
         bool ourService { get; set; }
}
public interface ITermUse
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ITermUseTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ITerritoryExclude
    {
         int custId { get; set; }
         string countryCode { get; set; }
}
public interface ITerritoryInclude
    {
         int custId { get; set; }
         string countryCode { get; set; }
}
public interface ITmpTradeLog
    {
         int Id { get; set; }
         int? RegId { get; set; }
         string Value { get; set; }
         DateTime? ModifyDate { get; set; }
    }
public interface ITradeStatus
    {    int statusCode { get; set; }
         string statusNameUk { get; set; }
         string statusNameRu { get; set; }
         string statusNameEn { get; set; }
}
public interface ITypeInternetObject
    {    int codeI { get; set; }
         string name { get; set; }
         string typeInetNameEn { get; set; }
         string typeInetNameRu { get; set; }
}
public interface ITypeInternetObjectTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ITypeMethodGet
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ITypeMethodGetTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ITypePlace
    {    int codeI { get; set; }
         string name { get; set; }
         bool? isHoll { get; set; }
         int? paramType { get; set; }
}
public interface ITypePlaceParam
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ITypePlaceParamTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ITypePlaceTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface ITypeVAT
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface ITypeVATTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IUseAreaType
    {    int codeI { get; set; }
         int categoryCode { get; set; }
         int reqType { get; set; }
         string name { get; set; }
}
public interface IUseAreaTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IUseMediaType
    {    int codeI { get; set; }
         int reqType { get; set; }
         string name { get; set; }
         int categoryCode { get; set; }
}
public interface IUseMediaTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IuserRole
    {
         int custId { get; set; }
         int roleType { get; set; }
         string userId { get; set; }
         int? status { get; set; }
}
public interface IUserRoleType
    {    int codeI { get; set; }
         int isAdmin { get; set; }
         string typeNameRu { get; set; }
         string typeNameEn { get; set; }
         string name { get; set; }
}
public interface IUserRoleTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IUsesKind
    {    int codeI { get; set; }
         int? usesType { get; set; }
         string name { get; set; }
}
public interface IUsesKindTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IUsesType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IUsesTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}
public interface IWorkRH
    {
         int cRightId { get; set; }
         int? workTypeRH { get; set; }
         string workCommentRH { get; set; }
         DateTime? workDateRH { get; set; }
         int? workTypeCl { get; set; }
         DateTime? workDateCl { get; set; }
         string workCoommentCl { get; set; }
         DateTime? modifyDate { get; set; }
         string modifyLogin { get; set; }
}
public interface IWorkType
    {    int codeI { get; set; }
         string name { get; set; }
}
public interface IWorkTypeTr
    {
         int codeI { get; set; }
         string lang { get; set; }
         string name { get; set; }
}

}

