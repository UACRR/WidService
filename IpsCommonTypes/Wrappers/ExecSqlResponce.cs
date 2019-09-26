using IpsCommonTypes.Enums;

namespace IpsCommonTypes.Wrappers
{
    /// <summary>
    /// Обгортка для результату обробки SQL процедур/функцій
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ExecSqlResponce<T> where T: class
    {
        /// <summary>
        /// Код результату обробки
        /// </summary>
        public ExecSqlResponceStatus StatusCode { get; set; }

        /// <summary>
        /// Повідомлення після обробки процедури або функції
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Дані, що повертає функція/процедура
        /// </summary>
        public T Data { get; set; }
    }

    /// <summary>
    /// Обгортка для результату обробки SQL процедур/функцій
    /// </summary>
    public class ExecSqlResponce
    {
        /// <summary>
        /// Код результату обробки
        /// </summary>
        public ExecSqlResponceStatus StatusCode { get; set; }

        /// <summary>
        /// Повідомлення після обробки процедури або функції
        /// </summary>
        public string Message { get; set; }
    }
}
