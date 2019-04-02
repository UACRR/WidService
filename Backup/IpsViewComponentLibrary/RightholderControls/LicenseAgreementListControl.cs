using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.ObjectRightControls;
using IpsViewComponentLibrary.Shared.Forms;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class LicenseAgreementListControl : UserControl
    {
        private RequestsOrReferenceBigRightView _licenseAgreement;

        private readonly LicenseDataService _licenseDataService;
        private readonly DialogService _dialogService;
        private readonly AgreementStatuses[] _allowedStatuses =
        {
            AgreementStatuses.Active,
            AgreementStatuses.OnNegotiation,
            AgreementStatuses.Closed,
            AgreementStatuses.Canceled
        };

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public LicenseAgreementListControl()
        {
            InitializeComponent();

            gvLicenseAgreementList.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);
            gvLicenseAgreementList.SetCommandColumnImageAlignment("ShowObjectColumn", ContentAlignment.MiddleCenter);

            if (!IsDesignMode)
            {
                _licenseDataService = new LicenseDataService();
                _dialogService = new DialogService();
            }
        }

        public RequestsOrReferenceBigRightView SelectedLicenseAgreement
        {
            get => gvLicenseAgreementList.CurrentRow?.DataBoundItem as RequestsOrReferenceBigRightView;
            set
            {
                if (_licenseAgreement != value)
                {
                    _licenseAgreement = value;

                    if (_licenseAgreement != null)
                    {
                        var row = gvLicenseAgreementList.Rows.FirstOrDefault(r => (int)r.Cells["LicId"].Value == _licenseAgreement.LicId);
                        if (row != null)
                        {
                            gvLicenseAgreementList.CurrentRow = row;
                            gvLicenseAgreementList.TableElement.ScrollToRow(row);
                        }
                    }
                }
            }
        }

        public void UpdateList()
        {
            UpdateList(SelectedLicenseAgreement);
        }

        public void UpdateList(RequestsOrReferenceBigRightView currentRightholder)
        {
            var States = chddlState.CheckedItems.Select(item => (LicenseTypes)item.Value);

            var query = new LicenseAgreementQuery(); 

            if (chddlState.CheckedItems.Any())
                query.States = chddlState.CheckedItems.Select(item => (LicenseTypes)item.Value).ToList();

            if (ddlStatus.SelectedValue != null && (int)ddlStatus.SelectedValue != -1)
                query.Status = (AgreementStatuses)ddlStatus.SelectedValue;

            var list = _licenseDataService.GetLicenseAgreements(query);
            bsBigRightRequests.DataSource = list;
            //show count Agreements into grid
            lblCountAgreements.Text = list.Count.ToString();

            SelectedLicenseAgreement = currentRightholder;
        }

        private void LicenseAgreementListControl_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode)
            {
                SetDictionaries();

                UpdateList();
            }
        }

        private void chddlState_PopupClosed(object sender, RadPopupClosedEventArgs args)
        {
            UpdateList();
        }

        private void ddlStatus_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void gvLicenseAgreementList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                EditLicenseAgreement(SelectedLicenseAgreement);
            }
            else if (currentColumnName == "ShowObjectColumn")
            {
                ShowObject(SelectedLicenseAgreement);
            }
        }

        private void gvLicenseAgreementList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            EditLicenseAgreement(SelectedLicenseAgreement);
        }

        private void gvLicenseAgreementList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void SetDictionaries()
        {
            chddlState.ValueMember = "CodeI";
            chddlState.DisplayMember = "Name";

            int[] validTypes = { 1,2,3 };
            chddlState.DataSource = IpsGlobal.AnketaDictionaties.licenseType.Where(rec => validTypes.Contains( rec.CodeI ));

            foreach (var item in chddlState.Items)
            {
                var state = (LicenseTypes)item.Value;
                if (state == LicenseTypes.Bid || state == LicenseTypes.Notice)
                    ((RadCheckedListDataItem)item).Checked = true;
            }

            ddlStatus.SelectedValueChanged -= ddlStatus_SelectedValueChanged;
            var statuses = IpsGlobal.AnketaDictionaties.agreementStatus.Where(s => _allowedStatuses.Contains((AgreementStatuses)s.CodeI)).ToList();
            statuses.Insert(0, new AgreementStatus { CodeI = -1, Name = "Всі" });
            ddlStatus.SetDataSource(statuses);
            ddlStatus.SelectedValue = (int)AgreementStatuses.OnNegotiation;
            ddlStatus.SelectedValueChanged += ddlStatus_SelectedValueChanged;
        }

        private void ShowObject(RequestsOrReferenceBigRightView selectedLicenseAgreement)
        {
            if (selectedLicenseAgreement.Objid.HasValue)
            {
                using (var view = new ObjectRightBrView())
                {
                    var presenter = new ObjectRightBrPresenter(view);
                    presenter.Show(selectedLicenseAgreement.Objid.Value);
                }
            }
        }

        private void EditLicenseAgreement(RequestsOrReferenceBigRightView selectedLicenseAgreement)
        {
            if (!selectedLicenseAgreement.CustId.HasValue)
                return;

            var consumerService = new ConsumerService();

            var consumer = consumerService.GetData(selectedLicenseAgreement.CustId.Value);
            var bigRightView = consumerService.getMainViewBR().FirstOrDefault(rec => rec.CustId == selectedLicenseAgreement.CustId.Value);

            var view = new RequestForm(consumer, bigRightView, ScopeOfUseForm.Edit, selectedLicenseAgreement.LicId, RequestForm.FormMode.ForSmallRightAdmin);

            if (view.ShowDialog() == DialogResult.OK)
            {
                var result = consumerService.Save(consumer);

                if (result)
                {
                    UpdateList();
                }
                else
                {
                    _dialogService.ShowError("Не вдалося зберегти зміни.");
                }
            }
        }

        #region Search rightolder

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvLicenseAgreementList.MasterTemplate.Refresh();
        }

        private void gvLicenseAgreementList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvLicenseAgreementList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvLicenseAgreementList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvLicenseAgreementList.EndUpdate(false);
                return;
            }

            gvLicenseAgreementList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvLicenseAgreementList.ColumnCount; i++)
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
                gvLicenseAgreementList.EndUpdate(false);
            }
        }

        #endregion
    }
}
