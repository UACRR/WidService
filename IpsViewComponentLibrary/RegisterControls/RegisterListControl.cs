using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RegisterControls
{
    public partial class RegisterListControl : UserControl
    {
        private readonly RegisterService _registerService;

        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private RegisterListViewModel _register;
        public RegisterListViewModel SelectedRegister
        {
            get
            {
                if (gvRegisterList.CurrentRow == null)
                    return null;

                return gvRegisterList.CurrentRow.DataBoundItem as RegisterListViewModel;
            }
            set
            {
                if (_register != value)
                {
                    _register = value;

                    if (_register != null)
                    {
                        var row = gvRegisterList.Rows.FirstOrDefault(r => (int)r.Cells["RegId"].Value == _register.RegId);
                        if (row != null)
                        {
                            gvRegisterList.CurrentRow = row;
                        }
                    }
                }
            }
        }

        public event EventHandler<RegisterListViewModel> RegisterSelected = delegate { };
        public event EventHandler<RegisterListViewModel> EditCommandExecuted = delegate { };

        public RegisterListControl()
        {
            InitializeComponent();

            dtCreateDateFrom.SetUserCalendarSettingsm();
            dtCreateDateTill.SetUserCalendarSettingsm();

            if (!IsDesignMode)
            {
                _registerService = new RegisterService();

                SetDictionaries();
                UpdateList();
            }
        }

        private void SetDictionaries()
        {
            var statuses = IpsGlobal.ObjectRightDictionaries.RegisterStatuses.Where(s => s.CodeI != 0).ToList();
            statuses.Insert(0, new RegisterStatus { CodeI = -1, Name = "Всі" });

            ddlStatus.ValueMember = "CodeI";
            ddlStatus.DisplayMember = "Name";
            ddlStatus.DataSource = statuses;
        }

        public void UpdateList()
        {
            UpdateList(SelectedRegister);
        }

        public void UpdateList(RegisterListViewModel currentRegister)
        {
            var filter = new RegisterFilter();

            //var selectedStatus = ddlStatus.SelectedValue as RegisterStatus;
            if (ddlStatus.SelectedValue != null && (int)ddlStatus.SelectedValue != -1)
                filter.Status = (int)ddlStatus.SelectedValue;

            if (dtCreateDateFrom.Value != DateTime.MinValue)
                filter.BeginDate = dtCreateDateFrom.Value;

            if (dtCreateDateTill.Value != DateTime.MinValue)
                filter.EndDate = dtCreateDateTill.Value;

            var list = _registerService.GetListByFilter(filter);
            registerListViewModelBindingSource.DataSource = list;

            SelectedRegister = currentRegister;
        }

        private void gvRegisterList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            //OnRegisterSelected(SelectedRegister);
            EditRegister(SelectedRegister);
        }

        private void gvRegisterList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                //OnEditCommandExecuted(SelectedRegister);
                EditRegister(SelectedRegister);
            }
        }

        private void ddlStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void dtCreateDateFrom_ValueChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void dtCreateDateTill_ValueChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnClearFrom_Click(object sender, EventArgs e)
        {
            dtCreateDateFrom.Value = DateTime.MinValue;
        }

        private void btnClearTill_Click(object sender, EventArgs e)
        {
            dtCreateDateTill.Value = DateTime.MinValue;
        }

        private void EditRegister(RegisterListViewModel selectedRegister)
        {
            using (var view = new RegisterView())
            {
                var presenter = new RegisterPresenter(view, _registerService);
                presenter.Show(selectedRegister.RegId);
            }

            // TODO: broadcast event if item update
            UpdateList();
        }

        private void gvRegisterList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipTextForColumnHeader(sender, e);
        }

        protected virtual void OnRegisterSelected(RegisterListViewModel selectedRegister)
        {
            RegisterSelected(this, selectedRegister);
        }

        protected virtual void OnEditCommandExecuted(RegisterListViewModel selectedRegister)
        {
            EditCommandExecuted(this, selectedRegister);
        }

        #region Search

        private void txtSearchRegister_TextChanged(object sender, EventArgs e)
        {
            gvRegisterList.MasterTemplate.Refresh();
        }

        private void gvRegisterList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchRegister.Text))
            {
                gvRegisterList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvRegisterList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRegisterList.EndUpdate(false);
                return;
            }

            gvRegisterList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvRegisterList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearchRegister.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
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
                gvRegisterList.EndUpdate(false);
            }
        }

        #endregion
    }
}
