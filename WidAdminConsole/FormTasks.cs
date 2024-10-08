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
    public partial class FormTasks : Form
    {
        private static readonly string[] _subjectNames = new string[]
        {
            "",
            "Завантаження початкової інформації",
            "Розрахунок дати початкової інформації",
            "Оновлення",
            "Завантаження квартального оновлення інформації",
            "Розрахунок дати квартального оновлення інформації",
            "Застосування квартального оновлення",
        };

        private static readonly string[] _taskNames = new string[]
        {
            "",
            "Завантажити файл",
            "Розпакувати файл",
            "Видалити запакований файл",
            "Занести інформацію з файлу до бази даних",
            "Видалити файл",
            "Знайти дату початкової/квартальної інформації",
            "Оновити дані в таблиці з квартальної інформації",
            "Створити копію інформації з файлу в базі даних",
            "Створити історичні записи",
            "Змінити назву SocWid на SocWid_",
            "Змінити назву SocWidInitial на SocWid",
            "Змінити назву SocWid_ на SocWidInitial",
        };

        private Dictionary<int, TreeNode> _periodNodes = new Dictionary<int, TreeNode>();
        private Dictionary<int, TreeNode> _subjectNodes = new Dictionary<int, TreeNode>();
        private Dictionary<int, TreeNode> _objectNodes = new Dictionary<int, TreeNode>();
        private Dictionary<string, TreeNode> _dayNodes = new Dictionary<string, TreeNode>();
        private string _errMsg;

        private List<WidUpdatePeriodDto> _periods;
        public FormTasks()
        {
            InitializeComponent();
        }

        private void FormTasks_Load(object sender, EventArgs e)
        {
            timerLoad.Enabled = true;
        }

        private void RefreshPeriodNodes()
        {
            // Provide for periods sorting
            _periods.ForEach(x =>
            {
                if (x.WidDumpTs == null) x.WidDumpTs = new DateTime(1900, 1, 1);
            });

            _periods.OrderBy(x => x.WidDumpTs).ToList().ForEach(period =>
            {
                TreeNode periodNode = null;
                if (_periodNodes.ContainsKey(period.Id))
                {
                    periodNode = _periodNodes[period.Id];
                }
                else
                {
                    var periodName = ((DateTime)period.WidDumpTs).ToString("yyyy-MM-dd");
                    if (periodName == (new DateTime(1900, 1, 1)).ToString("yyyy-MM-dd"))
                    {
                        periodName = "Початковий період";
                    }
                    else
                    {
                        periodName = $"Починаючи з {periodName}";
                    }
                    periodNode = tvLeft.Nodes.Add(periodName);
                    _periodNodes.Add(period.Id, periodNode);
                }
                periodNode.Tag = period;
                AssignImage(periodNode, period.WidTaskStatusId);
            });
        }

        private void RefreshSubjectNodes()
        {
            _periods.OrderBy(x => x.WidDumpTs).ToList().ForEach(period =>
            {
                period.WidTaskSubjects.OrderBy(x => x.WidTaskSubjectTypeId).ToList().ForEach(subject =>
                {
                    var periodNode = _periodNodes[subject.WidUpdatePeriodId];
                    TreeNode subjectNode = null;
                    if (_subjectNodes.ContainsKey(subject.Id))
                    {
                        subjectNode = _subjectNodes[subject.Id];
                    }
                    else
                    {
                        var nodeName = $"{subject.Db}: {_subjectNames[subject.WidTaskSubjectTypeId]}";
                        if(subject.WidTaskSubjectTypeId == (int)WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles)
                        {
                            nodeName += $" {(DateTime)subject.TasksDate:yyyy-MM-dd}";
                        }
                        subjectNode = periodNode.Nodes.Add(nodeName);
                        _subjectNodes.Add(subject.Id, subjectNode);
                    }
                    subjectNode.Tag = subject;
                    AssignImage(subjectNode, subject.WidTaskStatusId);
                });
            });
        }

        private void RefreshObjectNodes()
        {
            _periods.OrderBy(x => x.WidDumpTs).ToList().ForEach(period =>
            {
                period.WidTaskSubjects.OrderBy(x => x.WidTaskSubjectTypeId).ToList().ForEach(subject =>
                {
                    subject.WidTaskObjects.OrderBy(x => x.ObjectInfo).ToList().ForEach(obj => {
                        var subjectNode = _subjectNodes[obj.WidTaskSubjectId];
                        TreeNode objectNode = null;
                        if (_objectNodes.ContainsKey(obj.Id))
                        {
                            objectNode = _objectNodes[obj.Id];
                        }
                        else
                        {
                            var nodeName = "";
                            switch((WidTaskSubjectTypeCodeEnum)subject.WidTaskSubjectTypeId)
                            {
                                case WidTaskSubjectTypeCodeEnum.InitFromDump:
                                    if (subject.Db == "WID")
                                        nodeName = $"Таблиця {obj.ObjectInfo}";
                                    else
                                        nodeName = $"Файл {obj.ObjectInfo}";
                                    break;
                                case WidTaskSubjectTypeCodeEnum.UpdateFromTranFiles:
                                    if (subject.Db == "WID")
                                        nodeName = $"Час {obj.ObjectInfo.Substring(11, 2)}:{obj.ObjectInfo.Substring(13, 2)}:{obj.ObjectInfo.Substring(15, 2)}";
                                    else
                                        nodeName = $"Час 00:00:00";
                                    break;
                                case WidTaskSubjectTypeCodeEnum.InitNewDump:
                                    nodeName = obj.ObjectInfo;
                                    break;
                                case WidTaskSubjectTypeCodeEnum.UpdateFromNewDump:
                                    nodeName = obj.ObjectInfo;
                                    break;
                                case WidTaskSubjectTypeCodeEnum.CalcInitDumpTs:
                                case WidTaskSubjectTypeCodeEnum.CalcNewDumpTs:
                                    nodeName = "Всі таблиці";
                                    break;
                            }
                            objectNode = subjectNode.Nodes.Add(nodeName);
                            _objectNodes.Add(obj.Id, objectNode);
                        }
                        objectNode.Tag = obj;
                        AssignImage(objectNode, obj.WidTaskStatusId);
                    });
                });
            });
        }

        private void ResetIfHasMissingIds()
        {
            var usedPeriods = new HashSet<int>();
            var usedSubjects = new HashSet<int>();
            var usedObjects = new HashSet<int>();
            _periods.ForEach(period =>
            {
                usedPeriods.Add(period.Id);
                period.WidTaskSubjects.ForEach(subject =>
                {
                    usedSubjects.Add(subject.Id);
                    subject.WidTaskObjects.ForEach(obj =>
                    {
                        usedObjects.Add(obj.Id);
                    });
                });
            });

            if(
                _periodNodes.Any(x => !usedPeriods.Contains(x.Key)) ||
                _subjectNodes.Any(x => !usedSubjects.Contains(x.Key)) ||
                _objectNodes.Any(x => !usedObjects.Contains(x.Key))
            )
            {
                 _periodNodes = new Dictionary<int, TreeNode>();
                 _subjectNodes = new Dictionary<int, TreeNode>();
                 _objectNodes = new Dictionary<int, TreeNode>();
            }

        }

        private void RefreshErrorMsg()
        {
            _errMsg = "";
            _periods.ForEach(period =>
            {
                period.WidTaskSubjects.ForEach(subject =>
                {
                    subject.WidTaskObjects.ForEach(obj =>
                    {
                        var failedTask = obj.WidTasks.SingleOrDefault(task => task.WidTaskStatusId == (int)WidTaskStatusCodeEnum.Failed);
                        if(failedTask != null)
                        {
                            _errMsg = failedTask.ErrMsg;
                            var node = _objectNodes[obj.Id];
                            AssignImage(node, (int)WidTaskStatusCodeEnum.Failed);
                            while( (node = node.Parent) != null)
                            {
                                AssignImage(node, (int)WidTaskStatusCodeEnum.Failed);
                            }
                        }
                    });
                });
            });
            labError.Visible = _errMsg != "";
            linkErrorDetails.Visible = labError.Visible;
        }

        private void RefreshFromService()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                var task = Task.Run(async () => await GetWidAllTasks());
                task.Wait();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor.Current = Cursors.Default;
                return;
            }

            try
            {
                ResetIfHasMissingIds();

                RefreshPeriodNodes();
                RefreshSubjectNodes();
                RefreshObjectNodes();
                RefreshTasks(tvLeft.SelectedNode);
                RefreshErrorMsg();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private async Task GetWidAllTasks()
        {
            HttpClient client = new HttpClient();
            WidAllTasksRsp widTasksRsp;
            var url = Program.GetUrl("widalltasks");
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                widTasksRsp = await response.Content.ReadAsAsync<WidAllTasksRsp>();
                _periods = widTasksRsp.WidUpdatePeriods;
            }
            else
            {
                MessageBox.Show($"Запит до сервісу повернув помилку {response.StatusCode.ToString()}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception($"Запит до сервісу повернув помилку {response.StatusCode.ToString()}");
            }

        }

        private int GetStatusImageIndex(int statusId)
        {
            return statusId - 1;
        }

        private void AssignImage(TreeNode node, int statusId)
        {
            node.ImageIndex = GetStatusImageIndex(statusId);
            node.SelectedImageIndex = node.ImageIndex;
        }

        private void tvLeft_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshTasks(e.Node);
        }

        private void RefreshTasks(TreeNode node)
        {
            if(node == null)
            {
                lvRight.Items.Clear();
                labTasksPath.Text = "";
                lvRight.Visible = false;
                return;
            }

            lvRight.Items.Clear();

            labTasksPath.Text = node.Text;

            {
                var curNode = node;
                while ((curNode = curNode.Parent) != null)
                {
                    labTasksPath.Text = $"{curNode.Text}/{labTasksPath.Text}";
                };
            }
            

            if (node.Tag == null || node.Tag.GetType() != typeof(WidTaskObjectDto))
            {
                lvRight.Visible = false;
                return;
            }
            var obj = (WidTaskObjectDto)node.Tag;
            obj.WidTasks.OrderBy(x => x.ScheduledAt).ToList().ForEach(x =>
            {
                var item = lvRight.Items.Add(_taskNames[x.WidTaskTypeId]);
                item.SubItems.Add(x.PercentDone.ToString());
                if (x.StartedAt != null)
                {
                    item.SubItems.Add(((DateTime)x.StartedAt).ToString("yyyy-MM-dd hh:mm:ss"));
                }
                else
                {
                    item.SubItems.Add("");
                }
                if (x.EndedAt != null)
                {
                    item.SubItems.Add(((DateTime)x.EndedAt).ToString("yyyy-MM-dd hh:mm:ss"));
                }
                else
                {
                    item.SubItems.Add("");
                }
                item.ImageIndex = GetStatusImageIndex(x.WidTaskStatusId);
            });
            lvRight.Visible = true;

        }

        private void btnRefreshTasks_Click(object sender, EventArgs e)
        {
            RefreshFromService();
        }

        private void linkErrorDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var msg = $"{_errMsg}\r\n\r\n" +
                "Зауваження: сервіс буде продовжувати спробу виконати опеацію з інтервалом 10 хвилин.\r\n" +
                "В разі, якщо помилка викликана втратою зв'язку за FTP або сервером баз даних, зупиняти сервіс немає необхідності.\r\n" +
                "В іншому випадку рекомендується зупинити сервіс UacrrWidService і запустити його після виправлення помилок.";
            MessageBox.Show(msg, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var dlg = new FormParameters();
            dlg.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            timerLoad.Enabled = false;
            RefreshFromService();

        }
    }
}
