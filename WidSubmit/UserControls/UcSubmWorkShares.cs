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

namespace WidSubmit
{
    public partial class UcSubmWorkShares : UserControl
    {

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

        private static readonly Font SubTitleFont = new Font(FontFamily.GenericSansSerif, (float)7, FontStyle.Bold);
        private int _widSubmWorkId;

        private List<Share> _shares;
        private bool _isDirty;

        public UcSubmWorkShares()
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
            lvSubmWorkShares.Items.Clear();
            lvDetails.Items.Clear();

            _isDirty = true;
        }

        public void UpdateContent(int widSubmWorkId)
        {
            _widSubmWorkId = widSubmWorkId;

            if(!_isDirty) return;

            ClearContent();
            LoadShares();
            FillLvSubmWorkShares();

            _isDirty = false;
        }

        private void Configure()
        {
           lvSubmWorkShares.FullRowSelect = true;
           lvSubmWorkShares.GridLines = true;
           lvSubmWorkShares.HeaderStyle = ColumnHeaderStyle.None;
           lvSubmWorkShares.MultiSelect = false;
           lvSubmWorkShares.View = View.Details;
           
           lvSubmWorkShares.Columns.Clear();
           lvSubmWorkShares.Columns.Add("Код СМАРТ"     , 100);
           lvSubmWorkShares.Columns.Add("Назва СМАРТ"   , 150);
           lvSubmWorkShares.Columns.Add("Свій"          , 50);
           lvSubmWorkShares.Columns.Add("Роль WID"      , 70);
           lvSubmWorkShares.Columns.Add("Пуб %"         , 50);
           lvSubmWorkShares.Columns.Add("Мех %"         , 50);

           lvDetails.FullRowSelect = true;
           lvDetails.GridLines = true;
           lvDetails.HeaderStyle = ColumnHeaderStyle.None;
           lvDetails.MultiSelect = false;
           lvDetails.View = View.Details;
           
           lvDetails.Columns.Clear();
           lvDetails.Columns.Add("Назва параметра", 160);
           lvDetails.Columns.Add("Значення параметра", 200);

        }

        private void LoadShares()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select
                          SubmWorkId   
                        , RightHolderId
                        , RhCustId       
                        , RhIpBaseNr     
                        , RhIpNameNr     
                        , RhName      
                        , RhNameForWid
                        , RhTypeName     
                        , RhRoleName     
                        , RhRoleForWid   
                        , RhIsOwn        
                        , RhIsActive     
                        , RhShrPer       
                        , RhShrMec      
                    from vSubmWorkShares
                    where SubmWorkId = @submWorkId
                    order by RhName
                ";
                cmd.Parameters.AddWithValue("@submWorkId", _widSubmWorkId);
                using (var r = cmd.ExecuteReader())
                {
                    _shares = new List<Share>();
                    while (r.Read())
                    {
                        var idx = 0;
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

                        _shares.Add(share);
                    }
                }
            });
        }

        private int GetShareImageIndex(bool isOk)
        {
            return isOk ? -1 : (int)StatusImageIndex.FAILED;
        }

        private void AddSubmWorkShareTitleItem()
        {
            var item = new ListViewItem("Код СМАРТ");
            item.SubItems.Add("Назва СМАРТ");
            item.SubItems.Add("Свій"       );
            item.SubItems.Add("Роль WID"   );
            item.SubItems.Add("Пуб %"      );
            item.SubItems.Add("Мех %"      );
            item.Font = SubTitleFont;
            item.Tag = null;
            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareItem(Share share)
        {
            var isOk = share.RhRoleForWid != "" && share.RhIpBaseNr != "" && share.RhIpNameNr != null;
            var item = new ListViewItem(share.RhCustId.ToString());
            item.SubItems.Add(share.RhName);
            item.SubItems.Add(share.RhIsOwn ? "Так" : "Ні");
            item.SubItems.Add(share.RhRoleForWid);
            item.SubItems.Add(share.RhShrPer.ToString());
            item.SubItems.Add(share.RhShrMec.ToString());
            item.ImageIndex = GetShareImageIndex(isOk);
            item.Tag = share;
            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareEmptyItem()
        {
            var item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.Tag = null;
            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareSummaryTitleItem()
        {
            var item = new ListViewItem("Підсумок");
            item.SubItems.Add("Перевірка");
            item.SubItems.Add("Вірно");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.Font = SubTitleFont;
            item.Tag = null;
            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareTotalsItem()
        {
            var totalSharePer = _shares.Sum(x => x.RhShrPer);
            var totalShareMec = _shares.Sum(x => x.RhShrMec);
            var isOk = (totalSharePer== 0 || totalSharePer == 100) &&
                (totalShareMec== 0 || totalShareMec == 100);
            var item = new ListViewItem("");
            item.SubItems.Add("Сума процентів 0 або 100");
            item.SubItems.Add(isOk ? "Так" : "Ні");
            item.SubItems.Add("");
            item.SubItems.Add(totalSharePer.ToString());
            item.SubItems.Add(totalShareMec.ToString());
            item.ImageIndex = GetShareImageIndex(isOk);
            item.Tag = null;
            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareRolesDefinedItem()
        {
            var isOk = !_shares.Any(x => x.RhRoleForWid == "");
            var item = new ListViewItem("");
            item.SubItems.Add("Ролі для WID визначені");
            item.SubItems.Add(isOk ? "Так" : "Ні");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.ImageIndex = item.ImageIndex = GetShareImageIndex(isOk);
            item.Tag = null;

            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareIpiCodesItem()
        {
            var isOk = !_shares.Any(x => x.RhIpBaseNr == "" || x.RhIpNameNr == null);
            var item = new ListViewItem("");
            item.SubItems.Add("Міжнародні коди визначені");
            item.SubItems.Add(isOk ? "Так" : "Ні");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.ImageIndex = item.ImageIndex = GetShareImageIndex(isOk);
            item.Tag = null;

            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareHasOwnItem()
        {
            var isOk = _shares.Any(x => x.RhIsOwn);
            var item = new ListViewItem("");
            item.SubItems.Add("Є свій правовласник");
            item.SubItems.Add(isOk ? "Так" : "Ні");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.ImageIndex = item.ImageIndex = GetShareImageIndex(isOk);
            item.Tag = null;

            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareHasAuthorItem()
        {
            var isOk = _shares.Any(x => x.RhRoleForWid != "" && x.RhRoleForWid != "E");
            var item = new ListViewItem("");
            item.SubItems.Add("Є автор в ролі A/C/CA");
            item.SubItems.Add(isOk ? "Так" : "Ні");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.ImageIndex = item.ImageIndex = GetShareImageIndex(isOk);;
            item.Tag = null;
            lvSubmWorkShares.Items.Add(item);
        }

        private void AddSubmWorkShareClaimedShareNotZero()
        {
            var totalShare = _shares.Sum(x => x.RhShrPer + x.RhShrMec);
            var isOk = totalShare > 0;
            var item = new ListViewItem("");
            item.SubItems.Add("Загалом % не 0");
            item.SubItems.Add(isOk ? "Так" : "Ні");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.ImageIndex = item.ImageIndex = GetShareImageIndex(isOk);
            item.Tag = null;
            lvSubmWorkShares.Items.Add(item);
        }

        private void FillLvSubmWorkShares()
        {
            lvSubmWorkShares.BeginUpdate();
            lvSubmWorkShares.Items.Clear();
            AddSubmWorkShareTitleItem();
            _shares.ForEach(share =>
            {
                AddSubmWorkShareItem(share);
            });

            AddSubmWorkShareEmptyItem();
            AddSubmWorkShareSummaryTitleItem();

            AddSubmWorkShareIpiCodesItem();
            AddSubmWorkShareRolesDefinedItem();
            AddSubmWorkShareHasOwnItem();
            AddSubmWorkShareHasAuthorItem();
            AddSubmWorkShareTotalsItem();
            AddSubmWorkShareClaimedShareNotZero();


            lvSubmWorkShares.EndUpdate();

            FillLvDetails();
        }

        private void FillLvDetails()
        {
            lvDetails.Items.Clear();
            if(lvSubmWorkShares.SelectedItems.Count == 0)
            {
                return;
            }

            var share = (Share)lvSubmWorkShares.SelectedItems[0].Tag;
            if(share == null) return;

            lvDetails.BeginUpdate();
            ListViewItem item;
            item = lvDetails.Items.Add("Код СМАРТ             "); item.SubItems.Add(share.RhCustId     .ToString());
            item = lvDetails.Items.Add("Базовий код в IPI     "); item.SubItems.Add(share.RhIpBaseNr   .ToString());
                if (item.SubItems[1].Text == "") item.StateImageIndex = (int)StatusImageIndex.FAILED;
            item = lvDetails.Items.Add("Код назви в IPI       "); item.SubItems.Add(share.RhIpNameNr   .ToString());
                if (item.SubItems[1].Text == "") item.StateImageIndex = (int)StatusImageIndex.FAILED;
            item = lvDetails.Items.Add("Назва СМАРТ           "); item.SubItems.Add(share.RhName       .ToString());
            item = lvDetails.Items.Add("Назва для WID         "); item.SubItems.Add(share.RhNameForWid .ToString());
            item = lvDetails.Items.Add("Тип СМАРТ             "); item.SubItems.Add(share.RhTypeName   .ToString());
                if (share.RhRoleForWid == "") item.StateImageIndex = (int)StatusImageIndex.FAILED;
            item = lvDetails.Items.Add("Роль СМАРТ            "); item.SubItems.Add(share.RhRoleName   .ToString());
                if (share.RhRoleForWid == "") item.StateImageIndex = (int)StatusImageIndex.FAILED;
            item = lvDetails.Items.Add("Роль для WID          "); item.SubItems.Add(share.RhRoleForWid .ToString());
                if (share.RhRoleForWid == "") item.StateImageIndex = (int)StatusImageIndex.FAILED;
            item = lvDetails.Items.Add("Має договір СМАРТ     "); item.SubItems.Add(share.RhIsOwn      .ToString());
            item = lvDetails.Items.Add("Договір СМАРТ активний"); item.SubItems.Add(share.RhIsActive   .ToString());
            item = lvDetails.Items.Add("Пуб %                 "); item.SubItems.Add(share.RhShrPer     .ToString());
                if (share.RhShrPer > 100) item.StateImageIndex = (int)StatusImageIndex.FAILED;
            item = lvDetails.Items.Add("Мех %                 "); item.SubItems.Add(share.RhShrMec     .ToString());
                if (share.RhShrMec > 100) item.StateImageIndex = (int)StatusImageIndex.FAILED;
            lvDetails.EndUpdate();
        }

        private void lvSubmWorkShares_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvSubmWorkShares.SelectedItems.Count == 0)
            {
                lvDetails.Items.Clear();
            }
            else
            {
                FillLvDetails();
            }
        }

        private void lvSubmWorkShares_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvSubmWorkShares);
        }

        private void lvDetails_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvDetails);
        }
    }
}
