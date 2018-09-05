using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.RightholderControls
{
    public partial class RightholderListControl : UserControl,
        ISubscriber<RightholderUpdatedEvent>
    {
        private RightholderService _rightholderService;
        private AgreementStatuses[] _allowedStatuses;

        protected bool IsDesignMode
        {
            get { return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        private RightholderMainView _rightholder;
        public RightholderMainView SelectedRightholder
        {
            get
            {
                if (gvRightholdersList.CurrentRow == null)
                    return null;

                return gvRightholdersList.CurrentRow.DataBoundItem as RightholderMainView;
            }
            set
            {
                if (_rightholder != value)
                {
                    _rightholder = value;

                    if (_rightholder != null)
                    {
                        var row = gvRightholdersList.Rows.FirstOrDefault(r => (int)r.Cells["CustId"].Value == _rightholder.CustId);
                        if (row != null)
                        {
                            gvRightholdersList.CurrentRow = row;
                            gvRightholdersList.TableElement.ScrollToRow(row);
                        }
                    }
                }
            }
        }

        private bool _showCommandColumns = true;
        public bool ShowCommandColumns
        {
            get { return _showCommandColumns; }
            set
            {
                if (_showCommandColumns != value)
                {
                    _showCommandColumns = value;

                    gvRightholdersList.Columns["EditColumn"].IsVisible = _showCommandColumns;
                }
            }
        }

        public string SearchText
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        public event EventHandler<RightholderMainView> RightholderSelected;
        public event EventHandler<RightholderMainView> EditCommandExecuted;

        public RightholderListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                gvRightholdersList.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);

                ApplicationController.Instance.EventAggregator.SubsribeEvent(this);
                _rightholderService = new RightholderService();

                var statusNode = new RadTreeNode { Text = "Статус" };

                tvFilters.Nodes.Add(statusNode);
                tvFilters.ExpandAll();
            }
        }

        private void RightholderListControl_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode)
            {
                PopulateFiltersValues();

                // set default status filter as Active, this also cause update list, beacouse of tvFilters_SelectedNodeChanged is handled
                tvFilters.Nodes[0].Nodes.First(n => (RightholderStates)n.Value == RightholderStates.Active).Selected = true;
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            ApplicationController.Instance.EventAggregator.UnsubscribeEvent(this);

            base.Dispose(disposing);
        }

        public void SetAllowedStatuses(AgreementStatuses[] states)
        {
            _allowedStatuses = states;

            PopulateFiltersValues();
        }

        public void ResetAllowedStatuses()
        {
            _allowedStatuses = null;

            PopulateFiltersValues();
        }

        public void UpdateList()
        {
            UpdateList(SelectedRightholder);
        }

        public async void UpdateList(RightholderMainView currentRightholder)
        {
            waitingBar.StartWaiting();

            var query = CreateRightholderQuery();

            var list = await _rightholderService.GetRightholdersAsync(query);

            rightholderMainViewBindingSource.DataSource = list;
            
            //SelectedRightholder = currentRightholder; // TODO: is it needed?

            waitingBar.StopWaiting();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void gvRightholdersList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                OnEditCommandExecuted(SelectedRightholder);
            }
        }

        private void gvRightholdersList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnRightholderSelected(SelectedRightholder);
        }

        private void gvRightholdersList_ToolTipTextNeeded(object sender, Telerik.WinControls.ToolTipTextNeededEventArgs e)
        {
            Utilities.GridViewHelper.SetTooltipText(sender, e);
        }

        private void tvFilters_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            UpdateList();
        }

        private void tvFilters_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
        {
            if (e.Node.Nodes.Any())
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

        private void tvFilters_SelectedNodeChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Any())
            {
                // prevent selecting parent nodes
                e.Cancel = true;
            }
        }

        private void OnRightholderSelected(RightholderMainView selectedRightholder)
        {
            RightholderSelected?.Invoke(this, selectedRightholder);
        }

        private void OnEditCommandExecuted(RightholderMainView selectedRightholder)
        {
            using (var rightholderView = new RightholderView())
            {
                var rightholderPresenter = new RightholderPresenter(rightholderView);
                rightholderPresenter.Show(selectedRightholder.CustId);
            }

            EditCommandExecuted?.Invoke(this, selectedRightholder);
        }

        private void PopulateFiltersValues()
        {
            var filters = new List<RadTreeNode> {
                new RadTreeNode { Value = -1,                            Text = "Всі" },
                new RadTreeNode { Value = AgreementStatuses.NotAccepted, Text = "Не підтверджені" },
                new RadTreeNode { Value = AgreementStatuses.OnAcception, Text = "На акцепті" },
                new RadTreeNode { Value = AgreementStatuses.Active,      Text = "Активний" },
                new RadTreeNode { Value = AgreementStatuses.Closed,      Text = "Закритий" },
                new RadTreeNode { Value = AgreementStatuses.Inheritance, Text = "Оформлення спадщини" },
                new RadTreeNode { Value = AgreementStatuses.Blocked,     Text = "Заблокований" },
            };

            if (_allowedStatuses != null)
            {
                filters = filters.Where(node => _allowedStatuses.Contains((AgreementStatuses)node.Value)).ToList();
            }

            tvFilters.Nodes[0].Nodes.Clear();
            tvFilters.Nodes[0].Nodes.AddRange(filters);
        }

        private RightholderListQuery CreateRightholderQuery()
        {
            var query = new RightholderListQuery();

            var agreementStatus = (AgreementStatuses)tvFilters.Nodes[0].Nodes.First(n => n.Selected).Value;

            if ((int)agreementStatus != -1)
            {
                query.AgreementStatus = agreementStatus;
            }

            return query;
        }

        public void HandleEvent(RightholderUpdatedEvent e)
        {
            UpdateList();
        }

        #region Search rightolder

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvRightholdersList.MasterTemplate.Refresh();
        }

        private void gvRightholdersList_CustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvRightholdersList.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRightholdersList.EndUpdate(false);
                return;
            }

            gvRightholdersList.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvRightholdersList.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvRightholdersList.EndUpdate(false);
            }
        }

        #endregion
    }
}
