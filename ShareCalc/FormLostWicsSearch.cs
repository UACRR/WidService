using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ShareCalc.FormLostWicsSearch;

namespace ShareCalc
{
    public partial class FormLostWicsSearch : System.Windows.Forms.Form
    {
        internal class WidWork
        {
            internal int Wic        { get; set; }
            internal string Name    { get; set; }
            internal string Authors { get; set; }
        }

        internal class MsWork
        {
            internal int ObjId      { get; set; }
            internal string Name    { get; set; }
            internal string Authors { get; set; }
        }

        private List<WidWork> _widWorks;
        private List<MsWork> _msWorks;

        public FormLostWicsSearch()
        {
            InitializeComponent();
        }

        private void FormLostWicsSearch_Load(object sender, EventArgs e)
        {
            Configure();
            LoadWidWorks();
            FillWidWorks();
        }

        private void Configure()
        {
            lvWid.FullRowSelect = true;
            lvWid.GridLines = true;
            lvWid.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvWid.MultiSelect = false;
            lvWid.View = View.Details;
            lvWid.Columns.Clear();
            lvWid.Columns.Add("№", 60);
            lvWid.Columns.Add("WIC", 100);
            lvWid.Columns.Add("Назва", 200);
            lvWid.Columns.Add("Автори", 500);

            lvMs.FullRowSelect = true;
            lvMs.GridLines = true;
            lvMs.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvMs.MultiSelect = false;
            lvMs.View = View.Details;
            lvMs.Columns.Clear();
            lvMs.Columns.Add("№", 60);
            lvMs.Columns.Add("ObjId", 100);
            lvMs.Columns.Add("Назва", 200);
            lvMs.Columns.Add("Автори", 500);
        }

        private void LoadWidWorks()
        {
            _widWorks = new List<WidWork>();
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = @"
                    select t2.Wic, t2.WrkTtl, t3.Composers
                    from UacrrLostWics t1
	                    join SocWid..WidTitle t2 on t1.Wic = t2.Wic
	                    join MediaService..vWidComposerAggInv t3 on t1.Wic = t3.Wic
                    where t1.ObjId = 0
                    order by t2.WrkTtl
                ";
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var widWork = new WidWork();
                        widWork.Wic     = r.GetInt32(0);
                        widWork.Name    = r.GetString(1);
                        widWork.Authors = r.GetString(2);
                        _widWorks.Add(widWork);
                    }
                }
            });
        }

        private void FillWidWorks()
        {
            lvWid.Items.Clear();
            var rowIdx = 1;
            _widWorks.ForEach(work =>
            {
                var item = new ListViewItem(rowIdx.ToString());
                item.SubItems.Add(work.Wic.ToString());
                item.SubItems.Add(work.Name);
                item.SubItems.Add(work.Authors);
                item.Tag = work;
                lvWid.Items.Add(item);
                rowIdx++;
            });
        }

        private void PreLoadMsWorks()
        {
            var widWork = (WidWork)lvWid.SelectedItems[0].Tag;

            _msWorks = new List<MsWork>();
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = @"
                    select ObjId, Name, Composers
                    from MediaService..MediaTrack
                    where isnull(Name, '') <> ''
	                    and MediaService.dbo.ClrTranslitFromUkrToLat(Name) = @name
                ";
                cmd.Parameters.AddWithValue("@name", widWork.Name);
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var msWork = new MsWork();
                        msWork.ObjId     = r.GetInt32(0);
                        msWork.Name    = r.GetString(1);
                        msWork.Authors = r.GetString(2);
                        _msWorks.Add(msWork);
                    }
                }
            });
        }

        private void LoadMsWorks()
        {
            _msWorks = new List<MsWork>();
            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = @"
                    select ObjId, Name, composers
                    from MediaService..MediaTrack
                    where Name like @name
                ";
                cmd.Parameters.AddWithValue("@name", $"%{tbSearchName.Text}%");
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        var msWork = new MsWork();
                        msWork.ObjId     = r.GetInt32(0);
                        msWork.Name    = r.GetString(1);
                        msWork.Authors = r.IsDBNull(2) ? "" : r.GetString(2);
                        _msWorks.Add(msWork);
                    }
                }
            });
        }

        private void FillMsWorks()
        {
            lvMs.Items.Clear();
            var rowIdx = 1;
            _msWorks.ForEach(work =>
            {
                if(tbSearchAuthor.Text.Trim() == "" || work.Authors.ToUpper().Contains(tbSearchAuthor.Text.ToUpper()))
                {
                    var item = new ListViewItem(rowIdx.ToString());
                    item.SubItems.Add(work.ObjId.ToString());
                    item.SubItems.Add(work.Name);
                    item.SubItems.Add(work.Authors);
                    lvMs.Items.Add(item);
                    rowIdx++;
                }
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadMsWorks();
            FillMsWorks();
        }

        private void lvWid_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvMs.Items.Clear();
            if (lvWid.SelectedItems.Count == 0)
                return;

            //PreLoadMsWorks();
            //FillMsWorks();
        }

        private void tbSearchAuthor_TextChanged(object sender, EventArgs e)
        {
            FillMsWorks();
        }
    }
}
