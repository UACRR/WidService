using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Services;
using ipsFormsDesign.Dictionary;
using Telerik.WinControls.UI;
using ipsFormsDesign.EventAggregator;
using ipsFormsDesign.Events;
using IpsViewComponentLibrary.AppController;
using IpsViewComponentLibrary.Utilities;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.ObjectRightControls
{
    public partial class ObjectRightListControl : UserControl, ISubscriber<ObjectRightUpdatedEvent>
    {
        private readonly ObjectRightService _objectRightService;
        bool searchRunnable = false;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        private ObjectRightMainView _objectRight;

        public ObjectRightMainView SelectedObject
        {
            get => gvObjectsRightsList.CurrentRow?.DataBoundItem as ObjectRightMainView;
            set
            {
                if (_objectRight != value)
                {
                    _objectRight = value;

                    var row = gvObjectsRightsList.Rows.FirstOrDefault(r => (int)r.Cells["ObjId"].Value == _objectRight.ObjId);
                    if (row != null)
                    {
                        gvObjectsRightsList.CurrentRow = row;
                    }
                }
            }
        }

        public event EventHandler<ObjectRightMainView> ObjectSelected = delegate { };
        public event EventHandler<ObjectRightMainView> EditCommandExecuted = delegate { };

        public ObjectRightListControl()
        {
            InitializeComponent();

            if (!IsDesignMode)
            {
                gvObjectsRightsList.SetCommandColumnImageAlignment("EditColumn", ContentAlignment.MiddleCenter);

                _objectRightService = ObjectRightService.GetInstance();

                var stateNode = new RadTreeNode { Text = "Стан" };

                tvFilters.Nodes.Add(stateNode);
                tvFilters.ExpandAll();
            }
        }

        private void ObjectRightListControl_Load(object sender, EventArgs e)
        {
            if (!IsDesignMode)
            {
                ApplicationController.Instance.EventAggregator.SubsribeEvent(this);

                PopulateFiltersValues();

                // set default state filter as All, this also cause update list, beacouse of tvFilters_SelectedNodeChanged is handled
                tvFilters.Nodes[0].Nodes[0].Selected = true;
            }
        }

        public void UpdateList()
        {
            UpdateList(SelectedObject);
        }

        public async void UpdateList(ObjectRightMainView currentObject)
        {
            waitingBar.StartWaiting();

            var query = new ObjectRightQuery();

            query.Page = navigatorPanel.CurrentPage;
            query.PageSize = navigatorPanel.PageSize;

            if ((int)tvFilters.Nodes[0].Nodes.First(n => n.Selected).Value != -1)
                query.State = (ObjectRightStates)tvFilters.Nodes[0].Nodes.First(n => n.Selected).Value;
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                query.SearchText = txtSearch.Text;

            var result = await _objectRightService.GetObjectRightsAsync(query);
            bsObjectRightMainView.DataSource = result.List;

            navigatorPanel.TotalPages = (int) Math.Ceiling((double)result.TotalItems / (int)query.PageSize);
            //show count RightList into grid
            ctrlGridRowCount.TotalItems = result.TotalItems;

            waitingBar.StopWaiting();
            searchRunnable = false;
        }

        private void gvObjectsRightsList_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column is GridViewCommandColumn)
                return;

            OnObjectSelected(SelectedObject);
        }

        private void gvObjectsRightsList_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var currentColumnName = e.Column.Name;

            if (currentColumnName == "EditColumn")
            {
                OnEditCommandExecuted(SelectedObject);
            }
        }

        private void btnUpdateList_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void navigatorPanel_CurrentPageChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void navigatorPanel_PageSizeChanged(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void tvFilters_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            navigatorPanel.CurrentPage = 1;
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

        protected virtual void OnObjectSelected(ObjectRightMainView selectedObject)
        {
            ObjectSelected(this, selectedObject);
        }

        protected virtual void OnEditCommandExecuted(ObjectRightMainView selectedObject)
        {
            EditCommandExecuted(this, selectedObject);
        }

        private void PopulateFiltersValues()
        {
            var states = new[] {
                new { CodeI = -1, Name = "Всі" },
                new { CodeI = 0, Name = "Не підтверджені" },
                new { CodeI = 1, Name = "Не прив'язані" },
                new { CodeI = 2, Name = "Не розподілені" },
            };

            var statesValueNodes = states.Select(s => new RadTreeNode { Text = s.Name, Value = s.CodeI }).ToArray();
            tvFilters.Nodes[0].Nodes.Clear();
            tvFilters.Nodes[0].Nodes.AddRange(statesValueNodes);
        }

        public void HandleEvent(ObjectRightUpdatedEvent e)
        {
            UpdateList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchRunnable = true;
            navigatorPanel.CurrentPage = 1;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (searchRunnable)
                return;

            if (e.KeyChar == (char)Keys.Enter)
            {
                searchRunnable = true;
                navigatorPanel.CurrentPage = 1;
            }
        }
    }
}
