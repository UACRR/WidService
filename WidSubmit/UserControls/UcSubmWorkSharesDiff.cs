using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static WidSubmit.UcSubmWorkSharesDiff;

namespace WidSubmit
{
    public partial class UcSubmWorkSharesDiff : UserControl
    {
        public enum ChangeType
        {
              IDENTICAL
            , CREATED
            , UPDATED
            , DELETED
        }

        public enum StatusImageIndex
        {
	          CURRENT
	        , IN_PROGRESS
	        , COMPLETE
	        , FAILED
	        , PENDING
       }

        public class Share
        {
            public int      SubmWorkId       { get; set; }
            public int      RightHolderId    { get; set; }
            public int      RhCustId         { get; set; }
            public string   RhIpBaseNr       { get; set; }
            public int?     RhIpNameNr       { get; set; }
            public string   RhName           { get; set; }
            public string   RhNameForWid     { get; set; }
            public string   RhTypeName       { get; set; }
            public string   RhRoleName       { get; set; }
            public string   RhRoleForWid     { get; set; }
            public bool     RhIsOwn          { get; set; }
            public bool     RhIsActive       { get; set; }
            public decimal  RhShrPer         { get; set; }
            public decimal  RhShrMec         { get; set; }
        }

        public class ShareDiff
        {
            public int        CustId       { get; set; }
            public string     CustName     { get; set; }
            public Share      CurShare     { get; set; }
            public Share      PrevShare    { get; set; }
            public ChangeType ChangeType   { get; set; }
        }

        private static readonly Font SubTitleFont = new Font(FontFamily.GenericSansSerif, (float)7, FontStyle.Bold);
        private int  _curSubmWorkId;
        private int? _prevSubmWorkId;
        
        private string _curName;
        private string _prevName;

        private List<ShareDiff> _shareDiff;
        private bool _isDirty;

        public UcSubmWorkSharesDiff()
        {
            InitializeComponent();
            _isDirty = true;
        }

        private void UcSubmWorkShares_Load(object sender, EventArgs e)
        {
            Configure();
        }

        public void ClearContent()
        {
            lvNameDiff.Items.Clear();
            lvShareDiff.Items.Clear();

            _isDirty = true;
        }

        public void UpdateContent(int curSubmWorkId)
        {
            _curSubmWorkId = curSubmWorkId;

            if(!_isDirty) return;

            ClearContent();
            LoadPrevSubmWorkId();
            LoadNames();
            FillLvNames();
            LoadShares();
            FillLvShareDiff();
            
            _isDirty = false;
        }

        private void Configure()
        {
            lvNameDiff.FullRowSelect = true;
            lvNameDiff.GridLines = true;
            lvNameDiff.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvNameDiff.MultiSelect = false;
            lvNameDiff.View = View.Details;
            lvNameDiff.SmallImageList = ilChangeType;
            
            lvNameDiff.Columns.Clear();
            lvNameDiff.Columns.Add("Попередня назва" , 300);
            lvNameDiff.Columns.Add("Нова назва"      , 300);
            
            
            lvShareDiff.FullRowSelect = true;
            lvShareDiff.GridLines = true;
            lvShareDiff.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvShareDiff.MultiSelect = false;
            lvShareDiff.View = View.Details;
            lvShareDiff.SmallImageList = ilChangeType;
           
            lvShareDiff.Columns.Clear();
            lvShareDiff.Columns.Add("Код СМАРТ"        , 100);
            lvShareDiff.Columns.Add("Назва СМАРТ"      , 150);
            lvShareDiff.Columns.Add("Міжнародний код"  , 100);
            lvShareDiff.Columns.Add("Код назви"        , 100);
            lvShareDiff.Columns.Add("Тип в СМАРТ"      , 120);
            lvShareDiff.Columns.Add("Роль в СМАРТ"     , 100);
            lvShareDiff.Columns.Add("Пуб %"            , 50);
            lvShareDiff.Columns.Add("Мех %"            , 50);

         }

        private bool CompareShares(Share source, Share target)
        {
            if(
                source.RhIpBaseNr == target.RhIpBaseNr  &&
                source.RhIpNameNr == target.RhIpNameNr  &&
                source.RhTypeName == target.RhTypeName  &&
                source.RhRoleName == target.RhRoleName  &&
                source.RhShrPer   == target.RhShrPer    &&
                source.RhShrMec   == target.RhShrMec
            )
                return true;
            else
            {
                return false;
            }
        }

        private void UpdateChangeType(ShareDiff sd)
        {
            if      (sd.CurShare == null)                       sd.ChangeType = ChangeType.DELETED;
            else if (sd.PrevShare == null)                      sd.ChangeType = ChangeType.CREATED;
            else if (CompareShares(sd.CurShare, sd.PrevShare))  sd.ChangeType = ChangeType.IDENTICAL;
            else                                                sd.ChangeType = ChangeType.UPDATED;
        }

        private void LoadNames()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"select NameForWid from SubmWork where Id = @submWorkId";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submWorkId", _curSubmWorkId);
                _curName = (string)cmd.ExecuteScalar();

                if(_prevSubmWorkId != null)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@submWorkId", _prevSubmWorkId);
                    _prevName = (string)cmd.ExecuteScalar();
                }
                else
                {
                    _prevName = "";
                }
            });
        }

        private void LoadPrevSubmWorkId()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select dbo.fnPrevSubmWorkId(@submWorkId)";
                cmd.Parameters.AddWithValue("@submWorkId", _curSubmWorkId);
                var res = cmd.ExecuteScalar();
                _prevSubmWorkId = res == DBNull.Value ? null : (int?)cmd.ExecuteScalar();
            });
        }

        private void LoadShares()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"spSelectSubmWorkShareDiff";
                cmd.Parameters.AddWithValue("@submWorkId", _curSubmWorkId);
                using (var r = cmd.ExecuteReader())
                {
                    _shareDiff = new List<ShareDiff>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var shareDiff = new ShareDiff();
                        if (!r.IsDBNull(idx))
                        {
                            shareDiff.CustId = r.GetInt32(2);
                            shareDiff.CustName = r.GetString(5);
                            var share = new Share();
                            share.SubmWorkId    = r.GetInt32(idx);                                  idx++;
                            share.RightHolderId = r.GetInt32(idx);                                  idx++;
                            share.RhCustId      = r.GetInt32(idx);                                  idx++;
                            share.RhIpBaseNr    = r.IsDBNull(idx) ? "" : r.GetString(idx);          idx++;
                            share.RhIpNameNr    = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);   idx++;
                            share.RhName        = r.GetString(idx);                                 idx++;
                            share.RhNameForWid  = r.GetString(idx);                                 idx++;
                            share.RhTypeName    = r.GetString(idx);                                 idx++;
                            share.RhRoleName    = r.GetString(idx);                                 idx++;
                            share.RhRoleForWid  = r.GetString(idx);                                 idx++;
                            share.RhIsOwn       = r.GetBoolean(idx);                                idx++;
                            share.RhIsActive    = r.GetBoolean(idx);                                idx++;
                            share.RhShrPer      = r.GetDecimal(idx);                                idx++;
                            share.RhShrMec      = r.GetDecimal(idx);                                idx++;

                            shareDiff.CurShare = share;
                        }

                        idx = 14;
                        if (!r.IsDBNull(idx))
                        {
                            if(shareDiff.CustId == 0)
                            {
                                shareDiff.CustId = r.GetInt32(idx + 2);
                                shareDiff.CustName = r.GetString(idx + 5);
                            }
                            var share = new Share();
                            share.SubmWorkId    = r.GetInt32(idx);                                  idx++;
                            share.RightHolderId = r.GetInt32(idx);                                  idx++;
                            share.RhCustId      = r.GetInt32(idx);                                  idx++;
                            share.RhIpBaseNr    = r.IsDBNull(idx) ? "" : r.GetString(idx);          idx++;
                            share.RhIpNameNr    = r.IsDBNull(idx) ? (int?)null : r.GetInt32(idx);   idx++;
                            share.RhName        = r.GetString(idx);                                 idx++;
                            share.RhNameForWid  = r.GetString(idx);                                 idx++;
                            share.RhTypeName    = r.GetString(idx);                                 idx++;
                            share.RhRoleName    = r.GetString(idx);                                 idx++;
                            share.RhRoleForWid  = r.GetString(idx);                                 idx++;
                            share.RhIsOwn       = r.GetBoolean(idx);                                idx++;
                            share.RhIsActive    = r.GetBoolean(idx);                                idx++;
                            share.RhShrPer      = r.GetDecimal(idx);                                idx++;
                            share.RhShrMec      = r.GetDecimal(idx);                                idx++;

                            shareDiff.PrevShare = share;
                        }

                        UpdateChangeType(shareDiff);
                        _shareDiff.Add(shareDiff);
                    }
                }
            });

            _shareDiff = _shareDiff.OrderBy(x => x.CustName).ToList();
        }
    
        private void FillLvNames()
        {
            lvNameDiff.Items.Clear();
            var item = new ListViewItem(_prevName);
            item.SubItems.Add(_curName);
            item.ImageIndex = _prevName == _curName ? 0 : 2;
            lvNameDiff.Items.Add(item);
        }

        private void AddShareDiffItems(ShareDiff shareDiff)
        {
            var share = shareDiff.CurShare == null ? shareDiff.PrevShare : shareDiff.CurShare;
            var item = new ListViewItem(share.RhCustId.ToString());
            item.SubItems.Add(share.RhName);
            item.SubItems.Add(share.RhIpBaseNr); 
            item.SubItems.Add(share.RhIpNameNr.ToString());
            item.SubItems.Add(share.RhTypeName);
            item.SubItems.Add(share.RhRoleName);
            item.SubItems.Add(share.RhShrPer.ToString());
            item.SubItems.Add(share.RhShrMec.ToString());

            item.ImageIndex = (int)shareDiff.ChangeType;

            lvShareDiff.Items.Add(item);

            if(shareDiff.ChangeType == ChangeType.UPDATED)
            {
                var itemDiff = new ListViewItem("");
                itemDiff.SubItems.Add("");
                itemDiff.SubItems.Add(""); 
                itemDiff.SubItems.Add("");
                itemDiff.SubItems.Add("");
                itemDiff.SubItems.Add("");
                itemDiff.SubItems.Add(shareDiff.CurShare.RhShrPer != shareDiff.PrevShare.RhShrPer ? shareDiff.PrevShare.RhShrPer.ToString() : "");
                itemDiff.SubItems.Add(shareDiff.CurShare.RhShrMec != shareDiff.PrevShare.RhShrMec ? shareDiff.PrevShare.RhShrMec.ToString() : "");

                itemDiff.ImageIndex = -1;
                itemDiff.ForeColor = System.Drawing.Color.Red;

                lvShareDiff.Items.Add(itemDiff);
            }
        }

        private void FillLvShareDiff()
        {
            lvShareDiff.Items.Clear();
            _shareDiff.ForEach(shareDiff => {
                AddShareDiffItems(shareDiff);
            });
        }

        private void lvSubmWorkShares_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvShareDiff);
        }

        private void lvNameDiff_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.Selected = false;
            }
        }

        private void lvShareDiff_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                e.Item.Selected = false;
            }
        }
    }
}
