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

    /// <summary>
    /// Типи документів Великих прав для запиту
    /// </summary>
    public enum TypeBRDocument
    {
        /// <summary>
        /// Empty
        /// </summary>
        None = 0,
        /// <summary>
        /// Генеральна угода
        /// </summary>
        GenAgreement = 2,
        /// <summary>
        /// Ліцензійна угода
        /// </summary>
        LicAgreement = 3,
        /// <summary>
        /// Заявки
        /// </summary>
        Request = 4,
        /// <summary>
        /// Довідки
        /// </summary>
        Reference = 5,
        /// <summary>
        ///  All documents
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
