using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common.Editors
{
    public class IpsDateTimePicker : RadDateTimePicker
    {
        public override string ThemeClassName => typeof(RadDateTimePicker).FullName;

        public IpsDateTimePicker()
        {
            SetupDefaultAppearance();

            Culture = new CultureInfo("uk-UA");

            DateTimePickerElement.TextBoxElement.MaskType = MaskType.FreeFormDateTime;

            var calendarBehavior = DateTimePickerElement.GetCurrentBehavior() as RadDateTimePickerCalendar;
            calendarBehavior.PopupControl.Opening += PopupControl_Opening;
        }

        private void SetupDefaultAppearance()
        {
            DateTimePickerElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;
            DateTimePickerElement.Calendar.ShowFooter = true;
            DateTimePickerElement.Calendar.CalendarElement.CalendarStatusElement.LabelFormat = "dd.MM.yyyy";
            DateTimePickerElement.Calendar.ClearButton.Visibility = ElementVisibility.Collapsed;
            DateTimePickerElement.Calendar.TodayButton.Text = "Сьогодні";

            DateTimePickerElement.Calendar.MaximumSize = new Size(220, 180);
            DateTimePickerElement.Calendar.MinimumSize = new Size(220, 180);
            DateTimePickerElement.CalendarSize = new Size(220, 180);
            DateTimePickerElement.MaxDate = new DateTime(3000, 1, 1);
        }

        protected void SetupReadOnlyAppearance()
        {
            var borderPrimitive = DateTimePickerElement.FindDescendant<BorderPrimitive>();
            var arrowButton = DateTimePickerElement.FindDescendant<RadDateTimePickerArrowButtonElement>();

            if (ReadOnly)
            {
                arrowButton.Visibility = ElementVisibility.Collapsed;

                // display only bottom border
                borderPrimitive.BoxStyle = BorderBoxStyle.FourBorders;
                borderPrimitive.LeftColor = BackColor;
                borderPrimitive.RightColor = BackColor;
                borderPrimitive.TopColor = BackColor;
            }
            else
            {
                arrowButton.Visibility = ElementVisibility.Visible;

                borderPrimitive.BoxStyle = BorderBoxStyle.SingleBorder;
                borderPrimitive.LeftColor = SystemColors.ControlDark;
                borderPrimitive.RightColor = SystemColors.ControlDark;
                borderPrimitive.TopColor = SystemColors.ControlDark;
            }
        }

        private void PopupControl_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Value == NullDate)
                DateTimePickerElement.Calendar.FocusedDate = DateTime.Now;
        }

        public virtual void SetReadOnly(bool readOnly)
        {
            ReadOnly = readOnly;

            SetupReadOnlyAppearance();
        }
    }
}
