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
    public partial class UcMainIntegrated : UserControl
    {
        public enum ReportItemStatus
        {
            NotRegistered,
            RegistrationFailed,
            Registered,
        }

        public class CustomerItem
        {
            public int CustId { get; set; }
            public string Name { get; set; }
            public string ShortName { get; set; }
        }

        public class OtherCustomerItem
        {
            public int RegId { get; set; }
            public int CustId { get; set; }
            public string Name { get; set; }
        }

        public class ReportItem
        {
            public int RegId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string FileName { get; set; }
            public ReportItemStatus Status { get; set; }
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
        private ReportItem _selectedReport;
        private List<ReportLineItem> _reportLines;
        private List<OtherCustomerItem> _otherCustomers;

        private bool _ignoreCbLastUsedCustomersEvents = false;

        public UcMainIntegrated()
        {
            InitializeComponent();
        }

        private void UcMainIntegrated_Load(object sender, EventArgs e)
        {
            if (DesignMode)
            {
                return;
            }

            Configure();
            UpdateContent();

        }

        private void Configure()
        {
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;

            lvReports.FullRowSelect = true;
            lvReports.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvReports.MultiSelect = false;
            lvReports.View = View.Details;
            lvReports.SmallImageList = ilReports;
            lvReports.Columns.Add("Код звіту", 120);
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
            
            lvOtherCustomers.FullRowSelect = true;
            lvOtherCustomers.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvOtherCustomers.MultiSelect = false;
            lvOtherCustomers.View = View.Details;
            lvOtherCustomers.SmallImageList = ilReports;
            lvOtherCustomers.Columns.Add("Код звіту", 120);
            lvOtherCustomers.Columns.Add("Код користувача", 120);
            lvOtherCustomers.Columns.Add("Назва корстувача", 400);
        }

        private string FormatCustomer(CustomerItem customer)
        {
            return $"{customer.CustId} - {customer.ShortName}";
        }

        private void UpdateContent()
        {
            lvReports.Items.Clear();
            lvReportLines.Items.Clear();
            lvOtherCustomers.Items.Clear();   
            
            FillLastUsedCustomers();

            _ignoreCbLastUsedCustomersEvents = true;
            cbCustomers.SelectedIndex = 0;
            _ignoreCbLastUsedCustomersEvents = false;

            _selectedCustomer = _lastUsedCustomers[0];
            
            FillCustomerReports();
            UpdateControls();
        }

        private void UpdateControls()
        {
            btnShowReport.Visible = lvReports.SelectedItems.Count > 0;
            if(lvReports.SelectedItems.Count > 0)
            {
                var report = (ReportItem)lvReports.SelectedItems[0].Tag;
                btnShowReport.Text = 
                    report.Status == ReportItemStatus.Registered    ? "Показати звіт" :
                    report.Status == ReportItemStatus.NotRegistered ? "Зареєструвати звіт" :
                                                                      "Повторити реєстрацію";

            }
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

        }

        private void FillCustomerReports()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select 
                          t1.RegId
                        , t2.beginDate
                        , t2.endDate
                        , t1.FileName
                        , case
                            when t4.Id is null then 0
                            when t4.Id is not null and t4.Status = 0 then 1
                            else 2
                          end								as Status
                    from MediaService..Register t1
                        join MediaService..PaidPeriod t2 on t1.CUstId = t2.CustId
                            and t1.periodId = t2.periodId
                        left join ReportIdToRegId t3 on t1.regId = t3.RegId
	                    left join Reports t4 on t3.ReportId = t4.Id
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
                            Status = (ReportItemStatus)r.GetInt32(4),
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
                item.ImageIndex =
                    x.Status == ReportItemStatus.Registered          ?  0 :
                    x.Status == (int)ReportItemStatus.NotRegistered  ? -1 :
                                                                        1;
                item.Tag = x;
            });
        }

        private void FillRegisterReportLines(int regId)
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                     select top 100
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

        private void FillOtherCustomers(int regId)
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select t2.RegId, t2.CustId, t3.ShortName
                    from MediaService..Register t1
	                    join MediaService..Register t2 on t1.FileName = t2.FileName
	                    join MediaService..vCustomerNamesShort t3 on t2.CustId = t3.CustId
                    where t1.RegId = @RegId
	                    and t2.RegId <> t1.RegId
                    order by t3.ShortName
                ";
                cmd.Parameters.AddWithValue("@RegId", regId);
                using (var r = cmd.ExecuteReader())
                {
                    _otherCustomers = new List<OtherCustomerItem>();
                    while (r.Read())
                    {
                        var otherCustomer = new OtherCustomerItem();
                        var idx = 0;
                        otherCustomer.RegId = r.GetInt32(idx++);
                        otherCustomer.CustId = r.GetInt32(idx++);
                        otherCustomer.Name = r.GetString(idx++);

                        _otherCustomers.Add(otherCustomer);
                    }
                }
            });

            lvOtherCustomers.Items.Clear();
            _otherCustomers.ForEach(x =>
            {
                var item = lvOtherCustomers.Items.Add(x.CustId.ToString());
                item.SubItems.Add(x.CustId.ToString());
                item.SubItems.Add(x.Name);
                item.Tag = x;
            });
        }

        private void ShowReport(int reportId)
        {
            var report = Report.CreateFromDb(reportId);
            var form = new FormReport(report);
            form.Show();
        }

        private ReportItemStatus RegisterReport(CustomerItem customer, ReportItem report)
        {
            var form = new FormRegisterReport(customer, report);
            form.ShowDialog();
            return form.ReportItemStatus;

            var radioPreSearchManager = new RadioPreSearchManager();

            try
            {
                var reportId = 0;

                Helpers.RunSqlT(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spRegisterReportFromMs";
                    cmd.Parameters.AddWithValue("@RegId", report.RegId);
                    cmd.Parameters.AddWithValue("@ReportId", reportId).Direction = ParameterDirection.InputOutput;
                    cmd.ExecuteNonQuery();
                });

                radioPreSearchManager = new RadioPreSearchManager(reportId);
                radioPreSearchManager.AutoSearch();

                Helpers.RunSql(cmd =>
                {
                    cmd.CommandText = @"
                        update Reports 
                        set 
                              UpdatedAt             = getdate()
                            , AutoSearchFinishedAt  = getdate()
                        where Id = @ReportId";
                    cmd.Parameters.AddWithValue("@ReportId", reportId);
                    cmd.ExecuteNonQuery();
                });

            }
            catch (Exception ex)
            {
                Helpers.ShowError(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
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

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    if exists (select null from LastUsedCustomers where custId = @custId)
	                    update LastUsedCustomers set UsedAt = getdate() where CustId = @custId
                    else
	                    insert LastUsedCustomers(CustId, UsedAt) values(@custId, getdate())
                ";
                cmd.Parameters.AddWithValue("@custId", form.SelectedCustomer.CustId);
                cmd.ExecuteNonQuery();
            });

            UpdateContent();
        }

        private void cbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (_ignoreCbLastUsedCustomersEvents)
            {
                return;
            }

            var customer = _lastUsedCustomers[cbCustomers.SelectedIndex];

            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    if exists (select null from LastUsedCustomers where custId = @custId)
	                    update LastUsedCustomers set UsedAt = getdate() where CustId = @custId
                    else
	                    insert LastUsedCustomers(CustId, UsedAt) values(@custId, getdate())
                ";
                cmd.Parameters.AddWithValue("@custId", customer.CustId);
                cmd.ExecuteNonQuery();
            });


            UpdateContent();

        }

        private void lvReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var report = lvReports.SelectedItems.Count == 0 ?
                null : (ReportItem)lvReports.SelectedItems[0].Tag;

            if (report == null)
            {
                lvReportLines.Items.Clear();
                _reportLines.Clear();
                _selectedReport = null;
                UpdateControls();
                return;
            }

            _selectedReport = report;
            FillRegisterReportLines(_selectedReport.RegId);
            FillOtherCustomers(_selectedReport.RegId);

            UpdateControls();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (_reportLines.Count == 0)
            {
                MessageBox.Show("Обраний звіт не містить рядків! Обробка не можлива."
                    , "Обробка звітів користувача"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Warning);
                return;
            }

            var regId = _selectedReport.RegId;
            int? reportId = null;
            Helpers.RunSql(cmd =>
            {
                cmd.CommandText = @"
                    select ReportId
                    from ReportIdToRegId t1
                        join Reports t2 on t1.ReportId = t2.Id
                    where t1.RegId = @RegId
                        and t2.Status >= 1
                ";
                cmd.Parameters.AddWithValue("@RegId", regId);
                reportId = (int?)cmd.ExecuteScalar();
            });

            if (reportId == null)
            {
                var res = RegisterReport(_selectedCustomer, _selectedReport);
                _selectedReport.Status = res;
                lvReports.SelectedItems[0].ImageIndex =
                    res == ReportItemStatus.Registered          ?  0 :
                    res == (int)ReportItemStatus.NotRegistered  ? -1 :
                                                                   1;
                UpdateControls();
            }
            else
            {
                ShowReport((int)reportId);
            }
        }

    }
}
