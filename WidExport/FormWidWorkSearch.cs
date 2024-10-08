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
    public partial class FormWidWorkSearch : Form
    {
        public int Wic { get; private set; }
        public string Iswc { get; private set; }

        public FormWidWorkSearch()
        {
            InitializeComponent();
        }

        private void FormWidWorkSearch_Load(object sender, EventArgs e)
        {
            lvWorks.Columns.Add("Wic", 80);
            lvWorks.Columns.Add("Iswc", 80);
            lvWorks.Columns.Add("Назва", 160);
            lvWorks.Columns.Add("Автори", 200);
            lvWorks.Columns.Add("Виконавці", 200);

            btnApply.Enabled = false;
            btnApplyIswc.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandText = @"
                        select t1.Wic, t1.Iswc, t2.WrkTtl, t3.Authors, t4.Performers
                        from SocWid..WidIswc t1
                            join SocWid..WidTitle t2 on t1.Wic = t2.Wic
                            left join vWidAuthorAgg t3 on t2.Wic = t3.Wic
                            left join vWidPerformerAgg t4 on t3.Wic = t4.Wic
                        where t1.Iswc = @Iswc
                    ";
                    var iswc = tbIswc.Text.Replace(".", "").Replace("-", "");
                    cmd.Parameters.AddWithValue("@Iswc", iswc);
                    using (var r = cmd.ExecuteReader())
                    {
                        lvWorks.Items.Clear();
                        while (r.Read())
                        {
                            var item = lvWorks.Items.Add(r.GetInt32(0).ToString());
                            item.SubItems.Add(r.GetString(1));
                            item.SubItems.Add(r.GetString(2));
                            item.SubItems.Add(r.IsDBNull(3) ? "" : r.GetString(3));
                            item.SubItems.Add(r.IsDBNull(4) ? "" : r.GetString(4));
                        }
                    }
                });

                if (lvWorks.Items.Count > 0)
                {
                    lvWorks.Items[0].Selected = true;
                    btnApply.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Твори не знайдені", "Пошук твору в WID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btnApply.Enabled = false;
                    btnApplyIswc.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Пошук твору в WID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lvWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = lvWorks.SelectedItems.Count > 0;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Wic = int.Parse(lvWorks.SelectedItems[0].Text);
            Iswc = lvWorks.SelectedItems[0].SubItems[1].Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Wic = 0;
            Iswc = "";
            Close();
        }

        private void btnApplyIswc_Click(object sender, EventArgs e)
        {
            Wic = 0;
            Iswc = tbIswc.Text.Replace(".", "").Replace("-", "");
            Close();
        }
    }
}
