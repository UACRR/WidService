using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RadioStationReports
{
    public partial class FormMainIntegrated : Form
    {
        public class CustomerItem
        {
            public int CustId { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
        }

        public class ReportItem
        {
            public int RegId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string FileName { get; set; }
        }

        public class ReportLineItem
        {
            public int LineNr { get; set; }
            public string Name { get; set; }
            public string Performer { get; set; }
            public string MisicAuthor { get; set; }
            public string TextAuthor { get; set; }
            public TimeSpan Duration { get; set; }
            public int CountUses { get; set; }
            public TimeSpan TotalDuration { get; set; }
        }

        private List<CustomerItem> _lastUsedCustomers;
        private CustomerItem _selectedCustomer;
        private List<ReportItem> _reports;
        private List<ReportLineItem> _reportLines;

        public FormMainIntegrated()
        {
            InitializeComponent();
        }

        private void FormMainIntegrated_Load(object sender, EventArgs e)
        {
            Configure();

            FillLastUsedCustomers();
        }


        private void Configure()
        {
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;

            lvReports.FullRowSelect = true;
            lvReports.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvReports.MultiSelect = false;
            lvReports.View = View.Details;
            lvReports.Columns.Add("Код", 120);
            lvReports.Columns.Add("Початок", 120);
            lvReports.Columns.Add("Закінчення", 120);
            lvReports.Columns.Add("Назва файлу", 400);

            lvReportLines.FullRowSelect = true;
            lvReportLines.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvReportLines.MultiSelect = false;
            lvReportLines.View = View.Details;
            lvReportLines.Columns.Add("№", 120);
            lvReportLines.Columns.Add("Назва твору", 300);
            lvReportLines.Columns.Add("Виконавець", 300);
            //lvReportLines.Columns.Add("Автор музики", 400);
            //lvReportLines.Columns.Add("Автор тексту", 400);
            //lvReportLines.Columns.Add("Тривалість твору", 400);
            //lvReportLines.Columns.Add("Кількість прослуховувань", 400);
            //lvReportLines.Columns.Add("Загальна тривалість", 400);
        }

        private string FormatCustomer(CustomerItem customer)
        {
            return $"{customer.CustId} - {customer.ShortName} ({customer.Name})";
        }

        private void UpdateControls()
        {
            btnShowReport.Enabled = lvReports.SelectedItems.Count > 0;
        }

        private void FillLastUsedCustomers()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select t1.CustId, t2.Name, t2.ShortName
                    from LastUsedCustomers t1
	                    join MediaService..vCustomerNamesFull t2 on t1.CustId = t2.CustId
                    order by t1.UsedAt desc
                ";
                using (var r = cmd.ExecuteReader())
                {
                    _lastUsedCustomers = new List<CustomerItem>();
                    while (r.Read())
                    {
                        _lastUsedCustomers.Add(new CustomerItem
                        {
                            CustId = r.GetInt32(0),
                            Name = r.GetString(1),
                            ShortName = r.GetString(2),
                        });
                    }
                }
            });

            cbCustomers.Items.Clear();
            _lastUsedCustomers.ForEach(x =>
            {
                cbCustomers.Items.Add(FormatCustomer(x));
            });

            cbCustomers.SelectedIndex = 0;
        }

        private void FillCustomerReports()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select t1.RegId, t2.beginDate, endDate, t1.FileName
                    from MediaService..Register t1
	                    join MediaService..PaidPeriod t2 on t1.CUstId = t2.CustId
		                    and t1.periodId = t2.periodId
                    where t1.CustId = @CustId
                    order by t2.beginDate desc
                ";
                cmd.Parameters.AddWithValue("@CustId", _selectedCustomer.CustId);
                using (var r = cmd.ExecuteReader())
                {
                    _reports = new List<ReportItem>();
                    while (r.Read())
                    {
                        _reports.Add(new ReportItem
                        {
                            RegId = r.GetInt32(0),
                            StartDate = r.GetDateTime(1),
                            EndDate = r.GetDateTime(2),
                            FileName = r.GetString(3),
                        });
                    }
                }
            });

            lvReports.Items.Clear();
            _reports.ForEach(x =>
            {
                var item = lvReports.Items.Add(x.RegId.ToString());
                item.SubItems.Add(x.StartDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(x.EndDate.ToString("yyyy-MM-dd"));
                item.SubItems.Add(x.FileName);
                item.Tag = x;
            });
        }

        private void FillRegisterReportLines(int regId)
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                     select
	                      RegIItemId	as LineNr
	                    , ItemName		as Name
	                    , Performer		as Performer
	                    , AuthorMusic	as MisicAuthor
	                    , AuthorText	as TextAuthor
	                    , DurationUse	as Duration
	                    , CountUse		as CountUses
	                    , DurationItem	as TotalDuration
                    from MediaService..RegisterItem
                    where RegId = @RegId
                    order by RegIItemId
                ";
                cmd.Parameters.AddWithValue("@RegId", regId);
                using (var r = cmd.ExecuteReader())
                {
                    _reportLines = new List<ReportLineItem>();
                    while (r.Read())
                    {
                        var reportLine = new ReportLineItem();
                        var idx = 0;
                        reportLine.LineNr = r.GetInt32(idx++);
                        reportLine.Name = r.GetString(idx++);
                        reportLine.Performer = r.GetString(idx++);
                        reportLine.MisicAuthor = r.GetString(idx++);
                        reportLine.TextAuthor = r.GetString(idx++);
                        reportLine.Duration = r.GetTimeSpan(idx++);
                        reportLine.CountUses = r.GetInt32(idx++);
                        reportLine.TotalDuration = r.GetTimeSpan(idx++);

                        _reportLines.Add(reportLine);
                    }
                }
            });

            lvReportLines.Items.Clear();
            _reportLines.ForEach(x =>
            {
                var item = lvReportLines.Items.Add(x.LineNr.ToString());
                item.SubItems.Add(x.Name);
                item.SubItems.Add(x.Performer);
                //item.SubItems.Add(x.MisicAuthor);
                //item.SubItems.Add(x.TextAuthor);
                //item.SubItems.Add(x.Duration.ToString());
                //item.SubItems.Add(x.CountUses.ToString());
                //item.SubItems.Add(x.TotalDuration.ToString());
                item.Tag = x;
            });
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            var form = new FormSelectCustomer();
            form.ShowDialog();
            if (form.SelectedCustomer == null)
            {
                UpdateControls();
                return;
            }

            _selectedCustomer = new CustomerItem
            {
                CustId = form.SelectedCustomer.CustId,
                Name = form.SelectedCustomer.Name,
                ShortName = form.SelectedCustomer.ShortName,
            };

            var selectedCustomerIdx = -1;
            for (var idx = 0; idx < _lastUsedCustomers.Count; idx++)
            {
                if (_lastUsedCustomers[idx].CustId == _selectedCustomer.CustId)
                {
                    selectedCustomerIdx = idx;
                    break;
                }
            }

            if (selectedCustomerIdx >= 0)
            {
                _lastUsedCustomers.RemoveAt(selectedCustomerIdx);
                cbCustomers.Items.RemoveAt(selectedCustomerIdx);
            }

            _lastUsedCustomers.Insert(0, _selectedCustomer);

            cbCustomers.Items.Insert(0, FormatCustomer(_selectedCustomer));
            cbCustomers.SelectedIndex = 0;

            FillCustomerReports();

            UpdateControls();
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCustomer = _lastUsedCustomers[cbCustomers.SelectedIndex];
            if (_reportLines != null)
            {
                _reportLines.Clear();
            }
            lvReportLines.Items.Clear();
            FillCustomerReports();

            UpdateControls();
        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var report = lvReports.SelectedItems.Count == 0 ?
                null : (ReportItem)lvReports.SelectedItems[0].Tag;

            if (report == null)
            {
                lvReportLines.Items.Clear();
                _reportLines.Clear();
                UpdateControls();
                return;
            }

            FillRegisterReportLines(report.RegId);

            UpdateControls();
        }

       private void btnShowReport_Click(object sender, EventArgs e)
       {
            if(_reportLines.Count == 0)
            {
                MessageBox.Show("Обраний звіт не містить рядків! Обробка не можлива."
                    , "Обробка звітів користувача"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

       }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

     }
}
