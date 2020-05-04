using LanguageLibrary;
using LanguageLibrary.Model;
using SmRoPermitClientLib;
using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace SmRoPermitAdmin
{
    public partial class FormPermitAdminConsole : Form
    {
        private bool isUserDirty = false;
        private bool ignoreTextChanged = false;
        private bool ignoreCheckChanged = false;
        private bool isNewUser = false;
        private GridViewRowInfo currentRow;

        private static FormPermitAdminConsole Instance = null;

        private Dictionary<string, string> Txt = null;
        private string Lang;

        private delegate void ProtectedOperation();
        private void RunProtectedOperation(ProtectedOperation oper)
        {
            try
            {
                oper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Txt["ERR"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        #region Form Level Functions

        public void Translate(Control control)
        {
            if (!string.IsNullOrEmpty(control.Text))
            {
                control.Text = GetText(control.Text);
            }
            Type type = control.GetType();
            if (type.Name == "RadCollapsiblePanel")
            {
                var panel = control as Telerik.WinControls.UI.RadCollapsiblePanel;
                panel.HeaderText = GetText(panel.HeaderText);
            }
            else if (type.Name == "RadGridView")
            {
                var panel = control as Telerik.WinControls.UI.RadGridView;
                foreach (var col in panel.Columns)
                    col.HeaderText = GetText(col.HeaderText);
            }
            foreach (Control ctrl in control.Controls)
            {
                Translate(ctrl);
            }
        }

        private string GetText(string code)
        {
            return Txt.ContainsKey(code) ? Txt[code] : code;
        }

        public static void Show(string userCredentials)
        {
            try
            {
                if (Instance != null && !Instance.IsDisposed)
                {
                    Instance.Show();
                    Instance.Activate();
                }
                else
                {
                    Instance = new FormPermitAdminConsole(userCredentials);
                    Instance.Lang = AppLanguageLibrary.ApplicationCultureInfo.Name;
                    Instance.Txt = new Dictionary<string, string>();

                    Type type = AppLanguageLibrary.CurrentLanguage.SmRoPermitLD.GetType();
                    foreach (var prop in type.GetProperties())
                    {
                        LanguageItem li = (LanguageItem)prop.GetValue(AppLanguageLibrary.CurrentLanguage.SmRoPermitLD);
                        Instance.Txt[prop.Name] = string.IsNullOrEmpty(li.Content) ? prop.Name : li.Content;
                    }

                    Instance.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Instance.Txt["ERR"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private FormPermitAdminConsole(string userCredentials)
        {
            string[] arr = userCredentials.Split(':');
            PermitApiProxy.UserLogin = arr[0];
            PermitApiProxy.UserPassword = arr[1];
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                Text = GetText(Text);
            }

            foreach (Control ctrl in Controls)
            {
                Translate(ctrl);
            }

            Text += $" ({PermitApiProxy.UserLogin})";

            try
            {
                radCollapsiblePanelUserPersonalData.ControlsContainer.PanelElement.Border.Visibility =
                    ElementVisibility.Collapsed;
                radCollapsiblePanelUserAccount.ControlsContainer.PanelElement.Border.Visibility =
                    ElementVisibility.Collapsed;
                radCollapsiblePanelUserSysInfo.ControlsContainer.PanelElement.Border.Visibility =
                    ElementVisibility.Collapsed;
                radCollapsiblePanelUserPermissions.ControlsContainer.PanelElement.Border.Visibility =
                    ElementVisibility.Collapsed;
                var userList = PermitApiProxy.GetAllUsers(Lang);
                radGridUserList.DataSource = userList;
                UpdateControlsState();
                SetUserDirty(false);
                RefreshUserProps();
                UserPermissions.ImposeRestrictions(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Txt["ERR"], MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void radSplitUsers_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void radBtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isUserDirty)
            {
                MessageBox.Show(this, Txt["CONF_SAVE"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        #endregion

        #region User Level Functions

        private void UpdateControlsState()
        {
            radBtnDeleteUser.Enabled =
            radBtnResetPassword.Enabled =
            radBtnSaveUser.Visible =
            panelUserInfoContainer.Visible = 
            radBtnCancelUser.Visible = radGridUserList.CurrentRow != null;

            if (radGridUserList.CurrentRow != null)
            {
                User user = (User)radGridUserList.CurrentRow.DataBoundItem;
                radBtnResetPassword.Enabled = !user.IsWindowsAuth;
            }
        }

        private void SetUserDirty(bool isDirty)
        {
            isUserDirty = isDirty;
            radBtnSaveUser.Enabled = isUserDirty;
            radBtnCancelUser.Enabled = isUserDirty;
            radBtnAddUser.Enabled = !isUserDirty;
            radBtnDeleteUser.Enabled = !isUserDirty;
            radBtnResetPassword.Enabled = !isUserDirty;
        }

        private void RefreshUserProps()
        {
            if (radGridUserList.CurrentRow == null)
            {
                ignoreTextChanged = true;

                radLabUserInfoTitle.Text = Txt["NEW_USER"];

                radTbUserCodeI.Text = "";
                radTbUserLogin.Text = "";
                radTbUserFirstName.Text = "";
                radTbUserSurName.Text = "";
                radTbUserLastName.Text = "";
                radTbUserEmail.Text = "";
                radTbUserPhoneNumber.Text = "";
                radTbUserPasswordHash.Text = "";
                radTbUserCreateDate.Text = "";
                radTbUserModifyDate.Text = "";
                radChkUseWindowsAuth.Checked = false;
                radChkUserIsLock.Checked = false;
                radTbUserComment.Text = "";

                ignoreTextChanged = false;
                return;
            }
            User user = (User)radGridUserList.CurrentRow.DataBoundItem;
            ignoreTextChanged = true;

            radLabUserInfoTitle.Text = $"{user.FirstName} {user.SurName} {user.LastName} ({user.Login})";

            radTbUserCodeI.Text = user.CodeI.ToString();
            radTbUserLogin.Text = user.Login;
            radTbUserFirstName.Text = user.FirstName;
            radTbUserSurName.Text = user.SurName;
            radTbUserLastName.Text = user.LastName;
            radTbUserEmail.Text = user.Email;
            radTbUserPhoneNumber.Text = user.PhoneNumber;
            radTbUserPasswordHash.Text = user.PasswordHash;
            radTbUserCreateDate.Text = user.CreateDate.ToString("yyyy-MM-dd");
            radTbUserModifyDate.Text = user.ModifyDate.ToString("yyyy-MM-dd");
            radChkUseWindowsAuth.Checked = user.IsWindowsAuth;
            radChkUserIsLock.Checked = user.IsLock;
            radTbUserComment.Text = user.Comment;

            UpdateControlsState();

            ignoreTextChanged = false;

            radGridUserRoles.DataSource = null;
            RunProtectedOperation(() =>
            {
                radGridUserRoles.DataSource = PermitApiProxy.GetUserRoles(user.CodeI, Lang);
            });
        }

        private void radGridUserList_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            RefreshUserProps();
        }

        private void radBtnAddUser_Click(object sender, EventArgs e)
        {
            RunProtectedOperation(() =>
            {
                panelMain.Visible = false;
                splitPanel1.Collapsed = true;
                panelMain.Visible = true;

                isNewUser = true;
                currentRow = radGridUserList.CurrentRow;
                radGridUserList.CurrentRow = null;
                RefreshUserProps();
                radGridUserRoles.DataSource = null;
                radGridUserRoles.DataSource = PermitApiProxy.GetUserRoles(0, Lang);
                SetUserDirty(true);
                radBtnSaveUser.Visible =
                    panelUserInfoContainer.Visible =
                        radBtnCancelUser.Visible = true;
            });
        }

        private void radBtnDeleteUser_Click(object sender, EventArgs e)
        {
            if (radGridUserList.CurrentRow == null)
                return;
            if (MessageBox.Show(this, Txt["DEL_USER"], Txt["QUEST"], MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            User user = (User)radGridUserList.CurrentRow.DataBoundItem;
            if (PermitApiProxy.UserLogin.Equals(user.Login, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(this, Txt["CANNOT_DELETE_SELF"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RunProtectedOperation(() =>
            {
                PermitApiProxy.DeleteUser(user.CodeI);
                radGridUserList.Refresh();
                radGridUserList.CurrentRow.Delete();
                UpdateControlsState();
            });
        }

        private void radBtnSaveUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(radTbUserLogin.Text))
            {
                MessageBox.Show(this, Txt["PROVIDE_USER_LOGIN"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!isNewUser)
            {
                string curUserLogin = ((User)radGridUserList.CurrentRow.DataBoundItem).Login;
                string loggedInLogin = PermitApiProxy.UserLogin;
                if(loggedInLogin.Equals(curUserLogin, StringComparison.OrdinalIgnoreCase))
                {
                    if (!curUserLogin.Equals(radTbUserLogin.Text.Trim(), StringComparison.Ordinal))
                    {
                        MessageBox.Show(this, Txt["CANNOT_CHANGE_LOGIN"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (radChkUserIsLock.Checked)
                    {
                        MessageBox.Show(this, Txt["CANNOT_BLOCK_LOGIN"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            User user = new User
            {
                CodeI = isNewUser ? 0 : Convert.ToInt32(radTbUserCodeI.Text),
                Login = radTbUserLogin.Text.Trim(),
                FirstName = radTbUserFirstName.Text,
                SurName = radTbUserSurName.Text,
                LastName = radTbUserLastName.Text,
                Email = radTbUserEmail.Text,
                PhoneNumber = radTbUserPhoneNumber.Text,
                PasswordHash = radTbUserPasswordHash.Text,
                IsLock = radChkUserIsLock.Checked,
                Comment = radTbUserComment.Text,
                IsTempPassword = isNewUser && !radChkUseWindowsAuth.Checked,
                IsWindowsAuth = radChkUseWindowsAuth.Checked
            };

            List<Role> roles = (List<Role>)radGridUserRoles.DataSource;
            try
            {
                SetUserDirty(false); // should be here because AddUser indirectly causes RowChanging event
                if (isNewUser)
                {
                    RspAddUser.AddUserResult res = PermitApiProxy.AddUser(user, roles);
                    user.CodeI = res.CodeI;
                    isNewUser = false;
                    if (!radChkUseWindowsAuth.Checked)
                    {
                        Clipboard.SetText($"CodeI: {res.CodeI}, Pwd: '{res.Password}'");
                        MessageBox.Show(this, Txt["DEF_PWD_CREATED"]
                            + Txt["PLEASE_PASTE"]
                            , Txt["INFO"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    splitPanel1.Collapsed = false;
                    radGridUserList.CurrentRow = currentRow;
                }
                else
                {
                    PermitApiProxy.SaveUser(user, roles);
                }

                radGridUserList.DataSource = null;
                radGridUserList.DataSource = PermitApiProxy.GetAllUsers(Lang);
                var updatedGridRow = radGridUserList.Rows.Single(x => ((User)x.DataBoundItem).CodeI == user.CodeI);
                radGridUserList.CurrentRow = updatedGridRow;

            }
            catch (LoginNotUniqueException ex)
            {
                SetUserDirty(true);
                //RefreshUserProps();
                MessageBox.Show(this, Txt["LOGIN_NOT_UNIQUE"], Txt["ERR"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SetUserDirty(true);
                //RefreshUserProps();
                MessageBox.Show(this, ex.Message, Txt["ERR"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radBtnCancelUser_Click(object sender, EventArgs e)
        {
            SetUserDirty(false);
            if (isNewUser)
            {
                isNewUser = false;
                splitPanel1.Collapsed = false;
                radGridUserList.CurrentRow = currentRow;
            }
            RefreshUserProps();
        }

        private void radTbUserName_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged)
                return;
            SetUserDirty(true);
        }

        private void radTbUserPosition_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged)
                return;
            SetUserDirty(true);
        }

        private void radTbUserLogin_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged)
                return;
            SetUserDirty(true);
        }

        private void radTbUserPassword_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged)
                return;
            SetUserDirty(true);
        }

        private void radGridUserList_CurrentRowChanging(object sender, Telerik.WinControls.UI.CurrentRowChangingEventArgs e)
        {
            if (isUserDirty)
            {
                MessageBox.Show(this, Txt["UNSAVED_CHANGES"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        #endregion

        private void radChkUserIsLock_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged)
                return;
            SetUserDirty(true);
        }

        private void radGridUserRoles_ValueChanged(object sender, EventArgs e)
        {
            if (radGridUserRoles.ActiveEditor is RadCheckBoxEditor)
            {
                if (ignoreCheckChanged)
                    return;
                bool willBeChecked = !(bool)radGridUserRoles.CurrentCell.Value;

                if (!isNewUser)
                {
                    string curUserLogin = ((User)radGridUserList.CurrentRow.DataBoundItem).Login;
                    string loggedInLogin = PermitApiProxy.UserLogin;

                    if(loggedInLogin.Equals(curUserLogin, StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show(this, Txt["CANNOT_CHANGE_PERM"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ignoreCheckChanged = true;
                        radGridUserRoles.ActiveEditor.Value = willBeChecked ? ToggleState.Off : ToggleState.On;
                        ignoreCheckChanged = false;
                        return;
                    }
                }


                if (radGridUserRoles.CurrentCell.ColumnInfo.Name.Equals("CanRead", StringComparison.OrdinalIgnoreCase))
                {
                    if (!willBeChecked)
                    {
                        radGridUserRoles.CurrentRow.Cells["CanWrite"].Value = false;
                    }
                }
                else if (radGridUserRoles.CurrentCell.ColumnInfo.Name.Equals("CanWrite", StringComparison.OrdinalIgnoreCase))
                {
                    if(willBeChecked)
                    {
                        radGridUserRoles.CurrentRow.Cells["CanRead"].Value = true;
                    }
                }

                SetUserDirty(true);
            }
        }

        private void radBtnResetPassword_Click(object sender, EventArgs e)
        {
            if (radGridUserList.CurrentRow == null)
                return;
            User user = (User)radGridUserList.CurrentRow.DataBoundItem;
            if (PermitApiProxy.UserLogin.Equals(user.Login, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(this, Txt["CANNOT_CHANGE_PWD"], Txt["WARN"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DialogResult.OK != MessageBox.Show(this, Txt["CONFIRM_PWD_RESET"], Txt["QUEST"], MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return;
            }

            RunProtectedOperation(() =>
            {
                string res = PermitApiProxy.ResetPassword(user.CodeI);
                Clipboard.SetText($"CodeI: {user.CodeI}, Pwd: '{res}'");
                    MessageBox.Show(this, Txt["DEF_PWD_CREATED"]
                        + Txt["PLEASE_PASTE"]
                        , Txt["INFO"], MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void radChkUseWindowsAuth_CheckStateChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged)
                return;
            SetUserDirty(true);
        }
    }
}
