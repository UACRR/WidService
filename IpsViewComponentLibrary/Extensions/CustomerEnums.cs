namespace IpsViewComponentLibrary.Extensions
{
    /// <summary>
    /// Тип користувача
    /// </summary>
    public enum CustomerType
    {
        /// <summary>
        /// Фізична особа
        /// </summary>
        PhysicalPerson = 1,
        /// <summary>
        /// Юридична особа
        /// </summary>
        JuridicalPerson = 3,
    }

    public enum BRLicenseButtonActionType
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Акцептувати
        /// </summary>
        Accept,
        /// <summary>
        /// На погодження
        /// </summary>
        Confirm
    }
}