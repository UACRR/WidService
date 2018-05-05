using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class IpsAddressControl : UserControl
    {
        /// <summary>
        /// Підключення до обїекту анкети
        /// </summary>
        /// <param name="value"></param>

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList radDropDownListCountry
        {
            get
            {
                return radDropDownList1;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList radDropDownListCity
        {
            get
            {
                return radDropDownList2;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox radTextBoxAddress
        {
            get
            {
                return radTextBox1;
            }
        }



        public IpsAddressControl()
        {
            InitializeComponent();
        }
    }
}
