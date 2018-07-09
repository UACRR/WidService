using System;
namespace ipsFormsDesign.Interfaces
{
public interface IAccount
    {    int AccId { get; set; }
         int? BalsCode { get; set; }
         int? CustId { get; set; }
         int? ObjId { get; set; }
         string R030 { get; set; }
         string AccNls { get; set; }
         DateTime? DateOpen { get; set; }
         DateTime? DateClose { get; set; }
         int AccStatus { get; set; }
         string AccName { get; set; }
         short? AccDk { get; set; }
         DateTime? DateModify { get; set; }
}
public interface IAccountBals
    {    int BalsCode { get; set; }
         short? BalsType { get; set; }
         string BalsNameUk { get; set; }
         string BalsNameRu { get; set; }
         string BalsNameEn { get; set; }
}
public interface IAccountStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IAccountStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IActivityType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IActivityTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAgreementAddBr
    {
         int AgrId { get; set; }
         int Version { get; set; }
         string AgrNumber { get; set; }
         DateTime? AgrDate { get; set; }
         DateTime? DateBegin { get; set; }
         DateTime? DateEnd { get; set; }
         int? PeriodCode { get; set; }
         int? AgrStatus { get; set; }
         int? DayForPay { get; set; }
         int? AnkVersion { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         int? CustId { get; set; }
}
public interface IAgreementAddPartner
    {
         int AgrId { get; set; }
         int? CustId { get; set; }
         decimal? SrFirstRate { get; set; }
         decimal? SrMonthRate { get; set; }
         decimal? PfFirstRate { get; set; }
         decimal? PfMonthRate { get; set; }
         decimal? CourtRate { get; set; }
         decimal? NoCourtRate { get; set; }
         decimal? CourtCompRate { get; set; }
         int Version { get; set; }
         string AgrNumber { get; set; }
         DateTime? AgrDate { get; set; }
         DateTime? DateBegin { get; set; }
         DateTime? DateEnd { get; set; }
         int? PeriodCode { get; set; }
         int? AgrStatus { get; set; }
         int? DayForPay { get; set; }
         int? AnkVersion { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
}
public interface IAgreementAddRh
    {
         int AgrId { get; set; }
         decimal? RateCourt { get; set; }
         decimal? RateCommiss { get; set; }
         string ResponsUser { get; set; }
         int? CustId { get; set; }
         int Version { get; set; }
         string AgrNumber { get; set; }
         DateTime? AgrDate { get; set; }
         DateTime? DateBegin { get; set; }
         DateTime? DateEnd { get; set; }
         int? PeriodCode { get; set; }
         int? DayForPay { get; set; }
         int? AnkVersion { get; set; }
         int? AgrStatus { get; set; }
         int? GetCode { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
}
public interface IAgreementMaster
    {    int AgrId { get; set; }
         int CustId { get; set; }
         int? AgrStatus { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         int? AgrType { get; set; }
         int? Version { get; set; }
}
public interface IAgreementStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IAgreementStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAgreementType
    {    int CodeI { get; set; }
         string Name { get; set; }
         string TemplateName { get; set; }
}
public interface IAgreementTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAgrLicenseType
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? KindCode { get; set; }
         int? UsesKind { get; set; }
         string TemplateName { get; set; }
         bool? NeedPlace { get; set; }
}
public interface IAgrLicenseTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAlgorithmType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IAlgorithmTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAnketaAddName
    {
         int CustId { get; set; }
         string Lang { get; set; }
         string NikName { get; set; }
         string FirstName { get; set; }
         string SurName { get; set; }
         string LastName { get; set; }
         string Name { get; set; }
         string ShortName { get; set; }
}
public interface IAnketaAddNick
    {
         int AddId { get; set; }
         int CustId { get; set; }
         string NikName { get; set; }
}
public interface IAnketaAddParam
    {
         int ParamCode { get; set; }
         string LangCode { get; set; }
         string ParamName { get; set; }
         int? CustId { get; set; }
         string ParamValue { get; set; }
}
public interface IAnketaCompany
    {
         int CustId { get; set; }
         int Version { get; set; }
         int? ActivityCode { get; set; }
         int Status { get; set; }
         string Name { get; set; }
         string ShortName { get; set; }
         string FaAddress { get; set; }
         string JaAddress { get; set; }
         string Okpo { get; set; }
         DateTime? RegistrDate { get; set; }
         int? TypeVat { get; set; }
         string NumberVat { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         string JaCity { get; set; }
         string FaCity { get; set; }
         string JaCountry { get; set; }
         string FaCountry { get; set; }
         int? BanAccId { get; set; }
         int? JaRegion { get; set; }
         int? FaRegion { get; set; }
         string RegistrNumber { get; set; }
         string RegistrWho { get; set; }
         string LeCity { get; set; }
         string LeCountry { get; set; }
         string LePostIndex { get; set; }
         int? LeRegion { get; set; }
         string LeAddress { get; set; }
}
public interface IAnketaExternal
    {
         int CustId { get; set; }
         string Name { get; set; }
         string InterCode { get; set; }
}
public interface IAnketaPerson
    {
         int CustId { get; set; }
         int Version { get; set; }
         int Status { get; set; }
         string FirstName { get; set; }
         string SurName { get; set; }
         string LastName { get; set; }
         string NikName { get; set; }
         int? Sex { get; set; }
         DateTime? BirthDate { get; set; }
         string PhoneMobileMain { get; set; }
         string PhoneMobileExtra { get; set; }
         string PhoneHome { get; set; }
         string EMail { get; set; }
         string Citizenship { get; set; }
         int? Residency { get; set; }
         string ReCountry { get; set; }
         string ReAddress { get; set; }
         string Inn { get; set; }
         string PUseries { get; set; }
         string PUnumber { get; set; }
         string PUissuedWho { get; set; }
         DateTime? PUissuedWhen { get; set; }
         string PFseries { get; set; }
         string PFnumber { get; set; }
         DateTime? PFissuedDate { get; set; }
         DateTime? PFvalidity { get; set; }
         string BuisNumberRegistration { get; set; }
         DateTime? BuisDateRegistration { get; set; }
         string BuisNumberPayer { get; set; }
         string BuisSertNumberPayer { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         int? TypeVat { get; set; }
         string ReCity { get; set; }
         string FaCountry { get; set; }
         string FaCity { get; set; }
         string FaAddress { get; set; }
         int? BanAccId { get; set; }
         int? FaRegion { get; set; }
         string Lang { get; set; }
         int? ReRegion { get; set; }
         string LeCountry { get; set; }
         int? LeRegion { get; set; }
         string LeCity { get; set; }
         string LeAddress { get; set; }
         string LePostIndex { get; set; }
}
public interface IAnketaStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IAnketaStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAspNetRoleClaims
    {
         int Id { get; set; }
         string ClaimType { get; set; }
         string ClaimValue { get; set; }
         string RoleId { get; set; }
}
public interface IAspNetRoles
    {    string Id { get; set; }
         string ConcurrencyStamp { get; set; }
         string Description { get; set; }
         string Name { get; set; }
         string NormalizedName { get; set; }
}
public interface IAspNetUserClaims
    {
         int Id { get; set; }
         string ClaimType { get; set; }
         string ClaimValue { get; set; }
         string UserId { get; set; }
}
public interface IAspNetUserLogins
    {
         string LoginProvider { get; set; }
         string ProviderKey { get; set; }
         string ProviderDisplayName { get; set; }
         string UserId { get; set; }
}
public interface IAspNetUserRoles
    {
         string UserId { get; set; }
         string RoleId { get; set; }
}
public interface IAspNetUsers
    {    string Id { get; set; }
         int AccessFailedCount { get; set; }
         string ConcurrencyStamp { get; set; }
         string Email { get; set; }
         bool EmailConfirmed { get; set; }
         string FirstName { get; set; }
         string LastName { get; set; }
         bool LockoutEnabled { get; set; }
         DateTimeOffset? LockoutEnd { get; set; }
         string NormalizedEmail { get; set; }
         string NormalizedUserName { get; set; }
         string PasswordHash { get; set; }
         string PhoneNumber { get; set; }
         bool PhoneNumberConfirmed { get; set; }
         string SecurityStamp { get; set; }
         string SurName { get; set; }
         bool TwoFactorEnabled { get; set; }
         string UserName { get; set; }
}
public interface IAspNetUserTokens
    {
         string UserId { get; set; }
         string LoginProvider { get; set; }
         string Name { get; set; }
         string Value { get; set; }
    }
public interface IAtreementStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IAuthors
    {
         int AuthId { get; set; }
         int ObjId { get; set; }
         int RoleCode { get; set; }
         int? CustId { get; set; }
         string AuthorName { get; set; }
         int? IsFolkOrUnknown { get; set; }
         int? FolkType { get; set; }
}
public interface IBankAccount
    {    int BanAccId { get; set; }
         int? CustId { get; set; }
         string AccountNumber { get; set; }
         string Currency { get; set; }
         string TransitNumber { get; set; }
         int? Mfo { get; set; }
         string MfoName { get; set; }
         string MfoOkpo { get; set; }
         string PIndex { get; set; }
         string PAddress { get; set; }
         string PCity { get; set; }
         string PCountry { get; set; }
         int? PRegion { get; set; }
}
public interface IBrRegister
    {    int RegId { get; set; }
         int? PeriodId { get; set; }
         int? CustId { get; set; }
         int? ReqIdSr { get; set; }
         DateTime? CreateDate { get; set; }
         decimal? FullAmount { get; set; }
         decimal? RAmount { get; set; }
         int? Status { get; set; }
         string FileName { get; set; }
         string UserId { get; set; }
}
public interface IBrRegItem
    {    int RegItemId { get; set; }
         int RegId { get; set; }
         int? ObjId { get; set; }
         int? LicId { get; set; }
         string ItemName { get; set; }
         int? CategoryCode { get; set; }
         int? CountUse { get; set; }
         int? NumTicket { get; set; }
         decimal? FullAmount { get; set; }
         decimal? FullRate { get; set; }
         decimal? RAmount { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         int? Status { get; set; }
}
public interface ICategory
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? Status { get; set; }
         string TableObj { get; set; }
         int? Utype { get; set; }
         string Comment { get; set; }
}
public interface ICategoryStatusType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ICategoryStatusTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICategoryTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IClient
    {    int CustId { get; set; }
         string ClientBrand { get; set; }
         string ClientGroup { get; set; }
}
public interface IClientBrand
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IClientBrandTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IClientGroup
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IClientGroupTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IClnBusinessPlace
    {    int PlaceId { get; set; }
         int? CustId { get; set; }
         int? PlCode { get; set; }
         string PlaceName { get; set; }
         string PlaceCountry { get; set; }
         int? PlaceRegion { get; set; }
         string PlaceCity { get; set; }
         string PlaceAddress { get; set; }
         string PlacePhone { get; set; }
         bool? FreeEntry { get; set; }
}
public interface IClnPlaceHoll
    {
         int HollId { get; set; }
         int? PlaceId { get; set; }
         string HollName { get; set; }
         string ValuePlace { get; set; }
         string ValueAdd { get; set; }
}
public interface ICommentCause
    {    int CauseCode { get; set; }
         string CauseNameUk { get; set; }
         string CauseNameRu { get; set; }
         string CauseNameEn { get; set; }
}
public interface ICommunity
    {    int CustId { get; set; }
}
public interface ICompany
    {    int CustId { get; set; }
         int Version { get; set; }
}
public interface IContinent
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IContinentTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICopyRight
    {
         int CRightId { get; set; }
         int CustId { get; set; }
         int? ObjId { get; set; }
         int? LBasis { get; set; }
         decimal? Rate { get; set; }
         decimal? RoleRate { get; set; }
         DateTime? BeginDate { get; set; }
         DateTime? EndDate { get; set; }
         string LBasisComment { get; set; }
         DateTime? CreateDate { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         bool? PermCode { get; set; }
         int? ParentId { get; set; }
         int? RoleCode { get; set; }
         int? Status { get; set; }
}
public interface ICopyrightKind
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? CrGroupCode { get; set; }
}
public interface ICopyrightKindTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICopyrightType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ICopyrightTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICopyRtranslate
    {
         int CRightId { get; set; }
         int? RoleCode { get; set; }
         string LangFrom { get; set; }
         string LangTo { get; set; }
}
public interface ICounterNumber
    {    int CounterId { get; set; }
         string Name { get; set; }
         int? CNum { get; set; }
         string Prefix { get; set; }
         string SymbolN { get; set; }
         short? TemplYear { get; set; }
}
public interface ICountry
    {    int? ContinentCode { get; set; }
         string CountryCode { get; set; }
         string CountryName { get; set; }
         string A2 { get; set; }
         string KOdLit { get; set; }
         string CountryNameShort { get; set; }
         short? ShortChoise { get; set; }
         int? OrderBy { get; set; }
}
public interface ICountryTr
    {
         string CountryCode { get; set; }
         string Lang { get; set; }
         string CountryName { get; set; }
         string CountryNameShort { get; set; }
}
public interface ICreativeRoleType
    {    int CodeI { get; set; }
         int CategoryCode { get; set; }
         string Name { get; set; }
         int Crtype { get; set; }
}
public interface ICreativeRoleTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICreativeTranslate
    {    int CodeI { get; set; }
}
public interface ICrightStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ICrightStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICrkindGroup
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ICrkindGroupTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICurrency
    {    string R030 { get; set; }
         string A3 { get; set; }
         string CountryCode { get; set; }
         string R030NameEn { get; set; }
         string R030NameRu { get; set; }
         string R030NameUk { get; set; }
         int? NOmin { get; set; }
         string NAim { get; set; }
         short? PrWork { get; set; }
         short? PrNc { get; set; }
         int? OrderBy { get; set; }
}
public interface ICurrencyCourse
    {
         string R030 { get; set; }
         DateTime CDate { get; set; }
         int? CUnit { get; set; }
         decimal? CAmount { get; set; }
         decimal? CAmountNbu { get; set; }
}
public interface ICustCmRight
    {
         int CustId { get; set; }
         int CRkindCode { get; set; }
         int CmCustId { get; set; }
         DateTime DateBegin { get; set; }
         DateTime DateEnd { get; set; }
}
public interface ICustomer
    {    int CustId { get; set; }
         int? CustType { get; set; }
         int Status { get; set; }
         int? AnkVersion { get; set; }
         byte? AnkMy { get; set; }
         byte? AnkPublish { get; set; }
         byte? AnkTech { get; set; }
}
public interface ICustomerStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ICustomerStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ICustomerType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ICustomerTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IDicCategoryItems
    {
         string DicName { get; set; }
         int Code { get; set; }
         string Name { get; set; }
         string Url { get; set; }
         string DicType { get; set; }
         int? DicLevel { get; set; }
}
public interface IDicList
    {
         int DicId { get; set; }
         string DKind { get; set; }
         int DCode { get; set; }
         string DNameUk { get; set; }
         string DNameRu { get; set; }
         string DNameEn { get; set; }
    }
public interface IDictCategory
    {    int Code { get; set; }
         string Name { get; set; }
}
public interface IDistribStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IDistribStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IDistribType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IDistribTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IDistribution
    {    int DistId { get; set; }
         int? RegId { get; set; }
         int? PeriodId { get; set; }
         int CRkindCode { get; set; }
         int Status { get; set; }
         DateTime DistribDate { get; set; }
         decimal Amount { get; set; }
         decimal PartnerCommiss { get; set; }
         decimal CourtFee { get; set; }
         int? PartnerId { get; set; }
         bool? IsCourt { get; set; }
         int? RegIdBr { get; set; }
         int? DistType { get; set; }
         int? CustId { get; set; }
}
public interface IDistributionItem
    {
         int DistId { get; set; }
         int? RegId { get; set; }
         int? RegIitemId { get; set; }
         decimal? Amount { get; set; }
         int? Status { get; set; }
         int? RegIdBr { get; set; }
         int? RegItemIdBr { get; set; }
         int DistItemId { get; set; }
         int? ObjId { get; set; }
}
public interface IDocPreparePay
    {
         int DocPayId { get; set; }
         DateTime DateWork { get; set; }
         int? RegId { get; set; }
         int? DistId { get; set; }
         string ND { get; set; }
         DateTime? NDdate { get; set; }
         int? AccIdDebet { get; set; }
         int? AccIdCredit { get; set; }
         string AccDebet { get; set; }
         string AccCredit { get; set; }
         decimal? Amount { get; set; }
         decimal? AmountCur { get; set; }
         string PayNote { get; set; }
         string R030 { get; set; }
         DateTime DateOper { get; set; }
         int? PayStatus { get; set; }
         int? Paidid { get; set; }
         byte? FlCourt { get; set; }
}
public interface IDocReq
    {
         int DocId { get; set; }
         int ReqId { get; set; }
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
         string TextUk { get; set; }
         string TextRu { get; set; }
         string TextEn { get; set; }
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
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IDocumentTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IEmployee
    {    int Emplid { get; set; }
         int? CustId { get; set; }
         string UserId { get; set; }
         string FirstName { get; set; }
         string SurName { get; set; }
         string LastName { get; set; }
         string PhoneNumber { get; set; }
         string Email { get; set; }
}
public interface IEpisodeType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IEpisodeTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IEtGenre
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? CategoryCode { get; set; }
}
public interface IEtGenreRate
    {
         int ActCode { get; set; }
         int GenreCode { get; set; }
         decimal? Rate { get; set; }
}
public interface IEtGenreRole
    {
         int GenreCode { get; set; }
         int RoleCode { get; set; }
         int ActCode { get; set; }
         decimal? Rate { get; set; }
}
public interface IEtRole
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? CategoryCode { get; set; }
}
public interface IExternalPay
    {
         int PaidId { get; set; }
         DateTime? InputDate { get; set; }
         string Mfo { get; set; }
         string Okpol { get; set; }
         string Account { get; set; }
         string R030 { get; set; }
         string CodeOper { get; set; }
         string MfoCorr { get; set; }
         string NameMfoCorr { get; set; }
         string AccountCorr { get; set; }
         string OkpoCorr { get; set; }
         string NameCorr { get; set; }
         string DocNum { get; set; }
         DateTime? DocDate { get; set; }
         decimal? SDebet { get; set; }
         decimal? SCredit { get; set; }
         string Nplat { get; set; }
         decimal? SNcCur { get; set; }
         int? Status { get; set; }
         DateTime? DateOper { get; set; }
    }
public interface IFileCustomer
    {
         int DocId { get; set; }
         int CustId { get; set; }
         int DocType { get; set; }
         DateTime? CreateDate { get; set; }
         string DocFile { get; set; }
         string DocComment { get; set; }
         string MimeType { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
}
public interface IFileType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IFolkType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IFolkTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
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
    {    int CodeI { get; set; }
         int CategoryCode { get; set; }
         string Name { get; set; }
}
public interface IGenreTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IInvoice
    {
         int DocId { get; set; }
         int? PayCustId { get; set; }
         int? RecCustId { get; set; }
         int? PayAnk { get; set; }
         int? RecAnk { get; set; }
         string R030 { get; set; }
         decimal? Amount { get; set; }
         string RecMfo { get; set; }
         string RecBankName { get; set; }
         string Purpose { get; set; }
         int? Status { get; set; }
    }
public interface IItemStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IItemStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IKindComposition
    {    int CodeI { get; set; }
         string Name { get; set; }
         int CategoryCode { get; set; }
}
public interface IKindCompositionTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IKindFilm
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IKindFilmTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IKindSerial
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IKindSerialTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
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
public interface ILang
    {    string CodeS { get; set; }
         string Name { get; set; }
}
public interface ILangTr
    {
         string CodeS { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ILanguage
    {    string CodeS { get; set; }
         string Name { get; set; }
         int? NameId { get; set; }
         string NameSh3 { get; set; }
         short? ShortChoise { get; set; }
}
public interface ILegalBasis
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ILegalBasisTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
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
public interface ILicAuthorBr
    {
         int CRightId { get; set; }
         int? PrepayType { get; set; }
         DateTime? DateCreate { get; set; }
         DateTime? DateClose { get; set; }
         DateTime? DateModify { get; set; }
         DateTime? DateAccept { get; set; }
         decimal? Rate { get; set; }
         decimal? PrepaySum { get; set; }
         decimal? PrepaySumAuthor { get; set; }
         string R030 { get; set; }
         DateTime? PrepayDateDo { get; set; }
}
public interface ILicense
    {
         int LId { get; set; }
         int? PlaceId { get; set; }
         int? LicId { get; set; }
         int? LicVersion { get; set; }
         string LNum { get; set; }
         DateTime? LDate { get; set; }
         int? Status { get; set; }
}
public interface ILicenseAgreement
    {    int LicId { get; set; }
         int LicCode { get; set; }
         int? LicType { get; set; }
         int? CustId { get; set; }
         int? LicStatus { get; set; }
         int LicClass { get; set; }
         int AgrId { get; set; }
         int? LicSize { get; set; }
         int? LicVersion { get; set; }
}
public interface ILicenseAgrParam
    {    int LicId { get; set; }
         int LicVersion { get; set; }
         string LicNum { get; set; }
         DateTime? LicDate { get; set; }
         DateTime? DateBegin { get; set; }
         DateTime? DateEnd { get; set; }
         decimal? MinAmount { get; set; }
         decimal? RateAmount { get; set; }
         bool? IsAutoprolog { get; set; }
         decimal? AddRate { get; set; }
         decimal? IndxInfl { get; set; }
         int? PeriodCode { get; set; }
         int? DayForPay { get; set; }
         int? LicStatus { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         int? AnkVersion { get; set; }
         string Comment { get; set; }
}
public interface ILicenseBigR
    {    int LicId { get; set; }
         DateTime? DatePremiere { get; set; }
         int? ObjId { get; set; }
         decimal? FillingRate { get; set; }
         int? PerformNumb { get; set; }
         decimal? TicketPriceNc { get; set; }
         decimal? TicketPriceUsd { get; set; }
         bool? IsTour { get; set; }
         string WhereTour { get; set; }
         decimal? Rate { get; set; }
         int LicVersion { get; set; }
         decimal? PrepayRest { get; set; }
         string LangCode { get; set; }
         int? PerformType { get; set; }
}
public interface ILicenseClass
    {
         int CodeI { get; set; }
         string Name { get; set; }
    }
public interface ILicenseType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ILicenseTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ILicPlace
    {
         int LicId { get; set; }
         int PlaceId { get; set; }
}
public interface ILicPlaceHoll
    {
         int LicId { get; set; }
         int PlaceId { get; set; }
         int HollId { get; set; }
}
public interface IMediaFile
    {
         int MediaFileId { get; set; }
         string FileType { get; set; }
         string Path { get; set; }
         double? Compress { get; set; }
         double? PlayTime { get; set; }
         int? ObjId { get; set; }
}
public interface IMediaSearchData
    {
         long Id { get; set; }
         int ObjId { get; set; }
         int TypeData { get; set; }
         string AlterName { get; set; }
         string AlterNameNormalize { get; set; }
    }
public interface IMediaTrack
    {    int ObjId { get; set; }
         string Iswc { get; set; }
         string Name { get; set; }
         string Lyrics { get; set; }
         string Composers { get; set; }
         string Performers { get; set; }
         string Album { get; set; }
         string Genre { get; set; }
         int? NumberInAlbum { get; set; }
         int? Year { get; set; }
         string Label { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         TimeSpan? Duration { get; set; }
}
public interface IModifyMusicType
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? KindCompCode { get; set; }
         int CategoryCode { get; set; }
}
public interface IModifyMusicTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IModifyTextType
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? KindCompCode { get; set; }
         int CategoryCode { get; set; }
}
public interface IModifyTextTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IModifyType
    {    int CodeI { get; set; }
         string Name { get; set; }
         int? KindCompCode { get; set; }
         int CategoryCode { get; set; }
}
public interface IModifyTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IMoneyLinkStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IMoneyLinkStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IMoneyPeriodLink
    {
         int PeriodId { get; set; }
         int PaidId { get; set; }
         int LicId { get; set; }
         DateTime ModifyDate { get; set; }
         decimal Amount { get; set; }
         int? Status { get; set; }
}
public interface IMoneyReceived
    {    int PaidId { get; set; }
         int CustId { get; set; }
         int MoneyType { get; set; }
         DateTime DateInvoice { get; set; }
         string NumberInvoice { get; set; }
         string GoalInvoice { get; set; }
         decimal Amount { get; set; }
         decimal DestribAmount { get; set; }
}
public interface IMoneyType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IMoneyTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IMusicalDesign
    {
         int MdId { get; set; }
         int LicId { get; set; }
         int? Objid { get; set; }
         int? ActNumb { get; set; }
         string ObjName { get; set; }
         string NameMusician { get; set; }
         string NameSinger { get; set; }
         int? NumbPerfom { get; set; }
         TimeSpan? Duration { get; set; }
         int? LicVersion { get; set; }
}
public interface IMyAnketa
    {    int CustId { get; set; }
         string AccCompany { get; set; }
         string AccCommission { get; set; }
         string AccInCommission { get; set; }
         string AccCourt { get; set; }
}
public interface IMyCategory
    {
         int CustId { get; set; }
         int CodeI { get; set; }
}
public interface IMyCopyRightType
    {
         int CustId { get; set; }
         int CRtype { get; set; }
}
public interface IObjAct
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IObjActTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IObjectRight
    {    int CategoryCode { get; set; }
         int ObjId { get; set; }
         int? ReqId { get; set; }
         int? GenreType { get; set; }
         string Name { get; set; }
         string Author { get; set; }
         string Performer { get; set; }
         int? Status { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         DateTime? CreateDate { get; set; }
         string ObjImg { get; set; }
         int? Loadid { get; set; }
         int? SpecType { get; set; }
         int? ActCode { get; set; }
         string InnerCode { get; set; }
}
public interface IObjectStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IObjectStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
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
    {    int PeriodId { get; set; }
         int CustId { get; set; }
         int PeriodType { get; set; }
         int LicId { get; set; }
         DateTime BeginDate { get; set; }
         DateTime EndDate { get; set; }
         int Status { get; set; }
         decimal Amount { get; set; }
         decimal Undistribamount { get; set; }
         decimal Distribamount { get; set; }
         string PeriodName { get; set; }
         bool? FagFirst { get; set; }
         DateTime? DateActPrint { get; set; }
}
public interface IPartner
    {    int CustId { get; set; }
}
public interface IPartnerClient
    {
         int CustId { get; set; }
         int ClCustId { get; set; }
}
public interface IPaymentCase
    {
         int ReqId { get; set; }
         int? PayKind { get; set; }
         int? PayMethod { get; set; }
         int? PtId { get; set; }
         DateTime? DateForPay { get; set; }
         DateTime? DateInvoce { get; set; }
         DateTime? DatePay { get; set; }
         int? PayStatus { get; set; }
         DateTime? DatePayFact { get; set; }
         string OtherCase { get; set; }
}
public interface IPaymentKind
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IPaymentKindTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPaymentStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IPaymentStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPayMethodType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IPayMethodTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPayTurn
    {
         int TurnId { get; set; }
         DateTime DateWork { get; set; }
         string ND { get; set; }
         DateTime? NDdate { get; set; }
         int? AccIdDebet { get; set; }
         int? AccIdCredit { get; set; }
         string AccDebet { get; set; }
         string AccCredit { get; set; }
         decimal? Amount { get; set; }
         decimal? AmountCur { get; set; }
         string PayNote { get; set; }
         string R030 { get; set; }
         DateTime DateOper { get; set; }
         int? PayStatus { get; set; }
         int? RegId { get; set; }
         int? DistId { get; set; }
}
public interface IPerformer
    {    int PerId { get; set; }
         string PerName { get; set; }
}
public interface IPerformType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IPerformTypetTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPeriod
    {    int CodeI { get; set; }
         string Name { get; set; }
         string NameR { get; set; }
}
public interface IPeriodStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IPeriodStatusTr
    {
         int CodeI { get; set; }
         string Name { get; set; }
         string Lang { get; set; }
}
public interface IPeriodTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
         string NameR { get; set; }
}
public interface IPermitType
    {    bool CodeB { get; set; }
         string Name { get; set; }
}
public interface IPermitTypeTr
    {
         bool CodeB { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPerson
    {    int CustId { get; set; }
         int Version { get; set; }
}
public interface IPopGenre
    {    int CategoryCode { get; set; }
         string Name { get; set; }
         int Id { get; set; }
}
public interface IPopGenreTr
    {
         int Id { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPortalObjectRights
    {
         int ObjId { get; set; }
         int CRkindCode { get; set; }
         int Enable { get; set; }
}
public interface IPortalSupportRights
    {    int CRkindCode { get; set; }
}
public interface IPositionType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IPositionTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IPrePayType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IPrePayTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IRegion
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IRegionTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IRegister
    {    int RegId { get; set; }
         int? CustId { get; set; }
         int? CountRows { get; set; }
         string Login { get; set; }
         int? RgStatus { get; set; }
         DateTime? CreateDate { get; set; }
         int? PeriodId { get; set; }
         string UserId { get; set; }
         string FileName { get; set; }
         int? LicId { get; set; }
         TimeSpan? DurationItems { get; set; }
}
public interface IRegisterCount
    {
         decimal RegCntId { get; set; }
         int? RegId { get; set; }
         int? RegIitemId { get; set; }
         int? ObjId { get; set; }
         int? CustId { get; set; }
         int? CRtype { get; set; }
         int? CRkindCode { get; set; }
         decimal? Rate { get; set; }
         decimal? RateCommiss { get; set; }
         int? CmCustId { get; set; }
         int? RegIdBr { get; set; }
         int? RegItemIdBr { get; set; }
}
public interface IRegisterItem
    {    int RegId { get; set; }
         int RegIitemId { get; set; }
         int? ObjId { get; set; }
         string ItemName { get; set; }
         int? CategoryCode { get; set; }
         string Performer { get; set; }
         string AuthorMusic { get; set; }
         string AuthorText { get; set; }
         int? CountUse { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         TimeSpan? DurationUse { get; set; }
         TimeSpan? DurationItem { get; set; }
}
public interface IRegisterStatus
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IRegisterStatusTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IRelAdaptUseArea
    {
         int ReqId { get; set; }
         int UseAreaTypeCode { get; set; }
}
public interface IRelCounterDoc
    {
         int CDocId { get; set; }
         int CounterId { get; set; }
         int DocType { get; set; }
         int? LicType { get; set; }
}
public interface IRelDocAgrType
    {
         int AgrType { get; set; }
         int DocType { get; set; }
}
public interface IRelEmployee
    {
         int Emplid { get; set; }
         int CustId { get; set; }
         int PositionCode { get; set; }
         string RelDocument { get; set; }
}
public interface IRelEtGenre
    {
         int GenreCode { get; set; }
         int EtGenreCode { get; set; }
}
public interface IRelEtRole
    {
         int RoleCode { get; set; }
         int EtRoleCode { get; set; }
}
public interface IRelGenreAdapt
    {
         int ReqId { get; set; }
         int GenreId { get; set; }
}
public interface IRelGenreMovie
    {
         int ReqId { get; set; }
         int GenreId { get; set; }
}
public interface IRelGenrePercent
    {
         int ActCode { get; set; }
         int GenreType { get; set; }
         decimal? Rate { get; set; }
}
public interface IRelGenreRole
    {
         int RoleCode { get; set; }
         int GenreType { get; set; }
         decimal? Rate { get; set; }
         int ActCode { get; set; }
}
public interface IRelGenreSerial
    {
         int ReqId { get; set; }
         int GenreId { get; set; }
}
public interface IRelLicCopyR
    {
         int AgrLlicCode { get; set; }
         int CRkindCode { get; set; }
}
public interface IRelMovieEpisode
    {
         int EpisodeTypeCode { get; set; }
         int ReqId { get; set; }
         double? EpDuration { get; set; }
}
public interface IRelObjGenre
    {
         int GenreId { get; set; }
         int ObjId { get; set; }
}
public interface IRelObjPerformer
    {
         int ObjId { get; set; }
         int PerId { get; set; }
}
public interface IRelPopGenre
    {
         int GenreId { get; set; }
         int ObjId { get; set; }
}
public interface IRelReqMedia
    {
         int UseMediaTypeCode { get; set; }
         int ReqId { get; set; }
}
public interface IRelReqObj
    {
         int CategoryCode { get; set; }
         int ReqType { get; set; }
         int KindGroupId { get; set; }
         int? CrkindCode { get; set; }
}
public interface IRelSerialEpisode
    {
         int ReqId { get; set; }
         int EpisodeTypeCode { get; set; }
         double? EpDuration { get; set; }
}
public interface IRelTvepisode
    {
         int ReqId { get; set; }
         int EpisodeTypeCode { get; set; }
         double? EpDuration { get; set; }
}
public interface IReports
    {
         int Id { get; set; }
         string Repname { get; set; }
    }
public interface IReqAgreement
    {    int RAgrId { get; set; }
         int CustId { get; set; }
         int? CustIdRh { get; set; }
         int? ReqId { get; set; }
         string R030 { get; set; }
         decimal? Amount { get; set; }
         decimal? CostOffer { get; set; }
         int Status { get; set; }
         DateTime? AgrDate { get; set; }
         string UserId { get; set; }
         DateTime? ModifyDate { get; set; }
         int? TradeId { get; set; }
         string R030Offer { get; set; }
         DateTime? StatusDate { get; set; }
         string RAgrComment { get; set; }
}
public interface IReqAgreementStatus
    {    int StatusCode { get; set; }
         string StatusNameUk { get; set; }
         string StatusNameRu { get; set; }
         string StatusNameEn { get; set; }
}
public interface IReqCustomer
    {    int ReqCustId { get; set; }
         int? CustId { get; set; }
         string Name { get; set; }
         string CountryCode { get; set; }
         string Okpo { get; set; }
         string NickName { get; set; }
         int? ActivityCode { get; set; }
         string Comment { get; set; }
}
public interface IReqLocationUse
    {
         int LocUsId { get; set; }
         int? ReqId { get; set; }
         string CountryCode { get; set; }
         int? ContinentCode { get; set; }
}
public interface IReqTrade
    {
         int TradeId { get; set; }
         int ReqId { get; set; }
         string R030 { get; set; }
         decimal? CostRholder { get; set; }
         DateTime? CreateDate { get; set; }
         int RAgrId { get; set; }
         int Status { get; set; }
         DateTime? StatusDate { get; set; }
         DateTime? ModifyDate { get; set; }
         decimal? CostClient { get; set; }
         string TradeComment { get; set; }
         int? CauseCode { get; set; }
}
public interface IRequest
    {    int ReqId { get; set; }
         int? CategoryCode { get; set; }
         int ReqType { get; set; }
         DateTime? ReqDate { get; set; }
         int? CountUse { get; set; }
         DateTime? BeginDate { get; set; }
         DateTime? EndDate { get; set; }
         int Reqstatus { get; set; }
         int? CustId { get; set; }
         string UserId { get; set; }
         int ReqAimCode { get; set; }
         int? ObjId { get; set; }
         int? KindCompCode { get; set; }
         int? TermUseCode { get; set; }
         DateTime? CreateDate { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
         int? LicCode { get; set; }
         int? ReqCustId { get; set; }
         string ReqComment { get; set; }
         string R030 { get; set; }
         decimal? ReqAmount { get; set; }
         string WorkName { get; set; }
         TimeSpan? DurationUse { get; set; }
}
public interface IRequestAdapt
    {    int ReqId { get; set; }
         string ExecNick { get; set; }
         int? ModifyType { get; set; }
         int? ModifyTextType { get; set; }
         string ModifyTextComment { get; set; }
         int? ModifyMusicType { get; set; }
         string ModifyMusictComment { get; set; }
         string UseAreaComment { get; set; }
}
public interface IRequestAdvertising
    {
         int ReqId { get; set; }
         string TradeMark { get; set; }
         TimeSpan? DurationAll { get; set; }
         TimeSpan? DurationShort { get; set; }
}
public interface IRequestAim
    {    int CodeI { get; set; }
         int ReqType { get; set; }
         string Name { get; set; }
         int CategoryCode { get; set; }
}
public interface IRequestAimTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IRequestInternet
    {
         int ReqId { get; set; }
         int? TypeInternetObject { get; set; }
         string Url { get; set; }
         string UseDesc { get; set; }
}
public interface IRequestMovie
    {    int ReqId { get; set; }
         int? KindFilm { get; set; }
         string EpisodeComment { get; set; }
         bool? UseHire { get; set; }
         bool? UseFestival { get; set; }
}
public interface IRequestOther
    {
         int ReqId { get; set; }
         string UseDesc { get; set; }
}
public interface IRequestSerial
    {    int ReqId { get; set; }
         int? KindSerial { get; set; }
         string EpisodeComment { get; set; }
         short? CntSeries { get; set; }
         bool? UseHire { get; set; }
         bool? UseFestival { get; set; }
}
public interface IRequestStatusType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IRequestStatusTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IRequestTvradio
    {    int ReqId { get; set; }
         string ShortTitle { get; set; }
         string NameTvchanel { get; set; }
         string EpisodeComment { get; set; }
}
public interface IRequestType
    {    int CodeI { get; set; }
         int CategoryCode { get; set; }
         string Name { get; set; }
}
public interface IRequestTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IResidentType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IResidentTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IRholderType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IRholderTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IRightHolder
    {    int CustId { get; set; }
         byte? SignP { get; set; }
         bool? AroundWord { get; set; }
         string InterCode { get; set; }
         string InnerCode { get; set; }
         int? RHolderType { get; set; }
}
public interface ISaldoDay
    {
         int AccId { get; set; }
         DateTime DateBegin { get; set; }
         DateTime DateEnd { get; set; }
         string R030 { get; set; }
         decimal? Rest { get; set; }
         decimal? RestCourt { get; set; }
         decimal? Deboborot { get; set; }
         decimal? KrdOborot { get; set; }
         decimal? DeboborotCourt { get; set; }
         decimal? KrdOborotCourt { get; set; }
         decimal? RestBegin { get; set; }
         decimal? RestBeginCourt { get; set; }
    }
public interface ISeekObject
    {
         int Id { get; set; }
         int? CodeI { get; set; }
         int? ObjId { get; set; }
         string Name { get; set; }
}
public interface ISeekType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ISeekTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ISexType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ISexTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ISpecType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ISpecTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ITableColumn
    {
         decimal Id { get; set; }
         string Lang { get; set; }
         string CName { get; set; }
         string TName { get; set; }
         string DText { get; set; }
         string HText { get; set; }
    }
public interface ITableColumnTech
    {
         decimal Id { get; set; }
         string Cname { get; set; }
         string Tname { get; set; }
         string DnameUk { get; set; }
         string DnameRu { get; set; }
         string DnameEn { get; set; }
         short? TypeTab { get; set; }
    }
public interface ITableObject
    {
         decimal Id { get; set; }
         string Lang { get; set; }
         string CName { get; set; }
         string DText { get; set; }
         string HText { get; set; }
    }
public interface ITableType
    {
         string TName { get; set; }
         short? TType { get; set; }
    }
public interface ITermsOfService
    {    int CustId { get; set; }
         int CrkindCode { get; set; }
         bool OurService { get; set; }
}
public interface ITermUse
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ITermUseTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ITerritoryExclude
    {
         int CustId { get; set; }
         string CountryCode { get; set; }
}
public interface ITerritoryInclude
    {
         int CustId { get; set; }
         string CountryCode { get; set; }
}
public interface ITmpTradeLog
    {
         int Id { get; set; }
         int? RegId { get; set; }
         string Value { get; set; }
         DateTime? ModifyDate { get; set; }
    }
public interface ITradeStatus
    {    int StatusCode { get; set; }
         string StatusNameUk { get; set; }
         string StatusNameRu { get; set; }
         string StatusNameEn { get; set; }
}
public interface ITypeInternetObject
    {    int CodeI { get; set; }
         string Name { get; set; }
         string TypeInetNameEn { get; set; }
         string TypeInetNameRu { get; set; }
}
public interface ITypeInternetObjectTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ITypeMethodGet
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ITypeMethodGetTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ITypePlace
    {    int CodeI { get; set; }
         string Name { get; set; }
         bool? IsHoll { get; set; }
         int? ParamType { get; set; }
}
public interface ITypePlaceParam
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ITypePlaceParamTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ITypePlaceTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface ITypeVat
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface ITypeVattr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IUseAreaType
    {    int CodeI { get; set; }
         int CategoryCode { get; set; }
         int ReqType { get; set; }
         string Name { get; set; }
}
public interface IUseAreaTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IUseMediaType
    {    int CodeI { get; set; }
         int ReqType { get; set; }
         string Name { get; set; }
         int CategoryCode { get; set; }
}
public interface IUseMediaTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IUserRole
    {
         int CustId { get; set; }
         int RoleType { get; set; }
         string UserId { get; set; }
         int? Status { get; set; }
}
public interface IUserRoleType
    {    int CodeI { get; set; }
         int IsAdmin { get; set; }
         string TypeNameRu { get; set; }
         string TypeNameEn { get; set; }
         string Name { get; set; }
}
public interface IUserRoleTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IUsesKind
    {    int CodeI { get; set; }
         int? UsesType { get; set; }
         string Name { get; set; }
}
public interface IUsesKindTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IUsesType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IUsesTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}
public interface IWorkRh
    {
         int CRightId { get; set; }
         int? WorkTypeRh { get; set; }
         string WorkCommentRh { get; set; }
         DateTime? WorkDateRh { get; set; }
         int? WorkTypeCl { get; set; }
         DateTime? WorkDateCl { get; set; }
         string WorkCoommentCl { get; set; }
         DateTime? ModifyDate { get; set; }
         string ModifyLogin { get; set; }
}
public interface IWorkType
    {    int CodeI { get; set; }
         string Name { get; set; }
}
public interface IWorkTypeTr
    {
         int CodeI { get; set; }
         string Lang { get; set; }
         string Name { get; set; }
}

}

