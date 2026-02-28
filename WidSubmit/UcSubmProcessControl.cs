using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static WidSubmit.UcSubmProcessControl;
using Button = System.Windows.Forms.Button;

namespace WidSubmit
{
    public partial class UcSubmProcessControl : UserControl
    {
        public enum StepStatusEnum
        {
              COMPLETED
            , CURRENT
            , PENDING
        }

        public enum StepStatusImageIndexEnum
        {
              COMPLETED = 2
            , CURRENT = 1
            , PENDING = 4
        }

        public enum SubmStatusEnum
        {
              INITIAL
            , SUBM_FILE_CREATED
            , SUBM_FILE_UPLOADED
            , RESP_FILE_DOWNLOADED
            , RESP_WRONG_SUBM_FILE
            , RESP_FILE_PROCESSED
            , ISWC_CODES_PASSED_TO_MS
            , CLOSED
            , COMPLETED

        }

        public enum SubmStepEnum
        {
              INITIAL
            , SUBM_FILE
            , FINALIZE
        }

        public class SubmStatus
        {
            public SubmStatusEnum Id { get; set; }
            public List<Button> EnabledButtons { get; set; }
        }

        public class SubmStep
        {
            public SubmStepEnum Id { get; set; }
            public StepStatusEnum Status { get; set; }
            public Label StatusImageLabel{ get; set; }
            public Label CaptionLabel{ get; set; }
            public Label StatusLabel{ get; set; }
            public List<Button> ActionButtons{ get; set; }
            public List<SubmStatusEnum> SubmStatuses{ get; set; }
        }

        public class Submission
        {
            public int Id                    { get; set; }
	        public DateTime StartedAt        { get; set; }
	        public DateTime EndedAt          { get; set; }
	        public string SubmFileName       { get; set; }
	        public string RespFileName       { get; set; }
            public string ErrorFileName      { get; set; }
	        public int SubmissionStatusId    { get; set; }
	        public DateTime CreatedAt        { get; set; }
	        public DateTime? UpdatedAt       { get; set; }
        }

        private List<SubmStatus> _submStatuses;
        private List<SubmStep> _submSteps;
        private Submission _submission;

        private bool _isExpanded;
        public UcSubmProcessControl()
        {
            InitializeComponent();
        }

        private void UcSubmProcessControl_Load(object sender, EventArgs e)
        {
            //if (!DesignMode)
            //{
            //    SetExpanded(true);
            //    Configure();
            //    LoadSubmission();
            //    UpdateControls();
            //}
        }

        public void UpdateContent()
        {
            SetExpanded(true);
            Configure();
            LoadSubmission();
            UpdateControls();
        }

        private void Configure()
        {
            _submStatuses = new List<SubmStatus>
            {
                new SubmStatus { 
                    Id = SubmStatusEnum.INITIAL, 
                    EnabledButtons = new List<Button> {
                        btnUpdateFromMs,
                        btnCreateSubmFile,
                        btnSendSubmFile, 
                    }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.SUBM_FILE_CREATED, 
                    EnabledButtons = new List<Button> {
                        btnUpdateFromMs,
                        btnCreateSubmFile,
                        btnShowSubmFile, 
                        btnSendSubmFile, 
                     }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.SUBM_FILE_UPLOADED, 
                    EnabledButtons = new List<Button> {
                        btnShowSubmFile,
                        btnReceiveRespFile,
                    }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.RESP_WRONG_SUBM_FILE, 
                    EnabledButtons = new List<Button> {
                        btnShowSubmFile,
                        btnShowErrorFile,
                        btnCancelSubm,
                    }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.RESP_FILE_DOWNLOADED, 
                    EnabledButtons = new List<Button> {
                        btnShowSubmFile,
                        btnShowRespFile,
                        btnApplyRespFile, 
                    }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.RESP_FILE_PROCESSED, 
                    EnabledButtons = new List<Button> {
                        btnShowSubmFile,
                        btnShowRespFile,
                        btnPassToMs
                    }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.ISWC_CODES_PASSED_TO_MS, 
                    EnabledButtons = new List<Button> {
                        btnShowSubmFile,
                        btnShowRespFile,
                        btnCloseSubm,
                    }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.CLOSED, 
                    EnabledButtons = new List<Button> {
                        btnShowSubmFile,
                        btnShowRespFile,
                    }
                },
                new SubmStatus { 
                    Id = SubmStatusEnum.COMPLETED, 
                    EnabledButtons = new List<Button> {
                        btnShowSubmFile,
                        btnShowRespFile,
                    }
                },
            };

            _submSteps = new List<SubmStep>
            {
                new SubmStep {
                    Id = SubmStepEnum.INITIAL,
                    Status = StepStatusEnum.PENDING,
                    StatusImageLabel = labStepStatus1,
                    CaptionLabel = labStepTitle1,
                    StatusLabel = labMsg1,
                    ActionButtons = new List<Button> { 
                        btnUpdateFromMs,
                        btnCreateSubmFile,
                        btnShowSubmFile, 
                        btnSendSubmFile, 
                    },
                    SubmStatuses = new List<SubmStatusEnum>
                    {
                          SubmStatusEnum.INITIAL
                        , SubmStatusEnum.SUBM_FILE_CREATED
                        , SubmStatusEnum.SUBM_FILE_UPLOADED
                    },
                },
                new SubmStep {
                    Id = SubmStepEnum.SUBM_FILE,
                    Status = StepStatusEnum.PENDING,
                    StatusImageLabel = labStepStatus2,
                    CaptionLabel = labStepTitle2,
                    StatusLabel = labMsg2,
                    ActionButtons = new List<Button> { 
                        btnReceiveRespFile,
                        btnShowRespFile,
                        btnShowErrorFile,
                        btnCancelSubm,
                        btnApplyRespFile,
                    },
                    SubmStatuses = new List<SubmStatusEnum>
                    {
                          SubmStatusEnum.RESP_WRONG_SUBM_FILE
                        , SubmStatusEnum.RESP_FILE_DOWNLOADED
                        , SubmStatusEnum.RESP_FILE_PROCESSED
                    },
                },
                new SubmStep {
                    Id = SubmStepEnum.FINALIZE,
                    Status = StepStatusEnum.PENDING,
                    StatusImageLabel = labStepStatus3,
                    CaptionLabel = labStepTitle3,
                    StatusLabel = labMsg3,
                    ActionButtons = new List<Button> { 
                        btnPassToMs, 
                        btnCloseSubm,  
                    },
                    SubmStatuses = new List<SubmStatusEnum>
                    {
                          SubmStatusEnum.ISWC_CODES_PASSED_TO_MS
                        , SubmStatusEnum.CLOSED
                    },
                },
            };

        }

        private void BtnUpdateFromMs_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SetStepStatus()
        {
            var submStatusId = _submission.SubmissionStatusId;
            _submSteps.ForEach(step =>
            {
                var minSubmStatus = step.SubmStatuses.Min(x => x);
                var maxSubmStatus = step.SubmStatuses.Max(x => x);
                step.Status = submStatusId >= (int)minSubmStatus && submStatusId <= (int)maxSubmStatus ? StepStatusEnum.CURRENT :
                    submStatusId > (int)maxSubmStatus ? StepStatusEnum.COMPLETED :
                    StepStatusEnum.PENDING;
            });
        }

        private void SetStepStatusText()
        {
            var submStatusId = _submission.SubmissionStatusId;
            _submSteps.ForEach(step =>
            {
                var minSubmStatus = step.SubmStatuses.Min(x => x);
                var maxSubmStatus = step.SubmStatuses.Max(x => x);
                step.StatusLabel.Text = (int)maxSubmStatus < submStatusId ? GetStatusText((int)maxSubmStatus) :
                    (int)minSubmStatus > submStatusId ? "Не розпочато" :
                    GetStatusText(submStatusId);
            });
        }

        private void GetStepImageIndex(SubmStep step)
        {
            step.StatusImageLabel.ImageIndex = 
                step.Status == StepStatusEnum.COMPLETED ? (int)StepStatusImageIndexEnum.COMPLETED :
                step.Status == StepStatusEnum.CURRENT ? (int)StepStatusImageIndexEnum.CURRENT :
                (int)StepStatusImageIndexEnum.PENDING;
        }

        private string GetStatusText(int submStatusId)
        {
            switch(submStatusId)
            {
                case (int)SubmStatusEnum.INITIAL                    :
                    return "Обробка творів";
                case (int)SubmStatusEnum.SUBM_FILE_CREATED          :
                    return $"Створено/оновлено файл публікації {_submission.SubmFileName}";
                case (int)SubmStatusEnum.SUBM_FILE_UPLOADED         :
                    return $"Файл публікації {_submission.SubmFileName} викладено на ФТП";
                case (int)SubmStatusEnum.RESP_FILE_DOWNLOADED       :
                    return $"Файл відповіді {_submission.RespFileName} отриманий";
                case (int)SubmStatusEnum.RESP_WRONG_SUBM_FILE       :
                    return $"Файл публікації відхилений, помилоки в {_submission.ErrorFileName}";
                case (int)SubmStatusEnum.RESP_FILE_PROCESSED    :
                    return $"Файл відповіді {_submission.RespFileName} оброблений";
                case (int)SubmStatusEnum.ISWC_CODES_PASSED_TO_MS    :
                    return "Коди ISWC нових творів передані в СМАРТ";
                case (int)SubmStatusEnum.CLOSED                     :
                    return "Публікація творів завершена, нова публікація започаткована";
                case (int)SubmStatusEnum.COMPLETED                     :
                    return "Публікація творів завершена, нова публікація започаткована";
                default: return "";
            }
        }

        private void UpdateControls()
        {
            SetStepStatus();

            var submStatusId = _submission.SubmissionStatusId;
            _submSteps.ForEach(step =>
            {
                GetStepImageIndex(step);
                step.ActionButtons.ForEach(button =>
                {
                    button.Enabled = false;
                });
            });
            _submStatuses.Single(x => (int)x.Id == submStatusId).EnabledButtons.ForEach(x => x.Enabled = true);

            if(submStatusId == (int)SubmStatusEnum.SUBM_FILE_CREATED)
            {
                btnCreateSubmFile.Text = "Оновити файл";
                btnSendSubmFile.Text = "Оновити і викласти файл";
            }
            else
            {
                btnCreateSubmFile.Text = "Створити файл";
                btnSendSubmFile.Text = "Створити і викласти файл";
            }

            SetStepStatusText();
        }

        #region Submission
        private void LoadSubmission()
        {
            Helpers.RunProtected ( () =>
            {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = $@"
                         select
	                          Id
	                        , StartedAt
	                        , EndedAt
	                        , SubmFileName
	                        , RespFileName
                            , ErrorFileName
	                        , SubmissionStatusId
	                        , CreatedAt
	                        , UpdatedAt
                        from Submission
                        where Id = dbo.fnCurSubmId()
                    ";
                    using (var r = cmd.ExecuteReader())
                    {
                        r.Read();
                        _submission = new Submission();
                        var idx = 0;
                        _submission.Id = r.GetInt32(idx); idx++;
                        _submission.StartedAt = r.GetDateTime(idx); idx++;
                        _submission.EndedAt = r.GetDateTime(idx); idx++;
                        _submission.SubmFileName = r.GetString(idx); idx++;
                        _submission.RespFileName = r.GetString(idx); idx++;
                        _submission.ErrorFileName = r.GetString(idx); idx++;
                        _submission.SubmissionStatusId = r.GetInt32(idx); idx++;
                        _submission.CreatedAt = r.GetDateTime(idx); idx++;
                        _submission.UpdatedAt = r.IsDBNull(idx) ? (DateTime?)null : r.GetDateTime(idx); idx++;
                    }
                });
            });
        }
        
        private void SetSubmStatus(SubmStatusEnum status)
        {
            Helpers.RunProtected ( () =>
            {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = "update Submission set SubmissionStatusId = @status where Id = dbo.fnCurSubmId()";
                    cmd.Parameters.AddWithValue("@status", (int)status);
                    cmd.ExecuteNonQuery();
                });

                _submission.SubmissionStatusId = (int)status;
                UpdateControls();
            });
        }

        private void SetSubmFile(string submFileName)
        {
            Helpers.RunProtected ( () =>
            {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = "update Submission set SubmFileName = @submFileName where Id = dbo.fnCurSubmId()";
                    cmd.Parameters.AddWithValue("@submFileName", submFileName);
                    cmd.ExecuteNonQuery();
                });

                _submission.SubmFileName = submFileName;
                UpdateControls();
            });
        }

        private void SetRespFile(string respFileName)
        {
            Helpers.RunProtected ( () =>
            {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = "update Submission set RespFileName = @respFileName where Id = dbo.fnCurSubmId()";
                    cmd.Parameters.AddWithValue("@respFileName", respFileName);
                    cmd.ExecuteNonQuery();
                });

                _submission.RespFileName = respFileName;
                UpdateControls();
            });
        }

        private void SetErrorFile(string errorFileName)
        {
            Helpers.RunProtected ( () =>
            {
                Helpers.RunSqlSocWidSubmitEx(cmd =>
                {
                    cmd.CommandText = "update Submission set ErrorFileName = @errorFileName where Id = dbo.fnCurSubmId()";
                    cmd.Parameters.AddWithValue("@ErrorFileName", errorFileName);
                    cmd.ExecuteNonQuery();
                });

                _submission.ErrorFileName = errorFileName;
                UpdateControls();
            });
        }
        #endregion

        #region ExpandCollapse
        private void SetExpanded(bool isExpanded)
        {
            _isExpanded = isExpanded;
            btnExpandCollapse.Text = isExpanded ? "<" : ">";
            panelMain.ColumnStyles[1].SizeType = SizeType.Absolute;
            panelMain.ColumnStyles[1].Width = isExpanded ? 490 : 0;
            Width = isExpanded ? 522 : 40;
        }

        private void btnExpandCollapse_Click(object sender, EventArgs e)
        {
            _isExpanded = !_isExpanded;
            SetExpanded(_isExpanded);
        }
        #endregion // ExpandCollapse

        #region Actions

        private void UpdateFromMs()
        {

        }

        private void CreateSubmFile()
        {
            SetSubmFile("WID2023030609244604300140.021");
            SetSubmStatus(SubmStatusEnum.SUBM_FILE_CREATED);
        }

        private void ShowSubmFile()
        {
            MessageBox.Show(_submission.SubmFileName);
        }

        private void SendSubmFile()
        {
            SetSubmStatus(SubmStatusEnum.SUBM_FILE_UPLOADED);
        }

        int ReceiveRespFileRunIdx = 1;
        private void ReceiveRespFile()
        {
            if(ReceiveRespFileRunIdx == 1)
            {
                SetErrorFile("WID2023040708242611300140.021.gz");
                SetSubmStatus(SubmStatusEnum.RESP_WRONG_SUBM_FILE);
            }
            else
            {
                SetRespFile("WID20260116125101140300.021");
                SetSubmStatus(SubmStatusEnum.RESP_FILE_DOWNLOADED);

            }
            ReceiveRespFileRunIdx++;
        }

        private void ShowRespFile()
        {
            MessageBox.Show(_submission.RespFileName);
        }

        private void ApplyRespFile()
        {
            SetSubmStatus(SubmStatusEnum.RESP_FILE_PROCESSED);
        }

        private void CancelSubm()
        {
            SetSubmStatus(SubmStatusEnum.SUBM_FILE_CREATED);
        }

        private void ShowErrorFile()
        {
            MessageBox.Show(_submission.ErrorFileName);
        }

        private void PassToMs()
        {
            SetSubmStatus(SubmStatusEnum.ISWC_CODES_PASSED_TO_MS);
        }

        private void CloseSubm()
        {
            SetSubmStatus(SubmStatusEnum.COMPLETED);
        }
        #endregion // Actions

        #region ActionButtonHandlers
        private void btnUpdateFromMs_Click(object sender, EventArgs e)
        {
            UpdateFromMs();
        }


        private void btnCreateSubmFile_Click(object sender, EventArgs e)
        {
            CreateSubmFile();
        }

        private void btnShowSubmFile_Click(object sender, EventArgs e)
        {
            ShowSubmFile();
        }

        private void btnSendSubmFile_Click(object sender, EventArgs e)
        {
            SendSubmFile();
        }

        private void btnReceiveRespFile_Click(object sender, EventArgs e)
        {
            ReceiveRespFile();
        }

        private void btnShowRespFile_Click(object sender, EventArgs e)
        {
            ShowRespFile();
        }


        private void btnApplyRespFile_Click(object sender, EventArgs e)
        {
            ApplyRespFile();
        }

        private void btnShowErrorFile_Click(object sender, EventArgs e)
        {
            ShowErrorFile();
        }

        private void btnCancelSubm_Click(object sender, EventArgs e)
        {
            CancelSubm();
        }

        private void btnPassToMs_Click(object sender, EventArgs e)
        {
            PassToMs();
        }

        private void btnCloseSubm_Click(object sender, EventArgs e)
        {
            CloseSubm();
        }
        #endregion // ActionButtonHandlers
    }
}
