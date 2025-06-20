using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public partial class FormSearchInCisNet : Form
    {
        public enum ActionType
        {
              ACT_SEARCH_WORK
            , ACT_CHECK_EXISTS_IN_WID
            , ACT_SELECT_PACKAGE
            , ACT_SET_WORK_CODE
            , ACT_ADD_WORK_TO_PACKAGE
            , ACT_COMPLETED
        }
        public class Action
        {
            public ActionType ActionType { get; set; }
            public string Name { get; set; }
            public Label LabelCtrl { get; set; }
            public CheckBox CheckCtrl { get; set; }
            public TextBox ExCtrl { get; set; }
        }

        private List<Action> _actions;
        private int _curActionIdx;
        private bool _ignoreCheckChanged;

        private string _reportFileName;

        public string CisNetWorkCode;

        public FormSearchInCisNet(string reportFileName)
        {
            InitializeComponent();
            _reportFileName = reportFileName;
        }

        private void FormSearchInCisNet_Load(object sender, EventArgs e)
        {
            Configure();
            UpdateControls();
        }

        private void ConfigureActions()
        {
            _actions = new List<Action> {
                new Action {
                    ActionType = ActionType.ACT_SEARCH_WORK,
                    Name = "Виконайте пошук твору в CISNet.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = null,
                },
                new Action {
                    ActionType = ActionType.ACT_CHECK_EXISTS_IN_WID,
                    Name = "Переконайтесь, що обраний твір НЕ міститься в БД WidCentral. Якщо ТАК, натисніть ЕКСПОРТУВАТИ.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = null,
                },
                new Action {
                    ActionType = ActionType.ACT_SELECT_PACKAGE,
                    Name = "На сторінці експорту виберіть Package із назвою, зазначеною в колонці справа. Якщо такого пакета немає, створіть його.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = new TextBox(),
                },
                new Action {
                    ActionType = ActionType.ACT_SET_WORK_CODE,
                    Name = "Вставте код твору із CISNet (поле Work Code) в поле справа.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = new TextBox(),
                },
                new Action {
                    ActionType = ActionType.ACT_ADD_WORK_TO_PACKAGE,
                    Name = "Дадайте твір до пакету.",
                    LabelCtrl = new Label(),
                    CheckCtrl = new CheckBox(),
                    ExCtrl = null,
                },
                new Action {
                    ActionType = ActionType.ACT_COMPLETED,
                    Name = "Натисніть ЗАСТОСУВАТИ на цій формі. Результат буде утворений після ІМПОРТУ пакету із CISNet в СМАРТ.",
                    LabelCtrl = new Label(),
                    CheckCtrl = null,
                    ExCtrl = null,
                },
            };
        }

        private void Configure()
        {
            ConfigureActions();

            panelActions.SuspendLayout();

            panelActions.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            panelActions.ColumnCount = 4;
            panelActions.ColumnStyles.Clear();
            panelActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20));
            panelActions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            panelActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200));
            panelActions.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 4));

            panelActions.RowCount = _actions.Count;
            panelActions.RowStyles.Clear();
            for (var idx = 0; idx < _actions.Count; idx++)
            {
                var action = _actions[idx];

                panelActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));
                panelActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));
                panelActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));
                panelActions.RowStyles.Add(new RowStyle(SizeType.AutoSize, 29));

                if (action.CheckCtrl != null)
                {
                    action.CheckCtrl.CheckedChanged += CheckCtrl_CheckedChanged;
                    panelActions.Controls.Add(action.CheckCtrl, 0, idx);
                }

                var label = action.LabelCtrl;
                label.Text = action.Name;
                label.Dock = DockStyle.Fill;
                label.AutoSize = true;
                label.Padding = new Padding(5, 5, 5, 5);
                panelActions.Controls.Add(label, 1, idx);

                if (action.ExCtrl != null)
                {
                    action.ExCtrl.Dock = DockStyle.Fill;
                    action.ExCtrl.ReadOnly = action.ActionType == ActionType.ACT_SELECT_PACKAGE;
                    if(action.ActionType == ActionType.ACT_SELECT_PACKAGE)
                    {
                        action.ExCtrl.Text = _reportFileName;
                    }
                    panelActions.Controls.Add(action.ExCtrl, 2, idx);
                }
            }

            panelActions.ResumeLayout();

            _curActionIdx = 0;
        }

        private void UpdateControls()
        {
            for (var idx = 0; idx < _actions.Count; idx++)
            {
                var action = _actions[idx];
                if (action.CheckCtrl != null)
                {
                    action.CheckCtrl.Enabled = idx == _curActionIdx;
                }
                if (idx == _curActionIdx)
                {
                    action.LabelCtrl.Font = new Font(DefaultFont, FontStyle.Bold);
                }
                else
                {
                    action.LabelCtrl.Font = new Font(DefaultFont, FontStyle.Regular);
                }
                if (action.ExCtrl != null)
                {
                    action.ExCtrl.Enabled = idx == _curActionIdx;
                }
            }

            btnApply.Enabled = _curActionIdx == _actions.Count - 1;
        }

        private void CheckCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreCheckChanged)
            {
                return;
            }

            var action = _actions[_curActionIdx];
            switch(_curActionIdx)
            {
                case (int)ActionType.ACT_SET_WORK_CODE:
                    {
                        if(string.IsNullOrEmpty(action.ExCtrl.Text))
                        {
                            MessageBox.Show("Невірнимй формат коду твору", "Передача творів з CISNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            _ignoreCheckChanged = true;
                            action.CheckCtrl.Checked = false;
                            _ignoreCheckChanged = false;
                            return;
                        }

                        CisNetWorkCode = action.ExCtrl.Text.Trim();
                        var isRegistered = false;
                        Helpers.RunSql(cmd =>
                        {
                            cmd.CommandText = @"
                                select null
                                from Works
                                where CisNetWorkCode = @cisNetWorkCode
                            ";
                            cmd.Parameters.AddWithValue("@cisNetWorkCode", CisNetWorkCode);
                            using(var r = cmd.ExecuteReader())
                            {
                                isRegistered = r.HasRows;
                            }
                        });

                        if(isRegistered)
                        {
                            MessageBox.Show("Твір вже переданий в СМАРТ, наступнай крок слід ПРОПУСТИТИ", "Передача творів з CISNet",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _curActionIdx += 2;
                        }
                        else
                        {
                            _curActionIdx++;
                        }
                                           
                        UpdateControls();                
                    }
                break;
                default:
                      _curActionIdx++;                   
                    UpdateControls();                
                  break;
            }

 
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(DialogResult.No == MessageBox.Show("Закрити форму?", "Передача творів в СМАРТ", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                return;
            }

            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
