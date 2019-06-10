using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.CommunityControls.InternalModel;
using IpsViewComponentLibrary.CommunityControls.Presenters;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityLimitsAddForm : RadForm
    {
        private readonly CommunityViewsPresenter _presenter;
        private readonly int _communityCustId;

        public List<CustCmRight> LimitRights => ctrlRightLimitation.LimitRights;

        public int AuthorId { get; private set; }

        public event GetCommunityRightList GetCommunityRightList;

        protected new bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public CommunityLimitsAddForm(List<CommunityAuthorsView> autorList, int communityCustId)
        {
            InitializeComponent();
            if (!IsDesignMode)
                _presenter = new CommunityViewsPresenter();
            WindowState = FormWindowState.Maximized;
            parentGridPanel.PanelElement.PanelBorder.Width = 0f;
            ctrlSaveCancel.SaveButtonEnabled = false;
            ctrlSaveCancel.SaveClck += Save_Click;
            ctrlRightLimitation.ValueEdit += CtrlRightLimitation_ValueEdit;
            _communityCustId = communityCustId;
            bsCommunityAuthorsView.DataSource = autorList;
        }

        private void CtrlRightLimitation_ValueEdit(object sender, EventArgs e)
        {
            ctrlSaveCancel.SaveButtonEnabled = true;
            navigatorPanel.Enabled = false;
            txtSearch.Enabled = false;
            gvViewAutors.Enabled = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            AuthorId = (gvViewAutors.CurrentRow.DataBoundItem as CommunityAuthorsView)?.CustId ?? 0;
            //DialogResult = DialogResult.OK;
        }

        // зміна рядка автора
        private void gvViewAutors_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is CommunityAuthorsView item))
                return;

            var rightList = GetCommunityRightList?.Invoke(item.CustId);
            ctrlRightLimitation.SetData(item, rightList, _communityCustId);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void timerSearch_Tick(object sender, EventArgs e)
        {
            timerSearch.Stop();
            navigatorPanel.CurrentPage = 1;
        }

        private void navigatorPanel_CurrentPageChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void navigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        public async void UpdateList()
        {
            waitingBar.StartWaiting();

            var query = new PaginateAndSearchQuery();

            query.Page = navigatorPanel.CurrentPage;
            query.PageSize = navigatorPanel.PageSize;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                query.SearchText = txtSearch.Text;

            //var result = await _presenter.GetAllAutorsView(query2);
            var result = await _presenter.GetAllAutorsView(query);
            bsCommunityAuthorsView.DataSource = result.List.DistinctBy(rec => rec.CustId);

            navigatorPanel.TotalPages = (int)Math.Ceiling((double)result.TotalItems / (int)query.PageSize);

            waitingBar.StopWaiting();
        }

        public void UpdateTotalPages(double totalItems)
        {
            navigatorPanel.TotalPages = (int)Math.Ceiling(totalItems / navigatorPanel.PageSize);
        }
    }
}
