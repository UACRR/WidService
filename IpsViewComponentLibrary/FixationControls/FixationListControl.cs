using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.ViewModels.Fixations;

namespace IpsViewComponentLibrary.FixationControls
{
    public partial class FixationListControl : UserControl
    {
        private FixationListPresenter _presenter;

        public FixationListControl()
        {
            InitializeComponent();

            _presenter = new FixationListPresenter(this);
        }

        private void FixationListControl_Load(object sender, EventArgs e)
        {
            PopulateFiltersValues();

            _presenter.Load();
        }

        private void PopulateFiltersValues()
        {
            var filters = new List<RadTreeNode> {
                new RadTreeNode { Text = "Нове", Value = new FixationQuery { Stage = FixationStages.New }},
                new RadTreeNode { Text = "Узгодження до фікації", Value = new FixationQuery { Stage = FixationStages.NegotiationBeforeFixation }, Nodes = {
                    new RadTreeNode { Text = "Для узгодження", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationBeforeFixationOnNegotioation } },
                    new RadTreeNode { Text = "Направлене користувачу", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationBeforeFixationDirectedToConsumer } },
                    new RadTreeNode { Text = "Відмова", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationBeforeFixationRejected } },
                }},
                new RadTreeNode { Text = "На фіксації", Value = new FixationQuery { Stage = FixationStages.Fixation }, Nodes = {
                    new RadTreeNode { Text = "Не заплановане", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationNotScheduled } },
                    new RadTreeNode { Text = "Заплановане", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationScheduled } },
                    new RadTreeNode { Text = "Фіксація", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationFixation } },
                    new RadTreeNode { Text = "Зафіксоване", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationFixationCompleted } },
                }},
                new RadTreeNode { Text = "Ідентифікація правовласників", Value = new FixationQuery { Stage = FixationStages.RightholderIdentification }, Nodes = {
                    new RadTreeNode { Text = "На ідентифікації", Value = new FixationQuery { StageStatus = FixationStageStatuses.RightholderIdentificationOnIdentification } },
                    new RadTreeNode { Text = "На доопрацюванні", Value = new FixationQuery { StageStatus = FixationStageStatuses.RightholderIdentificationOnCorrection } },
                }},
                new RadTreeNode { Text = "Узгодження після фікації", Value = new FixationQuery { Stage = FixationStages.NegotiationAfterFixation}, Nodes = {
                    new RadTreeNode { Text = "Для узгодження", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationAfterFixationOnNegotioation } },
                    new RadTreeNode { Text = "Направлене користувачу", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationAfterFixationDirectedToConsumer } },
                    new RadTreeNode { Text = "Відмова", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationAfterFixationRejected } },
                }},
                new RadTreeNode { Text = "Судова робота", Value = new FixationQuery { Stage = FixationStages.JudicalWork }, Nodes = {
                    new RadTreeNode { Text = "В судовій роботі", Value = new FixationQuery {StageStatus = FixationStageStatuses.JudicalWorkOnJudicalWork } },
                    new RadTreeNode { Text = "На доопрацюванні", Value = new FixationQuery {StageStatus = FixationStageStatuses.JudicalWorkOnCorrection } },
                    new RadTreeNode { Text = "Вигране", Value = new FixationQuery { StageStatus = FixationStageStatuses.JudicalWorkWinned } },
                }},
                new RadTreeNode { Text = "Моніторинг надходження", Value = new FixationQuery { Stage = FixationStages.IncomeMonitoring }},
                new RadTreeNode { Text = "Закрите", Value = new FixationQuery { Stage = FixationStages.Closed }, Nodes = {
                    new RadTreeNode { Text = "Порушення відсутнє", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedWithoutViolation } },
                    new RadTreeNode { Text = "Погоджене до фіксації", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedAgreedBeforeFixation } },
                    new RadTreeNode { Text = "Погоджене після фіксації", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedAgreedAfterFixation } },
                    new RadTreeNode { Text = "По суду", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedByCourt } },
                    new RadTreeNode { Text = "Кошти надійшли", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedIncomeRecieved } },
                }},
            };

            var rootNode = new RadTreeNode { Text = "Етап / Статус етапу" };
            rootNode.Nodes.AddRange(filters);

            tvFilters.Nodes.Add(rootNode);
            tvFilters.ExpandAll();
        }

        private void tvFilters_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                // set font to bold for parent nodes
                e.NodeElement.Font = new Font(this.Font, FontStyle.Bold);

                if (e.NodeElement.IsMouseOver)
                {
                    // prevent hover highligting parent nodes
                    e.NodeElement.BackColor = Color.White;
                    e.NodeElement.BorderColor = Color.White;
                }
            }
            else if (e.Node.Level == 1)
            {
                // set font to bold for parent nodes
                e.NodeElement.Font = new Font(this.Font, FontStyle.Bold);
            }
            else
            {
                // blue highlight (instead of gray) selected node even if tree veiw is inactive
                bool isInactive = (bool)e.NodeElement.GetValue(TreeNodeElement.IsControlInactiveProperty);
                if (isInactive && e.NodeElement.IsSelected)
                {
                    e.NodeElement.BackColor = Color.FromArgb(255, 146, 192, 224);
                    e.NodeElement.BorderColor = Color.FromArgb(255, 146, 192, 224);
                }
                else
                {
                    e.NodeElement.ResetValue(LightVisualElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                    e.NodeElement.ResetValue(LightVisualElement.BorderColorProperty, Telerik.WinControls.ValueResetFlags.Local);
                }
            }
        }
    }
}
