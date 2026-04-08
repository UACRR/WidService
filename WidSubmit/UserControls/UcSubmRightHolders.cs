using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WidSubmit.UcSubmRightHolders;

namespace WidSubmit
{
    public partial class UcSubmRightHolders : UserControl
    {
        public class RightHolderSelectedEventArgs : EventArgs
        {
            public RightHolder RightHolder { get; }
            public RightHolderSelectedEventArgs(RightHolder rightHolder)
            {
                RightHolder = rightHolder;
            }
        }

        public enum PresentationMode
        {
            CUR_SUBM,
            PREV_SUBM,
            RIGHTHOLDER_SELECT,
        }

        public class RightHolder
        {
	        public int Id			    { get; set; }
	        public DateTime ValidFrom	{ get; set; }
	        public DateTime ValidTo		{ get; set; }
	        public DateTime CreatedAt	{ get; set; }
	        public int CustId		    { get; set; }
	        public string IpBaseNr		{ get; set; }
	        public int? IpNameNr		{ get; set; }
	        public string Name	        { get; set; }
            public string FstName	    { get; set; }
            public string NameForWid	{ get; set; }
            public string FstNameForWid	{ get; set; }
            public bool IsOwn		    { get; set; }
	        public bool IsActive		{ get; set; }
            public bool HasIpiAgreePer	{ get; set; }
            public bool HasIpiAgreeMec	{ get; set; }
            public bool IsInCurSubm	    { get; set; }
            public bool WasPublished	{ get; set; }
        }
        
        private List<RightHolder>   _rightHolders;
        private int _submissionId;

        // Робоча інформація
        private RightHolder _rightHolderSelected;
        private bool _ignoreControlEvents;
        private bool _rightHoldersEmpty;

        // Налаштування
        private PresentationMode _presentationMode;
        private bool _showExFilter;
        private bool _showEditRightHoldersButton;
        private bool _showAllRightHoldersItem;
        private  string _titleText;

        public event EventHandler<RightHolderSelectedEventArgs> RightHolderSelected;
        public event EventHandler RightHolderUnselected;
        public event EventHandler EditRightHoldersClicked;


        public UcSubmRightHolders()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | 
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint, true);
        }

        private void UcSubmRightHolders_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            timerSelChangedHandler.Enabled = false;
            timerInvokeRighHolderSelected.Enabled = false;
            timerInvokeRightHoldersEmpty.Enabled = false;

            labTitle.Text = _titleText;

            lvRightHolders.FullRowSelect = true;
            lvRightHolders.GridLines = true;
            lvRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolders.MultiSelect = false;
            lvRightHolders.View = View.Details;
            lvRightHolders.SmallImageList = ilSubmWorkStatuses;
            lvRightHolders.StateImageList = ilSubmWorkStatuses;

            lvRightHolders.Columns.Clear();
            lvRightHolders.Columns.Add("", 40);
            lvRightHolders.Columns.Add("№", 40);
            lvRightHolders.Columns.Add("Код СМАРТ", 80);
            lvRightHolders.Columns.Add("Назва СМАРТ", 200);

            panelRightHolders.RowStyles[3].Height = _showExFilter ? 23 : 0;
            panelRightHolders.RowStyles[4].Height = _showExFilter ? 28 : 0;
            panelRightHolders.RowStyles[8].Height = _showEditRightHoldersButton ? 30 : 0;
        }
        
        public void Init(PresentationMode presentationMode) 
        {
            _presentationMode = presentationMode;
            switch(_presentationMode)
            {
                case PresentationMode.CUR_SUBM:
                    _showExFilter = false;
                    _showEditRightHoldersButton = true;
                    _showAllRightHoldersItem = true;
                    _titleText = "Правовласники сеансу";
                    break;
                case PresentationMode.PREV_SUBM:
                    _showExFilter = false;
                    _showEditRightHoldersButton = false;
                    _showAllRightHoldersItem = true;
                    _titleText = "Правовласники сеансу";
                    break;
                case PresentationMode.RIGHTHOLDER_SELECT:
                    _showExFilter = true;
                    _showEditRightHoldersButton = false;
                    _showAllRightHoldersItem = false;
                    _titleText = "Правовласники товариства";
                    break;
            }

            Configure();
        }

        public void UpdateContent(int submissionId = 0)
        {
            _submissionId = submissionId;
            _rightHoldersEmpty = false;
            LoadRightHolders();
            FillLvRightHolders();
         }

        public List<RightHolder> GetSubmRightHolders()
        {
            return _rightHolders.Where(x => x.IsInCurSubm).ToList();
        }

        public void UpdateRightHolderItem(RightHolder rightHolder)
        {
            var item = FindRightHolderItem(rightHolder);
            if(item != null)
            {
                item.StateImageIndex = rightHolder.IsInCurSubm ? 3 : -1;
            }
        }

        public void RemoveAllFromCurSubm()
        {
            _rightHolders.ForEach(x => x.IsInCurSubm = false);
            FillLvRightHolders();
        }

        public void AddShownToCurSubm()
        {
            foreach(ListViewItem item in lvRightHolders.Items)
            {
                var rh = (RightHolder)item.Tag;
                if(rh != null && rh.IsActive)
                {
                     rh.IsInCurSubm = true;
                }
            }
            FillLvRightHolders();
        }

        private ListViewItem FindRightHolderItem(RightHolder rightHolder)
        {
            foreach(ListViewItem item in lvRightHolders.Items)
            {
                if((RightHolder)item.Tag == rightHolder)
                {
                    return item;
                }
            }
            return null;
        }

        private void LoadRightHolders()
        {
            Helpers.RunProtected(() =>
            {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spSelectRightHoldersForCurSubm";
                    cmd.Parameters.AddWithValue("@submId", _submissionId);
                
                    using (var r = cmd.ExecuteReader())
                    {
                        _rightHolders = new List<RightHolder>();
                        while (r.Read())
                        {
                            var idx = 0;
                            var rh = new RightHolder();
	                        rh.Id		        = r.GetInt32(idx);                                  idx++;
	                        rh.ValidFrom	    = r.GetDateTime(idx);                               idx++;
	                        rh.ValidTo	        = r.GetDateTime(idx);                               idx++;
	                        rh.CreatedAt	    = r.GetDateTime(idx);                               idx++;
	                        rh.CustId	        = r.GetInt32(idx);                                  idx++;
	                        rh.IpBaseNr	        = r.IsDBNull(idx) ? null : r.GetString(idx);        idx++;
	                        rh.IpNameNr	        = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);   idx++;
	                        rh.Name             = r.GetString(idx);                                 idx++;
                            rh.FstName          = r.GetString(idx);                                 idx++;
                            rh.NameForWid       = r.GetString(idx);                                 idx++;
                            rh.FstNameForWid    = r.GetString(idx);                                 idx++;
                            rh.IsOwn	        = r.GetBoolean(idx);                                idx++;
	                        rh.IsActive	        = r.GetBoolean(idx);                                idx++;
                            rh.HasIpiAgreePer	= r.GetBoolean(idx);                                idx++;
                            rh.HasIpiAgreeMec	= r.GetBoolean(idx);                                idx++;
                            rh.IsInCurSubm	    = r.GetBoolean(idx);                                idx++;
                            rh.WasPublished	    = r.GetBoolean(idx);                                idx++;

                            _rightHolders.Add(rh);
                        }
                    }
                });

                _rightHolders = _rightHolders.OrderBy(rh => rh.Name).ThenBy(rh => rh.FstName).ToList();

                tbRightHolderCntTotal.Text = _rightHolders.Count.ToString();
 
            });
       }

        private bool ShowRightHolder(RightHolder rh)
        {
            if(rbRightHolderFilterActive   .Checked && !rh.IsActive) return false;
            if(rbRightHolderFilterNotActive.Checked &&  rh.IsActive) return false;
            
            if(!cbRightHolderFilterEx.Checked)
            {
                if(!rh.IsInCurSubm) return false;
            }
            else
            {
                if(rbRightHolderFilterOwn      .Checked && !rh.IsOwn)        return false;
                if(rbRightHolderFilterPublished.Checked && !rh.WasPublished) return false;
            }
 
            var cond = tbRightHolderFilter.Text.Trim();
            if (cond.Length == 0)                                             return true;
            if (rh.CustId.ToString().Contains(cond))                          return true;
            if (rh.IpBaseNr != null && rh.IpBaseNr.Contains(cond))            return true;
            if (rh.IpNameNr != null && rh.IpNameNr.ToString().Contains(cond)) return true;
            if (rh.Name.ToUpper().Contains(cond.ToUpper()))                   return true;
            if (rh.FstName.ToUpper().Contains(cond.ToUpper()))                return true;

            return false;
        }

        private void FillLvRightHolders()
        {
            _ignoreControlEvents = true;

            lvRightHolders.BeginUpdate();
            lvRightHolders.Items.Clear();
            
            var item = new ListViewItem("");
            if(_showAllRightHoldersItem)
            {
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("<Всі правовласники>");
                item.Tag = null;
                lvRightHolders.Items.Add(item);
            }

            var seqNr = 1;
            _rightHolders.ForEach(x =>
            {
                if (ShowRightHolder(x))
                {
                    item = new ListViewItem("");
                    item.SubItems.Add(seqNr.ToString());
                    item.SubItems.Add(x.CustId.ToString());
                    item.SubItems.Add($"{x.Name} {x.FstName}".Trim());
                    item.ImageIndex = x.IsActive ? -1 : 5;
                    item.StateImageIndex = x.IsInCurSubm ? 3 : -1;
                    if(!x.WasPublished) item.ForeColor = SystemColors.GrayText;
                    item.Tag = x;
                    if(_rightHolderSelected != null)
                    {
                        if(x.CustId == _rightHolderSelected.CustId)
                        {
                            item.Selected = true;
                        }
                    }
                    lvRightHolders.Items.Add(item);
                    seqNr++;
                }
            });
            lvRightHolders.EndUpdate();

            if(lvRightHolders.SelectedItems.Count == 0 && lvRightHolders.Items.Count > 0)
            {
                if(_showAllRightHoldersItem && lvRightHolders.Items.Count > 1)
                    lvRightHolders.Items[1].Selected = true;
                else
                    lvRightHolders.Items[0].Selected = true;
            }

            tbRightHolderCntSelected.Text = _showAllRightHoldersItem ?
                (lvRightHolders.Items.Count - 1).ToString() : lvRightHolders.Items.Count.ToString();

            // ПРИЗНАЧАЄМО ОПРАЦЮВАННЯ РЕЗУЛЬТАТУ
            timerSelChangedHandler.Enabled = true;


        }

        private void ApplyRightHolderFilter()
        {
            FillLvRightHolders();
        }

        private void btnApplyRightHolderFilter_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                ApplyRightHolderFilter();
            });
        }

        private void rbRightHolderFilterActive_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvRightHolders();
            });
        }

        private void rbRightHolderFilterNotActive_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvRightHolders();
            });
        }

        private void rbRightHolderFilterActiveNotActive_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvRightHolders();
            });
        }

        private void cbRightHolderFilterEx_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                rbRightHolderFilterOwn              .Enabled = cbRightHolderFilterEx.Checked;
                rbRightHolderFilterPublished        .Enabled = cbRightHolderFilterEx.Checked;
                FillLvRightHolders();
            });
        }

        private void rbRightHolderFilterOwn_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvRightHolders();
            });
        }

        private void rbRightHolderFilterPublished_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvRightHolders();
            });
        }

        private void lvRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ignoreControlEvents) return;

            _ignoreControlEvents = true;
            timerSelChangedHandler.Enabled = true;
        }

        private void btnChangeRightHolders_Click(object sender, EventArgs e)
        {
            EditRightHoldersClicked?.Invoke(this, new EventArgs()); 
        }

         private void timerSelChangedHandler_Tick(object sender, EventArgs e)
         {
            timerSelChangedHandler.Enabled = false;
            if (lvRightHolders.SelectedItems.Count > 0)
            {
                var item = lvRightHolders.SelectedItems[0];
                var rh = (RightHolder)item.Tag;
                item.EnsureVisible();
                if(
                    _rightHoldersEmpty           ||
                    _rightHolderSelected == null ||
                    rh == null                   ||                   
                    rh.CustId != _rightHolderSelected.CustId
                )
                {
                    _rightHolderSelected = (RightHolder)item.Tag;
                    // Викликаємо подію після перемалювання контролу
                    timerInvokeRighHolderSelected.Enabled = true;
                }
                _rightHoldersEmpty = false;
            }
            else
            {
                foreach(ListViewItem item in lvRightHolders.Items)
                {
                    var rh = (RightHolder)item.Tag;
                    if(rh != null && rh.CustId == _rightHolderSelected.CustId)
                    {
                        item.Selected = true;
                        item.EnsureVisible();
                        break;
                    }
                }
                if(lvRightHolders.SelectedItems.Count == 0)
                {
                    // Викликаємо подію після перемалювання контролу
                    timerInvokeRightHoldersEmpty.Enabled = true;
                }
                _rightHoldersEmpty = true;
            }

            _ignoreControlEvents = false;
        }

        private void timerInvokeRighHolderSelected_Tick(object sender, EventArgs e)
        {
            timerInvokeRighHolderSelected.Enabled = false;
            var item = lvRightHolders.SelectedItems[0];
            RightHolderSelected?.Invoke(this, new RightHolderSelectedEventArgs((RightHolder)item.Tag)); 
        }

        private void timerInvokeRightHoldersEmpty_Tick(object sender, EventArgs e)
        {
            timerInvokeRightHoldersEmpty.Enabled = false;
            RightHolderUnselected?.Invoke(this, new EventArgs());
        }

        private void lvRightHolders_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvRightHolders);
        }
    }
}
