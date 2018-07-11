using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Interfaces
{
    public class ConsumerMainView
    {
        public int custId { get; set; }
        public string innokpo { get; set; }
        public string name { get; set; }
        public int countAgree { get; set; }
        public decimal undistribamount { get; set; }
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
        public string INNOKPO { get; set; }
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
        public int countLic1Active { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int countLic1NoActive { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int countLic1ToProlong { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int countLic2Active { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int countLic2NoActive { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int countLic3Active { get; set; }
        /// <summary>
        /// Кількість
        /// </summary>
        public int countLic3NoActive { get; set; }
        /// <summary>
        /// Сума
        /// </summary>
        public decimal undistribAmount { get; set; }
        /// <summary>
        /// Сума
        /// </summary>
        public decimal borg { get; set; }
        /// <summary>
        /// Сума
        /// </summary>
        public decimal unattachAmount { get; set; }
        /// <summary>
        /// Ід Партнера
        /// </summary>
        public int clcustId { get; set; }
        /// <summary>
        /// Назва Партнера
        /// </summary>
        public string partnerName { get; set; }

    }

    public interface IConsumerService : IModel
    {
        IList<ConsumerMainView> getMainView();
        IList<AutoCompleteData> getAutoCompleteList(string filter);
    }
}
