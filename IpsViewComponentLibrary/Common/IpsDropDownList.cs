using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Common
{
    class IpsDropDownList : RadDropDownList
    {
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
            DropDownListElement.ArrowButton.Visibility = ElementVisibility.Collapsed;
        }
    }
}
