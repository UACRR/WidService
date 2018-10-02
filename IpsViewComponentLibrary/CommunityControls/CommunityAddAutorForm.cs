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
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAddAutorForm : Telerik.WinControls.UI.RadForm
    {
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        private readonly List<CopyrightKind> _copyrightKinds = null;
        private List<RightLimitationsView> _rightLimitationsViews = null;
        private List<CommunityInfo> _communities;

        public event GetCommunityRightList GetCommunityRightList;

        public CommunityAddAutorForm(List<CommunityAutorsListView> autorList)
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewAutors);
            gvViewAutors.DataSource = autorList;
            if (!IsDesignMode)
            {
                _copyrightKinds = IpsGlobal.AnketaDictionaties.copyrightKind.ToList();
                _communities = IpsGlobal.AnketaDictionaties.communities.ToList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void gvViewAutors_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e?.CurrentRow?.DataBoundItem is CommunityAutorsListView item)
            {
                gvRightLimitations.DataSource = DataSource(item);
            }
            else
                gvRightLimitations.DataSource = null;
        }

        private List<RightLimitationsView> DataSource(CommunityAutorsListView cmnt)
        {
            _rightLimitationsViews = new List<RightLimitationsView>();
            var rightList = GetCommunityRightList?.Invoke(cmnt.CustId);

            foreach (var kind in _copyrightKinds)
            {
                var right = rightList?.SingleOrDefault(rec => rec.CRkindCode == kind.CodeI);
                _rightLimitationsViews.Add(new RightLimitationsView
                {
                    CustId = cmnt.CustId,
                    CmCustId = right?.CmCustId,
                    KindCode = kind.CodeI,
                    KindName = kind.Name,
                    CommunityName = _communities.SingleOrDefault(rec => rec?.CustId == right?.CustId)?.Name,
                    Check = right != null,
                    DateBegin = right?.DateBegin ?? DateTime.Today,
                    DateEnd = right?.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }

            return _rightLimitationsViews;
        }
    }

    public class RightLimitationsView
    {
        public int CustId { get; set; }
        public int? CmCustId { get; set; }
        public int KindCode { get; set; }
        public string KindName { get; set; }
        public bool? Check { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string CommunityName { get; set; }
    }
    
}
