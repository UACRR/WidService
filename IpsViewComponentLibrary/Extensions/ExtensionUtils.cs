using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using ConsumerSmallRightView = ipsFormsDesign.ViewModels.Consumer.ConsumerSmallRightView;

namespace IpsViewComponentLibrary.Extensions
{
    public delegate bool LicenseStatusChangeEventHandler(LicenseAgreement agr, int version, int status, bool changeVersion);
    public delegate bool ChangeLicenseTypeEventHandler(LicenseAgreement agreement, LicType licType);
    public delegate bool SaveRegisterRatedListEventHandler(RegisterRatedList list);
    public delegate Customer GetRegisterRatedList(int custId);
    public delegate List<RegisterItem> GetRegisterItemsEventHandler(int regId);
    public delegate List<Customer> GetPartnerList();

    public delegate bool SetPartnerEventHandler(int clientId, int partnerId);
    public delegate bool ChangePartnerEventHandler(int clientId, int partnerId, int oldPartnerId);

    public delegate void LoadCustomerCabinetBREventHandler(ConsumerBigRightView item);
    public delegate void LoadCustomerCabinetSREventHandler(ConsumerSmallRightView item);
    public delegate void UpdateCustomerDataEventHandler(int id);

    public delegate List<CustCmRight> GetCommunityRightList(int custId);

    public delegate void EmptyEventHandler();

    public delegate bool ActionWithTwoId(int custId, int id);
    public delegate bool ActionByIdDelegate(int id);
    public delegate bool SaveCustomerEventHandler(Customer customer);
    public delegate bool SaveObjectByIdEventHandler<T>(int id, T saveObj);
    public delegate Customer GetCustomerEventHandler();
    public delegate Customer GetCustomerByIdEventHandler(int custId);
    public delegate List<T> ReturnViewEventHandler<T>(int custId);

    public delegate T ReturnObjectEventHandler<out T>(int custId);

    public delegate bool AgreementStatusChangeEventHandler(int partnerId, CPartnerObjectStatus status);
    public delegate List<PaidPeriod> SaveAndReturnNewPeriodListEventHandler(int custId, List<PaidPeriod> periods);

    public static class ExtensionUtils
    {

        /// <summary>
        /// Незмінний розмір, кнопка "Сьогодні" посередині, навігація по місяцях/роках зумом
        /// </summary>
        /// <param name="dtPicker"></param>
        public static void SetUserCalendarSettings(this RadDateTimePicker dtPicker)
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

        // обробка події кліку кнопки кастомного календара
        private static void TodayButton_Click(object sender, EventArgs e)
        {
            // var container = (sender as RadControl).GetContainerControl();
            if (((RadDateTimePickerDropDown)((RadElement)sender).ElementTree.Control.Parent).OwnerControl is RadDateTimePicker dtPicker)
                dtPicker.Value = DateTime.Now;
        }

        /// <summary>
        /// Зробити колір тексту лейбла червоним
        /// </summary>
        /// <param name="label"></param>
        public static void SetWarningLabelColor(this RadLabel label)
        {
            label.ForeColor = Color.FromArgb(180, 255, 0, 2);
        }

        /// <summary>
        /// Зробити стандартний колір тексту лейбла
        /// </summary>
        /// <param name="label"></param>
        public static void SetDefaultLabelColor(this RadLabel label)
        {
            label.ForeColor = Control.DefaultForeColor;
        }

        /// <summary>
        /// Перевірка натиснутої кнопки. Допускаються: цифри, коми, видалення
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBoxPercentRate_KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Перевірка натиснутої кнопки. Допускаються: цифри, видалення
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TextBoxNumeric_KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        public static List<T> ToListOfType<T>(this IList<object> listObjects) where T : class 
        {
            var itemsList = new List<T>();
            foreach (var temp in listObjects)
                itemsList.Add(temp as T);
            return itemsList;
        }

        /// <summary>
        /// Метод ігнорування дублікатів в списку
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource item in source)
                if (seenKeys.Add(keySelector(item)))
                    yield return item;
        }

        /// <summary>
        /// Отримати дату кінця року
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndYearDate(this DateTime? dateTime)
        {
            if (dateTime != null)
                return (DateTime)dateTime;

            return new DateTime(DateTime.Today.Year, 12, 31);
        }

        //для колапс панелі
        public static void NavigationButtonPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RadButtonElement btn = sender as RadButtonElement;
            if (e.PropertyName == "Visibility" && btn?.Class == "PrevDownSplitterThumb")
            {
                if (btn.Visibility == ElementVisibility.Collapsed)
                {
                    btn.Visibility = ElementVisibility.Visible;
                    btn.AngleTransform = 0f;
                }
            }
            if (e.PropertyName == "Visibility" && btn?.Visibility == ElementVisibility.Visible && btn.Class == "NextUpSplitterThumb")
            {
                btn.Visibility = ElementVisibility.Collapsed;
            }
        }
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
    /// Тип вкладки кабінету великих прав
    /// </summary>
    public enum CabinetTabType
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Анкета
        /// </summary>
        Anketa,
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
        RegisterRatedList,
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
        PaysInfo,
        /// <summary>
        /// Аванси
        /// </summary>
        Prepays,
        /// <summary>
        /// Контакти
        /// </summary>
        Contacts,
        /// <summary>
        /// Всі вкладки
        /// </summary>
        All
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

    /// <summary>
    /// Тип ініціалізованої форми
    /// </summary>
    public enum FLoadType
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Створення нового об'єкту
        /// </summary>
        Create,
        /// <summary>
        /// Перегляд існуючого об'єкту
        /// </summary>
        View,
        /// <summary>
        /// Редагування існуючого об'єкту
        /// </summary>
        Edit,
    }
}
