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
    public partial class UcWidSubmWorkNames : UserControl
    {
        public class WorkName
        {
           public int Id                { get; set; }
           public int WidSubmGroupId    { get; set; }
           public int ObjId             { get; set; }
           public string LocalName      { get; set; }
           public string WidName        { get; set; }
           public bool IsMain           { get; set; }
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

        private List<WorkName> _workNames;
        private List<WorkName> _newWorkNames;

        public UcWidSubmWorkNames()
        {
            InitializeComponent();
        }

        private void UcWidSubmNames_Load(object sender, EventArgs e)
        {
            lvNames.Columns.Add("", 20);
            lvNames.Columns.Add("Локальна назва", 200);
            lvNames.Columns.Add("Назва в WID", 200);
            lvNames.Columns.Add("Затв.", 60);
            lvNames.Columns.Add("Змінено", 60);
            lvNames.Columns.Add("", 100); // IsDuplicate
        }

        public void SetGroupAndObjId(WidSubmGroup group, int? objId)
        {
            _group = group;
            _objId = objId;
            LoadData();
       }

        private void LoadData()
        {
            FillNames();
            tbName.Text = "";
            UpdateControls();
        }

        private void FillNames()
        {
            lvNames.Items.Clear();
            if(_group == null || _objId == null)
            {
                return;
            }

            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupWorkNameSelect";
                cmd.Parameters.AddWithValue("@WidSubmGroupId", _group.Id);
                cmd.Parameters.AddWithValue("@ObjId", _objId);
                _workNames = new List<WorkName>();
                _newWorkNames = new List<WorkName>();
                using (var r = cmd.ExecuteReader())
                {
                    while(r.Read())
                    {
                        _workNames.Add(new WorkName
                        {
                            Id               = r.GetInt32(0),
                            WidSubmGroupId   = r.GetInt32(1),
                            ObjId            = r.GetInt32(2),
                            LocalName        = r.GetString(3),
                            WidName          = r.GetBoolean(6) ? r.GetString(4) : Translit.FromUkr(r.GetString(3)),
                            IsMain           = r.GetBoolean(5),
                            IsConfirmed      = r.GetBoolean(6),
                            IsDuplcate       = r.GetBoolean(7),
                            CreatedBy        = r.GetString(8),
                            ModifiedBy       = r.GetString(9),
                            CreatedAt        = r.GetDateTime(10),
                            ModifiedAt       = r.GetDateTime(11),
                        });

                        _newWorkNames.Add(new WorkName
                        {
                            Id = r.GetInt32(0),
                            WidSubmGroupId = r.GetInt32(1),
                            ObjId = r.GetInt32(2),
                            LocalName = r.GetString(3),
                            WidName = r.GetBoolean(6) ? r.GetString(4) : Translit.FromUkr(r.GetString(3)),
                            IsMain = r.GetBoolean(5),
                            IsConfirmed = r.GetBoolean(6),
                            IsDuplcate = r.GetBoolean(7),
                            CreatedBy = r.GetString(8),
                            ModifiedBy = r.GetString(9),
                            CreatedAt = r.GetDateTime(10),
                            ModifiedAt = r.GetDateTime(11),
                        });
                    }
                    
                }
            });

            // Check for duplicate names
            CheckForDuplicates();

            _newWorkNames.ForEach(x =>
            {
                var item = lvNames.Items.Add(x.IsMain ? "*" : "");
                item.SubItems.Add(x.LocalName);
                item.SubItems.Add(x.WidName);
                item.SubItems.Add(x.IsConfirmed ? "Так" : "Ні");
                item.SubItems.Add(x.ModifiedBy);
                item.SubItems.Add(x.IsDuplcate ? "Дублікат, не буде передано" : "");
                item.Tag = x;
            });
        }

        private void CheckForDuplicates()
        {
            _newWorkNames.ForEach(x => x.IsDuplcate = false);
            for (var idxCur = 0; idxCur < _newWorkNames.Count; idxCur++)
            {
                var curName = _newWorkNames[idxCur];
                for (var idxPrev = 0; idxPrev < idxCur; idxPrev++)
                {
                    if (_newWorkNames[idxPrev].WidName.Equals(curName.WidName, StringComparison.OrdinalIgnoreCase))
                    {
                        curName.IsDuplcate = true;
                        break;
                    }
                }
            }
        }

        private void UpdateList()
        {
            foreach(ListViewItem item in lvNames.Items)
            {
                int i = 1;
                var workName = (WorkName)item.Tag;
                item.SubItems[i++].Text = workName.LocalName;
                item.SubItems[i++].Text = workName.WidName;
                item.SubItems[i++].Text = workName.IsConfirmed ? "Так" : "Ні";
                item.SubItems[i++].Text = workName.CreatedBy;
                item.SubItems[i++].Text = workName.IsDuplcate ? "Дублікат, не буде передано" : "";
            }
        }

        private void UpdateControls()
        {
            if(_group.Status == WidSubmGroupStatus.Closed)
            {

                tbName.Visible =
                btnApply.Visible =
                btnRus.Visible =
                btnUkr.Visible = false;
                return;
            }
            var workName = GetCurWorkName();
            if(workName == null)
            {
                tbName.Enabled =
                btnApply.Enabled =
                btnRus.Enabled =
                btnUkr.Enabled = false;
            }
            else
            {
                var oldWorkName = _workNames.Single(x => x.Id == workName.Id);

                tbName.Enabled = true;
                btnApply.Enabled = false;

                btnRus.Enabled =
                btnUkr.Enabled = true;
            }
        }

        private void btnUkr_Click(object sender, EventArgs e)
        {
            var workName = GetCurWorkName();
            tbName.Text = Translit.FromUkr(workName.LocalName);
        }

        private void btnRus_Click(object sender, EventArgs e)
        {
            var workName = GetCurWorkName();
            tbName.Text = Translit.FromRus(workName.LocalName);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var workName = GetCurWorkName();
            workName.WidName = tbName.Text.ToUpper();
            workName.IsConfirmed = false;
            workName.ModifiedBy = "oper";
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
                cmd.CommandText = "spWidSubmGroupWorkNameApprove";
                _newWorkNames.ForEach(x =>
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@WidSubmGroupWorkNameId", x.Id);
                    cmd.Parameters.AddWithValue("@IsDuplicate", x.IsDuplcate);
                    cmd.Parameters.AddWithValue("@WidName", x.WidName.Trim());
                    cmd.Parameters.AddWithValue("@ModifiedBy", x.ModifiedBy);
                    cmd.ExecuteNonQuery();
                });
            });
            LoadData();
            ChangedEvent?.Invoke();
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            var workName = GetCurWorkName();
            if(workName != null)
            {
                btnApply.Enabled = !workName.WidName.Equals(tbName.Text, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                btnApply.Enabled = false;
            }
        }

        private void lvNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var workName = GetCurWorkName();
            if(workName != null)
            {
                tbName.Text = workName.WidName;
            }
            else
            {
                tbName.Text = "";
            }
            UpdateControls();
        }

        private WorkName GetCurWorkName()
        {
            if(lvNames.SelectedItems.Count == 0)
            {
                return null;
            }
            return (WorkName)lvNames.SelectedItems[0].Tag;
        }
    }
}
