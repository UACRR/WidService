namespace ipsFormsDesign.Dictionary
{
    /// <summary>
    /// Тип діалогу 
    /// </summary>
    public enum DialogGoal
    {
        /// <summary>
        /// Створення нового договору
        /// </summary>
        forNew,
        /// <summary>
        /// Редагування не підтвердженого договору
        /// </summary>
        forEdit,
        /// <summary>
        /// Пролонгація договору
        /// </summary>
        forProlongation,
        /// <summary>
        /// Внесення змін до договору
        /// </summary>
        forChange,
        /// <summary>
        /// Пролонгація існуючого договору
        /// </summary>
        forExistProlongation,
        /// <summary>
        /// Внесення змін до існуючої версії договору
        /// </summary>
        forExistChange

    } //Exist

    /// <summary>
    /// Типи прав
    /// </summary>
    public enum TypeRights
    {
        /// <summary>
        /// Великі права
        /// </summary>
        BigRights,
        /// <summary>
        /// Малі права
        /// </summary>
        SmallRights,
        /// <summary>
        /// FOR DEVELOPERS
        /// </summary>
        All
    }
}
