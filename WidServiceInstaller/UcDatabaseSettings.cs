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
    public partial class UcDatabaseSettings : UcBase
    {
        private Dictionary<string, string> migrations;

        public UcDatabaseSettings()
        {
            InitializeComponent();
        }

        private void UcDatabaseSettings_Load(object sender, EventArgs e)
        {
            if(deploymentConfig == null) // For Design Mode
            {
                return;
            }
            ReadMigrations();
            var labelText = "Перш, ніж продовжити, забезпечте існування вказаного облікового запису, "
                + "створіть бази даних з назвами SocWid, SocIpi, SocWidInitial, SocWidUpdates, SocWidAdmin, "
                + "виконайте скрипти з фолдеру SqlScript цього інсталяційного пакету, "
                + "і надайте права читання/запису/масових операцій для цих баз даних вказаному обліковому запису "
                + "(для цього достатньо приначити роль db_owner). Приклад скрипта для створення баз даних міститься в фолдері SqlScript.";
            panelMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelMain.Controls.Add(new Label { Text = labelText, Dock = DockStyle.Fill }, 0, panelMain.RowStyles.Count - 1);
        }

        protected void ReadMigrations()
        {
            migrations = new Dictionary<string, string>();
            using (var sr = new StreamReader("Migrations.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if(string.IsNullOrEmpty(line))
                    {
                        continue;
                    }
                    var sepPos = line.IndexOf(':');
                    migrations.Add(line.Substring(0, sepPos).Trim(), line.Substring(sepPos + 1).Trim());
                }
            }
        }

        protected override bool ValidateChanges()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ValidateConnection();
                migrations.Keys.ToList().ForEach(dbName => ValidateAccessToDb(dbName));
                migrations.ToList().ForEach(pair => ValidateMigration(pair.Key, pair.Value));
                migrations.Keys.ToList().ForEach(dbName => ValidateWriteAccess(dbName));

                Cursor.Current = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(
                    $"{ex.Message}.\r\nЗмініть налаштування і спробуйте ще раз.",
                    "Помилка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void ValidateConnection()
        {
            try
            {
                using (var conn = new SqlConnection($@"Persist Security Info=False;User={deploymentConfig.DbServerLogin};Password={deploymentConfig.DbServerPassword};Server={deploymentConfig.DbServerUrl}"))
                {
                    conn.Open();
                }
             }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Не вдалось приєднатись до серверу баз даних з параметрами {deploymentConfig.DbServerUrl} ({deploymentConfig.DbServerLogin}:{deploymentConfig.DbServerPassword}).\r\n"
                    + $"{ex.Message}.");
            }
        }

        private void ValidateAccessToDb(string dbName)
        {
            try
            {
                using (var conn = new SqlConnection($@"Persist Security Info=False;Initial Catalog = {dbName};User={deploymentConfig.DbServerLogin};Password={deploymentConfig.DbServerPassword};Server={deploymentConfig.DbServerUrl}"))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Не вдалось приєднатись до бази даних {dbName} з параметрами {deploymentConfig.DbServerUrl} ({deploymentConfig.DbServerLogin}:{deploymentConfig.DbServerPassword}).\r\n"
                    + $"{ex.Message}");
            }
        }

        private void ValidateMigration(string dbName, string migrationId)
        {
            try
            {
                using (var conn = new SqlConnection($@"Persist Security Info=False;Initial Catalog = {dbName};User={deploymentConfig.DbServerLogin};Password={deploymentConfig.DbServerPassword};Server={deploymentConfig.DbServerUrl}"))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = $"select null from __EFMigrationsHistory where MigrationId = @MigrationId";
                        cmd.Parameters.AddWithValue("@MigrationId", migrationId);
                        using (var r = cmd.ExecuteReader())
                        {
                            if(!r.HasRows)
                            {
                                r.Close();
                                throw new Exception(
                                    $"Не застосована міграція {migrationId}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Не вірна схема бази даних {dbName}, параметри приєднання {deploymentConfig.DbServerUrl} ({deploymentConfig.DbServerLogin}:{deploymentConfig.DbServerPassword}).\r\n"
                    + $"{ex.Message}");
            }
        }

        private void ValidateWriteAccess(string dbName)
        {
            try
            {
                using (var conn = new SqlConnection($@"Persist Security Info=False;Initial Catalog = {dbName};User={deploymentConfig.DbServerLogin};Password={deploymentConfig.DbServerPassword};Server={deploymentConfig.DbServerUrl}"))
                {
                    conn.Open();
                    using(var tran = conn.BeginTransaction())
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = tran;
                        cmd.CommandText = $"insert __EFMigrationsHistory (MigrationId, ProductVersion) values('test', 'test')";
                        cmd.ExecuteNonQuery();
                        tran.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Не вірна схема бази даних {dbName}, параметри приєднання {deploymentConfig.DbServerUrl} ({deploymentConfig.DbServerLogin}:{deploymentConfig.DbServerPassword}).\r\n"
                    + $"{ex.Message}");
            }
        }
    }
}
