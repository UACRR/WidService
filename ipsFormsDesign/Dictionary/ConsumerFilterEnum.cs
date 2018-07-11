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
        /// Активні
        /// </summary>
        // Active = 2,
        /// <summary>
        /// Заборгованість
        /// </summary>
        Debt = 6,
        /// <summary>
        /// В роботі(прийом звітів)
        /// </summary>
        UnattachData = 7,
        /// <summary>
        /// Всі
        /// </summary>
        All 
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
    /// Типи документів Великих прав для запиту
    /// </summary>
    public enum TypeBRDocument
    {
        None = 0,
        // General agreement
        GenAgreement = 2,
        // License agreement
        LicAgreement = 3,
        // Request
        Request = 4,
        // Certificate
        Reference = 5,
        // All documents
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
