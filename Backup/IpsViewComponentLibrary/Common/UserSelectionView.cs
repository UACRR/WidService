using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.Common
{
    public partial class UserSelectionView : Telerik.WinControls.UI.RadForm
    {
        private readonly UserService _userService;

        public event EventHandler<UserViewModel> UserSelected;

        private UserViewModel _user;
        public UserViewModel SelectedUser
        {
            get
            {
                if (gvUsers.CurrentRow == null)
                    return null;

                return gvUsers.CurrentRow.DataBoundItem as UserViewModel;
            }
            set
            {
                if (_user != value)
                {
                    _user = value;
                    UpdateCurrentRow();
                }
            }
        }

        public UserSelectionView()
        {
            InitializeComponent();

            _userService = new UserService();

            StartPosition = FormStartPosition.CenterParent;
        }

        private void UserSelectionView_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

        private async void UpdateList()
        {
            var list = await _userService.GetUsersWithRoleFixationAsync();
            bsUserViewModel.DataSource = list;
            UpdateCurrentRow();
        }

        private void UpdateCurrentRow()
        {
            if (_user != null)
            {
                var row = gvUsers.Rows.FirstOrDefault(r => (string)r.Cells["UserId"].Value == _user.UserId);
                if (row != null)
                {
                    gvUsers.CurrentRow = row;
                    gvUsers.TableElement.ScrollToRow(row);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gvUsers_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            SelectAndClose();
        }

        private void gvUsers_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void SelectAndClose()
        {
            var item = SelectedUser;

            if (item != null)
            {
                OnUserSelected(item);

                DialogResult = DialogResult.OK;
                Close();
            }
            else
                DialogResult = DialogResult.None;
        }

        protected virtual void OnUserSelected(UserViewModel item)
        {
            UserSelected?.Invoke(this, item);
        }

        #region User search

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvUsers.MasterTemplate.Refresh();
        }

        private void gvUsers_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvUsers.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvUsers.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvUsers.EndUpdate(false);
                return;
            }

            gvUsers.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvUsers.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvUsers.EndUpdate(false);
            }
        }

        #endregion
    }
}
