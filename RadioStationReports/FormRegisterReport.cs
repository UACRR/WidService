using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RadioStationReports.UcMainIntegrated;

namespace RadioStationReports
{
    public partial class FormRegisterReport : Form
    {
        private enum ActionType
        {
            RegisterReportFromMs,
            CreateWorksForRegisteredReport,
            AutoSearchInMs,
            AutoSearchInWid,
            GetWicsToImport,
            ImportWorkFromWid,
            SyncObjIdWicIswc,
            UpdateWorksFromWid,
            CreateReportAuthors,
            SetReportRegistered,
       }

        private static Action[] ACTIONS =
        {
            new Action
            {
                Code = (int)ActionType.RegisterReportFromMs,
                Description = "Створення копії рядків звіту",
                Procedure = "spRegisterReportFromMs",
                UseRegId = false,
                UseReportId = false,
            },
            new Action
            {
                Code = (int)ActionType.CreateWorksForRegisteredReport,
                Description = "Створення інформації для пошуку творів в рядках",
                Procedure = "spCreateWorksForRegisteredReport",
                UseRegId = false,
                UseReportId = false,
            },
            new Action
            {
                Code = (int)ActionType.AutoSearchInMs,
                Description = "Пошук творів в БД СМАРТ",
                Procedure = "spAutoSearchInMs",
                UseRegId = false,
                UseReportId = false,
           },
            new Action
            {
                Code = (int)ActionType.AutoSearchInWid,
                Description = "Пошук творів в БД ВІД",
                Procedure = "spAutoSearchInWid",
                UseRegId = false,
                UseReportId = false,
            },
            new Action
            {
                Code = (int)ActionType.GetWicsToImport,
                Description = "Вибір знайдених в ВІД творів для імпорту в БД СМАРТ",
                Procedure = "spGetWicsToImport",
                UseRegId = false,
                UseReportId = false,
            },
            new Action
            {
                Code = (int)ActionType.ImportWorkFromWid,
                Description = "Імпорт знайдених в ВІД творів в БД СМАРТ",
                Procedure = "MediaService..spImportWorkFromWid",
                UseRegId = false,
                UseReportId = false,
            },
            new Action
            {
                Code = (int)ActionType.SyncObjIdWicIswc,
                Description = "Поєднання кодів знайдених творів",
                Procedure = "spSyncObjIdWicIswc",
                UseRegId = false,
                UseReportId = false,
            },
             new Action
            {
                Code = (int)ActionType.UpdateWorksFromWid,
                Description = "Оновлення інформації з WID",
                Procedure = "MediaService..spUpdateCustomerReportWorksFromWid",
                UseRegId = false,
                UseReportId = false,
            },
           new Action
            {
                Code = (int)ActionType.CreateReportAuthors,
                Description = "Розрахунок процентів для знайдених творів",
                Procedure = "spCreateReportAuthors",
                UseRegId = false,
                UseReportId = false,
            },
            new Action
            {
                Code = (int)ActionType.SetReportRegistered,
                Description = "Завершення завантаження",
                Procedure = "spSetReportRegistered",
                UseRegId = false,
                UseReportId = false,
           },
       };

        public class Action
        {
            public int Code { get; set; }
            public string Description { get; set; }
            public string Procedure { get; set; }
            public bool UseRegId { get; set; }
            public bool UseReportId { get; set; }
        }

        private CustomerItem _customer;
        private ReportItem _msReport;
        private int _reportId;

        private int _currentActionIdx;

        private List<int> _wicsToImport;
        private int _currentWicToImportIdx;

        public ReportItemStatus ReportItemStatus { get; set; }

        public FormRegisterReport(CustomerItem customer, ReportItem report)
        {
            InitializeComponent();
            _customer = customer;
            _msReport = report;
        }
        
        private void FormRegisterReport_Load(object sender, EventArgs e)
        {
            Configure();

            tbRegId.Text = _msReport.RegId.ToString();
            tbCustomerName.Text = _customer.ShortName;
            tbStartDate.Text = _msReport.StartDate.ToString("yyy-MM-dd");
            tbEndDate.Text = _msReport.EndDate.ToString("yyy-MM-dd");
            tbFileName.Text = _msReport.FileName;
        }

        private void Configure()
        {
            lvActions.FullRowSelect = true;
            lvActions.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvActions.MultiSelect = false;
            lvActions.View = View.Details;
            lvActions.SmallImageList = ilActions;
            lvActions.Columns.Add("Процес реєстрації звіту (кроки)", 340);
            lvActions.Columns.Add("Результат виконання", 300);

            ACTIONS.ToList().ForEach(x =>
            {
                var item = lvActions.Items.Add(x.Description);
                item.SubItems.Add("");
                item.Tag = x;
            });

            ReportItemStatus = ReportItemStatus.NotRegistered;
        }

        private void AddCurrentActionParams(SqlCommand cmd)
        {
            cmd.Parameters.Clear();
            switch ((ActionType)_currentActionIdx)
            {
                case ActionType.RegisterReportFromMs:
                    cmd.Parameters.AddWithValue("@regId", _msReport.RegId);
                    var paramReportId = new SqlParameter("@reportId", SqlDbType.Int)
                    { 
                        Direction = ParameterDirection.Output 
                    };
                    cmd.Parameters.Add(paramReportId);
                    break;
                case ActionType.CreateWorksForRegisteredReport:
                    cmd.Parameters.AddWithValue("@reportId", _reportId);
                    break;                
                case ActionType.AutoSearchInMs:
                    cmd.Parameters.AddWithValue("@reportId", _reportId);
                    break; 
                case ActionType.AutoSearchInWid:
                    cmd.Parameters.AddWithValue("@reportId", _reportId);
                    break; 
                case ActionType.GetWicsToImport:
                    cmd.Parameters.AddWithValue("@reportId", _reportId);
                    break; 
                case ActionType.ImportWorkFromWid:
                    cmd.Parameters.AddWithValue("@wic", _wicsToImport[_currentWicToImportIdx]);
                    cmd.Parameters.AddWithValue("@showTrace", 0);
                    cmd.Parameters.AddWithValue("@objId", 0);
                    break; 
                case ActionType.SyncObjIdWicIswc:
                    break; 
                case ActionType.UpdateWorksFromWid:
                    cmd.Parameters.AddWithValue("@reportId", _reportId);
                    break; 
                case ActionType.CreateReportAuthors:
                    cmd.Parameters.AddWithValue("@reportId", _reportId);
                    break; 
                case ActionType.SetReportRegistered:
                    cmd.Parameters.AddWithValue("@reportId", _reportId);
                    break;
                default:
                    break;
            }

        }

        private void RunAction()
        {
            try
            {
                if (_currentActionIdx == (int)ActionType.RegisterReportFromMs)
                {
                    Helpers.RunSqlT(cmd =>
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = ACTIONS[_currentActionIdx].Procedure;
                        cmd.Parameters.AddWithValue("@regId", _msReport.RegId);
                        var paramReportId = new SqlParameter("@reportId", SqlDbType.Int)
                        { 
                            Direction = ParameterDirection.Output 
                        };
                        cmd.Parameters.Add(paramReportId);
                        cmd.ExecuteNonQuery();
                        _reportId = (int)paramReportId.Value;
                    });
                }
                else if (_currentActionIdx == (int)ActionType.GetWicsToImport)
                {
                    _currentWicToImportIdx = 0;

                    Helpers.RunSql(cmd =>
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "spGetWicsToImport";
                        cmd.Parameters.AddWithValue("@reportId", _reportId);
                        using (var r = cmd.ExecuteReader())
                        {
                            _wicsToImport = new List<int>();
                            while (r.Read())
                            {
                                _wicsToImport.Add(r.GetInt32(0));
                            }
                        }
                    });
                }
                else
                {
                    Helpers.RunSqlT(cmd =>
                    {
                        cmd.CommandTimeout = 300;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = ACTIONS[_currentActionIdx].Procedure;
                        AddCurrentActionParams(cmd);
                        cmd.ExecuteNonQuery();
                    });
                }
            }
            catch (Exception ex)
            {
                ReportItemStatus = ReportItemStatus.RegistrationFailed;
                var item = lvActions.Items[_currentActionIdx];
                item.SubItems[1].Text = ex.Message;
                item.ImageIndex = 1;
            }

        }

        private void Register()
        {
            btnRegister.Enabled = false;
            btnClose.Enabled = false;
            ReportItemStatus = ReportItemStatus.NotRegistered;

            _currentActionIdx = 0;
            var item = lvActions.Items[_currentActionIdx];
            item.SubItems[1].Text = "Виконується ...";
            item.ImageIndex = 0;
            timerRunAction.Enabled = true;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timerRunAction_Tick(object sender, EventArgs e)
        {
            timerRunAction.Enabled = false;

            RunAction();

            if (ReportItemStatus == ReportItemStatus.RegistrationFailed)
            {
                btnRegister.Enabled = false;
                btnClose.Enabled = true;
                return;
            }

            var finishedActionIdx = _currentActionIdx;

            if (finishedActionIdx == (int)ActionType.GetWicsToImport)
            {
                lvActions.Items[finishedActionIdx].SubItems[1].Text = "Завершено";
                _currentActionIdx++;
                if (_wicsToImport.Count > 0)
                {
                    _currentWicToImportIdx = 0;
                }
                else
                {
                    lvActions.Items[_currentActionIdx].SubItems[1].Text = "Немає творів для імпотру";
                    lvActions.Items[_currentActionIdx].ImageIndex = 0;
                    _currentActionIdx++;
                    var itemNext = lvActions.Items[_currentActionIdx];
                    itemNext.SubItems[1].Text = "Виконується ...";
                    itemNext.ImageIndex = 0;
                }
                timerRunAction.Enabled = true;
                return;
            }

            if (finishedActionIdx == (int)ActionType.ImportWorkFromWid)
            {
                var item = lvActions.Items[finishedActionIdx];
                item.SubItems[1].Text = $"Імпортовано {_currentWicToImportIdx + 1} творів з {_wicsToImport.Count} ";
                item.ImageIndex = 0;
                _currentWicToImportIdx++;
                if (_currentWicToImportIdx == _wicsToImport.Count())
                {
                    _currentActionIdx++;
                    var itemNext = lvActions.Items[_currentActionIdx];
                    itemNext.SubItems[1].Text = "Виконується ...";
                    itemNext.ImageIndex = 0;
                }
                timerRunAction.Enabled = true;
                return;
            }
            
            lvActions.Items[finishedActionIdx].SubItems[1].Text = "Завершено";
            _currentActionIdx++;
                
            if (_currentActionIdx < ACTIONS.Count())
            {
                var item = lvActions.Items[_currentActionIdx];
                item.SubItems[1].Text = "Виконується ...";
                item.ImageIndex = 0;
                timerRunAction.Enabled = true;
            }
            else
            {
                ReportItemStatus = ReportItemStatus.Registered;
                btnRegister.Enabled = false;
                btnClose.Enabled = true;
            }
        }

        private void FormRegisterReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!btnClose.Enabled)
            {
                e.Cancel = true;
            }
        }
    }
}
