using System.Collections.Generic;

namespace IpsCommonTypes.Wrappers
{
    /// <summary>
    /// Обгортка для списку елементів по фільтру
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ItemListResponse<T> where T : class
    {
        /// <summary>
        /// Список елементів по фільтру
        /// </summary>
        public List<T> List { get; set; }

        /// <summary>
        /// Загальна кількість елементів без фільтра
        /// </summary>
        public int TotalItems { get; set; }
    }
}