using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidServiceInstaller
{
    public partial class FormMain : Form
    {
        enum StepStatus
        {
            awaiting = -1,
            pending = 0,
            inprogress = 1,
            completed = 2,
            failed = 3,
        }
        class StepInfo
        {
            public string Name { get; set; }
            public StepStatus Status { get; set; }
            public UcBase UserControl { get; set; }
        }

        List<StepInfo> steps;
        int currentStepIndex;
        DeploymentConfig deploymentConfig;

        public FormMain()
        {
            InitializeComponent();
            steps = new List<StepInfo>
            {
                new StepInfo { Name = "Загальні налаштування", Status = StepStatus.pending, UserControl = ucGeneralSettings},
                new StepInfo { Name = "Налаштування доступу до оновлень WID", Status = StepStatus.awaiting, UserControl = ucWidFtpSettings},
                new StepInfo { Name = "Налаштування доступу до оновлень IPI", Status = StepStatus.awaiting, UserControl = ucIpiFtpSettings},
                new StepInfo { Name = "Налаштування баз даних для рееплікації", Status = StepStatus.awaiting, UserControl = ucDatabaseSettings},
                new StepInfo { Name = "Підсумкові налаштування", Status = StepStatus.awaiting, UserControl = ucSettingsSummary},
                new StepInfo { Name = "Результат встановлення", Status = StepStatus.awaiting, UserControl = ucFinish },
            };
            currentStepIndex = 0;
            deploymentConfig = new DeploymentConfig();
            steps.ForEach(step =>
            {
                step.UserControl.deploymentConfig = deploymentConfig;
            });
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lvSteps.Columns[0].Width = 280;
            steps.ForEach(step =>
            {
                var item = lvSteps.Items.Add(step.Name, (int)step.Status);
                item.Tag = step;
            });
        }

        private void lvSteps_SelectedIndexChanged(object sender, EventArgs e)
        {
            RemoveLvStepsSelection();
        }

        private void RemoveLvStepsSelection()
        {
            foreach (ListViewItem item in lvSteps.Items)
            {
                item.Selected = false;
                item.Focused = false;
            }
        }

        private void timerOnLoad_Tick(object sender, EventArgs e)
        {
            timerOnLoad.Enabled = false;
            RefreshAll();
        }

        private void RefreshAll()
        {
            for(int i = 0; i < lvSteps.Items.Count; i++)
            {
                var item = lvSteps.Items[i];
                var uc = ((StepInfo)item.Tag).UserControl;
                uc.deploymentConfig = deploymentConfig;
                uc.BackColor = Color.Transparent;

                item.Selected = false;
                item.Focused = false;
                if (i < currentStepIndex)
                {
                    item.ImageIndex = (int)StepStatus.completed;
                    uc.Visible = false;
                }
                else if (i == currentStepIndex)
                {
                    item.ImageIndex = (int)StepStatus.pending;
                    uc.Visible = true;
                    uc.Dock = DockStyle.Fill;
                }
                else
                {
                    item.ImageIndex = (int)StepStatus.awaiting;
                    uc.Visible = false;
                }
                btnPrev.Enabled = currentStepIndex > 0 && currentStepIndex < steps.Count - 1;
                btnNext.Enabled = currentStepIndex < steps.Count - 1;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentStepIndex--;
            RefreshAll();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var step = steps[currentStepIndex];
            if (!step.UserControl.OnNext())
            {
                return;
            }
            currentStepIndex++;
            RefreshAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(currentStepIndex < steps.Count - 1 &&
                DialogResult.No == MessageBox.Show("Припинити розгортання сервісів?", "Розготання сервісів реплікації WID", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }
            Close();
        }
    }
}
