using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common.Editors
{
    class IpsDateTimePicker : RadDateTimePicker
    {
        public override string ThemeClassName
        {
            get
            {
                return typeof(RadDateTimePicker).FullName;
            }
        }

        public IpsDateTimePicker()
        {
            SetupDefaultAppearance();

            Culture = new CultureInfo("uk-UA");

            DateTimePickerElement.TextBoxElement.MaskType = MaskType.FreeFormDateTime;
        }

        private void SetupDefaultAppearance()
        {
            DateTimePickerElement.Calendar.HeaderNavigationMode = HeaderNavigationMode.Zoom;
            DateTimePickerElement.Calendar.ShowFooter = true;
            DateTimePickerElement.Calendar.CalendarElement.CalendarStatusElement.LabelFormat = "dd.MM.yyyy";
            DateTimePickerElement.Calendar.ClearButton.Visibility = ElementVisibility.Collapsed;
            DateTimePickerElement.Calendar.TodayButton.Text = "Сьогодні";
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

        public virtual void SetReadOnly(bool readOnly)
        {
            ReadOnly = readOnly;

            SetupReadOnlyAppearance();
        }
    }
}
