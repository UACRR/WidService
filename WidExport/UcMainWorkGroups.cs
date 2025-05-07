using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidExport
{
    public partial class UcMainWorkGroups : UserControl
    {
        private string[] _widSubmGroupStatusText =
        {
            "Активна",
            "Закрита",
        };

        private List<WidSubmGroup> _groups;

        public WidSubmGroup _selectedGroup { get; set; }
         public UcMainWorkGroups()
        {
            InitializeComponent();
        }

        public void RefreshStatistics()
        {
            ucWidGroupStatistics.SetGroup(_selectedGroup == null ? (int?)null : _selectedGroup.Id);
        }

        private void UcMainWorkGroups_Load(object sender, EventArgs e)
        {
            lvGroups.Columns.Add("№пп", 40);
            lvGroups.Columns.Add("Код", 60);
            lvGroups.Columns.Add("Назва", 180);
            lvGroups.Columns.Add("Статус", 65);

            if (!DesignMode)
            {
                FillGroups();
                RefreshControls();
            }
        }

        private void FillGroups()
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupSelect";
                using (var r = cmd.ExecuteReader())
                {
                    _groups = new List<WidSubmGroup>();
                    lvGroups.Items.Clear();
                    while (r.Read())
                    {
                        AddItem(r);
                    }
                }
            });
        }

        private void AddItem(SqlDataReader r)
        {
            var newGroup = new WidSubmGroup
            {
                Id = r.GetInt32(0),
                SeqNr = r.GetInt32(1),
                Name = r.GetString(2),
                Status = (WidSubmGroupStatus)r.GetInt32(3),
                GroupType = Convert.ToChar(r.GetValue(4)),
            };
            _groups.Add(newGroup);

            var seqNr = newGroup.SeqNr;
            var item = lvGroups.Items.Add(seqNr < 0 ? "" : seqNr.ToString());
            item.SubItems.Add(newGroup.Id.ToString());
            item.SubItems.Add(newGroup.Name);
            item.SubItems.Add(_widSubmGroupStatusText[(int)newGroup.Status]);
            item.Tag = newGroup;
        }

        private void RefreshControls()
        {
            btnShow.Visible             =
            btnCreateSubmFile.Visible   =
            btnDeleteGroup.Visible      =
            btnClose.Visible            =
            btnUpdate.Visible           =
            btnRefreshWicIswc.Visible   = false;

            if (_selectedGroup != null)
            {
                btnShow.Visible             = true;
                btnCreateSubmFile.Visible   = _selectedGroup.Status != WidSubmGroupStatus.Closed;
                btnDeleteGroup.Visible      =
                btnClose.Visible            =
                    _selectedGroup.GroupType == 'M' && _selectedGroup.Status != WidSubmGroupStatus.Closed;
                btnUpdate.Visible           = _selectedGroup.GroupType == 'C';
                btnRefreshWicIswc.Visible   = true;
            }

            FillParties();
            ucWidGroupStatistics.SetGroup(_selectedGroup == null ? (int?)null : _selectedGroup.Id);
            labelGroupName.Text = _selectedGroup == null ? "<групу не вибрано>" : _selectedGroup.Name;
        }
        private void FillParties()
        {
            panelButtons.Items.Clear();
            if (_selectedGroup == null)
            {
                return;
            }

            panelButtons.Items.Clear();

            if(_selectedGroup.SeqNr < 0)
            {
                panelButtons.Items.Add("<ВСІ АВТОРИ>");
            }
            else
            {
                Helpers.RunSqlSocWidSubmit(cmd => {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupPartySelect";
                    cmd.Parameters.AddWithValue("@groupId", _selectedGroup.Id);
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            panelButtons.Items.Add(r.GetString(5));
                        }
                    }
                });
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupAdd";
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    AddItem(r);
                }
            });
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (
                DialogResult.Yes != MessageBox.Show(
                    "Видалення групи може призвести до втрати важливої інформації. Видалити?",
                    "Видалення групи",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                return;
            }

            var hasAuthors = false;
            if (_selectedGroup != null)
            {
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandText = @"
                        select *
                        from WidSubmGroupParty
                        where WidSubmGroupId = @groupId
                    ";
                    cmd.Parameters.AddWithValue("@groupId", (int)_selectedGroup.Id);
                    using(var r = cmd.ExecuteReader())
                    {
                        hasAuthors = r.HasRows;
                    }
                }); 
            }
            if (hasAuthors)
            {
                MessageBox.Show(
                    "Група містить авторів, видалення неможливе.",
                    "Видалення групи",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupDeleteLast";
                cmd.ExecuteNonQuery();
                lvGroups.Items.Remove(lvGroups.Items[lvGroups.Items.Count - 1]);
            });
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            var form = new FormWidSubmit(_selectedGroup, null);
            form.Show();
        }

        private void lvGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvGroups.SelectedItems.Count == 0)
            {
                _selectedGroup = null;
            }
            else
            {
                var item = lvGroups.SelectedItems[0];
                _selectedGroup = (WidSubmGroup)item.Tag;
            }
            using (var wc = new WaitCursor())
            RefreshControls();
        }

        private void CreateSubmFile()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var fileHasWorks = false;
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"
                        select count(*) 
                        from WidSubmGroupWork 
                        where WidSubmGroupId = @groupId 
                            and ShouldResubmit = 1
                    ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", _selectedGroup.Id);
                    var cnt = (int)cmd.ExecuteScalar();
                    fileHasWorks = cnt > 0;
                });

                if (!fileHasWorks)
                {
                    if (DialogResult.Yes !=
                        MessageBox.Show("Відсутні твори для передачі, файл не буде створений.",
                            "Публікація творів",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning))
                    {
                        return;
                    }
                }


                var fileExists = false;
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandText = "select null from SubmFile where SubmFileStatus = 0";
                    using (var r = cmd.ExecuteReader())
                    {
                        fileExists = r.HasRows;
                    }
                });

                if (fileExists)
                {
                    if (DialogResult.Yes !=
                        MessageBox.Show("Підготовлений до передачі в WID файл вже створений. Замінити його на новий?",
                            "Публікація творів",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        return;
                    }
                }

                var builder = new WidTransBuilder();
                builder.CreateSubmFile((int)_selectedGroup.Id);

                //lvGroups.SelectedItems[0].SubItems[3].Text = _widSubmGroupStatusText[(int)WidSubmGroupStatus.FileCreated];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }
        private void btnCreateSubmFile_Click(object sender, EventArgs e)
        {
            CreateSubmFile();
            ucWidGroupStatistics.SetGroup(_selectedGroup == null ? (int?)null : _selectedGroup.Id);
        }

        private void CloseChildForms()
        {
            var formsToClose = new List<FormWidSubmit>();
            foreach (var form in Application.OpenForms)
            {
                if(form.GetType() == typeof(FormWidSubmit))
                {
                    formsToClose.Add((FormWidSubmit)form);
                }
            }
            formsToClose.ForEach(x =>
            {
                x.Close();
            });
        }

        private void btnRefreshWicIswc_Click(object sender, EventArgs e)
        {
            var cntCandidateWorks = 0;
            var cntNotReadyWorks = 0;
            var cntPassedWorks = 0;
            using (var wc = new WaitCursor())
            {
                Helpers.RunSqlSocWidSubmitT(cmd =>
                {
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmAllApplyToSmart";

                    SqlParameter pmCntCandidateWorks = new SqlParameter();
                    pmCntCandidateWorks.ParameterName = "@cntCandidateWorks";
                    pmCntCandidateWorks.DbType = DbType.Int32;
                    pmCntCandidateWorks.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pmCntCandidateWorks);

                    SqlParameter pmCntNotReadyWorks = new SqlParameter();
                    pmCntNotReadyWorks.ParameterName = "@cntNotReadyWorks";
                    pmCntNotReadyWorks.DbType = DbType.Int32;
                    pmCntNotReadyWorks.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pmCntNotReadyWorks);

                    SqlParameter pmCntPassedWorks = new SqlParameter();
                    pmCntPassedWorks.ParameterName = "@cntPassedWorks";
                    pmCntPassedWorks.DbType = DbType.Int32;
                    pmCntPassedWorks.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pmCntPassedWorks);

                    cmd.ExecuteNonQuery();

                    cntCandidateWorks   = (int)pmCntCandidateWorks.Value;
                    cntNotReadyWorks    = (int)pmCntNotReadyWorks .Value;
                    cntPassedWorks      = (int)pmCntPassedWorks   .Value;
            
                });
            }

            ucWidGroupStatistics.SetGroup(_selectedGroup == null ? (int?)null : _selectedGroup.Id);

            var msg = 
                  $"{cntCandidateWorks} нових творів створено в WID для передачі в СМАРТ\r\n"
                + $"{cntNotReadyWorks} творів з них не отримали код ISWC\r\n"
                + $"{cntPassedWorks} творів передано в СМАРТ\r\n";
            MessageBox.Show(msg, "Передача творів в СМАРТ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            CloseChildForms();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Буде реалізовано пізніше", "Публікація творів в WID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Не передані в WID твори будуть переміщені в окрему групу. Продовжити?",
                "Закриття групи творів",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if(res == DialogResult.No)
            {
                return;
            }

            var procResult = 0;
            using (var wc = new WaitCursor())
            {
                Helpers.RunSqlSocWidSubmitT(cmd =>
                {
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupClose";
                    cmd.Parameters.AddWithValue("@groupId", _selectedGroup.Id);
                    SqlParameter returnValue = new SqlParameter();
                    returnValue.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add(returnValue);
                    cmd.ExecuteNonQuery();
                    procResult = (int)returnValue.Value;
                });
            }

            switch (procResult)
            {
                case -1:
                    MessageBox.Show(
                        "Обробка групи не завершена. Твори групи не повинні бути заплановані до передачі.",
                        "Закриття групи творів", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    break;
                default:
                    ucWidGroupStatistics.SetGroup(_selectedGroup == null ? (int?)null : _selectedGroup.Id);
                    _selectedGroup.Status = WidSubmGroupStatus.Closed;
                    lvGroups.SelectedItems[0].SubItems[3].Text = _widSubmGroupStatusText[(int)_selectedGroup.Status];
                    MessageBox.Show($"Передано {procResult} творів.",
                        "Закриття групи творів", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Оновлення може зайняти тривалий час. Продовжити?",
                "Оновлення творів в групі змін",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (res == DialogResult.No)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Helpers.RunSqlSocWidSubmitT(cmd =>
            {
                cmd.CommandTimeout = 0;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupChangedWorksUpdate";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateObjIdToWicFromMs";
                cmd.Parameters.Clear();
                cmd.ExecuteNonQuery();

                var service = new WidSubmGroupPreProcService();
                service.ProcessNames(cmd, _selectedGroup.Id, false);
                service.ProcessNames(cmd, _selectedGroup.Id, true);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupUpdateChecklist";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@groupId", _selectedGroup.Id);
                cmd.ExecuteNonQuery();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spWidSubmGroupPreProc";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@groupId", _selectedGroup.Id);
                cmd.ExecuteNonQuery();
            });
            ucWidGroupStatistics.SetGroup(_selectedGroup == null ? (int?)null : _selectedGroup.Id);
            Cursor.Current = Cursors.Default;
        }
    }
}
