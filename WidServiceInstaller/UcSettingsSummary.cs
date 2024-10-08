using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidServiceInstaller
{
    public partial class UcSettingsSummary : UcBase
    {
        public UcSettingsSummary()
        {
            InitializeComponent();
        }

        private void UcSettingsSummary_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void UcSettingsSummary_Enter(object sender, EventArgs e)
        {
            RefreshData();
        }

        public override bool OnNext()
        {
            var stepText = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                stepText = "Uninstall Service";
                UninstallService();
                stepText = "Copy binaries";
                CopyBinaries();
                stepText = "Creating admin config";
                CreateAdminConfig();
                stepText = "Install and Start Service";
                InstallAndStartService();
                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(
                    $"Виникли помилки на кроці {stepText}.\r\n"
                    + $"{ex.Message}.\r\n"
                    + "Змініть налаштування і спробуйте ще раз.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void CopyBinaries()
        {
            var sourceBaseFolder = Path.GetDirectoryName(Application.ExecutablePath);
            var sourceFolder = Path.Combine(sourceBaseFolder, "WidAdminConsole");
            var targetFolder = Path.Combine(deploymentConfig.DeploymentRootPath, @"bin\WidAdminConsole");

            var diSource = new DirectoryInfo(sourceFolder);
            var diTarget = new DirectoryInfo(targetFolder);

            CopyAll(diSource, diTarget);

            sourceFolder = Path.Combine(sourceBaseFolder, "WidAdminApi");
            targetFolder = Path.Combine(deploymentConfig.DeploymentRootPath, @"bin\WidAdminApi");

            diSource = new DirectoryInfo(sourceFolder);
            diTarget = new DirectoryInfo(targetFolder);

            CopyAll(diSource, diTarget);
            UpdateAppsettingsJson(diTarget);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void UpdateAppsettingsJson(DirectoryInfo widAdminApiDir)
        {
            var connectionString = $@"Persist Security Info=False;User={deploymentConfig.DbServerLogin};Password={deploymentConfig.DbServerPassword};Server={deploymentConfig.DbServerUrl}";
            var fileText = $"{{\"Logging\": {{\"LogLevel\": {{\"Default\": \"Information\",\"Microsoft\": \"Warning\",\"Microsoft.Hosting.Lifetime\": \"Information\"}}}}, \"AllowedHosts\": \"*\",\r\n"
                + $"\"ConnectionStrings\": {{\"WidDbServer\": \"{connectionString.Replace(@"\", @"\\")}\"}}}}";
            File.WriteAllText(Path.Combine(widAdminApiDir.FullName, "appsettings.json"), fileText);
        }

        private void CreateAdminConfig()
        {
            try
            {
                using (var conn = new SqlConnection($@"Persist Security Info=False;Initial Catalog = SocWidAdmin;User={deploymentConfig.DbServerLogin};Password={deploymentConfig.DbServerPassword};Server={deploymentConfig.DbServerUrl}"))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = $@"
                            delete from WidConfigurations
                            insert WidConfigurations (
                                  Name
                                , WidFtpUrl
                                , WidFtpLogin
                                , WidFtpPassword
                                , WidFtpDumpPath
                                , WidFtpUpdatesPath
                                , WidWorkFilesRootPath
                                , IpiFtpUrl
                                , IpiFtpLogin
                                , IpiFtpPassword
                                , IpiFtpDumpPath
                                , IpiFtpUpdatesPath
                                , IpiWorkFilesRootPath
                                , CreatedAt
                                , UpdatedAt
                            )
                            values( 
                                  @Name
                                , @WidFtpUrl
                                , @WidFtpLogin
                                , @WidFtpPassword
                                , @WidFtpDumpPath
                                , @WidFtpUpdatesPath
                                , @WidWorkFilesRootPath
                                , @IpiFtpUrl
                                , @IpiFtpLogin
                                , @IpiFtpPassword
                                , @IpiFtpDumpPath
                                , @IpiFtpUpdatesPath
                                , @IpiWorkFilesRootPath
                                , @CreatedAt
                                , @UpdatedAt
                        )";
                        cmd.Parameters.AddWithValue("@Name", "Продуктова");
                        cmd.Parameters.AddWithValue("@WidFtpUrl", deploymentConfig.WidFtpUrl);
                        cmd.Parameters.AddWithValue("@WidFtpLogin", deploymentConfig.WidFtpLogin);
                        cmd.Parameters.AddWithValue("@WidFtpPassword", deploymentConfig.WidFtpPassword);
                        cmd.Parameters.AddWithValue("@WidFtpDumpPath", "wid-dump");
                        cmd.Parameters.AddWithValue("@WidFtpUpdatesPath", "outbox/SOC");
                        cmd.Parameters.AddWithValue("@WidWorkFilesRootPath", Path.Combine(deploymentConfig.DeploymentRootPath, @"ReplicationWorkFiles\Wid"));
                        cmd.Parameters.AddWithValue("@IpiFtpUrl", deploymentConfig.IpiFtpUrl);
                        cmd.Parameters.AddWithValue("@IpiFtpLogin", deploymentConfig.IpiFtpLogin);
                        cmd.Parameters.AddWithValue("@IpiFtpPassword", deploymentConfig.IpiFtpPassword);
                        cmd.Parameters.AddWithValue("@IpiFtpDumpPath", "IPI/IPI_Pub/Complete_IPI");
                        cmd.Parameters.AddWithValue("@IpiFtpUpdatesPath", "IPI/download");
                        cmd.Parameters.AddWithValue("@IpiWorkFilesRootPath", Path.Combine(deploymentConfig.DeploymentRootPath, @"ReplicationWorkFiles\Ipi"));
                        cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                        cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Не вдалось створити конфігурацію сервісу в БД SocWidAdmin, параметри приєднання {deploymentConfig.DbServerUrl} ({deploymentConfig.DbServerLogin}:{deploymentConfig.DbServerPassword}).\r\n"
                    + $"{ex.Message}");
            }
        }

        private void UninstallService()
        {
            if (WindowsServiceInstaller.ServiceIsInstalled("UacrrWidReplicationService"))
            {
                WindowsServiceInstaller.Uninstall("UacrrWidReplicationService");
            }
        }
        private void InstallAndStartService()
        {
            WindowsServiceInstaller.InstallAndStart("UacrrWidReplicationService",
                    "UacrrWidReplicationService",
                    Path.Combine(deploymentConfig.DeploymentRootPath, @"bin\WidAdminApi\WidAdminApi.exe"));
        }

        private void RefreshData()
        {
            if (deploymentConfig == null) // For Design Mode
            {
                return;
            }

            panelMain.Controls.Clear();

            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            panelMain.RowCount = 3;
            panelMain.RowStyles.Clear();
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));

            panelMain.Controls.Add(new Label { Text = "Сервіси будуть в становлені на основі наступних параметрів:", Dock = DockStyle.Fill }, 0, 0);

            var lv = new ListView
            {
                Dock = DockStyle.Fill,
                MultiSelect = false,
                FullRowSelect = true,
                HeaderStyle = ColumnHeaderStyle.None,
                View = View.Details,
                GridLines = true,
            };
            lv.Columns.Add("Name", 280);
            lv.Columns.Add("Value", 400);
            var cfgType = deploymentConfig.GetType();
            var propDscs = cfgType.GetProperties();
            propDscs.ToList().ForEach(propDsc =>
            {
                var attributes = propDsc.GetCustomAttributes(false).ToDictionary(a => a.GetType().Name, a => a);
                var displayName = ((DisplayNameAttribute)attributes["DisplayNameAttribute"]).DisplayName;
                var lvItem = lv.Items.Add(displayName);
                lvItem.SubItems.Add((string)propDsc.GetValue(deploymentConfig));
            });
            panelMain.Controls.Add(lv, 0, 1);

            panelMain.Controls.Add(new Label { Text = "Натисніть Далі щоб встановити.", Dock = DockStyle.Fill }, 0, 2);

            panelMain.Size = new Size(775, 549);
            panelMain.TabIndex = 1;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
        }

        private void UcSettingsSummary_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                RefreshData();
            }
        }
    }
}
