using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class UcMainPublishedWorks : UserControl
    {
        public class Work
        {
            public int ObjId { get; set; }
            public int Wic { get; set; }
            public string Iswc { get; set; }
            public string LocalName { get; set; }
            public string Authors { get; set; }
            public string WidName { get; set; }
            public string SourceName { get; set; }
        }

        private List<Work> _works;

        public UcMainPublishedWorks()
        {
            InitializeComponent();
        }

        private void UcMainWorks_Load(object sender, EventArgs e)
        {
            lvWorks.Columns.Add("№пп", 60);
            lvWorks.Columns.Add("ObjId", 60);
            lvWorks.Columns.Add("Wic", 60);
            lvWorks.Columns.Add("Iswc", 100);
            lvWorks.Columns.Add("Локальна назва", 140);
            lvWorks.Columns.Add("Автори/Правовласники", 300);
            lvWorks.Columns.Add("Назва в WID", 140);
            lvWorks.Columns.Add("Походження", 100);
        }

        public void RefreshControls()
        {
            Cursor.Current = Cursors.WaitCursor;
            _works = new List<Work>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMainPublishedWorks";
                cmd.Parameters.AddWithValue("@filter", tbSearch.Text);
                cmd.Parameters.AddWithValue("@source", DBNull.Value);
                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        _works.Add(new Work
                        {
                            ObjId = r.GetInt32(0),
                            Wic = r.GetInt32(1),
                            Iswc = r.IsDBNull(2) ? "" : r.GetString(2),
                            LocalName = r.GetString(3),
                            Authors = r.IsDBNull(4) ? "" : r.GetString(4),
                            WidName = r.IsDBNull(5) ? "" : r.GetString(5),
                            SourceName = r.GetString(6),
                        });
                    }
                }
            });

            var seqNr = 1;
            lvWorks.Items.Clear();
            _works.ForEach(x =>
            {
                var item = lvWorks.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.ObjId.ToString());
                item.SubItems.Add(x.Wic.ToString());
                item.SubItems.Add(x.Iswc);
                item.SubItems.Add(x.LocalName);
                item.SubItems.Add(x.Authors);
                item.SubItems.Add(x.WidName);
                item.SubItems.Add(x.SourceName);
                item.Tag = x;
                seqNr++;
            });
            Cursor.Current = Cursors.Default;
        }

        private void btnRefreshFromMs_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateObjIdToWicFromMs";
                cmd.ExecuteNonQuery();
            });
            Cursor.Current = Cursors.Default;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void btnProcessDsi_Click(object sender, EventArgs e)
        {
            var form = new FormDciSearchInMs();
            form.ShowDialog();
        }
    }
}
