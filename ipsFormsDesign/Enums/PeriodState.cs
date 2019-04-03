namespace ipsFormsDesign.Enums
{
    /// <summary>
    /// Стан періоду
    /// </summary>
    public enum PeriodState : int
    {
        /// <summary>
        /// Прийом звітів
        /// </summary>
        getReport = 1,
        /// <summary>
        /// Прийом коштів
        /// </summary>
        getPay = 2,
        /// <summary>
        /// Борг
        /// </summary>
        Debt = 3,
        /// <summary>
        /// Судова робота
        /// </summary>
        Court = 4,
        /// <summary>
        /// Кошти отримані
        /// </summary>
        Paid = 6,
        /// <summary>
        /// Закритий
        /// </summary>
        Close = 7
    }
}