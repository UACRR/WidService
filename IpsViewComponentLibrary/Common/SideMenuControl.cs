using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Collections.Generic;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;

namespace IpsViewComponentLibrary.Common
{
    public partial class SideMenuControl : UserControl
    {
        public event EventHandler SelectedMenuItemChanged;

        private SideMenuItem _selectedMenuItem;
        public SideMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                OnSelectedMenuItemChanged();
            }
        }

        private void OnSelectedMenuItemChanged()
        {
            SelectedMenuItemChanged?.Invoke(this, EventArgs.Empty);
        }

        private SideMenuItemCollection _items;
        public SideMenuItemCollection Items { get { return _items; } }

        public SideMenuControl()
        {
            InitializeComponent();

            _items = new SideMenuItemCollection();
            _items.CollectionChanged += Items_CollectionChanged;

            tvMenu.ExpandAll();
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            PopulateNodes();

            tvMenu.ExpandAll();
        }

        private void PopulateNodes()
        {
            SuspendLayout();

            tvMenu.Nodes.Clear();

            AddNodesFromItemCollection(tvMenu.Nodes, _items);

            ResumeLayout(false);
        }

        private void AddNodesFromItemCollection(RadTreeNodeCollection nodes, SideMenuItemCollection items)
        {
            foreach (var item in items)
            {
                var node = new RadTreeNode { Text = item.Text, Value = item, Selected = item.Selected };

                if (item.Items.Any())
                {
                    AddNodesFromItemCollection(node.Nodes, item.Items);
                }

                nodes.Add(node);

                if (item.Selected)
                {
                    _selectedMenuItem = item;
                }
            }
        }

        private void tvMenu_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                var backColor = SystemColors.ControlLight;// Color.LightGray;

                // set font to bold for root node
                e.NodeElement.Font = new Font(this.Font, FontStyle.Bold);
                e.NodeElement.BackColor = backColor;
                e.NodeElement.BorderColor = backColor;

                if (e.NodeElement.IsMouseOver)
                {
                    // prevent hover highligting root node
                    e.NodeElement.BackColor = backColor;
                    e.NodeElement.BorderColor = backColor;
                }
            }

            if (e.Node.Level == 1)
            {
                // set font to bold for nodes with level 1
                e.NodeElement.Font = new Font(this.Font, FontStyle.Bold);
            }

            if (e.Node.Level != 0)
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

        private void tvMenu_SelectedNodeChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            var menuItem = (SideMenuItem)e.Node.Value;

            if (!menuItem.IsSelectable)
            {
                e.Cancel = true;
                return;
            }
        }

        private void tvMenu_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            SelectedMenuItem = (SideMenuItem)e.Node.Value;
        }
    }

    public class SideMenuItemCollection : NotifyCollection<SideMenuItem>
    {
    }

    public class SideMenuItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public bool IsSelectable { get; set; } = true;
        public bool Selected { get; set; } = false;
        public SideMenuItemCollection Items { get; } = new SideMenuItemCollection();
    }
}
