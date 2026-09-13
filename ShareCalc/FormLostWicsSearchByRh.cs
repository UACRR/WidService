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

namespace ShareCalc
{
    public partial class FormLostWicsSearchByRh : System.Windows.Forms.Form
    {
        public class RightHolder
        {
            public string IpBaseNr      {  get; set; }
            public string NameWid       {  get; set; }
            public string FstNameWid    {  get; set; }
            public string CustId        {  get; set; }
            public string NameMs        {  get; set; }
            public string FstNameMs     {  get; set; }
            public string SurNameMs     {  get; set; }
            public string IsProcessed   {  get; set; }
        }

        public class WidWork
        {
            public string Wic      {  get; set; }
            public string Name     {  get; set; }
            public string ObjId    {  get; set; }
        }

        public class MsWork
        {
            public string ObjId    {  get; set; }
            public string Name     {  get; set; }
            public string Authors  {  get; set; }
        }

        private List<RightHolder> _rightHolders;
        private List<WidWork> _widWorks;
        private List<MsWork> _msWorks;

        private bool _ignoreMsWorkFilterChanged;
        private bool _ignoreCbWorkFilterLetterChange;

        public FormLostWicsSearchByRh()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Configure();
            LoadRightHolders();
            FillRightHolders();
        }

        private void Configure()
        {
            Helpers.ConfigureListView(lvRh
                , "IpBaseNr"        
                , "Прізвище WID"    
                , "Імя WID"         
                , "CustId"          
                , "Прізвище СМАРТ"  
                , "Імя СМАРТ"       
                , "Побатькові СМАРТ"
            );

            Helpers.ConfigureListView(lvWorksWid
                , "WIC"        
                , "Назва твору"    
                , "Знайдений ObjId"         
             );

            Helpers.ConfigureListView(lvWorksMs
                , "ObjId"        
                , "Назва твору" 
                , "Автори" 
             );

            lvRh.SmallImageList = ilStatuses;
            lvWorksWid.SmallImageList = ilStatuses;
            lvWorksMs.SmallImageList = ilStatuses;

            lvRh.StateImageList = ilStatuses;
            lvWorksWid.SmallImageList = ilStatuses;
            lvWorksMs.SmallImageList = ilStatuses;

            cbWorkFilterLetterChange.DropDownStyle = ComboBoxStyle.DropDownList;
            cbWorkFilterLetterChange.Items.Add("Без змін");
            cbWorkFilterLetterChange.Items.Add("І на И");
            cbWorkFilterLetterChange.Items.Add("ЙУ на Ю");
            cbWorkFilterLetterChange.Items.Add("ЛЙ на ЛЮ");
            cbWorkFilterLetterChange.Items.Add("ЧЛБ на ХЛІБ");
            cbWorkFilterLetterChange.Items.Add("Е на Э");
            cbWorkFilterLetterChange.Items.Add("И на Ы");
            cbWorkFilterLetterChange.Items.Add("Ж на ЗГ");
            _ignoreCbWorkFilterLetterChange = true;
            cbWorkFilterLetterChange.SelectedIndex = 0;
            _ignoreCbWorkFilterLetterChange = false;
        }

        private void LoadRightHolders()
        {
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = "select * from UacrrLostWicRightHolders order by Name";
                _rightHolders = Helpers.CreateListFromCmd<RightHolder>(cmd);
            });
        }

        private void FillRightHolders()
        {
            Helpers.FillListView(_rightHolders, lvRh);
            Helpers.FillListView(_rightHolders, lvRh, rh =>
            {
                var searchText = tbRhWidFilter.Text.Trim().ToUpper();
                if(
                       (searchText != "" && !rh.NameWid.ToUpper().StartsWith(searchText))
                    || (!rbRhWidFilterAll.Checked && rh.IsProcessed == "1")                                                                                                                                                                                                                                                                                                                                                                                                         
                )
                    return true;
                return false;
            });

            foreach (ListViewItem rhItem in lvRh.Items)
            {
                var rh = (RightHolder)rhItem.Tag;
                rhItem.StateImageIndex = rh.IsProcessed == "1" ? 2 : 4;
            }
        }

        private void LoadWidWorks()
        {
            if(lvRh.SelectedItems.Count == 0)
            {
                lvWorksWid.Items.Clear();
                lvWorksMs.Items.Clear();
                return;
            }

            var ipBaseNr = ((RightHolder)lvRh.SelectedItems[0].Tag).IpBaseNr;
            var extraFilterTxt = !rbShowAllWidWorks.Checked ? " and t1.ObjId = 0" : "";
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = $@"
                    select distinct cast(t1.Wic as varchar(16)), t2.WrkTtl, cast(isnull(t1.ObjId, '') as varchar(16)) as ObjId
                    from ShareCalc..UacrrLostWics t1
	                    join SocWid..WidTitle t2 on t1.Wic = t2.Wic
	                    join SocWid..widIntrPty t3 on t1.Wic = t3.Wic
	                    join SocIpi..IpiName t4 on t3.IpNameNr = t4.IpNameNr
                    where t4.IpBaseNr = @ipBaseNr
                        {extraFilterTxt}
                    order by t2.WrkTtl
                ";
                cmd.Parameters.AddWithValue("@ipBaseNr", ipBaseNr);
                _widWorks = Helpers.CreateListFromCmd<WidWork>(cmd);
            });
        }

        private void FillWidWorks()
        {
            Helpers.FillListView(_widWorks, lvWorksWid);
        }

        private void LoadMsWorks()
        {
            if(tbMsRhFilter.Text.Trim() == "")
            {
                _msWorks = new List<MsWork>();
                return;
            }

            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = @"
                    select distinct top 1000 cast(t1.ObjId as varchar(16)), t1.Name, Author, t3.*
                    from MediaService..ObjectRight t1
	                    join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
	                    join UacrrRhNamesMs t3 on t2.CustId = t3.CustId
                    where t3.Name like @paramName
	                    and t3.FirstName like @paramFirstName
	                    and t3.SurName like @paramSurName
                    order by t1.Name
                 ";
                var parts = tbMsRhFilter.Text.Trim().Split(' ');
                var paramName = $"{parts[0]}%";
                var paramFirstName = parts.Length > 1 ? $"{parts[1]}%" : "%";
                var paramSurName = parts.Length > 2 ? $"{parts[2]}%" : "%";
                cmd.Parameters.AddWithValue("@paramName", paramName);
                cmd.Parameters.AddWithValue("@paramFirstName", paramFirstName);
                cmd.Parameters.AddWithValue("@paramSurName", paramSurName);
                _msWorks = Helpers.CreateListFromCmd<MsWork>(cmd);
            });
        }

        private void FillMsWorks()
        {
            Helpers.FillListView(_msWorks, lvWorksMs, msWork =>
            {
                var searchText = tbMsWorkFilter.Text.Trim().ToUpper();
                if(searchText != "" && !msWork.Name.ToUpper().StartsWith(searchText))
                    return true;
                return false;
            });
        }

        private void ClearControls()
        {
            lvWorksMs.Items.Clear();
            lvWorksWid.Items.Clear();
            tbMsRhFilter.Text = "";
            tbMsWorkFilter.Text = "";
        }

        private void UpdateLvImages(System.Windows.Forms.ListView lv)
        {
            foreach(ListViewItem item in lv.Items)
            {
                item.ImageIndex = item.Selected ? 1 : 4;
            }
        }

        private void AssignObjId()
        {
            if(lvWorksWid.SelectedItems.Count == 0 || lvWorksMs.SelectedItems.Count == 0)
                return;

            var itemWid = lvWorksWid.SelectedItems[0];
            var itemMs  = lvWorksMs.SelectedItems[0];
            var workWid = (WidWork)itemWid.Tag;
            var workMs = (MsWork)itemMs.Tag;
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = "update ShareCalc..UacrrLostWics set ObjId = @objId where Wic = @wic";
                cmd.Parameters.AddWithValue("@wic", workWid.Wic);
                cmd.Parameters.AddWithValue("@objId", workMs.ObjId);
                cmd.ExecuteNonQuery();
            });

            workWid.ObjId = workMs.ObjId;
            itemWid.SubItems[3].Text = workMs.ObjId.ToString();
        }

        private void ToggleRhProcessed()
        {
            if(lvRh.SelectedItems.Count == 0)
            {
                return;
            }

            var rhItem = lvRh.SelectedItems[0];
            var rh = (RightHolder)rhItem.Tag;

            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = "update ShareCalc..UacrrLostWicRightHolders set IsProcessed = @isProcessed where IpBaseNr = @ipBaseNr";
                cmd.Parameters.AddWithValue("@ipBaseNr", rh.IpBaseNr);
                cmd.Parameters.AddWithValue("@isProcessed", rh.IsProcessed == "0" ? "1" : "0");
                cmd.ExecuteNonQuery();
            });

            rh.IsProcessed = rh.IsProcessed == "0" ? "1" : "0";
            rhItem.SubItems[8].Text = rh.IsProcessed;
            rhItem.StateImageIndex = rh.IsProcessed == "1" ? 2 : 4;
        }

        private void FillMsWorkFilter()
        {
            if(lvWorksWid.SelectedItems.Count == 0)
            {
                tbMsWorkFilter.Text = "";
                return;
            }
            var workWid = (WidWork)lvWorksWid.SelectedItems[0].Tag;
            var filterText = "";
            if(cbWorkFilterLetterChange.SelectedIndex == 0)
            {
                filterText = Translit.FstNCharsFromLat(workWid.Name, 3);
            }
            else
            {
                filterText = tbMsWorkFilter.Text;
                var parts = cbWorkFilterLetterChange.Text.Split(' ');
                filterText = filterText.Replace(parts[0], parts[2]);
            }
            tbMsWorkFilter.Text = filterText;
        }

        private void lvRh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvRh.SelectedItems.Count == 0)
            {
                ClearControls();
                UpdateLvImages(lvRh);
                return;
            }

            var rh = (RightHolder)lvRh.SelectedItems[0].Tag;
            var rhFilterText = Translit.FstNCharsFromLat(rh.NameWid, 3);
            if(rh.FstNameWid.Trim() != "")
            {
                var parts = rh.FstNameWid.Split(' ');
                if(parts.Length > 0)
                    rhFilterText += $" {Translit.FstCharFromLat(parts[0].Trim())}";
                if(parts.Length > 1)
                    rhFilterText += $" {Translit.FstCharFromLat(parts[1].Trim())}";
            }
            tbMsRhFilter.Text = rhFilterText;
            
            Helpers.RunProtected( () => {
                LoadWidWorks();
                FillWidWorks();
                LoadMsWorks();
                FillMsWorks();
            });

            UpdateLvImages(lvRh);
        }

        private void lvRh_DoubleClick(object sender, EventArgs e)
        {
            ToggleRhProcessed();
        }
        
        private void btnApplyMsRhFilter_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected( () => {
                LoadMsWorks();
                FillMsWorks();
            });
        }

        private void tbMsWorkFilter_TextChanged(object sender, EventArgs e)
        {
            if(_ignoreMsWorkFilterChanged)
                return;
            FillMsWorks();
        }

        private void lvWorksWid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvWorksWid.SelectedItems.Count == 0)
                return;

            var workWid = (WidWork)lvWorksWid.SelectedItems[0].Tag;
            _ignoreMsWorkFilterChanged = true;
            FillMsWorkFilter();
            _ignoreMsWorkFilterChanged= false;
            _ignoreCbWorkFilterLetterChange = true;
            cbWorkFilterLetterChange.SelectedIndex = 0;
            _ignoreCbWorkFilterLetterChange = false;
            FillMsWorks();
            UpdateLvImages(lvWorksWid);
        }

        private void lvWorksMs_DoubleClick(object sender, EventArgs e)
        {
            Helpers.RunProtected( () => {
                AssignObjId();
                if (lvWorksWid.SelectedIndices.Count > 0)
                {
                    var selectedIndex = lvWorksWid.SelectedIndices[0];
                    if(selectedIndex < lvWorksWid.Items.Count - 1)
                    {
                        lvWorksWid.Items[selectedIndex + 1].Selected = true;
                    }
                    FillMsWorkFilter();
                }

            });
        }

        private void rbShowUnmatchedWidWorks_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected( () => {
                LoadWidWorks();
                FillWidWorks();
            });
        }

        private void rbShowAllWidWorks_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected( () => {
                LoadWidWorks();
                FillWidWorks();
            });
        }

        private void tbRhWidFilter_TextChanged(object sender, EventArgs e)
        {
            FillRightHolders();
        }

        private void rbRhWidFilterAll_CheckedChanged(object sender, EventArgs e)
        {
            FillRightHolders();
        }

        private void rbRhWidFilterUnprocessed_CheckedChanged(object sender, EventArgs e)
        {
            FillRightHolders();
        }

        private void cbWorkFilterLetterChange_SelectedValueChanged(object sender, EventArgs e)
        {
            if(_ignoreCbWorkFilterLetterChange)
                return;
            FillMsWorkFilter();
            //FillMsWorks();
        }
    }
}
