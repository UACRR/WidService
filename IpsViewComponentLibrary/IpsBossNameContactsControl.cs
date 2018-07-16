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
        private const string phoneCode = "+380";
        public IpsBossNameContactsControl()
        {
            InitializeComponent();
            txtPhone.Text = phoneCode;
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
                if (mail.Address == email)
                {
                    bool havedot = false, havesymboladot = false;
                    byte countBdot = 0;
                    var mailHost = mail.Host;
                    foreach (var symbol in mailHost.ToCharArray())
                    {
                        countBdot++;
                        if (countBdot > 1 && symbol == 46)
                            havedot = true;
                        if (havedot && symbol != 46)
                            havesymboladot = true;
                    }

                    return havedot && havesymboladot;
                }
                return false;
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

            if(txtPhone.Text != string.Empty && txtPhone.Text.Length<13)
            {
                isValid = false;
                radLabel2.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            }
            else
                radLabel2.ForeColor = Color.Black;

            return isValid;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (txtEmail.Text.Length == 0 && ch == 46)
                e.Handled = true;

            if (txtEmail.Text.Length > 0)
            {
                var symbols = txtEmail.Text.ToCharArray();
                if (symbols.Last() == 46 && e.KeyChar == 46)
                    e.Handled = true;
            }

            if (!char.IsDigit(ch) && ch != 8 && !(ch>=64 && ch <= 90) && !(ch >= 97 && ch <= 122) && ch != 45 && ch != 46 && ch != 95)
            {
                e.Handled = true;
            }
        }


        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPhone.SelectionLength == txtPhone.TextLength)
            {
                e.Handled = true;

                txtPhone.Text = phoneCode + (e.KeyChar == 8 ? string.Empty : e.KeyChar.ToString());

                //txtPhone.Text = phoneCode + e.KeyChar;
                txtPhone.Select(txtPhone.Text.Length, 0);
            }

            if (txtPhone.SelectionStart < 4 && e.KeyChar != 8)
                e.Handled = true;

            char ch = e.KeyChar;
            if (ch == 8 && txtPhone.Text == phoneCode)
                e.Handled = true;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }

            if (txtPhone.Text == string.Empty && char.IsDigit(ch))
            {
                e.Handled = true;
                txtPhone.Text = phoneCode + e.KeyChar;
                txtPhone.Select(txtPhone.Text.Length, 0);
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (txtPhone.Text == string.Empty)
                txtPhone.Text = phoneCode;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if(txtPhone.Text == phoneCode)
                txtPhone.Clear();
        }
    }
}
