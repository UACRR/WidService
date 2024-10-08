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
    public partial class UcMisicWorkInfo : UserControl
    {
        private int _wic;
        public UcMisicWorkInfo()
        {
            InitializeComponent();
        }

        private Label AddLabel(FlowLayoutPanel panel, string text, bool shouldHighlight = false)
        {
            var label = new Label
            {
                Text = text,
                BackColor = !shouldHighlight ? Color.Honeydew : Color.LightGray,
                AutoSize = true,
                Padding = new Padding(5, 5, 5, 5),
                Margin = new Padding(5, 5, 5, 5),
                BorderStyle = BorderStyle.FixedSingle,
            };
            panel.Controls.Add(label);
            return label;
        }

        private void SetEmpty(FlowLayoutPanel panel)
        {
            panel.Controls.Clear();
            panel.Controls.Add(new Label
            {
                Text = "Немає інформації",
                AutoSize = true,
                Padding = new Padding(5, 5, 5, 5),
                Margin = new Padding(5, 5, 5, 5),
            });
        }
        private void RefreshAltTtl(SqlCommand cmd)
        {
            cmd.CommandText = "select AltTtl from widAltTtl where Wic = @wic";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", _wic);
            using (var r = cmd.ExecuteReader())
            {
                if (r.HasRows)
                {
                    panelAltTtl.Controls.Clear();
                    while (r.Read())
                    {
                        AddLabel(panelAltTtl, r.GetString(0));
                    }
                }
                else
                {
                    SetEmpty(panelAltTtl);
                }
            }
        }

        private void RefreshIswc(SqlCommand cmd)
        {
            cmd.CommandText = "select Iswc, PrefIswc from widIswc where Wic = @wic";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", _wic);
            using (var r = cmd.ExecuteReader())
            {
                if (r.HasRows)
                {
                    panelIswc.Controls.Clear();
                    while (r.Read())
                    {
                        AddLabel(panelIswc, r.GetString(0), r.GetString(0) == r.GetString(1));
                    }
                }
                else
                {
                    SetEmpty(panelIswc);
                }
            }
        }

        private void RefreshShareHolders(SqlCommand cmd)
        {
            cmd.CommandText = SqlQueries.ShareHolders;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", _wic);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                panelShareHolders.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    var role = row.Field<string>("IpRole");
                    var fstName = row.Field<string>("FstName");
                    var lstName = row.Field<string>("LstName");
                    var perShare = string.Format("{0:0.00}", row.Field<decimal>("PerShare"));
                    var mecShare = string.Format("{0:0.00}", row.Field<decimal>("MecShare"));
                    var text = $"[ {role} ] {fstName} {lstName} ({perShare}/{mecShare})";
                    var label = AddLabel(panelShareHolders, text);
                    label.Cursor = Cursors.Hand;
                    label.Click += delegate (object sender, EventArgs e) {
                        var form = new FormRhSocs(row.Field<int>("ipId"), text);
                        form.ShowDialog();
                    };
                }
            }
            else
            {
                SetEmpty(panelShareHolders);
            }
        }

        private void RefreshPerformers(SqlCommand cmd)
        {
            cmd.CommandText = "select PerfArtistFstName, PerfArtistLstName from widArtist where Wic = @wic";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@wic", _wic);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                panelPerformers.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    var fstName = row.Field<string>("PerfArtistFstName");
                    var lstName = row.Field<string>("PerfArtistLstName");
                    var text = $"{fstName} {lstName}";
                    AddLabel(panelPerformers, text);
                }
            }
            else
            {
                SetEmpty(panelPerformers);
            }
        }
        public void RefreshAll(int wic)
        {
            panelMain.Visible = false;
            panelMain.Refresh();
            _wic = wic;
            var connectionString = ConfigurationManager.ConnectionStrings["SocWid"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                RefreshAltTtl(cmd);
                RefreshIswc(cmd);
                RefreshShareHolders(cmd);
                RefreshPerformers(cmd);
            };
            panelMain.Visible = true;
        }

     }
}
