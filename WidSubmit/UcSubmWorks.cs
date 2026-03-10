using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public partial class UcSubmWorks : UserControl
    {
        public enum SubmWorkStatus
        {
	          NOT_READY
	        , READY
	        , SUBMITTED
	        , ACCEPTED
	        , ACCEPTED_WARNINGS
            , REJECTED
	        , APPLIED
	        , COMPLETED
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
        }

        public class SubmWork
        {
	        public int      Id              { get; set; }
	        public int      SubmissionId    { get; set; }
	        public int      ObjId           { get; set; }
	        public int?     Wic             { get; set; }
            public string   Iswc             { get; set; }
	        public string   Name            { get; set; }
	        public string   NameForWid	    { get; set; }
	        public bool     IsChanged	    { get; set; }
            public int      Status	        { get; set; }
        }

        private static readonly string[] _submWorkStatusText = new string[]
        {
	          "Проблемний"          //NOT_READY
	        , "До передачі"         //READY
	        , "Переданий"           //SUBMITTED
	        , "Прийнятий"           //ACCEPTED
	        , "Прийнятий умовно"    //ACCEPTED_WARNINGS
            , "Віджхилений"         //REJECTED
	        , "Застосований"        //APPLIED
	        , "Завершений"          //COMPLETED
        };

        private List<RightHolder>   _rightHolders;
        private List<SubmWork>      _submWorks;

        public UcSubmWorks()
        {
            InitializeComponent();
        }

        private void UcSubmWorks_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvRightHolders.FullRowSelect = true;
            lvRightHolders.GridLines = true;
            lvRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolders.MultiSelect = false;
            lvRightHolders.View = View.Details;

            lvRightHolders.Columns.Clear();
            lvRightHolders.Columns.Add("№", 40);
            lvRightHolders.Columns.Add("Код СМАРТ", 80);
            lvRightHolders.Columns.Add("Назва СМАРТ", 200);

            lvSubmWorks.FullRowSelect = true;
            lvSubmWorks.GridLines = true;
            lvSubmWorks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvSubmWorks.MultiSelect = false;
            lvSubmWorks.View = View.Details;

            lvSubmWorks.Columns.Clear();
            lvSubmWorks.Columns.Add("№", 40);
            lvSubmWorks.Columns.Add("Статус в сеансі", 100);
            lvSubmWorks.Columns.Add("Код СМАРТ", 80);
            lvSubmWorks.Columns.Add("Код WID", 80);
            lvSubmWorks.Columns.Add("ISWC", 80);
            lvSubmWorks.Columns.Add("Назва СМАРТ", 100);
            lvSubmWorks.Columns.Add("Назва WID", 100);
            lvSubmWorks.Columns.Add("Статус публікації", 100);

            cbFilterByStatus.Items.Clear();
            cbFilterByStatus.Items.Add("<Всі>");
            var idx = 0;
            _submWorkStatusText.ToList().ForEach(x => { 
                cbFilterByStatus.Items.Add($"{idx} - {x}");
                idx++;
            });
            cbFilterByStatus.SelectedIndex = 0;

            ResetTabImages();
        }
        
        public void UpdateContent()
        {
            LoadRightHolders();
            FillLvRightHolders();

            LoadSubmWorks();
            FillLvSubmWorks();
        }
        
        private void LoadRightHolders()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = $@"
                    select
	                      t1.Id		
	                    , t1.ValidFrom	
	                    , t1.ValidTo	
	                    , t1.CreatedAt	
	                    , t1.CustId	
	                    , t1.IpBaseNr	
	                    , t1.IpNameNr	
	                    , t1.Name
                        , t1.FstName
                        , t1.NameForWid
                        , t1.FstNameForWid
                        , t1.IsOwn
	                    , t1.IsActive
                        , t1.HasIpiAgreePer
                        , t1.HasIpiAgreeMec
                    from RightHolder t1
                        join SubmRightHolder t2 on t1.Id = t2.RightHolderId and t2.SubmissionId = dbo.fnCurSubmId()
                    order by t1.Name, t1.FstName
                ";
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

                        _rightHolders.Add(rh);
                    }
                }
            });
        }

        private void LoadSubmWorks()
        {
            var custId = lvRightHolders.SelectedItems.Count == 0 ? -1 :
                    lvRightHolders.SelectedItems[0].Tag == null ? 0 :
                    ((RightHolder)lvRightHolders.SelectedItems[0].Tag).CustId;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectRightHolderCurSubmWorks";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@custId", custId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _submWorks = new List<SubmWork>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var work = new SubmWork();
	                    work.Id           = r.GetInt32(idx);                                idx++;
	                    work.SubmissionId = r.GetInt32(idx);                                idx++;
	                    work.ObjId        = r.GetInt32(idx);                                idx++;
	                    work.Wic          = r.IsDBNull(idx) ? null : (int?)r.GetInt32(idx); idx++;
                        work.Iswc         = r.GetString(idx);                               idx++;
	                    work.Name         = r.GetString(idx);                               idx++;
	                    work.NameForWid   = r.GetString(idx);                               idx++;
                        work.IsChanged    = r.GetBoolean(idx);                              idx++;
                        work.Status       = r.GetInt32(idx);                                idx++;
                        
                        _submWorks.Add(work);
                    }
                }

                _submWorks.OrderBy(x => x.Name);
            });
        }
    
        private bool ShowRightHolder(RightHolder rh)
        {
            var cond = tbRightHolderFilter.Text.Trim();
            if (cond.Length == 0) return true;
            if (rh.CustId.ToString().Contains(cond)) return true;
            if (rh.IpBaseNr != null && rh.IpBaseNr.Contains(cond)) return true;
            if (rh.IpNameNr != null && rh.IpNameNr.ToString().Contains(cond)) return true;
            if (rh.Name.ToUpper().Contains(cond.ToUpper())) return true;
            if (rh.FstName.ToUpper().Contains(cond.ToUpper())) return true;

            return false;
        }

        private void FillLvRightHolders()
        {
            lvRightHolders.BeginUpdate();
            lvRightHolders.Items.Clear();
            
            var seqNr = 1;
            var item = new ListViewItem("");
            item.SubItems.Add("");
            item.SubItems.Add("<Всі правовласники>");
            item.Tag = null;
            lvRightHolders.Items.Add(item);

            seqNr++;
            _rightHolders.ForEach(x =>
            {
                if (ShowRightHolder(x))
                {
                    item = new ListViewItem(seqNr.ToString());
                    item.SubItems.Add(x.CustId.ToString());
                    item.SubItems.Add($"{x.Name} {x.FstName}".Trim());
                    item.StateImageIndex = x.IsOwn ? 1 : 4;
                    item.Tag = x;
                    lvRightHolders.Items.Add(item);
                    seqNr++;
                }
            });
            lvRightHolders.EndUpdate();

        }

        private bool ShowSubmWork(SubmWork work)
        {
            if (rbFilterSubmittedYes.Checked && work.IsChanged) return false;
            if (rbFilterSubmittedNo.Checked && !work.IsChanged) return false;

            var requiredStatus = cbFilterByStatus.SelectedIndex - 1;
            if (requiredStatus >= 0 && work.Status != requiredStatus) return false;

            var exFilterText = tbSubmWorkExFilter.Text.ToUpper();
            var meetsExFiler = work.ObjId.ToString() == exFilterText
                || work.Wic.ToString() == exFilterText
                || work.Iswc.ToUpper() == exFilterText
                || work.Name.Contains(exFilterText);
            if (!meetsExFiler) return false;

            return true;
        }

        private void FillLvSubmWorks()
        {
            lvSubmWorks.BeginUpdate();
            lvSubmWorks.Items.Clear();
            
            var seqNr = 1;
            _submWorks.ForEach(x =>
            {
                if (ShowSubmWork(x))
                {
                    var item = new ListViewItem(seqNr.ToString());
                    item.SubItems.Add(_submWorkStatusText[x.Status]);
                    item.SubItems.Add(x.ObjId.ToString());
                    item.SubItems.Add(x.Wic == null ? "" : x.Wic.ToString());
                    item.SubItems.Add(x.Iswc);
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.NameForWid);
                    item.SubItems.Add(x.IsChanged ? "Змінений" : "Новий");
                    item.ImageIndex = x.Status;
                    item.StateImageIndex = x.IsChanged ? 1 : 0;
                    item.Tag = x;

                    lvSubmWorks.Items.Add(item);
                    seqNr++;
                }
            });
            lvSubmWorks.EndUpdate();
        }

        private void ApplyRightHolderFilter()
        {
            FillLvRightHolders();
        }

        private void ResetTabImages()
        {
            panelWorkDetails.TabPages[0].ImageIndex = 4;
            panelWorkDetails.TabPages[1].ImageIndex = 4;
            panelWorkDetails.TabPages[2].ImageIndex = 4;
            panelWorkDetails.TabPages[3].ImageIndex = 4;
            panelWorkDetails.TabPages[4].ImageIndex = 4;
        }

        private void UpdateTabImages()
        {
            panelWorkDetails.TabPages[0].ImageIndex = ucSubmWorkCheckList.HasErrors() ? 3 : 2;
            panelWorkDetails.TabPages[1].ImageIndex = 2;
            panelWorkDetails.TabPages[2].ImageIndex = 2;
            panelWorkDetails.TabPages[3].ImageIndex = ucSubmWorkCheckList.HasErrors() ? 3 : 2;
            panelWorkDetails.TabPages[4].ImageIndex = 2;
        }

        private void btnApplyRightHolderFilter_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                ApplyRightHolderFilter();
            });
        }

        private void rbFilterSubmittedNo_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });
        }

        private void rbFilterSubmittedYes_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });
        }

        private void rbFilterSubmittedAll_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });
        }

        private void lvRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRightHolders.SelectedItems.Count == 0)
            {
                lvSubmWorks.Items.Clear();
                ucSubmWorkShares.ClearContent();
                ucSubmWorkAltNames.ClearContent();
                ucSubmWorkPerformers.ClearContent();
                ucSubmWorkCheckList.ClearContent();
                ResetTabImages();
                return;
            }

            Helpers.RunProtected(() =>
            {
                ucSubmWorkShares.ClearContent();
                ucSubmWorkAltNames.ClearContent();
                ucSubmWorkPerformers.ClearContent();
                ucSubmWorkCheckList.ClearContent();
                LoadSubmWorks();
                FillLvSubmWorks();
            });
        }

        private void lvSubmWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSubmWorks.SelectedItems.Count == 0)
            {
                ucSubmWorkShares.ClearContent();
                ucSubmWorkAltNames.ClearContent();
                ucSubmWorkPerformers.ClearContent();
                ucSubmWorkCheckList.ClearContent();
                ResetTabImages();
            }
            else
            {
                var submWork = (SubmWork)lvSubmWorks.SelectedItems[0].Tag;
                ucSubmWorkShares.UpdateContent(submWork.Id);
                ucSubmWorkAltNames.UpdateContent(submWork.Id);
                ucSubmWorkPerformers.UpdateContent(submWork.Id);
                ucSubmWorkCheckList.UpdateContent(submWork.Id);
                UpdateTabImages();
            }
        }

        private void lvRightHolders_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvRightHolders);
        }

        private void lvSubmWorks_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvSubmWorks);
        }

        private void cbFilterByStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterByStatus.SelectedIndex == -1 || _submWorks == null) return;

            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });

        }

        private void tbSubmWorkExFilter_TextChanged(object sender, EventArgs e)
        {
            btnSubmWorkApplyExFilter.Enabled = true;
        }

        private void btnSubmWorkApplyExFilter_Click(object sender, EventArgs e)
        {
            btnSubmWorkApplyExFilter.Enabled = false;
            FillLvSubmWorks();
        }
    }
}
