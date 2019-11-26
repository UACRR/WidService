using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IPSComponentLibrary.Extensions
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Незмінний розмір, кнопка "Сьогодні" посередині, навігація по місяцях/роках зумом
        /// </summary>
        /// <param name="dtPicker"></param>
        public static void SetUserCalendarSettingsm(this RadDateTimePicker dtPicker)
        {
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

            dtPicker.DateTimePickerElement.Calendar.TodayButton.Click += (sender, e) => dtPicker.Value = DateTime.Now;
        }
    }
}
