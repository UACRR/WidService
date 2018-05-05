using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    interface ILicPlace
	{
        int LicId { get; set; }
        int PlaceId { get; set; }
        ILicenseAgreement Lic { get; set; }
        IClnBusinessPlace Place { get; set; }
        ICollection<ILicPlaceHoll> LicPlaceHoll { get; set; }
	}
	interface ILicPlaceHoll
	{
        int LicId { get; set; }
        int PlaceId { get; set; }
        int HollId { get; set; }

        IClnPlaceHoll Holl { get; set; }
        ILicPlace LicPlace { get; set; }

	}
	interface IClnPlaceHoll
	{
        int HollId { get; set; }
        int? PlaceId { get; set; }
        string HollName { get; set; }
        int? HollNum { get; set; }
        bool? СalcNum { get; set; }
        decimal? SqHoll { get; set; }
        ICollection<ILicPlaceHoll> LicPlaceHoll { get; set; }

	}
	interface IClnBusinessPlace
	{
        int PlaceId { get; set; }
        int? CustId { get; set; }
        int? PlCode { get; set; }
        string PlaceName { get; set; }
        string PlaceCountry { get; set; }
        int? PlaceRegion { get; set; }
        string PlaceCity { get; set; }
        string PlaceAddress { get; set; }
        string PlacePhone { get; set; }
        bool? FreeEntry { get; set; }

        ICollection<IClnPlaceHoll> ClnPlaceHoll { get; set; }
        ICollection<ILicPlace> LicPlace { get; set; }

	}

	interface IMediaFile
	{
        int MediaFileId { get; set; }
        string FileType { get; set; }
        string Path { get; set; }
        double? Compress { get; set; }
        double? PlayTime { get; set; }
        int? ObjId { get; set; }
		
	}
	interface IMediaTrack
	{
        int ObjId { get; set; }
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
        double? Duration { get; set; }

        ICollection<IMediaFile> MediaFile { get; set; }
		
	}
	interface IObjectRight
	{
        int CategoryCode { get; set; }
        int ObjId { get; set; }
        int? ReqId { get; set; }
        int? ObjType { get; set; }
        string Name { get; set; }
        string Author { get; set; }
        string Performer { get; set; }
        int? Status { get; set; }
        DateTime? ModifyDate { get; set; }
        string ModifyLogin { get; set; }
        DateTime? CreateDate { get; set; }
        string ObjImg { get; set; }
        int? Loadid { get; set; }

        // ObjectType ObjectType { get; set; }
	}
	interface ILicenseBigR
	{
        int LicId { get; set; }
        DateTime? DatePremiere { get; set; }
        int? ObjId { get; set; }
        decimal? FillingRate { get; set; }
        int? PerfomNumb { get; set; }
        decimal? TicketPriceNc { get; set; }
        decimal? TicketPriceUsd { get; set; }
        bool? IsTour { get; set; }
        string WhereTour { get; set; }
	}
	interface IMoneyPeriodLink
	{
        int PeriodId { get; set; }
        int PaidId { get; set; }
        int LicId { get; set; }
        DateTime ModifyDate { get; set; }
        decimal Amount { get; set; }

	}
	interface ILicenseAgreement
	{
        int LicId { get; set; }
        int? LicCode { get; set; }
        int? LicType { get; set; }
        int? CustId { get; set; }
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
        int? ParentLicId { get; set; }
        int? LicStatus { get; set; }
        int? DayForPay { get; set; }
	}
	interface IMoneyReceived
	{
        int PaidId { get; set; }
        int CustId { get; set; }
        int MoneyType { get; set; }
        DateTime DateInvoice { get; set; }
        string NumberInvoice { get; set; }
        string GoalInvoice { get; set; }
        decimal Amount { get; set; }
        decimal DestribAmount { get; set; }
	
	}

	interface IDistributionItem
	{
        int DistId { get; set; }
        int RegId { get; set; }
        int RegIitemId { get; set; }
        decimal? Amount { get; set; }
        int? Status { get; set; }
		
	}
	interface IDistribution
	{
        int DistId { get; set; }
        int RegId { get; set; }
        int? PeriodId { get; set; }
        int CRkindCode { get; set; }
        int Status { get; set; }
        DateTime DistribDate { get; set; }
        decimal Amount { get; set; }
        decimal PartnerCommiss { get; set; }
        decimal CourtFee { get; set; }
        int? PartnerId { get; set; }
        bool? IsCourt { get; set; }

	
	}
	interface IPaidPeriod
	{
        int PeriodId { get; set; }
        int CustId { get; set; }
        int PeriodType { get; set; }
        int? LicId { get; set; }
        DateTime BeginDate { get; set; }
        DateTime EndDate { get; set; }
        int Status { get; set; }
        decimal Amount { get; set; }
        decimal Undistribamount { get; set; }
        decimal Distribamount { get; set; }
        string PeriodName { get; set; }
        bool? FagFirst { get; set; }
		
	}

	interface IClient
	{
        int CustId { get; set; }
        ICollection<IClnBusinessPlace> ClnBusinessPlace { get; set; }
        ICollection<ILicenseAgreement> LicenseAgreement { get; set; }
        ICollection<IMoneyReceived> MoneyReceived { get; set; }
        ICollection<IPaidPeriod> PaidPeriod { get; set; }

	}
	
	interface ICommunity
	{
        int CustId { get; set; }
		
	}
	interface IRelEmployee
	{
        int Emplid { get; set; }
        int CustId { get; set; }
        int PositionCode { get; set; }
        string RelDocument { get; set; }
	}
	interface ICompany
	{
        int CustId { get; set; }
        int Version { get; set; }
	}

	interface IMyAnketa
	{
	}

	interface IPartner
	{
        int CustId { get; set; }
	}
	interface IPerson
	{
        int CustId { get; set; }
        int Version { get; set; }
	
	}
	interface IRightHolder
	{
        int CustId { get; set; }
        byte? SignP { get; set; }
        bool? AroundWord { get; set; }
        string InterCode { get; set; }
        string InnerCode { get; set; }
        int? GetCode { get; set; }
	
	}
    
	interface ITerritoryInclude
	{
        int CustId { get; set; }
        string CountryCode { get; set; }

	}
	interface ITerritoryExclude
	{
        int CustId { get; set; }
        string CountryCode { get; set; }
	}
	interface ITermsOfService
	{
        int CustId { get; set; }
        int CrkindCode { get; set; }
	}
	interface IAnketaAddNick
	{
        int AddId { get; set; }
        int CustId { get; set; }
        string NikName { get; set; }
		
	}
	interface IAgreementAddRh
	{
        int AgrId { get; set; }
        decimal? RateCourt { get; set; }
        decimal? RateCommiss { get; set; }
        string ResponsUser { get; set; }
        int? CustId { get; set; }

	}
	interface IAgreementMaster
	{
        int AgrId { get; set; }
        int CustId { get; set; }
        int? ParentAgrId { get; set; }
        int? AgrStatus { get; set; }
        string AgrNumber { get; set; }
        DateTime? AgrDate { get; set; }
        DateTime? DateBegin { get; set; }
        DateTime? DateEnd { get; set; }
        DateTime? ModifyDate { get; set; }
        string ModifyLogin { get; set; }
        int? AgrType { get; set; }
		
	}
	interface IAnketaAddName
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
	interface IAnketaAddParam
	{
        int ParamCode { get; set; }
        string LangCode { get; set; }
        string ParamName { get; set; }
        int? CustId { get; set; }
        string ParamValue { get; set; }
	}
	interface IAnketaCompany
	{
        int CustId { get; set; }
        int Version { get; set; }
        int? ActivityCode { get; set; }
        int? IsCurrent { get; set; }
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
		
	}
	interface IAnketaPerson
	{
        int CustId { get; set; }
        int Version { get; set; }
        int? IsCurrent { get; set; }
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
	interface IBankAccount
	{
        int BanAccId { get; set; }
        int? CustId { get; set; }
        string AccountNumber { get; set; }
        string Currency { get; set; }
        string TransitNumber { get; set; }
        int? Mfo { get; set; }
        string MfoName { get; set; }
        string MfoOkpo { get; set; }
		
	}
	interface IEmployee
	{
        int Emplid { get; set; }
        int? CustId { get; set; }
        string UserId { get; set; }
        string FirstName { get; set; }
        string SurName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }

	}
	interface IRegister
	{
        int RegId { get; set; }
        int? CustId { get; set; }
        int? CountRows { get; set; }
        double? DurationItems { get; set; }
        string Login { get; set; }
        int? RgStatus { get; set; }
        DateTime? CreateDate { get; set; }
        int? PeriodId { get; set; }
        string UserId { get; set; }
        string FileName { get; set; }
        decimal? FullAmount { get; set; }
        decimal? FullRate { get; set; }
        int? NumTiket { get; set; }
		
	}
	interface IReqAgreement
	{
        int RAgrId { get; set; }
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
	interface IReqCustomer
	{
        int ReqCustId { get; set; }
        int? CustId { get; set; }
        string Name { get; set; }
        string CountryCode { get; set; }
        string Okpo { get; set; }
        string NickName { get; set; }
        int? ActivityCode { get; set; }
        string Comment { get; set; }
		
	}
	interface IRequest
	{
        int ReqId { get; set; }
        int? CategoryCode { get; set; }
        int ReqType { get; set; }
        DateTime? ReqDate { get; set; }
        int? CountUse { get; set; }
        DateTime? BeginDate { get; set; }
        DateTime? EndDate { get; set; }
        double? DurationUse { get; set; }
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
                
	}
	interface IUserRole
	{
        int CustId { get; set; }
        int RoleType { get; set; }
        string UserId { get; set; }
        int? Status { get; set; }

	}
    
	
	interface ICustomer
    {
        int CustId { get; set; }
        int? CustType { get; set; }
        int Status { get; set; }
        int? AnkVersion { get; set; }
        byte? AnkMy { get; set; }
        byte? AnkPublish { get; set; }
        byte? AnkTech { get; set; }

    }
}
