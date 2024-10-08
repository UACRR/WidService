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
    public partial class UcMainStatistics : UserControl
    {
        public class Statistics
        {
            public int Total { get; set; }
            public int NotProcessed { get; set; }
            public int NeedNotSubmit { get; set; }
            public int Submitted { get; set; }
        }

        private Statistics _statistics;

        public UcMainStatistics()
        {
            InitializeComponent();
        }

        private void UcMainWorks_Load(object sender, EventArgs e)
        {
            lvStat.Columns.Add("Назва", 400);
            lvStat.Columns.Add("Кількість", 100).TextAlign = HorizontalAlignment.Right;
        }

        public void RefreshControls()
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spMainStatistics";
                using(var r = cmd.ExecuteReader())
                {
                    r.Read();
                    _statistics = new Statistics
                    {
                        Total = r.GetInt32(0),
                        NotProcessed = r.GetInt32(1),
                        NeedNotSubmit = r.GetInt32(2),
                        Submitted = r.GetInt32(3),
                    };
                }
            });

            lvStat.Items.Clear();

            var item = lvStat.Items.Add("Загалом в групах");
            item.SubItems.Add(_statistics.Total.ToString());

            item = lvStat.Items.Add("Стан не визначено");
            item.SubItems.Add(_statistics.NotProcessed.ToString());

            item = lvStat.Items.Add("Не потребує передачі");
            item.SubItems.Add(_statistics.NeedNotSubmit.ToString());

            item = lvStat.Items.Add("Передано");
            item.SubItems.Add(_statistics.Submitted.ToString());
        }

        private void btnRefreshStatistics_Click(object sender, EventArgs e)
        {
            RefreshControls();
        }
    }
}
