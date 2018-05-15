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
        public IpsAddressControl()
        {
            InitializeComponent();
        }

        #region Edit controls

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList DdlCountry
        {
            get
            {
                return ddlCountry;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList DdlRegion
        {
            get
            {
                return ddlRegion;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtCity
        {
            get
            {
                return txtCity;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtAddress
        {
            get
            {
                return txtAddress;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtPhone
        {
            get
            {
                return txtPhone;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtFax
        {
            get
            {
                return txtFax;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtEmail
        {
            get
            {
                return txtEmail;
            }
        }

        #endregion
    }
}
