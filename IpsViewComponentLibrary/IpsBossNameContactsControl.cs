using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsBossNameContactsControl : UserControl
    {
        public IpsBossNameContactsControl()
        {
            InitializeComponent();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return employeeBindingSource.DataSource; }
            set
            {
                if (employeeBindingSource.DataSource != value)
                    employeeBindingSource.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return employeeBindingSource.DataMember; }
            set { employeeBindingSource.DataMember = value; }
        }

        #region Edit controls

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtEmail
        {
            get
            {
                return txtEmail;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtFirstName
        {
            get
            {
                return txtFirstName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtLastName
        {
            get
            {
                return txtLastName;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtPhone
        {
            get
            {
                return txtPhone;
            }
            set => txtPhone = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtSurName
        {
            get
            {
                return txtSurName;
            }
        }

        #endregion

        private bool IsValidMail(string email)
        {
            
            try
            {
                var mail = new MailAddress(email);
                
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool Validator()
        {
            bool isValid = true;

            if (txtEmail.Text != string.Empty)
            if (!IsValidMail(txtEmail.Text))
            {
                isValid = false;
                radLabel3.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                radLabel3.ForeColor = Color.Black;

            //if (rtxtBoxAuthorPaymentPercent.Text == string.Empty)
            //{
            //    isValid = false;
            //    radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            //}
            //else
            //    radLabel1.ForeColor = Color.Black;

            return isValid;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && !(ch>=64 && ch <= 90) && !(ch >= 97 && ch <= 122) && ch != 45 && ch != 46 && ch != 95)
            {
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 43)
            {
                e.Handled = true;
            }
        }
    }
}
