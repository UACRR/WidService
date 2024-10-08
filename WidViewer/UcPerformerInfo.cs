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
    public partial class UcPerformerInfo : UserControl
    {
        private string _fstName;
        private string _lstName;
        public UcPerformerInfo()
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
        private void RefreshMusicWorks(SqlCommand cmd)
        {
            cmd.CommandText = "select top 500 t2.Wic, t2.WrkTtl\r\n" +
                "from widArtist t1\r\n" +
                "    join widTitle t2 on t1.Wic = t2.Wic\r\n" +
                "where t1.PerfArtistFstName = @PerfArtistFstName and t1.PerfArtistLstName = @PerfArtistLstName\r\n" +
                "order by t2.WrkTtl\r\n";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@PerfArtistFstName", _fstName);
            cmd.Parameters.AddWithValue("@PerfArtistLstName", _lstName);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                panelMusicWorks.Controls.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    var title = row.Field<string>("WrkTtl");
                    var label = AddLabel(panelMusicWorks, title);
                    label.Cursor = Cursors.Hand;
                    label.Click += delegate (object sender, EventArgs e) {
                        var form = new FormMusicWorkInfo(row.Field<int>("Wic"), title);
                        form.ShowDialog();
                    };
                }
            }
            else
            {
                SetEmpty(panelMusicWorks);
            }
        }
        public void RefreshAll(string fstName, string lstName)
        {
            _fstName = fstName;
            _lstName = lstName;
            var connectionString = ConfigurationManager.ConnectionStrings["SocWid"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                RefreshMusicWorks(cmd);
            };
        }
    }
}
