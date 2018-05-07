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
                return ddlCountry;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList radDropDownListRegion
        {
            get
            {
                return ddlRegion;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox radTextBoxCity
        {
            get
            {
                return txtCity;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox radTextBoxAddress
        {
            get
            {
                return txtAddress;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox radTextBoxPhone
        {
            get
            {
                return txtPhone;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox radTextBoxFax
        {
            get
            {
                return txtFax;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox radTextBoxEmail
        {
            get
            {
                return txtEmail;
            }
        }

        public IpsAddressControl()
        {
            InitializeComponent();
        }
    }
}
