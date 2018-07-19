using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;
using ipsFormsDesign.Model;

namespace ipsFormsDesign.Interfaces
{
    public class ConsumerMainView
    {
        public int CustId { get; set; }
        public string Innokpo { get; set; }
        public string Name { get; set; }
        public int CountAgree { get; set; }
        public decimal Undistribamount { get; set; }
    }

    /// <summary>
    /// Дані для GridView Для великих прав
    /// </summary>
    public class ConsumerBigRightView
    {
        /// <summary>
        /// Тип Ген. угоди
        /// </summary>
        public int AgrType { get; set; }
        /// <summary>
        /// Назва Типу
        /// </summary>
        public string AgrTypeName { get; set; }
        /// <summary>
        /// Ід Сподивача
        /// </summary>
        public int CustId { get; set; }
        /// <summary>
        /// ЄДРПОУ
        /// </summary>
        public string Innokpo { get; set; }
        /// <summary>
        /// Ід Генеральной угоди
        /// </summary>
        public int AgrId { get; set; }
        /// <summary>
        /// Номер Ген. угоди
        /// </summary>
        public string AgrNumber { get; set; }
        /// <summary>
        /// Дата ген. угоди
        /// </summary>
        public DateTime? AgrDate { get; set; }
        /// <summary>
        /// Дата початку дії
        /// </summary>
        public DateTime? DateBegin { get; set; }
        /// <summary>
        /// Кінцева дата дії
        /// </summary>
        public DateTime? DateEnd { get; set; }
        /// <summary>
        ///  Назва Споживача
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Код країни Споживача 
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Місто
        /// </summary>        
        public string JaCity { get; set; }
        /// <summary>
        ///  Статус Ген. Угоди
        /// </summary>
        public int AgrStatus { get; set; }
        /// <summary>
        /// Назва статусу 
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// Статус Доп угоди
        /// </summary>
        public int AddStatus { get; set; }
        /// <summary>
        /// Назва Статус 
        /// </summary>
        public string AddStatusName { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int CountLic1Active { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int CountLic1NoActive { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int CountLic1ToProlong { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int CountLic2Active { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int CountLic2NoActive { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int CountLic3Active { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int CountLic3NoActive { get; set; }
        /// <summary>
        /// Сума
        /// </summary>
        public decimal UndistribAmount { get; set; }
        /// <summary>
        /// Сума
        /// </summary>
        public decimal Borg { get; set; }
        /// <summary>
        /// Сума
        /// </summary>
        public decimal UnattachAmount { get; set; }
        /// <summary>
        /// Сума
        /// </summary>
        public decimal PrePayRest { get; set; }
        /// <summary>
        /// Дата останього платежу
        /// </summary>
        public DateTime DatePayLast { get; set; }
        /// <summary>
        /// Ід Партнера
        /// </summary>
        public int ClcustId { get; set; }
        /// <summary>
        /// Назва Партнера
        /// </summary>
        public string PartnerName { get; set; }
        /// <summary>
        /// Адреса
        /// </summary>
        public string JaAddress { get; set; }

    }

    public interface IConsumerService : IModel
    {
        IList<ConsumerMainView> GetMainView();
        IList<AutoCompleteData> GetAutoCompleteList(string filter);
    }

    public class VbrLicense
    {
        public DateTime? AgrDate { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? LicDate { get; set; }
        public DateTime? LicDateBegin { get; set; }
        public DateTime? LicDateEnd { get; set; }
        public DateTime? DatePremiere { get; set; }
        public int? LicType { get; set; }
        public int? CustId { get; set; }
        public int AgrId { get; set; }
        public int? AgrStatus { get; set; }
        public int LicId { get; set; }
        public int LicVersion { get; set; }
        public int? LicStatus { get; set; }
        public int? Objid { get; set; }
        public int? ObjStatus { get; set; }
        public int? GenreType { get; set; }
        public int? PerformNumb { get; set; }
        public decimal? Borg { get; set; }
        public decimal? PrepayPaush { get; set; }
        public decimal? PrepayAvans { get; set; }
        public decimal? PrepayRest { get; set; }
        public decimal? TicketPriceNC { get; set; }
        public decimal? TicketPriceUSD { get; set; }
        public bool? IsTour { get; set; }
        public decimal? GenreRate72 { get; set; }
        public decimal? Rate { get; set; }
        public decimal? FillingRate { get; set; }
        public string LicTypeName { get; set; }
        public string Name { get; set; }
        public string AgrNumber { get; set; }
        public string AgrStatusName { get; set; }
        public string LicNum { get; set; }
        public string LicStatusName { get; set; }
        public string ObjName { get; set; }
        public string GenreName { get; set; }
        public string WhereTour { get; set; }
        public string ToProlong { get; set; }
        public string Comment { get; set; }
        public string R030 { get; set; }
    }

    /// <summary>
    /// Дані генеральних угод
    /// </summary>
    public class BigRightMasterGenAgr
    {
        public DateTime? AgrDate { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string AgrNumber { get; set; }
        public int Agrid { get; set; }
        public int Version { get; set; }
        public int CustId { get; set; }
        public int? AgrStatus { get; set; }
        public string CustName { get; set; }
        public string ShortName { get; set; }
        public string ClientGroup { get; set; }
        public string ClientBrand { get; set; }
        public string StatusName { get; set; }
    }

    public class BigRightRequests
    {
        public int CustId { get; set; }
        public int Objid { get; set; }
        public string ObjName { get; set; }
        public string LicNum { get; set; }
        public DateTime? LicDate { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? DatePremiere { get; set; }
        public DateTime? LicDateEnd { get; set; }
        public string LicStatusName { get; set; }
    }

    public class BigRightRequestBidAuthors
    {
        public int LicId { get; set; }
        public int LicVersion { get; set; }
        public int? CustIdCl { get; set; }
        public int CRightId { get; set; }
        public int? PrepayType { get; set; }
        public int? WorkTypeRH { get; set; }
        public int? WorkTypeCl { get; set; }
        public decimal? PrepaySum { get; set; }
        public decimal? RoleRate { get; set; }
        public string RoleName { get; set; }
        public string AuthorName { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string CountryName { get; set; }
        public string PrepayTypeName { get; set; }
        public string WorkTypeRHName { get; set; }
        public string WorkCommentRH { get; set; }
        public string WorkTypeRHCl { get; set; }
        public string WorkCoommentCl { get; set; }
        public string CountryCode { get; set; }
        public string R030 { get; set; }
        public WorkRh WorkRh { get; set; }
    }

    public class BigRightMoneyUndescrib
    {
        public DateTime DateInvoice { get; set; }
        public int PaidId { get; set; }
        public int CustId { get; set; }
        public int MoneyType { get; set; }
        public decimal Amount { get; set; }
        public decimal DestribAmount { get; set; }
        public decimal DestribPrepay { get; set; }
        public decimal? UndescribAmount { get; set; }
        public string NumberInvoice { get; set; }
        public string GoalInvoice { get; set; }
    }
}
