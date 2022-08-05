using SmRoPermitClientLib;
using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmRoPermitClientLib
{
    public partial class FormLogin : Form
    {
        private delegate void ProtectedOperation();
        private static void RunProtectedOperation(ProtectedOperation oper)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                oper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private static bool IsPasswordStrong(string password)
        {
            return password.Length >= 8
                && Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript);
        }

        public int CodeI { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }

        private bool IsChangePasswordMode = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void AdjustFormHeight()
        {
            float newHeight = 0;
            foreach (RowStyle rs in panelMain.RowStyles)
            {
                newHeight += rs.Height;
            }
            ClientSize = new Size(ClientSize.Width, Convert.ToInt32(newHeight) + 10);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            IsChangePasswordMode = false;
            panelMain.RowStyles[3].Height = 0;
            panelMain.RowStyles[4].Height = 0;
            AdjustFormHeight();
        }

        private void radBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void radBtnOk_Click(object sender, EventArgs e)
        {
            RunProtectedOperation( () => {
                if (!IsChangePasswordMode)
                {
                    PermitApiProxy.UserLogin = radTbLogin.Text;
                    PermitApiProxy.UserPassword = radTbPassword.Text;
                    RspLogin res = PermitApiProxy.Login();
                    switch (res.Result)
                    {
                        case RspLogin.LoginResult.Success:
                            CodeI = res.UserCodeI;
                            Login = radTbLogin.Text;
                            Password = radTbPassword.Text;
                            DialogResult = DialogResult.OK;
                            Close();
                            break;
                        case RspLogin.LoginResult.Failed:
                            radLabPrompt.Text = "Invalid login and/or password. Please, change and try again.";
                            radLabPrompt.BackColor = Color.Red; 
                            break;
                        case RspLogin.LoginResult.ChangePassword:
                            radLabPrompt.Text = "Please, change password.";
                            radLabPrompt.BackColor = BackColor;
                            panelMain.RowStyles[3].Height = 30;
                            panelMain.RowStyles[4].Height = 30;
                            AdjustFormHeight();
                            radTbLogin.Enabled = radTbPassword.Enabled = false;
                            IsChangePasswordMode = true;
                            break;
                    }
                }
                else
                {
                    if (!IsPasswordStrong(radTbNewPassword.Text))
                    {
                        panelMain.RowStyles[0].Height = 60;
                        AdjustFormHeight();
                        radLabPrompt.Text = "Password is not strong enough. Please. make sure that it is not less than 8 characters in length and contains digits, letters in lower and upper cases, and at least one special character.";
                        return;
                    }
                    RspLogin res = PermitApiProxy.ChangePasswordAndLogin(radTbLogin.Text, radTbPassword.Text, radTbNewPassword.Text);
                    CodeI = res.UserCodeI;
                    Login = radTbLogin.Text;
                    Password = radTbNewPassword.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            });
        }
    }
}
