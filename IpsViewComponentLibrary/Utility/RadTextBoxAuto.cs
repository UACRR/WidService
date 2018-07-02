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
        public Action<RadListDataItem> AcceptAuto { set; get; }
        //private int index = -1;
        //private RadListDataItem currentItem = null;
        public RadTextBoxAuto()
            : base()
        {
            // acceptAuto = action;
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
            if (AcceptAuto == null) return;
            ComponentThemableElementTree elementTree = ListElement.ElementTree;
            Point mousePosition = elementTree.Control.PointToClient(MousePosition);
            RadElement element = elementTree.GetElementAtPoint(mousePosition);


            while (element != null)
            {
                if (element is RadListVisualItem item)
                {
                    AcceptAuto(item.Data);
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
                    AcceptAuto(item as RadListDataItem);
                }
            }
        }
    }
}
