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
        private readonly List<CommunityInfo> _communities;
        private List<CommunityAutorsListView> _autorList;
        private readonly int _communityCustId;

        public List<CustCmRight> LimitRights { get; private set; } = new List<CustCmRight>();

        public event GetCommunityRightList GetCommunityRightList;

        public CommunityAddAutorForm(List<CommunityAutorsListView> autorList, int communityCustId)
        {
            InitializeComponent();
            if (!IsDesignMode)
            {
                _copyrightKinds = IpsGlobal.AnketaDictionaties.copyrightKind.ToList();
                _communities = IpsGlobal.AnketaDictionaties.communities.ToList();
            }
            ctrlSearch.SetUsageGrid(gvViewAutors);
            _communityCustId = communityCustId;
            _autorList = autorList;
            Load += CommunityAddAutorForm_Load;
        }

        private void CommunityAddAutorForm_Load(object sender, EventArgs e)
        {
            gvViewAutors.DataSource = _autorList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        // зміна рядка автора
        private void gvViewAutors_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e?.CurrentRow?.DataBoundItem is CommunityAutorsListView item)
            {
                gvRightLimitations.DataSource = DataSource(item);
            }
            else
                gvRightLimitations.DataSource = null;
        }

        // оновлення даних
        private List<RightLimitationsView> DataSource(CommunityAutorsListView cmnt)
        {
            _rightLimitationsViews = new List<RightLimitationsView>();
            var rightList = GetCommunityRightList?.Invoke(cmnt.CustId);
            var items = rightList?.Where(rec => rec?.CmCustId == _communityCustId).ToList();
            if(items != null)
                LimitRights.AddRange(items);

            foreach (var kind in _copyrightKinds)
            {
                var right = rightList?.SingleOrDefault(rec => rec.CRkindCode == kind.CodeI);
                _rightLimitationsViews.Add(new RightLimitationsView
                {
                    CustId = cmnt.CustId,
                    CmCustId = right?.CmCustId,
                    KindCode = kind.CodeI,
                    KindName = kind.Name,
                    CommunityName = _communities.SingleOrDefault(rec => rec?.CustId == right?.CmCustId)?.Name,
                    Check = right?.CmCustId == _communityCustId,
                    DateBegin = right?.DateBegin ?? DateTime.Today,
                    DateEnd = right?.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }
            return _rightLimitationsViews;
        }

        private void gvRightLimitations_ValueChanging(object sender, ValueChangingEventArgs e)
        {
            if (!(gvRightLimitations.CurrentRow.DataBoundItem is RightLimitationsView row) ||string.IsNullOrEmpty(row.CommunityName) || row.Check || row.CmCustId == _communityCustId)
            {
                ChangeRightLimitList((bool)e.NewValue);
                return;
            }

            if (MessageBox.Show("Обмеження прав належить іншій спільноті! Змінити обмеження?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ChangeRightLimitList((bool) e.NewValue);
            }
            else
                e.Cancel = true;
        }

        private void gvRightLimitations_ValueChanged(object sender, EventArgs e)
        {
            var currentRow = gvRightLimitations.CurrentRow;
            gvRightLimitations.MasterTemplate.Refresh();
            gvRightLimitations.GridViewElement.TableElement.ScrollToRow(currentRow);
        }

        private void ChangeRightLimitList(bool action)
        {
            var curRow = gvRightLimitations.CurrentRow.DataBoundItem as RightLimitationsView;
            if (action)
            {
                LimitRights.Add(new CustCmRight
                {
                    CustId = curRow?.CustId ?? throw new ArgumentNullException("Ідентифікатор 'CustId' не може бути NULL!"),
                    CRkindCode = curRow.KindCode,
                    CmCustId = curRow?.CmCustId ?? 0,
                    DateBegin = curRow.DateBegin ?? DateTime.Today,
                    DateEnd = curRow.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }
            else
            {
                var item = LimitRights.SingleOrDefault(r => r.CustId == curRow.CustId && r.CRkindCode == curRow.KindCode);
                LimitRights.Remove(item);
            }
        }
    }

    public class RightLimitationsView
    {
        public int CustId { get; set; }
        public int? CmCustId { get; set; }
        public int KindCode { get; set; }
        public string KindName { get; set; }
        public bool Check { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string CommunityName { get; set; }
    }
    
}
