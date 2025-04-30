using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class UcReportLineDistribution : UserControl
    {
        private class Distribution
        {
            public string RightHolder { get; set; }
            public string IpBaseNr { get; set; }
            public decimal WorkShare { get; set; }
            public decimal PayShare { get; set; }
            public string Soc { get; set; }
            public string AgreeNr { get; set; }
            public string AgreeStatus { get; set; }
            public string SubPublisher { get; set; }
        }

        private int _reportId;
        private int _lineNr;
        private List<Distribution> _distributions;

        private string _textToCopy = "";

        public UcReportLineDistribution()
        {
            InitializeComponent();
        }

        private void UcReportLineDistribution_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            lvDistribution.View = View.Details;
            lvDistribution.FullRowSelect = true;
            lvDistribution.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvDistribution.GridLines = true;
            lvDistribution.MultiSelect = false;

            lvDistribution.Columns.Add("Правовласник", 200);
            lvDistribution.Columns.Add("Код", 100);
            lvDistribution.Columns.Add("За твір %", 100);
            lvDistribution.Columns.Add("До виплати %", 100);
            lvDistribution.Columns.Add("Товариство", 100);
            lvDistribution.Columns.Add("Договір", 80);
            lvDistribution.Columns.Add("Статус договору", 120);
            lvDistribution.Columns.Add("Субвидавництво", 120);
        }

        public void Clear()
        {
            lvDistribution.Items.Clear();
        }

        public void Update(int reportId, int lineNr)
        {
            _reportId = reportId;
            _lineNr = lineNr;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectDistribution";
                cmd.Parameters.AddWithValue("@ReportId", _reportId);
                cmd.Parameters.AddWithValue("@lineNr", _lineNr);
                _distributions = new List<Distribution>();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (r.IsDBNull(19) || r.GetString(19) == "")
                        {
                            continue;
                        }

                        var distribution = new Distribution();
                        distribution.RightHolder = r.IsDBNull(19) ? "" : r.GetString(19);
                        distribution.IpBaseNr = r.IsDBNull(17) ? "" : r.GetString(17);
                        distribution.WorkShare = r.IsDBNull(20) ? 0 : r.GetDecimal(20);
                        distribution.PayShare = r.IsDBNull(21) ? 0 : r.GetDecimal(21);
                        distribution.Soc = r.IsDBNull(23) ? "" : r.GetString(23);
                        distribution.AgreeNr = r.IsDBNull(28) ? "" : r.GetString(28);
                        distribution.AgreeStatus = r.IsDBNull(29) ? "" : r.GetString(29);
                        distribution.SubPublisher = r.IsDBNull(29) ? "" : r.GetString(30);

                        _distributions.Add(distribution);
                    }
                }
            });

            var WorkShareTotal = 0M;
            var PayShareTotal = 0M;
            lvDistribution.Items.Clear();
            _distributions
                .OrderBy(x => x.RightHolder)
                .ToList()
                .ForEach(x =>
            {
                var item = lvDistribution.Items.Add(x.RightHolder);
                item.SubItems.Add(x.IpBaseNr);
                item.SubItems.Add(x.WorkShare.ToString());
                item.SubItems.Add(x.PayShare.ToString());
                item.SubItems.Add(x.Soc);
                item.SubItems.Add(x.AgreeNr);
                item.SubItems.Add(x.AgreeStatus);

                WorkShareTotal += x.WorkShare;
                PayShareTotal += x.PayShare;
            });

            if (lvDistribution.Items.Count > 0)
            {
                var item = lvDistribution.Items.Add("");

                item = lvDistribution.Items.Add("СУМА ПРОЦЕНТІВ");
                item.SubItems.Add("");
                item.SubItems.Add(WorkShareTotal.ToString());
                item.SubItems.Add(PayShareTotal.ToString());
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
            }

        }

        private void lvDistribution_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = lvDistribution.GetItemAt(e.X, e.Y);
                if (item == null)
                {
                    return;
                }
                var text = item.GetSubItemAt(e.X, e.Y).Text;
                _textToCopy = string.IsNullOrEmpty(text) ? "" : text;
                contextMenuStrip.Show(lvDistribution, new Point(e.X, e.Y), ToolStripDropDownDirection.BelowRight);
            }
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(_textToCopy))
            {
                Clipboard.SetText(_textToCopy);
            }
            else
            {
                Clipboard.Clear();
            }
        }
    }
}
