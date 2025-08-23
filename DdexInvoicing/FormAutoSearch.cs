using InvoicingLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DdexInvoicing
{
    public partial class FormAutoSearch : Form
    {
        private int _ddexReportId;

        private string _cmdSearchResult;
        private SqlCommand _cmdSearch;

        private int? _stepIdx;
        private DateTime? _stepStart;
        private DateTime? _stepEnd;

        private bool _allowClose;

        public FormAutoSearch(int ddexReportId)
        {
            InitializeComponent();
            _ddexReportId = ddexReportId;
            _cmdSearch = null;
            _cmdSearchResult = "";
        }

        private void FormAutoSearch_Load(object sender, EventArgs e)
        {
            Configure();
            FillLvSteps();
            //FillLvResult();
            //RefreshLvSteps();
        }

        private void Configure()
        {
            rbSearchInIdentMw.Checked = true;
            rbSearchInMs.Checked = false;
            rbSearchInWid.Checked = false;

            lvSteps.FullRowSelect = true;
            lvSteps.View = View.Details;
            lvSteps.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvSteps.HideSelection = false;
            lvSteps.MultiSelect = false;
            lvSteps.SmallImageList = ilMain;
            lvSteps.Columns.Add("#", 60);
            lvSteps.Columns.Add("Дія", 300);
            lvSteps.Columns.Add("Тривалість", 100);
            lvSteps.Columns.Add("Статус", 300);

            lvResult.FullRowSelect = true;
            lvResult.View = View.Details;
            lvResult.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvResult.HideSelection = false;
            lvResult.MultiSelect = false;
            lvResult.SmallImageList = ilMain;
            lvResult.Columns.Add("#", 60);
            lvResult.Columns.Add("", 60);
            lvResult.Columns.Add("Назва", 100);
            lvResult.Columns.Add("Автори", 200);
            lvResult.Columns.Add("Виконавці", 100);

            ResetControls();
        }

        private void FillLvSteps()
        {
            try
            {
                lvSteps.BeginUpdate();
                lvSteps.Items.Clear();
                Helpers.RunSqlOperationDdexUnprotected(cmd =>
                {
                    var searchType = rbSearchInIdentMw.Checked ? 0 :
                        rbSearchInMs.Checked ? 1 : 2;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AutoSearch..spResetSearchSteps";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@searchType", searchType);
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = $"select Id, Name, Status from AutoSearch..SearchSteps order by Id";
                    cmd.Parameters.Clear();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            var item = lvSteps.Items.Add(r.GetInt32(0).ToString());
                            item.SubItems.Add(r.GetString(1));
                            item.SubItems.Add("");
                            item.SubItems.Add("");
                        }
                    }
                });
                lvSteps.EndUpdate();
            }
            catch(Exception ex)
            {

            }
        }

        private void FillLvResult()
        {
            lvResult.Items.Clear();
            Helpers.RunSqlOperationDdex(cmd =>
            {
                if (rbSearchInIdentMw.Checked)
                {
                    cmd.CommandText = @"select * from AutoSearch..vFoundWorksInIdentMw";
                }
                else if (rbSearchInMs.Checked) {
                    cmd.CommandText = @"select * from AutoSearch..vFoundWorksInMs";
                }
                else if (rbSearchInWid.Checked) {
                    cmd.CommandText = @"select * from AutoSearch..vFoundWorksInWid";
                }
                using (var r = cmd.ExecuteReader())
                {
                    var idx = 1;
                    while(r.Read())
                    {
                        var item = lvResult.Items.Add(idx.ToString());
                        item.SubItems.Add("У звіті");
                        item.SubItems.Add(r.GetString(0));
                        item.SubItems.Add(r.GetString(1));
                        item.SubItems.Add(r.GetString(2));

                        item = lvResult.Items.Add("");
                        item.SubItems.Add("Знайдений");
                        item.SubItems.Add(r.GetString(3));
                        item.SubItems.Add(r.GetString(4));
                        item.SubItems.Add(r.GetString(5));

                        idx++;
                    }
                }
            });
        }

        private void RefreshLvSteps()
        {
            Helpers.RunSqlOperationDdexUnsafe(cmd =>
            {
                cmd.CommandText = $"select Status from AutoSearch..SearchSteps order by Id";
                using (var r = cmd.ExecuteReader())
                {
                    lvSteps.BeginUpdate();
                    var itemIdx = 0;
                    while (r.Read())
                    {
                        var item = lvSteps.Items[itemIdx];
                        var status = r.GetInt32(0);
                        var statusText = status == 0 ?
                            "" : status == 1 ? "Виконується ..." : "Завершено";
                        item.SubItems[3].Text = statusText;
                        item.ImageIndex = GetImageIndex(status);
                        if(item.SubItems[2].Text == "")
                        {
                            item.SubItems[2].Text = "00:00:00";
                        }

                        if(status == 1)
                        {
                            if(itemIdx != _stepIdx)
                            {
                                if(_stepIdx != null && itemIdx > 1)
                                {
                                    TimeSpan timeSpan = DateTime.Now - (DateTime)_stepStart;
                                    var itemPrev = lvSteps.Items[itemIdx - 1];
                                    itemPrev.SubItems[2].Text = timeSpan.ToString(@"hh\:mm\:ss");
                                }
                                item.SubItems[2].Text = "00:00:00";
                                _stepIdx = itemIdx;
                                _stepStart = DateTime.Now;
                            }
                            else
                            {
                                TimeSpan timeSpan = DateTime.Now - (DateTime)_stepStart;
                                item.SubItems[2].Text = timeSpan.ToString(@"hh\:mm\:ss");
                            }
                        }
 
                        itemIdx++;
                    }
                    lvSteps.EndUpdate();
                };
             });
        }

        private int GetImageIndex(int status)
        {
            return (status == 0) ? -1 : (status == 1) ? 1 : (status == 2) ? 0 : 3;
        }

        private void DoTestSearch()
        {
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = "update AutoSearch..SearchSteps set Status = 0";
                    cmd.ExecuteNonQuery();
                });

                Random rnd = new Random();
                for(var idx = 1; idx <= 18; idx++)
                {
                    Helpers.RunSqlOperationDdex(cmd =>
                    {
                        cmd.CommandText = "update AutoSearch..SearchSteps set Status = 1 where Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", idx);cmd.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                    });
                    Thread.Sleep(rnd.Next(1, 3) * 1000);
                    Helpers.RunSqlOperationDdex(cmd =>
                    {
                        cmd.CommandText = "update AutoSearch..SearchSteps set Status = 2 where Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", idx);cmd.ExecuteNonQuery();
                        cmd.ExecuteNonQuery();
                    });
                }
        }

        private async Task DoSearch()
        {
            try
            {
                await Helpers.RunSqlOperationDdexAsync(async cmd =>
                {
                    _cmdSearch = cmd;
                    var procName = rbSearchInIdentMw.Checked ? "spSearchInIdentMw" :
                        rbSearchInMs.Checked ? "spSearchInMs" : "spSearchInWid";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = $"AutoSearch..{procName}";
                    cmd.Parameters.AddWithValue("@ddexReportId", _ddexReportId);
                    await cmd.ExecuteNonQueryAsync();
                    FillLvResult();
                    MessageBox.Show("Пошук завершено", "Пошук творів", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return null;
               });
            }
            catch (Exception ex)
            {
                if(_cmdSearch != null)
                {
                    _cmdSearch.Cancel();
                    MessageBox.Show(ex.Message, "Пошук творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                ResetControls();
            }
        }
        private async void btnDoSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Helpers.RunSqlOperationDdex(cmd =>
                {
                    cmd.CommandText = $"update AutoSearch..SearchSteps set Status = 0";
                    cmd.ExecuteNonQuery();
                }, true);
            }
            catch(Exception)
            {
                return;
            }

            ResetControls();
            
            timerMonitor.Enabled = true;
            btnClose.Enabled = false;
            btnDoSearch.Enabled = false;
            rbSearchInIdentMw.Enabled = false;
            rbSearchInMs.Enabled = false;
            rbSearchInWid.Enabled = false;
            _allowClose = false;
            lvResult.Items.Clear();

            _cmdSearchResult = "";
            btnStopSearch.Enabled = true;
            await DoSearch();

            //_thread = new Thread(() =>
            //{
            //    DoSearch();
            //    //DoTestSearch();
            //});
            //_thread.Start();
        }

        private void ResetControls()
        {
            btnClose.Enabled = true;
            btnDoSearch.Enabled = true;
            btnStopSearch.Enabled = false;
            _allowClose = true;
            timerMonitor.Enabled = false;
            _cmdSearch = null;
            _cmdSearchResult = "";
            rbSearchInIdentMw.Enabled = true;
            rbSearchInMs.Enabled = true;
            rbSearchInWid.Enabled = true;
            //FillLvSteps();
        }

        private void timerMonitor_Tick(object sender, EventArgs e)
        {
            try
            {
                timerMonitor.Enabled = false;
                RefreshLvSteps();
                timerMonitor.Enabled = true;
            }
            catch (Exception ex)
            {
                if(_cmdSearch != null)
                {
                    _cmdSearch.Cancel();
                }
                MessageBox.Show(ex.Message, "Пошук творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControls();
            }

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            for(var idx = 0; idx < lvResult.Columns.Count; idx++)
            {
                if(idx != 0)
                {
                    sb.Append('\t');
                }
                sb.Append(lvResult.Columns[idx].Text);
            }
            sb.Append($"\r\n");

            foreach(ListViewItem item in lvResult.Items)
            {
                for (var idx = 0; idx < lvResult.Columns.Count; idx++)
                {
                    if (idx != 0)
                    {
                        sb.Append('\t');
                    }
                    sb.Append(item.SubItems[idx].Text);
                }
                sb.Append($"\r\n");
            }

            Clipboard.SetText(sb.ToString());

            MessageBox.Show("Дані передані в буфер обміну", "Операція завершена");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormAutoSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!_allowClose)
            {
                e.Cancel = true;
            }
        }

        private void rbSearchInIdentMw_CheckedChanged(object sender, EventArgs e)
        {
            FillLvSteps();
        }

        private void rbSearchInMs_CheckedChanged(object sender, EventArgs e)
        {
            FillLvSteps();
        }

        private void rbSearchInWid_CheckedChanged(object sender, EventArgs e)
        {
            FillLvSteps();
        }

        private void btnStopSearch_Click(object sender, EventArgs e)
        {
            if(_cmdSearch != null)
            {
                _cmdSearch.Cancel();
                ResetControls();
            }
        }
    }
}
