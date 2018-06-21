using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    public enum ConsumerFilterEnum : int
    {
        /// <summary>
        /// Не визначено
        /// </summary>
        None = 0,
        /// <summary>
        /// Всі
        /// </summary>
        All = 1,
        /// <summary>
        /// Діючі
        /// </summary>
        Working = 2,
        /// <summary>
        /// Для акцепту
        /// </summary>
        NotAccepted = 3,
        /// <summary>
        /// Для пролонгації
        /// </summary>
        ForProlongation = 4,
        /// <summary>
        /// Для розподілу
        /// </summary>
        ForDistribution = 5
    }
}
