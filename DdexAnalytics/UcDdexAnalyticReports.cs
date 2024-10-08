using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexAnalytics
{
    public partial class UcDdexAnalyticReports : UserControl
    {
        private class ReportDesignInfo
        {
            public string Title { get; set; }
            public int[] ColWidth { get; set; }
        }

        private ReportDesignInfo[] _reportDesignInfo =
        {
            new ReportDesignInfo
            {
                Title = "Роялті за період",
                ColWidth = new int[] {60, 60, 60, 120, 100, 120, 100, 100, 100}
            },
            new ReportDesignInfo
            {
                Title = "Роялті за період для тестування",
                ColWidth = new int[] {60, 60, 60, 120, 100, 120, 100, 100, 100}
            },
        };

        public UcDdexAnalyticReports()
        {
            InitializeComponent();
        }

        private void UcDdexAnalyticReports_Load(object sender, EventArgs e)
        {
            SetupControls();
            //BuildReport();
        }

        private void SetupControls()
        {
            lvReportList.View = View.Details;
            lvReportList.FullRowSelect = true;
            lvReportList.GridLines = true;
            lvReportList.HeaderStyle = ColumnHeaderStyle.None;
            lvReportList.MultiSelect = false;
            lvReportList.Columns.Add("").Width = 200;
            _reportDesignInfo.ToList().ForEach(x => {
                var item = lvReportList.Items.Add(x.Title);
                item.Tag = x;
            });

            lvReport.View = View.Details;
            lvReport.FullRowSelect = true;
            lvReport.GridLines = true;
            lvReport.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvReport.MultiSelect = false;

            panelRight.Visible = false;
            btnShowReport.Visible = lvReportList.SelectedItems.Count > 0;
        }

        private void BuildReport(ReportDesignInfo reportDesignInfo)
        {
            var sql = File.ReadAllText(@".\Sql\Procedures\DspRoyaltyPerPeriod.sql");
            var connString = ConfigurationManager.ConnectionStrings["Ddex"].ConnectionString;
            try
            {
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using(var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        using (var r = cmd.ExecuteReader())
                        {
                            lvReport.Items.Clear();
                            lvReport.Columns.Clear();
                            for(var idx = 0; idx < r.FieldCount; idx++)
                            {
                                var col = lvReport.Columns.Add(r.GetName(idx));
                                col.Width = reportDesignInfo.ColWidth[idx];
                            }

                            while(r.Read())
                            {
                                var item = lvReport.Items.Add(r.GetValue(0).ToString());
                                for(var idx = 1; idx < r.FieldCount; idx++)
                                {
                                    item.SubItems.Add(r.GetValue(idx).ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if(lvReportList.SelectedItems.Count == 0)
            {
                return;
            }

            var reportDesignInfo = (ReportDesignInfo)lvReportList.SelectedItems[0].Tag;
            BuildReport(reportDesignInfo);
            panelRight.Visible = true;
            labReport.Text = reportDesignInfo.Title;
        }

        private void lvReportList_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelRight.Visible = false;
            btnShowReport.Visible = lvReportList.SelectedItems.Count > 0;
        }

        private void btnCopyReport_Click(object sender, EventArgs e)
        {
            var sw = new StringWriter();
            for(int idx = 0; idx < lvReport.Columns.Count; idx++)
            {
                sw.Write(lvReport.Columns[idx].Text);
                if(idx < lvReport.Columns.Count - 1)
                {
                    sw.Write('\t');
                }
            }
            sw.Write("\r\n");

            foreach(ListViewItem item in lvReport.Items)
            {
                sw.Write(item.Text);
                for(int idx = 0; idx < item.SubItems.Count; idx++)
                {
                    sw.Write(item.SubItems[idx].Text);
                    if(idx < item.SubItems.Count - 1)
                    {
                        sw.Write('\t');
                    }
                }
                sw.Write("\r\n");
            }


            Clipboard.SetText(sw.ToString());
        }
    }
}
