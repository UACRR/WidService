using System;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RadioStationReports.FormSearchInCisNet;

namespace RadioStationReports
{
    public partial class FormImportFromCisNet : Form
    {
        private enum AutoActionStatus
        {
            Pending,
            Running,
            Completed,
            Error,
        }

        #region ManualActions
        public enum ManualActionType
        {
              ACT_SELECT_PACKAGE
            , ACT_SET_PACKAGE_CODE
            , ACT_SET_DOWLOAD_FOLDER_NAME
            , ACT_DOWNLOAD_PACKAGE
            , ACT_COMPLETED
        }
        public class ManualAction
        {
            public ManualActionType ActionType { get; set; }
            public string Name { get; set; }
            public Label LabelCtrl { get; set; }
            public CheckBox CheckCtrl { get; set; }
            public TextBox ExCtrl { get; set; }
        }

        private List<ManualAction> _manualActions;

        private int _curManualActionIdx;

        #endregion

        #region AutoActions
        public enum AutoActionType
        {
            ACT_COPY_PACKAGE_FILE
            , ACT_IMPORT_PACKAGE_TO_SOCCISNET
            , ACT_IMPORT_WORKS_TO_SMART
            , ACT_APPLY_IMPORTED_WORKS
        }

        public class AutoAction
        {
            public AutoActionType ActionType { get; set; }
            public int Status { get; set; }
            public string Name { get; set; }
            public string Progress { get; set; }
        }
        private List<AutoAction> _autoActions;

        private int _curAutoActionIdx;
        private int _failedAutoActionIdx;
        private string _failedAutoActionErrorText;

        private int _importWorksCnt;
        private int _curImportWorkIdx;

        #endregion

        private bool _ignoreCheckChanged;

        private string _reportFileName;
        private string _reportWorkFilesPath;

        private string _packageFileFulleName;
        private int _packageId;
        private List<string> _packageWorkCodes;

        public FormImportFromCisNet(string reportFileName, string reportWorkFilesPath)
        {
            InitializeComponent();
            _reportFileName = reportFileName;
            _reportWorkFilesPath = reportWorkFilesPath;
        }

        private void FormImportFromCisNet_Load(object sender, EventArgs e)
        {
            Configure();
            UpdateControls();
        }

        private void ConfigureManualActions()
        {
            _manualActions = [
                new ManualAction {
                    ActionType = ManualActionType.ACT_SELECT_PACKAGE,
                    Name = "У додатку CISNet виберіть пакет, який відповідає звіту. Потрібна назва в полі Package Comment мусить бути, як в полі справа.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = new TextBox(),
                },
                new ManualAction {
                    ActionType = ManualActionType.ACT_SET_PACKAGE_CODE,
                    Name = "Введіть код обраного пакету в поле справа.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = new TextBox(),
                },
                new ManualAction {
                    ActionType = ManualActionType.ACT_SET_DOWLOAD_FOLDER_NAME,
                    Name = "Введіть в поле справа повну назву фолдеру завантажень Інтернет провідника, де відкритий додаток CISNet.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = new TextBox(),
                },
                new ManualAction {
                    ActionType = ManualActionType.ACT_DOWNLOAD_PACKAGE,
                    Name = "В додатку CISNet натисніть Download CISML щоб вивантажити файл пакету. У фолдері завантажень буде створений файл з назвою, наведеною справа.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = new TextBox(),
                },
                 new ManualAction {
                    ActionType = ManualActionType.ACT_COMPLETED,
                    Name = "Натисніть ІМПОРТУВАТИ для передачі інформації з вивантаженого файлу в бази даних Товариства.",
                    LabelCtrl = new Label(),
                    CheckCtrl = null,
                    ExCtrl = null,
                },
            ];
        }

        private void FillManualActionControls()
        {
            panelManualActions.SuspendLayout();

            panelManualActions.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            panelManualActions.ColumnCount = 4;
            panelManualActions.ColumnStyles.Clear();
            panelManualActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            panelManualActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panelManualActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            panelManualActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 4));

            panelManualActions.RowCount = _manualActions.Count;
            panelManualActions.RowStyles.Clear();
            for (var idx = 0; idx < _manualActions.Count; idx++)
            {
                var action = _manualActions[idx];

                panelManualActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));
                panelManualActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));
                panelManualActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));
                panelManualActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));

                if (action.CheckCtrl != null)
                {
                    action.CheckCtrl.CheckedChanged += CheckCtrl_CheckedChanged;
                    panelManualActions.Controls.Add(action.CheckCtrl, 0, idx);
                }

                var label = action.LabelCtrl;
                label.Text = action.Name;
                label.Dock = DockStyle.Fill;
                label.AutoSize = true;
                label.Padding = new Padding(5, 5, 5, 5);
                panelManualActions.Controls.Add(label, 1, idx);

                if (action.ExCtrl != null)
                {
                    action.ExCtrl.Dock = DockStyle.Fill;
                    action.ExCtrl.ReadOnly = action.ActionType == ManualActionType.ACT_SELECT_PACKAGE ||
                        action.ActionType == ManualActionType.ACT_DOWNLOAD_PACKAGE;
                    if (action.ActionType == ManualActionType.ACT_SELECT_PACKAGE)
                    {
                        action.ExCtrl.Text = _reportFileName;
                    }
                    if (action.ActionType == ManualActionType.ACT_SET_PACKAGE_CODE)
                    {
                        action.ExCtrl.Text = "";
                    }
                    if (action.ActionType == ManualActionType.ACT_SET_DOWLOAD_FOLDER_NAME)
                    {
                        action.ExCtrl.Text = "";
                    }
                    if (action.ActionType == ManualActionType.ACT_DOWNLOAD_PACKAGE)
                    {
                        action.ExCtrl.Text = "";
                    }
                    panelManualActions.Controls.Add(action.ExCtrl, 2, idx);
                }
            }

            panelManualActions.ResumeLayout();

            _curManualActionIdx = 0;
        }

        private void ConfigureAutoActions()
        {
            _autoActions = [
                new AutoAction {
                    ActionType = AutoActionType.ACT_COPY_PACKAGE_FILE,
                    Status = -1,
                    Name = "Копіювання файлу імпорту в робочий фолдер звіту",
                    Progress = "",
                },
                new AutoAction {
                    ActionType = AutoActionType.ACT_IMPORT_PACKAGE_TO_SOCCISNET,
                    Status = -1,
                    Name = "Створення інформації в БД SocCisNet з файлу імпорту",
                    Progress = "",
                },
                new AutoAction {
                    ActionType = AutoActionType.ACT_IMPORT_WORKS_TO_SMART,
                    Status = -1,
                    Name = "Імпорт творів з БД SocCisNet в БД SMART",
                    Progress = "",
                },
                new AutoAction {
                    ActionType = AutoActionType.ACT_APPLY_IMPORTED_WORKS,
                    Status = -1,
                    Name = "Застосування імпортованих творів до звіту",
                    Progress = "",
                },
             ];
        }

        private void FillAutoActions()
        {
            lvAutoActions.View = View.Details;
            lvAutoActions.FullRowSelect = true;
            lvAutoActions.GridLines = true;
            lvAutoActions.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvAutoActions.MultiSelect = false;
            lvAutoActions.SmallImageList = ilStatuses;

            lvAutoActions.Columns.Add("Дія", 400);
            lvAutoActions.Columns.Add("Виконання", 300);

            _autoActions.ForEach(action =>
            {
                var item = lvAutoActions.Items.Add(action.Name);
                item.SubItems.Add(action.Progress);
                item.ImageIndex = -1;
                item.Tag = action;
            });
        }

        private void Configure()
        {
            ConfigureManualActions();
            FillManualActionControls();

            ConfigureAutoActions();
            FillAutoActions();

        }

        private void UpdateControls()
        {
            for (var idx = 0; idx < _manualActions.Count; idx++)
            {
                var action = _manualActions[idx];
                if (action.CheckCtrl != null)
                {
                    action.CheckCtrl.Enabled = idx == _curManualActionIdx;
                }
                if (idx == _curManualActionIdx)
                {
                    action.LabelCtrl.Font = new Font(DefaultFont, FontStyle.Bold);
                }
                else
                {
                    action.LabelCtrl.Font = new Font(DefaultFont, FontStyle.Regular);
                }
                if (action.ExCtrl != null)
                {
                    action.ExCtrl.Enabled = idx == _curManualActionIdx;
                }
            }

            btnImport.Enabled = _curManualActionIdx == _manualActions.Count - 1;
        }

        private void UpdateAutoActionsStatus()
        {
            for (var idxAction = 0; idxAction < _autoActions.Count; idxAction++)
            {
                var item = lvAutoActions.Items[idxAction];
                var action = item.Tag as AutoAction;
                if (idxAction == _curAutoActionIdx)
                {
                    item.ImageIndex = _failedAutoActionIdx == _curAutoActionIdx ?
                        (int)AutoActionStatus.Error : (int)AutoActionStatus.Running;
                    if (idxAction == (int)AutoActionType.ACT_IMPORT_WORKS_TO_SMART)
                    {
                        item.SubItems[1].Text =
                            _failedAutoActionIdx == _curAutoActionIdx ?
                                _failedAutoActionErrorText :
                                _curImportWorkIdx == -1 ?
                                    "Виконується ..." :
                                    $"Імпортовано {_curImportWorkIdx} з {_importWorksCnt} творів";
                    }
                    else
                    {
                        item.SubItems[1].Text = _failedAutoActionIdx == _curAutoActionIdx ?
                             _failedAutoActionErrorText : "Виконується ...";
                    }
                }
                else
                {
                    if (idxAction < _curAutoActionIdx)
                    {
                        item.ImageIndex = (int)AutoActionStatus.Completed;
                        item.SubItems[1].Text = idxAction == (int)AutoActionType.ACT_IMPORT_WORKS_TO_SMART ?
                            $"Імпортовано {_curImportWorkIdx} з {_importWorksCnt} творів" :
                            "Завершено";
                    }
                    else
                    {
                        item.ImageIndex = -1;
                        item.SubItems[1].Text = "";
                    }
                }
            }
        }

        private void CopyPackageFile()
        {
            var sourcePackageFilePath = _manualActions[(int)ManualActionType.ACT_SET_DOWLOAD_FOLDER_NAME].ExCtrl.Text;
            var sourcePackageFileName = _manualActions[(int)ManualActionType.ACT_DOWNLOAD_PACKAGE].ExCtrl.Text;
            var targetPackageFilePath = _reportWorkFilesPath;
            var targetPackageFileName = sourcePackageFileName;
            var sourcePackageFileFulleName = Path.Combine(sourcePackageFilePath, sourcePackageFileName);
            var targetPackageFileFulleName = Path.Combine(targetPackageFilePath, targetPackageFileName);

            Directory.CreateDirectory(targetPackageFilePath);

            File.Copy(sourcePackageFileFulleName, targetPackageFileFulleName, true);

            _packageFileFulleName = targetPackageFileFulleName;
        }
        private void ImportPackageToSocCisNet()
        {
            var workImporter = new CisNetPackageImporter();
            workImporter.ImportWorks(_packageFileFulleName);
        }
        private void ImportWorkToSmart()
        {
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MediaService..spImportWorkFromCisNet";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@workCode", _packageWorkCodes[_curImportWorkIdx]);
                cmd.Parameters.AddWithValue("@showTrace", false);
                cmd.Parameters.AddWithValue("@objId", 0);
                cmd.ExecuteNonQuery();
            });
        }

        private void ApplyImportedWorks()
        {
            Helpers.RunSqlT(cmd =>
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spUpdateWorksFromCisNet";
                cmd.ExecuteNonQuery();
            });
        }

        private void CheckCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreCheckChanged)
            {
                return;
            }

            var action = _manualActions[_curManualActionIdx];
            switch (_curManualActionIdx)
            {
                case (int)ManualActionType.ACT_SET_PACKAGE_CODE:
                    {
                        var packageCode = action.ExCtrl.Text;
                        var packageCodeInt = 0;
                        if (!int.TryParse(packageCode, out packageCodeInt))
                        {
                            MessageBox.Show("Невірний формат коду пакету", "Передача творів з CISNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _ignoreCheckChanged = true;
                            action.CheckCtrl.Checked = false;
                            _ignoreCheckChanged = false;
                            return;
                        }

                        var packageId = _manualActions[(int)ManualActionType.ACT_SET_PACKAGE_CODE].ExCtrl.Text;
                        _manualActions[(int)ManualActionType.ACT_DOWNLOAD_PACKAGE].ExCtrl.Text = $"WRK_{packageId}_140_WINDOWS.xml";
                        _curManualActionIdx++;
                        UpdateControls();
                    }
                    break;
                case (int)ManualActionType.ACT_SET_DOWLOAD_FOLDER_NAME:
                    {
                        var folderName = action.ExCtrl.Text;
                        if (!Directory.Exists(folderName))
                        {
                            MessageBox.Show("Невірний фолдер", "Передача творів з CISNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _ignoreCheckChanged = true;
                            action.CheckCtrl.Checked = false;
                            _ignoreCheckChanged = false;
                            return;
                        }
                        _curManualActionIdx++;
                        UpdateControls();
                    }
                    break;
                case (int)ManualActionType.ACT_DOWNLOAD_PACKAGE:
                    {
                        var folderName = _manualActions[(int)ManualActionType.ACT_SET_DOWLOAD_FOLDER_NAME].ExCtrl.Text;
                        var fileName = _manualActions[(int)ManualActionType.ACT_DOWNLOAD_PACKAGE].ExCtrl.Text;
                        var fileFullName = Path.Combine(folderName, fileName);
                        if (!File.Exists(fileFullName))
                        {
                            MessageBox.Show($"Не знайдено завантажений файл {fileFullName}", "Передача творів з CISNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _ignoreCheckChanged = true;
                            action.CheckCtrl.Checked = false;
                            _ignoreCheckChanged = false;
                            return;
                        }
                        _curManualActionIdx++;
                        UpdateControls();
                    }
                    break;
                default:
                    _curManualActionIdx++;
                    UpdateControls();
                    break;
            }


        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            _curAutoActionIdx = (int)AutoActionType.ACT_COPY_PACKAGE_FILE;
            _failedAutoActionIdx = -1;
            _importWorksCnt = -1;
            _curImportWorkIdx = -1;

            _packageId = int.Parse(_manualActions[(int)ManualActionType.ACT_SET_PACKAGE_CODE].ExCtrl.Text);

            btnClose.Enabled = false;
            UpdateAutoActionsStatus();
            timerRunAutoAction.Enabled = true;
        }

        private void timerRunAutoAction_Tick(object sender, EventArgs e)
        {
            try
            {
                timerRunAutoAction.Enabled = false;
                Cursor = Cursors.WaitCursor;

                switch ((AutoActionType)_curAutoActionIdx)
                {
                    case AutoActionType.ACT_COPY_PACKAGE_FILE:
                        CopyPackageFile();
                        timerRunAutoAction.Enabled = true;
                        _curAutoActionIdx++;
                        break;
                    case AutoActionType.ACT_IMPORT_PACKAGE_TO_SOCCISNET:
                        ImportPackageToSocCisNet();
                        timerRunAutoAction.Enabled = true;
                        _curAutoActionIdx++;
                        break;
                    case AutoActionType.ACT_IMPORT_WORKS_TO_SMART:
                        if (_importWorksCnt == -1)
                        {
                            Helpers.RunSql(cmd =>
                            {
                                cmd.CommandText = @"
                                    select t2.WorkCode as CisNetWorkCode
                                    from SocCisNet..Packages t1
	                                    join SocCisNet..PackageWorks t2 on t1.PackageId = t2.PackageId
                                    where t1.PackageId = @packageId
                                ";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@packageId", _packageId);
                                using (var r = cmd.ExecuteReader())
                                {
                                    _packageWorkCodes = new List<string>();
                                    while(r.Read())
                                    {
                                        _packageWorkCodes.Add(r.GetString(0));
                                    }
                                }

                                _importWorksCnt = _packageWorkCodes.Count;
                            });
                            
                            _curImportWorkIdx = 0;
                        }
                        if (_curImportWorkIdx < _importWorksCnt)
                        {
                            ImportWorkToSmart();
                            _curImportWorkIdx++;
                            timerRunAutoAction.Enabled = true;
                        }
                        else
                        {
                            _curAutoActionIdx++;
                            timerRunAutoAction.Enabled = true;
                        }
                        break;
                    case AutoActionType.ACT_APPLY_IMPORTED_WORKS:
                        ApplyImportedWorks();
                        _curAutoActionIdx++;
                        btnClose.Enabled = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Передача творів з CISNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _failedAutoActionIdx = _curAutoActionIdx;
                _failedAutoActionErrorText = ex.Message;
                btnClose.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
                UpdateAutoActionsStatus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
