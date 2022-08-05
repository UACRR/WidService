using System;
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
            SetupDefaultSettings();
            Culture = new CultureInfo("uk-UA");
        }

        private void SetupDefaultSettings()
        {
            DateTimePickerElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;
            DateTimePickerElement.Calendar.TodayButton.Text = "Сьогодні";
            DateTimePickerElement.Calendar.ClearButton.Visibility = ElementVisibility.Hidden;
            DateTimePickerElement.Calendar.ClearButton.ShowBorder = false;
            DateTimePickerElement.Calendar.ShowFooter = true;

            DateTimePickerElement.Calendar.MaximumSize = new Size(220, 180);
            DateTimePickerElement.Calendar.MinimumSize = new Size(220, 180);
            DateTimePickerElement.CalendarSize = new Size(220, 180);

            DateTimePickerElement.Calendar.CalendarElement.CalendarStatusElement.LabelFormat = "dd.MM.yyyy";
            DateTimePickerElement.Calendar.CalendarElement.CalendarStatusElement.LabelElement.Visibility = ElementVisibility.Hidden;

            DateTimePickerElement.Calendar.TodayButton.PositionOffset = new SizeF(-64, 0);

            DateTimePickerElement.Calendar.TodayButton.Click += TodayButton_Click;

            DateTimePickerElement.TextBoxElement.MaskType = MaskType.FreeFormDateTime;

            var calendarBehavior = DateTimePickerElement.GetCurrentBehavior() as RadDateTimePickerCalendar;
            if (calendarBehavior?.PopupControl != null)
                calendarBehavior.PopupControl.Opening += PopupControl_Opening;
        }

        private void PopupControl_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Value == NullDate)
                DateTimePickerElement.Calendar.FocusedDate = DateTime.Now;
        }

        /// <summary>
        /// Обробка натискання кнопки "Сьогодні"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TodayButton_Click(object sender, EventArgs e)
        {
            if (((RadDateTimePickerDropDown)((RadElement)sender).ElementTree.Control.Parent).OwnerControl is RadDateTimePicker dtPicker)
                dtPicker.Value = DateTime.Now;
        }

        private bool _borderVisible = true;
        public bool BorderVisible
        {
            get => _borderVisible;
            set
            {
                _borderVisible = value;
                var borderPrimitive = DateTimePickerElement.FindDescendant<BorderPrimitive>();
                var arrowButton = DateTimePickerElement.FindDescendant<RadDateTimePickerArrowButtonElement>();

                if (!value)
                {
                    // display only bottom border
                    arrowButton.Visibility = ElementVisibility.Collapsed;
                    borderPrimitive.BoxStyle = BorderBoxStyle.FourBorders;
                    borderPrimitive.LeftColor = BackColor;
                    borderPrimitive.RightColor = BackColor;
                    borderPrimitive.TopColor = BackColor;
                }
                else
                {
                    borderPrimitive.BoxStyle = BorderBoxStyle.SingleBorder;
                    borderPrimitive.LeftColor = SystemColors.ControlDark;
                    borderPrimitive.RightColor = SystemColors.ControlDark;
                    borderPrimitive.TopColor = SystemColors.ControlDark;
                }
            }
        }

        public new bool ReadOnly
        {
            get => base.ReadOnly;
            set
            {
                var arrowButton = DateTimePickerElement.FindDescendant<RadDateTimePickerArrowButtonElement>();
                arrowButton.Enabled = !value;
                base.ReadOnly = value;
            }
        }
    }
}
