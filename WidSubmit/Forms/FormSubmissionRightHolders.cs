using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidSubmit
{
    public partial class FormSubmissionRightHolders : Form
    {
        public class RightHolder
        {
	        public int Id			    { get; set; }
	        public int CustId		    { get; set; }
	        public string Name	        { get; set; }
            public string FstName	    { get; set; }
            public bool IsInSubm        { get; set; }
            public bool SubmAsOwn	    { get; set; }
        }

        private List<RightHolder> _rightHolders;

        private bool _ignoreSelectedIndexChanged = false;
        private bool _forceClose = false;

        public FormSubmissionRightHolders()
        {
            InitializeComponent();
        }

        private void FormSubmissionRightHolders_Load(object sender, EventArgs e)
        {
            Configure();
            LoadRightHolders();
            FillLvOwnRightHolders();
            FillLvSubmRightHolders();
        }

        private void Configure()
        {
            lvOwnRightHolders.FullRowSelect = true;
            lvOwnRightHolders.GridLines = true;
            lvOwnRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvOwnRightHolders.MultiSelect = false;
            lvOwnRightHolders.View = View.Details;
            lvOwnRightHolders.SmallImageList = ilStatuses;

            lvOwnRightHolders.Columns.Clear();
            lvOwnRightHolders.Columns.Add("№", 50);
            lvOwnRightHolders.Columns.Add("ID", 50);
            lvOwnRightHolders.Columns.Add("Код СМАРТ", 80);
            lvOwnRightHolders.Columns.Add("Назва СМАРТ", 200);

            lvSubmRightHolders.FullRowSelect = true;
            lvSubmRightHolders.GridLines = true;
            lvSubmRightHolders.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvSubmRightHolders.MultiSelect = false;
            lvSubmRightHolders.View = View.Details;

            lvSubmRightHolders.Columns.Clear();
            lvSubmRightHolders.Columns.Add("№", 40);
            lvSubmRightHolders.Columns.Add("ID", 50);
            lvSubmRightHolders.Columns.Add("Код СМАРТ", 80);
            lvSubmRightHolders.Columns.Add("Назва СМАРТ", 200);
            lvSubmRightHolders.Columns.Add("Свій для WID", 90);
        }

        private void LoadRightHolders()
        {
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = $@"
                    select
                          t1.Id																as Id		
                        , t1.CustId															as CustId	
                        , t1.Name															as Name
                        , t1.FstName														as FstName
	                    , cast(case when t2.Id is null then 0 else 1 end as bit)			as IsInSubm 
	                    , cast(case when t2.Id is null then 1 else t2.SubmAsOwn end as bit)	as SubmAsOwn
                    from vCurOwnRightHolder t1
	                    left join vCurSubmRightHolder t2 on t1.Id = t2.RightHolderId
                    order by t1.Name, t1.FstName
                ";
                using (var r = cmd.ExecuteReader())
                {
                    
                    _rightHolders = new List<RightHolder>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var rh = new RightHolder();
	                    rh.Id		        = r.GetInt32(idx);                                  idx++;
	                    rh.CustId	        = r.GetInt32(idx);                                  idx++;
	                    rh.Name             = r.GetString(idx);                                 idx++;
                        rh.FstName          = r.GetString(idx);                                 idx++;
                        rh.IsInSubm         = r.GetBoolean(idx);                                idx++;
                        rh.SubmAsOwn        = r.GetBoolean(idx);                                idx++;
                        
                        _rightHolders.Add(rh);
                    }
                }
            });
        }

        private void FillLvOwnRightHolders()
        {
            lvOwnRightHolders.BeginUpdate();
            lvOwnRightHolders.Items.Clear();
            var seqNr = 1;
            _rightHolders.ForEach(x =>
            {
                var item = new ListViewItem(seqNr.ToString());
                item.SubItems.Add(x.Id.ToString());
                item.SubItems.Add(x.CustId.ToString());
                item.SubItems.Add($"{x.Name} {x.FstName}".Trim());
                item.ImageIndex = x.IsInSubm ? 2 : 4;
                item.Tag = x;
                lvOwnRightHolders.Items.Add(item);
                seqNr++;
            });
            lvOwnRightHolders.EndUpdate();
        }

        private void FillLvSubmRightHolders()
        {
            lvSubmRightHolders.BeginUpdate();
            lvSubmRightHolders.Items.Clear();
            var seqNr = 1;
            _rightHolders.ForEach(x =>
            {
                if (x.IsInSubm)
                {
                    var item = new ListViewItem(seqNr.ToString());
                    item.SubItems.Add(x.Id.ToString());
                    item.SubItems.Add(x.CustId.ToString());
                    item.SubItems.Add($"{x.Name} {x.FstName}".Trim());
                    item.SubItems.Add(x.SubmAsOwn ? "так" : "ні");
                    item.Tag = x;
                    lvSubmRightHolders.Items.Add(item);
                    seqNr++;
                }
            });
            lvSubmRightHolders.EndUpdate();
        }

        private void lvSubmRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ignoreSelectedIndexChanged)
            {
                return;
            }
            
            if(lvSubmRightHolders.SelectedItems.Count == 0)
            {
                return;
            }
            
            _ignoreSelectedIndexChanged = true;
            lvOwnRightHolders.SelectedItems.Clear();
            
            var rightHolder = (RightHolder)lvSubmRightHolders.SelectedItems[0].Tag;
            foreach(ListViewItem item in lvOwnRightHolders.Items)
            {
                if(((RightHolder)item.Tag).Id == rightHolder.Id)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }

            _ignoreSelectedIndexChanged = false;
        }

        private void lvOwnRightHolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_ignoreSelectedIndexChanged)
            {
                return;
            }
            
            if(lvOwnRightHolders.SelectedItems.Count == 0)
            {
                return;
            }
            
            _ignoreSelectedIndexChanged = true;
            lvSubmRightHolders.SelectedItems.Clear();
            
            var rightHolder = (RightHolder)lvOwnRightHolders.SelectedItems[0].Tag;
            foreach(ListViewItem item in lvSubmRightHolders.Items)
            {
                if(((RightHolder)item.Tag).Id == rightHolder.Id)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }

            _ignoreSelectedIndexChanged = false;
        }

        private void lvSubmRightHolders_DoubleClick(object sender, EventArgs e)
        {
            if(lvSubmRightHolders.SelectedItems.Count == 0)
            {
                return;
            }

            var item = lvSubmRightHolders.SelectedItems[0];
            var rh = (RightHolder)item.Tag;
            rh.SubmAsOwn = !rh.SubmAsOwn;
            item.SubItems[4].Text = rh.SubmAsOwn ? "так" : "ні";
        }

        private void lvOwnRightHolders_DoubleClick(object sender, EventArgs e)
        {
            if(lvOwnRightHolders.SelectedItems.Count == 0)
            {
                return;
            }

            var ownItem = lvOwnRightHolders.SelectedItems[0];
            var ownRh = (RightHolder)ownItem.Tag;
            ownRh.IsInSubm = !ownRh.IsInSubm;
            ownItem.ImageIndex = ownRh.IsInSubm ? 2 : 4;

            _ignoreSelectedIndexChanged = true;
            var isFound = false;
            foreach(ListViewItem submItem in lvSubmRightHolders.Items)
            {
                if(((RightHolder)submItem.Tag).Id == ownRh.Id)
                {
                    lvSubmRightHolders.Items.Remove(submItem);
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                FillLvSubmRightHolders();
                foreach(ListViewItem submItem in lvSubmRightHolders.Items)
                {
                    if(((RightHolder)submItem.Tag).Id == ownRh.Id)
                    {
                        submItem.Selected = true;
                        submItem.EnsureVisible();
                        break;
                    }
                }
            }

            _ignoreSelectedIndexChanged = false;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Застосувати зміни і закрити форму?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.No)
            {
                return;
            }

            _forceClose = true;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Helpers.RunSqlSocWidSubmitExT(cmd =>
                {
                    cmd.CommandText = "select newid()";
                    var guid = cmd.ExecuteScalar();

                    cmd.CommandText = "insert Z_SubmRightHolder values(@guid, @rightHolderId, @submAsOwn)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@rightHolderId", 0);
                    cmd.Parameters.AddWithValue("@submAsOwn", 1);

                    _rightHolders.Where(x => x.IsInSubm).ToList().ForEach(x =>
                    {
                        cmd.Parameters[1].Value = x.Id;
                        cmd.Parameters[2].Value = x.SubmAsOwn;
                        cmd.ExecuteNonQuery();
                    });

                    cmd.CommandText = "spSubmRightHoldersSave";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.ExecuteNonQuery();
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Збереження результатів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

            Close();
        }

        private void FormSubmissionRightHolders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_forceClose)
            {
                e.Cancel = false;
                return;
            }
            var res = MessageBox.Show("Відмінити зміни і закрити форму?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = res == DialogResult.No;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
