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
    public partial class FormSelectParty : Form
    {
        private string _filter;
        private int _groupId;

        public string SelectedIpBaseNr;
        public int? SelectedIpNameNr;

        public FormSelectParty(int groupId)
        {
            InitializeComponent();

            _filter = "";
            _groupId = groupId;
            SelectedIpNameNr = null;
        }

        private void FormSelectParty_Load(object sender, EventArgs e)
        {
            lvParties.Columns.Add("#", 30);
            lvParties.Columns.Add("IpBaseNr", 100);
            lvParties.Columns.Add("MainIpNameNr", 100);
            lvParties.Columns.Add("MainName", 100);
            lvParties.Columns.Add("MainFstName", 100);
            lvParties.Columns.Add("FoundIpNameNr", 100);
            lvParties.Columns.Add("FoundName", 100);
            lvParties.Columns.Add("FoundFstName", 100);

            RefreshControls();
        }

        private void RefreshControls()
        {
            if(!_filter.Equals(tbFilter.Text, StringComparison.OrdinalIgnoreCase))
            {
                lvParties.Items.Clear();
            }
            btnSearch.Enabled = !string.IsNullOrEmpty(tbFilter.Text.Trim()) 
                && !_filter.Equals(tbFilter.Text, StringComparison.OrdinalIgnoreCase);
            btnSelect.Enabled = lvParties.SelectedItems.Count == 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filter = tbFilter.Text;
            var parts = filter.Split('-');
            if(parts.Count() == 3 && parts[0].Trim().ToUpper() == "I")
            {
                SearchByIpBaseNr(filter);
            }
            else
            {
                SearchByName(filter);
            }
        }

        private void SearchByIpBaseNr(string filter)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandText = @"
                        select
                              t1.IpBaseNr   as IpBaseNr
                            , t2.IpNameNr   as MainIpNameNr
                            , t2.Name       as MainName
                            , t2.FstName    as MainFstName
                            , null          as FoundIpNameNr
                            , null          as FoundName
                            , null          as FoundFstName
                        from  SocIpi..IpiBase t1
                            join SocIpi..IpiName t2 on t1.IpBaseNr = t2.IpBaseNr
                        where t1.IpBaseNr = @filter
                            and t2.NameType = 'PA'
                        order by t2.Name
                    ";
                    cmd.Parameters.AddWithValue("@filter", filter);
                    using (var r = cmd.ExecuteReader())
                    {
                        lvParties.Items.Clear();
                        var rowIdx = 1;
                        while (r.Read())
                        {
                            var item = lvParties.Items.Add(rowIdx.ToString());
                            var colIdx = 0;
                            item.SubItems.Add(r.GetString(colIdx++));
                            item.SubItems.Add(r.GetInt32(colIdx++).ToString());
                            item.SubItems.Add(r.GetString(colIdx++));
                            item.SubItems.Add(r.GetString(colIdx++));
                            item.SubItems.Add(r.IsDBNull(colIdx) ? "" : r.GetInt32(colIdx++).ToString());
                            item.SubItems.Add(r.IsDBNull(colIdx) ? "" : r.GetString(colIdx++));
                            item.SubItems.Add(r.IsDBNull(colIdx) ? "" : r.GetString(colIdx++));
                            rowIdx++;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                _filter = tbFilter.Text;
                RefreshControls();
            }
        }

        private void SearchByName(string filter)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spIpiPartySelect";
                    cmd.Parameters.AddWithValue("@nameStart", filter);
                    using (var r = cmd.ExecuteReader())
                    {
                        lvParties.Items.Clear();
                        var rowIdx = 1;
                        while (r.Read())
                        {
                            var item = lvParties.Items.Add(rowIdx.ToString());
                            var colIdx = 0;
                            item.SubItems.Add(r.GetString(colIdx++));
                            item.SubItems.Add(r.GetInt32(colIdx++).ToString());
                            item.SubItems.Add(r.GetString(colIdx++));
                            item.SubItems.Add(r.GetString(colIdx++));
                            item.SubItems.Add(r.IsDBNull(colIdx) ? "" : r.GetInt32(colIdx++).ToString());
                            item.SubItems.Add(r.IsDBNull(colIdx) ? "" : r.GetString(colIdx++));
                            item.SubItems.Add(r.IsDBNull(colIdx) ? "" : r.GetString(colIdx++));
                            rowIdx++;
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
                _filter = tbFilter.Text;
                RefreshControls();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectedIpBaseNr = lvParties.SelectedItems[0].SubItems[1].Text;
            SelectedIpNameNr = int.Parse(lvParties.SelectedItems[0].SubItems[2].Text);
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void lvParties_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }
    }
}
