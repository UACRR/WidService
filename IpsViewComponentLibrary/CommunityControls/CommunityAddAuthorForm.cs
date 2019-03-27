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
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAddAuthorForm : RadForm
    {
        private readonly int _communityCustId;

        public List<CustCmRight> LimitRights => ctrlRightLimitation.LimitRights;

        public int AuthorId { get; private set; }

        public event GetCommunityRightList GetCommunityRightList;

        public CommunityAddAuthorForm(List<CommunityAuthorsView> autorList, int communityCustId)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            btnSave.Enabled = false;

            ctrlRightLimitation.ValueEdit += CtrlRightLimitation_ValueEdit;
            ctrlSearch.SetUsageGrid(gvViewAutors);
            _communityCustId = communityCustId;
            bsCommunityAuthorsView.DataSource = autorList;
        }

        private void CtrlRightLimitation_ValueEdit(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            ctrlSearch.Enabled = false;
            gvViewAutors.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AuthorId = (gvViewAutors.CurrentRow.DataBoundItem as CommunityAuthorsView)?.CustId ?? 0;
            DialogResult = DialogResult.OK;
        }

        // зміна рядка автора
        private void gvViewAutors_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (!(e.CurrentRow?.DataBoundItem is CommunityAuthorsView item))
                return;

            var rightList = GetCommunityRightList?.Invoke(item.CustId);
            ctrlRightLimitation.SetData(item, rightList, _communityCustId);
        }
    }
}
