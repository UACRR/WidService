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
    public partial class UcWidSubmWorkPerformers
        : UserControl
    {
        public class WorkPerformer
        {
           public int Id                { get; set; }
           public int WidSubmGroupId    { get; set; }
           public int ObjId             { get; set; }
           public string LocalPerformer      { get; set; }
           public string WidPerformer        { get; set; }
           public bool IsConfirmed      { get; set; }
           public bool IsDuplcate       { get; set; }
           public string CreatedBy      { get; set; }
           public string ModifiedBy     { get; set; }
           public DateTime CreatedAt    { get; set; }
           public DateTime ModifiedAt   { get; set; }
        }

        public delegate void Changed();
        public event Changed ChangedEvent;

        private WidSubmGroup _group;
        private int? _objId;
        private bool _readOnly;

        private List<WorkPerformer> _workPerformers;
        private List<WorkPerformer> _newWorkPerformers;

        public UcWidSubmWorkPerformers()
        {
            InitializeComponent();
        }

        private void UcWidSubmPerformers_Load(object sender, EventArgs e)
        {
            lvPerformers.Columns.Add("Локальна назва", 200);
            lvPerformers.Columns.Add("Назва в WID", 200);
            lvPerformers.Columns.Add("Затв.", 60);
            lvPerformers.Columns.Add("Змінено", 60);
            lvPerformers.Columns.Add("", 100); // IsDuplicate
        }

        public void SetGroupAndObjId(WidSubmGroup group, bool readOnly, int? objId)
        {
            _group = group;
            _objId = objId;
            _readOnly = readOnly;
            LoadData();
       }

        private void LoadData()
        {
            FillPerformers();
            tbPerformer.Text = "";
            UpdateControls();
        }

        private void FillPerformers()
        {
            lvPerformers.Items.Clear();
            if(_group == null || _objId == null)
            {
                return;
            }

            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupWorkPerformerSelect";
                cmd.Parameters.AddWithValue("@WidSubmGroupId", _group.Id);
                cmd.Parameters.AddWithValue("@ObjId", _objId);
                _workPerformers = new List<WorkPerformer>();
                _newWorkPerformers = new List<WorkPerformer>();
                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        _workPerformers.Add(new WorkPerformer
                        {
                            Id               = r.GetInt32(0),
                            WidSubmGroupId   = r.GetInt32(1),
                            ObjId            = r.GetInt32(2),
                            LocalPerformer    = r.GetString(3),
                            WidPerformer      = r.GetBoolean(5) ? r.GetString(4) : Translit.FromUkr(r.GetString(3)),
                            IsConfirmed      = r.GetBoolean(5),
                            IsDuplcate       = r.GetBoolean(6),
                            CreatedBy        = r.GetString(7),
                            ModifiedBy       = r.GetString(8),
                            CreatedAt        = r.GetDateTime(9),
                            ModifiedAt       = r.GetDateTime(10),
                        });

                        _newWorkPerformers.Add(new WorkPerformer
                        {
                            Id = r.GetInt32(0),
                            WidSubmGroupId = r.GetInt32(1),
                            ObjId = r.GetInt32(2),
                            LocalPerformer = r.GetString(3),
                            WidPerformer = r.GetBoolean(5) ? r.GetString(4) : Translit.FromUkr(r.GetString(3)),
                            IsConfirmed = r.GetBoolean(5),
                            IsDuplcate = r.GetBoolean(6),
                            CreatedBy = r.GetString(7),
                            ModifiedBy = r.GetString(8),
                            CreatedAt = r.GetDateTime(9),
                            ModifiedAt = r.GetDateTime(10),
                        });
                    }
                    
                }
            });

            // Check for duplicate performers
            CheckForDuplicates();

            _newWorkPerformers.ForEach(x =>
            {
                var item = lvPerformers.Items.Add(x.LocalPerformer);
                item.SubItems.Add(x.WidPerformer);
                item.SubItems.Add(x.IsConfirmed ? "Так" : "Ні");
                item.SubItems.Add(x.ModifiedBy);
                item.SubItems.Add(x.IsDuplcate ? "Дублікат, не буде передано" : "");
                item.Tag = x;
            });
        }

        private void CheckForDuplicates()
        {
            _newWorkPerformers.ForEach(x => x.IsDuplcate = false);
            for (var idxCur = 0; idxCur < _newWorkPerformers.Count; idxCur++)
            {
                var curPerformer = _newWorkPerformers[idxCur];
                for (var idxPrev = 0; idxPrev < idxCur; idxPrev++)
                {
                    if (_newWorkPerformers[idxPrev].WidPerformer.Equals(curPerformer.WidPerformer, StringComparison.OrdinalIgnoreCase))
                    {
                        curPerformer.IsDuplcate = true;
                        break;
                    }
                }
            }
        }

        private void UpdateList()
        {
            foreach(ListViewItem item in lvPerformers.Items)
            {
                int i = 1;
                var workPerformer = (WorkPerformer)item.Tag;
                item.Text = workPerformer.LocalPerformer;
                item.SubItems[i++].Text = workPerformer.WidPerformer;
                item.SubItems[i++].Text = workPerformer.IsConfirmed ? "Так" : "Ні";
                item.SubItems[i++].Text = workPerformer.CreatedBy;
                item.SubItems[i++].Text = workPerformer.IsDuplcate ? "Дублікат, не буде передано" : "";
            }
        }

        private void UpdateControls()
        {
            if(_group.Status == WidSubmGroupStatus.Closed)
            {
                tbPerformer.Visible =
                btnApply.Visible =
                btnRus.Visible =
                btnUkr.Visible = false;
                return;
            }
            var workPerformer = GetCurWorkPerformer();
            if(workPerformer == null)
            {
                tbPerformer.Enabled =
                btnApply.Enabled =
                btnRus.Enabled =
                btnUkr.Enabled = false;
            }
            else
            {
                var oldWorkPerformer = _workPerformers.Single(x => x.Id == workPerformer.Id);

                tbPerformer.Enabled = true;
                btnApply.Enabled = false;

                btnRus.Enabled =
                btnUkr.Enabled = true;

                if(_readOnly)
                {
                    tbPerformer.Enabled =
                    btnApply.Enabled =
                    btnRus.Enabled =
                    btnUkr.Enabled = false;
                }
            }
        }

        private void btnUkr_Click(object sender, EventArgs e)
        {
            var workPerformer = GetCurWorkPerformer();
            tbPerformer.Text = Translit.FromUkr(workPerformer.LocalPerformer);
        }

        private void btnRus_Click(object sender, EventArgs e)
        {
            var workPerformer = GetCurWorkPerformer();
            tbPerformer.Text = Translit.FromRus(workPerformer.LocalPerformer);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var workPerformer = GetCurWorkPerformer();
            workPerformer.WidPerformer = tbPerformer.Text.ToUpper();
            workPerformer.IsConfirmed = false;
            workPerformer.ModifiedBy = "oper";
            CheckForDuplicates();
            UpdateList();
            UpdateControls();
            ApproveAll();
        }

        private void ApproveAll()
        {
            Helpers.RunSqlSocWidSubmitT(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupWorkPerformerApprove";
                _newWorkPerformers.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@WidSubmGroupWorkPerformerId", x.Id);
                    cmd.Parameters.AddWithValue("@WidPerformer", x.WidPerformer.Trim());
                    cmd.Parameters.AddWithValue("@ModifiedBy", x.ModifiedBy);
                    cmd.ExecuteNonQuery();
                });
            });
            LoadData();
            ChangedEvent?.Invoke();
        }

        private void tbPerformer_TextChanged(object sender, EventArgs e)
        {
            var workPerformer = GetCurWorkPerformer();
            if(workPerformer != null)
            {
                btnApply.Enabled = !workPerformer.WidPerformer.Equals(tbPerformer.Text, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                btnApply.Enabled = false;
            }
        }

        private void lvPerformers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var workPerformer = GetCurWorkPerformer();
            if(workPerformer != null)
            {
                tbPerformer.Text = workPerformer.WidPerformer;
            }
            else
            {
                tbPerformer.Text = "";
            }
            UpdateControls();
        }

        private WorkPerformer GetCurWorkPerformer()
        {
            if(lvPerformers.SelectedItems.Count == 0)
            {
                return null;
            }
            return (WorkPerformer)lvPerformers.SelectedItems[0].Tag;
        }
    }
}
