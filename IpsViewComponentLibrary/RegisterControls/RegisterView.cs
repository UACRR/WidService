using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Utilities;
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

        private RegisterFormType _formType;
        public RegisterFormType FormType
        {
            get { return _formType; }
            set
            {
                _formType = value;
                SetUpViewForFormType();
            }
        }

        public Register Register
        {
            get { return bsRegister.DataSource as Register; }
            set
            {
                if (bsRegister.DataSource != value)
                {
                    bsRegister.DataSource = value;
                    txtPeriodName.Text = value?.Rm?.Period?.PeriodName;
                    ddlLicCode.SelectedValue = value?.Rm?.Period?.Lic?.LicCode;
                }
            }
        }

        public ConsumerMainView ConsumerInfo
        {
            set
            {
                txtConsumerName.Text = value.Name;
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

            dtCreateDate.SetReadOnly(true);

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

        private void SetUpViewForFormType()
        {
            if (FormType == RegisterFormType.OrdinaryDistribution)
            {
                splitPanelStage.Collapsed = true;

                ctrlRegisterItemList.ShowAuthors = true;
                ctrlRegisterItemListStage.ShowAuthors = true;

                lblMusicRate.Visible = false;
                mebMusicRate.Visible = false;
            }
            else if (FormType == RegisterFormType.CompositionAndMusicalDesignDistribution)
            {
                splitPanelStage.Collapsed = false;

                ctrlRegisterItemList.ShowAuthors = false;
                ctrlRegisterItemList.ExpandAll();

                ctrlRegisterItemListStage.ShowAuthors = false;

                lblMusicRate.Visible = true;
                mebMusicRate.Visible = true;
            }
        }

        private void SetDictionaries()
        {
            ddlStatus.SetDataSource(IpsGlobal.ObjectRightDictionaries.RegisterStatuses);
            ddlLicCode.SetDataSource(IpsGlobal.AnketaDictionaties.agrLicenseType);
            ddlAlgorithmId.SetDataSource(IpsGlobal.AnketaDictionaties.algorithmType);
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

        #region Validation

        public bool IsValid
        {
            get => ValidateChildren();
        }

        private void mebRegRate_Validating(object sender, CancelEventArgs e)
        {
            var value = int.Parse(mebRegRate.Text);

            if (value > 100)
            {
                errorProvider.SetError(mebRegRate, "Відсоток авторської винагороди по звіту не може бути більше 100%.");
                e.Cancel = true;
                return;
            }
            else
            {
                errorProvider.SetError(mebRegRate, "");
            }

            var authRate = int.Parse(mebAuthRate.Text);
            var musicRate = int.Parse(mebMusicRate.Text);

            if (value != authRate + musicRate)
            {
                errorProvider.SetError(mebRegRate, "Сума відсотків авторської винагороди постановки і музичного супроводу повинна дорівнювати відсотку винагороди по звіту.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(mebRegRate, "");
        }

        #endregion
    }
}
