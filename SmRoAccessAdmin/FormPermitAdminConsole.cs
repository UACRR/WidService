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

        private Dictionary<string, string> Txt = Translator.Load();

        #region Form Level Functions

        public FormPermitAdminConsole(string userCredentials)
        {
            string[] arr = userCredentials.Split(':');
            PermitApiProxy.UserLogin = arr[0];
            PermitApiProxy.UserPassword = arr[1];
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Translator.Transalate(this);
            Text += $" ({PermitApiProxy.UserLogin})";

            try
            {
                radCollapsiblePanelUserPersonalData.ControlsContainer.PanelElement.Border.Visibility = ElementVisibility.Collapsed;
                radCollapsiblePanelUserAccount.ControlsContainer.PanelElement.Border.Visibility = ElementVisibility.Collapsed;
                radCollapsiblePanelUserSysInfo.ControlsContainer.PanelElement.Border.Visibility = ElementVisibility.Collapsed;
                radCollapsiblePanelUserPermissions.ControlsContainer.PanelElement.Border.Visibility = ElementVisibility.Collapsed;
                radGridUserList.DataSource = PermitApiProxy.GetAllUsers();
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
            radChkUserIsLock.Checked = user.IsLock;
            radTbUserComment.Text = user.Comment;


            ignoreTextChanged = false;

            radGridUserRoles.DataSource = null;
            radGridUserRoles.DataSource = PermitApiProxy.GetUserRoles(user.CodeI);
        }

        private void radGridUserList_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            RefreshUserProps();
        }

        private void radBtnAddUser_Click(object sender, EventArgs e)
        {
            /*splitPanel1.Visible = false;
            leftSplitterPanelWidth = splitPanel1.SizeInfo.AbsoluteSize.Width;
            splitPanel1.SizeInfo.SizeMode = Telerik.WinControls.UI.Docking.SplitPanelSizeMode.Absolute;
            splitPanel1.SizeInfo.AbsoluteSize = new Size(1, 0);*/
            panelMain.Visible = false;
            splitPanel1.Collapsed = true;
            panelMain.Visible = true;

            isNewUser = true;
            currentRow = radGridUserList.CurrentRow;
            radGridUserList.CurrentRow = null;
            RefreshUserProps();
            radGridUserRoles.DataSource = null;
            radGridUserRoles.DataSource = PermitApiProxy.GetUserRoles(0);
            SetUserDirty(true);
            radBtnSaveUser.Visible =
                panelUserInfoContainer.Visible =
                    radBtnCancelUser.Visible = true;
            return;
            /*try
            {
                int codeI = AccessAdminOperations.AddUser();
                //radGridUserList.DataSource = null;
                //radGridUserList.DataSource = AccessAdminOperations.GetAllUsers();
                var newGridRow = radGridUserList.Rows.Single(x => ((User)x.DataBoundItem).CodeI == codeI);
                radGridUserList.CurrentRow = newGridRow;
                UpdateControlsState();
                SetUserDirty(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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
            try
            {
                PermitApiProxy.DeleteUser(user.CodeI);
                radGridUserList.Refresh();
                radGridUserList.CurrentRow.Delete();
                UpdateControlsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Txt["ERR"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radBtnSaveUser_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(radTbUserLogin.Text))
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
                Comment = radTbUserComment.Text
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
                    Clipboard.SetText($"CodeI: {res.CodeI}, Pwd: '{res.Password}'");
                    MessageBox.Show(this, Txt["DEF_PWD_CREATED"]
                        + Txt["PLEASE_PASTE"]
                        , Txt["INFO"], MessageBoxButtons.OK, MessageBoxIcon.Information);
                    splitPanel1.Collapsed = false;
                    radGridUserList.CurrentRow = currentRow;
                }
                else
                {
                    PermitApiProxy.SaveUser(user, roles);
                }

                radGridUserList.DataSource = null;
                radGridUserList.DataSource = PermitApiProxy.GetAllUsers();
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

            try
            {
                string res = PermitApiProxy.ResetPassword(user.CodeI);
                Clipboard.SetText($"CodeI: {user.CodeI}, Pwd: '{res}'");
                    MessageBox.Show(this, Txt["DEF_PWD_CREATED"]
                        + Txt["PLEASE_PASTE"]
                        , Txt["INFO"], MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Txt["ERR"], MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
