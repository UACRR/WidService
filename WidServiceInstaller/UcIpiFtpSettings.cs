using SharedLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidServiceInstaller
{
    public partial class UcIpiFtpSettings : UcBase
    {
        public UcIpiFtpSettings()
        {
            InitializeComponent();
        }

        protected override bool ValidateChanges()
        {
            Cursor.Current = Cursors.WaitCursor;
            var ftpClient = new FtpClient(deploymentConfig.IpiFtpUrl, deploymentConfig.IpiFtpLogin, deploymentConfig.IpiFtpPassword, true);
            var retVal = ftpClient.HasAccess(deploymentConfig.IpiFtpUrl);
            if (!retVal)
            {
                MessageBox.Show(
                    $"Не вдалось приєднатись до FTP серверу IPI з параметрами {deploymentConfig.IpiFtpUrl} ({deploymentConfig.IpiFtpLogin}:{deploymentConfig.IpiFtpPassword}).\r\n"
                    + "Змініть налаштування і спробуйте ще раз.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Cursor.Current = Cursors.Default;
            return retVal;
        }
    }
}
