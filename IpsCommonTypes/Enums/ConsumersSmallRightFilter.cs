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
        /// Не отримані звіти
        /// </summary>
        NotReceivingRegister = 10,

        /// <summary>
        /// Не отримані кошти
        /// </summary>
        NotReceivingMoney = 11,

        /// <summary>
        /// Всі
        /// </summary>
        All
    }
}