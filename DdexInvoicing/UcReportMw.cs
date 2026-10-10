using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using InvoicingLib;
using System.Data.SqlClient;

namespace DdexInvoicing
{
    public partial class UcReportMw : UserControl
    {
        public enum Status
        {
              unprocessed = 0
            , rejected = 1
            , identified = 2
            , postponed = 3
        }
        public class RowChangedEventArgs : EventArgs
        {
            public string ResourceTitle { get; set; }
            public string Title { get; set; }
            public string Authors { get; set; }
            public string Performers { get; set; }
            public string Iswc { get; set; }
            public int?   ObjId { get; set; }
            public int?   Wic { get; set; }
        }
        public class ReportRecordEntry
        {
            public int Id { get; set; }
            public string ResourceTitle { get; set; }
            public string Title { get; set; }
            public string Authors { get; set; }
            public string Performers { get; set; }
            public string Iswc { get; set; }
            public int Status { get; set; }
            public int? Wic { get; set; }
            public int? ObjId { get; set; }
            public decimal NetRevenue { get; set; }
            public string Reject { get; set; }
            public string Postpone { get; set; }
        }
        private class RadMenuItemInfo
        {
            public bool isCurrent { get; set; }
        }

        private int _ddexReportId;
        private List<ReportRecordEntry> _reportRecords;

        public event EventHandler<RowChangedEventArgs> RowChangedEvent;

        private FormReportVsFoundWork _formReportVsFoundWork;

        public UcReportMw()
        {
            InitializeComponent();
        }

        public void SetDdexReportId(int ddexReportId)
        {
            _ddexReportId = ddexReportId;
        }

        public void SetWic(int wic)
        {
            var row = radGridSales.CurrentRow;
            var rec = (ReportRecordEntry)row.DataBoundItem;
            rec.Status = (int)Status.identified;
            rec.Wic = wic;
            rec.ObjId = null;
            SaveStatus(rec.Id, rec.Status);
            SaveWic(rec.Id, (int)rec.Wic);
            SetStatusImage(row);
        }

        public void SetObjId(int objId)
        {
            var row = radGridSales.CurrentRow;
            var rec = (ReportRecordEntry)row.DataBoundItem;
            rec.Status = (int)Status.identified;
            rec.ObjId = objId;
            rec.Wic = null;
            SaveStatus(rec.Id, rec.Status);
            SaveObjId(rec.Id, (int)rec.ObjId);
            SetStatusImage(row);
        }

        private void UcReportMw_Load(object sender, EventArgs e)
        {
            ddbBlock.Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                var startIndex = i * 1000 + 1;
                var endIndex = (i + 1) * 1000;
                var text = $"{startIndex}-{endIndex}";
                AddMenuItem(ddbBlock, text, text, new RadMenuItemInfo { isCurrent = true, });
            }
            ddbBlock.Text = "1-1000";

            ddbStatus.Items.Clear();
            AddMenuItem(ddbStatus, "all", "всі", new RadMenuItemInfo { isCurrent = true, });
            AddMenuItem(ddbStatus, "unprocessed", "необроблені", new RadMenuItemInfo { isCurrent = false, });
            AddMenuItem(ddbStatus, "rejected", "відхилені", new RadMenuItemInfo { isCurrent = false, });
            AddMenuItem(ddbStatus, "identified", "знайдені", new RadMenuItemInfo { isCurrent = false, });
            AddMenuItem(ddbStatus, "postponed", "відкладені", new RadMenuItemInfo { isCurrent = false, });
            ddbStatus.Text = "всі";

            ddbSort.Items.Clear();
            AddMenuItem(ddbSort, "byRevenue", "прибутковості", new RadMenuItemInfo { isCurrent = true, });
            AddMenuItem(ddbSort, "byRecordName", "назви запису", new RadMenuItemInfo { isCurrent = false, });
            AddMenuItem(ddbSort, "byMwName", "назви твору", new RadMenuItemInfo { isCurrent = false, });
            AddMenuItem(ddbSort, "byAuthors", "імен авторів", new RadMenuItemInfo { isCurrent = false, });
            AddMenuItem(ddbSort, "byPerformers", "імен виконавців", new RadMenuItemInfo { isCurrent = false, });
            AddMenuItem(ddbSort, "byIswc", "коду ISWC", new RadMenuItemInfo { isCurrent = false, });
            ddbSort.Text = "прибутковісті";

            radGridSales.MasterTemplate.Columns.ToList().ForEach(x =>
            {
                x.AutoSizeMode = BestFitColumnMode.AllCells;
            });

            ApplyFilter();
        }

        private void AddMenuItem(RadDropDownButton btn, string name, string text, RadMenuItemInfo info)
        {
            var item = new RadMenuItem
            {
                Name = name,
                Text = text,
                Tag = info,
            };
            item.Click += new System.EventHandler(OnDropDownButtonClick);
            btn.Items.Add(item);
        }

        private void OnDropDownButtonClick(object sender, EventArgs e)
        {
            var item = sender as RadMenuItem;
            var btn = item.Owner as RadDropDownButtonElement;
            btn.Text = item.Text;
            foreach (var curItem in btn.Items)
            {
                ((RadMenuItemInfo)curItem.Tag).isCurrent = (curItem == item);
            }
            ApplyFilter();
            //radGridSales.DataSource = null;
            //btnApplyFilter.Enabled = true;
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                var filter = DdexReport.GetFilterStringShort(cmd, _ddexReportId);

                var firstRowIndex = 0;
                var lastRowIndex = 0;
                foreach (var item in ddbBlock.Items)
                {
                    if (((RadMenuItemInfo)item.Tag).isCurrent)
                    {
                        var parts = ddbBlock.Text.Split('-');
                        firstRowIndex = int.Parse(parts[0]);
                        lastRowIndex = int.Parse(parts[1]);
                        break;
                    }
                }

                var status = 0;
                var statusFilter = "";
                foreach (var item in ddbStatus.Items)
                {
                    if (((RadMenuItemInfo)item.Tag).isCurrent)
                    {
                        statusFilter = item.Name.Equals("all", StringComparison.OrdinalIgnoreCase) ? "" : " and status = @status";

                        switch (item.Name)
                        {
                            case "unprocessed": status = (int)Status.unprocessed; break;
                            case "rejected": status = (int)Status.rejected; break;
                            case "identified": status = (int)Status.identified; break;
                            case "postponed": status = (int)Status.postponed; break;
                            default: status = (int)Status.unprocessed; break;
                        }
                        break;
                    }
                }

                string order = "";
                string orderDir = "asc";
                foreach (var item in ddbSort.Items)
                {
                    if (((RadMenuItemInfo)item.Tag).isCurrent)
                    {
                        switch (item.Name)
                        {
                            case "byRevenue": order = "netrevenue"; orderDir = "desc"; break;
                            case "byRecordName": order = "ResourceTitle"; break;
                            case "byMwName": order = "Title"; break;
                            case "byAuthors": order = "composerauthor"; break;
                            case "byPerformers": order = "displayartistname"; break;
                            case "byIswc": order = "Iswc"; break;
                            default: order = "netrevenue"; break;
                        }
                        break;
                    }
                }
                cmd.CommandText = $@"
                    select 
                          Id
                        , ResourceTitle
                        , title
                        , composerauthor
                        , displayartistname
                        , ISWC
                        , status
                        , wic
                        , objId
                        , t2.netrevenue 
                        , 'Не шукати' Reject
                        , 'Відкласти' Postpone
                    from IdentMW t1 
                        join IdentReportMwRecords t2 on t2.mwId = t1.id
                    where 
                        t2.ddexReportId {filter}
                        and t2.PriorityIndex >= @firstRowIndex 
                        and t2.PriorityIndex <= @lastRowIndex
                    {statusFilter}
                    order by {order} {orderDir}, Id
                    option(recompile)
                 ";

                cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@firstRowIndex", firstRowIndex);
                cmd.Parameters.AddWithValue("@lastRowIndex", lastRowIndex);

                _reportRecords = new List<ReportRecordEntry>();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        _reportRecords.Add(new ReportRecordEntry
                        {
                            Id = r.GetInt32(0),
                            ResourceTitle = r.GetString(1),
                            Title = r.GetString(2),
                            Authors = r.GetString(3),
                            Performers = r.GetString(4),

                            Iswc = r.GetString(5),
                            Status = r.GetInt32(6),
                            Wic = r.IsDBNull(7) ? null : (int?)r.GetInt32(7),
                            ObjId = r.IsDBNull(8) ? null : (int?)r.GetInt32(8),
                            NetRevenue = r.GetDecimal(9),
                            Reject = r.GetString(10),
                            Postpone = r.GetString(11),
                        });
                    }
                }
                radGridSales.DataSource = _reportRecords;
                btnApplyFilter.Enabled = false;

                foreach (var row in radGridSales.Rows)
                {
                    SetStatusImage(row);
                }
            });
        }

        private void SetStatusImage(GridViewRowInfo row)
        {
            var cell = row.Cells["Status"];
            var rec = (ReportRecordEntry)row.DataBoundItem;
            if (rec.Status == 0)
            {
                cell.Value = null;
            }
            else
            {
                var simpleStatus = rec.Status >= 10 ? Status.unprocessed : (Status)(rec.Status - 1);
                cell.Value = ilStatuses.Images[(int)simpleStatus];
            }
        }

        private void SaveStatus(int id, int status)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = "update IdentMW set status = @status where Id = @Id\r\n";

                if (status != (int)Status.identified)
                {
                    cmd.CommandText += "update IdentMW set Wic = null, ObjId = null where Id = @Id\r\n";
                }

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
            });
        }

        private void SaveWic(int id, int? wic)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    update IdentMW
                    set wic = @wic, objId = null
                    where Id = @Id
                 ";

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@wic", wic);
                cmd.ExecuteNonQuery();
            });
        }

        private void SaveObjId(int id, int? objId)
        {
            Helpers.RunSqlOperationDdex(cmd =>
            {
                cmd.CommandText = $@"
                    update IdentMW
                    set Wic = null, objId = @objId
                    where Id = @Id
                 ";

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@objId", objId);
                cmd.ExecuteNonQuery();
            });
        }

        private void radGridSales_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column == null)
            {
                return;
            }

            var rec = (ReportRecordEntry)e.Row.DataBoundItem;
            switch (e.Column.Name)
            {
                case "ResourceTitle":
                    break;
                case "Title":
                    break;
                case "Authors":
                    break;
                case "Performers":
                    break;
                case "Iswc":
                    break;
                case "Reject":
                    rec.Status = (int)Status.rejected;
                    rec.Wic = null;
                    rec.ObjId = null;
                    SaveStatus(rec.Id, rec.Status);
                    SetStatusImage(e.Row);
                    break;
                case "Postpone":
                    rec.Status = (int)Status.postponed;
                    rec.Wic = null;
                    rec.ObjId = null;
                    SaveStatus(rec.Id, rec.Status);
                    SetStatusImage(e.Row);
                    break;
            }
        }

        private void radGridSales_SelectionChanged(object sender, EventArgs e)
        {
            var rec = (ReportRecordEntry)radGridSales.CurrentRow.DataBoundItem;
            var rowChangedEvent = RowChangedEvent;
            if (rowChangedEvent != null)
            {
                var rowChangedEventArgs = new RowChangedEventArgs
                {
                    ResourceTitle = rec.ResourceTitle,
                    Title = rec.Title,
                    Authors = rec.Authors,
                    Performers = rec.Performers,
                    Iswc = rec.Iswc,
                    ObjId = rec.ObjId,
                    Wic = rec.Wic,
                };

                if(_formReportVsFoundWork != null)
                {
                    _formReportVsFoundWork.SetWork(rec.Id);
                }

                rowChangedEvent(sender, rowChangedEventArgs);
            }
        }

        private void radBtnAutoSearch_Click(object sender, EventArgs e)
        {
            var form = new FormAutoSearch(_ddexReportId);
            form.ShowDialog();
            ApplyFilter();
        }

        private void chkShowFormReportVsFoundWork_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On) 
            {
                var rec = (ReportRecordEntry)radGridSales.CurrentRow.DataBoundItem;
                _formReportVsFoundWork = new FormReportVsFoundWork();
                _formReportVsFoundWork.SetWork(rec.Id);
                _formReportVsFoundWork.Show(this);
            }
            else
            {
                _formReportVsFoundWork.Close();
                _formReportVsFoundWork = null;
            }
        }

        private void UcReportMw_Enter(object sender, EventArgs e)
        {
            if(_formReportVsFoundWork != null)
            {
                _formReportVsFoundWork.Visible = true;
            }
        }

        private void UcReportMw_Leave(object sender, EventArgs e)
        {
            if(_formReportVsFoundWork != null)
            {
                _formReportVsFoundWork.Visible = false;
            }
        }
    }
}
