using System;
using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.ViewModels.Consumer;

namespace ipsFormsDesign.Interfaces
{
    /// <summary>
    /// Дані для GridView Для великих прав
    /// </summary>
    public class ConsumerBigRightView
    {
        /// <summary>
        /// ID клієнта
        /// </summary>
        public int CustId { get; set; }

        /// <summary>
        ///  Назва клієнта
        /// </summary>
        public string Name { get; set; }

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
        /// Місто
        /// </summary>        
        public string JaCity { get; set; }

        /// <summary>
        /// Тип Ген. угоди
        /// </summary>
        public int AgrType { get; set; }
        /// <summary>
        /// Назва Типу
        /// </summary>
        public string AgrTypeName { get; set; }

        /// <summary>
        /// Код країни Споживача 
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Дата останього платежу
        /// </summary>
        public DateTime? DatePayLast { get; set; }

        /// <summary>
        /// Ід Партнера
        /// </summary>
        public int? ClcustId { get; set; }

        /// <summary>
        /// Назва Партнера
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Адреса
        /// </summary>
        public string JaAddress { get; set; }

        ///// <summary>
        ///// Сума
        ///// </summary>
        //public decimal? UndistribAmount { get; set; }
        ///// <summary>
        ///// Сума
        ///// </summary>
        //public decimal? Borg { get; set; }
        ///// <summary>
        ///// Сума
        ///// </summary>
        //public decimal? UnattachAmount { get; set; }
        ///// <summary>
        ///// Сума
        ///// </summary>
        //public decimal? PrePayRest { get; set; }

        public float? UndistribAmount { get; set; }
        public float? Borg { get; set; }
        public float? UnattachAmount { get; set; }
        public float? PrePayRest { get; set; }

        private int? _agrStatus;
        /// <summary>
        ///  Статус Ген. Угоди
        /// </summary>
        public int? AgrStatus
        {
            get => _agrStatus;
            set
            {
                _agrStatus = value;
                if (value.HasValue)
                {
                    StatusName = IpsGlobal.AnketaDictionaties.agreementStatus.First(rec => rec.CodeI == value.Value).Name;
                }
            }
        }

        /// <summary>
        /// Назва статусу 
        /// </summary>
        public string StatusName { get; set; }

        private int? _addStatus;
        /// <summary>
        /// Статус Доп угоди
        /// </summary>
        public int? AddStatus
        {
            get => _addStatus;
            set
            {
                _addStatus = value;
                if (value.HasValue)
                {
                    AddStatusName = IpsGlobal.AnketaDictionaties.agreementStatus.First(rec => rec.CodeI == value.Value).Name;
                }
            }
        }

        /// <summary>
        /// Назва Статус 
        /// </summary>
        public string AddStatusName { get; set; }


        public int CountLic1Active { get; set; }
        public int CountLic1NoActive { get; set; }
        public int CountLic1ToProlong { get; set; }
        public int CountLic2Active { get; set; }
        public int CountLic2NoActive { get; set; }
        public int CountLic3Active { get; set; }
        public int CountLic3NoActive { get; set; }

    }

    public interface IConsumerService : IModel
    {
        IList<ConsumerSmallRightView> GetMainView();
        IList<AutoCompleteData> GetAutoCompleteList(string filter);
    }

    /// <summary>
    /// Дані ліцензійних договорів
    /// </summary>
    public class LicenseAgreementBigRightView
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
    public class GeneralAgreementBigRightView
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
        public int? LicId { get; set; }
    }

    /// <summary>
    /// Дані заявок/довідок
    /// </summary>
    public class RequestsOrReferenceBigRightView
    {
        public DateTime? LicDate { get; set; }
        public DateTime? LicDateBegin { get; set; }
        public DateTime? LicDateEnd { get; set; }
        public DateTime? DatePremiere { get; set; }
        public int? LicType { get; set; }
        public int? CustId { get; set; }
        public int AgrId { get; set; }
        public int LicId { get; set; }
        public int LicVersion { get; set; }
        public int? LicStatus { get; set; }
        public int? Objid { get; set; }
        public int? ObjStatus { get; set; }
        public int? GenreType { get; set; }
        public int? PerformNumb { get; set; }
        public decimal? TicketPriceNC { get; set; }
        public decimal? TicketPriceUSD { get; set; }
        public bool? IsTour { get; set; }
        public decimal? GenreRate72 { get; set; }
        public decimal? Rate { get; set; }
        public decimal? FillingRate { get; set; }
        public string LicTypeName { get; set; }
        public string Name { get; set; }
        public string LicNum { get; set; }
        public string LicStatusName { get; set; }
        public string ObjName { get; set; }
        public string GenreName { get; set; }
        public string WhereTour { get; set; }
        public string Comment { get; set; }
    }

    /// <summary>
    /// Автори для ліцензій, довідок, заявок великих прав
    /// </summary>
    public class AuthorsForLicenseBigRightView
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

    /// <summary>
    /// Незакріплені кошти користувачів великих/малих прав
    /// </summary>
    public class UnattachedMoneyView
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

    public class BigRightSpectacleView
    {
        public int? CustId { get; set; }
        public int LicId { get; set; }
        public int ObjId { get; set; }
        public int? ActCode { get; set; }
        public decimal? Rate { get; set; }
        public decimal? RateMusic { get; set; }
        public string Name { get; set; }
        public int LicType { get; set; }
    }

    public class RatedListBigRightView
    {
        public DateTime? CreateDate { get; set; }
        public int? CustId { get; set; }
        public int? PeriodId { get; set; }
        public int? Status { get; set; }
        public int RmId { get; set; }
        public decimal? FullAmount { get; set; }
        public decimal? RAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public decimal Distribamount { get; set; }
        public decimal? Borg { get; set; }
        public decimal? PrepaySum { get; set; }
        public string PeriodName { get; set; }
        public string StatusName { get; set; }
    }

    /// <summary>
    /// Р/Л вистави
    /// </summary>
    public class RatedListSpectacleBigRightView
    {
        public int RmId { get; set; }
        public int RegId { get; set; }
        public int? ObjId { get; set; }
        public int? ActCode { get; set; }
        public int? CountUse { get; set; }
        public int CustId { get; set; }
        public decimal? RegAmount { get; set; }
        public decimal? AuthAmount { get; set; }
        public decimal PrepaySumAuthor { get; set; }
        public decimal? AvanseRest { get; set; }
        public decimal AvanseUsed { get; set; }
        public decimal? AuthRate { get; set; }
        public decimal? RoleRate { get; set; }
        public decimal? AmountDistributed { get; set; }
        public string ItemName { get; set; }
        public string RoleName { get; set; }
        public string NameRh { get; set; }
        public decimal? MusicRate { get; set; }
        public decimal? MusicAmount { get; set; }
    }

    /// <summary>
    /// Р/Л музичне оформлення
    /// </summary>
    public class RatedListMusicDesignBigRightView
    {
        public TimeSpan? Duration { get; set; }
        public int RmId { get; set; }
        public int RegId { get; set; }
        public int? ObjId { get; set; }
        public string ObjName { get; set; }
        public string NameMusician { get; set; }
        public string NameSinger { get; set; }
    }

    public class PartnerView
    {
        public int? CustId { get; set; }
        public DateTime? AgrDate { get; set; }
        public int AgrId { get; set; }
        public int? AgrStatus { get; set; }
        public int? ClnCount { get; set; }
        public string AgrCount { get; set; }
        public string Innokpo { get; set; }
        public string Name { get; set; }
        public string AgrNumber { get; set; }
        public string JaCity { get; set; }
        public string StatusName { get; set; }
        public string IsMy { get; set; }
    }

    /// <summary>
    /// Список клієнтів представника
    /// </summary>
    public class PartnerClientListView
    {
        public int CustId { get; set; }
        public int ClCustId { get; set; }
        public int? CustType { get; set; }
        public string CustTypeName { get; set; }
        public string AgrCount { get; set; }
        public decimal SumBorg { get; set; }
        public string Innokpo { get; set; }
        public string ClientName { get; set; }
    }

    /// <summary>
    /// Список вільних клієнтів
    /// </summary>
    public class PartnerAllFreeClientsView
    {
        public int ClCustId { get; set; }
        public int? AgrCount { get; set; }
        public string Innokpo { get; set; }
        public string ClientName { get; set; }
        public string Jacity { get; set; }    
        public int? JaRegion { get; set; }
        public string RegionName { get; set; }
    }

    /// <summary>
    /// Список існуючих спільнот
    /// </summary>
    public class CommunityListView
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public DateTime? RegistrDate { get; set; }
        public int? CountAuthors { get; set; }
        public int IsMy { get; set; }
    }

    public class CommunityAuthorsView
    {
        public DateTime RegistrDate { get; set; }
        public int CustId { get; set; }
        public int? CmCustId { get; set; }
        public int CustStatus { get; set; }
        public int? AgrStatus { get; set; }
        public int CntObj { get; set; }
        public decimal YearProfit { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public string Community_name { get; set; }
        public string Country { get; set; }
    }

}
