using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidServiceInstaller
{
    public partial class UcGeneralSettings : UcBase
    {
        public UcGeneralSettings()
        {
            InitializeComponent();
        }

        protected override bool ValidateChanges()
        {
            var di = new DirectoryInfo(deploymentConfig.DeploymentRootPath);
            if(!di.Exists)
            {
                MessageBox.Show(
                    $"Фолдера '{deploymentConfig.DeploymentRootPath}' не існує.\r\n"
                    + "Вкажіть інший фолдер, або створіть потрібний фолдер і забезпечте повний доступ до нього під системним обліковим записом (Local System).",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
            var acl = di.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));

            for (int i = 0; i < acl.Count; i++)
            {
                var rule = (FileSystemAccessRule)acl[i];
                if(rule.IdentityReference.Value == "S-1-5-18"
                    && rule.AccessControlType ==AccessControlType.Allow
                    && rule.FileSystemRights == FileSystemRights.FullControl
                )
                {
                    return true;
                }
            }
            MessageBox.Show(
                $"Системний обліковий запис (Local System), під яким буде встановлено сервіс реплікації, не має необхідного доступу до фолдеру '{deploymentConfig.DeploymentRootPath}'\r\n"
                + "Вкажіть інший фолдер, або забезпечте повний доступ до вказаного фолдеру для Local System.",
                "Помилка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            return false;
        }

    }
}
