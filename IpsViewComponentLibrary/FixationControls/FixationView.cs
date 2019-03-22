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
using System.Reflection;
using System.Windows.Forms;
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
                SetUpPrintButton();
                SetUpIdentificationPage();
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

        private ConsumerSmallRightView _consumer;
        public ConsumerSmallRightView Consumer
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

        public BindingList<RegisterItemViewModel> RegisterItemList { get; } = new BindingList<RegisterItemViewModel>();
        public BindingList<RegisterCountViewModel> RegisterCountList { get; } = new BindingList<RegisterCountViewModel>();
        public BindingList<AmountDistributionViewModel> DistributionList { get; } = new BindingList<AmountDistributionViewModel>();

        public FixationView()
        {
            InitializeComponent();

            // this will enforce binding for invisible controls
            CreateControls(pageGeneral);
            CreateControls(pageFixation);
            CreateControls(pageIdentification);
            CreateControls(pageJudicalWork);
            CreateControls(pageDistribution);

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

        public void RunForSpecifyRequiredValues(FixationStageStatuses newStatus)
        {
            if (newStatus == FixationStageStatuses.FixationNotScheduled
                || newStatus == FixationStageStatuses.FixationScheduled
                || newStatus == FixationStageStatuses.FixationFixationCompleted)

                mainPageView.SelectedPage = pageFixation;

            else if (newStatus == FixationStageStatuses.RightholderIdentificationOnIdentification
                || newStatus == FixationStageStatuses.NegotiationAfterFixationOnNegotioation)

                mainPageView.SelectedPage = pageIdentification;

            else if (newStatus == FixationStageStatuses.JudicalWorkWinned)

                mainPageView.SelectedPage = pageJudicalWork;

            Run();
        }

        public bool IsValid()
        {
            return ValidateChildren();
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
            SetUpPrintButton();
            SetUpIdentificationPage();
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

        private void gvStorages_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            IpsViewComponentLibrary.Utilities.GridViewHelper.DisplayErrors(sender, e);
        }

        private void gvFiles_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            IpsViewComponentLibrary.Utilities.GridViewHelper.DisplayErrors(sender, e);
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
            _presenter.LinkObject(e.RegisterItem, e.ObjId);
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

        #region Print documents

        private void miPrintNakaz_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationOrder();
        }

        private void miPrintActFiksacii_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationAct();
        }

        private void miPrintActIdentyfikacii_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationIdentificationAct();
        }

        private void miPrintSlugbova_Click(object sender, EventArgs e)
        {
            _presenter.PrintFixationSlugbova();
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

        private void ddlResponsible_Validating(object sender, CancelEventArgs e)
        {
            if (!_presenter.ValidateResponsible())
            {
                errorProvider.SetError(ddlResponsible, "Відповідальний є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(ddlResponsible, "");
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

        private void dtFixationDtBegin_Validating(object sender, CancelEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.FixationScheduled)
                return;

            if (dtFixationDtBegin.Value == dtFixationDtBegin.NullDate)
            {
                errorProvider.SetError(dtFixationDtBegin, "Дата початку фіксації є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(dtFixationDtBegin, "");
        }

        private void dtFixationDtEnd_Validating(object sender, CancelEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.FixationFixationCompleted)
                return;

            if (dtFixationDtEnd.Value == dtFixationDtEnd.NullDate)
            {
                errorProvider.SetError(dtFixationDtEnd, "Дата завершення фіксації є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(dtFixationDtEnd, "");
        }

        private void gvStorages_Validating(object sender, CancelEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.FixationFixationCompleted)
                return;

            if (gvStorages.Rows.Count == 0)
            {
                gvStorages.TableElement.Text = "Вкажіть хоча б один носій.";
                errorProvider.SetError(lblStorages, "Вкажіть хоча б один носій.");
                e.Cancel = true;
            }
            else
            {
                gvStorages.TableElement.Text = "";
                errorProvider.SetError(lblStorages, "");
            }
        }

        private void gvStorages_RowValidating(object sender, RowValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty((string)e.Row.Cells["Name"].Value))
            {
                e.Row.Cells["Name"].ErrorText = "Назва є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["Name"].ErrorText = "";
            }

            if (string.IsNullOrEmpty((string)e.Row.Cells["SerialNumber"].Value))
            {
                e.Row.Cells["SerialNumber"].ErrorText = "Серійний номер є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["SerialNumber"].ErrorText = "";
            }

            if (e.Row.Cells["Capacity"].Value == null || (decimal)e.Row.Cells["Capacity"].Value == 0)
            {
                e.Row.Cells["Capacity"].ErrorText = "Об'єм є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["Capacity"].ErrorText = "";
            }
        }

        private void gvFiles_Validating(object sender, CancelEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.FixationFixationCompleted)
                return;

            if (gvFiles.Rows.Count == 0)
            {
                gvFiles.TableElement.Text = "Вкажіть хоча б один файл.";
                errorProvider.SetError(lblFiles, "Вкажіть хоча б один файл.");
                e.Cancel = true;
            }
            else
            {
                gvFiles.TableElement.Text = "";
                errorProvider.SetError(lblFiles, "");
            }
        }

        private void gvFiles_RowValidating(object sender, RowValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty((string)e.Row.Cells["Name"].Value))
            {
                e.Row.Cells["Name"].ErrorText = "Назва є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["Name"].ErrorText = "";
            }
        }

        private void ctrlRegisterItemList_RegisterItemListValidating(object sender, CancelEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.RightholderIdentificationOnIdentification)
                return;

            var gv = (RadGridView)sender;

            if (gv.Rows.Count == 0)
            {
                gv.TableElement.Text = "Вкажіть хоча б один твір.";
                e.Cancel = true;
            }
            else
            {
                gv.TableElement.Text = "";
            }
        }

        private void ctrlRegisterItemList_RegisterItemRowValidating(object sender, RowValidatingEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.RightholderIdentificationOnIdentification)
                return;

            if (string.IsNullOrEmpty((string)e.Row.Cells["ItemName"].Value))
            {
                e.Row.Cells["ItemName"].ErrorText = "Назва твору є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["ItemName"].ErrorText = "";
            }

            if (string.IsNullOrEmpty((string)e.Row.Cells["Performer"].Value))
            {
                e.Row.Cells["Performer"].ErrorText = "Виконавець є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["Performer"].ErrorText = "";
            }

            if (e.Row.Cells["TimeStart"].Value == null)
            {
                e.Row.Cells["TimeStart"].ErrorText = "Час початку звучання є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["TimeStart"].ErrorText = "";
            }

            if (e.Row.Cells["TimeEnd"].Value == null)
            {
                e.Row.Cells["TimeEnd"].ErrorText = "Час завершення звучання є обов'язковим полем.";
                e.Cancel = true;
            }
            else
            {
                e.Row.Cells["TimeEnd"].ErrorText = "";
            }

            if (_fixation.StageStatus >= (int)FixationStageStatuses.NegotiationAfterFixationOnNegotioation)
            {
                if (e.Row.Cells["ObjId"].Value == null)
                {
                    e.Row.Cells["ObjectName"].ErrorText = "Необхідно прив'язати об'єкт права.";
                    e.Cancel = true;
                }
                else
                {
                    e.Row.Cells["ObjectName"].ErrorText = "";
                }
            }
        }

        private void mebRewardAmount_Validating(object sender, CancelEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.JudicalWorkWinned)
                return;
            if (_fixation.StageStatus >= (int)FixationStageStatuses.ClosedAgreedBeforeFixation)
                return;

            if (string.IsNullOrEmpty(mebRewardAmount.Text))
            {
                errorProvider.SetError(mebRewardAmount, "Сума винагороди є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(mebRewardAmount, "");
        }

        private void mebCourtFeeAmount_Validating(object sender, CancelEventArgs e)
        {
            if (_fixation.StageStatus < (int)FixationStageStatuses.JudicalWorkWinned)
                return;

            if (_fixation.StageStatus >= (int)FixationStageStatuses.ClosedAgreedBeforeFixation)
                return;

            if (string.IsNullOrEmpty(mebCourtFeeAmount.Text))
            {
                errorProvider.SetError(mebCourtFeeAmount, "Сума судового збору є обов'язковим полем.");
                e.Cancel = true;
            }
            else
                errorProvider.SetError(mebCourtFeeAmount, "");
        }

        #endregion

        private void ShowAllowedPages()
        {
            var fixationVisibility = 
                _fixation.StageStatus >= (int)FixationStageStatuses.FixationNotScheduled ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            var identificatioVisibility =
                _fixation.StageStatus >= (int)FixationStageStatuses.FixationFixationCompleted ? ElementVisibility.Visible : ElementVisibility.Collapsed;

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

        private void SetUpPrintButton()
        {
            sbPrint.Visible = _fixation.StageStatus >= (int)FixationStageStatuses.FixationScheduled;

            miPrintSlugbova.Visibility = 
                _fixation.StageStatus >= (int)FixationStageStatuses.NegotiationAfterFixationRejected ? ElementVisibility.Visible : ElementVisibility.Collapsed;

            miPrintActIdentyfikacii.Visibility =
                _fixation.StageStatus >= (int)FixationStageStatuses.NegotiationAfterFixationOnNegotioation ? ElementVisibility.Visible : ElementVisibility.Collapsed;
        }

        private void SetUpIdentificationPage()
        {
            if (_fixation.StageStatus == (int)FixationStageStatuses.FixationFixationCompleted ||
                _fixation.StageStatus == (int)FixationStageStatuses.RightholderIdentificationOnCorrection)
            {
                ctrlRegisterItemList.ShowFilters = false;
                ctrlRegisterItemList.ShowObjectInfo = false;
                ctrlRegisterItemList.AllowEditList = true;
                ctrlRegisterItemList.AllowShowObjectCommand = false;
                ctrlRegisterItemList.AllowLinkCommand = false;
                ctrlRegisterItemList.AllowUnlinkCommand = false;
                ctrlRegisterItemList.AllowFindCommand = false;
                gboxSearch.Visible = false;
            }
            else if (_fixation.StageStatus == (int)FixationStageStatuses.RightholderIdentificationOnIdentification)
            {
                ctrlRegisterItemList.ShowFilters = true;
                ctrlRegisterItemList.ShowObjectInfo = true;
                ctrlRegisterItemList.AllowEditList = true;
                ctrlRegisterItemList.AllowShowObjectCommand = true;
                ctrlRegisterItemList.AllowLinkCommand = true;
                ctrlRegisterItemList.AllowUnlinkCommand = true;
                ctrlRegisterItemList.AllowFindCommand = true;
                gboxSearch.Visible = true;
            }
            else
            {
                ctrlRegisterItemList.ShowFilters = false;
                ctrlRegisterItemList.ShowObjectInfo = true;
                ctrlRegisterItemList.AllowEditList = false;
                ctrlRegisterItemList.AllowShowObjectCommand = true;
                ctrlRegisterItemList.AllowLinkCommand = false;
                ctrlRegisterItemList.AllowUnlinkCommand = false;
                ctrlRegisterItemList.AllowFindCommand = false;
                gboxSearch.Visible = false;
            }

            // Для закритого статусу прячемо кнопку "Delete"
            if (_fixation.StageStatus >= (int)FixationStageStatuses.ClosedAgreedBeforeFixation)
                ctrlRegisterItemList.AllowShowDeleteCommand = false;

        }

        private static void CreateControls(Control control)
        {
            CreateControl(control);
            foreach (Control subcontrol in control.Controls)
            {
                CreateControl(subcontrol);
            }
        }

        private static void CreateControl(Control control)
        {
            var method = control.GetType().GetMethod("CreateControl", BindingFlags.Instance | BindingFlags.NonPublic);
            var parameters = method.GetParameters();

            method.Invoke(control, new object[] { true });
        }
    }
}
