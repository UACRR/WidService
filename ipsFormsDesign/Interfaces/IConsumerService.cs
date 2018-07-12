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
        public DateTime AgrDate { get; set; }
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
}
