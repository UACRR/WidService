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
    public partial class FormRhSocs : Form
    {
        private int _ipNameNr;
        private string _rh;
        public FormRhSocs(int ipNameNr, string rh)
        {
            _ipNameNr = ipNameNr;
            _rh = rh;

            InitializeComponent();
        }

        private void FormRhSocs_Load(object sender, EventArgs e)
        {
            timerLoad.Enabled = true;
            Text = $"{Text} {_rh}";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;

            var connectionString = ConfigurationManager.ConnectionStrings["SocWid"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = SqlQueries.ShareHolderSocieties;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ipNameNr", _ipNameNr);
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                
                lvSocs.BeginUpdate();
                foreach (DataRow row in dt.Rows)
                {
                    var item = lvSocs.Items.Add(row.Field<string>("SocId"));

                    item.SubItems.Add(row.Field<string>("Shr"));
                    item.SubItems.Add(row.Field<string>("CreClass"));
                    item.SubItems.Add(row.Field<string>("Rol"));
                    item.SubItems.Add(row.Field<string>("Rgt"));
                    item.SubItems.Add(row.Field<string>("TisNr")); 
                    item.SubItems.Add(row.Field<string>("Tisan"));
                }
                lvSocs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvSocs.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                lvSocs.EndUpdate();
                Cursor.Current = Cursors.Default;
            };
        }
    }
}
