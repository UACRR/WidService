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
    public partial class UcWidFtpSettings : UcBase
    {
        public UcWidFtpSettings()
        {
            InitializeComponent();
        }

        protected override bool ValidateChanges()
        {
            Cursor.Current = Cursors.WaitCursor;
            var ftpClient = new FtpClient(deploymentConfig.WidFtpUrl, deploymentConfig.WidFtpLogin, deploymentConfig.WidFtpPassword);
            var retVal = ftpClient.HasAccess(deploymentConfig.WidFtpUrl);
            if(!retVal)
            {
                MessageBox.Show(
                    $"Не вдалось приєднатись до FTP серверу WID з параметрами {deploymentConfig.WidFtpUrl} ({deploymentConfig.WidFtpLogin}:{deploymentConfig.WidFtpPassword}).\r\n"
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
