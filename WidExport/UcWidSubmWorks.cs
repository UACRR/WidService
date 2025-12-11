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
    public partial class UcWidSubmWorks : UserControl
    {
        public class Work
        {
            public int    Id               { get; set; }
            public int    ObjId            { get; set; }
            public string Name          { get; set; }
            public string Performer     { get; set; }
            public int    Status           { get; set; }
            public int?   Wic           { get; set; }
            public string Iswc          { get; set; }
            public bool? ShouldSubmit { get; set; }
            public string ReSubmitIswc { get; set; }
            public string TransType { get; set; }
        }

        public class WidSubmGroupWorkStatus
        {
            public int Id { get; set; }
            public string Description { get; set; }
        }

        private string[] WidSubmGroupWorkStatusDescription = new string[]
        {
            "Не оброблено"      ,
            "На розгляді"       ,
            "Відкладено"        ,
            "Узгоджено"       ,
            "Надіслано WID"         ,
            "Прийнято WID"          ,
            "Відхилено WID"         ,
            "Прийнято WID умовно"   ,
            "Існувало в WID"       ,
            "Надіслано повторно",
            "Завершено"         ,
        };

        private WidSubmGroup _group;
        private int? _ipNameNr;
        private int? _objId;

        private List<Work> _works;

        public UcWidSubmWorks()
        {
            InitializeComponent();
        }
        private void UcWidSubmWorks_Load(object sender, EventArgs e)
        {
            FillWorks();

            cbFilterStatus.DisplayMember = "Description";
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = -1, Description = "<Всі>" }); 
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 8, Description = "Існували в WID" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 3, Description = "Узгоджені" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 2, Description = "Відкладені" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 4, Description = "Надіслані WID" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 5, Description = "Прийняті WID" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 7, Description = "Прийняті WID умовно" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 6, Description = "Відхилені WID" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 9, Description = "Надіслані повторно" });
            cbFilterStatus.Items.Add(new WidSubmGroupWorkStatus { Id = 10, Description = "Завершені" });
            cbFilterStatus.SelectedIndex = 0;

            cbFilterSubmit.Items.Add("<Всі>");
            cbFilterSubmit.Items.Add("Не визначено");
            cbFilterSubmit.Items.Add("Так");
            cbFilterSubmit.Items.Add("Ні");
            cbFilterSubmit.SelectedIndex = 0;

            cbFilterSubmType.Items.Add("<Всі>");
            cbFilterSubmType.Items.Add("Новий");
            cbFilterSubmType.Items.Add("Зміна");
            cbFilterSubmType.SelectedIndex = 0;

            lvWorks.Columns.Add("#", 40);
            lvWorks.Columns.Add("ObjId", 60);
            lvWorks.Columns.Add("Назва", 200);
            lvWorks.Columns.Add("Виконавець", 100);
            lvWorks.Columns.Add("Статус", 100);
            lvWorks.Columns.Add("Wic", 100);
            lvWorks.Columns.Add("Iswc", 100);
            lvWorks.Columns.Add("Передати", 160);
            lvWorks.Columns.Add("Iswc для передачі", 100);
            lvWorks.Columns.Add("T/T", 40);

            btnApplyFilter.Enabled = false;
            btnResetFilter.Enabled = false;

            ucWidSubmNames.ChangedEvent += UcWidSubmNames_ChangedEvent;
            ucWidSubmPerformers.ChangedEvent += UcWidSubmPerformers_ChangedEvent;
        }

        private void UcWidSubmShares_ChangedEvent()
        {
            UpdateControls();
        }

        private void UcWidSubmPerformers_ChangedEvent()
        {
            UpdateControls();
        }

        private void UcWidSubmNames_ChangedEvent()
        {
            UpdateControls();
        }

        public void SetWidSubmGroupAndParty(WidSubmGroup group, int? ipNameNr, int? objId = null)
        {
            _group = group;
            _ipNameNr = ipNameNr;
            _objId = objId;
            
            FillWorks();

            lvWorks.SelectedItems.Clear();
            
            if (objId == null)
            {
                if(lvWorks.Items.Count > 0)
                {
                    lvWorks.SelectedIndices.Add(0);
                    lvWorks.EnsureVisible(0);
                }
                else
                {
                    SetObjId(null);
                }
            }
            else
            {
                var idx = 0;
                foreach(ListViewItem item in lvWorks.Items)
                {
                    var work = (Work)item.Tag;
                    if(work.ObjId == objId)
                    {
                        lvWorks.SelectedIndices.Add(idx);
                        lvWorks.EnsureVisible(idx);
                        return;
                    }
                    idx++;
                }
            }

            UpdateControls();
        }
        private void SetObjId(int? objId)
        {
            switch (tabMwInfo.SelectedIndex)
            {
                case 0:
                    ucWidSubmShares.SetGroupAndObjId(_group.Id, objId);
                    break;
                case 1:
                    ucWidSubmNames.SetGroupAndObjId(_group, objId);
                    break;
                case 2:
                    ucWidSubmPerformers.SetGroupAndObjId(_group, objId);
                    break;
                case 4:
                    ucWidSubmWorkResp.SetGroupAndObjId(_group.Id, objId);
                    break;
            }

            // Update always because info from control is used for coloring status and drawing icons
            ucWidSubmWorkCheckList.SetGroupAndObjId(_group, objId);
        }

        private void FillWorks()
        {
            lvWorks.Items.Clear();
            _works = new List<Work>();
            if (_group == null || _ipNameNr == null)
            {
                return;
            }

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Helpers.RunSqlSocWidSubmit(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"spWidSubmGroupPartyWorkSelect";
                    cmd.Parameters.AddWithValue("@WidSubmGroupId", _group.Id);
                    cmd.Parameters.AddWithValue("@IpNameNr", _ipNameNr);
                    cmd.Parameters.AddWithValue("@status", DBNull.Value);

                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            _works.Add(new Work
                            {
                                Id = r.GetInt32(0),
                                ObjId = r.GetInt32(1),
                                Name = r.IsDBNull(2) ? "" : r.GetString(2),
                                Performer = r.IsDBNull(3) ? "" : r.GetString(3),
                                Status = r.GetInt32(4),
                                Wic = r.IsDBNull(5) ? (int?)null : r.GetInt32(5),
                                Iswc = r.IsDBNull(6) ? null : r.GetString(6),
                                ShouldSubmit = r.IsDBNull(7) ? (bool?)null : r.GetBoolean(7),
                                ReSubmitIswc = r.GetString(8),
                                TransType = r.GetString(9),
                            });
                        }
                    }
                });

                FillWorksView();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Список творів", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool CheckMeetsFilter(Work work)
        {
            var workStatus = (WidSubmGroupWorkStatus)cbFilterStatus.SelectedItem;
            if(workStatus.Id > 0 &&  work.Status != workStatus.Id)
            {
                return false;
            }

            if (
                cbFilterSubmit.SelectedIndex == 1 && work.ShouldSubmit != null ||
                cbFilterSubmit.SelectedIndex == 2 && (work.ShouldSubmit == null || !(bool)work.ShouldSubmit) ||
                cbFilterSubmit.SelectedIndex == 3 && (work.ShouldSubmit == null || (bool)work.ShouldSubmit)
            )
            {
                return false;
            }

            if (
                cbFilterSubmType.SelectedIndex == 1 && work.TransType != "A" ||
                cbFilterSubmType.SelectedIndex == 2 && work.TransType != "U"
            )
            {
                return false;
            }

            if (
                tbFilterName.Text.Trim() != "" && !work.Name.ToUpper().Contains(tbFilterName.Text.ToUpper())
            )
            {
                return false;
            }

            if (
                tbFilterPerformer.Text.Trim() != "" && !work.Performer.ToUpper().Contains(tbFilterPerformer.Text.ToUpper())
            )
            {
                return false;
            }

            if (
                tbFilterObjId.Text.Trim() != "" && work.ObjId.ToString() != tbFilterObjId.Text.Trim()
            )
            {
                return false;
            }

            return true;
        }

        private void FillWorksView()
        {
            lvWorks.Items.Clear();
            var seqNr = 1;
            _works.ForEach(x =>
            {
                if(CheckMeetsFilter(x))
                {
                    var lvItem = lvWorks.Items.Add(seqNr.ToString());
                    lvItem.SubItems.Add(x.ObjId.ToString());
                    lvItem.SubItems.Add(x.Name);
                    lvItem.SubItems.Add(x.Performer);
                    lvItem.SubItems.Add(WidSubmGroupWorkStatusDescription[x.Status]);
                    lvItem.SubItems.Add(x.Wic == null ? "" : x.Wic.ToString());
                    lvItem.SubItems.Add(x.Iswc == null ? "" : x.Iswc);
                    lvItem.SubItems.Add(GetShouldSubmitTxt(x));
                    lvItem.SubItems.Add(x.ReSubmitIswc);
                    lvItem.SubItems.Add(x.TransType);
                    lvItem.Tag = x;
                    seqNr++;
                }
            });

         }

        private string GetShouldSubmitTxt(Work work)
        {
            /*
            if (
                work.Status == (int)WidSubmGroupWorkStatusEnum.Unprocessed ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.InWork ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.Postponed ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.Accepted ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.Sent ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.AlreadyInWid ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.ReSent ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.Completed
            )
            {
                return "n/a";
            }
            */

            return work.ShouldSubmit == null ? "не визначено" :
                (bool)work.ShouldSubmit ? "так" : "ні";
        }

        private void UpdateSelectedWork()
        {
            using (var wc = new WaitCursor())
            {
                SetWorkDetailsVisble(true);
                var item = lvWorks.SelectedItems[0];
                var objId = int.Parse(item.SubItems[1].Text);
                var work = (Work)item.Tag;

                var subItemIdx = 1;

                item.SubItems[subItemIdx++].Text = work.ObjId.ToString();
                item.SubItems[subItemIdx++].Text = work.Name;
                item.SubItems[subItemIdx++].Text = work.Performer;
                item.SubItems[subItemIdx++].Text = WidSubmGroupWorkStatusDescription[work.Status];
                item.SubItems[subItemIdx++].Text = work.Wic == null ? "" : work.Wic.ToString();
                item.SubItems[subItemIdx++].Text = work.Iswc == null ? "" : work.Iswc;
                item.SubItems[subItemIdx++].Text = GetShouldSubmitTxt(work);
                item.SubItems[subItemIdx++].Text = work.ReSubmitIswc;
                item.SubItems[subItemIdx++].Text = work.TransType;

                SetObjId(objId);

                UpdateControls();
            }
        }

        private void lvWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvWorks.SelectedItems.Count == 0)
            {
                SetObjId(null);
                SetWorkDetailsVisble(false);
                return;
            }

            UpdateSelectedWork();
        }

        private void UpdateControls()
        {
            var work = GetCurrentWork();

            labStatus.Visible = _group.Status != WidSubmGroupStatus.Closed && work != null;
            labStatus.ForeColor = ucWidSubmWorkCheckList.HasErrors() ? Color.DarkRed : Color.DarkGreen;
            labStatus.Text = ucWidSubmWorkCheckList.HasErrors() ? "Публікація в WID неможлива" : "Готовий до публікації в WID";

            mnuActions.Visible = _group.Status != WidSubmGroupStatus.Closed;

            mnuUpdateFromMs.Enabled = work != null &&
                (
                    work.Status == (int)WidSubmGroupWorkStatusEnum.AlreadyInWid ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Postponed ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Accepted ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Rejected
                );

            mnuSubmit.Enabled = work != null &&
                !ucWidSubmWorkCheckList.HasErrors() &&
                work.ShouldSubmit != true &&
                (
                    work.Status == (int)WidSubmGroupWorkStatusEnum.AlreadyInWid ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Postponed ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Accepted ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Rejected
                );

            mnuDoNotSubmit.Enabled = work != null && 
                work.ShouldSubmit != false &&
                (
                    work.Status == (int)WidSubmGroupWorkStatusEnum.AlreadyInWid ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Postponed ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Accepted ||
                    work.Status == (int)WidSubmGroupWorkStatusEnum.Rejected
                );

            SetWorkDetailsVisble(work != null);

            tabMwInfo.TabPages[0].ImageIndex = ucWidSubmWorkCheckList.HasShareErrors() ? 3 : 2;
            tabMwInfo.TabPages[1].ImageIndex = ucWidSubmWorkCheckList.HasNameErrors() ? 3 : 2;
            tabMwInfo.TabPages[2].ImageIndex = ucWidSubmWorkCheckList.HasPerformerErrors() ? 3 : 2;
            tabMwInfo.TabPages[3].ImageIndex = ucWidSubmWorkCheckList.HasErrors() ? 3 : 2;
            tabMwInfo.TabPages[4].ImageIndex = work != null && 
                IsWorkResponded(work) ? 0 : -1;

            ucWidSubmWorkResp.Visible = work != null && 
                IsWorkResponded(work);

        }

        private bool IsWorkResponded(Work work)
        {
            return 
                work.Status == (int)WidSubmGroupWorkStatusEnum.Approved ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.Rejected ||
                work.Status == (int)WidSubmGroupWorkStatusEnum.PartApproved;
        }

        private Work GetCurrentWork()
        {
            if(lvWorks.SelectedItems.Count == 0)
            {
                return null;
            }
            else
            {
                return (Work)lvWorks.SelectedItems[0].Tag;
            }
        }

        private void SetWorkDetailsVisble(bool setVisible)
        {
            labStatus.Visible = setVisible;
            mnuActions.Visible = setVisible;
            tabMwInfo.Visible = setVisible;
        }

        private void ResetFilter()
        {
            cbFilterStatus.SelectedIndex = 0;
            cbFilterSubmit.SelectedIndex = 0;
            cbFilterSubmType.SelectedIndex = 0;
            tbFilterName.Text = "";
            tbFilterPerformer.Text = "";
            tbFilterObjId.Text = "";

        }

        private void mnuProcess_Click(object sender, EventArgs e)
        {
            SetStatus(WidSubmGroupWorkStatusEnum.InWork);
        }

        private void mnuPostpone_Click(object sender, EventArgs e)
        {
            SetStatus(WidSubmGroupWorkStatusEnum.Postponed);
        }

        private void mnuSubmit_Click(object sender, EventArgs e)
        {
            SetStatus(WidSubmGroupWorkStatusEnum.Accepted);
        }

        private void SetStatus(WidSubmGroupWorkStatusEnum status)
        {
            if(lvWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var item = lvWorks.SelectedItems[0];
            var work = (Work)item.Tag;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "update WidSubmGroupWork set Status = @status where ObjId = @objId";
                cmd.Parameters.AddWithValue("@objId", work.ObjId);
                cmd.Parameters.AddWithValue("@status", (int)status);
                cmd.ExecuteNonQuery();
            });
            work.Status = (int)status;
            item.SubItems[4].Text = WidSubmGroupWorkStatusDescription[work.Status];
            UpdateControls();
        }

        private void OnFilterChanged()
        {
            btnApplyFilter.Enabled = true;
            btnResetFilter.Enabled = true;
            lvWorks.Items.Clear();
            SetWorkDetailsVisble(false);
        }

        private void cbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        private void cbResubmit_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        private void cbFilterSubmType_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        private void tbFilterName_TextChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        private void tbFilterPerformer_TextChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        private void tbFilterObjId_TextChanged(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

       private void ReSubmit_Click(object sender, EventArgs e)
        {
            if (lvWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var item = lvWorks.SelectedItems[0];
            ReSubmitWork(item, true);
        }

        private void DoNotPublish_Click(object sender, EventArgs e)
        {
            if (lvWorks.SelectedItems.Count == 0)
            {
                return;
            }
            var item = lvWorks.SelectedItems[0];
            ReSubmitWork(item, false);
        }

        private void ReSubmitWork(ListViewItem item, bool reSubmit)
        {
            var work = (Work)item.Tag;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                var reSubmitStr = reSubmit ? "1" : "0";
                cmd.CommandText = $"update WidSubmGroupWork set ShouldReSubmit = {reSubmitStr} where WidSubmGroupId = @groupId and ObjId = @objId";
                cmd.Parameters.AddWithValue("@groupId", _group.Id);
                cmd.Parameters.AddWithValue("@objId", work.ObjId);
                cmd.ExecuteNonQuery();
            });
            work.ShouldSubmit = reSubmit;
            item.SubItems[7].Text = reSubmit ? "так" : "ні";
            UpdateControls();
        }

        private void UpdateFromMs(Work work)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Helpers.RunSqlSocWidSubmitT(cmd =>
                {
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateObjIdToWicFromMs";
                    cmd.Parameters.Clear();
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupWorkUpdateFromMs";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", _group.Id);
                    cmd.Parameters.AddWithValue("@objId", work.ObjId);
                    cmd.ExecuteNonQuery();

                    var service = new WidSubmGroupPreProcService();
                    service.ProcessWorkNames(cmd, work.ObjId, false);
                    service.ProcessWorkNames(cmd, work.ObjId, true);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupWorkUpdateChecklist";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", _group.Id);
                    cmd.Parameters.AddWithValue("@objId", work.ObjId);
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupWorkPreProc";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", _group.Id);
                    cmd.Parameters.AddWithValue("@objId", work.ObjId);

                    using (var r = cmd.ExecuteReader())
                    {
                        r.Read();
                        work.Id = r.GetInt32(0);
                        work.ObjId = r.GetInt32(1);
                        work.Name = r.IsDBNull(2) ? "" : r.GetString(2);
                        work.Performer = r.IsDBNull(3) ? "" : r.GetString(3);
                        work.Status = r.GetInt32(4);
                        work.Wic = r.IsDBNull(5) ? (int?)null : r.GetInt32(5);
                        work.Iswc = r.IsDBNull(6) ? null : r.GetString(6);
                        work.ShouldSubmit = r.IsDBNull(7) ? (bool?)null : r.GetBoolean(7);
                        work.ReSubmitIswc = r.GetString(8);
                        work.TransType = r.GetString(9);
                    }
                });

                UpdateSelectedWork();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UpdateAllFromMs()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Helpers.RunSqlSocWidSubmitT(cmd =>
                {
                    cmd.CommandTimeout = 0;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spUpdateObjIdToWicFromMs";
                    cmd.Parameters.Clear();
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupUpdateFromMs";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", _group.Id);
                    cmd.ExecuteNonQuery();

                    var service = new WidSubmGroupPreProcService();
                    service.ProcessNames(cmd, _group.Id, false);
                    service.ProcessNames(cmd, _group.Id, true);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupUpdateChecklist";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", _group.Id);
                    cmd.ExecuteNonQuery();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spWidSubmGroupPreProc";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@groupId", _group.Id);
                    cmd.ExecuteNonQuery();
                });

                FillWorks();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void mnuUpdateFromMs_Click(object sender, EventArgs e)
        {
            var work = GetCurrentWork();
            if (work == null)
            {
                return;
            }
            UpdateFromMs(work);
        }


        private void SearchWid_Click(object sender, EventArgs e)
        {
            var work = GetCurrentWork();
            if(work == null)
            {
                MessageBox.Show("Не вибраний твір", "Підготовка творів для передачі", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(work.Status != (int)WidSubmGroupWorkStatusEnum.Rejected)
            {
                MessageBox.Show("Дія можлива лише для відхилених творів", "Підготовка творів для передачі", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var form = new FormWidWorkSearch();
            form.ShowDialog();

            if(form.Wic == 0 && string.IsNullOrEmpty(form.Iswc))
            {
                return;
            }

            var objExists = false;
            Helpers.RunSqlSocWidSubmit(cmd =>
            {
                cmd.CommandText = "select ObjId from ObjIdToWic where ObjId = @ObjId";
                cmd.Parameters.AddWithValue("@ObjId", work.ObjId);
                using(var r = cmd.ExecuteReader())
                {
                    if(r.HasRows)
                    {
                        objExists = true;
                    }
                }
            });
            if(objExists)
            {
                MessageBox.Show("Даний твір вже повязаний з твром в WID", "Підготовка творів для передачі", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (form.Wic != 0)
            {
                try
                {
                    Helpers.RunSqlSocWidSubmitT(cmd =>
                    {
                        cmd.CommandText = @"
                            insert ObjIdToWic(ObjId, Wic, Iswc, Source) 
                            values (@ObjId, @Wic, @Iswc, 3)
                            update WidSubmGroupWork 
                            set ShouldReSubmit = 0 
                            where WidSubmGroupId = @GroupId and ObjId = @ObjId
                        ";
                        cmd.Parameters.AddWithValue("@GroupId", _group.Id);
                        cmd.Parameters.AddWithValue("@ObjId", work.ObjId);
                        cmd.Parameters.AddWithValue("@Wic", form.Wic);
                        cmd.Parameters.AddWithValue("@Iswc", form.Iswc);
                        cmd.ExecuteNonQuery();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Підготовка творів для передачі", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                work.Wic = form.Wic;
                work.Iswc = form.Iswc;
                work.ShouldSubmit = false;

                var item = lvWorks.SelectedItems[0];
                item.SubItems[5].Text = work.Wic.ToString();
                item.SubItems[6].Text = work.Iswc.ToString();
                item.SubItems[7].Text = (bool)work.ShouldSubmit ? "так" : "ні";
            }
            else
            {
                try
                {
                    Helpers.RunSqlSocWidSubmit(cmd =>
                    {
                        cmd.CommandText = @"
                            update WidSubmGroupWork 
                            set ShouldReSubmit = 1, ReSubmitIswc = @Iswc
                            where WidSubmGroupId = @GroupId and ObjId = @ObjId
                        ";
                        cmd.Parameters.AddWithValue("@GroupId", _group.Id);
                        cmd.Parameters.AddWithValue("@ObjId", work.ObjId);
                        cmd.Parameters.AddWithValue("@Iswc", form.Iswc);
                        cmd.ExecuteNonQuery();
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Підготовка творів для передачі", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                work.Wic = null;
                work.Iswc = null;
                work.ShouldSubmit = true;
                work.ReSubmitIswc = form.Iswc;

                var item = lvWorks.SelectedItems[0];
                item.SubItems[5].Text = "";
                item.SubItems[6].Text = "";
                item.SubItems[7].Text = (bool)work.ShouldSubmit ? "так" : "ні";
                item.SubItems[8].Text = work.ReSubmitIswc;
            }
        }

        private void mnuMultiUpdate_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvWorks.Items)
            {
                var work = (Work)item.Tag;
                UpdateFromMs(work);
            }
        }

        private void mnuRepublish_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvWorks.Items)
            {
                var work = (Work)item.Tag;
                if(work.Status == (int)WidSubmGroupWorkStatusEnum.Rejected && work.ShouldSubmit == null)
                {
                    var reSend = string.IsNullOrEmpty(work.Iswc) ? true : false;
                    ReSubmitWork(item, reSend);
                }
            }
        }

        private void tabMwInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lvWorks.SelectedItems.Count == 0)
            {
                SetObjId(null);
                return;
            }
            var item = lvWorks.SelectedItems[0];
            var work = (Work)item.Tag;
            SetObjId(work.ObjId);
        }

        private void mnuUpdateAllFromMs_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes != MessageBox.Show(
                    "Будуть оновлені не передані твори (твори у статусі ІСНУВАЛО В ВІД, ВІДКЛАДЕНО, ЗАТВЕРДЖЕНО).\r\n"
                  + "Оновлення може відбуватись тривалий час.\r\n"
                  + "Виконати оновлення?"
                , "Оновлення групи творів"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question))
            {
                return;
            }

            UpdateAllFromMs();
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            btnApplyFilter.Enabled = false;
            btnResetFilter.Enabled = true;
            FillWorksView();
            SetWorkDetailsVisble(false);
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {

            ResetFilter();
            FillWorksView();
            SetWorkDetailsVisble(false);
            btnApplyFilter.Enabled = false;
            btnResetFilter.Enabled = false;       
        }

    }
}
