using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    class IpsDropDownList : RadDropDownList
    {
        public override string ThemeClassName
        {
            get
            {
                return typeof(RadDropDownList).FullName;
            }
        }

        public override bool ReadOnly
        {
            get { return base.ReadOnly; }
            set
            {
                base.ReadOnly = value;

                SetupAppearance();
            }
        }

        protected void SetupAppearance()
        {
            var borderPrimitive = DropDownListElement.FindDescendant<BorderPrimitive>();

            if (ReadOnly)
            {
                DropDownListElement.ArrowButton.Visibility = ElementVisibility.Collapsed;

                // display only bottom border
                borderPrimitive.BoxStyle = BorderBoxStyle.FourBorders;
                borderPrimitive.LeftColor = BackColor;
                borderPrimitive.RightColor = BackColor;
                borderPrimitive.TopColor = BackColor;
            }
            else
            {
                DropDownListElement.ArrowButton.Visibility = ElementVisibility.Visible;

                borderPrimitive.BoxStyle = BorderBoxStyle.SingleBorder;
                borderPrimitive.LeftColor = SystemColors.ControlDark;
                borderPrimitive.RightColor = SystemColors.ControlDark;
                borderPrimitive.TopColor = SystemColors.ControlDark;
            }
        }
    }
}
