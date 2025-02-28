using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DdexInvoicing.UcDspResourceAnalyser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DdexInvoicing
{
    public partial class UcDspResourceAnalyser : UserControl
    {
        
        public class DspResourceDetailRecord
        {
	        public int DspResourcePk            { get; set; }
	        public DateTime PeriodStartDate     { get; set; }
	        public int Year                     { get; set; }
	        public int Quarter                  { get; set; }
	        public int Month                    { get; set; }
	        public string FileType              { get; set; }
	        public int MwId                     { get; set; }
	        public int ObjId                    { get; set; }
	        public int Wic                      { get; set; }
	        public string ResourceTitle         { get; set; }
	        public string Title                 { get; set; }
	        public string Authors               { get; set; }
	        public string Performers            { get; set; }
	        public string Iswc                  { get; set; }
        }

        public class DspResource
        {
            public int Id                   { get; set; }
            public string DspToken          { get; set; }
            public string DspResourceId     { get; set; }
            public int ObjId                { get; set; }
            public int Wic                  { get; set; }
            public bool IsImportedFromWid   { get; set; }
            public int MwIdCanonical        { get; set; }

            public List<DspResourceDetailRecord> Details { get; set; }
        }

        private List<DspResource> _dspResources;

        public UcDspResourceAnalyser()
        {
            InitializeComponent();
        }

        private void UcDspResourceAnalyser_Load(object sender, EventArgs e)
        {
            Configure();

            tbFilter.Text = "8058";
        }

        private void Configure()
        {
            lvDspResources.View = View.Details;
            lvDspResources.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvDspResources.FullRowSelect = true;
            lvDspResources.HideSelection = false;
            lvDspResources.MultiSelect = false;
            lvDspResources.GridLines = true;
            lvDspResources.Columns.Clear();
            lvDspResources.Columns.Add("Код", 60);
            lvDspResources.Columns.Add("Назва", 200);
        }

        private void ApplyFilter()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    select
	                      ObjId
	                    , isnull(Name, '')
	                    , isnull(Author, '')
	                    , isnull(Performer, '')
                    from MediaService..ObjectRight
                    where ObjId = @ObjId
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ObjId", tbFilter.Text);
                using (var r = cmd.ExecuteReader())
                {
                    labWorkName.Text = "";
                    labWorkDetails.Text = "";
                    labWorkPerformers.Text = "";
                    if (r.Read())
                    {
                        labWorkName.Text = r.GetString(1);
                        labWorkDetails.Text = r.GetString(2);
                        labWorkPerformers.Text = r.GetString(3);
                    }
                }

            });

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    select distinct
	                      t1.Id
	                    , t1.DspToken
	                    , t1.DspResourceId
	                    , isnull(t1.ObjId, 0)
	                    , isnull(t1.Wic, 0)
	                    , isnull(t1.IsImportedFromWid, 0)
	                    , isnull(t1.MwIdCanonical, 0)
                    from DspResources t1
	                    join DspResourceToIdentMw t2 on t1.Id = t2.DspResourcePk
	                    join IdentMw t3 on t2.IdentMwPk = t3.Id
                    where t3.ObjId = @ObjId
                    order by t1.DspToken
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ObjId", tbFilter.Text);
                using (var r = cmd.ExecuteReader())
                {
                    _dspResources = new List<DspResource>();
                    while(r.Read())
                    {
                        var dspResource = new DspResource();
                        var idx = 0;
                        dspResource.Id                   = r.GetInt32(idx++);
                        dspResource.DspToken             = r.GetString(idx++);
                        dspResource.DspResourceId        = r.GetString(idx++);
                        dspResource.ObjId                = r.GetInt32(idx++);
                        dspResource.Wic                  = r.GetInt32(idx++);
                        dspResource.IsImportedFromWid    = r.GetBoolean(idx++);
                        dspResource.MwIdCanonical        = r.GetInt32(idx++);
                        _dspResources.Add(dspResource);
                    }
                }

            });

            FillLvDspResources();
        }

        private void FillLvDspResources()
        {
            lvDspResources.Items.Clear();
            _dspResources.ForEach(x =>
            {
                var item = lvDspResources.Items.Add(x.Id.ToString());
                item.SubItems.Add(x.DspResourceId);
                item.Tag = x;
            });
        }

        private void LoadDspResourceDetails(DspResource dspResource)
        {
            if(dspResource.Details != null)
            {
                return;
            }

            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = @"
                    select distinct 
	                      t1.Id			                        as DspResourcePk
	                    , t4.PeriodStartDate		            as PeriodStartDate
	                    , t4.Year					            as Year
	                    , isnull(t4.Quarter, 0)			        as Quarter
	                    , isnull(t4.Month, 0)					as Month
	                    , t4.FileType				            as FileType
	                    , t3.Id						            as MwId
	                    , isnull(t3.ObjId, 0)					as ObjId
	                    , isnull(t3.Wic, 0)				        as Wic
	                    , isnull(t3.ResourceTitle, '')			as ResourceTitle
	                    , isnull(t3.Title, '')					as Title
	                    , isnull(t3.ComposerAuthor, '')		    as Authors
	                    , isnull(t3.DisplayArtistName, '')		as Performers
	                    , isnull(t3.Iswc, '')					as Iswc
                    from DspResources t1
	                    join DspResourceToDdexReport t2 on t1.Id = t2.DspResourcePk
	                    join IdentMw t3 on t2.MwId = t3.Id
	                    join vDdexReportWithDates t4 on t2.DdexReportPk = t4.Id
                    where t1.Id = @dspResourcePk
                    order by t4.PeriodStartDate, t4.FileType
                ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@dspResourcePk", dspResource.Id);
                using (var r = cmd.ExecuteReader())
                {
                    dspResource.Details = new List<DspResourceDetailRecord>();
                    while (r.Read())
                    {
                        var o = new DspResourceDetailRecord();
                        var idx = 0;
                        o.DspResourcePk = r.GetInt32(idx++);
                        o.PeriodStartDate = r.GetDateTime(idx++);
                        o.Year = r.GetInt32(idx++);
                        o.Quarter = r.GetInt32(idx++);
                        o.Month = r.GetInt32(idx++);
                        o.FileType = r.GetString(idx++);
                        o.MwId = r.GetInt32(idx++);
                        o.ObjId = r.GetInt32(idx++);
                        o.Wic = r.GetInt32(idx++);
                        o.ResourceTitle = r.GetString(idx++);
                        o.Title = r.GetString(idx++);
                        o.Authors = r.GetString(idx++);
                        o.Performers = r.GetString(idx++);
                        o.Iswc = r.GetString(idx++);

                         dspResource.Details.Add(o);
                    }

                }

            });
        }

        private void UpdateWbResourceMetaData(DspResource dspResource)
        {
            var helper = new DspResourceAnalyserHelper(dspResource);
            wbResourceMetaData.DocumentText = helper.GetHtml();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void lvDspResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvDspResources.SelectedItems.Count == 0)
            {
                return;
            }
            var item = lvDspResources.SelectedItems[0];
            var dspResource = (DspResource)item.Tag;
            LoadDspResourceDetails(dspResource);
            UpdateWbResourceMetaData(dspResource);
        }
    }
}
