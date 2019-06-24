namespace IpsCommonTypes.Enums
{
    /// <summary>
    /// Фільтр для списку користувачів великих прав
    /// </summary>
    public enum ConsumersBigRightFilter : int
    {
        /// <summary>
        /// Не визначено
        /// </summary>
        None = 0,

        /// <summary>
        /// Діючі
        /// </summary>
        Working = 1,

        /// <summary>
        /// Для акцепту
        /// </summary>
        NotAccepted = 2,

        /// <summary>
        /// Не активні
        /// </summary>
        NotActive = 3,

        /// <summary>
        /// Для пролонгації
        /// </summary>
        ForProlongation = 4,

        /// <summary>
        /// Для розподілу
        /// </summary>
        ForDistribution = 5,

        /// <summary>
        /// Заборгованість
        /// </summary>
        Debt = 6,

        /// <summary>
        /// В роботі(прийом звітів)
        /// </summary>
        UnattachData = 7,

        /// <summary>
        /// Закриті
        /// </summary>
        Closed = 8,

        /// <summary>
        /// Не підтверджені
        /// </summary>
        NotConfirmed = 9,

        /// <summary>
        /// Всі
        /// </summary>
        All
    }
}