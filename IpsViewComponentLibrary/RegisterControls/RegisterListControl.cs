using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RegisterControls
{
    public partial class RegisterListControl : UserControl, ISubscriber<RegisterUpdatedEvent>
    {
        private readonly RegisterService _registerService;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        private RegisterListViewModel _register;
        public RegisterListViewModel SelectedRegister
        {
            get => gvRegisterList?.CurrentRow?.DataBoundItem as RegisterListViewModel;
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

        public bool IsExternalRegister { get; set; }

        public RegisterListControl()
        {
            InitializeComponent();

            dtCreateDateFrom.SetUserCalendarSettings();
            dtCreateDateTill.SetUserCalendarSettings();

            ctrlGridRowCount.RadGridViewDataSource = gvRegisterList;
            ctrlSearch.SetUsageGrid(gvRegisterList);

            gvRegisterList.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);

            if (!IsDesignMode)
            {
                _registerService = new RegisterService();

                SetDictionaries();
                //UpdateList();

                ApplicationController.Instance.EventAggregator.SubsribeEvent(this);
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

            var list = IsExternalRegister ? _registerService.GetExternalListByFilter(filter) : _registerService.GetListByFilter(filter);

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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void EditRegister(RegisterListViewModel selectedRegister)
        {
            if (IsExternalRegister)
            {
                using (var view = new RegisterCCIDView())
                {
                    var presenter = new RegisterCCIDPresenter(view, _registerService);
                    presenter.Show(selectedRegister.RegId);
                }
            }
            else
            {
                using (var view = new RegisterView())
                {
                    var presenter = new RegisterPresenter(view, _registerService);
                    presenter.Show(selectedRegister.RegId);
                }
            }
        }

        private void gvRegisterList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        protected virtual void OnRegisterSelected(RegisterListViewModel selectedRegister)
        {
            RegisterSelected(this, selectedRegister);
        }

        protected virtual void OnEditCommandExecuted(RegisterListViewModel selectedRegister)
        {
            EditCommandExecuted(this, selectedRegister);
        }

        public void HandleEvent(RegisterUpdatedEvent e)
        {
            UpdateList();
        }
    }
}
