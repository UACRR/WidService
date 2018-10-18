using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.Fixations;
using ipsFormsDesign.ViewModels.Users;
using IpsViewComponentLibrary.Common;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.FixationControls
{
    public partial class FixationView : IpsViewComponentLibrary.Common.Form.IpsForm
    {
        private bool firstShowDistribution = true;

        private FixationPresenter _presenter;
        public FixationPresenter Presenter
        {
            get { return _presenter; }
            set
            {
                if (_presenter == null)
                {
                    _presenter = value;
                }
            }
        }

        private Fixation _fixation;
        public Fixation Fixation
        {
            get { return _fixation; }
            set
            {
                _fixation = value;
                bsFixation.DataSource = _fixation;
                ShowAllowedPages();
            }
        }

        private UserViewModel _responsible;
        public UserViewModel Responsible
        {
            get { return _responsible; }
            set
            {
                _responsible = value;
                ddlResponsible.Text = _responsible.FullName;
            }
        }

        private ConsumerMainView _consumer;
        public ConsumerMainView Consumer
        {
            get { return _consumer; }
            set
            {
                _consumer = value;
                ddlConsumer.Text = _consumer.Name;
                txtClientInnOkpo.Text = _consumer.Innokpo;
            }
        }

        private bool _showStatusesGroupBox = false;
        public bool ShowStatusesGroupBox
        {
            get { return _showStatusesGroupBox; }
            set
            {
                _showStatusesGroupBox = value;
                bgbStatuses.Visible = _showStatusesGroupBox;
            }
        }

        public bool IsValid
        {
            get => ValidateChildren();
        }

        public BindingList<RegisterItemViewModel> RegisterItemList { get; } = new BindingList<RegisterItemViewModel>();
        public BindingList<RegisterCountViewModel> RegisterCountList { get; } = new BindingList<RegisterCountViewModel>();
        public BindingList<AmountDistributionViewModel> DistributionList { get; } = new BindingList<AmountDistributionViewModel>();

        public FixationView()
        {
            InitializeComponent();

            ddlUsesType.SetDataSource(IpsGlobal.AnketaDictionaties.usesType);
            ddlStage.SetDataSource(IpsGlobal.AnketaDictionaties.fixStageStatus, "CodeI", "StageName");
            ddlStatus.SetDataSource(IpsGlobal.AnketaDictionaties.fixStageStatus, "CodeI", "StatusName");

            gvStorages.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);
            gvFiles.SetCommandColumnImageAlignment("DeleteColumn", ContentAlignment.MiddleCenter);

            bgbStatuses.Visible = _showStatusesGroupBox;

            ctrlRegisterItemList.DataSource = RegisterItemList;
            ctrlRegisterItemList.DataSourceRegisterCount = RegisterCountList;
            bsAmountDistributionViewModel.DataSource = DistributionList;
        }

        public void SetAvailableStageStatuses(IEnumerable<FixationStageStatuses> stageStatuses)
        {
            bgbStatuses.Buttons.Clear();

            foreach (var ss in stageStatuses)
            {
                bgbStatuses.Buttons.AddButton(EnumUtility.GetDescription(ss), ss);
            }
        }

        public void Run()
        {
            ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _presenter.Save();
        }

        private void bgbStatuses_ValueSelected(object sender, ValueSelectedEventArgs e)
        {
            _presenter.SetStatus((FixationStageStatuses)e.Value);
            bsFixation.ResetCurrentItem();
            ShowAllowedPages();
        }

        private void btnAddStorage_Click(object sender, EventArgs e)
        {
            var newRow = gvStorages.Rows.AddNew();
            newRow.Cells["Name"].BeginEdit();
        }

        private void gvStorages_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "DeleteColumn")
            {
                gvStorages.Rows.Remove(gvStorages.CurrentRow);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            var newRow = gvFiles.Rows.AddNew();
            newRow.Cells["Name"].BeginEdit();
        }

        private void gvFiles_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "DeleteColumn")
            {
                gvFiles.Rows.Remove(gvFiles.CurrentRow);
            }
        }

        private void ddlResponsible_PopupOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            _presenter.SelectResponsible();
        }

        private void ddlConsumer_PopupOpening(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            _presenter.SelectConsumer();
        }

        private void ctrlRegisterItemList_ObjectLinked(object sender, RegisterControls.ObjectLinkedEventArgs e)
        {
            _presenter.LinkObject(e.RegisterItem, e.ObjectRight);
        }

        private void ctrlRegisterItemList_RegisterItemAdded(object sender, RegisterControls.RegisterItemAddedEventArgs e)
        {
            _presenter.NewRegisterItemAdded(e.NewRegisterItem);
        }

        private void ctrlRegisterItemList_UnlinkCommandExecuted(object sender, RegisterItemViewModel registerItem)
        {
            _presenter.UnlinkObject(registerItem);
        }

        private void ctrlRegisterItemList_RegisterCountDeleted(object sender, RegisterCountViewModel registerCount)
        {
            _presenter.RegisterCountDeleted(registerCount);
        }

        private void mainPageView_SelectedPageChanged(object sender, EventArgs e)
        {
            if (mainPageView.SelectedPage == pageDistribution && firstShowDistribution)
            {
                firstShowDistribution = false;
                _presenter.UpdateAmountDistribution();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _presenter.UpdateAmountDistribution();
        }

        private void gvDistribution_GroupSummaryEvaluate(object sender, GroupSummaryEvaluationEventArgs e)
        {
            if (e.SummaryItem.Name == "ObjName")
            {
                var distr = e.Group[0].DataBoundItem as AmountDistributionViewModel;

                if (distr != null)
                    e.FormatString = $"Твір: {distr.ObjName}, Автори: {distr.Author}";
            }
        }

        #region Print documents

        private void btnOrderFixation_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationOrder();
        }

        private void btnPrintFixationAct_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationAct();
        }

        private void btnPrintSlugbova_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationSlugbova();
        }

        private void btnPrintIdentificationAct_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationIdentificationAct();
        }

        #endregion

        #region Validation

        private void ddlConsumer_Validating(object sender, CancelEventArgs e)
        {
            if (!_presenter.ValidateConsumer())
            {
                errorProvider.SetError(ddlConsumer, "Користувач є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(ddlConsumer, "");
        }

        private void txtEventName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEventName.Text))
            {
                errorProvider.SetError(txtEventName, "Назва заходу є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(txtEventName, "");
        }

        private void txtEventDates_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEventDates.Text))
            {
                errorProvider.SetError(txtEventDates, "Дати заходу є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(txtEventDates, "");
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCity.Text))
            {
                errorProvider.SetError(txtCity, "Місто є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(txtCity, "");
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, "Адреса є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(txtAddress, "");
        }

        private void txtPlacement_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlacement.Text))
            {
                errorProvider.SetError(txtPlacement, "Приміщення є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(txtPlacement, "");
        }

        #endregion

        private void ShowAllowedPages()
        {
            var fixationVisibility = 
                _fixation.StageStatus >= (int)FixationStageStatuses.FixationNotScheduled ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            var identificatioVisibility =
                _fixation.StageStatus >= (int)FixationStageStatuses.RightholderIdentificationOnIdentification ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            var judicalVisibility =
                _fixation.StageStatus >= (int)FixationStageStatuses.JudicalWorkOnJudicalWork ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            var distributionVisibility =
                _fixation.StageStatus >= (int)FixationStageStatuses.IncomeMonitoring ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            if (_fixation.StageStatus == (int)FixationStageStatuses.ClosedWithoutViolation || _fixation.StageStatus == (int)FixationStageStatuses.ClosedAgreedBeforeFixation)
            {
                fixationVisibility = ElementVisibility.Collapsed;
                identificatioVisibility = ElementVisibility.Collapsed;
                judicalVisibility = ElementVisibility.Collapsed;
                distributionVisibility = ElementVisibility.Collapsed;
            }
            else if (_fixation.StageStatus == (int)FixationStageStatuses.ClosedAgreedAfterFixation)
            {
                fixationVisibility = ElementVisibility.Visible;
                identificatioVisibility = ElementVisibility.Visible;
                judicalVisibility = ElementVisibility.Collapsed;
                distributionVisibility = ElementVisibility.Collapsed;
            }
            else if (_fixation.StageStatus == (int)FixationStageStatuses.ClosedByCourt)
            {
                fixationVisibility = ElementVisibility.Visible;
                identificatioVisibility = ElementVisibility.Visible;
                judicalVisibility = ElementVisibility.Visible;
                distributionVisibility = ElementVisibility.Collapsed;
            }
            else if (_fixation.StageStatus == (int)FixationStageStatuses.ClosedIncomeRecieved)
            {
                fixationVisibility = ElementVisibility.Visible;
                identificatioVisibility = ElementVisibility.Visible;
                judicalVisibility = ElementVisibility.Visible;
                distributionVisibility = ElementVisibility.Visible;
            }

            pageFixation.Item.Visibility = fixationVisibility;
            pageIdentification.Item.Visibility = identificatioVisibility;
            pageJudicalWork.Item.Visibility = judicalVisibility;
            pageDistribution.Item.Visibility = distributionVisibility;
        }
    }
}
