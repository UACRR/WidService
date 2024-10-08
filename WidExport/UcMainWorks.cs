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
    public partial class UcMainWorks : UserControl
    {
        public class Work
        {
            public int GroupId { get; set; }
            public string GroupName { get; set; }
            public int ObjId { get; set; }
            public string LocalName { get; set; }
            public string Authors { get; set; }
            public string Performers { get; set; }
            public int CustId { get; set; }
        }

        private List<Work> _works;

        public UcMainWorks()
        {
            InitializeComponent();
        }

        private void UcMainWorks_Load(object sender, EventArgs e)
        {
            lvWorks.Columns.Add("Код групи", 60);
            lvWorks.Columns.Add("Назва групи", 100);
            lvWorks.Columns.Add("Код твору", 100);
            lvWorks.Columns.Add("Назва твору", 100);
            lvWorks.Columns.Add("Автори/Правовласники", 300);
            lvWorks.Columns.Add("Виконавці", 300);
        }

        public void RefreshControls()
        {
            _works = new List<Work>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMainWorks";
                cmd.Parameters.AddWithValue("@filter", tbSearch.Text);
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        _works.Add(new Work
                        {
                            GroupId = r.GetInt32(0),
                            GroupName = r.GetString(1),
                            ObjId = r.GetInt32(2),
                            LocalName = r.GetString(3),
                            Authors = r.GetString(4),
                            Performers = r.GetString(5),
                            CustId = r.GetInt32(6),
                        });
                    }
                }
            });

            lvWorks.Items.Clear();
            var seqNr = 1;
            _works.ForEach(x =>
            {
                var item = lvWorks.Items.Add(seqNr.ToString());
                item.SubItems.Add(x.GroupName);
                item.SubItems.Add(x.ObjId.ToString());
                item.SubItems.Add(x.LocalName);
                item.SubItems.Add(x.Authors);
                item.SubItems.Add(x.Performers);
                item.Tag = x;
                seqNr++;
            });

            btnShowGroup.Enabled = lvWorks.SelectedItems.Count > 0;
        }

        private void btnShowGroup_Click(object sender, EventArgs e)
        {
            var work = (Work)lvWorks.SelectedItems[0].Tag;
            var form = new FormWidSubmit(WidSubmGroup.FromDb(work.GroupId), work.CustId, work.ObjId);
            form.Show();
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShowGroup.Enabled = lvWorks.SelectedItems.Count > 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void bntInfo_Click(object sender, EventArgs e)
        {
            var msg =
                "В якості УМОВИ можна вкахзати одне з наступного:\r\n\r\n" +
                "(а) Код ISWC\r\n\r\n" +
                "(б) Код твору в СМАРТІ (ObjId)\r\n\r\n" +
                "(в) Код твору в WID (Wic)\r\n\r\n" +
                "(г) Точну головну назву твору в СМАРТІ\r\n\r\n" +
                "(д) Шаблон назви твору в СМАРТІ з використанням символа %, наприклад,\r\n\r\n" +
                "    НЕ ЗАЧИНЯ В СПАЛЬНІ% - починається з НЕ ЗАЧИНЯ В СПАЛЬНІ,\r\n\r\n" +
                "    %В СПАЛЬНІ ВІКНО - закінчується на В СПАЛЬНІ ВІКНО,\r\n\r\n" +
                "    %ЗАЧИНЯ В СПАЛЬНІ% - містить ЗАЧИНЯ В СПАЛЬНІ."
            ;
            MessageBox.Show(msg, "Умова вибора правовласника", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
