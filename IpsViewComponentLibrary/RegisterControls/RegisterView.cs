using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace IpsViewComponentLibrary.RegisterControls
{
    public partial class RegisterView : Telerik.WinControls.UI.RadForm
    {
        private RegisterPresenter _presenter;
        public RegisterPresenter Presenter
        {
            set
            {
                if (_presenter == null)
                    _presenter = value;
            }
        }

        public Register Register
        {
            get { return registerBindingSource.DataSource as Register; }
            set
            {
                if (registerBindingSource.DataSource != value)
                {
                    registerBindingSource.DataSource = value;
                }
            }
        }

        public BindingList<RegisterItemViewModel> RegisterItemList { get; private set; } = new BindingList<RegisterItemViewModel>();
        public BindingList<RegisterExtra> RegisterExtraList { get; private set; } = new BindingList<RegisterExtra>();

        public BindingList<RegisterItemViewModel> RegisterItemListStage { get; private set; } = new BindingList<RegisterItemViewModel>();
        public BindingList<RegisterExtra> RegisterExtraListStage { get; private set; } = new BindingList<RegisterExtra>();

        public Collection<RegisterItemViewModel> SelectedRegisterItems { get => ctrlRegisterItemList.SelectedRegisterItems; }
        public Collection<RegisterItemViewModel> SelectedRegisterItemsStage { get => ctrlRegisterItemListStage.SelectedRegisterItems; }

        public RegisterView()
        {
            InitializeComponent();

            SetDictionaries();

            ctrlRegisterItemList.DataSource = RegisterItemList;
            ctrlRegisterItemList.DataSourceRegisterExtra = RegisterExtraList;

            ctrlRegisterItemListStage.DataSource = RegisterItemListStage;
            ctrlRegisterItemListStage.DataSourceRegisterExtra = RegisterExtraListStage;
        }

        public void Run()
        {
            SetControlEnabled((RegisterStatusType)Register.RgStatus);
            SetAllowedCommand((RegisterStatusType)Register.RgStatus);
            SetAllowedStatus((RegisterStatusType)Register.RgStatus);

            ShowDialog();
        }

        public void SetStatus(RegisterStatusType status)
        {
            ddlStatus.SelectedValue = (int)status;

            SetAllowedStatus(status);
            SetAllowedCommand(status);
            SetControlEnabled(status);
        }

        // ordinary distribution
        public void SetupViewForSchema1()
        {
            splitPanelStage.Collapsed = true;

            ctrlRegisterItemList.ShowAuthors = true;
            ctrlRegisterItemListStage.ShowAuthors = true;
        }

        // composition and musical design distribution
        public void SetupViewForSchema2()
        {
            splitPanelStage.Collapsed = false;

            ctrlRegisterItemList.ShowAuthors = false;
            ctrlRegisterItemList.ExpandAll();

            ctrlRegisterItemListStage.ShowAuthors = false;
        }

        private void SetDictionaries()
        {
            ddlStatus.ValueMember = "CodeI";
            ddlStatus.DisplayMember = "Name";
            ddlStatus.DataSource = IpsGlobal.ObjectRightDictionaries.RegisterStatuses;
        }

        private void SetAllowedStatus(RegisterStatusType status)
        {
            if (status == RegisterStatusType.OnAcception)
            {
                btnSetStatus.Text = "Погодити";
                btnSetStatus.Tag = RegisterStatusType.Accepted;
            }
            else
            {
                btnSetStatus.Text = "До розподілу";
                btnSetStatus.Tag = RegisterStatusType.OnDistribution;
            }
        }

        private void SetAllowedCommand(RegisterStatusType status)
        {
            var canWork = status == RegisterStatusType.Accepted;

            ctrlRegisterItemList.AllowFindCommand = canWork;
            ctrlRegisterItemList.AllowLinkCommand = canWork;
            ctrlRegisterItemList.AllowUnlinkCommand = canWork;
            ctrlRegisterItemList.AllowCreateObjectCommand = canWork;

            ctrlRegisterItemListStage.AllowFindCommand = canWork;
            ctrlRegisterItemListStage.AllowLinkCommand = canWork;
            ctrlRegisterItemListStage.AllowUnlinkCommand = canWork;
            ctrlRegisterItemListStage.AllowCreateObjectCommand = canWork;
        }

        private void SetControlEnabled(RegisterStatusType status)
        {
            if (status == RegisterStatusType.OnAcception)
            {
                gboxStatus.Enabled = true;
                gboxSearch.Enabled = false;
            }
            else if (status == RegisterStatusType.Accepted)
            {
                gboxStatus.Enabled = true;
                gboxSearch.Enabled = true;
            }
            else if (status == RegisterStatusType.OnDistribution || status == RegisterStatusType.Completed || status == RegisterStatusType.Canceled)
            {
                gboxStatus.Enabled = false;
                gboxSearch.Enabled = false;
            }

            btnSetCanceledStatus.Enabled = !((int)status >= 2);
        }

        private void btnSearchAuto_Click(object sender, EventArgs e)
        {
            _presenter.SearchObjectsAuto();
        }

        private void btnSearchAll_Click(object sender, EventArgs e)
        {
            _presenter.SearchObjectsForAll();
        }

        private void btnSearchNotLinked_Click(object sender, EventArgs e)
        {
            _presenter.SearchObjectsForNotLinked();
        }

        private void btnSearchSelected_Click(object sender, EventArgs e)
        {
            _presenter.SearchObjectsForSelected();
        }

        private void btnCreateSelected_Click(object sender, EventArgs e)
        {
            _presenter.CreateObjectsForSelected();
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            _presenter.SetStatus((RegisterStatusType)btnSetStatus.Tag);
        }

        private void btnSetCanceledStatus_Click(object sender, EventArgs e)
        {
            _presenter.SetStatus(RegisterStatusType.Canceled);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }
    }
}
