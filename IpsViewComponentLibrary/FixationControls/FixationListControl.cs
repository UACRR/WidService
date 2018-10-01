using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ipsFormsDesign.ViewModels.Fixations;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using IpsViewComponentLibrary.AppController;
using ipsFormsDesign.Utilities;
using IpsViewComponentLibrary.Common;

namespace IpsViewComponentLibrary.FixationControls
{
    public partial class FixationListControl : UserControl, ISubscriber<FixationUpdatedEvent>
    {
        private FixationListPresenter _presenter;

        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object FixationDataSource
        {
            get { return bsFixationListViewModel.DataSource; }
            set
            {
                if (bsFixationListViewModel.DataSource != value)
                    bsFixationListViewModel.DataSource = value;
            }
        }

        public FixationQuery FixationQuery
        {
            get
            {
                return (FixationQuery)sideMenu.SelectedMenuItem.Value;
            }
        }

        private FixationListViewModel _selectedFixation;
        public FixationListViewModel SelectedFixation
        {
            get
            {
                if (gvFixationsList.CurrentRow == null)
                    return null;

                return gvFixationsList.CurrentRow.DataBoundItem as FixationListViewModel;
            }
            set
            {
                if (_selectedFixation != value)
                {
                    _selectedFixation = value;

                    if (_selectedFixation != null)
                    {
                        var row = gvFixationsList.Rows.FirstOrDefault(r => (int)r.Cells["FixId"].Value == _selectedFixation.FixId);
                        if (row != null)
                        {
                            gvFixationsList.CurrentRow = row;
                            gvFixationsList.TableElement.ScrollToRow(row);
                        }
                    }
                }
            }
        }

        public FixationListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

                _presenter = new FixationListPresenter(this);
            }
        }

        private void FixationListControl_Load(object sender, EventArgs e)
        {
            gvFixationsList.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);
            gvFixationsList.SetCommandColumnImageAlignment("SetStatusColumn", ContentAlignment.MiddleCenter);

            if (!IsDesignMode)
            {
                gvFixationsList.SetComboboxColumnDataSource("UsesType", IpsGlobal.AnketaDictionaties.usesType);

                PopulateMenuItems();

                UpdateList();
            }
        }

        private void sideMenu_SelectedMenuItemChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void gvFixationsList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            IpsViewComponentLibrary.Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void gvFixationsList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                OnEditCommandExecuted();
            }
            else if (currentColumnName == "SetStatusColumn")
            {
                ShowChangeStatusMenu();
            }
        }

        private void gvFixationsList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnEditCommandExecuted();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _presenter.Add();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        protected virtual void OnEditCommandExecuted()
        {
            _presenter.Edit();
        }

        private void UpdateList()
        {
            waitingBar.StartWaiting();
            _presenter.UpdateList();
            waitingBar.StopWaiting();
        }

        private void PopulateMenuItems()
        {
            sideMenu.Items.Clear();

            var rootItem = new SideMenuItem { Text = "Етап / Статус етапу", IsSelectable = false, Items = {
                new SideMenuItem { Text = "Нове", Value = new FixationQuery { Stage = FixationStages.New }, Selected = true },
                new SideMenuItem { Text = "Узгодження до фікації", Value = new FixationQuery { Stage = FixationStages.NegotiationBeforeFixation }, Items = {
                    new SideMenuItem { Text = "Для узгодження", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationBeforeFixationOnNegotioation } },
                    new SideMenuItem { Text = "Направлене користувачу", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationBeforeFixationDirectedToConsumer } },
                    new SideMenuItem { Text = "Відмова", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationBeforeFixationRejected } },
                }},
                new SideMenuItem { Text = "На фіксації", Value = new FixationQuery { Stage = FixationStages.Fixation }, Items = {
                    new SideMenuItem { Text = "Не заплановане", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationNotScheduled } },
                    new SideMenuItem { Text = "Заплановане", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationScheduled } },
                    new SideMenuItem { Text = "Фіксація", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationFixation } },
                    new SideMenuItem { Text = "Зафіксоване", Value = new FixationQuery { StageStatus = FixationStageStatuses.FixationFixationCompleted } },
                }},
                new SideMenuItem { Text = "Ідентифікація правовласників", Value = new FixationQuery { Stage = FixationStages.RightholderIdentification }, Items = {
                    new SideMenuItem { Text = "На ідентифікації", Value = new FixationQuery { StageStatus = FixationStageStatuses.RightholderIdentificationOnIdentification } },
                    new SideMenuItem { Text = "На доопрацюванні", Value = new FixationQuery { StageStatus = FixationStageStatuses.RightholderIdentificationOnCorrection } },
                }},
                new SideMenuItem { Text = "Узгодження після фікації", Value = new FixationQuery { Stage = FixationStages.NegotiationAfterFixation}, Items = {
                    new SideMenuItem { Text = "Для узгодження", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationAfterFixationOnNegotioation } },
                    new SideMenuItem { Text = "Направлене користувачу", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationAfterFixationDirectedToConsumer } },
                    new SideMenuItem { Text = "Відмова", Value = new FixationQuery {StageStatus = FixationStageStatuses.NegotiationAfterFixationRejected } },
                }},
                new SideMenuItem { Text = "Судова робота", Value = new FixationQuery { Stage = FixationStages.JudicalWork }, Items = {
                    new SideMenuItem { Text = "В судовій роботі", Value = new FixationQuery {StageStatus = FixationStageStatuses.JudicalWorkOnJudicalWork } },
                    new SideMenuItem { Text = "На доопрацюванні", Value = new FixationQuery {StageStatus = FixationStageStatuses.JudicalWorkOnCorrection } },
                    new SideMenuItem { Text = "Вигране", Value = new FixationQuery { StageStatus = FixationStageStatuses.JudicalWorkWinned } },
                }},
                new SideMenuItem { Text = "Моніторинг надходження", Value = new FixationQuery { Stage = FixationStages.IncomeMonitoring }},
                new SideMenuItem { Text = "Закрите", Value = new FixationQuery { Stage = FixationStages.Closed }, Items = {
                    new SideMenuItem { Text = "Порушення відсутнє", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedWithoutViolation } },
                    new SideMenuItem { Text = "Погоджене до фіксації", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedAgreedBeforeFixation } },
                    new SideMenuItem { Text = "Погоджене після фіксації", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedAgreedAfterFixation } },
                    new SideMenuItem { Text = "По суду", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedByCourt } },
                    new SideMenuItem { Text = "Кошти надійшли", Value = new FixationQuery { StageStatus = FixationStageStatuses.ClosedIncomeRecieved } },
                }},
            }};

            sideMenu.Items.Add(rootItem);
        }

        private void ShowChangeStatusMenu()
        {
            var fixation = SelectedFixation;

            if (fixation == null)
                return;

            var menu = FixationStageStatusMenuFactory.Create(fixation.GetAvailableStageStatuses(), FixationStatusMenu_Click);

            if (!menu.Items.Any())
                return;

            Point absolutePosition = gvFixationsList.CurrentCell.PointToScreen(gvFixationsList.CurrentCell.Location);
            absolutePosition.Y += gvFixationsList.CurrentCell.Size.Height;

            menu.Show(absolutePosition);
            menu.SizeChanged += (s, e) =>
            {
                // set position of menu after size changed, because before menu is showed his width = 0
                menu.Left = absolutePosition.X - menu.Width + gvFixationsList.CurrentCell.Size.Width;
            };
        }

        private void FixationStatusMenu_Click(object sender, EventArgs e)
        {
            if (sender is RadMenuItem menuItem)
            {
                var newStatus = (FixationStageStatuses)menuItem.Tag;

                _presenter.SetStatus(newStatus);
            }
        }

        public void HandleEvent(FixationUpdatedEvent e)
        {
            UpdateList();
        }
    }
}
