namespace IpsCommonTypes.Enums
{
    /// <summary>
    /// Фільтр для списку користувачів малих прав
    /// </summary>
    public enum ConsumersSmallRightFilter
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
        /// Для пролонгації
        /// </summary>
        ForProlongation = 4,

        /// <summary>
        /// Для розподілу
        /// </summary>
        ForDistribution = 5,

        /// <summary>
        /// Погоджені звіти
        /// </summary>
        RegisterStatusOk = 6,

        /// <summary>
        /// Відхилені звіти
        /// </summary>
        RegisterStatusRefuse = 7,

        /// <summary>
        /// Не підтверджений
        /// </summary>
        ForAccept = 8,

        /// <summary>
        /// Борг
        /// </summary>
        Debt = 9,

        /// <summary>
        /// Прийом звітів
        /// </summary>
        ReceivingRegister = 10,

        /// <summary>
        /// Прийом коштів
        /// </summary>
        ReceivingMoney = 11,

        /// <summary>
        /// Незакріплені
        /// </summary>
        UnattachedMoney = 12,

        /// <summary>
        /// Всі
        /// </summary>
        All
    }
}