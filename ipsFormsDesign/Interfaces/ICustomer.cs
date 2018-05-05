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

        ICollection<ILicenseAgreement> InverseParentLic { get; set; }
        ICollection<ILicPlace> LicPlace { get; set; }
        ICollection<IMoneyPeriodLink> MoneyPeriodLink { get; set; }
        ICollection<IPaidPeriod> PaidPeriod { get; set; }

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
        ICollection<IMoneyPeriodLink> MoneyPeriodLink { get; set; }
		
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

        ICollection<IDistributionItem> DistributionItem { get; set; }
		
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
        ICollection<IDistribution> Distribution { get; set; }
        ICollection<IMoneyPeriodLink> MoneyPeriodLink { get; set; }
		
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
        // ICollection<CustCmRight> CustCmRight { get; set; }
        // ICollection<RegisterCount> RegisterCount { get; set; }
		
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

        ICollection<IRelEmployee> RelEmployee { get; set; }
		
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

        ICollection<IAgreementAddRh> AgreementAddRh { get; set; }
        ICollection<IAnketaAddNick> AnketaAddNick { get; set; }
        ICollection<IReqAgreement> ReqAgreement { get; set; }
        ICollection<ITermsOfService> TermsOfService { get; set; }
        ICollection<ITerritoryExclude> TerritoryExclude { get; set; }
        ICollection<ITerritoryInclude> TerritoryInclude { get; set; }
		
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
	interface IAccount
	{
	}
	interface IAgreementMaster
	{
	}
	interface IAnketaAddName
	{
	}
	interface IAnketaAddParam
	{
	}
	interface IAnketaCompany
	{
	}
	interface IAnketaPerson
	{
	}
	interface IBankAccount
	{
	}
	interface IEmployee
	{
	}
	interface IRegister
	{
	}
	interface IReqAgreement
	{
	}
	interface IReqCustomer
	{
	}
	interface IRequest
	{
	}
	interface IUserRole
	{
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

        IClient Client { get; set; }
        ICommunity Community { get; set; }
        ICompany Company { get; set; }
		
        IMyAnketa MyAnketa { get; set; }
        IPartner Partner { get; set; }
        IPerson Person { get; set; }
        IRightHolder RightHolder { get; set; }
        
		ICollection<IAccount> Account { get; set; }
        ICollection<IAgreementMaster> AgreementMaster { get; set; }
        ICollection<IAnketaAddName> AnketaAddName { get; set; }
        ICollection<IAnketaAddParam> AnketaAddParam { get; set; }
        ICollection<IAnketaCompany> AnketaCompany { get; set; }
        ICollection<IAnketaPerson> AnketaPerson { get; set; }
        ICollection<IBankAccount> BankAccount { get; set; }
        ICollection<IEmployee> Employee { get; set; }
        ICollection<IRegister> Register { get; set; }
        ICollection<IReqAgreement> ReqAgreement { get; set; }
        ICollection<IReqCustomer> ReqCustomer { get; set; }
        ICollection<IRequest> Request { get; set; }
        ICollection<IUserRole> UserRole { get; set; }

    }
}
