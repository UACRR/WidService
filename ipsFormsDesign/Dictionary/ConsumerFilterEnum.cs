using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    /// <summary>
    /// Тип фільтру для Споживачів
    /// </summary>
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
        ForDistribution = 5,
        /// <summary>
        /// Активні
        /// </summary>
        Active,
        /// <summary>
        /// Не активні
        /// </summary>
        NotActive,
        /// <summary>
        /// Заборгованість
        /// </summary>
        Debt,
        /// <summary>
        /// В роботі(прийом звітів)
        /// </summary>
        InWork

    }

    /// <summary>
    /// Тип діалогу 
    /// </summary>
    public enum DialogGoal
    {
        /// <summary>
        /// Створення нового контракту
        /// </summary>
        forNew,
        /// <summary>
        /// Редагування поточного договору
        /// </summary>
        forEdit,
        /// <summary>
        /// Створення або редагування доп угоди на пролонгацію 
        /// </summary>
        forProlongation
    }

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

    /// <summary>
    /// Тип особи користувача
    /// </summary>
    public enum PersonType
    {
        /// <summary>
        /// Фізична особа
        /// </summary>
        PhysicalPerson,
        /// <summary>
        /// Юридична особа
        /// </summary>
        JuridicalPerson
    }
}
