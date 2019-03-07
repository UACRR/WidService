using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsBossNameContactsControl : UserControl
    {
        private const string phoneCode = "+380";

        /// <summary>
        /// Зовнішній номер телефону
        /// </summary>
        public bool OutsidePhone { get; set; }

        public IpsBossNameContactsControl()
        {
            InitializeComponent();
            txtPhone.Text = phoneCode;
            txtPhone.Leave += txtPhone_Leave;
            txtPhone.Enter += txtPhone_Enter;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => employeeBindingSource.DataSource;
            set
            {
                if (employeeBindingSource.DataSource != value)
                    employeeBindingSource.DataSource = value;
            }
        }

        #region Edit controls

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtEmail => txtEmail;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtFirstName => txtFirstName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtLastName => txtLastName;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtPhone
        {
            get => txtPhone;
            set => txtPhone = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtSurName => txtSurName;

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
            if (!OutsidePhone)
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
            else
            {
                char ch = e.KeyChar;
                if (!char.IsDigit(ch) && ch != 8 && ch != 43)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (!OutsidePhone && txtPhone.Text == string.Empty)
                txtPhone.Text = phoneCode;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if(!OutsidePhone && txtPhone.Text == phoneCode)
                txtPhone.Clear();
        }

        public void UnsubscribePhoneVldt()
        {
            OutsidePhone = true;
            txtPhone.NullText = string.Empty;
        }
    }
}
