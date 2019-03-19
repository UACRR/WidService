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
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAddAutorForm : RadForm
    {
        private const string LimitationOfRightsQuestion = "Обмеження прав належить іншому товариству! Змінити обмеження?";
        private const string ExceptionMsg = "Ідентифікатор 'CustId' не може бути NULL!";

        private readonly List<CopyrightKind> _copyrightKinds;
        private List<RightLimitationsView> _rightLimitationsViews;
        private readonly List<CommunityInfo> _communities;
        private readonly List<CommunityAutorsListView> _autorList;
        private readonly int _communityCustId;

        public List<CustCmRight> LimitRights { get; } = new List<CustCmRight>();
        public CommunityAutorsListView CurrentRow { get; set; }
        public int AuthorId { get; private set; }

        public event GetCommunityRightList GetCommunityRightList;

        public CommunityAddAutorForm(List<CommunityAutorsListView> autorList, int communityCustId)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            btnSave.Enabled = false;

            if (IpsGlobal.AnketaDictionaties != null)
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
            if (CurrentRow == null)
                return;
            
            var currentRow = gvViewAutors.Rows
                .SingleOrDefault(rec => rec.DataBoundItem is CommunityAutorsListView item 
                                        && item.CustId == CurrentRow.CustId
                                        && item.CmCustId == CurrentRow.CmCustId);
            if (currentRow != null)
            {
                gvViewAutors.CurrentRow = currentRow;
                gvViewAutors.GridViewElement.TableElement.ScrollToRow(gvViewAutors.CurrentRow);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AuthorId = (gvViewAutors.CurrentRow.DataBoundItem as CommunityAutorsListView)?.CustId ?? 0;
            DialogResult = DialogResult.OK;
        }

        private void EnableEditMode()
        {
            btnSave.Enabled = true;
            ctrlSearch.Enabled = false;
            gvViewAutors.Enabled = false;
        }

        // зміна рядка автора
        private void gvViewAutors_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow?.DataBoundItem is CommunityAutorsListView item)
                gvRightLimitations.DataSource = DataSource(item);
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
            {
                LimitRights.Clear();
                LimitRights.AddRange(items);
            }

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
            if (!(gvRightLimitations.CurrentRow.DataBoundItem is RightLimitationsView row) || string.IsNullOrEmpty(row.CommunityName) || row.Check || row.CmCustId == _communityCustId)
            {
                ChangeRightLimitList((bool) e.NewValue);
                return;
            }

            if (MessageShow.ConfirmAction(LimitationOfRightsQuestion) == DialogResult.Yes)
                ChangeRightLimitList((bool) e.NewValue);
            else
                e.Cancel = true;
        }

        private void ChangeRightLimitList(bool action)
        {
            if (!(gvRightLimitations.CurrentRow.DataBoundItem is RightLimitationsView currentRow))
                throw new ArgumentNullException(ExceptionMsg);

            EnableEditMode();

            if (action)
            {
                LimitRights.Add(new CustCmRight
                {
                    CustId = currentRow.CustId,
                    CRkindCode = currentRow.KindCode,
                    CmCustId = currentRow.CmCustId ?? 0,
                    DateBegin = currentRow.DateBegin ?? DateTime.Today,
                    DateEnd = currentRow.DateEnd ?? new DateTime(3000, 1, 1)
                });
            }
            else
            {
                var item = LimitRights.SingleOrDefault(r => r.CustId == currentRow.CustId && r.CRkindCode == currentRow.KindCode);
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
