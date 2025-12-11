using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadioStationReports
{
    public class ListViewMenu
    {
        private readonly Size MENU_SIZE = new (253, 114);
        private readonly Size MENU_ITEM_SIZE = new (252, 22);

        private ContextMenuStrip contextMenuStrip;

        private ToolStripMenuItem toolStripMenuItemCopy;
        private ToolStripMenuItem toolStripMenuRowCopy;
        private ToolStripMenuItem toolStripMenuRowCopyEx;
        private ToolStripMenuItem toolStripMenuAllCopy;
        private ToolStripMenuItem toolStripMenuAllEx;

        private ListView _lv;
        private ListViewItem _lvItem;
        private ListViewItem.ListViewSubItem _lvSubItem;

        public ListViewMenu(ListView lv)
        {
            // 
            // toolStripMenuItemCopy
            // 
            toolStripMenuItemCopy = new ToolStripMenuItem
            {
                Name = "toolStripMenuItemCopy",
                Size = MENU_ITEM_SIZE,
                Text = "Копіювати значення",
            };
            toolStripMenuItemCopy.Click += ToolStripMenuItemCopy_Click;;
            
            // 
            // toolStripMenuRowCopy
            //
            toolStripMenuRowCopy = new ToolStripMenuItem
            {
                Name = "toolStripMenuRowCopy",
                Size = MENU_ITEM_SIZE,
                Text = "Копіювати рядок",
            };
            toolStripMenuRowCopy.Click += ToolStripMenuRowCopy_Click;
            
            // 
            // toolStripMenuRowCopyEx
            // 
            toolStripMenuRowCopyEx = new ToolStripMenuItem
            {
                Name = "toolStripMenuRowCopyEx",
                Size = MENU_ITEM_SIZE,
                Text = "Копіювати рядок із заголовками",
            };
            toolStripMenuRowCopyEx.Click += ToolStripMenuRowCopyEx_Click;
            
            // 
            // toolStripMenuAllCopy
            //
            toolStripMenuAllCopy = new ToolStripMenuItem
            {
                Name = "toolStripMenuAllCopy",
                Size = MENU_ITEM_SIZE,
                Text = "Копіювати все",
            };
            toolStripMenuAllCopy.Click += ToolStripMenuAllCopy_Click;
            
            // 
            // toolStripMenuAllEx
            //
            toolStripMenuAllEx = new ToolStripMenuItem
            {
                Name = "toolStripMenuAllEx",
                Size = MENU_ITEM_SIZE,
                Text = "Копіювати все із заголовками",
            };
            toolStripMenuAllEx.Click += ToolStripMenuAllEx_Click;

            // 
            // contextMenuStrip
            // 
            contextMenuStrip = new ContextMenuStrip();
            //contextMenuStrip.SuspendLayout();
            contextMenuStrip.Items.AddRange([
                toolStripMenuItemCopy, 
                toolStripMenuRowCopy, 
                toolStripMenuRowCopyEx, 
                toolStripMenuAllCopy, 
                toolStripMenuAllEx
            ]);
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = MENU_SIZE;
            //contextMenuStrip.ResumeLayout(false);

            _lv = lv;
        }
        
        public void Show(Point point)
        {
            _lvItem = _lv.GetItemAt(point.X, point.Y);
            _lvSubItem = _lvItem?.GetSubItemAt(point.X, point.Y);

            toolStripMenuItemCopy.Enabled = _lvSubItem != null;
            toolStripMenuRowCopy.Enabled = _lvItem != null;
            toolStripMenuRowCopyEx.Enabled = _lvItem != null;

            contextMenuStrip.Show(_lv, point, ToolStripDropDownDirection.BelowRight);
        }

        private string GetCbdHeaderText()
        {
            var sb = new StringBuilder();
            for (var idx = 0; idx < _lv.Columns.Count; idx++)
            {
                var col = _lv.Columns[idx];
                sb.Append(col.Text);
                if(idx < _lv.Columns.Count - 1)
                {
                    sb.Append("\t");
                }
            }
            return sb.ToString();
        }

        private string GetCbdLvItemText(ListViewItem lvItem)
        {
            if(lvItem == null)
            {
                return "";
            }
            
            var sb = new StringBuilder();
            for (var idx = 0; idx < lvItem.SubItems.Count; idx++)
            {
                var subItem = lvItem.SubItems[idx];
                sb.Append(subItem.Text);
                if(idx < lvItem.SubItems.Count - 1)
                {
                    sb.Append('\t');
                }
            }
            return sb.ToString();
        }

        private void AppendCbdLvItemText(StringBuilder sb, ListViewItem lvItem)
        {
            if(lvItem == null)
            {
                return;
            }

            for (var idx = 0; idx < lvItem.SubItems.Count; idx++)
            {
                var subItem = lvItem.SubItems[idx];
                sb.Append(subItem.Text);
                if(idx < lvItem.SubItems.Count - 1)
                {
                    sb.Append('\t');
                }
            }
        }

        private string GetCbdLvAllText()
        {
            var sb = new StringBuilder();
            for (var idx = 0; idx < _lv.Items.Count; idx++)
            {
                var lvItem = _lv.Items[idx];
                AppendCbdLvItemText(sb, lvItem);
                if(idx < _lv.Items.Count - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        private void SetCbdText(string cbdText)
        {
            if(string.IsNullOrEmpty(cbdText))
            {
                Clipboard.Clear();
            }
            else
            {
                Clipboard.SetText(cbdText);
            }
        }

        private void ToolStripMenuItemCopy_Click(object sender, EventArgs e)
        {
            var cbdText = _lvSubItem == null ? "" : _lvSubItem.Text;
            SetCbdText(cbdText);
        }
        private void ToolStripMenuRowCopy_Click(object sender, EventArgs e)
        {
            var cbdText = GetCbdLvItemText(_lvItem);
            SetCbdText(cbdText);
        }
        private void ToolStripMenuRowCopyEx_Click(object sender, EventArgs e)
        {
            var cbdText = $"{GetCbdHeaderText()}{Environment.NewLine}{GetCbdLvItemText(_lvItem)}";
            SetCbdText(cbdText);
        }        
        private void ToolStripMenuAllCopy_Click(object sender, EventArgs e)
        {
            var cbdText = GetCbdLvAllText();
            SetCbdText(cbdText);
        }
        private void ToolStripMenuAllEx_Click(object sender, EventArgs e)
        {
            var cbdText = $"{GetCbdHeaderText()}{Environment.NewLine}{GetCbdLvAllText()}";
            SetCbdText(cbdText);
        }

    }
}
