using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class FormWidSubmGroupSelectEdit : Form
    {

        private int _groupId { get; set; }

        public FormWidSubmGroupSelectEdit(int groupId)
        {
            InitializeComponent();
            _groupId = groupId;
        }

        private void FormWidSubmGroupSelectEdit_Load(object sender, EventArgs e)
        {
            lvGroups.Columns.Add("№пп", 60);
            lvGroups.Columns.Add("Код", 60);
            lvGroups.Columns.Add("Назва", 100);
            lvGroups.Columns.Add("Статус", 60);

            FillGroups();
            RefreshControls();
        }

        public int GetGroupId() => _groupId;

        private void FillGroups()
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupSelect";
                using (var r = cmd.ExecuteReader())
                {
                    lvGroups.Items.Clear();
                    while (r.Read())
                    {
                        AddItem(r);
                    }
                }
            });
        }

        private void AddItem(SqlDataReader r)
        {
            var item = lvGroups.Items.Add(r.GetInt32(1).ToString());
            item.SubItems.Add(r.GetInt32(0).ToString());
            item.SubItems.Add(r.GetString(2));
            item.SubItems.Add(r.GetInt32(3).ToString());
            item.Tag = r.GetInt32(0);
        }

        private void RefreshControls()
        {
            btnSelect.Enabled = lvGroups.SelectedItems.Count > 0;
            FillParties();
        }

        private void FillParties()
        {
            lvParties.Items.Clear();
            
            Helpers.RunSqlSocWidSubmit(cmd => {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupPartySelect";
                cmd.Parameters.AddWithValue("@groupId", _groupId);
                using (var r = cmd.ExecuteReader())
                {
                    lvParties.Items.Clear();
                    while (r.Read())
                    {
                        lvParties.Items.Add(r.GetString(5));
                    }
                }
            });
        }



        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupAdd";
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    AddItem(r);
                }
            });
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (
                DialogResult.Yes != MessageBox.Show(
                    "Видалення групи може призвести до втрати важливої інформації. Видалити?",
                    "Видалення групи",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                return;
            }
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupDeleteLast";
                cmd.ExecuteNonQuery();
                lvGroups.Items.Remove(lvGroups.Items[lvGroups.Items.Count - 1]);
            });
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            _groupId = (int)lvGroups.SelectedItems[0].Tag;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void lvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            _groupId = (int)lvGroups.SelectedItems[0].Tag;
            RefreshControls();
        }

        private void lvGroups_DoubleClick(object sender, EventArgs e)
        {
            if(lvGroups.SelectedItems.Count == 0)
            {
                return;
            }
            _groupId = (int)lvGroups.SelectedItems[0].Tag;
            Close();
        }
    }
}
