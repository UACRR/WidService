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
    public partial class UcMainAuthors : UserControl
    {
        public class Author
        {
            public int GroupId { get; set; }
            public string GroupName { get; set; }
            public string AuthorName { get; set; }
            public int CustId { get; set; }
            public string IpBaseNr { get; set; }
            public int IpNameNr { get; set; }
        }

        private List<Author> _authors;

        public UcMainAuthors()
        {
            InitializeComponent();
        }

        private void UcMainAuthors_Load(object sender, EventArgs e)
        {
            lvRightHolders.Columns.Add("Група", 100);
            lvRightHolders.Columns.Add("Автор/Правовласник", 300);
            lvRightHolders.Columns.Add("CustId", 100);
            lvRightHolders.Columns.Add("IpBaseNr", 100);
            lvRightHolders.Columns.Add("IpNameNr", 100);
        }
        public void RefreshControls()
        {
            _authors = new List<Author>();
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMainAuthors";
                cmd.Parameters.AddWithValue("@filter", tbSearch.Text);
                using(var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        _authors.Add(new Author
                        {
                            GroupId = r.GetInt32(0),
                            GroupName = r.GetString(1),
                            AuthorName = r.GetString(2),
                            CustId = r.GetInt32(3),
                            IpBaseNr = r.GetString(4),
                            IpNameNr = r.GetInt32(5),
                        });
                    }
                }
            });

            lvRightHolders.Items.Clear();
            _authors.ForEach(x =>
            {
                var item = lvRightHolders.Items.Add(x.GroupName);
                item.SubItems.Add(x.AuthorName);
                item.SubItems.Add(x.CustId.ToString());
                item.SubItems.Add(x.IpBaseNr);
                item.SubItems.Add(x.IpNameNr.ToString());
                item.Tag = x;
            });

            btnShowGroup.Enabled = lvRightHolders.SelectedItems.Count > 0;
        }

        private void btnShowGroup_Click(object sender, EventArgs e)
        {
            var rightHolder = (Author)lvRightHolders.SelectedItems[0].Tag;
            var form = new FormWidSubmit(WidSubmGroup.FromDb(rightHolder.GroupId), rightHolder.CustId);
            form.ShowDialog();
        }

        private void lvRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnShowGroup.Enabled = lvRightHolders.SelectedItems.Count > 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            var msg =
                "В якості УМОВИ можна вказати одне з наступного:\r\n\r\n" +
                "(а) Код правовласника в СМАРТІ (CustId)\r\n\r\n" +
                "(б) Код правовласника в IPI (IpBaseNr)\r\n\r\n" +
                "(в) Код імені правовласника в IPI (IpNameNr)\r\n\r\n" +
                "(г) Точну назву юридичної особи або прізвище автора в IPI\r\n\r\n" +
                "(д) Шаблон назви юридичної особи або прізвища автора в IPI з використанням символа %, наприклад,\r\n\r\n" +
                "    BEBESH% - починається з BEBESH,\r\n\r\n" +
                "    %SHKO - закінчується на SHKO,\r\n\r\n" +
                "    %BESH% - містить BESH."
            ;
            MessageBox.Show(msg, "Умова вибора правовласника", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
