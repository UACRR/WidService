using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidServiceInstaller
{
    public partial class UcFinish : UcBase
    {
        public UcFinish()
        {
            InitializeComponent();
        }

        private void UcFinish_Load(object sender, EventArgs e)
        {
            if (deploymentConfig == null) // For Design Mode
            {
                return;
            }

            var labelText = $"Сервіс реплікації встановлено і запущено під системним обліковім записом.\r\n\r\n"
                + $"Назва сервісу UacrrWidReplicationService.\r\n\r\n"
                + $"Для керуванням сервісом запустіть консоль '{Path.Combine(deploymentConfig.DeploymentRootPath, @"bin\WidAdminConsole\WidAdminConsole.exe")}'.";
            panelMain.Controls.Add(new Label { Text = labelText, Dock = DockStyle.Fill }, 0, 0);
        }
    }
}
