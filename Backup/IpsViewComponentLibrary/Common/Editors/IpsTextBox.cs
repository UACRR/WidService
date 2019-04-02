using System;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common.Editors
{
    class IpsTextBox : RadTextBox
    {
        public override string ThemeClassName
        {
            get
            {
                return typeof(RadTextBox).FullName;
            }
        }

        protected void SetupAppearance()
        {
            var borderPrimitive = TextBoxElement.FindDescendant<BorderPrimitive>();

            if (ReadOnly)
            {
                // display only bottom border
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

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            SetupAppearance();

            base.OnReadOnlyChanged(e);
        }
    }
}
