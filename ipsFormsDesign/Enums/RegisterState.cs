namespace ipsFormsDesign.Enums
{
    public enum RegisterState : int
    {
        /// <summary>
        /// Новий
        /// </summary>
        newItem = 0,

        /// <summary>
        /// На погоджені
        /// </summary>
        OnAccept = 1,

        /// <summary>
        /// Погоджений
        /// </summary>
        Accepted = 2,

        /// <summary>
        /// До розподілу
        /// </summary>
        OnRate = 3,

        /// <summary>
        /// Виконано
        /// </summary>
        Worked = 4,

        /// <summary>
        /// Відхилено
        /// </summary>
        Rejected = 5
    }
}