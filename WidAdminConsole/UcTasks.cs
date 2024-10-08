using SharedLib;
using SharedLib.Dto;
using SharedLib.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidAdminConsole
{
    public partial class UcTasks : UserControl
    {
        private Dictionary<WidTaskTypeCodeEnum, string> _taskCodeText = new Dictionary<WidTaskTypeCodeEnum, string>()
        {
            {WidTaskTypeCodeEnum.FileDownload, "Завантаження з Ftp" },
            {WidTaskTypeCodeEnum.FileUnzip, "Розпакування" },
            {WidTaskTypeCodeEnum.FileZipDelete, "Проміжна очистка" },
            {WidTaskTypeCodeEnum.FileApplyToDb, "Завантаження в БД" },
            {WidTaskTypeCodeEnum.CreateHistRecords, "Створити історичні записи" },
            {WidTaskTypeCodeEnum.FileDelete, "Фіналізація" },
        };

        private Dictionary<WidTaskStatusCodeEnum, string> _statusCodeText = new Dictionary<WidTaskStatusCodeEnum, string>()
        {
            {WidTaskStatusCodeEnum.Pending, "Очікує" },
            {WidTaskStatusCodeEnum.InProgress, "Виконується" },
            {WidTaskStatusCodeEnum.Completed, "Завершено" },
            {WidTaskStatusCodeEnum.Failed, "Помилки" },
        };

        private WidTaskDto[] _widTasks;
        private bool _isRunning;
        private string _errMsg;

        public UcTasks()
        {
            InitializeComponent();
        }
        private void UcTasks_Load(object sender, EventArgs e)
        {
            RefreshFromService();
        }

        private async Task GetWidTasks()
        {
            HttpClient client = new HttpClient();
            WidTasksRsp widTasksRsp = null;
            HttpResponseMessage response = await client.GetAsync(Program.GetUrl("widtasks"));
            if (response.IsSuccessStatusCode)
            {
                widTasksRsp = await response.Content.ReadAsAsync<WidTasksRsp>();
            }
            _widTasks = widTasksRsp.WidTasks;
            _isRunning = widTasksRsp.IsRunning;
            var failedTask = _widTasks.SingleOrDefault(x => x.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Failed);
            if(failedTask == null)
            {
                _errMsg = "";
            }
            else
            {
                _errMsg = failedTask.ErrMsg;
            }
        }

        private async Task RunWidTasks()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Program.GetUrl("runtasks"));
            bool res = false;
            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<bool>();
            }
            _isRunning = true;
            _errMsg = null;
        }

        private async Task StopWidTasks()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Program.GetUrl("stoptasks"));
            bool res = false;
            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsAsync<bool>();
            }
            _isRunning = false;
            _errMsg = null;
        }


        private void RefreshTasksList()
        {
            var items = lvTasks.Items;
            //items.Clear();

            for(int i = 0; i < Math.Max(_widTasks.Length, items.Count); i++)
            {
                if(i >= _widTasks.Length)
                {
                    throw new Exception("Error");
                }
                else if (i >= items.Count)
                {
                    var task = _widTasks[i];
                    var item = items.Add(task.EntityName);
                    item.SubItems.Add(_taskCodeText[(WidTaskTypeCodeEnum)task.WidTaskTypeId]);
                    item.SubItems.Add(_statusCodeText[(WidTaskStatusCodeEnum)task.WidTaskStatusId]);
                    item.SubItems.Add(task.PercentDone.ToString());
                    item.SubItems.Add(task.StartedAt == null ? "" : task.StartedAt.ToString());
                    item.SubItems.Add(task.EndedAt == null ? "" : task.EndedAt.ToString());
                }
                else
                {
                    var task = _widTasks[i];
                    var item = items[i];
                    var status = (WidTaskStatusCodeEnum)task.WidTaskStatusId;
                    //item.SubItems.Add(_taskCodeText[(WidTaskTypeCodeEnum)task.WidTaskTypeId]);
                    item.SubItems[2].Text = _statusCodeText[status];
                    item.SubItems[3].Text = task.PercentDone.ToString();
                    item.SubItems[4].Text = task.StartedAt == null ? "" : task.StartedAt.ToString();
                    item.SubItems[5].Text = task.EndedAt == null ? "" : task.EndedAt.ToString();
                    if((status == WidTaskStatusCodeEnum.InProgress || status == WidTaskStatusCodeEnum.Failed))
                    {
                        item.EnsureVisible();
                    }
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                var task = Task.Run(async () => await RunWidTasks());
                task.Wait();
                RefreshControls();
            }
            catch (Exception)
            {
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                var task = Task.Run(async () => await StopWidTasks());
                task.Wait();
                RefreshControls();
            }
            catch (Exception)
            {
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFromService();
        }

        private void RefreshFromService()
        {
            try
            {
                timerRefresh.Enabled = false;
                var task = Task.Run(async () => await GetWidTasks());
                task.Wait();
                RefreshTasksList();
                RefreshControls();
                //timerRefresh.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

       private void RefreshControls()
        {
            btnRun.Enabled = !_isRunning;
            btnStop.Enabled = _isRunning;
            btnShowError.Visible = !string.IsNullOrEmpty(_errMsg);
            if(!string.IsNullOrEmpty(_errMsg))
            {
                labMessage.Text = "Виконання задач припинено внаслідок помилк";
            }
            else if (_isRunning)
            {
                labMessage.Text = "Задачі виконуються";
            }
            else
            {
                labMessage.Text = "Виконання задач не розпочато або припинене оператором";
            }
        }

        private void btnShowError_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_errMsg, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            RefreshFromService();
        }
    }
}
