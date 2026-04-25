using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WidSubmit.Properties;

namespace WidSubmit
{
    public partial class UcRightHolders : UserControl
    {
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

        public class Submission
        {
	        public int          Id		        { get; set; }
	        public DateTime     StartedAt	    { get; set; }
	        public DateTime?    EndedAt	        { get; set; }
	        public string       SubmFileName    { get; set; }
	        public string       RespFileName    { get; set; }
            public string       ErrorFileName   { get; set; }
	        public DateTime     CreatedAt	    { get; set; }
	        public DateTime?    UpdatedAt	    { get; set; }
        }

        private List<Submission> _submissions;
        private List<RightHolder> _rightHolders;
        private List<RightHolder> _rightHolderHist;

        private bool _ignoreCbFilterBySubmissionSelectedIndexChanged = false;

        private bool _isDirty;

        public UcRightHolders()
        {
            InitializeComponent();

            _isDirty = true;
        }

        private void UcRightHolders_Load(object sender, EventArgs e)
        {
            Configure();
        }
        
        public void SetDirty() => _isDirty = true;

        public void UpdateContent()
        {
            if(!_isDirty) return;

            panelMain.Visible = false;
            timerUpdateContent.Enabled = true;
            //LoadSubmissions();
            //_ignoreCbFilterBySubmissionSelectedIndexChanged = true;
            //FillCbFilterBySubmission();
            //_ignoreCbFilterBySubmissionSelectedIndexChanged = false;
            //LoadRightHolders();
            //ApplyFilter();
            //this.Visible = true;
        }
         
        private void ApplyFilter()
        {
            FillLvRightHolders();

            lvRightHolderHist.Items.Clear();
            _rightHolderHist = null;
        }

        private void Configure()
        {
            lvRightHolders.FullRowSelect = true;
            lvRightHolders.GridLines = true;
            lvRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolders.MultiSelect = false;
            lvRightHolders.View = View.Details;

            lvRightHolders.Columns.Clear();
            lvRightHolders.Columns.Add("", 50);
            lvRightHolders.Columns.Add("№", 40);
            lvRightHolders.Columns.Add("Код СМАРТ", 80);
            lvRightHolders.Columns.Add("Назва СМАРТ", 200);

            lvRightHolderHist.FullRowSelect = true;
            lvRightHolderHist.GridLines = true;
            lvRightHolderHist.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvRightHolderHist.MultiSelect = false;
            lvRightHolderHist.View = View.Details;

            cbFilterBySubmission.Items.Clear();

            panelMiddle.SplitterDistance = 460;
        }

        private void LoadSubmissions()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select top 50
                          Id		   
	                    , StartedAt
	                    , EndedAt	   
	                    , SubmFileName 
	                    , RespFileName 
                        , ErrorFileName
	                    , CreatedAt
	                    , UpdatedAt
                    from Submission
                    order by StartedAt desc
                ";
                using (var r = cmd.ExecuteReader())
                {
                    _submissions = new List<Submission>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var subm = new Submission();
	                    subm.Id		        = r.GetInt32(idx);                                          idx++;
	                    subm.StartedAt	    = r.GetDateTime(idx);                                       idx++;
	                    subm.EndedAt	    = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx);   idx++;
	                    subm.SubmFileName 	= r.GetString(idx);                                         idx++;
	                    subm.RespFileName   = r.GetString(idx);                                         idx++;
                        subm.ErrorFileName  = r.GetString(idx);                                         idx++;
	                    subm.CreatedAt      = r.GetDateTime(idx);                                       idx++;
	                    subm.UpdatedAt      = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx);   idx++;

                        _submissions.Add(subm);
                    }
                }
            });
        }

        private void LoadRightHolders()
        {
            var submFilterIdx = cbFilterBySubmission.SelectedIndex;
            var submId = cbFilterBySubmission.SelectedIndex == 0 ? -1 : _submissions[submFilterIdx - 1].Id;
            var extraJoin = submId > 0 ? 
                "join SubmRightHolder t2 on t1.Id = t2.RightHolderId and t2.SubmissionId = @submId" : 
                "";
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
                        {extraJoin}
                    where t1.ValidTo = datefromparts(9999, 12, 31)
                    order by t1.Name, t1.FstName
                ";
                cmd.Parameters.AddWithValue("@submId", submId);
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
                        //rh.HasIpiAgreePer	= r.GetBoolean(idx);                                idx++;
                        //rh.HasIpiAgreeMec	= r.GetBoolean(idx);                                idx++;

                        _rightHolders.Add(rh);
                    }
                }
            });
        }

        private void LoadRightHolderHist(int custId)
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = @"
                    select top 10
	                      Id		
	                    , ValidFrom	
	                    , ValidTo	
	                    , CreatedAt	
	                    , CustId	
	                    , IpBaseNr	
	                    , IpNameNr	
	                    , Name
                        , FstName
                        , FstNameForWid
                        , FstNameForWid
                        , IsOwn
	                    , IsActive
                        , HasIpiAgreePer
                        , HasIpiAgreeMec
                    from RightHolder
                    where CustId = @custId
                    order by ValidFrom desc
                ";
                cmd.Parameters.AddWithValue("@custId", custId);
                using (var r = cmd.ExecuteReader())
                {
                    _rightHolderHist = new List<RightHolder>();
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
                        //rh.HasIpiAgreePer	= r.GetBoolean(idx);                                idx++;
                        //rh.HasIpiAgreeMec	= r.GetBoolean(idx);                                idx++;

                        _rightHolderHist.Add(rh);
                    }
                }
            });
        }
    
        private void FillCbFilterBySubmission()
        {
            cbFilterBySubmission.BeginUpdate();
            cbFilterBySubmission.Items.Clear();
            cbFilterBySubmission.Items.Add("причетні до творів УААСП");
            var submIdx = 0;
            _submissions.ForEach(x =>
            {
                if (submIdx == 0)
                {
                    cbFilterBySubmission.Items.Add("вибрані для поточної передачі");
                }
                else
                {
                    var txtStartedAt = x.StartedAt == new DateTime(1900, 1, 1) ? "початку" :  x.StartedAt.ToString("yyy-MM-dd");
                    var txtEndedAt = x.EndedAt == null ? "кінця" : ((DateTime)x.EndedAt).ToString("yyy-MM-dd");
                    cbFilterBySubmission.Items.Add($"залучені від {txtStartedAt} до {txtEndedAt}");
                }
                submIdx++;
            });
            cbFilterBySubmission.SelectedIndex = 0;
            cbFilterBySubmission.EndUpdate();
        }
        private void FillLvRightHolders()
        {
            lvRightHolderHist.Items.Clear();

            lvRightHolders.BeginUpdate();
            lvRightHolders.Items.Clear();
            var seqNr = 1;
            _rightHolders.ForEach(x =>
            {
                if (ShowRightHolder(x))
                {
                    var item = new ListViewItem();
                    item.Text = "";
                    item.SubItems.Add(seqNr.ToString());
                    item.SubItems.Add(x.CustId.ToString());
                    item.SubItems.Add($"{x.Name} {x.FstName}".Trim());
                    item.StateImageIndex = x.IsOwn ? 1 : 4;
                    item.ImageIndex = !x.IsOwn ? 4 : x.IsActive ? 2 : 3;
                    item.Tag = x;
                    lvRightHolders.Items.Add(item);
                    seqNr++;
                }
            });
            lvRightHolders.EndUpdate();

            FillLvRightHolderHist();
        }

        private void FillLvRightHolderHist()
        {
            if(_rightHolderHist == null)
            {
                lvRightHolderHist.Items.Clear();
                return;
            }

            var colWidths = new List<int>();
            if (lvRightHolderHist.Columns.Count > 0)
            {
                foreach (ColumnHeader col in lvRightHolderHist.Columns)
                {
                    colWidths.Add(col.Width);
                }
            }
            else
            {
                colWidths.Add(240);
                colWidths.Add(200);
            }
            
            lvRightHolderHist.Columns.Clear();
            lvRightHolderHist.BeginUpdate();
            lvRightHolderHist.Items.Clear();
            lvRightHolderHist.Columns.Add("Параметри правовласника", colWidths[0]);
            lvRightHolderHist.Items.Add(new ListViewItem("Має договір з УААСП"));
            lvRightHolderHist.Items.Add(new ListViewItem("Договір з УААСП активний"));
            lvRightHolderHist.Items.Add(new ListViewItem("Базовий код в IPI"));
            lvRightHolderHist.Items.Add(new ListViewItem("Код назви в IPI"));
            //lvRightHolderHist.Items.Add(new ListViewItem("Має договір з УААСП в IPI для пуб"));
            //lvRightHolderHist.Items.Add(new ListViewItem("Має договір з УААСП в IPI для мех"));
            lvRightHolderHist.Items.Add(new ListViewItem("Назва в СМАРТ"));
            
            _rightHolderHist.ForEach(x =>
            {
                var fromTxt = x.ValidFrom == new DateTime(1900, 1, 1) ? "початку" : x.ValidFrom.ToString("yyyy.MM.dd");
                var toTxt = x.ValidTo == new DateTime(9999, 12, 31) ? "кінця" : x.ValidTo.ToString("yyyy.MM.dd");
                lvRightHolderHist.Columns.Add($"Від {fromTxt} до {toTxt}", colWidths[1]);
            });
                        
            _rightHolderHist.ForEach(x =>
            {
                var itemIdx = 0;
                var items = lvRightHolderHist.Items;
                items[itemIdx++].SubItems.Add(x.IsOwn ? "так" : "ні");
                items[itemIdx++].SubItems.Add(x.IsActive ? "так" : "ні");
                items[itemIdx++].SubItems.Add(x.IpBaseNr == null ? "" : x.IpBaseNr);
                items[itemIdx++].SubItems.Add(x.IpNameNr == null ? "" : x.IpNameNr.ToString());
                //items[itemIdx++].SubItems.Add(x.HasIpiAgreePer ? "так" : "ні");
                //items[itemIdx++].SubItems.Add(x.HasIpiAgreeMec ? "так" : "ні");
                items[itemIdx++].SubItems.Add($"{x.Name} {x.FstName}".Trim());
            });
            lvRightHolderHist.EndUpdate();
        }

        private void FillLvRightHolderHistOld()
        {
            if(_rightHolderHist == null)
            {
                lvRightHolderHist.Items.Clear();
                return;
            }

           lvRightHolderHist.BeginUpdate();
           lvRightHolderHist.Items.Clear();
            _rightHolderHist.ForEach(x =>
            {
                var item = new ListViewItem();
                item.Text = "";
                item.SubItems.Add(x.ValidFrom == new DateTime(1900, 1, 1) ? "Без обмежень" : x.ValidFrom.ToString("yyyy-MM-dd"));
                item.SubItems.Add(x.ValidTo == new DateTime(9999, 12, 31)? "Без обмежень" : x.ValidTo.ToString("yyyy-MM-dd"));
                item.SubItems.Add(x.IsOwn ? "так" : "ні");
                item.SubItems.Add(x.IsActive ? "так" : "ні");
                item.SubItems.Add(x.IpBaseNr == null ? "" : x.IpBaseNr);
                item.SubItems.Add(x.IpNameNr == null ? "" : x.IpNameNr.ToString());
                //item.SubItems.Add(x.HasIpiAgreePer ? "так" : "ні");
                //item.SubItems.Add(x.HasIpiAgreeMec ? "так" : "ні");
                item.SubItems.Add($"{x.Name} {x.FstName}".Trim());
                item.ImageIndex = x.ValidTo == new DateTime(9999, 12, 31) ? !x.IsOwn ? 4 : x.IsActive ? 2 : 3 : 4;
                item.Tag = x;
                lvRightHolderHist.Items.Add(item);
            });
            lvRightHolderHist.EndUpdate();
        }
        private bool ShowRightHolder(RightHolder rh)
        {
            if (rbFilterOwn.Checked && !rh.IsOwn) return false;
            if (rbFilterForeign.Checked && rh.IsOwn) return false;

            var cond = tbFilter.Text.Trim();
            if (cond.Length == 0) return true;
            if (rh.CustId.ToString().Contains(cond)) return true;
            if (rh.IpBaseNr != null && rh.IpBaseNr.Contains(cond)) return true;
            if (rh.IpNameNr != null && rh.IpNameNr.ToString().Contains(cond)) return true;
            if (rh.Name.ToUpper().Contains(cond.ToUpper())) return true;
            if (rh.FstName.ToUpper().Contains(cond.ToUpper())) return true;

            return false;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void lvRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rightHolderHist = new List<RightHolder>();
            lvRightHolderHist.Items.Clear();
            if(lvRightHolders.SelectedItems.Count == 0)
            {
                return;
            }
            var curItem = lvRightHolders.SelectedItems[0];
            var rh = curItem.Tag as RightHolder;
            LoadRightHolderHist(rh.CustId);
            FillLvRightHolderHist();
        }

        private void rbFilterOwn_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void rbFilterForeign_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void rbFilterOwnAndForeign_CheckedChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cbFilterBySubmission_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ignoreCbFilterBySubmissionSelectedIndexChanged)
            {
                return;
            }
            switch (cbFilterBySubmission.SelectedIndex)
            {
                case 0: btnUpdateRightHolders.Visible = true; btnChangeSubmRightHolders.Visible = false; break;
                case 1: btnUpdateRightHolders.Visible = false; btnChangeSubmRightHolders.Visible = true; break;
                default: btnUpdateRightHolders.Visible = false; btnChangeSubmRightHolders.Visible = false; break;
            }
            LoadRightHolders();
            ApplyFilter();
        }

        private void btnUpdateRightHolders_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlSocWidSubmitExT(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spRightHoldersUpdate";
                cmd.ExecuteNonQuery();
            });
            UpdateContent();
        }

        private void btnChangeSubmRightHolders_Click(object sender, EventArgs e)
        {
            var form = new FormSubmissionRightHolders();
            form.ShowDialog();
            LoadRightHolders();
            FillLvRightHolders();
        }

        private void lvRightHolders_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvRightHolders);
        }

        private void lvRightHolderHist_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvRightHolderHist);
        }

        private void timerUpdateContent_Tick(object sender, EventArgs e)
        {
            timerUpdateContent.Enabled = false;
            
            Helpers.SetWaitCursor();
            
            LoadSubmissions();
            _ignoreCbFilterBySubmissionSelectedIndexChanged = true;
            FillCbFilterBySubmission();
            _ignoreCbFilterBySubmissionSelectedIndexChanged = false;
            LoadRightHolders();
            ApplyFilter();
            panelMain.Visible = true;

            Helpers.UnsetWaitCursor();
            _isDirty = false;
            
        }
    }
}
