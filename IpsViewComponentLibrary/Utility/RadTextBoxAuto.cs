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
                var dropDown = sender as ComponentThemableElementTree;

                RadListDataItem item = AutoCompleteItems.Where(rec => rec.Value == ListElement.ActiveItem.Value).FirstOrDefault();

                if (item != null)
                {
                    OnListItemSelected(item as RadListDataItem);
                }
            }
        }

        protected void OnListItemSelected(RadListDataItem item)
        {
            ListItemSelected(this, item);
        }
    }
}
