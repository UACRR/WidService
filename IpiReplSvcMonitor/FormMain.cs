using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace IpiReplSvcMonitor
{
    public partial class FormMain : Form
    {
        private class Period
        {
            public int Id { get; set; }
            public DateTime IpiCompleteDate { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime StartedAt { get; set; }
            public DateTime EndedAt { get; set; }
        }

        private class Job
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string StartedAt { get; set; }
            public string EndedAt { get; set; }
        }

        private class Task
        {
            public int Id { get; set; }
            public string FileName { get; set; }
            public string StartedAt { get; set; }
            public string EndedAt { get; set; }
        }

        private class Step
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string FileName { get; set; }
            public string StartedAt { get; set; }
            public string EndedAt { get; set; }
        }

        private List<Period> _periods;
        private List<Job> _jobs;
        private List<Task> _tasks;
        private List<Step> _steps;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                Configure();

                LoadPeriods();
                FillPeriods();

                LoadJobs();
                FillJobs();

                FillError();
            });
        }

        private void Configure()
        {
            Helpers.ConfigureListView(lvJobs
                , "Код"
                , "Назва"
                , "Початок"
                , "Завершення"
            );

            Helpers.ConfigureListView(lvTasks
                , "Код"
                , "Файл"
                , "Початок"
                , "Завершення"
            );

            Helpers.ConfigureListView(lvSteps
                , "Код"
                , "Назва"
                , "Файл"
                , "Початок"
                , "Завершення"
            );

            lvJobs.SmallImageList = ilEntityTypes;
            lvJobs.StateImageList = ilStatuses;

            lvTasks.SmallImageList = ilEntityTypes;
            lvTasks.StateImageList = ilStatuses;

            lvSteps.SmallImageList = ilEntityTypes;
            lvSteps.StateImageList = ilStatuses;
        }

        private void FillError()
        {
            Helpers.RunSqlSocIpi(cmd =>
            {
                cmd.CommandText = @"
                    select top 1 t1.ErrMsg
                    from RpnJobTaskStepErrs t1
	                    join RpnJobTaskSteps t2 on t1.RpnJobTaskStepId = t2.Id
                    where t2.EndedAt is null
                    order by t1.Id desc
                ";
                var errText = cmd.ExecuteScalar();
                labErrorText.Text = errText == null ? "" : (string)errText;
            });
        }

        private void LoadPeriods()
        {
            Helpers.RunSqlSocIpi(cmd =>
            {
                cmd.CommandText = @"select * from RpnPeriods";
                _periods = Helpers.CreateListFromCmd<Period>(cmd);
            });
        }

        private void FillPeriods()
        {
            tbIpiStartDate.Text = _periods[0].IpiCompleteDate.ToString("yyyy-MM-dd");
        }

        private void LoadJobs()
        {
            Helpers.RunSqlSocIpi(cmd =>
            {
                cmd.CommandText = @"
                    select t1.Id
	                    , t2.Description
	                    , format(t1.StartedAt, 'yyyy-MM-dd HH:mm:ss')
                        , format(t1.EndedAt, 'yyyy-MM-dd HH:mm:ss')
                    from RpnJobs t1
	                    join RpnJobTypes t2 on t1.RpnJobTypeId = t2.Id
                    order by t1.SeqNr
            ";
                _jobs = Helpers.CreateListFromCmd<Job>(cmd);
            });
        }

        private void FillJobs()
        {
            Helpers.FillListView(_jobs, lvJobs, job =>
            {
                return false;
            });

            foreach (ListViewItem item in lvJobs.Items)
            {
                var job = item.Tag as Job;
                item.ImageIndex = -1;
                item.StateImageIndex = job.StartedAt == "" ? -1 : job.EndedAt == "" ? 0 : 1;
            }

        }

        private void LoadTasks(int jobId)
        {
            var extraFilter = rbFilterFinished.Checked ? "and t1.EndedAt is not null" :
                rbFilterNext.Checked ? "and t1.EndedAt is null" :
                "";
            Helpers.RunSqlSocIpi(cmd =>
            {
                cmd.CommandText = $@"
                    select t1.Id
                        , t3.FileName
                        , format(t1.StartedAt, 'yyyy-MM-dd HH:mm:ss')
                        , format(t1.EndedAt, 'yyyy-MM-dd HH:mm:ss')
                    from RpnJobTasks t1
                        join RpnJobTaskTypes t2 on t1.RpnJobTaskTypeId = t2.Id
	                    join RpnJobTaskSteps t3 on t1.Id = t3.RpnJobTaskId
		                    and t3.RpnJobTaskStepTypeId = 5
                    where t1.RpnJobId = @jobId
                        {extraFilter}
                    order by t1.SeqNr
                ";
                cmd.Parameters.AddWithValue("@jobId", jobId);
                _tasks = Helpers.CreateListFromCmd<Task>(cmd);
            });
        }

        private void FillTasks()
        {
            Helpers.FillListView(_tasks, lvTasks, task =>
            {
                return false;
            });

            foreach (ListViewItem item in lvTasks.Items)
            {
                var task = item.Tag as Task;
                item.ImageIndex = -1;
                item.StateImageIndex = task.StartedAt == "" ? -1 : task.EndedAt == "" ? 0 : 1;
            }
        }

        private void LoadSteps(int taskId)
        {
            Helpers.RunSqlSocIpi(cmd =>
            {
                cmd.CommandText = @"
                    select t1.Id
	                    , t2.Description
	                    , t1.FileName
	                    , format(t1.StartedAt, 'yyyy-MM-dd HH:mm:ss')
                        , format(t1.EndedAt, 'yyyy-MM-dd HH:mm:ss')
                    from RpnJobTaskSteps t1
	                    join RpnJobTaskStepTypes t2 on t1.RpnJobTaskStepTypeId = t2.Id
                    where t1.RpnJobTaskId = @taskId
                    order by t1.SeqNr
                ";
                cmd.Parameters.AddWithValue("@taskId", taskId);
                _steps = Helpers.CreateListFromCmd<Step>(cmd);
            });
        }

        private void FillSteps()
        {
            Helpers.FillListView(_steps, lvSteps, step =>
            {
                return false;
            });

            foreach (ListViewItem item in lvSteps.Items)
            {
                var step = item.Tag as Step;
                item.ImageIndex = -1;
                item.StateImageIndex = step.StartedAt == "" ? -1 : step.EndedAt == "" ? 0 : 1;
            }
        }

        private void lvJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                lvTasks.Items.Clear();
                lvSteps.Items.Clear();

                if (lvJobs.SelectedItems.Count == 0)
                    return;

                var job = (Job)lvJobs.SelectedItems[0].Tag;
                LoadTasks(job.Id);
                FillTasks();
            });
        }

        private void lvTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                lvSteps.Items.Clear();

                if (lvTasks.SelectedItems.Count == 0)
                    return;

                var task = (Task)lvTasks.SelectedItems[0].Tag;
                LoadSteps(task.Id);
                FillSteps();
            });
        }

        private void rbFilterNext_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                if (rbFilterNext.Checked)
                {
                    lvTasks.Items.Clear();
                    lvSteps.Items.Clear();
                    if (lvJobs.SelectedItems.Count == 0)
                        return;

                    var job = (Job)lvJobs.SelectedItems[0].Tag;
                    LoadTasks(job.Id);
                    FillTasks();
                }
            });
        }

        private void rbFilterFinished_CheckedChanged(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                if (rbFilterFinished.Checked)
                {
                    lvTasks.Items.Clear();
                    lvSteps.Items.Clear();
                    if (lvJobs.SelectedItems.Count == 0)
                        return;

                    var job = (Job)lvJobs.SelectedItems[0].Tag;
                    LoadTasks(job.Id);
                    FillTasks();
                }
            });
        }

        private void btnRefreshJobs_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                lvTasks.Items.Clear();
                lvSteps.Items.Clear();

                LoadJobs();
                FillJobs();
            });
        }

        private void btnRefreshTasks_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                if (lvJobs.SelectedItems.Count == 0)
                    return;

                lvSteps.Items.Clear();

                var job = (Job)lvJobs.SelectedItems[0].Tag;
                LoadTasks(job.Id);
                FillTasks();
            });
        }

        private void btnRefreshSteps_Click(object sender, EventArgs e)
        {
            Helpers.RunProtected(() =>
            {
                if (lvTasks.SelectedItems.Count == 0)
                    return;

                var task = (Task)lvTasks.SelectedItems[0].Tag;
                LoadSteps(task.Id);
                FillSteps();
            });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
