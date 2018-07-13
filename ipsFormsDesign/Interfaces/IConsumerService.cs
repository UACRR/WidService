using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DateTimeTime AgrDateTime { get; set; }
        /// <summary>
        /// Дата початку дії
        /// </summary>
        public DateTimeTime DateTimeBegin { get; set; }
        /// <summary>
        /// Кінцева дата дії
        /// </summary>
        public DateTimeTime DateTimeEnd { get; set; }
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
        public DateTimeTime DateTimePayLast { get; set; }
        /// <summary>
        /// Ід Партнера
        /// </summary>
        public int ClcustId { get; set; }
        /// <summary>
        /// Назва Партнера
        /// </summary>
        public string PartnerName { get; set; }

    }

    public interface IConsumerService : IModel
    {
        IList<ConsumerMainView> GetMainView();
        IList<AutoCompleteData> GetAutoCompleteList(string filter);
    }

    public class VBRLicense
    {
        public DateTime agrDateTime { get; set; }
        public DateTime DateTimeBegin { get; set; }
        public DateTime DateTimeEnd { get; set; }
        public DateTime licDateTime { get; set; }
        public DateTime licDateTimeBegin { get; set; }
        public DateTime licDateTimeEnd { get; set; }
        public DateTime DateTimePremiere { get; set; }
        public int licType { get; set; }
        public int custId { get; set; }
        public int agrId { get; set; }
        public int agrStatus { get; set; }
        public int licId { get; set; }
        public int licVersion { get; set; }
        public int licStatus { get; set; }
        public int objid { get; set; }
        public int objStatus { get; set; }
        public int genreType { get; set; }
        public int performNumb { get; set; }
        public decimal borg { get; set; }
        public decimal prepayPaush { get; set; }
        public decimal prepayAvans { get; set; }
        public decimal prepayRest { get; set; }
        public decimal ticketPriceNC { get; set; }
        public decimal ticketPriceUSD { get; set; }
        public bool isTour { get; set; }
        public decimal genreRate72 { get; set; }
        public decimal rate { get; set; }
        public decimal fillingRate { get; set; }
        public string licTypeName { get; set; }
        public string name { get; set; }
        public string agrNumber { get; set; }
        public string agrStatusName { get; set; }
        public string licNum { get; set; }
        public string licStatusName { get; set; }
        public string objName { get; set; }
        public string genreName { get; set; }
        public string whereTour { get; set; }
        public string toProlong { get; set; }
        public string comment { get; set; }
        public string r030 { get; set; }
    }
}
