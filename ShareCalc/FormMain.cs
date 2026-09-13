using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareCalc
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvWorks.FullRowSelect = true;
            lvWorks.GridLines = true;
            lvWorks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvWorks.MultiSelect = false;
            lvWorks.View = View.Details;

            lvWorks.Columns.Clear();
            lvWorks.Columns.Add("#", 60);
            lvWorks.Columns.Add("Код", 60);
            lvWorks.Columns.Add("Назва", 200);
        }

        private void FillWorks()
        {
            var objId = 0;
            int.TryParse(tbFilter.Text, out objId);

            Helpers.RunSqlShareCalc(cmd =>
            {
                cmd.CommandText = @"
                    select top 1000 ObjId, Name
                    from MediaService..MediaTrack
                    where ObjId = @objId
                        or Name like @name
                    order by Name
                ";
                cmd.Parameters.AddWithValue("@objId", objId);
                cmd.Parameters.AddWithValue("@name", $"%{tbFilter.Text}%");
 
                using(var r = cmd.ExecuteReader())
                {
                    lvWorks.Items.Clear();
                    var idx = 1;
                    while(r.Read())
                    {
                        var item = new ListViewItem(idx.ToString());
                        item.SubItems.Add(r.GetInt32(0).ToString());
                        item.SubItems.Add(r.GetString(1));
                        item.Tag = r.GetInt32(0);
                        lvWorks.Items.Add(item);
                        idx++;
                    }
                }
            });
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                FillWorks();
            });
        }

        private void lvWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvWorks.SelectedItems.Count == 0)
            {
                ucShareCalc.Clear();
            }
            else
            {
                var item = lvWorks.SelectedItems[0];
                var objId = (int)item.Tag;
                var name = item.SubItems[2].Text;
                ucShareCalc.SetWork(objId, name);
            }
        }
    }
}
