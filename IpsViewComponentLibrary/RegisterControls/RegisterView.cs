using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Forms;

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

        public Collection<RegisterItemViewModel> SelectedRegisterItems { get => ctrlRegisterItemList.SelectedRegisterItems; }

        public RegisterView()
        {
            InitializeComponent();

            SetDictionaries();

            ctrlRegisterItemList.DataSource = RegisterItemList;
        }

        public void Run()
        {
            SetControlEnabled((RegisterStatusType)Register.RgStatus);
            SetAllowedCommand((RegisterStatusType)Register.RgStatus);
            SetAllowedStatus((RegisterStatusType)Register.RgStatus);

            ShowDialog();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Помилка");
        }

        public void SetStatus(RegisterStatusType status)
        {
            ddlStatus.SelectedValue = (int)status;

            SetAllowedStatus(status);
            SetAllowedCommand(status);
            SetControlEnabled(status);
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
        }

        private void ctrlRegisterItemList_FindCommandExecuted(object sender, RegisterItemViewModel selectedRegisterItem)
        {
            _presenter.SearchObjects(selectedRegisterItem);
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
