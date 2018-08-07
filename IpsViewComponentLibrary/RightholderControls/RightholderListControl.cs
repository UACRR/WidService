using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderListControl : UserControl
    {
        private RightholderService _rightholderService;
        private RightholderStatusType[] _allowedStatuses;

        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private RightholderMainView _rightholder;
        public RightholderMainView SelectedRightholder
        {
            get
            {
                if (gvRightholdersList.CurrentRow == null)
                    return null;

                return gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;
            }
            set
            {
                if (_rightholder != value)
                {
                    _rightholder = value;

                    if (_rightholder != null)
                    {
                        var row = gvRightholdersList.Rows.FirstOrDefault(r => (int)r.Cells["CustId"].Value == _rightholder.CustId);
                        if (row != null)
                        {
                            gvRightholdersList.CurrentRow = row;
                            gvRightholdersList.TableElement.ScrollToRow(row);
                        }
                    }
                }
            }
        }

        private bool _showCommandColumns = true;
        public bool ShowCommandColumns
        {
            get { return _showCommandColumns; }
            set
            {
                if (_showCommandColumns != value)
                {
                    _showCommandColumns = value;

                    gvRightholdersList.Columns["EditColumn"].IsVisible = _showCommandColumns;
                    gvRightholdersList.Columns["ObjectListColumn"].IsVisible = _showCommandColumns;
                    gvRightholdersList.Columns["SetStatusColumn"].IsVisible = _showCommandColumns;
                }
            }
        }

        public string SearchText
        {
            get => txtSearchRightholder.Text;
            set => txtSearchRightholder.Text = value;
        }

        public event EventHandler<RightholderMainView> RightholderSelected;
        public event EventHandler<RightholderMainView> EditCommandExecuted;
        public event EventHandler<RightholderMainView> ShowRightholdersObjectsCommandExecuted;

        public RightholderListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                _rightholderService = new RightholderService();
            }
        }

        public void SetAllowedStatuses(RightholderStatusType[] statuses)
        {
            _allowedStatuses = statuses;

            PopulateStatusesDropDownList();
        }

        public void ClearAllowedStatuses()
        {
            _allowedStatuses = null;

            PopulateStatusesDropDownList();
        }

        public void UpdateList()
        {
            UpdateList(SelectedRightholder);
        }

        public void UpdateList(RightholderMainView currentRightholder)
        {
            var query = new RightholderListQuery
            {
                Status = (RightholderStatusType)ddlStatus.SelectedValue,
            };

            var list = _rightholderService.GetRightholders(query);
            rightholderMainViewBindingSource.DataSource = list;

            SelectedRightholder = currentRightholder;
        }

        private void RightholderListControl_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode)
            {
                PopulateStatusesDropDownList();

                ddlStatus.SelectedValue = (int)RightholderStatusType.Active;
            }
        }

        private void ddlStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void gvRightholdersList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                OnEditCommandExecuted(SelectedRightholder);
            }
            else if (currentColumnName == "ObjectListColumn")
            {
                OnShowRightholdersObjectsCommandExecuted(SelectedRightholder);
            }
            else if (currentColumnName == "SetStatusColumn")
            {
                ShowChangeRightholderStatusMenu();
            }
        }

        private void gvRightholdersList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnRightholderSelected(SelectedRightholder);
        }

        private void ShowChangeRightholderStatusMenu()
        {
            var rightholder = gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;

            if (rightholder != null)
            {
                Point absolutePosition = gvRightholdersList.CurrentCell.PointToScreen(gvRightholdersList.CurrentCell.Location);
                absolutePosition.Y += gvRightholdersList.CurrentCell.Size.Height;

                var menu = RightholderStatusMenuFactory.Create((RightholderStatusType)rightholder.Status, RightholderStatusMenu_Click);
                menu.Show(absolutePosition);
            }
        }

        private void RightholderStatusMenu_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                var newStatus = (RightholderStatusType)menuItem.Tag;

                var result = _rightholderService.SetStatus(SelectedRightholder.CustId, newStatus);

                if (result)
                    UpdateList();
                else
                    MessageBox.Show("Не вдалося змінити статус.", "Помилка");
            }
        }

        private void OnRightholderSelected(RightholderMainView selectedRightholder)
        {
            RightholderSelected?.Invoke(this, selectedRightholder);
        }

        private void OnEditCommandExecuted(RightholderMainView selectedRightholder)
        {
            EditCommandExecuted?.Invoke(this, selectedRightholder);
        }

        private void OnShowRightholdersObjectsCommandExecuted(RightholderMainView selectedRightholder)
        {
            ShowRightholdersObjectsCommandExecuted?.Invoke(this, selectedRightholder);
        }

        private void PopulateStatusesDropDownList()
        {
            var statuses = IpsGlobal.AnketaDictionaties.customerStatus;

            if (_allowedStatuses != null)
            {
                statuses = statuses.Where(s => _allowedStatuses.Contains((RightholderStatusType)s.CodeI)).ToList();
            }

            ddlStatus.SelectedValueChanged -= ddlStatus_SelectedValueChanged;
            ddlStatus.SetDataSource(statuses);
            ddlStatus.SelectedValueChanged += ddlStatus_SelectedValueChanged;
        }

        #region Search rightolder

        private void txtSearchRightholder_TextChanged(object sender, EventArgs e)
        {
            gvRightholdersList.MasterTemplate.Refresh();
        }

        private void gvRightholdersList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchRightholder.Text))
            {
                gvRightholdersList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRightholdersList.EndUpdate(false);
                return;
            }

            gvRightholdersList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearchRightholder.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
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
                gvRightholdersList.EndUpdate(false);
            }
        }

        #endregion
    }
}
