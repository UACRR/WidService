using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WidSubmit.UcSubmRightHolders;

namespace WidSubmit
{
    public partial class UcSubmWorks : UserControl
    {
        public class SubmWork
        {
	        public int      Id               { get; set; }
	        public int      SubmissionId     { get; set; }
	        public int      ObjId            { get; set; }
	        public int?     Wic              { get; set; }
            public string   Iswc             { get; set; }
	        public string   Name             { get; set; }
	        public string   NameForWid	     { get; set; }
	        public bool     IsChanged	     { get; set; }
            public int      Status	         { get; set; }
        }

        private static readonly string[] _submWorkStatusText = new string[]
        {
	          "Проблемний"          //NOT_READY
	        , "До передачі"         //READY
	        , "Переданий"           //SUBMITTED
	        , "Прийнятий"           //ACCEPTED
	        , "Прийнятий умовно"    //ACCEPTED_WARNINGS
            , "Відхилений"          //REJECTED
	        , "Застосований"        //APPLIED
	        , "Завершений"          //COMPLETED
        };

        private int _submissionId;

        private List<SubmWork>      _submWorks;

        private RightHolder _selectedRightHolder;

        private bool _isHistoryMode;
        private bool _isSuscribedToEvents;

        private bool _isDirty;

        public UcSubmWorks()
        {
            InitializeComponent();

            _isHistoryMode = false;
            _isDirty = true;
        }

        private void UcSubmWorks_Load(object sender, EventArgs e)
        {
            Configure();
        }

        private void Configure()
        {
            ucSubmRightHolders.Init(_isHistoryMode ? PresentationMode.PREV_SUBM : PresentationMode.CUR_SUBM);

            lvSubmWorks.FullRowSelect = true;
            lvSubmWorks.GridLines = true;
            lvSubmWorks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvSubmWorks.MultiSelect = false;
            lvSubmWorks.View = View.Details;

            lvSubmWorks.Columns.Clear();
            lvSubmWorks.Columns.Add("№", 40);
            lvSubmWorks.Columns.Add("Статус в сеансі", 100);
            lvSubmWorks.Columns.Add("Попередня передача", 100);
            lvSubmWorks.Columns.Add("Код СМАРТ", 80);
            lvSubmWorks.Columns.Add("Код WID", 80);
            lvSubmWorks.Columns.Add("ISWC", 80);
            lvSubmWorks.Columns.Add("Назва СМАРТ", 100);
            lvSubmWorks.Columns.Add("Назва WID", 100);
            lvSubmWorks.Columns.Add("Як публікувати", 100);

            cbFilterByStatus.Items.Clear();
            cbFilterByStatus.Items.Add("<Всі>");
            var idx = 0;
            _submWorkStatusText.ToList().ForEach(x => { 
                cbFilterByStatus.Items.Add($"{idx} - {x}");
                idx++;
            });
            cbFilterByStatus.SelectedIndex = 0;

            ResetTabImages();
        }
        
        public void SetHistoryMode() => _isHistoryMode = true;
        public void SetDirty() => _isDirty = true;

        private void SuscribeToEvents()
        {
            if(_isSuscribedToEvents) { return; }
            ucSubmRightHolders.RightHolderSelected += OnRightHolderSelected;
            ucSubmRightHolders.RightHolderUnselected += OnRightHolderUnselected;
            ucSubmRightHolders.EditRightHoldersClicked += OnEditRightHoldersClicked;

            _isSuscribedToEvents = true;
        }

        public void UpdateContent(int submissionId = 0)
        {
            if(!_isDirty) return;

            _submissionId = submissionId;
            panelMain.Visible = false;

            timerUpdateContent.Enabled = true;
            //if(!_isHistoryMode)
            //{
            //    Helpers.RunSqlSocWidSubmitEx(cmd =>
            //    {
            //        cmd.CommandText = "select dbo.fnCurSubmId()";
            //        _submissionId = (int)cmd.ExecuteScalar();
            //    });
            //}
            //
            //LoadRightHolders();
            //FillLvRightHolders();
            //
            //LoadSubmWorks();
            //FillLvSubmWorks();
            //
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select count(*) from SubmWork where SubmissionId = @submissionId";
                cmd.Parameters.AddWithValue("@submissionId", _submissionId);
                tbSubmWorkCntTotal.Text =  ((int)cmd.ExecuteScalar()).ToString();
            });
         }
        
        private void LoadSubmWorks()
        {
            var custId = _selectedRightHolder == null ? 0 : _selectedRightHolder.CustId;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spSelectRightHolderSubmWorks";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@submissionId", _submissionId);
                cmd.Parameters.AddWithValue("@custId", custId);
                
                using (var r = cmd.ExecuteReader())
                {
                    _submWorks = new List<SubmWork>();
                    while (r.Read())
                    {
                        var idx = 0;
                        var work = new SubmWork();
	                    work.Id                 = r.GetInt32(idx);                                idx++;
	                    work.SubmissionId       = r.GetInt32(idx);                                idx++;
	                    work.ObjId              = r.GetInt32(idx);                                idx++;
	                    work.Wic                = r.IsDBNull(idx) ? null : (int?)r.GetInt32(idx); idx++;
                        work.Iswc               = r.GetString(idx);                               idx++;
	                    work.Name               = r.GetString(idx);                               idx++;
	                    work.NameForWid         = r.GetString(idx);                               idx++;
                        work.IsChanged          = r.GetBoolean(idx);                              idx++;
                        work.Status             = r.GetInt32(idx);                                idx++;
                        
                        _submWorks.Add(work);
                    }
                }

                _submWorks.OrderBy(x => x.Name);
            });

       }
    
        private bool ShowSubmWork(SubmWork work)
        {
            if (rbFilterSubmittedYes.Checked && !work.IsChanged) return false;
            if (rbFilterSubmittedNo.Checked && work.IsChanged) return false;

            var requiredStatus = cbFilterByStatus.SelectedIndex - 1;
            if (requiredStatus >= 0 && work.Status != requiredStatus) return false;

            var exFilterText = tbSubmWorkExFilter.Text.ToUpper();
            var meetsExFiler = work.ObjId.ToString() == exFilterText
                || work.Wic.ToString() == exFilterText
                || work.Iswc.ToUpper() == exFilterText
                || work.Name.Contains(exFilterText);
            if (!meetsExFiler) return false;

            return true;
        }

        private void FillLvSubmWorks()
        {
            lvSubmWorks.BeginUpdate();
            lvSubmWorks.Items.Clear();
            
            var seqNr = 1;
            _submWorks.ForEach(x =>
            {
                if (ShowSubmWork(x))
                {
                    var item = new ListViewItem(seqNr.ToString());
                    item.SubItems.Add(_submWorkStatusText[x.Status]);
                    item.SubItems.Add("Не передавався");
                    item.SubItems.Add(x.ObjId.ToString());
                    item.SubItems.Add(x.Wic == null ? "" : x.Wic.ToString());
                    item.SubItems.Add(x.Iswc);
                    item.SubItems.Add(x.Name);
                    item.SubItems.Add(x.NameForWid);
                    item.SubItems.Add(x.IsChanged ? "Змінений" : "Новий");
                    item.ImageIndex = x.Status;
                    item.StateImageIndex = x.IsChanged ? 1 : 0;
                    item.Tag = x;

                    lvSubmWorks.Items.Add(item);
                    seqNr++;
                }
            });
            lvSubmWorks.EndUpdate();

            tbSubmWorkCntSelected.Text = lvSubmWorks.Items.Count.ToString();
        }

        private void ResetTabImages()
        {
            panelWorkDetails.TabPages[0].ImageIndex = 4;
            panelWorkDetails.TabPages[1].ImageIndex = 4;
            panelWorkDetails.TabPages[2].ImageIndex = 4;
            panelWorkDetails.TabPages[3].ImageIndex = 4;
            panelWorkDetails.TabPages[4].ImageIndex = 4;
        }

        private void UpdateTabImages()
        {
            panelWorkDetails.TabPages[0].ImageIndex = ucSubmWorkCheckList.HasErrors() ? 3 : 2;
            panelWorkDetails.TabPages[1].ImageIndex = 2;
            panelWorkDetails.TabPages[2].ImageIndex = 2;
            panelWorkDetails.TabPages[3].ImageIndex = ucSubmWorkCheckList.HasErrors() ? 3 : 2;
            panelWorkDetails.TabPages[4].ImageIndex = 2;
        }

        private void ClearTabControls()
        {
            ucSubmWorkShares.ClearContent();
            ucSubmWorkAltNames.ClearContent();
            ucSubmWorkPerformers.ClearContent();
            ucSubmWorkCheckList.ClearContent();
            ucSubmWorkRespErr.ClearContent();
            ucSubmWorkSharesDiff.ClearContent();
        }

        private void UpdateTabControls()
        {
            if(lvSubmWorks.SelectedItems.Count == 0) return;

            var submWork = (SubmWork)lvSubmWorks.SelectedItems[0].Tag;
            switch(panelWorkDetails.SelectedIndex)
            {
                case 0: ucSubmWorkShares.UpdateContent(submWork.Id)    ; break;
                case 1: ucSubmWorkAltNames.UpdateContent(submWork.Id)  ; break;
                case 2: ucSubmWorkPerformers.UpdateContent(submWork.Id); break;
                case 3: ucSubmWorkCheckList.UpdateContent(submWork.Id) ; break;
                case 4: ucSubmWorkRespErr.UpdateContent(submWork.Id)   ; break;
                case 5: ucSubmWorkSharesDiff.UpdateContent(submWork.Id); break;
            }
        }
 

        private void rbFilterSubmittedNo_CheckedChanged(object sender, EventArgs e)
        {
            ClearTabControls();
            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });
        }

        private void rbFilterSubmittedYes_CheckedChanged(object sender, EventArgs e)
        {
            ClearTabControls();
            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });
        }

        private void rbFilterSubmittedAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearTabControls();
            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });
        }

        private void lvSubmWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTabControls();
            if (lvSubmWorks.SelectedItems.Count == 0)
            {
                ResetTabImages();
            }
            else
            {
                UpdateTabControls();
                UpdateTabImages();
            }
        }

        private void lvSubmWorks_MouseDown(object sender, MouseEventArgs e)
        {
            Helpers.CopyCellValue(e, lvSubmWorks);
        }

        private void cbFilterByStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterByStatus.SelectedIndex == -1 || _submWorks == null) return;

            ClearTabControls();
            Helpers.RunProtected(() =>
            {
                FillLvSubmWorks();
            });

        }

        private void tbSubmWorkExFilter_TextChanged(object sender, EventArgs e)
        {
            btnSubmWorkApplyExFilter.Enabled = true;
        }

        private void btnSubmWorkApplyExFilter_Click(object sender, EventArgs e)
        {
            btnSubmWorkApplyExFilter.Enabled = false;
            ClearTabControls();
            FillLvSubmWorks();
        }

        private void timerUpdateContent_Tick(object sender, EventArgs e)
        {
            timerUpdateContent.Enabled = false;
            
            Helpers.SetWaitCursor();
            
            if(!_isHistoryMode)
            {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = "select dbo.fnCurSubmId()";
                    _submissionId = (int)cmd.ExecuteScalar();
                });
            }

            SuscribeToEvents();
            ucSubmRightHolders.UpdateContent(_submissionId);

            LoadSubmWorks();
            FillLvSubmWorks();

            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select count(*) from SubmWork where SubmissionId = @submissionId";
                cmd.Parameters.AddWithValue("@submissionId", _submissionId);
                tbSubmWorkCntTotal.Text =  ((int)cmd.ExecuteScalar()).ToString();
            });
            panelMain.Visible = true;

            Helpers.UnsetWaitCursor();
            _isDirty = false;
        }

        private void btnChangeRightHolders_Click(object sender, EventArgs e)
        {
            var form = new FormSubmissionRightHolders();
            form.ShowDialog();
            //LoadRightHolders();
            //FillLvRightHolders();
        }

        public void OnRightHolderSelected(object sender, RightHolderSelectedEventArgs e)
        {
            _selectedRightHolder = e.RightHolder;
           Helpers.RunProtected(() =>
            {
                ClearTabControls();
                LoadSubmWorks();
                FillLvSubmWorks();
            });
        }

        public void OnRightHolderUnselected(object sender, EventArgs e)
        {
            lvSubmWorks.Items.Clear();
            ClearTabControls();
            ResetTabImages();
        }

        public void OnEditRightHoldersClicked(object sender, EventArgs e)
        {
            var submStatus = 0;
            Helpers.RunSqlSocWidSubmitEx(cmd =>
            {
                cmd.CommandText = "select SubmissionStatusId from Submission where Id = @submissionId";
                cmd.Parameters.AddWithValue("@submissionId", _submissionId);
                submStatus = (int)cmd.ExecuteScalar();
            });

            if(submStatus >= (int)SubmStatusEnum.SUBM_FILE_UPLOADED)
            {
                MessageBox.Show("Файл переданий, зміни правовласників сеансу не можливі.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var form = new FormSubmissionRightHolders();
            var res = form.ShowDialog();
            if(res == DialogResult.Cancel) return;

            Helpers.RunProtected(() =>
            {
                Helpers.RunSqlSocWidSubmitExT(cmd =>
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spSubmWorksUpdate";
                    cmd.ExecuteNonQuery();
                });
            });

            _isDirty = true;
            UpdateContent();
        }

        private void panelWorkDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTabControls();
        }
    }
}
