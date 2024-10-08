using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidViewer
{
    public partial class FormMain : Form
    {
        private UcMisicWorkInfo _ucMisicWorkInfo;
        private UcRightHolderInfo _ucRightHolderInfo;
        private UcPerformerInfo _ucPerformerInfo;
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {

            _ucMisicWorkInfo = new UcMisicWorkInfo
            {
                Dock = DockStyle.Fill,
                Visible = false,
            };
            _ucRightHolderInfo = new UcRightHolderInfo
            {
                Dock = DockStyle.Fill,
                Visible = false,
            };
            _ucPerformerInfo = new UcPerformerInfo
            {
                Dock = DockStyle.Fill,
                Visible = false,
            };

            cbEntityType.Items.Add("Музичні твори");
            cbEntityType.Items.Add("Правовласники");
            cbEntityType.Items.Add("Виконавці");
            cbEntityType.SelectedIndex = 0;

            cbRowCount.Items.Add("10");
            cbRowCount.Items.Add("50");
            cbRowCount.Items.Add("100");
            cbRowCount.SelectedIndex = 0;

            cbFilter.Items.Add("співпадають з");
            cbFilter.Items.Add("починаються з");
            cbFilter.Items.Add("подібні до");
            cbFilter.Items.Add("задовільняють патерну");
            cbFilter.Items.Add("мають код");
            cbFilter.SelectedIndex = 4;

            tbFilter.Text = "982986";

            RefreshEntityList();

        }

        private void RefreshMusicWorkList()
        {
            lvEntityList.BeginUpdate();

            lvEntityList.Columns.Clear();
            lvEntityList.Columns.Add("№пп", 40);
            lvEntityList.Columns.Add("Код", 80);
            lvEntityList.Columns.Add("Назва", 240);

            var connectionString = ConfigurationManager.ConnectionStrings["SocWid"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                if (cbFilter.SelectedIndex < 4)
                {
                    var oper = cbFilter.SelectedIndex == 0 ? "=" : "like";
                    var paramValue = cbFilter.SelectedIndex == 0 ? tbFilter.Text :
                        cbFilter.SelectedIndex == 1 ? $"{tbFilter.Text}%" :
                        cbFilter.SelectedIndex == 2 ? $"%{tbFilter.Text}%" :
                                                                    tbFilter.Text;
                    cmd.CommandText = $"select top {cbRowCount.Text} Wic, WrkTtl from widTitle where WrkTtl {oper} @wrkTtl";
                    cmd.Parameters.AddWithValue("@wrkTtl", paramValue);
                }
                else
                {
                    cmd.CommandText = $"select Wic, WrkTtl from widTitle where Wic = @wic";
                    var wic = tbFilter.Text;
                    try
                    {
                        cmd.Parameters.AddWithValue("@wic", int.Parse(wic));
                    }
                    catch
                    {
                        tbFilter.Text = "";
                        cmd.Parameters.AddWithValue("@wic", 0);
                    }
                }
                using (var r = cmd.ExecuteReader())
                {
                    lvEntityList.Items.Clear();
                    int i = 1;
                    while (r.Read())
                    {
                        var item = lvEntityList.Items.Add(i.ToString());
                        item.SubItems.Add(r.GetInt32(0).ToString());
                        item.SubItems.Add(r.GetString(1));
                        i++;
                    }
                }
            };

            lvEntityList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvEntityList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvEntityList.EndUpdate();
        }

        private void RefreshRightHolderList()
        {
            lvEntityList.BeginUpdate();

            lvEntityList.Columns.Clear();
            lvEntityList.Columns.Add("№пп", 40);
            lvEntityList.Columns.Add("Код", 80);
            lvEntityList.Columns.Add("Повне ім'я", 240);

            var connectionString = ConfigurationManager.ConnectionStrings["SocWid"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                if (cbFilter.SelectedIndex < 4)
                {
                    var oper = cbFilter.SelectedIndex == 0 ? "=" : "like";
                    var paramValue = cbFilter.SelectedIndex == 0 ? tbFilter.Text :
                        cbFilter.SelectedIndex == 1 ? $"{tbFilter.Text}%" :
                        cbFilter.SelectedIndex == 2 ? $"%{tbFilter.Text}%" :
                                                                    tbFilter.Text;
                    cmd.CommandText = $@"
                        select distinct top {cbRowCount.Text} t2.IpNameNr, t2.FstName, t2.Name
                        from widIntrPty t1
                            join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
                        where t2.FstName {oper} @name or t2.Name {oper} @name
                        order by t2.FstName, t2.Name,  t2.IpNameNr
                    ";
                    cmd.Parameters.AddWithValue("@name", paramValue);
                }
                else
                {
                    cmd.CommandText = $@"
                        select distinct top {cbRowCount.Text} t2.IpNameNr, t2.FstName, t2.Name
                        from widIntrPty t1
                            join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
                        where t1.Wic = @wic
                        order by t2.FstName, t2.Name,  t2.IpNameNr
                    ";
                    var wic = tbFilter.Text;
                    try
                    {
                        cmd.Parameters.AddWithValue("@wic", int.Parse(wic));
                    }
                    catch
                    {
                        tbFilter.Text = "";
                        cmd.Parameters.AddWithValue("@wic", 0);
                    }
                }
                using (var r = cmd.ExecuteReader())
                {
                    lvEntityList.Items.Clear();
                    int i = 1;
                    while (r.Read())
                    {
                        var item = lvEntityList.Items.Add(i.ToString());
                        item.SubItems.Add(r.GetString(0));
                        item.SubItems.Add($"{r.GetString(1)} {r.GetString(2)}");
                        i++;
                    }
                }
            };

            lvEntityList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvEntityList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvEntityList.EndUpdate();
        }

        private void RefreshPerformerList()
        {
            lvEntityList.BeginUpdate();

            lvEntityList.Columns.Clear();
            lvEntityList.Columns.Add("№пп", 40);
            lvEntityList.Columns.Add("Повне ім'я", 240);
            lvEntityList.Columns.Add("Перша частина", 0).Width = 0;
            lvEntityList.Columns.Add("Друга частина", 0).Width = 0;

            var connectionString = ConfigurationManager.ConnectionStrings["SocWid"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                if (cbFilter.SelectedIndex < 4)
                {
                    var oper = cbFilter.SelectedIndex == 0 ? "=" : "like";
                    var paramValue = cbFilter.SelectedIndex == 0 ? tbFilter.Text :
                        cbFilter.SelectedIndex == 1 ? $"{tbFilter.Text}%" :
                        cbFilter.SelectedIndex == 2 ? $"%{tbFilter.Text}%" :
                                                                    tbFilter.Text;
                    cmd.CommandText = $"select distinct top {cbRowCount.Text} PerfArtistFstName, PerfArtistLstName\r\n" +
                        "from widArtist\r\n" +
                        $"where PerfArtistLstName {oper} @name or PerfArtistFstName {oper} @name\r\n" +
                        "order by PerfArtistFstName, PerfArtistLstName\r\n";
                    cmd.Parameters.AddWithValue("@name", paramValue);
                }
                else
                {
                    cmd.CommandText = $"select distinct top {cbRowCount.Text} PerfArtistFstName, PerfArtistLstName\r\n" +
                        "from widArtist\r\n" +
                        $"where Wic = @wic\r\n" +
                        "order by PerfArtistFstName, PerfArtistLstName\r\n";
                    var wic = tbFilter.Text;
                    try
                    {
                        cmd.Parameters.AddWithValue("@wic", int.Parse(wic));
                    }
                    catch
                    {
                        tbFilter.Text = "";
                        cmd.Parameters.AddWithValue("@wic", 0);
                    }
                }
                using (var r = cmd.ExecuteReader())
                {
                    lvEntityList.Items.Clear();
                    int i = 1;
                    while (r.Read())
                    {
                        var item = lvEntityList.Items.Add(i.ToString());
                        item.SubItems.Add($"{r.GetString(0)} {r.GetString(1)}");
                        item.SubItems.Add($"{r.GetString(0)}");
                        item.SubItems.Add($"{r.GetString(1)}");
                        i++;
                    }
                }
            };

            lvEntityList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            lvEntityList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            lvEntityList.EndUpdate();
        }

        private void RefreshEntityList()
        {
            switch(cbEntityType.SelectedIndex)
            {
                case 0:
                    RefreshMusicWorkList();
                    break;
                case 1:
                    RefreshRightHolderList();
                    break;
                case 2:
                    RefreshPerformerList();
                    break;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RefreshEntityList();
            Cursor.Current = Cursors.Default;
        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                RefreshEntityList();
                Cursor.Current = Cursors.Default;
            }
        }

        private void lvEntityList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ucMisicWorkInfo.Visible = false;
            //_ucMisicWorkInfo.RefreshA=();
            var selectedItem = lvEntityList.SelectedItems.Count > 0 ? lvEntityList.SelectedItems[0] : null;
            if(selectedItem != null)
            {
                switch (cbEntityType.SelectedIndex)
                {
                    case 0:
                        
                         var mwWic = int.Parse(selectedItem.SubItems[1].Text);
                        _ucMisicWorkInfo.RefreshAll(mwWic);
                        _ucMisicWorkInfo.Visible = true;
                        break;
                    case 1:
                         var ipNameNr = int.Parse(selectedItem.SubItems[1].Text);
                        _ucRightHolderInfo.RefreshAll(ipNameNr);
                        _ucRightHolderInfo.Visible = true;
                        break;
                    case 2:
                        _ucPerformerInfo.RefreshAll(selectedItem.SubItems[2].Text, selectedItem.SubItems[3].Text);
                        _ucPerformerInfo.Visible = true;
                        break;
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void cbEntityType_SelectedIndexChanged(object sender, EventArgs e)
        {
            split.Panel2.Controls.Clear();
            lvEntityList.Items.Clear();
            switch(cbEntityType.SelectedIndex)
            {
                case 0:
                    _ucMisicWorkInfo.Visible = false;
                    split.Panel2.Controls.Add(_ucMisicWorkInfo);
                    break;
                case 1:
                    _ucRightHolderInfo.Visible = false;
                    split.Panel2.Controls.Add(_ucRightHolderInfo);
                    break;
                case 2:
                    _ucPerformerInfo.Visible = false;
                    split.Panel2.Controls.Add(_ucPerformerInfo);
                    break;
            }
        }
    }
}
