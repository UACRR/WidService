using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public delegate bool LisenseStatusChangeEventHandler(LicenseAgreement agr, int version, int status);

    public static class ExtensionUtils
    {
        /// <summary>
        /// Незмінний розмір, кнопка "Сьогодні" посередині, навігація по місяцях/роках зумом
        /// </summary>
        /// <param name="dtPicker"></param>
        public static void SetUserCalendarSettingsm(this RadDateTimePicker dtPicker)
        {
            //_dtPicker = dtPicker;
            //if(dtPicker == null) return;
            dtPicker.DateTimePickerElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;
            //dtTetsDate.DateTimePickerElement.Calendar.TodayButton.ShowBorder = true;
            dtPicker.DateTimePickerElement.Calendar.TodayButton.Text = "Сьогодні";
            dtPicker.DateTimePickerElement.Calendar.ClearButton.Visibility = ElementVisibility.Hidden;
            dtPicker.DateTimePickerElement.Calendar.ClearButton.ShowBorder = false;
            dtPicker.DateTimePickerElement.Calendar.ShowFooter = true;

            dtPicker.DateTimePickerElement.Calendar.MaximumSize = new Size(220, 180);
            dtPicker.DateTimePickerElement.Calendar.MinimumSize = new Size(220, 180);
            dtPicker.DateTimePickerElement.CalendarSize = new Size(220, 180);

            dtPicker.DateTimePickerElement.Calendar.CalendarElement.CalendarStatusElement.LabelFormat = "dd/MM/yyyy";
            dtPicker.DateTimePickerElement.Calendar.CalendarElement.CalendarStatusElement.LabelElement.Visibility = ElementVisibility.Hidden;

            dtPicker.DateTimePickerElement.Calendar.TodayButton.PositionOffset = new SizeF(-64, 0);

            dtPicker.DateTimePickerElement.Calendar.TodayButton.Click += TodayButton_Click;
        }

        private static void TodayButton_Click(object sender, EventArgs e)
        {
            // var container = (sender as RadControl).GetContainerControl();
            var dtPicker = ((RadDateTimePickerDropDown)((RadElement)sender).ElementTree.Control.Parent).OwnerControl as RadDateTimePicker;
            if (dtPicker != null)
                dtPicker.Value = DateTime.Now;
        }
    }

    public interface IMiddleCtrlAnketaConsumer
    {
        /// <summary>
        /// Встановлення джерела даних для DataBinding
        /// </summary>
        /// <param name="cust">Дані споживача</param>
        /// <param name="dictionaties">Словники</param>
        /// <param name="anketeType">Тип анкети: редагування/створення нової</param>
        void SetDataSources(Customer cust, AnketaDictionaties dictionaties);

        /// <summary>
        /// Перевірка на правильність введених даних
        /// </summary>
        bool Validator();
    }



    #region МАЙДАНЧИКИ

    /// <summary>
    /// Тип ініціалізації форми приміщення завкладу
    /// </summary>
    public enum PremisesFormTypeInitialization
    {
        /// <summary>
        /// Редагування
        /// </summary>
        Edit,
        /// <summary>
        /// Створення нового
        /// </summary>
        CreateNew
    }

    /// <summary>
    /// Тип вимірювання майданчика
    /// </summary>
    public enum MeasurementOfPremises
    {
        /// <summary>
        /// Площа
        /// </summary>
        Area = 1,
        /// <summary>
        /// Кількість місць
        /// </summary>
        Number = 2,
        /// <summary>
        /// Інше
        /// </summary>
        Other = 3,
        Empty = 0
    }

    /// <summary>
    /// Тип закладу що редагується
    /// </summary>
    public enum TypeInstitution
    {
        /// <summary>
        /// Заклад додано, відображається на грід
        /// </summary>
        ExistingInstitution,
        /// <summary>
        /// Заклад було щойно створено
        /// </summary>
        NonExistentInstitution
    }

    /// <summary>
    /// Типи майданчиків
    /// </summary>
    public enum ExistencePlaces
    {
        /// <summary>
        /// Один майданчик
        /// </summary>
        SinglePlace,
        /// <summary>
        /// Багато майданчиків
        /// </summary>
        ManyPlaces
    }

    /// <summary>
    /// Тип форматування поточної анкети
    /// </summary>
    public enum ConsumerAnketeType
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Створення нової анкети споживача
        /// </summary>
        CreateNewAnketa,
        /// <summary>
        /// Редагування існуючої анкети споживача
        /// </summary>
        EditAnketa
    }

    /// <summary>
    /// Тип ініціалізації, для чого буде застосовуватись
    /// </summary>
    public enum ConsumerAgreementInitType
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Створення нового договору
        /// </summary>
        AddNewAgreement,
        /// <summary>
        /// Редагування існуючого договору
        /// </summary>
        EditAgreement,
        /// <summary>
        /// Пролонгація договору
        /// </summary>
        Prolongation
    }

    /// <summary>
    /// Для визначення видаляти чи додавати в мінімальну суму вартість майданчика
    /// </summary>
    public enum CalculationMinAmountType
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Видалити вартість майданчика з мінімальної суми
        /// </summary>
        DeleteCalcValue,
        /// <summary>
        /// Додати вартість майданчика в мінімальну суму
        /// </summary>
        AddCalcValue,
    }

    #endregion

    /// <summary>
    /// Тип вкладки кабінету великих прав
    /// </summary>
    public enum CabinetTabType
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Ліцензії
        /// </summary>
        Licenses,
        /// <summary>
        /// Розрахунки
        /// </summary>
        Calculations,
        /// <summary>
        /// Розрахункові листи
        /// </summary>
        Payslips,
        /// <summary>
        /// Заявки
        /// </summary>
        Requests,
        /// <summary>
        /// Довідки
        /// </summary>
        References,
        /// <summary>
        /// Генеральна угода
        /// </summary>
        GeneralAgreement,
        /// <summary>
        /// Файли
        /// </summary>
        Files,
        /// <summary>
        /// Представник
        /// </summary>
        Agent,
        /// <summary>
        /// Платежі
        /// </summary>
        Payments,
        /// <summary>
        /// Аванси
        /// </summary>
        Prepays,
        /// <summary>
        /// Контакти
        /// </summary>
        Contacts
    }

    /// <summary>
    /// Тип контролу
    /// </summary>
    public enum ControlRequestOrReferenceType
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Заявка
        /// </summary>
        Request,
        /// <summary>
        /// Довідка
        /// </summary>
        Reference
    }


}
