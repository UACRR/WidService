using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class UcSearch : UserControl
    {
        public delegate void OnWorkApplied(string code);
        public class FoundWork
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Authors { get; set; }
            public string Performers { get; set; }
            public bool IsMatching { get; set; }
        }

        private OnWorkApplied _onWorkApplied;
        private string _name;
        private string _performers;
        private List<FoundWork> _foundWorks;

        public UcSearch()
        {
            InitializeComponent();
        }

        private void UcSearch_Load(object sender, EventArgs e)
        {
        }

        public void SetNamePerformer(string name, string performers, OnWorkApplied onWorkApplied)
        {
            _name = name;
            _performers = performers;
            _onWorkApplied = onWorkApplied;

            cbSerachUsingLike.Checked = false;

            try
            {
                Cursor = Cursors.WaitCursor;
                FillControls(true);
                timerLoad.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Пошук творів", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        private void LoadFoundWorks()
        {
            Helpers.RunSql(cmd =>
            {
                cmd.CommandTimeout = cbSerachUsingLike.Checked ? 60 : 30;
                cmd.CommandText = cbSerachUsingLike.Checked ? "MediaService..spSearchWorksEx" : "MediaService..spSearchWorks";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", cbSerachUsingLike.Checked ? $"%{_name}%" : _name);

                using (var r = cmd.ExecuteReader())
                {
                    _foundWorks = new List<FoundWork>();
                    while (r.Read())
                    {
                        var foundWork = new FoundWork();

                        var idx = 0;

                        foundWork.Code = r.GetString(idx++);
                        foundWork.Name = r.GetString(idx++);
                        foundWork.Authors = r.GetString(idx++);
                        foundWork.Performers = r.GetString(idx++);

                        _foundWorks.Add(foundWork);
                    }
                }
            });
        }

        private string RefineString(string source)
        {
            var retVal = new StringWriter();
            for (var idx = 0; idx < source.Length; idx++)
            {
                var curChar = source[idx];
                retVal.Write(Char.IsLetterOrDigit(curChar) ? curChar : ' ');
            }
            return retVal.ToString();
        }

        private List<string> CreatePerformerFragments()
        {
            var fragments = tbFilterTextFragment.Text
                    .Split(' ')
                    .Where(x => x.Trim() != "")
                    .Distinct()
                    .ToList();
            return fragments;
        }

        private void FillWebControl(bool isPreLoad)
        {
            var fragments = CreatePerformerFragments();

            if(!isPreLoad)
            {
                _foundWorks.ForEach(x =>
                {
                    x.IsMatching = false;
                    fragments.ForEach(y =>
                    {
                        if (
                            x.Authors.Contains(y, StringComparison.OrdinalIgnoreCase) ||
                            x.Performers.Contains(y, StringComparison.OrdinalIgnoreCase))
                        {
                            x.IsMatching = true;
                        }
                    });
                });

                var foundWorks = _foundWorks.OrderByDescending(x => x.IsMatching).ToList();
                if (rbShowSelected.Checked)
                {
                    foundWorks = foundWorks.Where(x => x.IsMatching).ToList();
                }

                var htmlHelper = new UcSearchHelper();
                var html = htmlHelper.GetHtml(foundWorks, fragments);
                wvFoundWorks.DocumentText = html;

            }

            else
            {
                var htmlHelper = new UcSearchHelper();
                var html = htmlHelper.GetWaitHtml();
                wvFoundWorks.DocumentText = html;
            }
        }

        private void FillControls(bool isPreLoad)
        {
            if (isPreLoad)
            {
                tbReportWorkName.Text = _name;
                tbReportWorkPerformers.Text = _performers;

                tbFilterName.Text = _name;
                tbFilterTextFragment.Text = RefineString(_performers);
            }

            FillWebControl(isPreLoad);
        }

        private void rbShowAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                FillWebControl(false);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void rbShowSelected_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                FillWebControl(false);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSelectByTextFragnemts_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                FillWebControl(false);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            _name = tbFilterName.Text;
            try
            {
                Cursor = Cursors.WaitCursor;
                FillWebControl(true);
                timerLoad.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Пошук творів", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void wvFoundWorks_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if(_foundWorks != null)
            {
                _foundWorks.ForEach(x =>
                {
                    var el = wvFoundWorks.Document.GetElementById(x.Code);
                    if (el != null)
                    {
                        el.Click += (y, z) =>
                        {
                            _onWorkApplied(((HtmlElement)y).Id);
                        };
                    }
                });
            }
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Enabled = false;
            try
            {
                Cursor = Cursors.WaitCursor;
                LoadFoundWorks();
                FillControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Пошук творів", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
