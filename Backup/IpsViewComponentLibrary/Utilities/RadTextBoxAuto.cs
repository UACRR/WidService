using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public class RadTextBoxAuto : RadTextBoxControl
    {
        private bool _callProcessDialogKey = true;

        public override string ThemeClassName
        {
            get
            {
                return typeof(RadTextBoxControl).FullName;
            }
        }

        public event EventHandler<RadListDataItem> ListItemSelected;

        public RadTextBoxAuto()
            : base()
        {
            ListElement.ElementTree.Control.KeyDown += new KeyEventHandler(radTextBoxControl1_KeyDown);
            ListElement.ElementTree.Control.Click += this.OnListElementClick;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (!_callProcessDialogKey && (keyData == Keys.Tab || keyData == Keys.Enter))
            {
                _callProcessDialogKey = true;
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// Подія натиску клавіші мишки на елемент списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnListElementClick(object sender, EventArgs e)
        {
            FireClick();
        }

        /// <summary>
        /// Метод отриманя елемента на якому натиснута клавіша мишки 
        /// </summary>
        private void FireClick()
        {
            if (ListItemSelected == null)
                return;

            ComponentThemableElementTree elementTree = ListElement.ElementTree;
            Point mousePosition = elementTree.Control.PointToClient(MousePosition);
            RadElement element = elementTree.GetElementAtPoint(mousePosition);

            while (element != null)
            {
                if (element is RadListVisualItem item)
                {
                    OnListItemSelected(item.Data);
                    break;
                }

                element = element.Parent;
            }
        }

        /// <summary>
        /// Ввод з клавіатури
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radTextBoxControl1_KeyDown(object sender, KeyEventArgs e)
        {
           if (ListElement.ActiveItem != null && (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter))
            {
                _callProcessDialogKey = false;
                OnListItemSelected(ListElement.ActiveItem);
            }
        }

        protected void OnListItemSelected(RadListDataItem item)
        {
            ListItemSelected(this, item);
        }
    }
}
